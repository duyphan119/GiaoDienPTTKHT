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
        public ucQuanLyTaiKhoan()
        {
            InitializeComponent();
        }

        private void ucQuanLyTaiKhoan_Load(object sender, EventArgs e)
        {
            cnn = new SqlConnection(
                @"Data Source=DESKTOP-NIULDEP\SQLEXPRESS;Initial Catalog=btl_pttkht;User ID=sa;Password=password"
            );
            cnn.Open();
            scm = new SqlCommand("select * from nhanvien", cnn);
            reader = scm.ExecuteReader();
            while(reader.Read()){
                int manv = reader.GetInt32(0);
                string tennv = reader.GetString(1);
                DateTime ngaysinh = reader.GetDateTime(7);
                string gioitinh = reader.GetString(2);
                string sdt = reader.GetString(3);
                string chucvu = reader.GetString(4);
                string quyen = reader.GetString(6);
                string matkhau = reader.GetString(5);
                dgvEmployee.Rows.Add(new object[]{
                    manv,
                    tennv,
                    ngaysinh.Date.ToString("dd/MM/yyyy"),
                    gioitinh,
                    sdt,
                    chucvu,
                    quyen,
                    matkhau
                });
                NhanVien nv = new NhanVien(
                    tennv, ngaysinh, gioitinh, manv, sdt, chucvu, quyen, matkhau
                );
                cbId.Items.Add(manv);
                ds_nv.Add(nv);
            }
            cnn.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(action == ADD)
            {
                setEnabled(false);
                reset();
                action = "";
            }
            else if(action == EDIT)
            {
                MessageBox.Show("Đang sửa");
            }
            else
            {
                cbId.Text = "" + (ds_nv.Count + 1);
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
            cbPermission.Enabled = status;
            cbPosition.Enabled = status;
            dateTime.Enabled = status;
            txtPassword.Enabled = status;
            btnSave.Enabled = status;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (action == EDIT)
            {
                setEnabled(false);
                reset();
                action = "";
            }
            else if (action == ADD)
            {
               MessageBox.Show(this,"Đang thêm","Chú ý",MessageBoxButtons.YesNoCancel);
            }
            else
            {
                setEnabled(true);
                action = EDIT;
            }
        }

        public void reset()
        {
            cbId.Text = "Mã Nhân Viên";
            cbGender.Text = "Giới Tính";
            cbPermission.Text = "Quyền";
            cbPosition.Text = "Chức Vụ";
            txtName.Text = "";
            txtPhone.Text = "";
            txtPassword.Text = "";
        }

        private void dgvEmployee_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0 && e.RowIndex<dgvEmployee.Rows.Count - 1)
            {
                rowIndex = e.RowIndex;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(rowIndex != -1)
            {
                try
                {
                    cnn.Open();
                    scm = new SqlCommand("delete from nhanvien where manv = " + ds_nv[rowIndex].ma, cnn);
                    scm.ExecuteNonQuery();
                    cnn.Close();
                    ds_nv.RemoveAt(rowIndex);
                    dgvEmployee.Rows.RemoveAt(rowIndex);
                    rowIndex = -1;
                }
                catch (SqlException err)
                {
                    Console.WriteLine(err);
                    MessageBox.Show(this, "Xoá không thành công", "Chú ý", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show(this, "Chưa chọn nhân viên", "Chú ý", MessageBoxButtons.OK);
            }
        }

        public void setData(NhanVien nv)
        {
            cbGender.Text = nv.gioitinh;
            cbPermission.Text = nv.quyen;
            cbPosition.Text = nv.chucvu;
            txtName.Text = nv.ten;
            txtPhone.Text = nv.sdt;
            txtPassword.Text = nv.matkhau;
            dateTime.Value = nv.ngaysinh;
        }

        public NhanVien getData()
        {
            try
            {
                NhanVien nv = new NhanVien(
                txtName.Text,
                dateTime.Value,
                cbGender.Text,
                Convert.ToInt32(cbId.Text),
                txtPhone.Text,
                cbPosition.Text,
                cbPermission.Text,
                txtPassword.Text
            );
                return nv;
            }
            catch (FormatException err)
            {
                MessageBox.Show(this, "Mã Nhân Viên Không Hợp Lệ", "Chú ý", MessageBoxButtons.OK);
                return null;
            }
            
        }

        public string validate_nv(NhanVien nv)
        {
            string error = "";
            if(nv.ten == "")
            {
                error += "Tên không được để trống\n";
            }
            if(nv.gioitinh == "Giới Tính")
            {
                error += "Chưa chọn giới tính\n";
            }
            if (nv.quyen == "Quyền")
            {
                error += "Chưa chọn quyền\n";
            }
            if (nv.chucvu == "Chức Vụ")
            {
                error += "Chưa chọn chức vụ\n";
            }
            if (nv.matkhau == "")
            {
                error += "Mật khẩu không được để trống\n";
            }
            if (nv.sdt.Length!=10)
            {
                error += "Số điện thoại chỉ có 10 số\n";
            }
            if ((DateTime.Now - nv.ngaysinh).Days <= 18*365)
            {
                error += "Tuổi phải từ 18 trở lên\n";
            }
            return error;
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
                string error = validate_nv(nv);
                if (error == "")
                {
                    cnn.Open();
                    if (action == ADD)
                    {
                        scm = new SqlCommand(
                            "insert into nhanvien" +
                            "(manv, tennv, ngaysinh, gioitinh, sdt, chucvu, matkhau, quyen) " +
                            "values(" +
                                nv.ma + ", " +
                                "N'" + nv.ten + "', " +
                                "'" + nv.ngaysinh + "', " +
                                "N'" + nv.gioitinh + "', " +
                                "'" + nv.sdt + "', " +
                                "N'" + nv.chucvu + "', " +
                                "'" + nv.matkhau + "', " +
                                "'" + nv.quyen + "')", cnn);
                        dgvEmployee.Rows.Add(new object[]{
                        nv.ma,
                        nv.ten,
                        nv.ngaysinh.Date.ToString("dd/MM/yyyy"),
                        nv.gioitinh,
                        nv.sdt,
                        nv.chucvu,
                        nv.quyen,
                        nv.matkhau
                    });
                        ds_nv.Add(nv);
                    }
                    else if (action == EDIT)
                    {
                        scm = new SqlCommand(
                            "update nhanvien set " +
                            "tennv = N'" + nv.ten + "'," +
                            "gioitinh=N'" + nv.gioitinh + "', " +
                            "ngaysinh='" + nv.ngaysinh + "', " +
                            "sdt='" + nv.sdt + "', " +
                            "chucvu=N'" + nv.chucvu + "', " +
                            "matkhau='" + nv.matkhau + "', " +
                            "quyen='" + nv.quyen + "' where " +
                            "manv = " + nv.ma, cnn);
                        int index = ds_nv.FindIndex(item => item.ma == nv.ma);
                        ds_nv[index] = nv;
                        dgvEmployee.Rows[index].Cells[1].Value = nv.ten;
                        dgvEmployee.Rows[index].Cells[2].Value = nv.ngaysinh;
                        dgvEmployee.Rows[index].Cells[3].Value = nv.gioitinh;
                        dgvEmployee.Rows[index].Cells[4].Value = nv.sdt;
                        dgvEmployee.Rows[index].Cells[5].Value = nv.chucvu;
                        dgvEmployee.Rows[index].Cells[6].Value = nv.quyen;
                        dgvEmployee.Rows[index].Cells[7].Value = nv.matkhau;
                    }
                    scm.ExecuteNonQuery();
                    cnn.Close();
                    setEnabled(false);
                    reset();
                    action = "";
                }
                else
                {
                    MessageBox.Show(this, error, "Chú ý", MessageBoxButtons.OK);
                }
            }
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar)) e.Handled = true;
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
    }
}
