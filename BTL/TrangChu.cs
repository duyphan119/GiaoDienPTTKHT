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
namespace BTL
{
    public partial class TrangChu : MetroForm
    {
        private bool[] btnClick = new bool[5] { true, false, false, false, false };
        
        public TrangChu()
        {
            InitializeComponent();
        }

        private void TrangChu_Load(object sender, EventArgs e)
        {
            panel2.Controls.Add(new ucTrangChu());
            ToolTip tip = new ToolTip();
            tip.SetToolTip(button1,"Duy Phan đã đăng nhập");
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
            panel4.Visible = false;
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

        private void button6_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button6_MouseLeave(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.ForeColor = Color.White;
        }

        private void button6_MouseMove(object sender, MouseEventArgs e)
        {
            Button btn = sender as Button;
            btn.ForeColor = Color.RoyalBlue;
        }


        private void panel4_MouseLeave(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            panel4.Visible = !panel4.Visible;
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            panel4.Visible = false;
        }

        private void panel3_Click(object sender, EventArgs e)
        {
            panel4.Visible = false;
        }

        private void panel2_Click(object sender, EventArgs e)
        {
            panel4.Visible = false;
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            panel4.Visible = false;
        }

        private void rjButton1_MouseMove(object sender, MouseEventArgs e)
        {
            RJButton btn = sender as RJButton;
            btn.ForeColor = Color.RoyalBlue;
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
            btn.BackColor = Color.White;
            Image img = Image.FromFile(@"..\..\imgs\home-hover.png");
            btn.Image = img;
            btn.ForeColor = Color.RoyalBlue;
            panel2.Controls.RemoveAt(0);
            panel2.Controls.Add(new ucTrangChu());
        }

        private void rjButton2_MouseMove(object sender, MouseEventArgs e)
        {
            RJButton btn = sender as RJButton;
            btn.ForeColor = Color.RoyalBlue;
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
            btn.BackColor = Color.White;
            Image img = Image.FromFile(@"..\..\imgs\money-bag-hover.png");
            btn.Image = img;
            btn.ForeColor = Color.RoyalBlue;
            panel2.Controls.RemoveAt(0);
            panel2.Controls.Add(new ucBanHang());
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
            btn.ForeColor = Color.RoyalBlue;
            Image img = Image.FromFile(@"..\..\imgs\home-hover.png");
            btn.Image = img;
        }

        private void rjButton3_Click(object sender, EventArgs e)
        {
            clearBtnClick();
            btnClick[2] = true;
            Button btn = sender as Button;
            btn.BackColor = Color.White;
            Image img = Image.FromFile(@"..\..\imgs\home-hover.png");
            btn.Image = img;
            btn.ForeColor = Color.RoyalBlue;
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
            btn.ForeColor = Color.RoyalBlue;
            Image img = Image.FromFile(@"..\..\imgs\bunker-hover.png");
            btn.Image = img;
        }

        private void rjButton4_Click(object sender, EventArgs e)
        {
            clearBtnClick();
            btnClick[3] = true;
            Button btn = sender as Button;
            btn.BackColor = Color.White;
            Image img = Image.FromFile(@"..\..\imgs\bunker-hover.png");
            btn.Image = img;
            btn.ForeColor = Color.RoyalBlue;
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
            btn.ForeColor = Color.RoyalBlue;
            Image img = Image.FromFile(@"..\..\imgs\statistics-hover.png");
            btn.Image = img;
        }

        private void rjButton5_Click(object sender, EventArgs e)
        {
            clearBtnClick();
            btnClick[4] = true;
            Button btn = sender as Button;
            btn.BackColor = Color.White;
            Image img = Image.FromFile(@"..\..\imgs\statistics-hover.png");
            btn.Image = img;
            btn.ForeColor = Color.RoyalBlue;
            panel2.Controls.RemoveAt(0);
            panel2.Controls.Add(new ucThongKe());
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.ForeColor = Color.White;
        }

        private void button2_MouseMove(object sender, MouseEventArgs e)
        {
            Button btn = sender as Button;
            btn.ForeColor = Color.RoyalBlue;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel4.Visible = !panel4.Visible;
            button1.BackColor = Color.Gray;
        }
    }
}
