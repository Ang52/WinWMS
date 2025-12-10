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
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
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
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(255, 182, 193);  // 粉色表头
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
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(255, 218, 224);  // 浅粉色选中
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.GridColor = Color.FromArgb(255, 218, 224);  // 浅粉色网格线
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
            bottomPanel.Controls.Add(btnDelete);
            bottomPanel.Controls.Add(btnUpdate);
            bottomPanel.Controls.Add(btnAdd);
            bottomPanel.Controls.Add(txtUnit);
            bottomPanel.Controls.Add(lblUnit);
            bottomPanel.Controls.Add(txtSpec);
            bottomPanel.Controls.Add(lblSpec);
            bottomPanel.Controls.Add(txtName);
            bottomPanel.Controls.Add(lblName);
            bottomPanel.Controls.Add(txtMaterialCode);
            bottomPanel.Controls.Add(lblMaterialCode);
            bottomPanel.Controls.Add(txtPrice);
            bottomPanel.Controls.Add(lblPrice);
            bottomPanel.Location = new Point(20, 400);
            bottomPanel.Name = "bottomPanel";
            bottomPanel.Padding = new Padding(25, 20, 25, 20);
            bottomPanel.Size = new Size(960, 180);
            bottomPanel.TabIndex = 1;
            // 
            // btnDelete
            // 
            btnDelete.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDelete.BackColor = Color.FromArgb(219, 112, 147);  // 玫瑰粉删除按钮
            btnDelete.Cursor = Cursors.Hand;
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Microsoft YaHei UI", 11F, FontStyle.Bold);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(815, 125);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(115, 40);
            btnDelete.TabIndex = 10;
            btnDelete.Text = "🗑️ 删除";
            btnDelete.UseVisualStyleBackColor = false;
            // 
            // btnUpdate
            // 
            btnUpdate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnUpdate.BackColor = Color.FromArgb(255, 182, 193);  // 粉色更新按钮
            btnUpdate.Cursor = Cursors.Hand;
            btnUpdate.FlatAppearance.BorderSize = 0;
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.Font = new Font("Microsoft YaHei UI", 11F, FontStyle.Bold);
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Location = new Point(670, 125);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(115, 40);
            btnUpdate.TabIndex = 9;
            btnUpdate.Text = "✏️ 更新";
            btnUpdate.UseVisualStyleBackColor = false;
            // 
            // btnAdd
            // 
            btnAdd.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAdd.BackColor = Color.FromArgb(255, 105, 180);  // 深粉色添加按钮
            btnAdd.Cursor = Cursors.Hand;
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Microsoft YaHei UI", 11F, FontStyle.Bold);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(525, 125);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(115, 40);
            btnAdd.TabIndex = 8;
            btnAdd.Text = "➕ 添加";
            btnAdd.UseVisualStyleBackColor = false;
            //
            // txtPrice
            //
            txtPrice.BorderStyle = BorderStyle.FixedSingle;
            txtPrice.Font = new Font("Microsoft YaHei UI", 10F);
            txtPrice.Location = new Point(130, 125);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(360, 25);
            txtPrice.TabIndex = 9;
            //
            // lblPrice
            //
            lblPrice.AutoSize = true;
            lblPrice.Font = new Font("Microsoft YaHei UI", 10F);
            lblPrice.ForeColor = Color.FromArgb(64, 64, 64);
            lblPrice.Location = new Point(30, 128);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(93, 20);
            lblPrice.TabIndex = 8;
            lblPrice.Text = "标准单价：";
            // 
            // txtUnit
            // 
            txtUnit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtUnit.BorderStyle = BorderStyle.FixedSingle;
            txtUnit.Font = new Font("Microsoft YaHei UI", 10F);
            txtUnit.Location = new Point(625, 75);
            txtUnit.Name = "txtUnit";
            txtUnit.Size = new Size(305, 25);
            txtUnit.TabIndex = 7;
            // 
            // lblUnit
            // 
            lblUnit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblUnit.AutoSize = true;
            lblUnit.Font = new Font("Microsoft YaHei UI", 10F);
            lblUnit.ForeColor = Color.FromArgb(64, 64, 64);
            lblUnit.Location = new Point(530, 78);
            lblUnit.Name = "lblUnit";
            lblUnit.Size = new Size(93, 20);
            lblUnit.TabIndex = 6;
            lblUnit.Text = "计量单位：";
            // 
            // txtSpec
            // 
            txtSpec.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtSpec.BorderStyle = BorderStyle.FixedSingle;
            txtSpec.Font = new Font("Microsoft YaHei UI", 10F);
            txtSpec.Location = new Point(625, 25);
            txtSpec.Name = "txtSpec";
            txtSpec.Size = new Size(305, 25);
            txtSpec.TabIndex = 5;
            // 
            // lblSpec
            // 
            lblSpec.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblSpec.AutoSize = true;
            lblSpec.Font = new Font("Microsoft YaHei UI", 10F);
            lblSpec.ForeColor = Color.FromArgb(64, 64, 64);
            lblSpec.Location = new Point(558, 28);
            lblSpec.Name = "lblSpec";
            lblSpec.Size = new Size(65, 20);
            lblSpec.TabIndex = 4;
            lblSpec.Text = "规格：";
            // 
            // txtName
            // 
            txtName.BorderStyle = BorderStyle.FixedSingle;
            txtName.Font = new Font("Microsoft YaHei UI", 10F);
            txtName.Location = new Point(130, 75);
            txtName.Name = "txtName";
            txtName.Size = new Size(360, 25);
            txtName.TabIndex = 3;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new Font("Microsoft YaHei UI", 10F);
            lblName.ForeColor = Color.FromArgb(64, 64, 64);
            lblName.Location = new Point(30, 78);
            lblName.Name = "lblName";
            lblName.Size = new Size(93, 20);
            lblName.TabIndex = 2;
            lblName.Text = "物料名称：";
            // 
            // txtMaterialCode
            // 
            txtMaterialCode.BorderStyle = BorderStyle.FixedSingle;
            txtMaterialCode.Font = new Font("Microsoft YaHei UI", 10F);
            txtMaterialCode.Location = new Point(130, 25);
            txtMaterialCode.Name = "txtMaterialCode";
            txtMaterialCode.Size = new Size(360, 25);
            txtMaterialCode.TabIndex = 1;
            // 
            // lblMaterialCode
            // 
            lblMaterialCode.AutoSize = true;
            lblMaterialCode.Font = new Font("Microsoft YaHei UI", 10F);
            lblMaterialCode.ForeColor = Color.FromArgb(64, 64, 64);
            lblMaterialCode.Location = new Point(30, 28);
            lblMaterialCode.Name = "lblMaterialCode";
            lblMaterialCode.Size = new Size(93, 20);
            lblMaterialCode.TabIndex = 0;
            lblMaterialCode.Text = "物资编号：";
            // 
            // MaterialManagementForm
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 240, 245);  // 浅粉色背景
            ClientSize = new Size(1000, 600);
            Controls.Add(bottomPanel);
            Controls.Add(dataGridView1);
            Font = new Font("Microsoft YaHei UI", 9F);
            MinimumSize = new Size(800, 500);
            Name = "MaterialManagementForm";
            Text = "物料管理";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
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
    }
}
