
namespace BTL
{
    partial class ucDanhMuc
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
            this.btnManagerAcount = new MetroFramework.Controls.MetroButton();
            this.metroButton2 = new MetroFramework.Controls.MetroButton();
            this.metroButton3 = new MetroFramework.Controls.MetroButton();
            this.metroButton4 = new MetroFramework.Controls.MetroButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // btnManagerAcount
            // 
            this.btnManagerAcount.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnManagerAcount.DisplayFocus = true;
            this.btnManagerAcount.ForeColor = System.Drawing.SystemColors.Window;
            this.btnManagerAcount.Location = new System.Drawing.Point(72, 31);
            this.btnManagerAcount.Name = "btnManagerAcount";
            this.btnManagerAcount.Size = new System.Drawing.Size(160, 58);
            this.btnManagerAcount.TabIndex = 3;
            this.btnManagerAcount.Text = "Quản Lý Tài Khoản";
            this.btnManagerAcount.UseCustomBackColor = true;
            this.btnManagerAcount.UseCustomForeColor = true;
            this.btnManagerAcount.UseSelectable = true;
            this.btnManagerAcount.UseStyleColors = true;
            this.btnManagerAcount.UseWaitCursor = true;
            this.btnManagerAcount.Click += new System.EventHandler(this.btnManagerAcount_Click);
            // 
            // metroButton2
            // 
            this.metroButton2.BackColor = System.Drawing.Color.DodgerBlue;
            this.metroButton2.DisplayFocus = true;
            this.metroButton2.ForeColor = System.Drawing.SystemColors.Window;
            this.metroButton2.Location = new System.Drawing.Point(304, 31);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.Size = new System.Drawing.Size(159, 58);
            this.metroButton2.TabIndex = 4;
            this.metroButton2.Text = "Quản Lý Nhóm Món";
            this.metroButton2.UseCustomBackColor = true;
            this.metroButton2.UseCustomForeColor = true;
            this.metroButton2.UseSelectable = true;
            this.metroButton2.UseStyleColors = true;
            this.metroButton2.UseWaitCursor = true;
            this.metroButton2.Click += new System.EventHandler(this.metroButton2_Click);
            // 
            // metroButton3
            // 
            this.metroButton3.BackColor = System.Drawing.Color.DodgerBlue;
            this.metroButton3.DisplayFocus = true;
            this.metroButton3.ForeColor = System.Drawing.SystemColors.Window;
            this.metroButton3.Location = new System.Drawing.Point(536, 31);
            this.metroButton3.Name = "metroButton3";
            this.metroButton3.Size = new System.Drawing.Size(160, 58);
            this.metroButton3.TabIndex = 5;
            this.metroButton3.Text = "Quản Lý Bàn";
            this.metroButton3.UseCustomBackColor = true;
            this.metroButton3.UseCustomForeColor = true;
            this.metroButton3.UseSelectable = true;
            this.metroButton3.UseStyleColors = true;
            this.metroButton3.UseWaitCursor = true;
            this.metroButton3.Click += new System.EventHandler(this.metroButton3_Click);
            // 
            // metroButton4
            // 
            this.metroButton4.BackColor = System.Drawing.Color.DodgerBlue;
            this.metroButton4.DisplayFocus = true;
            this.metroButton4.ForeColor = System.Drawing.SystemColors.Window;
            this.metroButton4.Location = new System.Drawing.Point(768, 31);
            this.metroButton4.Name = "metroButton4";
            this.metroButton4.Size = new System.Drawing.Size(159, 58);
            this.metroButton4.TabIndex = 6;
            this.metroButton4.Text = "Quản Lý Thực Đơn";
            this.metroButton4.UseCustomBackColor = true;
            this.metroButton4.UseCustomForeColor = true;
            this.metroButton4.UseSelectable = true;
            this.metroButton4.UseStyleColors = true;
            this.metroButton4.UseWaitCursor = true;
            this.metroButton4.Click += new System.EventHandler(this.metroButton4_Click);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 116);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1020, 553);
            this.panel1.TabIndex = 7;
            // 
            // ucDanhMuc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.metroButton4);
            this.Controls.Add(this.metroButton3);
            this.Controls.Add(this.metroButton2);
            this.Controls.Add(this.btnManagerAcount);
            this.Name = "ucDanhMuc";
            this.Size = new System.Drawing.Size(1020, 669);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroButton btnManagerAcount;
        private MetroFramework.Controls.MetroButton metroButton2;
        private MetroFramework.Controls.MetroButton metroButton3;
        private MetroFramework.Controls.MetroButton metroButton4;
        private System.Windows.Forms.Panel panel1;
    }
}
