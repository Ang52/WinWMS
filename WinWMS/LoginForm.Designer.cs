namespace WinWMS
{
    partial class LoginForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panelLogin = new Panel();
            btnLogin = new Button();
            txtPassword = new TextBox();
            txtUsername = new TextBox();
            lblPassword = new Label();
            lblUsername = new Label();
            lblTitle = new Label();
            lblSubtitle = new Label();
            panelLogin.SuspendLayout();
            SuspendLayout();
            // 
            // panelLogin
            // 
            panelLogin.BackColor = Color.FromArgb(250, 235, 240);
            panelLogin.Controls.Add(btnLogin);
            panelLogin.Controls.Add(txtPassword);
            panelLogin.Controls.Add(txtUsername);
            panelLogin.Controls.Add(lblPassword);
            panelLogin.Controls.Add(lblUsername);
            panelLogin.Controls.Add(lblTitle);
            panelLogin.Controls.Add(lblSubtitle);
            panelLogin.Location = new Point(500, 250);
            panelLogin.Name = "panelLogin";
            panelLogin.Size = new Size(400, 350);
            panelLogin.TabIndex = 0;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(240, 160, 175);
            btnLogin.Cursor = Cursors.Hand;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Bold);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(80, 270);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(240, 50);
            btnLogin.TabIndex = 6;
            btnLogin.Text = "登  录";
            btnLogin.UseVisualStyleBackColor = false;
            // 
            // txtPassword
            // 
            txtPassword.BackColor = Color.White;
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.Font = new Font("Microsoft YaHei UI", 11F);
            txtPassword.ForeColor = Color.Black;
            txtPassword.Location = new Point(80, 210);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '●';
            txtPassword.Size = new Size(240, 31);
            txtPassword.TabIndex = 5;
            // 
            // txtUsername
            // 
            txtUsername.BackColor = Color.White;
            txtUsername.BorderStyle = BorderStyle.FixedSingle;
            txtUsername.Font = new Font("Microsoft YaHei UI", 11F);
            txtUsername.ForeColor = Color.Black;
            txtUsername.Location = new Point(80, 140);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(240, 31);
            txtUsername.TabIndex = 4;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Microsoft YaHei UI", 10F, FontStyle.Bold);
            lblPassword.ForeColor = Color.FromArgb(219, 112, 147);
            lblPassword.Location = new Point(80, 182);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(84, 24);
            lblPassword.TabIndex = 3;
            lblPassword.Text = "🔒 密码：";
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Microsoft YaHei UI", 10F, FontStyle.Bold);
            lblUsername.ForeColor = Color.FromArgb(219, 112, 147);
            lblUsername.Location = new Point(80, 112);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(103, 24);
            lblUsername.TabIndex = 2;
            lblUsername.Text = "👤 用户名：";
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Microsoft YaHei UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(219, 112, 147);
            lblTitle.Location = new Point(0, 30);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(400, 40);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "✨ WinWMS 登录";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblSubtitle
            // 
            lblSubtitle.Font = new Font("Microsoft YaHei UI", 10F);
            lblSubtitle.ForeColor = Color.FromArgb(255, 105, 180);
            lblSubtitle.Location = new Point(0, 70);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(400, 25);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "仓储管理系统 - 安全登录";
            lblSubtitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 240, 245);
            ClientSize = new Size(1400, 800);
            Controls.Add(panelLogin);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "WinWMS 用户登录";
            panelLogin.ResumeLayout(false);
            panelLogin.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelLogin;
        private Label lblTitle;
        private Label lblSubtitle;
        private Label lblUsername;
        private Label lblPassword;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private Button btnLogin;
    }
}
