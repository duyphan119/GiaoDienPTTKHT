
namespace BTL
{
    partial class TrangChu
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblInfoEmployee = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnChangePassword = new System.Windows.Forms.Button();
            this.rjButton5 = new BTL.RJButton();
            this.rjButton1 = new BTL.RJButton();
            this.rjButton3 = new BTL.RJButton();
            this.rjButton2 = new BTL.RJButton();
            this.rjButton4 = new BTL.RJButton();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Location = new System.Drawing.Point(253, 87);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1484, 712);
            this.panel2.TabIndex = 3;
            this.panel2.Click += new System.EventHandler(this.panel2_Click);
            this.panel2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseMove);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rjButton5);
            this.panel1.Controls.Add(this.rjButton1);
            this.panel1.Controls.Add(this.rjButton3);
            this.panel1.Controls.Add(this.rjButton2);
            this.panel1.Controls.Add(this.rjButton4);
            this.panel1.Location = new System.Drawing.Point(1, 87);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(252, 712);
            this.panel1.TabIndex = 4;
            // 
            // lblInfoEmployee
            // 
            this.lblInfoEmployee.AutoSize = true;
            this.lblInfoEmployee.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblInfoEmployee.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfoEmployee.Location = new System.Drawing.Point(249, 52);
            this.lblInfoEmployee.Name = "lblInfoEmployee";
            this.lblInfoEmployee.Size = new System.Drawing.Size(218, 20);
            this.lblInfoEmployee.TabIndex = 5;
            this.lblInfoEmployee.Text = "Nhân viên: Phan Khánh Duy";
            this.lblInfoEmployee.Click += new System.EventHandler(this.label1_Click);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.btnLogout);
            this.panel3.Controls.Add(this.btnChangePassword);
            this.panel3.Location = new System.Drawing.Point(337, 77);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(143, 70);
            this.panel3.TabIndex = 0;
            this.panel3.Visible = false;
            // 
            // btnLogout
            // 
            this.btnLogout.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Location = new System.Drawing.Point(3, 35);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(137, 26);
            this.btnLogout.TabIndex = 2;
            this.btnLogout.Text = "Đăng xuất";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnChangePassword
            // 
            this.btnChangePassword.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnChangePassword.FlatAppearance.BorderSize = 0;
            this.btnChangePassword.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnChangePassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChangePassword.Location = new System.Drawing.Point(3, 3);
            this.btnChangePassword.Name = "btnChangePassword";
            this.btnChangePassword.Size = new System.Drawing.Size(137, 26);
            this.btnChangePassword.TabIndex = 1;
            this.btnChangePassword.Text = "Đổi mật khẩu";
            this.btnChangePassword.UseVisualStyleBackColor = true;
            this.btnChangePassword.Click += new System.EventHandler(this.btnChangePassword_Click);
            // 
            // rjButton5
            // 
            this.rjButton5.BackColor = System.Drawing.Color.RoyalBlue;
            this.rjButton5.BackgroundColor = System.Drawing.Color.RoyalBlue;
            this.rjButton5.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.rjButton5.BorderRadius = 20;
            this.rjButton5.BorderSize = 0;
            this.rjButton5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rjButton5.FlatAppearance.BorderSize = 0;
            this.rjButton5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.rjButton5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rjButton5.Font = new System.Drawing.Font("Arial", 10.5F, System.Drawing.FontStyle.Bold);
            this.rjButton5.ForeColor = System.Drawing.Color.White;
            this.rjButton5.Image = global::BTL.Properties.Resources.statistics;
            this.rjButton5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.rjButton5.Location = new System.Drawing.Point(12, 285);
            this.rjButton5.Name = "rjButton5";
            this.rjButton5.Size = new System.Drawing.Size(223, 60);
            this.rjButton5.TabIndex = 4;
            this.rjButton5.Text = "Thống kê";
            this.rjButton5.TextColor = System.Drawing.Color.White;
            this.rjButton5.UseVisualStyleBackColor = false;
            this.rjButton5.Click += new System.EventHandler(this.rjButton5_Click);
            this.rjButton5.MouseLeave += new System.EventHandler(this.rjButton5_MouseLeave);
            this.rjButton5.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rjButton5_MouseMove);
            // 
            // rjButton1
            // 
            this.rjButton1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.rjButton1.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.rjButton1.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.rjButton1.BorderRadius = 20;
            this.rjButton1.BorderSize = 0;
            this.rjButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rjButton1.FlatAppearance.BorderSize = 0;
            this.rjButton1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.rjButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rjButton1.Font = new System.Drawing.Font("Arial", 10.5F, System.Drawing.FontStyle.Bold);
            this.rjButton1.ForeColor = System.Drawing.Color.Blue;
            this.rjButton1.Image = global::BTL.Properties.Resources.home_hover;
            this.rjButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.rjButton1.Location = new System.Drawing.Point(12, 21);
            this.rjButton1.Name = "rjButton1";
            this.rjButton1.Size = new System.Drawing.Size(223, 60);
            this.rjButton1.TabIndex = 0;
            this.rjButton1.Text = "Trang Chủ";
            this.rjButton1.TextColor = System.Drawing.Color.Blue;
            this.rjButton1.UseVisualStyleBackColor = false;
            this.rjButton1.Click += new System.EventHandler(this.rjButton1_Click);
            this.rjButton1.MouseLeave += new System.EventHandler(this.rjButton1_MouseLeave);
            this.rjButton1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rjButton1_MouseMove);
            // 
            // rjButton3
            // 
            this.rjButton3.BackColor = System.Drawing.Color.RoyalBlue;
            this.rjButton3.BackgroundColor = System.Drawing.Color.RoyalBlue;
            this.rjButton3.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.rjButton3.BorderRadius = 20;
            this.rjButton3.BorderSize = 0;
            this.rjButton3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rjButton3.FlatAppearance.BorderSize = 0;
            this.rjButton3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.rjButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rjButton3.Font = new System.Drawing.Font("Arial", 10.5F, System.Drawing.FontStyle.Bold);
            this.rjButton3.ForeColor = System.Drawing.Color.White;
            this.rjButton3.Image = global::BTL.Properties.Resources.home;
            this.rjButton3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.rjButton3.Location = new System.Drawing.Point(12, 219);
            this.rjButton3.Name = "rjButton3";
            this.rjButton3.Size = new System.Drawing.Size(223, 60);
            this.rjButton3.TabIndex = 2;
            this.rjButton3.Text = "Danh Mục";
            this.rjButton3.TextColor = System.Drawing.Color.White;
            this.rjButton3.UseVisualStyleBackColor = false;
            this.rjButton3.Click += new System.EventHandler(this.rjButton3_Click);
            this.rjButton3.MouseLeave += new System.EventHandler(this.rjButton3_MouseLeave);
            this.rjButton3.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rjButton3_MouseMove);
            // 
            // rjButton2
            // 
            this.rjButton2.BackColor = System.Drawing.Color.RoyalBlue;
            this.rjButton2.BackgroundColor = System.Drawing.Color.RoyalBlue;
            this.rjButton2.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.rjButton2.BorderRadius = 20;
            this.rjButton2.BorderSize = 0;
            this.rjButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rjButton2.FlatAppearance.BorderSize = 0;
            this.rjButton2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.rjButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rjButton2.Font = new System.Drawing.Font("Arial", 10.5F, System.Drawing.FontStyle.Bold);
            this.rjButton2.ForeColor = System.Drawing.Color.White;
            this.rjButton2.Image = global::BTL.Properties.Resources.money_bag;
            this.rjButton2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.rjButton2.Location = new System.Drawing.Point(12, 87);
            this.rjButton2.Name = "rjButton2";
            this.rjButton2.Size = new System.Drawing.Size(223, 60);
            this.rjButton2.TabIndex = 1;
            this.rjButton2.Text = "Bán Hàng";
            this.rjButton2.TextColor = System.Drawing.Color.White;
            this.rjButton2.UseVisualStyleBackColor = false;
            this.rjButton2.Click += new System.EventHandler(this.rjButton2_Click);
            this.rjButton2.MouseLeave += new System.EventHandler(this.rjButton2_MouseLeave);
            this.rjButton2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rjButton2_MouseMove);
            // 
            // rjButton4
            // 
            this.rjButton4.BackColor = System.Drawing.Color.RoyalBlue;
            this.rjButton4.BackgroundColor = System.Drawing.Color.RoyalBlue;
            this.rjButton4.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.rjButton4.BorderRadius = 20;
            this.rjButton4.BorderSize = 0;
            this.rjButton4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rjButton4.FlatAppearance.BorderSize = 0;
            this.rjButton4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.rjButton4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rjButton4.Font = new System.Drawing.Font("Arial", 10.5F, System.Drawing.FontStyle.Bold);
            this.rjButton4.ForeColor = System.Drawing.Color.White;
            this.rjButton4.Image = global::BTL.Properties.Resources.bunker;
            this.rjButton4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.rjButton4.Location = new System.Drawing.Point(12, 153);
            this.rjButton4.Name = "rjButton4";
            this.rjButton4.Size = new System.Drawing.Size(223, 60);
            this.rjButton4.TabIndex = 3;
            this.rjButton4.Text = "Kho Hàng";
            this.rjButton4.TextColor = System.Drawing.Color.White;
            this.rjButton4.UseVisualStyleBackColor = false;
            this.rjButton4.Click += new System.EventHandler(this.rjButton4_Click);
            this.rjButton4.MouseLeave += new System.EventHandler(this.rjButton4_MouseLeave);
            this.rjButton4.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rjButton4_MouseMove);
            // 
            // TrangChu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1738, 801);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.lblInfoEmployee);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "TrangChu";
            this.Resizable = false;
            this.Text = "Nhà Hàng";
            this.TransparencyKey = System.Drawing.Color.Empty;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TrangChu_FormClosing);
            this.Load += new System.EventHandler(this.TrangChu_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private RJButton rjButton1;
        private RJButton rjButton5;
        private RJButton rjButton4;
        private RJButton rjButton3;
        private RJButton rjButton2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblInfoEmployee;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnChangePassword;
    }
}