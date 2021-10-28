
namespace BTL
{
    partial class ucQuanLyNhomMon
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
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.metroButton7 = new MetroFramework.Controls.MetroButton();
            this.metroButton6 = new MetroFramework.Controls.MetroButton();
            this.metroButton5 = new MetroFramework.Controls.MetroButton();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(681, 67);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(289, 40);
            this.textBox3.TabIndex = 19;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(681, 10);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(289, 40);
            this.textBox2.TabIndex = 20;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(556, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 40);
            this.label3.TabIndex = 17;
            this.label3.Text = "Tên Nhóm:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(556, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 40);
            this.label2.TabIndex = 18;
            this.label2.Text = "Mã Nhóm:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listView1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(23, 113);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(974, 433);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh sách";
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(16, 29);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(952, 398);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Mã Nhóm";
            this.columnHeader1.Width = 350;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Tên Nhóm";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 350;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(163, 10);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(320, 40);
            this.textBox1.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(27, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 40);
            this.label1.TabIndex = 14;
            this.label1.Text = "Tìm kiếm";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // metroButton7
            // 
            this.metroButton7.BackColor = System.Drawing.Color.SeaGreen;
            this.metroButton7.DisplayFocus = true;
            this.metroButton7.ForeColor = System.Drawing.Color.Snow;
            this.metroButton7.Location = new System.Drawing.Point(296, 67);
            this.metroButton7.Name = "metroButton7";
            this.metroButton7.Size = new System.Drawing.Size(113, 40);
            this.metroButton7.TabIndex = 10;
            this.metroButton7.Text = "Xoá";
            this.metroButton7.UseCustomBackColor = true;
            this.metroButton7.UseCustomForeColor = true;
            this.metroButton7.UseSelectable = true;
            this.metroButton7.UseStyleColors = true;
            // 
            // metroButton6
            // 
            this.metroButton6.BackColor = System.Drawing.Color.SeaGreen;
            this.metroButton6.DisplayFocus = true;
            this.metroButton6.ForeColor = System.Drawing.Color.Snow;
            this.metroButton6.Location = new System.Drawing.Point(163, 67);
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
            this.metroButton5.Location = new System.Drawing.Point(31, 67);
            this.metroButton5.Name = "metroButton5";
            this.metroButton5.Size = new System.Drawing.Size(113, 40);
            this.metroButton5.TabIndex = 12;
            this.metroButton5.Text = "Thêm";
            this.metroButton5.UseCustomBackColor = true;
            this.metroButton5.UseCustomForeColor = true;
            this.metroButton5.UseSelectable = true;
            this.metroButton5.UseStyleColors = true;
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(335, 67);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(60, 20);
            this.metroLabel3.TabIndex = 13;
            this.metroLabel3.Text = "Giới tính";
            // 
            // ucQuanLyNhomMon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.metroButton7);
            this.Controls.Add(this.metroButton6);
            this.Controls.Add(this.metroButton5);
            this.Controls.Add(this.metroLabel3);
            this.Name = "ucQuanLyNhomMon";
            this.Size = new System.Drawing.Size(1020, 542);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private MetroFramework.Controls.MetroButton metroButton7;
        private MetroFramework.Controls.MetroButton metroButton6;
        private MetroFramework.Controls.MetroButton metroButton5;
        private MetroFramework.Controls.MetroLabel metroLabel3;
    }
}
