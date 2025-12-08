namespace WinWMS
{
    partial class OutboundForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            formPanel = new Panel();
            pnlRemarkBorder = new Panel();
            txtRemark = new TextBox();
            lblRemark = new Label();
            btnOutbound = new Button();
            numQuantity = new NumericUpDown();
            lblQuantity = new Label();
            cmbWarehouse = new ComboBox();
            lblWarehouse = new Label();
            cmbSpec = new ComboBox();
            lblSpec = new Label();
            cmbMaterial = new ComboBox();
            lblMaterial = new Label();
            formPanel.SuspendLayout();
            pnlRemarkBorder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numQuantity).BeginInit();
            SuspendLayout();
            // 
            // formPanel
            // 
            formPanel.Anchor = AnchorStyles.None;
            formPanel.BackColor = Color.White;
            formPanel.Controls.Add(pnlRemarkBorder);
            formPanel.Controls.Add(lblRemark);
            formPanel.Controls.Add(btnOutbound);
            formPanel.Controls.Add(numQuantity);
            formPanel.Controls.Add(lblQuantity);
            formPanel.Controls.Add(cmbWarehouse);
            formPanel.Controls.Add(lblWarehouse);
            formPanel.Controls.Add(cmbSpec);
            formPanel.Controls.Add(lblSpec);
            formPanel.Controls.Add(cmbMaterial);
            formPanel.Controls.Add(lblMaterial);
            formPanel.Location = new Point(250, 75);
            formPanel.MaximumSize = new Size(600, 500);
            formPanel.MinimumSize = new Size(450, 450);
            formPanel.Name = "formPanel";
            formPanel.Padding = new Padding(40);
            formPanel.Size = new Size(500, 470);
            formPanel.TabIndex = 0;
            // 
            // pnlRemarkBorder
            // 
            pnlRemarkBorder.BackColor = Color.FromArgb(180, 180, 180);  // 灰色边框
            pnlRemarkBorder.Controls.Add(txtRemark);
            pnlRemarkBorder.Location = new Point(140, 235);
            pnlRemarkBorder.Name = "pnlRemarkBorder";
            pnlRemarkBorder.Padding = new Padding(2);  // 2像素边框厚度
            pnlRemarkBorder.Size = new Size(320, 110);
            pnlRemarkBorder.TabIndex = 10;
            // 
            // txtRemark
            // 
            txtRemark.BorderStyle = BorderStyle.None;
            txtRemark.Dock = DockStyle.Fill;
            txtRemark.Font = new Font("Microsoft YaHei UI", 11F);
            txtRemark.Location = new Point(2, 2);
            txtRemark.Multiline = true;
            txtRemark.Name = "txtRemark";
            txtRemark.PlaceholderText = "可选填写备注信息...";
            txtRemark.Size = new Size(316, 106);
            txtRemark.TabIndex = 4;
            txtRemark.BackColor = Color.White;
            // 
            // lblRemark
            // 
            lblRemark.AutoSize = true;
            lblRemark.Font = new Font("Microsoft YaHei UI", 11F);
            lblRemark.ForeColor = Color.FromArgb(64, 64, 64);
            lblRemark.Location = new Point(40, 238);
            lblRemark.Name = "lblRemark";
            lblRemark.Size = new Size(69, 20);
            lblRemark.TabIndex = 9;
            lblRemark.Text = "备注：";
            // 
            // btnOutbound
            // 
            btnOutbound.BackColor = Color.FromArgb(255, 105, 180);  // 深粉色按钮
            btnOutbound.Cursor = Cursors.Hand;
            btnOutbound.FlatAppearance.BorderSize = 0;
            btnOutbound.FlatStyle = FlatStyle.Flat;
            btnOutbound.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Bold);
            btnOutbound.ForeColor = Color.White;
            btnOutbound.Location = new Point(130, 380);
            btnOutbound.Name = "btnOutbound";
            btnOutbound.Size = new Size(250, 50);
            btnOutbound.TabIndex = 5;
            btnOutbound.Text = "✓ 确认出库";
            btnOutbound.UseVisualStyleBackColor = false;
            // 
            // numQuantity
            // 
            numQuantity.BorderStyle = BorderStyle.FixedSingle;
            numQuantity.Font = new Font("Microsoft YaHei UI", 11F);
            numQuantity.Location = new Point(140, 180);
            numQuantity.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numQuantity.Name = "numQuantity";
            numQuantity.Size = new Size(320, 26);
            numQuantity.TabIndex = 3;
            // 
            // lblQuantity
            // 
            lblQuantity.AutoSize = true;
            lblQuantity.Font = new Font("Microsoft YaHei UI", 11F);
            lblQuantity.ForeColor = Color.FromArgb(64, 64, 64);
            lblQuantity.Location = new Point(40, 183);
            lblQuantity.Name = "lblQuantity";
            lblQuantity.Size = new Size(99, 20);
            lblQuantity.TabIndex = 8;
            lblQuantity.Text = "出库数量：";
            // 
            // cmbWarehouse
            // 
            cmbWarehouse.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbWarehouse.Font = new Font("Microsoft YaHei UI", 11F);
            cmbWarehouse.FormattingEnabled = true;
            cmbWarehouse.Location = new Point(140, 130);
            cmbWarehouse.Name = "cmbWarehouse";
            cmbWarehouse.Size = new Size(320, 28);
            cmbWarehouse.TabIndex = 2;
            cmbWarehouse.BackColor = Color.White;
            // 
            // lblWarehouse
            // 
            lblWarehouse.AutoSize = true;
            lblWarehouse.Font = new Font("Microsoft YaHei UI", 11F);
            lblWarehouse.ForeColor = Color.FromArgb(64, 64, 64);
            lblWarehouse.Location = new Point(40, 133);
            lblWarehouse.Name = "lblWarehouse";
            lblWarehouse.Size = new Size(99, 20);
            lblWarehouse.TabIndex = 7;
            lblWarehouse.Text = "出库仓库：";
            // 
            // cmbSpec
            // 
            cmbSpec.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSpec.Font = new Font("Microsoft YaHei UI", 11F);
            cmbSpec.FormattingEnabled = true;
            cmbSpec.Location = new Point(140, 80);
            cmbSpec.Name = "cmbSpec";
            cmbSpec.Size = new Size(320, 28);
            cmbSpec.TabIndex = 1;
            cmbSpec.BackColor = Color.White;
            // 
            // lblSpec
            // 
            lblSpec.AutoSize = true;
            lblSpec.Font = new Font("Microsoft YaHei UI", 11F);
            lblSpec.ForeColor = Color.FromArgb(64, 64, 64);
            lblSpec.Location = new Point(40, 83);
            lblSpec.Name = "lblSpec";
            lblSpec.Size = new Size(99, 20);
            lblSpec.TabIndex = 6;
            lblSpec.Text = "物料规格：";
            // 
            // cmbMaterial
            // 
            cmbMaterial.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMaterial.Font = new Font("Microsoft YaHei UI", 11F);
            cmbMaterial.FormattingEnabled = true;
            cmbMaterial.Location = new Point(140, 30);
            cmbMaterial.Name = "cmbMaterial";
            cmbMaterial.Size = new Size(320, 28);
            cmbMaterial.TabIndex = 0;
            cmbMaterial.BackColor = Color.White;
            // 
            // lblMaterial
            // 
            lblMaterial.AutoSize = true;
            lblMaterial.Font = new Font("Microsoft YaHei UI", 11F);
            lblMaterial.ForeColor = Color.FromArgb(64, 64, 64);
            lblMaterial.Location = new Point(40, 33);
            lblMaterial.Name = "lblMaterial";
            lblMaterial.Size = new Size(99, 20);
            lblMaterial.TabIndex = 5;
            lblMaterial.Text = "物料名称：";
            // 
            // OutboundForm
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 240, 245);  // 浅粉色背景
            ClientSize = new Size(1000, 600);
            Controls.Add(formPanel);
            Font = new Font("Microsoft YaHei UI", 9F);
            MinimumSize = new Size(800, 600);
            Name = "OutboundForm";
            Text = "出库操作";
            formPanel.ResumeLayout(false);
            formPanel.PerformLayout();
            pnlRemarkBorder.ResumeLayout(false);
            pnlRemarkBorder.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numQuantity).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel formPanel;
        private ComboBox cmbMaterial;
        private ComboBox cmbSpec;
        private ComboBox cmbWarehouse;
        private NumericUpDown numQuantity;
        private Panel pnlRemarkBorder;
        private TextBox txtRemark;
        private Button btnOutbound;
        private Label lblMaterial;
        private Label lblSpec;
        private Label lblWarehouse;
        private Label lblQuantity;
        private Label lblRemark;
    }
}
