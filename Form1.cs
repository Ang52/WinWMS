using System.Runtime.InteropServices;

namespace WinWMS
{
    public partial class Form1 : Form
    {
        private Button? currentActiveButton;
        private Form? currentChildForm;

        // Windows API for title bar color
        [DllImport("dwmapi.dll")]
        private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);

        private const int DWMWA_USE_IMMERSIVE_DARK_MODE = 20;
        private const int DWMWA_CAPTION_COLOR = 35;

        public Form1()
        {
            InitializeComponent();
            SetTitleBarColor();
            SetupButtonHoverEffects();
            currentActiveButton = btnHome;
            ShowWelcomePage();
        }

        private void SetTitleBarColor()
        {
            if (OperatingSystem.IsWindowsVersionAtLeast(10, 0, 22000))
            {
                // 粉色 RGB(255, 182, 193) 转换为 BGR 格式
                int color = 0x00C1B6FF; // BGR格式: BB GG RR
                DwmSetWindowAttribute(this.Handle, DWMWA_CAPTION_COLOR, ref color, sizeof(int));
            }
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            SetTitleBarColor();
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

            // 主容器面板 - 启用自动滚动
            Panel welcomePanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                AutoScroll = true
            };

            // 内容容器 - 使用绝对定位
            Panel contentContainer = new Panel
            {
                BackColor = Color.White,
                AutoScroll = false,
                Location = new Point(0, 0)
            };

            // 标题
            Label lblWelcome = new Label
            {
                Text = "欢迎使用 WinWMS 仓储管理系统 ✨",
                Font = new Font("Microsoft YaHei UI", 24, FontStyle.Bold),
                ForeColor = Color.FromArgb(219, 112, 147),
                AutoSize = true,
                TextAlign = ContentAlignment.MiddleCenter
            };

            // 描述
            Label lblDescription = new Label
            {
                Text = "现代化粉色主题 · 响应式设计 · 优雅的仓储管理",
                Font = new Font("Microsoft YaHei UI", 12),
                ForeColor = Color.FromArgb(255, 105, 180),
                AutoSize = true,
                TextAlign = ContentAlignment.MiddleCenter
            };

            // 卡片网格容器 - 固定3列2行
            TableLayoutPanel cardsPanel = new TableLayoutPanel
            {
                ColumnCount = 3,
                RowCount = 2,
                CellBorderStyle = TableLayoutPanelCellBorderStyle.None,
                BackColor = Color.Transparent
            };

