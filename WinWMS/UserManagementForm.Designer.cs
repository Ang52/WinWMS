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
            dataGridViewCellStyle1.BackColor = Color.FromArgb(240, 240, 240);
            dataGridViewCellStyle1.Font = new Font("Microsoft YaHei UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(240, 240, 240);
            dataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.ColumnHeadersHeight = 40;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Microsoft YaHei UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle2.Padding = new Padding(5, 0, 5, 0);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(230, 244, 255);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.GridColor = Color.FromArgb(230, 230, 230);
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Microsoft YaHei UI", 9F);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(230, 244, 255);
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 35;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(1000, 430);
            dataGridView1.TabIndex = 0;
            // 
            // bottomPanel
            // 
            bottomPanel.BackColor = Color.White;
            bottomPanel.Controls.Add(btnDelete);
            bottomPanel.Controls.Add(btnUpdate);
            bottomPanel.Controls.Add(btnAdd);
            bottomPanel.Controls.Add(cmbRole);
            bottomPanel.Controls.Add(lblRole);
            bottomPanel.Controls.Add(txtPassword);
            bottomPanel.Controls.Add(lblPassword);
            bottomPanel.Controls.Add(txtUsername);
            bottomPanel.Controls.Add(lblUsername);
            bottomPanel.Dock = DockStyle.Bottom;
            bottomPanel.Location = new Point(0, 430);
            bottomPanel.Name = "bottomPanel";
            bottomPanel.Padding = new Padding(20);
            bottomPanel.Size = new Size(1000, 170);
            bottomPanel.TabIndex = 1;
            // 
            // btnDelete
            // 
            btnDelete.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDelete.BackColor = Color.FromArgb(220, 53, 69);
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Microsoft YaHei UI", 9F, FontStyle.Bold);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(845, 110);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(100, 35);
            btnDelete.TabIndex = 8;
            btnDelete.Text = "🗑️ 删除";
            btnDelete.UseVisualStyleBackColor = false;
            // 
            // btnUpdate
            // 
            btnUpdate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnUpdate.BackColor = Color.FromArgb(255, 193, 7);
            btnUpdate.FlatAppearance.BorderSize = 0;
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.Font = new Font("Microsoft YaHei UI", 9F, FontStyle.Bold);
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Location = new Point(720, 110);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(100, 35);
            btnUpdate.TabIndex = 7;
            btnUpdate.Text = "✏️ 更新";
            btnUpdate.UseVisualStyleBackColor = false;
            // 
            // btnAdd
            // 
            btnAdd.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAdd.BackColor = Color.FromArgb(40, 167, 69);
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Microsoft YaHei UI", 9F, FontStyle.Bold);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(595, 110);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(100, 35);
            btnAdd.TabIndex = 6;
            btnAdd.Text = "➕ 添加";
            btnAdd.UseVisualStyleBackColor = false;
            // 
            // cmbRole
            // 
            cmbRole.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRole.Font = new Font("Microsoft YaHei UI", 9F);
            cmbRole.FormattingEnabled = true;
            cmbRole.Items.AddRange(new object[] { "admin", "user" });
            cmbRole.Location = new Point(590, 35);
            cmbRole.Name = "cmbRole";
            cmbRole.Size = new Size(355, 28);
            cmbRole.TabIndex = 5;
            // 
            // lblRole
            // 
            lblRole.AutoSize = true;
            lblRole.Font = new Font("Microsoft YaHei UI", 9F);
            lblRole.ForeColor = Color.FromArgb(64, 64, 64);
            lblRole.Location = new Point(528, 38);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(56, 20);
            lblRole.TabIndex = 4;
            lblRole.Text = "角色：";
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Microsoft YaHei UI", 9F);
            txtPassword.Location = new Point(110, 82);
            txtPassword.Name = "txtPassword";
            txtPassword.PlaceholderText = "留空则不修改密码";
            txtPassword.Size = new Size(380, 27);
            txtPassword.TabIndex = 3;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Microsoft YaHei UI", 9F);
            lblPassword.ForeColor = Color.FromArgb(64, 64, 64);
            lblPassword.Location = new Point(30, 85);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(56, 20);
            lblPassword.TabIndex = 2;
            lblPassword.Text = "密码：";
            // 
            // txtUsername
            // 
            txtUsername.Font = new Font("Microsoft YaHei UI", 9F);
            txtUsername.Location = new Point(110, 32);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(380, 27);
            txtUsername.TabIndex = 1;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Microsoft YaHei UI", 9F);
            lblUsername.ForeColor = Color.FromArgb(64, 64, 64);
            lblUsername.Location = new Point(30, 35);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(70, 20);
            lblUsername.TabIndex = 0;
            lblUsername.Text = "用户名：";
            // 
            // UserManagementForm
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 245, 245);
            ClientSize = new Size(1000, 600);
            Controls.Add(bottomPanel);
            Controls.Add(dataGridView1);
            Font = new Font("Microsoft YaHei UI", 9F);
            Name = "UserManagementForm";
            Text = "用户管理";
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
        private TextBox txtUsername;
        private TextBox txtPassword;
        private ComboBox cmbRole;
        private Label lblUsername;
        private Label lblPassword;
        private Label lblRole;
    }
}
