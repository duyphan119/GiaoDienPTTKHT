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
        public ucNhaCungCap uc_NCC;
        public ucNhapKho uc_NK;
        public ucXuatKho uc_XK;
        public ucKhoHang(NhanVien x)
        {
            InitializeComponent();
            nv = x;
        }

        private void btnSupplier_Click(object sender, EventArgs e)
        {
            uc_NCC.Visible = true;
            uc_NK.Visible = false;
            uc_XK.Visible = false;
            //panel1.Controls.Clear();
            //panel1.Controls.Add(new ucNhaCungCap(nv));
        }

        private void ucKhoHang_Load(object sender, EventArgs e)
        {
            uc_NCC = new ucNhaCungCap(nv);
            uc_NK = new ucNhapKho(nv);
            uc_XK = new ucXuatKho(nv);
            panel1.Controls.Add(uc_NCC);
            panel1.Controls.Add(uc_NK);
            panel1.Controls.Add(uc_XK);
            //panel1.Controls.Clear();
            //panel1.Controls.Add(new ucNhaCungCap(nv));
            uc_NCC.Visible = true;
            uc_NK.Visible = false;
            uc_XK.Visible = false;
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            uc_NK.Visible = true;
            uc_NCC.Visible = false;
            uc_XK.Visible = false;
            //panel1.Controls.Clear();
            //panel1.Controls.Add(new ucNhapKho(nv));
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            uc_XK.Visible = true;
            uc_NCC.Visible = false;
            uc_NK.Visible = false;
            //panel1.Controls.Clear();
            //panel1.Controls.Add(new ucXuatKho(nv));
        }
    }
}
