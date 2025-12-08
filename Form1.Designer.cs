namespace WinWMS
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            sidebarPanel = new Panel();
            btnExit = new Button();
            btnUserManagement = new Button();
            btnWarehouseUnit = new Button();
            btnMaterialCategory = new Button();
            btnMaterialManagement = new Button();
            btnOutboundQuery = new Button();
            btnInboundQuery = new Button();
            btnInventoryQuery = new Button();
            btnMonthlyReport = new Button();
            btnOutbound = new Button();
            btnInbound = new Button();
            btnHome = new Button();
            logoPanel = new Panel();
            lblSystemName = new Label();
            lblLogo = new Label();
            topPanel = new Panel();
            lblPageTitle = new Label();
            btnBack = new Button();
            mainPanel = new Panel();
            statusStrip1 = new StatusStrip();
            sidebarPanel.SuspendLayout();
            logoPanel.SuspendLayout();
            topPanel.SuspendLayout();
            SuspendLayout();
            // 
            // sidebarPanel
            // 
            sidebarPanel.BackColor = Color.FromArgb(45, 45, 48);
            sidebarPanel.Controls.Add(btnExit);
            sidebarPanel.Controls.Add(btnUserManagement);
            sidebarPanel.Controls.Add(btnWarehouseUnit);
            sidebarPanel.Controls.Add(btnMaterialCategory);
            sidebarPanel.Controls.Add(btnMaterialManagement);
            sidebarPanel.Controls.Add(btnOutboundQuery);
            sidebarPanel.Controls.Add(btnInboundQuery);
            sidebarPanel.Controls.Add(btnInventoryQuery);
            sidebarPanel.Controls.Add(btnMonthlyReport);
            sidebarPanel.Controls.Add(btnOutbound);
            sidebarPanel.Controls.Add(btnInbound);
            sidebarPanel.Controls.Add(btnHome);
            sidebarPanel.Controls.Add(logoPanel);
            sidebarPanel.Dock = DockStyle.Left;
            sidebarPanel.Location = new Point(0, 0);
            sidebarPanel.Name = "sidebarPanel";
            sidebarPanel.Size = new Size(200, 600);
            sidebarPanel.TabIndex = 0;
            // 
            // btnExit
            // 
            btnExit.Dock = DockStyle.Bottom;
            btnExit.FlatAppearance.BorderSize = 0;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.Font = new Font("Microsoft YaHei UI", 10F);
            btnExit.ForeColor = Color.White;
            btnExit.Location = new Point(0, 555);
            btnExit.Name = "btnExit";
            btnExit.Padding = new Padding(10, 0, 0, 0);
            btnExit.Size = new Size(200, 45);
            btnExit.TabIndex = 12;
            btnExit.Text = "🚪  退出系统";
            btnExit.TextAlign = ContentAlignment.MiddleLeft;
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += exitToolStripMenuItem_Click;
            // 
            // btnUserManagement
            // 
            btnUserManagement.Dock = DockStyle.Top;
            btnUserManagement.FlatAppearance.BorderSize = 0;
            btnUserManagement.FlatStyle = FlatStyle.Flat;
            btnUserManagement.Font = new Font("Microsoft YaHei UI", 10F);
            btnUserManagement.ForeColor = Color.White;
            btnUserManagement.Location = new Point(0, 555);
            btnUserManagement.Name = "btnUserManagement";
            btnUserManagement.Padding = new Padding(10, 0, 0, 0);
            btnUserManagement.Size = new Size(200, 45);
            btnUserManagement.TabIndex = 11;
            btnUserManagement.Text = "👥  用户管理";
            btnUserManagement.TextAlign = ContentAlignment.MiddleLeft;
            btnUserManagement.UseVisualStyleBackColor = true;
            btnUserManagement.Click += UserManagementToolStripMenuItem_Click;
            // 
            // btnWarehouseUnit
            // 
            btnWarehouseUnit.Dock = DockStyle.Top;
            btnWarehouseUnit.FlatAppearance.BorderSize = 0;
            btnWarehouseUnit.FlatStyle = FlatStyle.Flat;
            btnWarehouseUnit.Font = new Font("Microsoft YaHei UI", 10F);
            btnWarehouseUnit.ForeColor = Color.White;
            btnWarehouseUnit.Location = new Point(0, 510);
            btnWarehouseUnit.Name = "btnWarehouseUnit";
            btnWarehouseUnit.Padding = new Padding(10, 0, 0, 0);
            btnWarehouseUnit.Size = new Size(200, 45);
            btnWarehouseUnit.TabIndex = 10;
            btnWarehouseUnit.Text = "⚙️  仓库管理";
            btnWarehouseUnit.TextAlign = ContentAlignment.MiddleLeft;
            btnWarehouseUnit.UseVisualStyleBackColor = true;
            btnWarehouseUnit.Click += WarehouseManagementToolStripMenuItem_Click;
            // 
            // btnMaterialCategory
            // 
            btnMaterialCategory.Dock = DockStyle.Top;
            btnMaterialCategory.FlatAppearance.BorderSize = 0;
            btnMaterialCategory.FlatStyle = FlatStyle.Flat;
            btnMaterialCategory.Font = new Font("Microsoft YaHei UI", 10F);
            btnMaterialCategory.ForeColor = Color.White;
            btnMaterialCategory.Location = new Point(0, 465);
            btnMaterialCategory.Name = "btnMaterialCategory";
            btnMaterialCategory.Padding = new Padding(10, 0, 0, 0);
            btnMaterialCategory.Size = new Size(200, 45);
            btnMaterialCategory.TabIndex = 9;
            btnMaterialCategory.Text = "⚙️  物资单位";
            btnMaterialCategory.TextAlign = ContentAlignment.MiddleLeft;
            btnMaterialCategory.UseVisualStyleBackColor = true;
            // 
            // btnMaterialManagement
            // 
            btnMaterialManagement.Dock = DockStyle.Top;
            btnMaterialManagement.FlatAppearance.BorderSize = 0;
            btnMaterialManagement.FlatStyle = FlatStyle.Flat;
            btnMaterialManagement.Font = new Font("Microsoft YaHei UI", 10F);
            btnMaterialManagement.ForeColor = Color.White;
            btnMaterialManagement.Location = new Point(0, 420);
            btnMaterialManagement.Name = "btnMaterialManagement";
            btnMaterialManagement.Padding = new Padding(10, 0, 0, 0);
            btnMaterialManagement.Size = new Size(200, 45);
            btnMaterialManagement.TabIndex = 8;
            btnMaterialManagement.Text = "📦  物资管理";
            btnMaterialManagement.TextAlign = ContentAlignment.MiddleLeft;
            btnMaterialManagement.UseVisualStyleBackColor = true;
            btnMaterialManagement.Click += MaterialManagementToolStripMenuItem_Click;
            // 
            // btnOutboundQuery
            // 
            btnOutboundQuery.Dock = DockStyle.Top;
            btnOutboundQuery.FlatAppearance.BorderSize = 0;
            btnOutboundQuery.FlatStyle = FlatStyle.Flat;
            btnOutboundQuery.Font = new Font("Microsoft YaHei UI", 10F);
            btnOutboundQuery.ForeColor = Color.White;
            btnOutboundQuery.Location = new Point(0, 375);
            btnOutboundQuery.Name = "btnOutboundQuery";
            btnOutboundQuery.Padding = new Padding(10, 0, 0, 0);
            btnOutboundQuery.Size = new Size(200, 45);
            btnOutboundQuery.TabIndex = 7;
            btnOutboundQuery.Text = "📊  出库查询";
            btnOutboundQuery.TextAlign = ContentAlignment.MiddleLeft;
            btnOutboundQuery.UseVisualStyleBackColor = true;
            btnOutboundQuery.Click += OutboundQueryToolStripMenuItem_Click;
            // 
            // btnInboundQuery
            // 
            btnInboundQuery.Dock = DockStyle.Top;
            btnInboundQuery.FlatAppearance.BorderSize = 0;
            btnInboundQuery.FlatStyle = FlatStyle.Flat;
            btnInboundQuery.Font = new Font("Microsoft YaHei UI", 10F);
            btnInboundQuery.ForeColor = Color.White;
            btnInboundQuery.Location = new Point(0, 330);
            btnInboundQuery.Name = "btnInboundQuery";
            btnInboundQuery.Padding = new Padding(10, 0, 0, 0);
            btnInboundQuery.Size = new Size(200, 45);
            btnInboundQuery.TabIndex = 6;
            btnInboundQuery.Text = "📊  入库查询";
            btnInboundQuery.TextAlign = ContentAlignment.MiddleLeft;
            btnInboundQuery.UseVisualStyleBackColor = true;
            btnInboundQuery.Click += InboundQueryToolStripMenuItem_Click;
            // 
            // btnInventoryQuery
            // 
            btnInventoryQuery.Dock = DockStyle.Top;
            btnInventoryQuery.FlatAppearance.BorderSize = 0;
            btnInventoryQuery.FlatStyle = FlatStyle.Flat;
            btnInventoryQuery.Font = new Font("Microsoft YaHei UI", 10F);
            btnInventoryQuery.ForeColor = Color.White;
            btnInventoryQuery.Location = new Point(0, 285);
            btnInventoryQuery.Name = "btnInventoryQuery";
            btnInventoryQuery.Padding = new Padding(10, 0, 0, 0);
            btnInventoryQuery.Size = new Size(200, 45);
            btnInventoryQuery.TabIndex = 5;
            btnInventoryQuery.Text = "📊  库存查询";
            btnInventoryQuery.TextAlign = ContentAlignment.MiddleLeft;
            btnInventoryQuery.UseVisualStyleBackColor = true;
            btnInventoryQuery.Click += InventoryQueryToolStripMenuItem_Click;
            // 
            // btnMonthlyReport
            // 
            btnMonthlyReport.Dock = DockStyle.Top;
            btnMonthlyReport.FlatAppearance.BorderSize = 0;
            btnMonthlyReport.FlatStyle = FlatStyle.Flat;
            btnMonthlyReport.Font = new Font("Microsoft YaHei UI", 10F);
            btnMonthlyReport.ForeColor = Color.White;
            btnMonthlyReport.Location = new Point(0, 240);
            btnMonthlyReport.Name = "btnMonthlyReport";
            btnMonthlyReport.Padding = new Padding(10, 0, 0, 0);
            btnMonthlyReport.Size = new Size(200, 45);
            btnMonthlyReport.TabIndex = 4;
            btnMonthlyReport.Text = "📈  月度报表";
            btnMonthlyReport.TextAlign = ContentAlignment.MiddleLeft;
            btnMonthlyReport.UseVisualStyleBackColor = true;
            btnMonthlyReport.Click += MonthlyReportToolStripMenuItem_Click;
            // 
            // btnOutbound
            // 
            btnOutbound.Dock = DockStyle.Top;
            btnOutbound.FlatAppearance.BorderSize = 0;
            btnOutbound.FlatStyle = FlatStyle.Flat;
            btnOutbound.Font = new Font("Microsoft YaHei UI", 10F);
            btnOutbound.ForeColor = Color.White;
            btnOutbound.Location = new Point(0, 195);
            btnOutbound.Name = "btnOutbound";
            btnOutbound.Padding = new Padding(10, 0, 0, 0);
            btnOutbound.Size = new Size(200, 45);
            btnOutbound.TabIndex = 3;
            btnOutbound.Text = "📤  出库";
            btnOutbound.TextAlign = ContentAlignment.MiddleLeft;
            btnOutbound.UseVisualStyleBackColor = true;
            btnOutbound.Click += OutboundToolStripMenuItem_Click;
            // 
            // btnInbound
            // 
            btnInbound.Dock = DockStyle.Top;
            btnInbound.FlatAppearance.BorderSize = 0;
            btnInbound.FlatStyle = FlatStyle.Flat;
            btnInbound.Font = new Font("Microsoft YaHei UI", 10F);
            btnInbound.ForeColor = Color.White;
            btnInbound.Location = new Point(0, 150);
            btnInbound.Name = "btnInbound";
            btnInbound.Padding = new Padding(10, 0, 0, 0);
            btnInbound.Size = new Size(200, 45);
            btnInbound.TabIndex = 2;
            btnInbound.Text = "📥  入库";
            btnInbound.TextAlign = ContentAlignment.MiddleLeft;
            btnInbound.UseVisualStyleBackColor = true;
            btnInbound.Click += InboundToolStripMenuItem_Click;
            // 
            // btnHome
            // 
            btnHome.BackColor = Color.FromArgb(62, 62, 66);
            btnHome.Dock = DockStyle.Top;
            btnHome.FlatAppearance.BorderSize = 0;
            btnHome.FlatStyle = FlatStyle.Flat;
            btnHome.Font = new Font("Microsoft YaHei UI", 10F);
            btnHome.ForeColor = Color.White;
            btnHome.Location = new Point(0, 105);
            btnHome.Name = "btnHome";
            btnHome.Padding = new Padding(10, 0, 0, 0);
            btnHome.Size = new Size(200, 45);
            btnHome.TabIndex = 1;
            btnHome.Text = "🏠  首页";
            btnHome.TextAlign = ContentAlignment.MiddleLeft;
            btnHome.UseVisualStyleBackColor = false;
            // 
            // logoPanel
            // 
            logoPanel.BackColor = Color.FromArgb(0, 122, 204);
            logoPanel.Controls.Add(lblSystemName);
            logoPanel.Controls.Add(lblLogo);
            logoPanel.Dock = DockStyle.Top;
            logoPanel.Location = new Point(0, 0);
            logoPanel.Name = "logoPanel";
            logoPanel.Size = new Size(200, 105);
            logoPanel.TabIndex = 0;
            // 
            // lblSystemName
            // 
            lblSystemName.Font = new Font("Microsoft YaHei UI", 11F, FontStyle.Bold);
            lblSystemName.ForeColor = Color.White;
            lblSystemName.Location = new Point(0, 55);
            lblSystemName.Name = "lblSystemName";
            lblSystemName.Size = new Size(200, 30);
            lblSystemName.TabIndex = 1;
            lblSystemName.Text = "仓储管理系统";
            lblSystemName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblLogo
            // 
            lblLogo.Font = new Font("Microsoft YaHei UI", 20F, FontStyle.Bold);
            lblLogo.ForeColor = Color.White;
            lblLogo.Location = new Point(0, 15);
            lblLogo.Name = "lblLogo";
            lblLogo.Size = new Size(200, 40);
            lblLogo.TabIndex = 0;
            lblLogo.Text = "🏢 WMS";
            lblLogo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // topPanel
            // 
            topPanel.BackColor = Color.FromArgb(62, 62, 66);
            topPanel.Controls.Add(lblPageTitle);
            topPanel.Controls.Add(btnBack);
            topPanel.Dock = DockStyle.Top;
            topPanel.Location = new Point(200, 0);
            topPanel.Name = "topPanel";
            topPanel.Size = new Size(829, 60);
            topPanel.TabIndex = 1;
            // 
            // lblPageTitle
            // 
            lblPageTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblPageTitle.Font = new Font("Microsoft YaHei UI", 16F, FontStyle.Bold);
            lblPageTitle.ForeColor = Color.White;
            lblPageTitle.Location = new Point(60, 0);
            lblPageTitle.Name = "lblPageTitle";
            lblPageTitle.Size = new Size(769, 60);
            lblPageTitle.TabIndex = 1;
            lblPageTitle.Text = "欢迎使用仓储管理系统";
            lblPageTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnBack
            // 
            btnBack.FlatAppearance.BorderSize = 0;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.Font = new Font("Microsoft YaHei UI", 16F);
            btnBack.ForeColor = Color.White;
            btnBack.Location = new Point(10, 10);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(40, 40);
            btnBack.TabIndex = 0;
            btnBack.Text = "◀";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Visible = false;
            // 
            // mainPanel
            // 
            mainPanel.BackColor = Color.FromArgb(240, 240, 240);
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Location = new Point(200, 60);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(829, 518);
            mainPanel.TabIndex = 2;
            // 
            // statusStrip1
            // 
            statusStrip1.BackColor = Color.FromArgb(45, 45, 48);
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Location = new Point(200, 578);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(829, 22);
            statusStrip1.TabIndex = 3;
            statusStrip1.Text = "statusStrip1";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 240, 240);
            ClientSize = new Size(1029, 600);
            Controls.Add(mainPanel);
            Controls.Add(statusStrip1);
            Controls.Add(topPanel);
            Controls.Add(sidebarPanel);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "仓储管理系统 - WMS";
            sidebarPanel.ResumeLayout(false);
            logoPanel.ResumeLayout(false);
            topPanel.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel sidebarPanel;
        private Panel logoPanel;
        private Label lblLogo;
        private Label lblSystemName;
        private Button btnHome;
        private Button btnInbound;
        private Button btnOutbound;
        private Button btnInventoryQuery;
        private Button btnInboundQuery;
        private Button btnOutboundQuery;
        private Button btnMaterialManagement;
        private Button btnWarehouseUnit;
        private Button btnMaterialCategory;
        private Button btnUserManagement;
        private Button btnMonthlyReport;
        private Button btnExit;
        private Panel topPanel;
        private Label lblPageTitle;
        private Button btnBack;
        private Panel mainPanel;
        private StatusStrip statusStrip1;
    }
}
