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
    public partial class ucQuanLyTaiKhoan : UserControl
    {
        private const string ADD = "Thêm";
        private const string EDIT = "Sửa";
        private SqlConnection cnn;
        private SqlCommand scm;
        private SqlDataReader reader;
        private string action = "";
        private int rowIndex = -1;
        private List<NhanVien> ds_nv = new List<NhanVien>();
        private DAO.DAO_NhanVien dao_nv = new DAO.DAO_NhanVien();
        public ucQuanLyTaiKhoan()
        {
            InitializeComponent();
        }

        private void ucQuanLyTaiKhoan_Load(object sender, EventArgs e)
        {
            cnn = new SqlConnection(
                @"Data Source=DESKTOP-NIULDEP\SQLEXPRESS;Initial Catalog=btl_pttkht;User ID=sa;Password=password"
            );
            ds_nv = dao_nv.getAll();
            ds_nv.ForEach(nv =>
            {
                dgvEmployee.Rows.Add(new object[]{
                    nv.ma,
                    nv.ten,
                    nv.ngaysinh.Date.ToString("dd/MM/yyyy"),
                    nv.gioitinh,
                    nv.diachi,
                    nv.sdt,
                    nv.chucvu
                });
                cbId.Items.Add(nv.ma);
            });
            dgvEmployee.ClearSelection();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            reset();
            if(action == ADD)
            {
                setEnabled(false);
                action = "";
                cbId.Text = "";
            }
            else
            {
                if (ds_nv.Count > 0)
                {
                    cbId.Text = "" + (ds_nv[ds_nv.Count - 1].ma + 1);
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

        public void setEnabled(bool status)
        {
            txtName.Enabled = status;
            txtPhone.Enabled = status;
            cbId.Enabled = status;
            cbGender.Enabled = status;
            cbPosition.Enabled = status;
            dateTime.Enabled = status;
            btnSave.Enabled = status;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            reset();
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

        public void reset()
        {
            txtName.Text = "";
            txtPhone.Text = "";
            if(action == ADD)
            {
                if(ds_nv.Count > 0)
                {
                    cbId.Text = "" + (ds_nv[ds_nv.Count - 1].ma + 1);
                }
                else
                {
                    cbId.Text = "1";
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            for (int i = dgvEmployee.SelectedRows.Count - 1; i >= 0; i--)
            {
                int index = dgvEmployee.SelectedRows[i].Index;
                DialogResult answer = MessageBox.Show(
                    this,
                    $@"Các dữ liệu liên quan đến nhân viên <{ds_nv[rowIndex].ten}> sẽ bị xoá. Bạn có chắn chắn xoá không ?",
                    "Xác nhận",
                    MessageBoxButtons.YesNo);
                if (answer == DialogResult.Yes)
                {
                    dao_nv.deleteById(ds_nv[index].ma);
                    ds_nv.RemoveAt(index);
                    dgvEmployee.Rows.RemoveAt(index);
                    cbId.Items.RemoveAt(index);
                    rowIndex = -1;
                    dgvEmployee.ClearSelection();
                }
            }
        }

        public void setData(NhanVien nv)
        {
            cbGender.Text = nv.gioitinh;
            cbPosition.Text = nv.chucvu;
            txtName.Text = nv.ten;
            txtPhone.Text = nv.sdt;
            dateTime.Value = nv.ngaysinh;
        }

        public NhanVien getData()
        {
            string error = "";
            string manv = cbId.Text;
            string ten = txtName.Text;
            DateTime ngaysinh = dateTime.Value;
            string sdt = txtPhone.Text;
            string diachi = txtAddress.Text;
            string chucvu = cbPosition.Text;
            string gioitinh = cbGender.Text;
            if (ten == "")
            {
                error += "Tên không được để trống\n";
            }
            if ((DateTime.Now - ngaysinh).Days <= 18 * 365)
            {
                error += "Tuổi phải từ 18 trở lên\n";
            }
            if (gioitinh == "")
            {
                error += "Chưa chọn giới tính\n";
            }
            if (diachi == "")
            {
                error += "Địa chỉ không được để trống\n";
            }
            if (sdt.Length != 10)
            {
                error += "Số điện thoại chỉ có 10 số\n";
            }
            if (chucvu == "")
            {
                error += "Chưa chọn chức vụ\n";
            }
            if(error == "")
            {
                NhanVien nv = new NhanVien(
                    Convert.ToInt32(manv), 
                    ten,
                    ngaysinh,
                    gioitinh,
                    diachi,
                    sdt,
                    chucvu,
                    "123456"
                );
                return nv;
            }
            return null;
            
        }

        private void cbId_SelectedIndexChanged(object sender, EventArgs e)
        {
            NhanVien nv = ds_nv.Find(item => "" + item.ma == cbId.SelectedItem.ToString());
            if (ds_nv != null)
            {
                setData(nv);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            NhanVien nv = getData();
            if (nv != null)
            {
                
                cnn.Open();
                if (action == ADD)
                {
                    scm = new SqlCommand(
                        $@"insert into nhanvien(manv, tennv, ngaysinh, gioitinh, sdt, chucvu, matkhau, diachi) values
                            ({nv.ma}, N'{nv.ten}','{nv.ngaysinh}', N'{nv.gioitinh}', '{nv.sdt}', N'{nv.chucvu}', '{nv.matkhau}', N'{nv.diachi}'),", cnn);
                    dgvEmployee.Rows.Add(new object[]{
                        nv.ma,
                        nv.ten,
                        nv.ngaysinh.Date.ToString("dd/MM/yyyy"),
                        nv.gioitinh,
                        nv.diachi,
                        nv.sdt,
                        nv.chucvu
                    });
                    ds_nv.Add(nv);
                    cbId.Items.Add(nv.ma);
                }
                else if (action == EDIT)
                {
                    scm = new SqlCommand(
                        $@"update nhanvien set 
                        tennv = N'{nv.ten}', 
                        ngaysinh = '{nv.ngaysinh}', 
                        gioitinh = N'{nv.gioitinh}', 
                        diachi = N'{nv.diachi}', 
                        sdt ='{nv.sdt}',
                        chucvu =N'{nv.chucvu}',
                        matkhau='{nv.matkhau}'
                        where manv ={nv.ma}", cnn);
                    int index = ds_nv.FindIndex(item => item.ma == nv.ma);
                    ds_nv[index] = nv;
                    dgvEmployee.Rows[index].Cells[1].Value = nv.ten;
                    dgvEmployee.Rows[index].Cells[2].Value = nv.ngaysinh.Date.ToString("dd/MM/yyyy");
                    dgvEmployee.Rows[index].Cells[3].Value = nv.gioitinh;
                    dgvEmployee.Rows[index].Cells[4].Value = nv.diachi;
                    dgvEmployee.Rows[index].Cells[5].Value = nv.sdt;
                    dgvEmployee.Rows[index].Cells[6].Value = nv.chucvu;
                }
                scm.ExecuteNonQuery();
                cnn.Close();
                dgvEmployee.ClearSelection();
                reset();
                
            }
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar)) e.Handled = true;
            if (txtPhone.Text.Length > 10) e.Handled = true;
            if (e.KeyChar == (char)8) e.Handled = false;
        }

        private void cbPermission_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cbPosition_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cbGender_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cbId_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }
    }
}
