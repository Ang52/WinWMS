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
            if (currentChildForm != null)
            {
                currentChildForm.Close();
                currentChildForm.Dispose();
                currentChildForm = null;
            }

            lblPageTitle.Text = "欢迎使用仓储管理系统";
            mainPanel.Controls.Clear();

            Panel welcomePanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                AutoScroll = true
            };

            Label lblWelcome = new Label
            {
                Text = "欢迎使用 WinWMS 仓储管理系统 ✨",
                Font = new Font("Microsoft YaHei UI", 28, FontStyle.Bold),
                ForeColor = Color.FromArgb(219, 112, 147),
                AutoSize = true,
                Location = new Point(80, 60)
            };

            Label lblDescription = new Label
            {
                Text = "现代化粉色主题 · 响应式设计 · 优雅的仓储管理解决方案",
                Font = new Font("Microsoft YaHei UI", 14),
                ForeColor = Color.FromArgb(255, 105, 180),
                AutoSize = true,
                Location = new Point(80, 120)
            };

            TableLayoutPanel cardsPanel = new TableLayoutPanel
            {
                Location = new Point(40, 180),
                Size = new Size(1000, 400),
                ColumnCount = 3,
                RowCount = 2,
                Padding = new Padding(20)
            };

            cardsPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            cardsPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            cardsPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            cardsPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 180F));
            cardsPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 180F));

            cardsPanel.Controls.Add(CreateImageCard("📥", "入库管理", "快速记录物资入库信息", Color.FromArgb(255, 182, 193)), 0, 0);
            cardsPanel.Controls.Add(CreateImageCard("📤", "出库管理", "高效处理物资出库流程", Color.FromArgb(255, 192, 203)), 1, 0);
            cardsPanel.Controls.Add(CreateImageCard("📊", "数据查询", "实时查询库存和记录", Color.FromArgb(255, 218, 224)), 2, 0);
            cardsPanel.Controls.Add(CreateImageCard("📈", "报表分析", "生成月度统计报表", Color.FromArgb(255, 182, 193)), 0, 1);
            cardsPanel.Controls.Add(CreateImageCard("📦", "物资管理", "管理所有物资信息", Color.FromArgb(255, 192, 203)), 1, 1);
            cardsPanel.Controls.Add(CreateImageCard("👥", "用户管理", "系统用户权限管理", Color.FromArgb(255, 218, 224)), 2, 1);

            Label lblFooter = new Label
            {
                Text = "💡 提示：请从左侧菜单选择功能开始使用 | 支持多分辨率自适应",
                Font = new Font("Microsoft YaHei UI", 11),
                ForeColor = Color.FromArgb(180, 180, 180),
                AutoSize = true,
                Location = new Point(80, 600)
            };

            welcomePanel.Controls.Add(lblWelcome);
            welcomePanel.Controls.Add(lblDescription);
            welcomePanel.Controls.Add(cardsPanel);
            welcomePanel.Controls.Add(lblFooter);
            mainPanel.Controls.Add(welcomePanel);
        }

        private Panel CreateImageCard(string icon, string title, string description, Color bgColor)
        {
            Panel card = new Panel { Dock = DockStyle.Fill, BackColor = bgColor, Margin = new Padding(10), Cursor = Cursors.Hand };

            Label lblIcon = new Label
            {
                Text = icon,
                Font = new Font("Segoe UI Emoji", 48),
                ForeColor = Color.White,
                Size = new Size(100, 80),
                TextAlign = ContentAlignment.MiddleCenter
            };

            Label lblTitle = new Label
            {
                Text = title,
                Font = new Font("Microsoft YaHei UI", 13, FontStyle.Bold),
                ForeColor = Color.White,
                Size = new Size(260, 25),
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(10, 100)
            };

            Label lblDesc = new Label
            {
                Text = description,
                Font = new Font("Microsoft YaHei UI", 9),
                ForeColor = Color.White,
                Size = new Size(260, 35),
                TextAlign = ContentAlignment.TopCenter,
                Location = new Point(10, 130)
            };

            card.Controls.Add(lblIcon);
            card.Controls.Add(lblTitle);
            card.Controls.Add(lblDesc);

            card.Resize += (s, e) => lblIcon.Location = new Point((card.Width - 100) / 2, 15);

            Color hoverColor = Color.FromArgb(Math.Max(0, bgColor.R - 20), Math.Max(0, bgColor.G - 20), Math.Max(0, bgColor.B - 20));
            card.MouseEnter += (s, e) => card.BackColor = hoverColor;
            card.MouseLeave += (s, e) => card.BackColor = bgColor;

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

            // 为退出按钮添加特殊悬停效果
            btnExit.MouseEnter += (s, e) => btnExit.BackColor = Color.FromArgb(220, 20, 60);  // 深红色
            btnExit.MouseLeave += (s, e) => btnExit.BackColor = Color.FromArgb(255, 182, 193);

            // 为主页按钮添加特殊处理
            btnHome.Click += (s, e) => ShowWelcomePage();
        }

        private void NavButton_MouseEnter(object? sender, EventArgs e)
        {
            if (sender is Button btn && btn != currentActiveButton)
            {
                btn.BackColor = Color.FromArgb(255, 105, 180);  // 深粉色悬停
            }
        }

        private void NavButton_MouseLeave(object? sender, EventArgs e)
        {
            if (sender is Button btn && btn != currentActiveButton)
            {
                btn.BackColor = Color.FromArgb(255, 182, 193);  // 恢复粉色
            }
        }

        private void NavButton_Click(object? sender, EventArgs e)
        {
            if (sender is Button btn)
            {
                // 重置之前激活的按钮
                if (currentActiveButton != null)
                {
                    currentActiveButton.BackColor = Color.FromArgb(255, 182, 193);
                }
                
                // 设置当前按钮为激活状态
                btn.BackColor = Color.FromArgb(255, 105, 180);  // 深粉色激活
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
