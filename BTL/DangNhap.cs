using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;

namespace BTL
{
    public partial class DangNhap : MetroForm
    {
        public DangNhap()
        {
            InitializeComponent();
        }

        private void DangNhap_Load(object sender, EventArgs e)
        {

        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            new TrangChu().Visible = true;
            this.Visible = false;
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            panel2.BackColor = Color.RoyalBlue;
            panel3.BackColor = Color.Blue;
            pictureBox1.Image = Image.FromFile(@"..\..\imgs\user-login-hover.png");
            pictureBox2.Image = Image.FromFile(@"..\..\imgs\password-login.png");
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            panel3.BackColor = Color.RoyalBlue;
            panel2.BackColor = Color.Blue;
            pictureBox1.Image = Image.FromFile(@"..\..\imgs\user-login.png");
            pictureBox2.Image = Image.FromFile(@"..\..\imgs\password-login-hover.png");
        }
    }
}
