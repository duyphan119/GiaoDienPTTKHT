using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL
{
    public partial class ucDanhMuc : UserControl
    {
        public ucDanhMuc()
        {
            InitializeComponent();
            panel1.Controls.Add(new ucQuanLyTaiKhoan());
        }

        private void btnManagerAcount_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            panel1.Controls.Add(new ucQuanLyTaiKhoan());
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            panel1.Controls.Add(new ucQuanLyNhomMon());
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            panel1.Controls.Add(new ucQuanLyBan());
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            panel1.Controls.Add(new ucQuanLyThucDon());
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
