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
    public partial class ucNhaCungCap : UserControl
    {
        private const string ADD = "Thêm";
        private const string EDIT = "Sửa";
        private SqlConnection cnn;
        private SqlCommand scm;
        private SqlDataReader reader;
        private string action;
        private List<NhaCungCap> ds_ncc = new List<NhaCungCap>();
        public NhanVien nv;
        public ucNhaCungCap(NhanVien x)
        {
            InitializeComponent();
            nv = x;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            reset();
            if (action == ADD)
            {
                setEnabled(false);
                action = "";
                cbId.Text = "";
            }
            else
            {
                if (ds_ncc.Count > 0)
                {
                    cbId.Text = "" + (ds_ncc[ds_ncc.Count - 1].ma + 1);
                }
                else
                {
                    cbId.Text = "1";
                }
                
                setEnabled(true);
                cbId.Enabled = false;
                action = ADD;
            }
        }

        public void reset()
        {
            if(action == ADD)
            {
                cbId.Text = "" + (ds_ncc[ds_ncc.Count - 1].ma + 1);
            }
            else
            {
                cbId.Text = "";
            }
            txtName.Text = txtAddress.Text = txtPhone.Text = "";
        }

        public void setEnabled(bool status)
        {
            cbId.Enabled = status;
            txtName.Enabled = status;
            txtAddress.Enabled = status;
            txtPhone.Enabled = status;
            btnSave.Enabled = status;
        }

        private void ucNhaCungCap_Load(object sender, EventArgs e)
        {
            dgvSupplier.Rows.Add(new object[]
            {
                "","","",""
            });
            dgvSupplier.Rows.RemoveAt(0);
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
                cbId.Items.Add(ncc.ma);
                ds_ncc.Add(ncc);
                dgvSupplier.Rows.Add(new object[]
                {
                    ncc.ma, ncc.ten, ncc.diachi, ncc.sdt
                });
            }
            dgvSupplier.ClearSelection();
            cnn.Close();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            reset();
            if (action == EDIT)
            {
                setEnabled(false);
                action = "";
            }
            else
            {
                setEnabled(true);
                action = EDIT;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            for (int i = dgvSupplier.SelectedRows.Count - 1; i >= 0; i--)
            {
                int index = dgvSupplier.SelectedRows[i].Index;
                try
                {
                    cnn.Open();
                    scm = new SqlCommand("delete from nhacungcap where mancc = " + ds_ncc[index].ma, cnn);
                    scm.ExecuteNonQuery();
                    cnn.Close();
                    dgvSupplier.Rows.RemoveAt(index);
                    ds_ncc.RemoveAt(index);
                    cbId.Items.RemoveAt(index);
                    dgvSupplier.ClearSelection();
                }
                catch (SqlException er)
                {
                    cnn.Close();
                    DialogResult answer = MessageBox.Show(this,
                        $@"Nguyên liệu <{ds_ncc[index].ten}> có liên quan đến các dữ liệu khác. Bạn có thật sự muốn xoá ?",
                        "Lưu ý",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);
                    if (answer == DialogResult.Yes)
                    {
                        List<int> ds_ma = new List<int>();
                        cnn.Open();
                        scm = new SqlCommand($@"
                                select manl from nguyenlieu where mancc = {ds_ncc[index].ma};", cnn);
                        reader = scm.ExecuteReader();
                        while (reader.Read())
                        {
                            int manl = reader.GetInt32(0);
                            ds_ma.Add(manl);
                        }
                        cnn.Close();
                        ds_ma.ForEach(manl =>
                        {
                            cnn.Open();
                            scm = new SqlCommand($@"
                                delete from chitietphieunhap where manl ={manl};
                                delete from chitietphieuxuat where manl ={manl};
                                delete from nguyenlieu where mancc = {ds_ncc[index].ma};
                                delete from nhacungcap where mancc = {ds_ncc[index].ma};", cnn);
                            scm.ExecuteNonQuery();
                            cnn.Close();
                        });

                        dgvSupplier.Rows.RemoveAt(index);
                        ds_ncc.RemoveAt(index);
                        cbId.Items.RemoveAt(index);
                    }
                    Console.WriteLine(er);
                }
            }
        }
        public NhaCungCap getData()
        {
            NhaCungCap ncc = new NhaCungCap(Convert.ToInt32(cbId.Text), txtName.Text, txtAddress.Text, txtPhone.Text);
            return ncc;
        }
        public void setData(NhaCungCap ncc)
        {
            txtName.Text = ncc.ten;
            txtAddress.Text = ncc.diachi;
            txtPhone.Text = ncc.sdt;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            reset();
        }
        public string validate_ncc(NhaCungCap ncc)
        {
            string error = "";
            if (ncc.ten == "")
            {
                error += "Tên không được để trống\n";
            }
            if (ncc.diachi == "")
            {
                error += "Địa chỉ không được để trống\n";
            }
            if (ncc.sdt.Length != 10)
            {
                error += "Số điện thoại chỉ có 10 chữ số\n";
            }
            return error;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            NhaCungCap ncc = getData();
            if (ncc != null)
            {
                string error = validate_ncc(ncc);
                if (error == "")
                {
                    cnn.Open();
                    if (action == ADD)
                    {
                        scm = new SqlCommand(
                            $@"insert into nhacungcap(mancc, tenncc, diachi, sdt)
                            values ({ncc.ma},N'{ncc.ten}',N'{ncc.diachi}','{ncc.sdt}')
                            ", cnn);
                        ds_ncc.Add(ncc);
                        dgvSupplier.Rows.Add(new object[]
                        {
                           ncc.ma, ncc.ten,ncc.diachi,ncc.sdt
                        });
                        cbId.Items.Add(ncc.ma);
                    }
                    else if (action == EDIT)
                    {
                        scm = new SqlCommand(
                            $@"update nhacungcap set tenncc = N'{ncc.ten}',
                            diachi = N'{ncc.diachi}', sdt = '{ncc.sdt}' where
                            mancc = {ncc.ma}", cnn);
                        int index = ds_ncc.FindIndex(item => item.ma == ncc.ma);
                        dgvSupplier.Rows[index].Cells[1].Value = ncc.ten;
                        dgvSupplier.Rows[index].Cells[2].Value = ncc.diachi;
                        dgvSupplier.Rows[index].Cells[3].Value = ncc.sdt;
                        ds_ncc[index] = ncc;
                    }
                    scm.ExecuteNonQuery();
                    cnn.Close();
                    reset();
                    dgvSupplier.ClearSelection();
                }
                else
                {
                    MessageBox.Show(this, error, "Chú ý", MessageBoxButtons.OK);
                }
            }
        }

        private void cbId_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtPhone.Text.Length == 10) e.Handled = true;
            if (!char.IsDigit(e.KeyChar)) e.Handled = true;
        }

        private void cbId_SelectedIndexChanged(object sender, EventArgs e)
        {
            NhaCungCap ncc = ds_ncc.Find(item => "" + item.ma == cbId.SelectedItem.ToString());
            if (ncc != null)
            {
                setData(ncc);
            }
        }
    }
}
