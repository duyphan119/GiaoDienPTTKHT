
namespace BTL
{
    partial class ucQuanLyBan
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.metroButton7 = new MetroFramework.Controls.MetroButton();
            this.metroButton8 = new MetroFramework.Controls.MetroButton();
            this.metroButton6 = new MetroFramework.Controls.MetroButton();
            this.metroButton5 = new MetroFramework.Controls.MetroButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listView1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(26, 129);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(974, 398);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh Sách Bàn";
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(6, 29);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(952, 363);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Mã Bàn";
            this.columnHeader1.Width = 200;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Tên Bàn";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 210;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Trạng Thái";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 300;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(576, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 40);
            this.label1.TabIndex = 15;
            this.label1.Text = "Tiềm kiếm";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(708, 73);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(292, 40);
            this.textBox1.TabIndex = 14;
            // 
            // metroButton7
            // 
            this.metroButton7.BackColor = System.Drawing.Color.SeaGreen;
            this.metroButton7.DisplayFocus = true;
            this.metroButton7.ForeColor = System.Drawing.Color.Snow;
            this.metroButton7.Location = new System.Drawing.Point(300, 73);
            this.metroButton7.Name = "metroButton7";
            this.metroButton7.Size = new System.Drawing.Size(113, 40);
            this.metroButton7.TabIndex = 9;
            this.metroButton7.Text = "Xoá";
            this.metroButton7.UseCustomBackColor = true;
            this.metroButton7.UseCustomForeColor = true;
            this.metroButton7.UseSelectable = true;
            this.metroButton7.UseStyleColors = true;
            // 
            // metroButton8
            // 
            this.metroButton8.BackColor = System.Drawing.Color.SeaGreen;
            this.metroButton8.DisplayFocus = true;
            this.metroButton8.ForeColor = System.Drawing.Color.Snow;
            this.metroButton8.Location = new System.Drawing.Point(429, 73);
            this.metroButton8.Name = "metroButton8";
            this.metroButton8.Size = new System.Drawing.Size(113, 40);
            this.metroButton8.TabIndex = 10;
            this.metroButton8.Text = "Tạo Nhanh";
            this.metroButton8.UseCustomBackColor = true;
            this.metroButton8.UseCustomForeColor = true;
            this.metroButton8.UseSelectable = true;
            this.metroButton8.UseStyleColors = true;
            // 
            // metroButton6
            // 
            this.metroButton6.BackColor = System.Drawing.Color.SeaGreen;
            this.metroButton6.DisplayFocus = true;
            this.metroButton6.ForeColor = System.Drawing.Color.Snow;
            this.metroButton6.Location = new System.Drawing.Point(161, 73);
            this.metroButton6.Name = "metroButton6";
            this.metroButton6.Size = new System.Drawing.Size(113, 40);
            this.metroButton6.TabIndex = 11;
            this.metroButton6.Text = "Sửa";
            this.metroButton6.UseCustomBackColor = true;
            this.metroButton6.UseCustomForeColor = true;
            this.metroButton6.UseSelectable = true;
            this.metroButton6.UseStyleColors = true;
            // 
            // metroButton5
            // 
            this.metroButton5.BackColor = System.Drawing.Color.SeaGreen;
            this.metroButton5.DisplayFocus = true;
            this.metroButton5.ForeColor = System.Drawing.Color.Snow;
            this.metroButton5.Location = new System.Drawing.Point(26, 73);
            this.metroButton5.Name = "metroButton5";
            this.metroButton5.Size = new System.Drawing.Size(113, 40);
            this.metroButton5.TabIndex = 12;
            this.metroButton5.Text = "Thêm";
            this.metroButton5.UseCustomBackColor = true;
            this.metroButton5.UseCustomForeColor = true;
            this.metroButton5.UseSelectable = true;
            this.metroButton5.UseStyleColors = true;
            // 
            // ucQuanLyBan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.metroButton7);
            this.Controls.Add(this.metroButton8);
            this.Controls.Add(this.metroButton6);
            this.Controls.Add(this.metroButton5);
            this.Name = "ucQuanLyBan";
            this.Size = new System.Drawing.Size(1020, 542);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private MetroFramework.Controls.MetroButton metroButton7;
        private MetroFramework.Controls.MetroButton metroButton8;
        private MetroFramework.Controls.MetroButton metroButton6;
        private MetroFramework.Controls.MetroButton metroButton5;
    }
}
