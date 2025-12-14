using System.Runtime.InteropServices;

namespace WinWMS
{
    public partial class Form1 : Form
    {
        private Button? currentActiveButton;
        private Form? currentChildForm;
        
        // 保存欢迎页面的控件引用，以便在窗口大小变化时更新布局
        private Panel? welcomePanel;
        private Panel? contentContainer;
        private Label? lblWelcome;
        private Label? lblDescription;
        private TableLayoutPanel? cardsPanel;
        private Label? lblFooter;

        // Windows API 用于设置标题栏颜色
        [DllImport("dwmapi.dll")]
        private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);

        private const int DWMWA_USE_IMMERSIVE_DARK_MODE = 20;
        private const int DWMWA_CAPTION_COLOR = 35;   // 标题栏颜色属性

        public Form1()
        {
            InitializeComponent();
            SetTitleBarColor();
            SetupButtonHoverEffects();
            currentActiveButton = btnHome;
            
            // 监听窗体大小变化事件，用于动态调整欢迎页布局
            this.Resize += Form1_Resize;
            
            // 根据用户角色设置权限
            ApplyRolePermissions();
            
            ShowWelcomePage();
        }
        
        /// <summary>
        /// 根据用户角色应用权限控制
        /// </summary>
        private void ApplyRolePermissions()
        {
            // 在状态栏显示当前登录用户信息
            string roleName = UserSession.IsAdmin ? "管理员" : "操作员";
            statusLabel.Text = $"当前用户：{UserSession.Username} [{roleName}] | WinWMS v2.0 | .NET 8.0 | 李易远";
            
            // 如果是操作员，隐藏管理员专属功能
            if (UserSession.IsOperator)
            {
                // 隐藏物料管理按钮
                btnMaterialManagement.Visible = false;
                
                // 隐藏仓库管理按钮
                btnWarehouseManagement.Visible = false;
                
                // 隐藏用户管理按钮
                btnUserManagement.Visible = false;
            }
            else if (UserSession.IsAdmin)
            {
                // 管理员拥有所有权限，显示所有按钮
                btnMaterialManagement.Visible = true;
                btnWarehouseManagement.Visible = true;
                btnUserManagement.Visible = true;
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            // 当窗体大小变化时，如果当前显示的是欢迎页面，则更新其布局
            if (currentChildForm == null && welcomePanel != null && !welcomePanel.IsDisposed)
            {
                UpdateWelcomeLayout(welcomePanel, contentContainer!, lblWelcome!, lblDescription!, cardsPanel!, lblFooter!);
            }
        }

        private void SetTitleBarColor()
        {
            if (OperatingSystem.IsWindowsVersionAtLeast(10, 0, 22000))
            {
                // 设置为粉色标题栏：RGB(255, 182, 193) 转为 BGR 格式
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
            // 关闭之前的子窗体，避免资源占用
            if (currentChildForm != null)
            {
                currentChildForm.Close();
                currentChildForm.Dispose();
            }

            // 更新页面标题
            lblPageTitle.Text = title;

            // 清空主面板中原有的控件
            mainPanel.Controls.Clear();

            // 配置子窗体为嵌入模式
            currentChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            // 将子窗体添加到主面板并显示
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

            // 主容器面板 - 启用自动滚动以适配小屏幕
            welcomePanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                AutoScroll = true
            };

            // 内容容器 - 真实内容布局区域
            contentContainer = new Panel
            {
                BackColor = Color.White,
                AutoScroll = false,
                Location = new Point(0, 0)
            };

            // 标题标签
            lblWelcome = new Label
            {
                Text = "欢迎使用 WinWMS 仓储管理系统 ✨",
                Font = new Font("Microsoft YaHei UI", 24, FontStyle.Bold),
                ForeColor = Color.FromArgb(219, 112, 147),
                AutoSize = true,
                TextAlign = ContentAlignment.MiddleCenter
            };

            // 描述标签
            lblDescription = new Label
            {
                Text = "现代化粉色主题 · 响应式设计 · 优雅的仓储管理",
                Font = new Font("Microsoft YaHei UI", 12),
                ForeColor = Color.FromArgb(255, 105, 180),
                AutoSize = true,
                TextAlign = ContentAlignment.MiddleCenter
            };

            // 卡片网格容器 - 固定3列2行
            cardsPanel = new TableLayoutPanel
            {
                ColumnCount = 3,
                RowCount = 2,
                CellBorderStyle = TableLayoutPanelCellBorderStyle.None,
                BackColor = Color.Transparent
            };

            // 列样式：3 列平均分配宽度
            cardsPanel.ColumnStyles.Clear();
            cardsPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            cardsPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            cardsPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.34F));

