using BTL.Model;
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
    public partial class ucKhoHang : UserControl
    {
        public NhanVien nv;
        public ucKhoHang(NhanVien x)
        {
            InitializeComponent();
            nv = x;
        }

        private void btnSupplier_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            panel1.Controls.Add(new ucNhaCungCap(nv));
        }

        private void ucKhoHang_Load(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            panel1.Controls.Add(new ucNhaCungCap(nv));
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            panel1.Controls.Add(new ucNhapKho(nv));
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            panel1.Controls.Add(new ucXuatKho(nv));
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            panel1.Controls.Add(new ucNguyenLieu(nv));
        }
    }
}
