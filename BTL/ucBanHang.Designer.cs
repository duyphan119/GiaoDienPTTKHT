
namespace BTL
{
    partial class ucBanHang
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvFood = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lbPriceSum = new System.Windows.Forms.Label();
            this.lblTimeIn = new System.Windows.Forms.Label();
            this.lblInfoTable = new System.Windows.Forms.Label();
            this.fpnlTable = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnPrintBill = new BTL.RJButton();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFood)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.dgvFood);
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.9F);
            this.panel2.Location = new System.Drawing.Point(438, 141);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(843, 449);
            this.panel2.TabIndex = 2;
            // 
            // dgvFood
            // 
            this.dgvFood.AllowUserToAddRows = false;
            this.dgvFood.AllowUserToDeleteRows = false;
            this.dgvFood.AllowUserToResizeColumns = false;
            this.dgvFood.AllowUserToResizeRows = false;
            this.dgvFood.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvFood.BackgroundColor = System.Drawing.Color.White;
            this.dgvFood.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.SkyBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.SkyBlue;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvFood.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvFood.ColumnHeadersHeight = 44;
            this.dgvFood.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column3,
            this.Column2,
            this.Column4});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvFood.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvFood.Enabled = false;
            this.dgvFood.EnableHeadersVisualStyles = false;
            this.dgvFood.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgvFood.Location = new System.Drawing.Point(0, 0);
            this.dgvFood.Name = "dgvFood";
            this.dgvFood.RowHeadersVisible = false;
            this.dgvFood.RowHeadersWidth = 51;
            this.dgvFood.RowTemplate.Height = 24;
            this.dgvFood.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFood.Size = new System.Drawing.Size(843, 449);
            this.dgvFood.TabIndex = 31;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "     Tên món";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "     Đơn Vị Tính";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "     Số Lượng";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "     Đơn Giá";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // lbPriceSum
            // 
            this.lbPriceSum.AutoSize = true;
            this.lbPriceSum.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lbPriceSum.Location = new System.Drawing.Point(439, 596);
            this.lbPriceSum.Name = "lbPriceSum";
            this.lbPriceSum.Size = new System.Drawing.Size(106, 20);
            this.lbPriceSum.TabIndex = 31;
            this.lbPriceSum.Text = "Tổng tiền: 0đ";
            // 
            // lblTimeIn
            // 
            this.lblTimeIn.AutoSize = true;
            this.lblTimeIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimeIn.Location = new System.Drawing.Point(434, 114);
            this.lblTimeIn.Name = "lblTimeIn";
            this.lblTimeIn.Size = new System.Drawing.Size(140, 24);
            this.lblTimeIn.TabIndex = 32;
            this.lblTimeIn.Text = "Giờ khách vào: ";
            // 
            // lblInfoTable
            // 
            this.lblInfoTable.AutoSize = true;
            this.lblInfoTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfoTable.Location = new System.Drawing.Point(434, 76);
            this.lblInfoTable.Name = "lblInfoTable";
            this.lblInfoTable.Size = new System.Drawing.Size(58, 24);
            this.lblInfoTable.TabIndex = 33;
            this.lblInfoTable.Text = "Bàn:  ";
            // 
            // fpnlTable
            // 
            this.fpnlTable.AutoScroll = true;
            this.fpnlTable.Location = new System.Drawing.Point(3, 64);
            this.fpnlTable.Name = "fpnlTable";
            this.fpnlTable.Size = new System.Drawing.Size(420, 602);
            this.fpnlTable.TabIndex = 34;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(420, 46);
            this.label1.TabIndex = 35;
            this.label1.Text = "Danh Sách Bàn";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(437, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(844, 46);
            this.label2.TabIndex = 36;
            this.label2.Text = "Chi Tiết Bàn";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // btnPrintBill
            // 
            this.btnPrintBill.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnPrintBill.BackgroundColor = System.Drawing.Color.RoyalBlue;
            this.btnPrintBill.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnPrintBill.BorderRadius = 5;
            this.btnPrintBill.BorderSize = 0;
            this.btnPrintBill.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrintBill.FlatAppearance.BorderSize = 0;
            this.btnPrintBill.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrintBill.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintBill.ForeColor = System.Drawing.Color.White;
            this.btnPrintBill.Location = new System.Drawing.Point(1107, 596);
            this.btnPrintBill.Name = "btnPrintBill";
            this.btnPrintBill.Size = new System.Drawing.Size(174, 62);
            this.btnPrintBill.TabIndex = 37;
            this.btnPrintBill.Text = "In Hoá Đơn";
            this.btnPrintBill.TextColor = System.Drawing.Color.White;
            this.btnPrintBill.UseVisualStyleBackColor = false;
            this.btnPrintBill.Click += new System.EventHandler(this.btnPrintBill_Click);
            // 
            // ucBanHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnPrintBill);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.fpnlTable);
            this.Controls.Add(this.lblInfoTable);
            this.Controls.Add(this.lblTimeIn);
            this.Controls.Add(this.lbPriceSum);
            this.Controls.Add(this.panel2);
            this.Name = "ucBanHang";
            this.Size = new System.Drawing.Size(1295, 712);
            this.Load += new System.EventHandler(this.ucBanHang_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFood)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbPriceSum;
        private System.Windows.Forms.Label lblTimeIn;
        private System.Windows.Forms.Label lblInfoTable;
        private System.Windows.Forms.FlowLayoutPanel fpnlTable;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvFood;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private RJButton btnPrintBill;
    }
}
