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
    }
}
