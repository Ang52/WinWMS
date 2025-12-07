namespace WinWMS
{
    partial class InventoryQueryForm
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtMaterialCode = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtSpec = new System.Windows.Forms.TextBox();
            this.cmbWarehouse = new System.Windows.Forms.ComboBox();
            this.lblMaterialCode = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblSpec = new System.Windows.Forms.Label();
            this.lblWarehouse = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 70);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(776, 368);
            this.dataGridView1.TabIndex = 0;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(694, 29);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "查询";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // txtMaterialCode
            // 
            this.txtMaterialCode.Location = new System.Drawing.Point(75, 30);
            this.txtMaterialCode.Name = "txtMaterialCode";
            this.txtMaterialCode.Size = new System.Drawing.Size(100, 23);
            this.txtMaterialCode.TabIndex = 2;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(224, 30);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(100, 23);
            this.txtName.TabIndex = 3;
            // 
            // txtSpec
            // 
            this.txtSpec.Location = new System.Drawing.Point(373, 30);
            this.txtSpec.Name = "txtSpec";
            this.txtSpec.Size = new System.Drawing.Size(100, 23);
            this.txtSpec.TabIndex = 4;
            // 
            // cmbWarehouse
            // 
            this.cmbWarehouse.FormattingEnabled = true;
            this.cmbWarehouse.Location = new System.Drawing.Point(522, 30);
            this.cmbWarehouse.Name = "cmbWarehouse";
            this.cmbWarehouse.Size = new System.Drawing.Size(121, 23);
            this.cmbWarehouse.TabIndex = 5;
            // 
            // lblMaterialCode
            // 
            this.lblMaterialCode.AutoSize = true;
            this.lblMaterialCode.Location = new System.Drawing.Point(14, 33);
            this.lblMaterialCode.Name = "lblMaterialCode";
            this.lblMaterialCode.Size = new System.Drawing.Size(55, 15);
            this.lblMaterialCode.TabIndex = 6;
            this.lblMaterialCode.Text = "物资编号";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(187, 33);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(31, 15);
            this.lblName.TabIndex = 7;
            this.lblName.Text = "名称";
            // 
            // lblSpec
            // 
            this.lblSpec.AutoSize = true;
            this.lblSpec.Location = new System.Drawing.Point(336, 33);
            this.lblSpec.Name = "lblSpec";
            this.lblSpec.Size = new System.Drawing.Size(31, 15);
            this.lblSpec.TabIndex = 8;
            this.lblSpec.Text = "规格";
            // 
            // lblWarehouse
            // 
            this.lblWarehouse.AutoSize = true;
            this.lblWarehouse.Location = new System.Drawing.Point(485, 33);
            this.lblWarehouse.Name = "lblWarehouse";
            this.lblWarehouse.Size = new System.Drawing.Size(31, 15);
            this.lblWarehouse.TabIndex = 9;
            this.lblWarehouse.Text = "仓库";
            // 
            // InventoryQueryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblWarehouse);
            this.Controls.Add(this.lblSpec);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblMaterialCode);
            this.Controls.Add(this.cmbWarehouse);
            this.Controls.Add(this.txtSpec);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtMaterialCode);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.dataGridView1);
            this.Name = "InventoryQueryForm";
            this.Text = "库存查询";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtMaterialCode;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtSpec;
        private System.Windows.Forms.ComboBox cmbWarehouse;
        private System.Windows.Forms.Label lblMaterialCode;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblSpec;
        private System.Windows.Forms.Label lblWarehouse;
    }
}
