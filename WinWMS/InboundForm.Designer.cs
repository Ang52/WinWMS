namespace WinWMS
{
    partial class InboundForm
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
            btnInbound = new Button();
            txtPrice = new TextBox();
            lblPrice = new Label();
            numQuantity = new NumericUpDown();
            lblQuantity = new Label();
            cmbWarehouse = new ComboBox();
            lblWarehouse = new Label();
            cmbMaterial = new ComboBox();
            lblMaterial = new Label();
            txtRemark = new TextBox();
            lblRemark = new Label();
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
            formPanel.Controls.Add(btnInbound);
            formPanel.Controls.Add(txtPrice);
            formPanel.Controls.Add(lblPrice);
            formPanel.Controls.Add(numQuantity);
            formPanel.Controls.Add(lblQuantity);
            formPanel.Controls.Add(cmbWarehouse);
            formPanel.Controls.Add(lblWarehouse);
            formPanel.Controls.Add(cmbMaterial);
            formPanel.Controls.Add(lblMaterial);
            formPanel.Location = new Point(250, 75);
            formPanel.MaximumSize = new Size(600, 520);
            formPanel.MinimumSize = new Size(450, 450);
            formPanel.Name = "formPanel";
            formPanel.Padding = new Padding(40);
            formPanel.Size = new Size(500, 450);
            formPanel.TabIndex = 0;
            // 
            // btnInbound
            // 
            btnInbound.BackColor = Color.FromArgb(255, 105, 180);  // 深粉色按钮
            btnInbound.Cursor = Cursors.Hand;
            btnInbound.FlatAppearance.BorderSize = 0;
            btnInbound.FlatStyle = FlatStyle.Flat;
            btnInbound.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Bold);
            btnInbound.ForeColor = Color.White;
            btnInbound.Location = new Point(130, 365);
            btnInbound.Name = "btnInbound";
            btnInbound.Size = new Size(250, 50);
            btnInbound.TabIndex = 5;
            btnInbound.Text = "✓ 确认入库";
            btnInbound.UseVisualStyleBackColor = false;
            // 
            // txtPrice
            // 
            txtPrice.BorderStyle = BorderStyle.FixedSingle;
            txtPrice.Font = new Font("Microsoft YaHei UI", 11F);
            txtPrice.Location = new Point(140, 195);
            txtPrice.Name = "txtPrice";
            txtPrice.PlaceholderText = "请输入单价";
            txtPrice.Size = new Size(320, 26);
            txtPrice.TabIndex = 3;
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Font = new Font("Microsoft YaHei UI", 11F);
            lblPrice.ForeColor = Color.FromArgb(64, 64, 64);
            lblPrice.Location = new Point(40, 198);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(99, 20);
            lblPrice.TabIndex = 8;
            lblPrice.Text = "入库单价：";
            // 
            // numQuantity
            // 
            numQuantity.BorderStyle = BorderStyle.FixedSingle;
            numQuantity.Font = new Font("Microsoft YaHei UI", 11F);
            numQuantity.Location = new Point(140, 145);
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
            lblQuantity.Location = new Point(40, 148);
            lblQuantity.Name = "lblQuantity";
            lblQuantity.Size = new Size(99, 20);
            lblQuantity.TabIndex = 7;
            lblQuantity.Text = "入库数量：";
            // 
            // cmbWarehouse
            // 
            cmbWarehouse.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbWarehouse.FlatStyle = FlatStyle.Flat;
            cmbWarehouse.Font = new Font("Microsoft YaHei UI", 11F);
            cmbWarehouse.FormattingEnabled = true;
            cmbWarehouse.Location = new Point(140, 95);
            cmbWarehouse.Name = "cmbWarehouse";
            cmbWarehouse.Size = new Size(320, 28);
            cmbWarehouse.TabIndex = 1;
            // 
            // lblWarehouse
            // 
            lblWarehouse.AutoSize = true;
            lblWarehouse.Font = new Font("Microsoft YaHei UI", 11F);
            lblWarehouse.ForeColor = Color.FromArgb(64, 64, 64);
            lblWarehouse.Location = new Point(40, 98);
            lblWarehouse.Name = "lblWarehouse";
            lblWarehouse.Size = new Size(99, 20);
            lblWarehouse.TabIndex = 6;
            lblWarehouse.Text = "入库仓库：";
            // 
            // cmbMaterial
            // 
            cmbMaterial.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMaterial.FlatStyle = FlatStyle.Flat;
            cmbMaterial.Font = new Font("Microsoft YaHei UI", 11F);
            cmbMaterial.FormattingEnabled = true;
            cmbMaterial.Location = new Point(140, 45);
            cmbMaterial.Name = "cmbMaterial";
            cmbMaterial.Size = new Size(320, 28);
            cmbMaterial.TabIndex = 0;
            // 
            // lblMaterial
            // 
            lblMaterial.AutoSize = true;
            lblMaterial.Font = new Font("Microsoft YaHei UI", 11F);
            lblMaterial.ForeColor = Color.FromArgb(64, 64, 64);
            lblMaterial.Location = new Point(40, 48);
            lblMaterial.Name = "lblMaterial";
            lblMaterial.Size = new Size(99, 20);
            lblMaterial.TabIndex = 5;
            lblMaterial.Text = "物料名称：";
            // 
            // txtRemark
            // 
            txtRemark.BorderStyle = BorderStyle.FixedSingle;
            txtRemark.Font = new Font("Microsoft YaHei UI", 11F);
            txtRemark.Location = new Point(140, 245);
            txtRemark.Multiline = true;
            txtRemark.Name = "txtRemark";
            txtRemark.PlaceholderText = "可选填写备注信息...";
            txtRemark.Size = new Size(320, 90);
            txtRemark.TabIndex = 4;
            // 
            // lblRemark
            // 
            lblRemark.AutoSize = true;
            lblRemark.Font = new Font("Microsoft YaHei UI", 11F);
            lblRemark.ForeColor = Color.FromArgb(64, 64, 64);
            lblRemark.Location = new Point(40, 248);
            lblRemark.Name = "lblRemark";
            lblRemark.Size = new Size(69, 20);
            lblRemark.TabIndex = 9;
            lblRemark.Text = "备注：";
            // 
            // InboundForm
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 240, 245);  // 浅粉色背景
            ClientSize = new Size(1000, 600);
            Controls.Add(formPanel);
            Font = new Font("Microsoft YaHei UI", 9F);
            MinimumSize = new Size(800, 500);
            Name = "InboundForm";
            Text = "入库操作";
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
        private TextBox txtPrice;
        private TextBox txtRemark;
        private Button btnInbound;
        private Label lblMaterial;
        private Label lblWarehouse;
        private Label lblQuantity;
        private Label lblPrice;
        private Label lblRemark;
    }
}
