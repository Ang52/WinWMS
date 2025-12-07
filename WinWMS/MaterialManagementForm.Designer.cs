namespace WinWMS
{
    partial class MaterialManagementForm
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
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.txtMaterialCode = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtSpec = new System.Windows.Forms.TextBox();
            this.txtUnit = new System.Windows.Forms.TextBox();
            this.lblMaterialCode = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblSpec = new System.Windows.Forms.Label();
            this.lblUnit = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(776, 255);
            this.dataGridView1.TabIndex = 0;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(12, 415);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "添加";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(111, 415);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 2;
            this.btnUpdate.Text = "更新";
            this.btnUpdate.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(210, 415);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "删除";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // txtMaterialCode
            // 
            this.txtMaterialCode.Location = new System.Drawing.Point(88, 285);
            this.txtMaterialCode.Name = "txtMaterialCode";
            this.txtMaterialCode.Size = new System.Drawing.Size(197, 23);
            this.txtMaterialCode.TabIndex = 4;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(88, 314);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(197, 23);
            this.txtName.TabIndex = 5;
            // 
            // txtSpec
            // 
            this.txtSpec.Location = new System.Drawing.Point(88, 343);
            this.txtSpec.Name = "txtSpec";
            this.txtSpec.Size = new System.Drawing.Size(197, 23);
            this.txtSpec.TabIndex = 6;
            // 
            // txtUnit
            // 
            this.txtUnit.Location = new System.Drawing.Point(88, 372);
            this.txtUnit.Name = "txtUnit";
            this.txtUnit.Size = new System.Drawing.Size(197, 23);
            this.txtUnit.TabIndex = 7;
            // 
            // lblMaterialCode
            // 
            this.lblMaterialCode.AutoSize = true;
            this.lblMaterialCode.Location = new System.Drawing.Point(12, 288);
            this.lblMaterialCode.Name = "lblMaterialCode";
            this.lblMaterialCode.Size = new System.Drawing.Size(55, 15);
            this.lblMaterialCode.TabIndex = 8;
            this.lblMaterialCode.Text = "物资编号";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(12, 317);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(31, 15);
            this.lblName.TabIndex = 9;
            this.lblName.Text = "名称";
            // 
            // lblSpec
            // 
            this.lblSpec.AutoSize = true;
            this.lblSpec.Location = new System.Drawing.Point(12, 346);
            this.lblSpec.Name = "lblSpec";
            this.lblSpec.Size = new System.Drawing.Size(31, 15);
            this.lblSpec.TabIndex = 10;
            this.lblSpec.Text = "规格";
            // 
            // lblUnit
            // 
            this.lblUnit.AutoSize = true;
            this.lblUnit.Location = new System.Drawing.Point(12, 375);
            this.lblUnit.Name = "lblUnit";
            this.lblUnit.Size = new System.Drawing.Size(55, 15);
            this.lblUnit.TabIndex = 11;
            this.lblUnit.Text = "计量单位";
            // 
            // MaterialManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblUnit);
            this.Controls.Add(this.lblSpec);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblMaterialCode);
            this.Controls.Add(this.txtUnit);
            this.Controls.Add(this.txtSpec);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtMaterialCode);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dataGridView1);
            this.Name = "MaterialManagementForm";
            this.Text = "物料管理";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TextBox txtMaterialCode;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtSpec;
        private System.Windows.Forms.TextBox txtUnit;
        private System.Windows.Forms.Label lblMaterialCode;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblSpec;
        private System.Windows.Forms.Label lblUnit;
    }
}
