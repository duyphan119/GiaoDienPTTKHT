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
        private DAO.DAO_NhanVien dao_nv = new DAO.DAO_NhanVien();
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
                NhanVien nv = dao_nv.login(5, "123456");
                if (nv != null)
                {
                    new TrangChu(nv).Visible = true;
                    Visible = false;
                }
                else
                {
                    MessageBox.Show(this,"Mã nhân viên hoặc mật khẩu không chính xác","Lưu ý",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                }
            }
            catch(SqlException err)
            {
                Console.WriteLine(err);
                cnn.Close();
                MessageBox.Show(this, "Mã nhân viên hoặc mật khẩu không chính xác", "Lưu ý", MessageBoxButtons.OK, MessageBoxIcon.Stop);
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
