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
using BTL.Model;
using MetroFramework.Forms;

namespace BTL
{
    public partial class DangNhap : MetroForm
    {
        private SqlConnection cnn;
        private SqlCommand scm;
        private SqlDataReader reader;
        public DangNhap()
        {
            InitializeComponent();
        }

        private void DangNhap_Load(object sender, EventArgs e)
        {
            cnn = new SqlConnection(
                @"Data Source=DESKTOP-NIULDEP\SQLEXPRESS;Initial Catalog=btl_pttkht;User ID=sa;Password=password"
            );
            
        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            try
            {
                cnn.Open();
                // scm = new SqlCommand("select * from nhanvien where manv = " + Convert.ToInt32(txtID.Text) + " and matkhau = '" + txtPassword.Text + "'", cnn);
                scm = new SqlCommand("select * from nhanvien where manv = 1 and matkhau = '123456'", cnn);
                reader = scm.ExecuteReader();
                if (reader.Read())
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
                    new TrangChu(nv).Visible = true;
                    Visible = false;
                }
                else
                {
                    MessageBox.Show("Sai mật khẩu");
                }
                cnn.Close();
            }
            catch(FormatException err)
            {
                Console.WriteLine(err);
                MessageBox.Show("Sai mật khẩu");
                cnn.Close();
            }
        }

        private void txtID_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtPassword.Text == "")
            {
                txtPassword.Text = "Mật khẩu";
            }
            if(txtID.Text == "Mã nhân viên")
            {
                txtID.Text = "";
            }
        }

        private void txtPassword_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtID.Text == "")
            {
                txtID.Text = "Mã nhân viên";
            }
            if(txtPassword.Text == "Mật khẩu")
            {
                txtPassword.Text = "";
            }
        }
    }
}