            // 设置列样式 - 每列33.33%
            cardsPanel.ColumnStyles.Clear();
            cardsPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            cardsPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            cardsPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.34F));

            // 设置行样式 - 每行50%
            cardsPanel.RowStyles.Clear();
            cardsPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            cardsPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));

            // 卡片数据
            var cards = new[]
            {
                new { Icon = "📥", Title = "入库管理", Desc = "快速记录物资入库信息", Color = Color.FromArgb(255, 182, 193) },
                new { Icon = "📤", Title = "出库管理", Desc = "高效处理物资出库流程", Color = Color.FromArgb(255, 192, 203) },
                new { Icon = "📊", Title = "数据查询", Desc = "实时查询库存和记录", Color = Color.FromArgb(255, 218, 224) },
                new { Icon = "📈", Title = "报表分析", Desc = "生成月度统计报表", Color = Color.FromArgb(255, 182, 193) },
                new { Icon = "📦", Title = "物资管理", Desc = "管理所有物资信息", Color = Color.FromArgb(255, 192, 203) },
                new { Icon = "👥", Title = "用户管理", Desc = "系统用户权限管理", Color = Color.FromArgb(255, 218, 224) }
            };

            // 添加卡片到网格 - 按行填充
            for (int i = 0; i < cards.Length; i++)
            {
                int row = i / 3;
                int col = i % 3;
                var card = cards[i];
                var cardPanel = CreateFixedGridCard(card.Icon, card.Title, card.Desc, card.Color);
                cardsPanel.Controls.Add(cardPanel, col, row);
            }

            // 页脚提示
            Label lblFooter = new Label
            {
                Text = "💡 提示：请从左侧菜单选择功能开始使用 | 支持多分辨率自适应",
                Font = new Font("Microsoft YaHei UI", 10),
                ForeColor = Color.FromArgb(180, 180, 180),
                AutoSize = true,
                TextAlign = ContentAlignment.MiddleCenter
            };

            // 添加控件到容器
            contentContainer.Controls.Add(lblWelcome);
            contentContainer.Controls.Add(lblDescription);
            contentContainer.Controls.Add(cardsPanel);
            contentContainer.Controls.Add(lblFooter);

            welcomePanel.Controls.Add(contentContainer);
            mainPanel.Controls.Add(welcomePanel);

            // 窗口大小改变时更新布局
            welcomePanel.Resize += (s, e) => 
            {
                UpdateWelcomeLayout(welcomePanel, contentContainer, lblWelcome, lblDescription, cardsPanel, lblFooter);
            };

            // 使用 Timer 延迟初始化，确保控件完全加载
            System.Windows.Forms.Timer initTimer = new System.Windows.Forms.Timer();
            initTimer.Interval = 50;
            initTimer.Tick += (s, e) =>
            {
                initTimer.Stop();
                initTimer.Dispose();
                if (!welcomePanel.IsDisposed && welcomePanel.IsHandleCreated)
                {
                    UpdateWelcomeLayout(welcomePanel, contentContainer, lblWelcome, lblDescription, cardsPanel, lblFooter);
                }
            };
            initTimer.Start();
        }

        private void UpdateWelcomeLayout(Panel welcomePanel, Panel contentContainer, 
            Label lblWelcome, Label lblDescription, TableLayoutPanel cardsPanel, Label lblFooter)
        {
            // 安全检查
            if (welcomePanel == null || welcomePanel.IsDisposed || !welcomePanel.IsHandleCreated) return;
            if (contentContainer == null || contentContainer.IsDisposed) return;
            if (welcomePanel.Width <= 0 || welcomePanel.Height <= 0) return;

            try
            {
                contentContainer.SuspendLayout();

                // 获取可用空间
                int availableWidth = Math.Max(600, welcomePanel.ClientSize.Width);
                int availableHeight = Math.Max(400, welcomePanel.ClientSize.Height);

                // === 响应式缩放计算 ===
                const float BASE_WIDTH = 1180f;  // 基准宽度（1400 - 220）
                const float MIN_SCALE = 0.65f;   // 最小缩放65%
                const float MAX_SCALE = 1.05f;   // 最大缩放105%
                
                float scale = availableWidth / BASE_WIDTH;
                scale = Math.Max(MIN_SCALE, Math.Min(MAX_SCALE, scale));

                // === 字体响应式调整 ===
                int titleSize = (int)(22 * scale);
                titleSize = Math.Max(14, Math.Min(26, titleSize));
                lblWelcome.Font = new Font("Microsoft YaHei UI", titleSize, FontStyle.Bold);

                int descSize = (int)(11 * scale);
                descSize = Math.Max(8, Math.Min(13, descSize));
                lblDescription.Font = new Font("Microsoft YaHei UI", descSize);

                int footerSize = (int)(9 * scale);
                footerSize = Math.Max(7, Math.Min(11, footerSize));
                lblFooter.Font = new Font("Microsoft YaHei UI", footerSize);

                // === 卡片尺寸计算 ===
                const int BASE_CARD_WIDTH = 220;
                const int BASE_CARD_HEIGHT = 165;
                
                int cardWidth = (int)(BASE_CARD_WIDTH * scale);
                int cardHeight = (int)(BASE_CARD_HEIGHT * scale);
                
                cardWidth = Math.Max(160, Math.Min(260, cardWidth));
                cardHeight = Math.Max(120, Math.Min(195, cardHeight));
                
                int cardSpacing = (int)(18 * scale);
                cardSpacing = Math.Max(8, Math.Min(25, cardSpacing));
                
                int gridWidth = cardWidth * 3 + cardSpacing * 4;
                int gridHeight = cardHeight * 2 + cardSpacing * 3;

                cardsPanel.Size = new Size(gridWidth, gridHeight);
                cardsPanel.Padding = new Padding(cardSpacing);

                // === 间距计算 ===
                int spacing = (int)(18 * scale);
                spacing = Math.Max(8, Math.Min(25, spacing));

                // === 总高度计算 ===
                int totalHeight = 
                    lblWelcome.Height + spacing +
                    lblDescription.Height + (spacing * 2) +
                    gridHeight + (spacing * 2) +
                    lblFooter.Height + 50;

                // === 垂直居中 ===
                int topMargin = Math.Max(25, (availableHeight - totalHeight) / 2);
                if (totalHeight > availableHeight - 50)
                {
                    topMargin = 25;
                }

                // === 水平居中 ===
                int centerX = availableWidth / 2;

                // === 设置位置 ===
                lblWelcome.Location = new Point(Math.Max(15, centerX - lblWelcome.Width / 2), topMargin);
                lblDescription.Location = new Point(Math.Max(15, centerX - lblDescription.Width / 2), lblWelcome.Bottom + spacing);
                cardsPanel.Location = new Point(Math.Max(15, centerX - gridWidth / 2), lblDescription.Bottom + (spacing * 2));
                lblFooter.Location = new Point(Math.Max(15, centerX - lblFooter.Width / 2), cardsPanel.Bottom + (spacing * 2));

                // === 设置容器大小 ===
                int containerHeight = Math.Max(lblFooter.Bottom + 60, totalHeight + 30);
                contentContainer.Size = new Size(availableWidth, containerHeight);

                // === 更新卡片 ===
                foreach (Control ctrl in cardsPanel.Controls)
                {
                    if (ctrl is Panel cardPanel)
                    {
                        cardPanel.Size = new Size(cardWidth, cardHeight);
                        cardPanel.Margin = new Padding((int)(8 * scale));
                        UpdateCardSize(cardPanel, cardWidth, cardHeight);
                    }
                }
            }
            catch
            {
                // 忽略布局错误
            }
            finally
            {
                contentContainer.ResumeLayout(true);
            }
        }

        private Panel CreateFixedGridCard(string icon, string title, string description, Color bgColor)
        {
            Panel card = new Panel
            {
                BackColor = bgColor,
                Margin = new Padding(10),
                Cursor = Cursors.Hand,
                Dock = DockStyle.Fill,
                Tag = new { Icon = icon, Title = title, Description = description, BgColor = bgColor, OriginalColor = bgColor }
            };

            // 图标
            Label lblIcon = new Label
            {
                Name = "lblIcon",
                Text = icon,
                ForeColor = Color.White,
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = Color.Transparent
            };

            // 标题
            Label lblTitle = new Label
            {
                Name = "lblTitle",
                Text = title,
                ForeColor = Color.White,
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = Color.Transparent
            };

            // 描述
            Label lblDesc = new Label
            {
                Name = "lblDesc",
                Text = description,
                ForeColor = Color.White,
                AutoSize = false,
                TextAlign = ContentAlignment.TopCenter,
                BackColor = Color.Transparent
            };

            card.Controls.Add(lblIcon);
            card.Controls.Add(lblTitle);
            card.Controls.Add(lblDesc);

            // 悬停效果 - 避免抖动
            Color hoverColor = Color.FromArgb(
                Math.Max(0, bgColor.R - 20),
                Math.Max(0, bgColor.G - 20),
                Math.Max(0, bgColor.B - 20)
            );

            EventHandler mouseEnter = (s, e) => { card.BackColor = hoverColor; };
            EventHandler mouseLeave = (s, e) => { card.BackColor = bgColor; };

            card.MouseEnter += mouseEnter;
            card.MouseLeave += mouseLeave;

            // 子控件也响应鼠标事件，但不改变卡片大小（避免抖动）
            foreach (Control ctrl in card.Controls)
            {
                ctrl.MouseEnter += mouseEnter;
                ctrl.MouseLeave += mouseLeave;
            }

            return card;
        }

        private void UpdateCardSize(Panel card, int width, int height)
        {
            // 更新卡片内部控件的大小和位置
            foreach (Control ctrl in card.Controls)
            {
                if (ctrl is Label lbl)
                {
                    if (lbl.Name == "lblIcon")
                    {
                        lbl.Font = new Font("Segoe UI Emoji", Math.Max(32, height / 5));
                        lbl.Size = new Size(width - 20, (int)(height * 0.45));
                        lbl.Location = new Point(10, (int)(height * 0.1));
                    }
                    else if (lbl.Name == "lblTitle")
                    {
                        lbl.Font = new Font("Microsoft YaHei UI", Math.Max(11, width / 22), FontStyle.Bold);
                        lbl.Size = new Size(width - 20, (int)(height * 0.15));
                        lbl.Location = new Point(10, (int)(height * 0.55));
                    }
                    else if (lbl.Name == "lblDesc")
                    {
                        lbl.Font = new Font("Microsoft YaHei UI", Math.Max(8, width / 30));
                        lbl.Size = new Size(width - 20, (int)(height * 0.25));
                        lbl.Location = new Point(10, (int)(height * 0.70));
                    }
                }
            }
        }

        private void RepositionContent(Panel contentPanel, Label lblWelcome, Label lblDescription, 
            FlowLayoutPanel cardsContainer, Label lblFooter)
        {
            // 保留此方法以防编译错误，但不再使用
        }

        private Panel CreateResponsiveCard(string icon, string title, string description, Color bgColor)
        {
            // 保留此方法以防编译错误，使用新的固定网格方法
            return CreateFixedGridCard(icon, title, description, bgColor);
        }

        private Panel CreateImageCard(string icon, string title, string description, Color bgColor)
        {
            // 保留旧方法以保持兼容性
            return CreateFixedGridCard(icon, title, description, bgColor);
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
                btn.BackColor = Color.FromArgb(255, 200, 210);  // 微微发白的浅粉色悬停
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
                btn.BackColor = Color.FromArgb(255, 200, 210);  // 微微发白的浅粉色激活
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
