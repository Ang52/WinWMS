using System.Security.Cryptography;
using System.Text;
using MySql.Data.MySqlClient;

namespace WinWMS
{
    public partial class LoginForm : Form
    {
        private List<Particle> particles = new List<Particle>();
        private System.Windows.Forms.Timer? animationTimer;
        private Random random = new Random();

        public LoginForm()
        {
            InitializeComponent();
            
            // 设置窗体样式
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            
            // 初始化粒子
            InitializeParticles();
            
            // 启动动画定时器
            animationTimer = new System.Windows.Forms.Timer();
            animationTimer.Interval = 30; // 约33fps
            animationTimer.Tick += AnimationTimer_Tick;
            animationTimer.Start();
            
            // 绑定事件
            btnLogin.Click += BtnLogin_Click;
            txtPassword.KeyPress += TxtPassword_KeyPress;
            txtUsername.KeyPress += TxtUsername_KeyPress;
            
            // 设置登录面板圆角和阴影效果
            SetupPanelStyle();
            
            // 窗体加载时设置焦点
            this.Load += (s, e) => txtUsername.Focus();
            
            // 绘制粒子背景
            this.Paint += LoginForm_Paint;
        }

        private void TxtUsername_KeyPress(object? sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtPassword.Focus();
                e.Handled = true;
            }
        }

        private void TxtPassword_KeyPress(object? sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                BtnLogin_Click(sender, e);
                e.Handled = true;
            }
        }

        private void InitializeParticles()
        {
            // 创建80个粒子
            for (int i = 0; i < 80; i++)
            {
                particles.Add(new Particle
                {
                    X = random.Next(0, this.ClientSize.Width),
                    Y = random.Next(0, this.ClientSize.Height),
                    Size = random.Next(2, 6),
                    SpeedX = (float)(random.NextDouble() * 1.5 - 0.75),
                    SpeedY = (float)(random.NextDouble() * 1.5 - 0.75),
                    Opacity = random.Next(50, 200)
                });
            }
        }

        private void AnimationTimer_Tick(object? sender, EventArgs e)
        {
            // 更新粒子位置
            foreach (var particle in particles)
            {
                particle.X += particle.SpeedX;
                particle.Y += particle.SpeedY;

                // 边界检测
                if (particle.X < 0 || particle.X > this.ClientSize.Width)
                    particle.SpeedX = -particle.SpeedX;
                if (particle.Y < 0 || particle.Y > this.ClientSize.Height)
                    particle.SpeedY = -particle.SpeedY;

                // 确保粒子在边界内
                particle.X = Math.Max(0, Math.Min(this.ClientSize.Width, particle.X));
                particle.Y = Math.Max(0, Math.Min(this.ClientSize.Height, particle.Y));
            }

            // 重绘窗体
            this.Invalidate();
        }

        private void LoginForm_Paint(object? sender, PaintEventArgs e)
        {
            // 启用抗锯齿
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // 绘制粒子
            foreach (var particle in particles)
            {
                using (SolidBrush brush = new SolidBrush(Color.FromArgb(particle.Opacity, 255, 182, 193)))
                {
                    e.Graphics.FillEllipse(brush, particle.X, particle.Y, particle.Size, particle.Size);
                }
            }

            // 绘制连接线（距离较近的粒子之间）
            for (int i = 0; i < particles.Count; i++)
            {
                for (int j = i + 1; j < particles.Count; j++)
                {
                    float dx = particles[i].X - particles[j].X;
                    float dy = particles[i].Y - particles[j].Y;
                    float distance = (float)Math.Sqrt(dx * dx + dy * dy);

                    if (distance < 120)
                    {
                        int opacity = (int)(100 * (1 - distance / 120));
                        using (Pen pen = new Pen(Color.FromArgb(opacity, 255, 182, 193), 1))
                        {
                            e.Graphics.DrawLine(pen, particles[i].X + particles[i].Size / 2, 
                                particles[i].Y + particles[i].Size / 2,
                                particles[j].X + particles[j].Size / 2, 
                                particles[j].Y + particles[j].Size / 2);
                        }
                    }
                }
            }
        }

        private void SetupPanelStyle()
        {
            // 设置按钮圆角效果
            btnLogin.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, btnLogin.Width, btnLogin.Height, 15, 15));
            
            // 按钮悬停效果
            btnLogin.MouseEnter += (s, e) => btnLogin.BackColor = Color.FromArgb(230, 140, 160);
            btnLogin.MouseLeave += (s, e) => btnLogin.BackColor = Color.FromArgb(240, 160, 175);
        }

        // Windows API 用于创建圆角矩形
        [System.Runtime.InteropServices.DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
        );

        private void BtnLogin_Click(object? sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            // 验证输入
            if (string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show("请输入用户名！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("请输入密码！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }

            try
            {
                // 查询用户信息
                string query = "SELECT id, username, password_hash, role FROM users WHERE username = @username";
                MySqlParameter[] parameters = { new MySqlParameter("@username", username) };
                
                var dt = DbHelper.ExecuteQuery(query, parameters);

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("用户名或密码错误！", "登录失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPassword.Clear();
                    txtPassword.Focus();
                    return;
                }

                // 获取数据库中的密码哈希
                string storedHash = dt.Rows[0]["password_hash"].ToString() ?? "";
                
                // 验证密码（这里使用简单的哈希对比，实际应使用 BCrypt）
                string inputHash = ComputeSha256Hash(password);
                
                if (storedHash != inputHash)
                {
                    MessageBox.Show("用户名或密码错误！", "登录失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPassword.Clear();
                    txtPassword.Focus();
                    return;
                }

                // 登录成功，设置用户会话
                UserSession.UserId = Convert.ToInt32(dt.Rows[0]["id"]);
                UserSession.Username = dt.Rows[0]["username"].ToString() ?? "";
                UserSession.Role = dt.Rows[0]["role"].ToString() ?? "";

                // 显示欢迎消息
                string roleName = UserSession.IsAdmin ? "管理员" : "操作员";
                MessageBox.Show($"欢迎您，{UserSession.Username}！\n\n您的角色：{roleName}", 
                    "登录成功", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // 停止动画定时器
                animationTimer?.Stop();

                // 设置对话框结果并关闭
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"登录过程中发生错误：\n{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 计算字符串的 SHA256 哈希值
        /// 注意：生产环境建议使用 BCrypt 或 Argon2
        /// </summary>
        private string ComputeSha256Hash(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            animationTimer?.Stop();
            animationTimer?.Dispose();
        }

        // 粒子类
        private class Particle
        {
            public float X { get; set; }
            public float Y { get; set; }
            public int Size { get; set; }
            public float SpeedX { get; set; }
            public float SpeedY { get; set; }
            public int Opacity { get; set; }
        }
    }
}
