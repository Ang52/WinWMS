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
            cmbSpec = new ComboBox();
            lblSpec = new Label();
            cmbMaterial = new ComboBox();
            lblMaterial = new Label();
            pnlRemarkBorder = new Panel();
            txtRemark = new TextBox();
            lblRemark = new Label();
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
            formPanel.Controls.Add(btnInbound);
            formPanel.Controls.Add(txtPrice);
            formPanel.Controls.Add(lblPrice);
            formPanel.Controls.Add(numQuantity);
            formPanel.Controls.Add(lblQuantity);
            formPanel.Controls.Add(cmbWarehouse);
            formPanel.Controls.Add(lblWarehouse);
            formPanel.Controls.Add(cmbSpec);
            formPanel.Controls.Add(lblSpec);
            formPanel.Controls.Add(cmbMaterial);
            formPanel.Controls.Add(lblMaterial);
            formPanel.Location = new Point(250, 50);
            formPanel.MaximumSize = new Size(600, 560);
            formPanel.MinimumSize = new Size(450, 500);
            formPanel.Name = "formPanel";
            formPanel.Padding = new Padding(40);
            formPanel.Size = new Size(500, 520);
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
            btnInbound.Location = new Point(130, 435);
            btnInbound.Name = "btnInbound";
            btnInbound.Size = new Size(250, 50);
            btnInbound.TabIndex = 6;
            btnInbound.Text = "✓ 确认入库";
            btnInbound.UseVisualStyleBackColor = false;
            // 
            // txtPrice
            // 
            txtPrice.BorderStyle = BorderStyle.FixedSingle;
            txtPrice.Font = new Font("Microsoft YaHei UI", 11F);
            txtPrice.Location = new Point(140, 235);
            txtPrice.Name = "txtPrice";
            txtPrice.PlaceholderText = "请输入单价";
            txtPrice.Size = new Size(320, 26);
            txtPrice.TabIndex = 4;
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Font = new Font("Microsoft YaHei UI", 11F);
            lblPrice.ForeColor = Color.FromArgb(64, 64, 64);
            lblPrice.Location = new Point(40, 238);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(99, 20);
            lblPrice.TabIndex = 10;
            lblPrice.Text = "入库单价：";
            // 
            // numQuantity
            // 
            numQuantity.BorderStyle = BorderStyle.FixedSingle;
            numQuantity.Font = new Font("Microsoft YaHei UI", 11F);
            numQuantity.Location = new Point(140, 185);
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
            lblQuantity.Location = new Point(40, 188);
            lblQuantity.Name = "lblQuantity";
            lblQuantity.Size = new Size(99, 20);
            lblQuantity.TabIndex = 9;
            lblQuantity.Text = "入库数量：";
            // 
            // cmbWarehouse
            // 
            cmbWarehouse.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbWarehouse.Font = new Font("Microsoft YaHei UI", 11F);
            cmbWarehouse.FormattingEnabled = true;
            cmbWarehouse.Location = new Point(140, 135);
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
            lblWarehouse.Location = new Point(40, 138);
            lblWarehouse.Name = "lblWarehouse";
            lblWarehouse.Size = new Size(99, 20);
            lblWarehouse.TabIndex = 8;
            lblWarehouse.Text = "入库仓库：";
            // 
            // cmbSpec
            // 
            cmbSpec.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSpec.Font = new Font("Microsoft YaHei UI", 11F);
            cmbSpec.FormattingEnabled = true;
            cmbSpec.Location = new Point(140, 85);
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
            lblSpec.Location = new Point(40, 88);
            lblSpec.Name = "lblSpec";
            lblSpec.Size = new Size(99, 20);
            lblSpec.TabIndex = 7;
            lblSpec.Text = "物料规格：";
            // 
            // cmbMaterial
            // 
            cmbMaterial.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMaterial.Font = new Font("Microsoft YaHei UI", 11F);
            cmbMaterial.FormattingEnabled = true;
            cmbMaterial.Location = new Point(140, 35);
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
            lblMaterial.Location = new Point(40, 38);
            lblMaterial.Name = "lblMaterial";
            lblMaterial.Size = new Size(99, 20);
            lblMaterial.TabIndex = 6;
            lblMaterial.Text = "物料名称：";
            // 
            // pnlRemarkBorder
            // 
            pnlRemarkBorder.BackColor = Color.FromArgb(180, 180, 180);  // 灰色边框
            pnlRemarkBorder.Controls.Add(txtRemark);
            pnlRemarkBorder.Location = new Point(140, 285);
            pnlRemarkBorder.Name = "pnlRemarkBorder";
            pnlRemarkBorder.Padding = new Padding(2);  // 2像素边框厚度
            pnlRemarkBorder.Size = new Size(320, 120);
            pnlRemarkBorder.TabIndex = 11;
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
            txtRemark.Size = new Size(316, 116);
            txtRemark.TabIndex = 5;
            txtRemark.BackColor = Color.White;
            // 
            // lblRemark
            // 
            lblRemark.AutoSize = true;
            lblRemark.Font = new Font("Microsoft YaHei UI", 11F);
            lblRemark.ForeColor = Color.FromArgb(64, 64, 64);
            lblRemark.Location = new Point(40, 288);
            lblRemark.Name = "lblRemark";
            lblRemark.Size = new Size(69, 20);
            lblRemark.TabIndex = 11;
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
            MinimumSize = new Size(800, 600);
            Name = "InboundForm";
            Text = "入库操作";
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
        private TextBox txtPrice;
        private Panel pnlRemarkBorder;
        private TextBox txtRemark;
        private Button btnInbound;
        private Label lblMaterial;
        private Label lblSpec;
        private Label lblWarehouse;
        private Label lblQuantity;
        private Label lblPrice;
        private Label lblRemark;
    }
}
