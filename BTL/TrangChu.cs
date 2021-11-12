using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using System.Drawing.Drawing2D;
using BTL.Model;

namespace BTL
{
    public partial class TrangChu : MetroForm
    {
        private bool[] btnClick = new bool[5] { true, false, false, false, false };
        private NhanVien nv = new NhanVien();
        
        public TrangChu(NhanVien x)
        {
            InitializeComponent();
            nv = x;
        }

        private void TrangChu_Load(object sender, EventArgs e)
        {
            panel2.Controls.Add(new ucTrangChu());
            ToolTip tip = new ToolTip();
            lblInfoEmployee.Text = "Nhân viên: " + nv.ten;
            if (nv.quyen == "user")
            {
                rjButton5.Location = new Point(rjButton3.Location.X, rjButton3.Location.Y);
                rjButton3.Visible = false;
            }
        }

        public void clearBtnClick()
        {
            for(int i = 0; i < btnClick.Length; i++)
            {
                if(btnClick[i] == true)
                {
                    btnClick[i] = false;
                    break;
                }
            }
            rjButton1.ForeColor = Color.White;
            rjButton1.BackColor = Color.RoyalBlue;
            Image img1 = Image.FromFile(@"..\..\imgs\home.png");
            rjButton1.Image = img1;
            rjButton2.ForeColor = Color.White;
            rjButton2.BackColor = Color.RoyalBlue;
            Image img2 = Image.FromFile(@"..\..\imgs\money-bag.png");
            rjButton2.Image = img2;
            rjButton3.ForeColor = Color.White;
            rjButton3.BackColor = Color.RoyalBlue;
            Image img3 = Image.FromFile(@"..\..\imgs\home.png");
            rjButton3.Image = img3;
            rjButton4.ForeColor = Color.White;
            rjButton4.BackColor = Color.RoyalBlue;
            Image img4 = Image.FromFile(@"..\..\imgs\bunker.png");
            rjButton4.Image = img4;
            rjButton5.ForeColor = Color.White;
            rjButton5.BackColor = Color.RoyalBlue;
            Image img5 = Image.FromFile(@"..\..\imgs\statistics.png");
            rjButton5.Image = img5;
        }

        private void panel2_Click(object sender, EventArgs e)
        {
           
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            
        }

        private void rjButton1_MouseMove(object sender, MouseEventArgs e)
        {
            RJButton btn = sender as RJButton;
            btn.ForeColor = Color.Blue;
            Image img = Image.FromFile(@"..\..\imgs\home-hover.png");
            btn.Image = img;
        }

        private void rjButton1_MouseLeave(object sender, EventArgs e)
        {
            if (!btnClick[0])
            {
                RJButton btn = sender as RJButton;
                btn.ForeColor = Color.White;
                Image img = Image.FromFile(@"..\..\imgs\home.png");
                btn.Image = img;
            }
        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            clearBtnClick();
            btnClick[0] = true;
            Button btn = sender as Button;
            btn.BackColor = Color.WhiteSmoke;
            Image img = Image.FromFile(@"..\..\imgs\home-hover.png");
            btn.Image = img;
            btn.ForeColor = Color.Blue;
            panel2.Controls.RemoveAt(0);
            panel2.Controls.Add(new ucTrangChu());
        }

        private void rjButton2_MouseMove(object sender, MouseEventArgs e)
        {
            RJButton btn = sender as RJButton;
            btn.ForeColor = Color.Blue;
            Image img = Image.FromFile(@"..\..\imgs\money-bag-hover.png");
            btn.Image = img;
        }

        private void rjButton2_MouseLeave(object sender, EventArgs e)
        {
            if (!btnClick[1])
            {
                RJButton btn = sender as RJButton;
                btn.ForeColor = Color.White;
                Image img = Image.FromFile(@"..\..\imgs\money-bag.png");
                btn.Image = img;
            }
        }

        private void rjButton2_Click(object sender, EventArgs e)
        {
            clearBtnClick();
            btnClick[1] = true;
            Button btn = sender as Button;
            btn.BackColor = Color.WhiteSmoke;
            Image img = Image.FromFile(@"..\..\imgs\money-bag-hover.png");
            btn.Image = img;
            btn.ForeColor = Color.Blue;
            panel2.Controls.RemoveAt(0);
            panel2.Controls.Add(new ucBanHang(nv));
        }

        private void rjButton3_MouseLeave(object sender, EventArgs e)
        {
            if (!btnClick[2])
            {
                RJButton btn = sender as RJButton;
                btn.ForeColor = Color.White;
                Image img = Image.FromFile(@"..\..\imgs\home.png");
                btn.Image = img;
            }
        }

        private void rjButton3_MouseMove(object sender, MouseEventArgs e)
        {
            RJButton btn = sender as RJButton;
            btn.ForeColor = Color.Blue;
            Image img = Image.FromFile(@"..\..\imgs\home-hover.png");
            btn.Image = img;
        }

        private void rjButton3_Click(object sender, EventArgs e)
        {
            clearBtnClick();
            btnClick[2] = true;
            Button btn = sender as Button;
            btn.BackColor = Color.WhiteSmoke;
            Image img = Image.FromFile(@"..\..\imgs\home-hover.png");
            btn.Image = img;
            btn.ForeColor = Color.Blue;
            panel2.Controls.RemoveAt(0);
            panel2.Controls.Add(new ucDanhMuc());
        }

        private void rjButton4_MouseLeave(object sender, EventArgs e)
        {
            if (!btnClick[3])
            {
                RJButton btn = sender as RJButton;
                btn.ForeColor = Color.White;
                Image img = Image.FromFile(@"..\..\imgs\bunker.png");
                btn.Image = img;
            }
        }

        private void rjButton4_MouseMove(object sender, MouseEventArgs e)
        {
            RJButton btn = sender as RJButton;
            btn.ForeColor = Color.Blue;
            Image img = Image.FromFile(@"..\..\imgs\bunker-hover.png");
            btn.Image = img;
        }

        private void rjButton4_Click(object sender, EventArgs e)
        {
            clearBtnClick();
            btnClick[3] = true;
            Button btn = sender as Button;
            btn.BackColor = Color.WhiteSmoke;
            Image img = Image.FromFile(@"..\..\imgs\bunker-hover.png");
            btn.Image = img;
            btn.ForeColor = Color.Blue;
            panel2.Controls.RemoveAt(0);
            panel2.Controls.Add(new ucKhoHang());
        }

        private void rjButton5_MouseLeave(object sender, EventArgs e)
        {
            if (!btnClick[4])
            {
                RJButton btn = sender as RJButton;
                btn.ForeColor = Color.White;
                Image img = Image.FromFile(@"..\..\imgs\statistics.png");
                btn.Image = img;
            }
        }

        private void rjButton5_MouseMove(object sender, MouseEventArgs e)
        {
            RJButton btn = sender as RJButton;
            btn.ForeColor = Color.Blue;
            Image img = Image.FromFile(@"..\..\imgs\statistics-hover.png");
            btn.Image = img;
        }

        private void rjButton5_Click(object sender, EventArgs e)
        {
            clearBtnClick();
            btnClick[4] = true;
            Button btn = sender as Button;
            btn.BackColor = Color.WhiteSmoke;
            Image img = Image.FromFile(@"..\..\imgs\statistics-hover.png");
            btn.Image = img;
            btn.ForeColor = Color.Blue;
            panel2.Controls.RemoveAt(0);
            panel2.Controls.Add(new ucThongKe());
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.ForeColor = Color.White;
        }

        private void TrangChu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            panel3.Visible = !panel3.Visible;
        }
    }
}
