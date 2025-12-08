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
            txtRemark = new TextBox();
            lblRemark = new Label();
            btnOutbound = new Button();
            numQuantity = new NumericUpDown();
            lblQuantity = new Label();
            cmbWarehouse = new ComboBox();
            lblWarehouse = new Label();
            cmbMaterial = new ComboBox();
            lblMaterial = new Label();
            formPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numQuantity).BeginInit();
            SuspendLayout();
            // 
            // formPanel
            // 
            formPanel.Anchor = AnchorStyles.None;
            formPanel.BackColor = Color.White;
            formPanel.Controls.Add(txtRemark);
            formPanel.Controls.Add(lblRemark);
            formPanel.Controls.Add(btnOutbound);
            formPanel.Controls.Add(numQuantity);
            formPanel.Controls.Add(lblQuantity);
            formPanel.Controls.Add(cmbWarehouse);
            formPanel.Controls.Add(lblWarehouse);
            formPanel.Controls.Add(cmbMaterial);
            formPanel.Controls.Add(lblMaterial);
            formPanel.Location = new Point(250, 100);
            formPanel.MaximumSize = new Size(600, 450);
            formPanel.MinimumSize = new Size(450, 400);
            formPanel.Name = "formPanel";
            formPanel.Padding = new Padding(40);
            formPanel.Size = new Size(500, 400);
            formPanel.TabIndex = 0;
            // 
            // txtRemark
            // 
            txtRemark.BorderStyle = BorderStyle.FixedSingle;
            txtRemark.Font = new Font("Microsoft YaHei UI", 11F);
            txtRemark.Location = new Point(140, 195);
            txtRemark.Multiline = true;
            txtRemark.Name = "txtRemark";
            txtRemark.PlaceholderText = "可选填写备注信息...";
            txtRemark.Size = new Size(320, 85);
            txtRemark.TabIndex = 3;
            // 
            // lblRemark
            // 
            lblRemark.AutoSize = true;
            lblRemark.Font = new Font("Microsoft YaHei UI", 11F);
            lblRemark.ForeColor = Color.FromArgb(64, 64, 64);
            lblRemark.Location = new Point(40, 198);
            lblRemark.Name = "lblRemark";
            lblRemark.Size = new Size(69, 20);
            lblRemark.TabIndex = 8;
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
            btnOutbound.Location = new Point(130, 310);
            btnOutbound.Name = "btnOutbound";
            btnOutbound.Size = new Size(250, 50);
            btnOutbound.TabIndex = 4;
            btnOutbound.Text = "✓ 确认出库";
            btnOutbound.UseVisualStyleBackColor = false;
            // 
            // numQuantity
            // 
            numQuantity.BorderStyle = BorderStyle.FixedSingle;
            numQuantity.Font = new Font("Microsoft YaHei UI", 11F);
            numQuantity.Location = new Point(140, 140);
            numQuantity.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numQuantity.Name = "numQuantity";
            numQuantity.Size = new Size(320, 26);
            numQuantity.TabIndex = 2;
            // 
            // lblQuantity
            // 
            lblQuantity.AutoSize = true;
            lblQuantity.Font = new Font("Microsoft YaHei UI", 11F);
            lblQuantity.ForeColor = Color.FromArgb(64, 64, 64);
            lblQuantity.Location = new Point(40, 143);
            lblQuantity.Name = "lblQuantity";
            lblQuantity.Size = new Size(99, 20);
            lblQuantity.TabIndex = 7;
            lblQuantity.Text = "出库数量：";
            // 
            // cmbWarehouse
            // 
            cmbWarehouse.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbWarehouse.FlatStyle = FlatStyle.Flat;
            cmbWarehouse.Font = new Font("Microsoft YaHei UI", 11F);
            cmbWarehouse.FormattingEnabled = true;
            cmbWarehouse.Location = new Point(140, 88);
            cmbWarehouse.Name = "cmbWarehouse";
            cmbWarehouse.Size = new Size(320, 28);
            cmbWarehouse.TabIndex = 1;
            // 
            // lblWarehouse
            // 
            lblWarehouse.AutoSize = true;
            lblWarehouse.Font = new Font("Microsoft YaHei UI", 11F);
            lblWarehouse.ForeColor = Color.FromArgb(64, 64, 64);
            lblWarehouse.Location = new Point(40, 91);
            lblWarehouse.Name = "lblWarehouse";
            lblWarehouse.Size = new Size(99, 20);
            lblWarehouse.TabIndex = 6;
            lblWarehouse.Text = "出库仓库：";
            // 
            // cmbMaterial
            // 
            cmbMaterial.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMaterial.FlatStyle = FlatStyle.Flat;
            cmbMaterial.Font = new Font("Microsoft YaHei UI", 11F);
            cmbMaterial.FormattingEnabled = true;
            cmbMaterial.Location = new Point(140, 38);
            cmbMaterial.Name = "cmbMaterial";
            cmbMaterial.Size = new Size(320, 28);
            cmbMaterial.TabIndex = 0;
            // 
            // lblMaterial
            // 
            lblMaterial.AutoSize = true;
            lblMaterial.Font = new Font("Microsoft YaHei UI", 11F);
            lblMaterial.ForeColor = Color.FromArgb(64, 64, 64);
            lblMaterial.Location = new Point(40, 41);
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
            MinimumSize = new Size(800, 500);
            Name = "OutboundForm";
            Text = "出库操作";
            formPanel.ResumeLayout(false);
            formPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numQuantity).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel formPanel;
        private ComboBox cmbMaterial;
        private ComboBox cmbWarehouse;
        private NumericUpDown numQuantity;
        private TextBox txtRemark;
        private Button btnOutbound;
        private Label lblMaterial;
        private Label lblWarehouse;
        private Label lblQuantity;
        private Label lblRemark;
    }
}
