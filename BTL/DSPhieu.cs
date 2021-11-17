using BTL.Model;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL
{
    public partial class DSPhieu : MetroForm
    {
        private SqlConnection cnn;
        private SqlCommand scm;
        private SqlDataReader reader;
        private List<NhanVien> ds_nv = new List<NhanVien>();
        private List<Phieu> ds_ph = new List<Phieu>();
        private ucNhapKho nk;
        private ucXuatKho xk;

        public DSPhieu(ucNhapKho _nk, ucXuatKho _xk)
        {
            InitializeComponent();
            nk = _nk;
            xk = _xk;
            if(nk == null)
            {
                phieu(false);
            }
            else
            {
                phieu(true);
            }
        }

        public void phieu(bool kieu)
        {
            //kieu = true: nhập kho
            //kieu = false: xuất kho
            dgvList.Rows.Clear();
            ds_ph.Clear();
            cnn = new SqlConnection(
                @"Data Source=DESKTOP-NIULDEP\SQLEXPRESS;Initial Catalog=btl_pttkht;User ID=sa;Password=password"
            );
            cnn.Open();
            scm = new SqlCommand("select * from nhanvien", cnn);
            reader = scm.ExecuteReader();
            while (reader.Read())
            {
                int ma = reader.GetInt32(0);
                string ten = reader.GetString(1);
                string gioitinh = reader.GetString(2);
                string sdt = reader.GetString(3);
                string chucvu = reader.GetString(4);
                string matkhau = reader.GetString(5);
                string quyen = reader.GetString(6);
                DateTime ngaysinh = reader.GetDateTime(7);
                NhanVien nv = new NhanVien(
                    ten, ngaysinh, gioitinh, ma, sdt, chucvu, quyen, matkhau
                );
                ds_nv.Add(nv);
            }
            cnn.Close();
            cnn.Open();
            if(kieu == true)
            {
                scm = new SqlCommand("select * from phieunhap", cnn);
            }
            else
            {
                scm = new SqlCommand("select * from phieuxuat", cnn);
            }
            reader = scm.ExecuteReader();
            while (reader.Read())
            {
                int ma = reader.GetInt32(0);
                DateTime ngay = reader.GetDateTime(1);
                Phieu ph = new Phieu(ma, ngay, ds_nv.Find(item=>item.ma == reader.GetInt32(2)), new List<ChiTietPhieu>());
                ds_ph.Add(ph);
                dgvList.Rows.Add(new object[]
                {
                    ph.sophieu, ph.ngay, ph.nv.ten
                });
            }
            cnn.Close();
            dgvList.ClearSelection();
            Visible = true;
        }

        private void DSPhieu_Load(object sender, EventArgs e)
        {

        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            Phieu ph = ds_ph.Find(item => item.sophieu.ToString() == txtResult.Text);
            if(ph != null)
            {
                if (nk == null)
                {
                    xk.moPhieu(ph);
                }
                else
                {
                    nk.moPhieu(ph);
                }
                Visible = false;
            }
            else
            {
                MessageBox.Show(this, "Số phiếu không hợp lệ", "Lưu ý", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtResult.Text = dgvList.Rows[e.RowIndex].Cells[0].Value.ToString();
        }
    }
}
