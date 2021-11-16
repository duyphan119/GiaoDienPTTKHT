
namespace BTL
{
    partial class ucKhoHang
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnExport = new MetroFramework.Controls.MetroButton();
            this.btnImport = new MetroFramework.Controls.MetroButton();
            this.btnProduct = new MetroFramework.Controls.MetroButton();
            this.btnSupplier = new MetroFramework.Controls.MetroButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnExport);
            this.panel3.Controls.Add(this.btnImport);
            this.panel3.Controls.Add(this.btnProduct);
            this.panel3.Controls.Add(this.btnSupplier);
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1020, 77);
            this.panel3.TabIndex = 23;
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnExport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExport.DisplayFocus = true;
            this.btnExport.ForeColor = System.Drawing.SystemColors.Window;
            this.btnExport.Location = new System.Drawing.Point(779, 9);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(159, 58);
            this.btnExport.TabIndex = 14;
            this.btnExport.Text = "Xuất Kho";
            this.btnExport.UseCustomBackColor = true;
            this.btnExport.UseCustomForeColor = true;
            this.btnExport.UseSelectable = true;
            this.btnExport.UseStyleColors = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnImport
            // 
            this.btnImport.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnImport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImport.DisplayFocus = true;
            this.btnImport.ForeColor = System.Drawing.SystemColors.Window;
            this.btnImport.Location = new System.Drawing.Point(547, 9);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(160, 58);
            this.btnImport.TabIndex = 13;
            this.btnImport.Text = "Nhập Kho";
            this.btnImport.UseCustomBackColor = true;
            this.btnImport.UseCustomForeColor = true;
            this.btnImport.UseSelectable = true;
            this.btnImport.UseStyleColors = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnProduct
            // 
            this.btnProduct.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnProduct.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProduct.DisplayFocus = true;
            this.btnProduct.ForeColor = System.Drawing.SystemColors.Window;
            this.btnProduct.Location = new System.Drawing.Point(315, 9);
            this.btnProduct.Name = "btnProduct";
            this.btnProduct.Size = new System.Drawing.Size(159, 58);
            this.btnProduct.TabIndex = 12;
            this.btnProduct.Text = "Nguyên Liệu";
            this.btnProduct.UseCustomBackColor = true;
            this.btnProduct.UseCustomForeColor = true;
            this.btnProduct.UseSelectable = true;
            this.btnProduct.UseStyleColors = true;
            // 
            // btnSupplier
            // 
            this.btnSupplier.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnSupplier.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSupplier.DisplayFocus = true;
            this.btnSupplier.ForeColor = System.Drawing.SystemColors.Window;
            this.btnSupplier.Location = new System.Drawing.Point(83, 9);
            this.btnSupplier.Name = "btnSupplier";
            this.btnSupplier.Size = new System.Drawing.Size(160, 58);
            this.btnSupplier.TabIndex = 11;
            this.btnSupplier.Text = "Nhà Cung Cấp";
            this.btnSupplier.UseCustomBackColor = true;
            this.btnSupplier.UseCustomForeColor = true;
            this.btnSupplier.UseSelectable = true;
            this.btnSupplier.UseStyleColors = true;
            this.btnSupplier.Click += new System.EventHandler(this.btnSupplier_Click);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 83);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1020, 586);
            this.panel1.TabIndex = 24;
            // 
            // ucKhoHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Name = "ucKhoHang";
            this.Size = new System.Drawing.Size(1020, 669);
            this.Load += new System.EventHandler(this.ucKhoHang_Load);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private MetroFramework.Controls.MetroButton btnExport;
        private MetroFramework.Controls.MetroButton btnImport;
        private MetroFramework.Controls.MetroButton btnProduct;
        private MetroFramework.Controls.MetroButton btnSupplier;
        private System.Windows.Forms.Panel panel1;
    }
}
