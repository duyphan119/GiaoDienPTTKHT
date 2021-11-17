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
    public partial class ucNguyenLieu : UserControl
    {
        private const string EDIT = "Sửa";
        private const string ADD = "Thêm";
        private SqlConnection cnn;
        private SqlCommand scm;
        private SqlDataReader reader;
        private string action;
        private List<NhaCungCap> ds_ncc = new List<NhaCungCap>();
        private List<NguyenLieu> ds_nl = new List<NguyenLieu>();
        private List<Phieu> ds_ph = new List<Phieu>();
        private List<int> ds_tonkho = new List<int>();
        private Phieu phieu = new Phieu();
        private NhanVien nv;
        public ucNguyenLieu(NhanVien x)
        {
            InitializeComponent();
            nv = x;
        }

        private void ucNguyenLieu_Load(object sender, EventArgs e)
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
                dgvProduct.Rows.Add(new object[]
                {
                    nl.ncc.ten, nl.ma, nl.ten, nl.dvt, 0, nl.gia
                });
                int index = cbUnit.Items.IndexOf(nl.dvt); 
                if (index == -1)
                {
                    cbUnit.Items.Add(nl.dvt);
                }
                cbId.Items.Add(nl.ma);
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
                    dgvProduct.Rows[i].Cells[4].Value = reader.GetInt32(0);
                }
                cnn.Close();
            }
            dgvProduct.ClearSelection();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            reset();
            if (action == EDIT)
            {
                cbId.Enabled = false;
                action = "";
                cbId.Text = "";
            }
            else
            {
                action = EDIT;
                cbId.Enabled = true;
            }
            setEnabled(false);
        }

        public void setEnabled(bool status)
        {
            txtName.Enabled = status;
            cbUnit.Enabled = status;
            txtPrice.Enabled = status;
            cbSupplier.Enabled = status;
        }

        private void cbId_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(action == EDIT && cbId.SelectedIndex != -1)
            {
                setEnabled(true);
                int index = ds_nl.FindIndex(item => item.ma == Convert.ToInt32(cbId.SelectedItem));
                setData(ds_nl[index], ds_tonkho[index]);
            }
            else
            {
                reset();
            }
        }
        public void setData(NguyenLieu ngl, int sl)
        {
            cbSupplier.Text = ngl.ncc.ten;
            txtName.Text = ngl.ten;
            cbUnit.Text = ngl.dvt;
            txtInventory.Text = "" + sl;
            txtPrice.Text = "" + ngl.gia;
        }
        public void reset()
        {
            cbId.SelectedIndex = -1;
            txtName.Text = txtPrice.Text = txtInventory.Text = cbSupplier.Text = cbUnit.Text = "";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            reset();
        }

        public NguyenLieu getData()
        {
            string error = "";
            if (cbSupplier.Text == "")
            {
                error += "Nhà cung cấp không được để trống\n";
            }
            if (txtName.Text == "")
            {
                error += "Tên không được để trống\n";
            }
            if (cbUnit.Text == "")
            {
                error += "Đơn vị tính không được để trống\n";
            }
            if (txtPrice.Text == "")
            {
                error += "Giá tiền không được để trống\n";
            }
            else
            {
                txtPrice.Text = "" + Convert.ToInt32(txtPrice.Text);
            }
            if (error == "")
            {
                return new NguyenLieu(
                    Convert.ToInt32(cbId.Text),
                    Convert.ToInt32(txtPrice.Text),
                    txtName.Text,
                    cbUnit.Text,
                    ds_ncc[cbSupplier.SelectedIndex]
                );
            }
            MessageBox.Show(this, error, "Lưu ý", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            return null;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            NguyenLieu nl = getData();
            if(nl != null)
            {
                if(action == EDIT)
                {
                    cnn.Open();
                    scm = new SqlCommand($@"update nguyenlieu set tennl = N'{nl.ten}', 
                    giatien = {nl.gia}, dvt = N'{nl.dvt}', mancc = {nl.ncc.ma} where manl = {nl.ma}", cnn);
                    scm.ExecuteNonQuery();
                    cnn.Close();
                    int index = ds_nl.FindIndex(item => item.ma == Convert.ToInt32(cbId.SelectedItem));
                    ds_nl[index] = nl;
                    dgvProduct.Rows[index].Cells[0].Value = nl.ncc.ten;
                    dgvProduct.Rows[index].Cells[1].Value = nl.ma;
                    dgvProduct.Rows[index].Cells[2].Value = nl.ten;
                    dgvProduct.Rows[index].Cells[3].Value = nl.dvt;
                    dgvProduct.Rows[index].Cells[5].Value = nl.gia;
                    reset();
                }
                else if(action == ADD)
                {
                    cnn.Open();
                    scm = new SqlCommand(
                        $@"insert into nguyenlieu(manl, tennl, dvt, giatien, mancc)
                            values ({nl.ma},N'{nl.ten}',N'{nl.dvt}',{nl.gia},{nl.ncc.ma})", cnn);
                    scm.ExecuteNonQuery();
                    cnn.Close();
                    ds_nl.Add(nl);
                    ds_tonkho.Add(0);
                    dgvProduct.Rows.Add(new object[]
                    {
                        nl.ncc.ten, nl.ma, nl.ten, nl.dvt, 0, nl.gia
                    });
                    reset();
                    cbId.Text = "" + (ds_nl[ds_nl.Count - 1].ma + 1);
                }
                dgvProduct.ClearSelection();
            }
        }

        private void dgvProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            reset();
            if (action == ADD)
            {
                action = "";
                setEnabled(false);
                cbId.Text = "";
            }
            else
            {
                if(ds_nl.Count > 0)
                {
                    cbId.Text = "" + (ds_nl[ds_nl.Count - 1].ma + 1);
                }
                else
                {
                    cbId.Text = "1";
                }
                cbId.Enabled = false;
                setEnabled(true);
                action = ADD;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
           
            for (int i = dgvProduct.SelectedRows.Count - 1; i >= 0; i--)
            {
                int index = dgvProduct.SelectedRows[i].Index;
                try
                {
                    cnn.Open();
                    scm = new SqlCommand($"delete from nguyenlieu where manl = {ds_nl[index].ma}", cnn);
                    scm.ExecuteNonQuery();
                    cnn.Close();
                    dgvProduct.Rows.RemoveAt(index);
                    ds_nl.RemoveAt(index);
                    cbId.Items.RemoveAt(index);
                    ds_tonkho.RemoveAt(index);
                }
                catch (SqlException er)
                {
                    cnn.Close();
                    DialogResult answer = MessageBox.Show(this, 
                        $@"Nguyên liệu <{ds_nl[index].ten}> có liên quan đến các dữ liệu khác. Bạn có thật sự muốn xoá ?",
                        "Lưu ý", 
                        MessageBoxButtons.YesNo, 
                        MessageBoxIcon.Stop);
                    if(answer == DialogResult.Yes)
                    {
                        cnn.Open();
                        scm = new SqlCommand($@"delete from chitietphieunhap where manl = {ds_nl[index].ma};
                            delete from chitietphieuxuat where manl = {ds_nl[index].ma};
                            delete from nguyenlieu where manl = {ds_nl[index].ma}", cnn);
                        scm.ExecuteNonQuery();
                        cnn.Close();
                        dgvProduct.Rows.RemoveAt(index);
                        ds_nl.RemoveAt(index);
                        cbId.Items.RemoveAt(index);
                        ds_tonkho.RemoveAt(index);
                    }
                    Console.WriteLine(er);
                }
            }
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar)) e.Handled = true;
            if(e.KeyChar == (char)8) e.Handled = false;
        }

        private void cbSupplier_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cbId_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
