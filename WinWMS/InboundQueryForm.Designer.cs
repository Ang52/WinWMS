namespace WinWMS
{
    partial class InboundQueryForm
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            dataGridView1 = new DataGridView();
            topPanel = new Panel();
            btnSearch = new Button();
            cmbWarehouse = new ComboBox();
            lblWarehouse = new Label();
            cmbMaterial = new ComboBox();
            lblMaterial = new Label();
            dtpEndDate = new DateTimePicker();
            lblEndDate = new Label();
            dtpStartDate = new DateTimePicker();
            lblStartDate = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            topPanel.SuspendLayout();
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
            dataGridView1.Location = new Point(20, 100);
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
            dataGridView1.Size = new Size(960, 480);
            dataGridView1.TabIndex = 0;
            // 
            // topPanel
            // 
            topPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            topPanel.BackColor = Color.White;
            topPanel.Controls.Add(btnSearch);
            topPanel.Controls.Add(cmbWarehouse);
            topPanel.Controls.Add(lblWarehouse);
            topPanel.Controls.Add(cmbMaterial);
            topPanel.Controls.Add(lblMaterial);
            topPanel.Controls.Add(dtpEndDate);
            topPanel.Controls.Add(lblEndDate);
            topPanel.Controls.Add(dtpStartDate);
            topPanel.Controls.Add(lblStartDate);
            topPanel.Location = new Point(20, 20);
            topPanel.Name = "topPanel";
            topPanel.Padding = new Padding(20, 15, 20, 15);
            topPanel.Size = new Size(960, 65);
            topPanel.TabIndex = 10;
            // 
            // btnSearch
            // 
            btnSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSearch.BackColor = Color.FromArgb(255, 105, 180);  // 深粉色按钮
            btnSearch.Cursor = Cursors.Hand;
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("Microsoft YaHei UI", 11F, FontStyle.Bold);
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(835, 13);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(105, 38);
            btnSearch.TabIndex = 1;
            btnSearch.Text = "🔍 查询";
            btnSearch.UseVisualStyleBackColor = false;
            // 
            // cmbWarehouse
            // 
            cmbWarehouse.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cmbWarehouse.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbWarehouse.Font = new Font("Microsoft YaHei UI", 10F);
            cmbWarehouse.FormattingEnabled = true;
            cmbWarehouse.Location = new Point(670, 18);
            cmbWarehouse.Name = "cmbWarehouse";
            cmbWarehouse.Size = new Size(140, 27);
            cmbWarehouse.TabIndex = 5;
            // 
            // lblWarehouse
            // 
            lblWarehouse.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblWarehouse.AutoSize = true;
            lblWarehouse.Font = new Font("Microsoft YaHei UI", 10F);
            lblWarehouse.ForeColor = Color.FromArgb(64, 64, 64);
            lblWarehouse.Location = new Point(605, 21);
            lblWarehouse.Name = "lblWarehouse";
            lblWarehouse.Size = new Size(65, 20);
            lblWarehouse.TabIndex = 9;
            lblWarehouse.Text = "仓库：";
            // 
            // cmbMaterial
            // 
            cmbMaterial.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cmbMaterial.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMaterial.Font = new Font("Microsoft YaHei UI", 10F);
            cmbMaterial.FormattingEnabled = true;
            cmbMaterial.Location = new Point(455, 18);
            cmbMaterial.Name = "cmbMaterial";
            cmbMaterial.Size = new Size(130, 27);
            cmbMaterial.TabIndex = 4;
            // 
            // lblMaterial
            // 
            lblMaterial.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblMaterial.AutoSize = true;
            lblMaterial.Font = new Font("Microsoft YaHei UI", 10F);
            lblMaterial.ForeColor = Color.FromArgb(64, 64, 64);
            lblMaterial.Location = new Point(390, 21);
            lblMaterial.Name = "lblMaterial";
            lblMaterial.Size = new Size(65, 20);
            lblMaterial.TabIndex = 8;
            lblMaterial.Text = "物料：";
            // 
            // dtpEndDate
            // 
            dtpEndDate.CalendarFont = new Font("Microsoft YaHei UI", 10F);
            dtpEndDate.Font = new Font("Microsoft YaHei UI", 10F);
            dtpEndDate.Location = new Point(230, 18);
            dtpEndDate.Name = "dtpEndDate";
            dtpEndDate.Size = new Size(140, 25);
            dtpEndDate.TabIndex = 3;
            // 
            // lblEndDate
            // 
            lblEndDate.AutoSize = true;
            lblEndDate.Font = new Font("Microsoft YaHei UI", 10F);
            lblEndDate.ForeColor = Color.FromArgb(64, 64, 64);
            lblEndDate.Location = new Point(195, 21);
            lblEndDate.Name = "lblEndDate";
            lblEndDate.Size = new Size(35, 20);
            lblEndDate.TabIndex = 7;
            lblEndDate.Text = "至";
            // 
            // dtpStartDate
            // 
            dtpStartDate.CalendarFont = new Font("Microsoft YaHei UI", 10F);
            dtpStartDate.Font = new Font("Microsoft YaHei UI", 10F);
            dtpStartDate.Location = new Point(80, 18);
            dtpStartDate.Name = "dtpStartDate";
            dtpStartDate.Size = new Size(105, 25);
            dtpStartDate.TabIndex = 2;
            // 
            // lblStartDate
            // 
            lblStartDate.AutoSize = true;
            lblStartDate.Font = new Font("Microsoft YaHei UI", 10F);
            lblStartDate.ForeColor = Color.FromArgb(64, 64, 64);
            lblStartDate.Location = new Point(15, 21);
            lblStartDate.Name = "lblStartDate";
            lblStartDate.Size = new Size(65, 20);
            lblStartDate.TabIndex = 6;
            lblStartDate.Text = "日期：";
            // 
            // InboundQueryForm
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 240, 245);  // 浅粉色背景
            ClientSize = new Size(1000, 600);
            Controls.Add(dataGridView1);
            Controls.Add(topPanel);
            Font = new Font("Microsoft YaHei UI", 9F);
            MinimumSize = new Size(800, 500);
            Name = "InboundQueryForm";
            Text = "入库查询";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            topPanel.ResumeLayout(false);
            topPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private Button btnSearch;
        private DateTimePicker dtpStartDate;
        private DateTimePicker dtpEndDate;
        private ComboBox cmbMaterial;
        private ComboBox cmbWarehouse;
        private Label lblStartDate;
        private Label lblEndDate;
        private Label lblMaterial;
        private Label lblWarehouse;
        private Panel topPanel;
    }
}
