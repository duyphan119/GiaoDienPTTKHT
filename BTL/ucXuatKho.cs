using BTL.Model;
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
    public partial class ucXuatKho : UserControl
    {
        private const string ADD = "Thêm";
        private SqlConnection cnn;
        private SqlCommand scm;
        private SqlDataReader reader;
        private string action = "";
        private List<NhaCungCap> ds_ncc = new List<NhaCungCap>();
        private List<NguyenLieu> ds_nl = new List<NguyenLieu>();
        private List<Phieu> ds_ph = new List<Phieu>();
        private List<int> ds_tonkho = new List<int>();
        private Phieu phieu = new Phieu();
        public NhanVien nv;
        public ucXuatKho(NhanVien x)
        {
            InitializeComponent();
            nv = x;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            groupDetail.Enabled = !groupDetail.Enabled;
            if(groupDetail.Enabled == true)
            {
                if(ds_ph.Count >0)
                {
                    txtId.Text = (ds_ph[ds_ph.Count - 1].sophieu+1).ToString();
                    btnExport.Enabled = true;
                    phieu.sophieu = ds_ph[ds_ph.Count - 1].sophieu + 1;
                }
                else
                {
                    txtId.Text = "1";
                }
            }
            else
            {
                txtId.Text = "";
            }
        }
        public void reset()
        {
            cbId.Text = txtName.Text = cbUnit.Text = txtPrice.Text = "";
            nudQuantity.Value = 0;
        }

        public void setEnabled(bool status)
        {
            cbId.Enabled = status;
            nudQuantity.Enabled = status;
        }
        public void setData(int manl, int soluong, int index)
        {
            cnn.Open();
            scm = new SqlCommand($"select * from nguyenlieu where manl = {manl}", cnn);
            reader = scm.ExecuteReader();
            while (reader.Read())
            {
                int ma = reader.GetInt32(0);
                string ten = reader.GetString(1);
                int giatien = reader.GetInt32(2);
                string dvt = reader.GetString(3);
                NhaCungCap ncc = ds_ncc.Find(item => item.ma == reader.GetInt32(4));
                NguyenLieu nl = new NguyenLieu(ma, giatien, ten, dvt, ncc);
                txtName.Text = nl.ten;
                txtPrice.Text = nl.gia.ToString();
                nudQuantity.Maximum = soluong;
                nudQuantity.Value = 0;
                cbUnit.Text = nl.dvt;
                ds_nl[index] = nl;
            }
            cnn.Close();

            
        }

        private void ucXuatKho_Load(object sender, EventArgs e)
        {
            cnn = new SqlConnection(
                @"Data Source=DESKTOP-NIULDEP\SQLEXPRESS;Initial Catalog=btl_pttkht;User ID=sa;Password=password"
            );
            cnn.Open();
            scm = new SqlCommand("select * from nhacungcap", cnn);
            reader = scm.ExecuteReader();
            while (reader.Read())
            {
                int ma = reader.GetInt32(0);
                string ten = reader.GetString(1);
                string dc = reader.GetString(2);
                string sdt = reader.GetString(3);
                NhaCungCap ncc = new NhaCungCap(ma, ten, dc, sdt);
                cbSupplier.Items.Add(ncc.ten);
                ds_ncc.Add(ncc);
            }
            cnn.Close();
            cnn.Open();
            scm = new SqlCommand("select * from nguyenlieu", cnn);
            reader = scm.ExecuteReader();
            while (reader.Read())
            {
                int ma = reader.GetInt32(0);
                string ten = reader.GetString(1);
                int giatien = reader.GetInt32(2);
                string dvt = reader.GetString(3);
                NhaCungCap ncc = ds_ncc.Find(item => item.ma == reader.GetInt32(4));
                NguyenLieu nl = new NguyenLieu(ma, giatien, ten, dvt, ncc);
                ds_nl.Add(nl);
            }
            cnn.Close();
            for (int i = 0; i < ds_nl.Count; i++)
            {
                cnn.Open();
                scm = new SqlCommand($"execute sp_TonKhoCuaNguyenLieu {ds_nl[i].ma}", cnn);
                reader = scm.ExecuteReader();
                while (reader.Read())
                {
                    ds_tonkho.Add(reader.GetInt32(0));
                    //dgvProduct.Rows[i].Cells[4].Value = reader.GetInt32(0);
                }
                cnn.Close();
            }
            cnn.Open();
            scm = new SqlCommand("select * from phieuxuat", cnn);
            reader = scm.ExecuteReader();
            while (reader.Read())
            {
                int ma = reader.GetInt32(0);
                DateTime ngaynhap = reader.GetDateTime(1);
                Phieu ph = new Phieu(ma, ngaynhap, null, new List<ChiTietPhieu>());
                ds_ph.Add(ph);
            }
            cnn.Close();
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            reset();
            if (action == ADD)
            {
                cbSupplier.Text = action = "";
            }
            else
            {
                action = ADD;
            }
            cbSupplier.Enabled = !cbSupplier.Enabled;
            setEnabled(false);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void cbSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSupplier.SelectedIndex != -1)
            {
                setEnabled(true);
                cbId.Items.Clear();
                cnn.Open();
                scm = new SqlCommand($@"select * from nguyenlieu 
                    where mancc = {ds_ncc[cbSupplier.SelectedIndex].ma}", cnn);
                reader = scm.ExecuteReader();
                while (reader.Read())
                {
                    cbId.Items.Add(reader.GetInt32(0));
                }
                cnn.Close();
            }
        }
        public NguyenLieu getData()
        {
            NguyenLieu ncc = new NguyenLieu(
            Convert.ToInt32(cbId.Text),
            Convert.ToInt32(txtPrice.Text),
            txtName.Text,
            cbUnit.Text,
            ds_ncc[cbSupplier.SelectedIndex]);
            return ncc;

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            NguyenLieu nl = getData();
            int soluong = Convert.ToInt32(nudQuantity.Value);
            if (action == ADD && soluong > 0)
            {
                int index = ds_nl.FindIndex(item => "" + item.ma == cbId.SelectedItem.ToString());
                int index2 = phieu.list.FindIndex(item => "" + item.nl.ma == cbId.SelectedItem.ToString());
                if(index2 != -1)
                {
                    phieu.list[index2].soluong += soluong;
                    dgvProduct.Rows[index2].Cells[3].Value = phieu.list[index2].soluong;
                }
                else
                {
                    phieu.list.Add(new ChiTietPhieu(nl, soluong));
                    dgvProduct.Rows.Add(new object[]
                    {
                     nl.ma, nl.ten, nl.dvt, soluong, nl.gia.ToString("#,##")
                    });
                }
                ds_tonkho[index] -= soluong;
                btnSave.Enabled = false;
                dgvProduct.ClearSelection();
                reset();
            }
            else if(soluong <= 0)
            {
                MessageBox.Show(this, "Số lượng xuất phải > 0", "Lưu ý", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void dgvProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnDelete.Enabled = true;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            btnExport.Enabled = false;
            cbSupplier.Enabled = groupDetail.Enabled = !groupDetail.Enabled;
            cbSupplier.Text = "";
            setEnabled(!cbSupplier.Enabled);
            cnn.Open();
            scm = new SqlCommand($@"insert into phieuxuat(sopx, ngayxuat, manv)
                 values ({phieu.sophieu},getdate(),{nv.ma})
                ", cnn);
            scm.ExecuteNonQuery();
            cnn.Close();
            phieu.list.ForEach(item =>
            {
                cnn.Open();
                scm = new SqlCommand($@"insert into chitietphieuxuat(sopx, manl, soluong)
                         values ({phieu.sophieu},{item.nl.ma},{item.soluong})
                        ", cnn);
                scm.ExecuteNonQuery();
                cnn.Close();
            });
            dgvProduct.Rows.Clear();
            phieu.ngay = DateTime.Now;
            new Report(null).phieuXuat(phieu);
            ds_ph.Add(phieu);
            action = "";
            phieu = new Phieu();
        }

        private void cbId_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = ds_nl.FindIndex(item => item.ma == ds_nl[cbId.SelectedIndex].ma);
            if (action == ADD && index != -1)
            {
                setData(ds_nl[index].ma, ds_tonkho[index], index);
                btnSave.Enabled = true;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            for (int i = dgvProduct.SelectedRows.Count - 1; i >= 0; i--)
            {
                int index = dgvProduct.SelectedRows[i].Index;
                int index2 = ds_nl.FindIndex(item => item.ma == Convert.ToInt32(dgvProduct.Rows[index].Cells[0].Value));
                ds_tonkho[index2] += Convert.ToInt32(dgvProduct.Rows[index].Cells[3].Value);
                dgvProduct.Rows.RemoveAt(index);
                phieu.list.RemoveAt(index);
            }
        }

        private void cbUnit_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
