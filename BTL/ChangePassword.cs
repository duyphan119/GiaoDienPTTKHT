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
    public partial class ChangePassword : MetroForm
    {
        private NhanVien nv;
        public ChangePassword(NhanVien x)
        {
            InitializeComponent();
            nv = x;
        }

        private void ChangePassword_Load(object sender, EventArgs e)
        {
            
        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            if (txtOldPassword.Text == nv.matkhau)
            {
                if(txtNewPassword.Text == txtConfirmNewPassword.Text)
                {
                    SqlConnection cnn = new SqlConnection(
                        @"Data Source=DESKTOP-NIULDEP\SQLEXPRESS;Initial Catalog=btl_pttkht;User ID=sa;Password=password"
                    );
                    cnn.Open();
                    SqlCommand scm = new SqlCommand(
                        $@"update nhanvien set 
                        matkhau='{txtNewPassword.Text}' 
                        where manv = {nv.ma}", cnn);
                    scm.ExecuteNonQuery();
                    cnn.Close();
                    MessageBox.Show("Đổi mật khẩu thành công");
                }
                else
                {
                    MessageBox.Show(this, "Nhập lại mật khẩu không chính xác", "Lưu ý", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            else
            {
                MessageBox.Show(this, "Mật khẩu hiện tại không chính xác", "Lưu ý", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
    }
}
