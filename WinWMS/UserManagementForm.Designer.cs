namespace WinWMS
{
    partial class UserManagementForm
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
            cmbRole = new ComboBox();
            lblRole = new Label();
            txtPassword = new TextBox();
            lblPassword = new Label();
            txtUsername = new TextBox();
            lblUsername = new Label();
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
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
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
            dataGridView1.GridColor = Color.FromArgb(255, 218, 224);
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
            
            // 创建主容器Panel，用于居中显示内容
            Panel centerPanel = new Panel();
            centerPanel.Width = 580;  // 固定宽度包含输入框和按钮
            centerPanel.Height = 140;
            centerPanel.Left = (bottomPanel.Width - centerPanel.Width) / 2;  // 水平居中
            centerPanel.Top = (bottomPanel.Height - centerPanel.Height) / 2;  // 垂直居中
            centerPanel.Anchor = AnchorStyles.None;  // 保持居中
            
            // 创建左侧输入区域的FlowLayoutPanel
            FlowLayoutPanel leftInputPanel = new FlowLayoutPanel();
            leftInputPanel.Dock = DockStyle.Left;
            leftInputPanel.FlowDirection = FlowDirection.LeftToRight;
            leftInputPanel.WrapContents = true;
            leftInputPanel.Width = 330;
            leftInputPanel.Padding = new Padding(0, 10, 0, 0);  // 减少顶部内边距
            
            // 创建右侧按钮区域的TableLayoutPanel
            TableLayoutPanel buttonPanel = new TableLayoutPanel();
            buttonPanel.Dock = DockStyle.Fill;
            buttonPanel.ColumnCount = 2;
            buttonPanel.RowCount = 2;
            buttonPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            buttonPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            buttonPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            buttonPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            buttonPanel.Padding = new Padding(10, 5, 0, 5);  // 减少上下内边距
            
            // 添加到centerPanel
            centerPanel.Controls.Add(buttonPanel);
            centerPanel.Controls.Add(leftInputPanel);
            
            // 添加centerPanel到bottomPanel
            bottomPanel.Controls.Add(centerPanel);
            
            // 添加控件到leftInputPanel - 顺序：用户名 -> 密码 -> 角色
            leftInputPanel.Controls.Add(lblUsername);
            leftInputPanel.Controls.Add(txtUsername);
            leftInputPanel.Controls.Add(lblPassword);
            leftInputPanel.Controls.Add(txtPassword);
            leftInputPanel.Controls.Add(lblRole);
            leftInputPanel.Controls.Add(cmbRole);
            
            // 添加按钮到buttonPanel (2x2布局)
            buttonPanel.Controls.Add(btnAdd, 0, 0);
            buttonPanel.Controls.Add(btnUpdate, 1, 0);
            buttonPanel.Controls.Add(btnDelete, 0, 1);
            buttonPanel.Controls.Add(picLogo, 1, 1);
            
            // lblUsername - 使用两端对齐
            lblUsername.Anchor = AnchorStyles.Left;
            lblUsername.AutoSize = false;
            lblUsername.Font = new Font("Microsoft YaHei UI", 10F);
            lblUsername.ForeColor = Color.FromArgb(64, 64, 64);
            lblUsername.Margin = new Padding(5, 5, 3, 5);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(70, 25);
            lblUsername.TabIndex = 0;
            lblUsername.Text = "用户名";
            lblUsername.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtUsername
            // 
            txtUsername.BorderStyle = BorderStyle.FixedSingle;
            txtUsername.Font = new Font("Microsoft YaHei UI", 10F);
            txtUsername.Margin = new Padding(0, 5, 0, 5);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(230, 25);
            txtUsername.TabIndex = 1;
            leftInputPanel.SetFlowBreak(txtUsername, true);
            // 
            // lblPassword - 使用两端对齐
            // 
            lblPassword.Anchor = AnchorStyles.Left;
            lblPassword.AutoSize = false;
            lblPassword.Font = new Font("Microsoft YaHei UI", 10F);
            lblPassword.ForeColor = Color.FromArgb(64, 64, 64);
            lblPassword.Margin = new Padding(5, 5, 3, 5);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(70, 25);
            lblPassword.TabIndex = 2;
            lblPassword.Text = "密    码";
            lblPassword.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtPassword
            // 
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.Font = new Font("Microsoft YaHei UI", 10F);
            txtPassword.Margin = new Padding(0, 5, 0, 5);
            txtPassword.Name = "txtPassword";
            txtPassword.PlaceholderText = "留空则不修改密码";
            txtPassword.Size = new Size(230, 25);
            txtPassword.TabIndex = 3;
            txtPassword.UseSystemPasswordChar = true;
            leftInputPanel.SetFlowBreak(txtPassword, true);
            // 
            // lblRole - 使用两端对齐
            // 
            lblRole.Anchor = AnchorStyles.Left;
            lblRole.AutoSize = false;
            lblRole.Font = new Font("Microsoft YaHei UI", 10F);
            lblRole.ForeColor = Color.FromArgb(64, 64, 64);
            lblRole.Margin = new Padding(5, 5, 3, 5);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(70, 25);
            lblRole.TabIndex = 4;
            lblRole.Text = "角    色";
            lblRole.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cmbRole
            // 
            cmbRole.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRole.FlatStyle = FlatStyle.Flat;
            cmbRole.Font = new Font("Microsoft YaHei UI", 10F);
            cmbRole.FormattingEnabled = true;
            cmbRole.Items.AddRange(new object[] { "admin", "operator" });
            cmbRole.Margin = new Padding(0, 5, 0, 5);
            cmbRole.Name = "cmbRole";
            cmbRole.Size = new Size(230, 27);
            cmbRole.TabIndex = 5;
            leftInputPanel.SetFlowBreak(cmbRole, true);
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
            btnAdd.TabIndex = 6;
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
            btnUpdate.TabIndex = 7;
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
            btnDelete.TabIndex = 8;
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
            picLogo.TabIndex = 9;
            
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
            // UserManagementForm
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 240, 245);
            ClientSize = new Size(1000, 600);
            Controls.Add(bottomPanel);
            Controls.Add(dataGridView1);
            Font = new Font("Microsoft YaHei UI", 9F);
            MinimumSize = new Size(800, 500);
            Name = "UserManagementForm";
            Text = "用户管理";
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
        private TextBox txtUsername;
        private TextBox txtPassword;
        private ComboBox cmbRole;
        private Label lblUsername;
        private Label lblPassword;
        private Label lblRole;
        private PictureBox picLogo;
    }
}