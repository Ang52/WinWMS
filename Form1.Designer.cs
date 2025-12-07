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
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            infoManagementToolStripMenuItem = new ToolStripMenuItem();
            materialManagementToolStripMenuItem = new ToolStripMenuItem();
            warehouseManagementToolStripMenuItem = new ToolStripMenuItem();
            inventoryOperationsToolStripMenuItem = new ToolStripMenuItem();
            inboundToolStripMenuItem = new ToolStripMenuItem();
            outboundToolStripMenuItem = new ToolStripMenuItem();
            queryAndReportsToolStripMenuItem = new ToolStripMenuItem();
            inventoryQueryToolStripMenuItem = new ToolStripMenuItem();
            inboundQueryToolStripMenuItem = new ToolStripMenuItem();
            outboundQueryToolStripMenuItem = new ToolStripMenuItem();
            monthlyReportToolStripMenuItem = new ToolStripMenuItem();
            systemManagementToolStripMenuItem = new ToolStripMenuItem();
            userManagementToolStripMenuItem = new ToolStripMenuItem();
            statusStrip1 = new StatusStrip();
            mainPanel = new Panel();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, infoManagementToolStripMenuItem, inventoryOperationsToolStripMenuItem, queryAndReportsToolStripMenuItem, systemManagementToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(8, 3, 0, 3);
            menuStrip1.Size = new Size(1029, 30);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(71, 24);
            fileToolStripMenuItem.Text = "文件(&F)";
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(142, 26);
            exitToolStripMenuItem.Text = "退出(&X)";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // infoManagementToolStripMenuItem
            // 
            infoManagementToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { materialManagementToolStripMenuItem, warehouseManagementToolStripMenuItem });
            infoManagementToolStripMenuItem.Name = "infoManagementToolStripMenuItem";
            infoManagementToolStripMenuItem.Size = new Size(97, 24);
            infoManagementToolStripMenuItem.Text = "信息管理(&I)";
            // 
            // materialManagementToolStripMenuItem
            // 
            materialManagementToolStripMenuItem.Name = "materialManagementToolStripMenuItem";
            materialManagementToolStripMenuItem.Size = new Size(177, 26);
            materialManagementToolStripMenuItem.Text = "物料管理(&M)";
            // 
            // warehouseManagementToolStripMenuItem
            // 
            warehouseManagementToolStripMenuItem.Name = "warehouseManagementToolStripMenuItem";
            warehouseManagementToolStripMenuItem.Size = new Size(177, 26);
            warehouseManagementToolStripMenuItem.Text = "仓库管理(&W)";
            // 
            // inventoryOperationsToolStripMenuItem
            // 
            inventoryOperationsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { inboundToolStripMenuItem, outboundToolStripMenuItem });
            inventoryOperationsToolStripMenuItem.Name = "inventoryOperationsToolStripMenuItem";
            inventoryOperationsToolStripMenuItem.Size = new Size(105, 24);
            inventoryOperationsToolStripMenuItem.Text = "库存操作(&O)";
            // 
            // inboundToolStripMenuItem
            // 
            inboundToolStripMenuItem.Name = "inboundToolStripMenuItem";
            inboundToolStripMenuItem.Size = new Size(144, 26);
            inboundToolStripMenuItem.Text = "入库(&I)";
            // 
            // outboundToolStripMenuItem
            // 
            outboundToolStripMenuItem.Name = "outboundToolStripMenuItem";
            outboundToolStripMenuItem.Size = new Size(144, 26);
            outboundToolStripMenuItem.Text = "出库(&O)";
            // 
            // queryAndReportsToolStripMenuItem
            // 
            queryAndReportsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { inventoryQueryToolStripMenuItem, inboundQueryToolStripMenuItem, outboundQueryToolStripMenuItem, monthlyReportToolStripMenuItem });
            queryAndReportsToolStripMenuItem.Name = "queryAndReportsToolStripMenuItem";
            queryAndReportsToolStripMenuItem.Size = new Size(120, 24);
            queryAndReportsToolStripMenuItem.Text = "查询与报表(&Q)";
            // 
            // inventoryQueryToolStripMenuItem
            // 
            inventoryQueryToolStripMenuItem.Name = "inventoryQueryToolStripMenuItem";
            inventoryQueryToolStripMenuItem.Size = new Size(177, 26);
            inventoryQueryToolStripMenuItem.Text = "库存查询(&I)";
            // 
            // inboundQueryToolStripMenuItem
            // 
            inboundQueryToolStripMenuItem.Name = "inboundQueryToolStripMenuItem";
            inboundQueryToolStripMenuItem.Size = new Size(177, 26);
            inboundQueryToolStripMenuItem.Text = "入库查询(&N)";
            // 
            // outboundQueryToolStripMenuItem
            // 
            outboundQueryToolStripMenuItem.Name = "outboundQueryToolStripMenuItem";
            outboundQueryToolStripMenuItem.Size = new Size(177, 26);
            outboundQueryToolStripMenuItem.Text = "出库查询(&O)";
            // 
            // monthlyReportToolStripMenuItem
            // 
            monthlyReportToolStripMenuItem.Name = "monthlyReportToolStripMenuItem";
            monthlyReportToolStripMenuItem.Size = new Size(177, 26);
            monthlyReportToolStripMenuItem.Text = "月度报表(&M)";
            // 
            // systemManagementToolStripMenuItem
            // 
            systemManagementToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { userManagementToolStripMenuItem });
            systemManagementToolStripMenuItem.Name = "systemManagementToolStripMenuItem";
            systemManagementToolStripMenuItem.Size = new Size(102, 24);
            systemManagementToolStripMenuItem.Text = "系统管理(&S)";
            // 
            // userManagementToolStripMenuItem
            // 
            userManagementToolStripMenuItem.Name = "userManagementToolStripMenuItem";
            userManagementToolStripMenuItem.Size = new Size(173, 26);
            userManagementToolStripMenuItem.Text = "用户管理(&U)";
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Location = new Point(0, 578);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Padding = new Padding(1, 0, 18, 0);
            statusStrip1.Size = new Size(1029, 22);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            // 
            // mainPanel
            // 
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Location = new Point(0, 30);
            mainPanel.Margin = new Padding(4, 4, 4, 4);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(1029, 548);
            mainPanel.TabIndex = 2;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightPink;
            ClientSize = new Size(1029, 600);
            Controls.Add(mainPanel);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Margin = new Padding(4, 4, 4, 4);
            Name = "Form1";
            Text = "仓储管理系统";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem infoManagementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem materialManagementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem warehouseManagementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inventoryOperationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inboundToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem outboundToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem queryAndReportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inventoryQueryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inboundQueryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem outboundQueryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem monthlyReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem systemManagementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userManagementToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Panel mainPanel;
    }
}