            // 行样式：2 行平均分配高度
            cardsPanel.RowStyles.Clear();
            cardsPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            cardsPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));

            // 卡片数据源定义
            var cards = new[]
            {
                new { Icon = "📥", Title = "入库管理", Desc = "快速记录物资入库信息", Color = Color.FromArgb(255, 182, 193) },
                new { Icon = "📤", Title = "出库管理", Desc = "高效处理物资出库流程", Color = Color.FromArgb(255, 192, 203) },
                new { Icon = "📊", Title = "数据查询", Desc = "实时查询库存和记录", Color = Color.FromArgb(255, 218, 224) },
                new { Icon = "📈", Title = "报表分析", Desc = "生成月度统计报表", Color = Color.FromArgb(255, 182, 193) },
                new { Icon = "📦", Title = "物资管理", Desc = "管理所有物资信息", Color = Color.FromArgb(255, 192, 203) },
                new { Icon = "👥", Title = "用户管理", Desc = "系统用户权限管理", Color = Color.FromArgb(255, 218, 224) }
            };

            // 将卡片按行填充到表格布局中
            for (int i = 0; i < cards.Length; i++)
            {
                int row = i / 3;
                int col = i % 3;
                var card = cards[i];
                var cardPanel = CreateFixedGridCard(card.Icon, card.Title, card.Desc, card.Color);
                cardsPanel.Controls.Add(cardPanel, col, row);
            }

            // 页脚提示信息
            lblFooter = new Label
            {
                Text = "💡 提示：请从左侧菜单选择功能开始使用 | 支持多分辨率自适应",
                Font = new Font("Microsoft YaHei UI", 10),
                ForeColor = Color.FromArgb(180, 180, 180),
                AutoSize = true,
                TextAlign = ContentAlignment.MiddleCenter
            };

            // 将控件加入内容容器
            contentContainer.Controls.Add(lblWelcome);
            contentContainer.Controls.Add(lblDescription);
            contentContainer.Controls.Add(cardsPanel);
            contentContainer.Controls.Add(lblFooter);

            welcomePanel.Controls.Add(contentContainer);
            mainPanel.Controls.Add(welcomePanel);

            // 欢迎面板大小改变时，动态更新布局
            welcomePanel.Resize += (s, e) => 
            {
                UpdateWelcomeLayout(welcomePanel, contentContainer, lblWelcome, lblDescription, cardsPanel, lblFooter);
            };

            // 使用 Timer 进行一次延迟布局，确保控件已完成创建
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
            // 基本安全检查，防止在销毁/未创建时访问控件
            if (welcomePanel == null || welcomePanel.IsDisposed || !welcomePanel.IsHandleCreated) return;
            if (contentContainer == null || contentContainer.IsDisposed) return;
            if (welcomePanel.Width <= 0 || welcomePanel.Height <= 0) return;

            try
            {
                contentContainer.SuspendLayout();

                // 获取可用区域（限制最小宽高，避免过小导致布局异常）
                int availableWidth = Math.Max(600, welcomePanel.ClientSize.Width);
                int availableHeight = Math.Max(400, welcomePanel.ClientSize.Height);

                // === 响应式缩放计算 ===
                const float BASE_WIDTH = 1180f;  // 基准宽度（根据设计稿估算）
                const float MIN_SCALE = 0.65f;   // 最小缩放比例 65%
                const float MAX_SCALE = 1.05f;   // 最大缩放比例 105%
                
                float scale = availableWidth / BASE_WIDTH;
                scale = Math.Max(MIN_SCALE, Math.Min(MAX_SCALE, scale));

                // === 标题字体自适应 ===
                int titleSize = (int)(22 * scale);
                titleSize = Math.Max(14, Math.Min(26, titleSize));
                lblWelcome.Font = new Font("Microsoft YaHei UI", titleSize, FontStyle.Bold);

                // 描述字体自适应
                int descSize = (int)(11 * scale);
                descSize = Math.Max(8, Math.Min(13, descSize));
                lblDescription.Font = new Font("Microsoft YaHei UI", descSize);

                // 页脚字体自适应
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

                // === 控件上下间距 ===
                int spacing = (int)(18 * scale);
                spacing = Math.Max(8, Math.Min(25, spacing));

                // === 估算整体高度，用于垂直居中或顶部对齐 ===
                int totalHeight = 
                    lblWelcome.Height + spacing +
                    lblDescription.Height + (spacing * 2) +
                    gridHeight + (spacing * 2) +
                    lblFooter.Height + 50;

                // === 垂直方向布局：在高度足够时居中，否则靠上并允许滚动 ===
                int topMargin = Math.Max(25, (availableHeight - totalHeight) / 2);
                if (totalHeight > availableHeight - 50)
                {
                    topMargin = 25;
                }

                // === 水平方向居中 ===
                int centerX = availableWidth / 2;

                // === 设置各控件位置 ===
                lblWelcome.Location = new Point(Math.Max(15, centerX - lblWelcome.Width / 2), topMargin);
                lblDescription.Location = new Point(Math.Max(15, centerX - lblDescription.Width / 2), lblWelcome.Bottom + spacing);
                cardsPanel.Location = new Point(Math.Max(15, centerX - gridWidth / 2), lblDescription.Bottom + (spacing * 2));
                lblFooter.Location = new Point(Math.Max(15, centerX - lblFooter.Width / 2), cardsPanel.Bottom + (spacing * 2));

                // === 更新内容容器尺寸，驱动滚动条显示 ===
                int containerHeight = Math.Max(lblFooter.Bottom + 60, totalHeight + 30);
                contentContainer.Size = new Size(availableWidth, containerHeight);

                // === 同步更新每个卡片内部布局 ===
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
                // 忽略布局过程中的异常，防止影响主程序运行
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
                // 使用 Tag 保存元数据，便于扩展点击事件等
                Tag = new { Icon = icon, Title = title, Description = description, BgColor = bgColor, OriginalColor = bgColor }
            };

            // 图标标签
            Label lblIcon = new Label
            {
                Name = "lblIcon",
                Text = icon,
                ForeColor = Color.White,
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = Color.Transparent
            };

            // 标题标签
            Label lblTitle = new Label
            {
                Name = "lblTitle",
                Text = title,
                ForeColor = Color.White,
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = Color.Transparent
            };

            // 描述标签
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

            // 悬停效果 - 仅改变背景颜色，避免尺寸变化带来抖动
            Color hoverColor = Color.FromArgb(
                Math.Max(0, bgColor.R - 20),
                Math.Max(0, bgColor.G - 20),
                Math.Max(0, bgColor.B - 20)
            );

            EventHandler mouseEnter = (s, e) => { card.BackColor = hoverColor; };
            EventHandler mouseLeave = (s, e) => { card.BackColor = bgColor; };

            card.MouseEnter += mouseEnter;
            card.MouseLeave += mouseLeave;

            // 子控件也绑定鼠标事件，以保证整体卡片区域都有悬停效果
            foreach (Control ctrl in card.Controls)
            {
                ctrl.MouseEnter += mouseEnter;
                ctrl.MouseLeave += mouseLeave;
            }

            return card;
        }

        private void UpdateCardSize(Panel card, int width, int height)
        {
            // 根据卡片宽高，动态调整内部图标/标题/描述的字体和布局
            foreach (Control ctrl in card.Controls)
            {
                if (ctrl is Label lbl)
                {
                    if (lbl.Name == "lblIcon")
                    {
                        // 图标字体大小：最小 24pt，最大 48pt，随高度变化
                        int iconSize = Math.Max(24, Math.Min(48, height / 4));
                        lbl.Font = new Font("Segoe UI Emoji", iconSize);
                        lbl.Size = new Size(width - 20, (int)(height * 0.40));
                        lbl.Location = new Point(10, (int)(height * 0.08));
                    }
                    else if (lbl.Name == "lblTitle")
                    {
                        // 标题字体大小：最小 9pt，最大 14pt，随宽度变化
                        int titleSize = Math.Max(9, Math.Min(14, width / 20));
                        lbl.Font = new Font("Microsoft YaHei UI", titleSize, FontStyle.Bold);
                        lbl.Size = new Size(width - 20, (int)(height * 0.18));
                        lbl.Location = new Point(10, (int)(height * 0.50));
                    }
                    else if (lbl.Name == "lblDesc")
                    {
                        // 描述字体大小：最小 7pt，最大 10pt
                        int descSize = Math.Max(7, Math.Min(10, width / 28));
                        lbl.Font = new Font("Microsoft YaHei UI", descSize);
                        lbl.Size = new Size(width - 20, (int)(height * 0.28));
                        lbl.Location = new Point(10, (int)(height * 0.68));
                    }
                }
            }
        }

        private void RepositionContent(Panel contentPanel, Label lblWelcome, Label lblDescription, 
            FlowLayoutPanel cardsContainer, Label lblFooter)
        {
            // 保留此方法以防编译错误，但当前布局逻辑已迁移到 UpdateWelcomeLayout 中
        }

        private Panel CreateResponsiveCard(string icon, string title, string description, Color bgColor)
        {
            // 兼容旧调用：内部直接复用固定网格卡片创建逻辑
            return CreateFixedGridCard(icon, title, description, bgColor);
        }

        private Panel CreateImageCard(string icon, string title, string description, Color bgColor)
        {
            // 兼容旧调用：保持接口不变，内部复用新卡片实现
            return CreateFixedGridCard(icon, title, description, bgColor);
        }

        private void SetupButtonHoverEffects()
        {
            // 为所有侧边栏按钮添加统一的鼠标悬停效果
            foreach (Control control in sidebarPanel.Controls)
            {
                if (control is Button btn && btn != btnExit)
                {
                    btn.MouseEnter += NavButton_MouseEnter;
                    btn.MouseLeave += NavButton_MouseLeave;
                    btn.Click += NavButton_Click;
                }
            }

            // 为退出按钮设置单独的悬停样式
            btnExit.MouseEnter += (s, e) => btnExit.BackColor = Color.FromArgb(220, 20, 60);  // 深红色
            btnExit.MouseLeave += (s, e) => btnExit.BackColor = Color.FromArgb(255, 182, 193);

            // 主页按钮点击时，切回欢迎页面
            btnHome.Click += (s, e) => ShowWelcomePage();
        }

        private void NavButton_MouseEnter(object? sender, EventArgs e)
        {
            if (sender is Button btn && btn != currentActiveButton)
            {
                btn.BackColor = Color.FromArgb(255, 200, 210);  // 浅粉色悬停背景
            }
        }

        private void NavButton_MouseLeave(object? sender, EventArgs e)
        {
            if (sender is Button btn && btn != currentActiveButton)
            {
                btn.BackColor = Color.FromArgb(255, 182, 193);  // 恢复默认粉色
            }
        }

        private void NavButton_Click(object? sender, EventArgs e)
        {
            if (sender is Button btn)
            {
                // 取消之前激活按钮的高亮
                if (currentActiveButton != null)
                {
                    currentActiveButton.BackColor = Color.FromArgb(255, 182, 193);
                }

                // 设置当前按钮为激活状态
                btn.BackColor = Color.FromArgb(255, 200, 210);  // 激活浅粉色
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
                // 清空用户会话
                UserSession.Clear();
                this.Close();
            }
        }
    }
}
