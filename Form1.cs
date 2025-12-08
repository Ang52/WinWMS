namespace WinWMS
{
    public partial class Form1 : Form
    {
        private Button? currentActiveButton;
        private Form? currentChildForm;

        public Form1()
        {
            InitializeComponent();
            SetupButtonHoverEffects();
            currentActiveButton = btnHome;
            ShowWelcomePage();
        }

        // 在主面板中显示子窗体
        private void ShowFormInPanel(Form childForm, string title)
        {
            // 关闭之前的子窗体
            if (currentChildForm != null)
            {
                currentChildForm.Close();
                currentChildForm.Dispose();
            }

            // 更新标题
            lblPageTitle.Text = title;

            // 清空主面板
            mainPanel.Controls.Clear();

            // 配置子窗体
            currentChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            // 添加到主面板
            mainPanel.Controls.Add(childForm);
            childForm.Show();
        }

        private void ShowWelcomePage()
        {
            // 关闭之前的子窗体
            if (currentChildForm != null)
            {
                currentChildForm.Close();
                currentChildForm.Dispose();
                currentChildForm = null;
            }

            lblPageTitle.Text = "欢迎使用仓储管理系统";

            // 清空主面板
            mainPanel.Controls.Clear();

            // 创建欢迎面板
            Panel welcomePanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White
            };

            // 欢迎标题
            Label lblWelcome = new Label
            {
                Text = "欢迎使用 WinWMS 仓储管理系统",
                Font = new Font("Microsoft YaHei UI", 24, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 122, 204),
                AutoSize = true,
                Location = new Point(100, 80)
            };

            // 系统描述
            Label lblDescription = new Label
            {
                Text = "现代化的仓储管理解决方案",
                Font = new Font("Microsoft YaHei UI", 14),
                ForeColor = Color.FromArgb(128, 128, 128),
                AutoSize = true,
                Location = new Point(100, 140)
            };

            // 功能卡片容器
            FlowLayoutPanel cardsPanel = new FlowLayoutPanel
            {
                Location = new Point(50, 200),
                Size = new Size(700, 300),
                AutoScroll = true
            };

            // 添加功能卡片
            cardsPanel.Controls.Add(CreateFeatureCard("📥 入库管理", "快速记录物资入库信息"));
            cardsPanel.Controls.Add(CreateFeatureCard("📤 出库管理", "高效处理物资出库流程"));
            cardsPanel.Controls.Add(CreateFeatureCard("📊 数据查询", "实时查询库存和记录"));
            cardsPanel.Controls.Add(CreateFeatureCard("📈 报表分析", "生成月度统计报表"));

            // 底部信息
            Label lblFooter = new Label
            {
                Text = "请从左侧菜单选择功能开始使用",
                Font = new Font("Microsoft YaHei UI", 10),
                ForeColor = Color.FromArgb(150, 150, 150),
                AutoSize = true,
                Location = new Point(100, 450)
            };

            welcomePanel.Controls.Add(lblWelcome);
            welcomePanel.Controls.Add(lblDescription);
            welcomePanel.Controls.Add(cardsPanel);
            welcomePanel.Controls.Add(lblFooter);

            mainPanel.Controls.Add(welcomePanel);
        }

        private Panel CreateFeatureCard(string title, string description)
        {
            Panel card = new Panel
            {
                Size = new Size(300, 120),
                BackColor = Color.FromArgb(240, 248, 255),
                Margin = new Padding(10),
                Padding = new Padding(20)
            };

            Label lblTitle = new Label
            {
                Text = title,
                Font = new Font("Microsoft YaHei UI", 12, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 122, 204),
                AutoSize = true,
                Location = new Point(20, 20)
            };

            Label lblDesc = new Label
            {
                Text = description,
                Font = new Font("Microsoft YaHei UI", 9),
                ForeColor = Color.FromArgb(100, 100, 100),
                AutoSize = true,
                Location = new Point(20, 55)
            };

            card.Controls.Add(lblTitle);
            card.Controls.Add(lblDesc);

            // 添加悬停效果
            card.MouseEnter += (s, e) => card.BackColor = Color.FromArgb(230, 244, 255);
            card.MouseLeave += (s, e) => card.BackColor = Color.FromArgb(240, 248, 255);

            return card;
        }

        private void SetupButtonHoverEffects()
        {
            // 为所有侧边栏按钮添加鼠标悬停效果
            foreach (Control control in sidebarPanel.Controls)
            {
                if (control is Button btn && btn != btnExit)
                {
                    btn.MouseEnter += NavButton_MouseEnter;
                    btn.MouseLeave += NavButton_MouseLeave;
                    btn.Click += NavButton_Click;
                }
            }

            // 为主页按钮添加特殊处理
            btnHome.Click += (s, e) => ShowWelcomePage();
        }

        private void NavButton_MouseEnter(object? sender, EventArgs e)
        {
            if (sender is Button btn && btn != currentActiveButton)
            {
                btn.BackColor = Color.FromArgb(62, 62, 66);
            }
        }

        private void NavButton_MouseLeave(object? sender, EventArgs e)
        {
            if (sender is Button btn && btn != currentActiveButton)
            {
                btn.BackColor = Color.FromArgb(45, 45, 48);
            }
        }

        private void NavButton_Click(object? sender, EventArgs e)
        {
            if (sender is Button btn)
            {
                // 重置之前激活的按钮
                if (currentActiveButton != null)
                {
                    currentActiveButton.BackColor = Color.FromArgb(45, 45, 48);
                }
                
                // 设置当前按钮为激活状态
                btn.BackColor = Color.FromArgb(62, 62, 66);
                currentActiveButton = btn;
            }
        }

        private void MonthlyReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowFormInPanel(new MonthlyReportForm(), "月度报表");
        }

        private void OutboundQueryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowFormInPanel(new OutboundQueryForm(), "出库查询");
        }

        private void InboundQueryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowFormInPanel(new InboundQueryForm(), "入库查询");
        }

        private void InventoryQueryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowFormInPanel(new InventoryQueryForm(), "库存查询");
        }

        private void OutboundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowFormInPanel(new OutboundForm(), "出库管理");
        }

        private void InboundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowFormInPanel(new InboundForm(), "入库管理");
        }

        private void WarehouseManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowFormInPanel(new WarehouseManagementForm(), "仓库管理");
        }

        private void MaterialManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowFormInPanel(new MaterialManagementForm(), "物料管理");
        }

        private void UserManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowFormInPanel(new UserManagementForm(), "用户管理");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要退出系统吗？", "退出确认", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
