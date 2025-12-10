namespace WinWMS
{
    partial class MaterialManagementForm
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            dataGridView1 = new DataGridView();
            bottomPanel = new Panel();
            btnDelete = new Button();
            btnUpdate = new Button();
            btnAdd = new Button();
            txtPrice = new TextBox();
            lblPrice = new Label();
            txtUnit = new TextBox();
            lblUnit = new Label();
            txtSpec = new TextBox();
            lblSpec = new Label();
            txtName = new TextBox();
            lblName = new Label();
            txtMaterialCode = new TextBox();
            lblMaterialCode = new Label();
            picLogo = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            bottomPanel.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.BorderStyle = BorderStyle.FixedSingle;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(255, 182, 193);
            dataGridViewCellStyle1.Font = new Font("Microsoft YaHei UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(255, 182, 193);
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.ColumnHeadersHeight = 45;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Microsoft YaHei UI", 10F);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle2.Padding = new Padding(5);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(255, 218, 224);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.GridColor = Color.FromArgb(255, 182, 193);
            dataGridView1.Location = new Point(20, 20);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Microsoft YaHei UI", 10F);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(255, 218, 224);
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 40;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(960, 360);
            dataGridView1.TabIndex = 0;
            // 
            // bottomPanel
            // 
            bottomPanel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            bottomPanel.BackColor = Color.White;
            bottomPanel.Location = new Point(20, 400);
            bottomPanel.Name = "bottomPanel";
            bottomPanel.Padding = new Padding(25, 20, 25, 20);
            bottomPanel.Size = new Size(960, 180);
            bottomPanel.TabIndex = 1;
            
            // 创建左侧输入区域的FlowLayoutPanel
            FlowLayoutPanel leftInputPanel = new FlowLayoutPanel();
            leftInputPanel.Dock = DockStyle.Left;
            leftInputPanel.FlowDirection = FlowDirection.LeftToRight;
            leftInputPanel.WrapContents = true;
            leftInputPanel.Width = 650;
            leftInputPanel.Padding = new Padding(0, 15, 0, 0);  // 添加适度的顶部内边距，使内容垂直居中
            
            // 创建右侧按钮区域的TableLayoutPanel
            TableLayoutPanel buttonPanel = new TableLayoutPanel();
            buttonPanel.Dock = DockStyle.Fill;
            buttonPanel.ColumnCount = 2;
            buttonPanel.RowCount = 2;
            buttonPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            buttonPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            buttonPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            buttonPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            buttonPanel.Padding = new Padding(20, 10, 20, 10);
            
            // 添加到bottomPanel
            bottomPanel.Controls.Add(buttonPanel);
            bottomPanel.Controls.Add(leftInputPanel);
            
            // 添加控件到leftInputPanel
            leftInputPanel.Controls.Add(lblMaterialCode);
            leftInputPanel.Controls.Add(txtMaterialCode);
            leftInputPanel.Controls.Add(lblSpec);
            leftInputPanel.Controls.Add(txtSpec);
            leftInputPanel.Controls.Add(lblName);
            leftInputPanel.Controls.Add(txtName);
            leftInputPanel.Controls.Add(lblUnit);
            leftInputPanel.Controls.Add(txtUnit);
            leftInputPanel.Controls.Add(lblPrice);
            leftInputPanel.Controls.Add(txtPrice);
            
            // 添加按钮到buttonPanel (2x2布局)
            buttonPanel.Controls.Add(btnAdd, 0, 0);
            buttonPanel.Controls.Add(btnUpdate, 1, 0);
            buttonPanel.Controls.Add(btnDelete, 0, 1);
            buttonPanel.Controls.Add(picLogo, 1, 1);
            
            // lblMaterialCode
            lblMaterialCode.Anchor = AnchorStyles.Left;
            lblMaterialCode.AutoSize = false;
            lblMaterialCode.Font = new Font("Microsoft YaHei UI", 10F);
            lblMaterialCode.ForeColor = Color.FromArgb(64, 64, 64);
            lblMaterialCode.Margin = new Padding(5, 5, 3, 5);
            lblMaterialCode.Name = "lblMaterialCode";
            lblMaterialCode.Size = new Size(95, 25);
            lblMaterialCode.TabIndex = 0;
            lblMaterialCode.Text = "物料编号：";
            lblMaterialCode.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtMaterialCode
            // 
            txtMaterialCode.BorderStyle = BorderStyle.FixedSingle;
            txtMaterialCode.Font = new Font("Microsoft YaHei UI", 10F);
            txtMaterialCode.Margin = new Padding(0, 5, 15, 5);
            txtMaterialCode.Name = "txtMaterialCode";
            txtMaterialCode.Size = new Size(200, 25);
            txtMaterialCode.TabIndex = 1;
            // 
            // lblSpec
            // 
            lblSpec.Anchor = AnchorStyles.Left;
            lblSpec.AutoSize = false;
            lblSpec.Font = new Font("Microsoft YaHei UI", 10F);
            lblSpec.ForeColor = Color.FromArgb(64, 64, 64);
            lblSpec.Margin = new Padding(5, 5, 3, 5);
            lblSpec.Name = "lblSpec";
            lblSpec.Size = new Size(95, 25);
            lblSpec.TabIndex = 2;
            lblSpec.Text = "物料规格：";
            lblSpec.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtSpec
            // 
            txtSpec.BorderStyle = BorderStyle.FixedSingle;
            txtSpec.Font = new Font("Microsoft YaHei UI", 10F);
            txtSpec.Margin = new Padding(0, 5, 15, 5);
            txtSpec.Name = "txtSpec";
            txtSpec.Size = new Size(200, 25);
            txtSpec.TabIndex = 3;
            leftInputPanel.SetFlowBreak(txtSpec, true);
            // 
            // lblName
            // 
            lblName.Anchor = AnchorStyles.Left;
            lblName.AutoSize = false;
            lblName.Font = new Font("Microsoft YaHei UI", 10F);
            lblName.ForeColor = Color.FromArgb(64, 64, 64);
            lblName.Margin = new Padding(5, 5, 3, 5);
            lblName.Name = "lblName";
            lblName.Size = new Size(95, 25);
            lblName.TabIndex = 4;
            lblName.Text = "物料名称：";
            lblName.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtName
            // 
            txtName.BorderStyle = BorderStyle.FixedSingle;
            txtName.Font = new Font("Microsoft YaHei UI", 10F);
            txtName.Margin = new Padding(0, 5, 15, 5);
            txtName.Name = "txtName";
            txtName.Size = new Size(200, 25);
            txtName.TabIndex = 5;
            // 
            // lblUnit
            // 
            lblUnit.Anchor = AnchorStyles.Left;
            lblUnit.AutoSize = false;
            lblUnit.Font = new Font("Microsoft YaHei UI", 10F);
            lblUnit.ForeColor = Color.FromArgb(64, 64, 64);
            lblUnit.Margin = new Padding(5, 5, 3, 5);
            lblUnit.Name = "lblUnit";
            lblUnit.Size = new Size(95, 25);
            lblUnit.TabIndex = 6;
            lblUnit.Text = "计量单位：";
            lblUnit.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtUnit
            // 
            txtUnit.BorderStyle = BorderStyle.FixedSingle;
            txtUnit.Font = new Font("Microsoft YaHei UI", 10F);
            txtUnit.Margin = new Padding(0, 5, 15, 5);
            txtUnit.Name = "txtUnit";
            txtUnit.Size = new Size(200, 25);
            txtUnit.TabIndex = 7;
            leftInputPanel.SetFlowBreak(txtUnit, true);
            // 
            // lblPrice
            // 
            lblPrice.Anchor = AnchorStyles.Left;
            lblPrice.AutoSize = false;
            lblPrice.Font = new Font("Microsoft YaHei UI", 10F);
            lblPrice.ForeColor = Color.FromArgb(64, 64, 64);
            lblPrice.Margin = new Padding(5, 5, 3, 5);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(95, 25);
            lblPrice.TabIndex = 8;
            lblPrice.Text = "标准单价：";
            lblPrice.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtPrice
            // 
            txtPrice.BorderStyle = BorderStyle.FixedSingle;
            txtPrice.Font = new Font("Microsoft YaHei UI", 10F);
            txtPrice.Margin = new Padding(0, 5, 15, 5);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(200, 25);
            txtPrice.TabIndex = 9;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(255, 105, 180);
            btnAdd.Cursor = Cursors.Hand;
            btnAdd.Dock = DockStyle.Fill;
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Microsoft YaHei UI", 11F, FontStyle.Bold);
            btnAdd.ForeColor = Color.White;
            btnAdd.Margin = new Padding(5);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(120, 50);
            btnAdd.TabIndex = 10;
            btnAdd.Text = "➕ 添加";
            btnAdd.UseVisualStyleBackColor = false;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.FromArgb(255, 182, 193);
            btnUpdate.Cursor = Cursors.Hand;
            btnUpdate.Dock = DockStyle.Fill;
            btnUpdate.FlatAppearance.BorderSize = 0;
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.Font = new Font("Microsoft YaHei UI", 11F, FontStyle.Bold);
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Margin = new Padding(5);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(120, 50);
            btnUpdate.TabIndex = 11;
            btnUpdate.Text = "✏️ 更新";
            btnUpdate.UseVisualStyleBackColor = false;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(219, 112, 147);
            btnDelete.Cursor = Cursors.Hand;
            btnDelete.Dock = DockStyle.Fill;
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Microsoft YaHei UI", 11F, FontStyle.Bold);
            btnDelete.ForeColor = Color.White;
            btnDelete.Margin = new Padding(5);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(120, 50);
            btnDelete.TabIndex = 12;
            btnDelete.Text = "🗑️ 删除";
            btnDelete.UseVisualStyleBackColor = false;
            // 
            // picLogo - 系统Logo
            // 
            picLogo.BackColor = Color.FromArgb(255, 240, 245);
            picLogo.Dock = DockStyle.Fill;
            picLogo.Margin = new Padding(5);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(120, 50);
            picLogo.TabIndex = 13;
            
            // 创建单个Label显示完整Logo
            Label lblCompleteLogo = new Label
            {
                Text = "🏢 WMS",
                Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Bold),
                ForeColor = Color.FromArgb(255, 105, 180),
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = Color.Transparent
            };
            
            picLogo.Controls.Add(lblCompleteLogo);
            
            // 
            // MaterialManagementForm
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 240, 245);
            ClientSize = new Size(1000, 600);
            Controls.Add(bottomPanel);
            Controls.Add(dataGridView1);
            Font = new Font("Microsoft YaHei UI", 9F);
            MinimumSize = new Size(800, 500);
            Name = "MaterialManagementForm";
            Text = "物料管理";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            bottomPanel.ResumeLayout(false);
            bottomPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private Panel bottomPanel;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private TextBox txtMaterialCode;
        private TextBox txtName;
        private TextBox txtSpec;
        private TextBox txtUnit;
        private Label lblMaterialCode;
        private Label lblName;
        private Label lblSpec;
        private Label lblUnit;
        private TextBox txtPrice;
        private Label lblPrice;
        private PictureBox picLogo;
    }
}
