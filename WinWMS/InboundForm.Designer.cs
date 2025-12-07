namespace WinWMS
{
    partial class InboundForm
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
            this.cmbMaterial = new System.Windows.Forms.ComboBox();
            this.cmbWarehouse = new System.Windows.Forms.ComboBox();
            this.numQuantity = new System.Windows.Forms.NumericUpDown();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.btnInbound = new System.Windows.Forms.Button();
            this.lblMaterial = new System.Windows.Forms.Label();
            this.lblWarehouse = new System.Windows.Forms.Label();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbMaterial
            // 
            this.cmbMaterial.FormattingEnabled = true;
            this.cmbMaterial.Location = new System.Drawing.Point(111, 30);
            this.cmbMaterial.Name = "cmbMaterial";
            this.cmbMaterial.Size = new System.Drawing.Size(200, 23);
            this.cmbMaterial.TabIndex = 0;
            // 
            // cmbWarehouse
            // 
            this.cmbWarehouse.FormattingEnabled = true;
            this.cmbWarehouse.Location = new System.Drawing.Point(111, 70);
            this.cmbWarehouse.Name = "cmbWarehouse";
            this.cmbWarehouse.Size = new System.Drawing.Size(200, 23);
            this.cmbWarehouse.TabIndex = 1;
            // 
            // numQuantity
            // 
            this.numQuantity.Location = new System.Drawing.Point(111, 110);
            this.numQuantity.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numQuantity.Name = "numQuantity";
            this.numQuantity.Size = new System.Drawing.Size(200, 23);
            this.numQuantity.TabIndex = 2;
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(111, 150);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(200, 23);
            this.txtPrice.TabIndex = 3;
            // 
            // btnInbound
            // 
            this.btnInbound.Location = new System.Drawing.Point(111, 200);
            this.btnInbound.Name = "btnInbound";
            this.btnInbound.Size = new System.Drawing.Size(100, 30);
            this.btnInbound.TabIndex = 4;
            this.btnInbound.Text = "执行入库";
            this.btnInbound.UseVisualStyleBackColor = true;
            // 
            // lblMaterial
            // 
            this.lblMaterial.AutoSize = true;
            this.lblMaterial.Location = new System.Drawing.Point(30, 33);
            this.lblMaterial.Name = "lblMaterial";
            this.lblMaterial.Size = new System.Drawing.Size(31, 15);
            this.lblMaterial.TabIndex = 5;
            this.lblMaterial.Text = "物料";
            // 
            // lblWarehouse
            // 
            this.lblWarehouse.AutoSize = true;
            this.lblWarehouse.Location = new System.Drawing.Point(30, 73);
            this.lblWarehouse.Name = "lblWarehouse";
            this.lblWarehouse.Size = new System.Drawing.Size(31, 15);
            this.lblWarehouse.TabIndex = 6;
            this.lblWarehouse.Text = "仓库";
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new System.Drawing.Point(30, 112);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(31, 15);
            this.lblQuantity.TabIndex = 7;
            this.lblQuantity.Text = "数量";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(30, 153);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(55, 15);
            this.lblPrice.TabIndex = 8;
            this.lblPrice.Text = "入库单价";
            // 
            // InboundForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 261);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.lblQuantity);
            this.Controls.Add(this.lblWarehouse);
            this.Controls.Add(this.lblMaterial);
            this.Controls.Add(this.btnInbound);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.numQuantity);
            this.Controls.Add(this.cmbWarehouse);
            this.Controls.Add(this.cmbMaterial);
            this.Name = "InboundForm";
            this.Text = "入库操作";
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbMaterial;
        private System.Windows.Forms.ComboBox cmbWarehouse;
        private System.Windows.Forms.NumericUpDown numQuantity;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Button btnInbound;
        private System.Windows.Forms.Label lblMaterial;
        private System.Windows.Forms.Label lblWarehouse;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.Label lblPrice;
    }
}
