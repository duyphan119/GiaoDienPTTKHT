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
    public partial class ucQuanLyBan : UserControl
    {
        private const string ADD = "Thêm";
        private const string EDIT = "Sửa";
        private SqlConnection cnn;
        private SqlCommand scm;
        private SqlDataReader reader;
        private List<Ban> ds_ban = new List<Ban>();
        private string action;
        public ucQuanLyBan()
        {
            InitializeComponent();
            dgvTable.Rows.Add(new object[]
            {
                   "",""
            });
            dgvTable.Rows.RemoveAt(0);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Ban ban = getData();
            if (ban != null)
            {
                cnn.Open();
                if (action == ADD)
                {
                    scm = new SqlCommand(
                        "insert into ban (soban, trangthai) " +
                        "values(" +
                            ban.soban + ", " +
                            "N'" + ban.trangthai + "')", cnn);
                    ds_ban.Add(ban);
                    dgvTable.Rows.Add(new object[]
                    {
                        ban.soban.ToString(), (ban.trangthai==true)?"Trống":"Có Khách"
                    });
                    cbId.Items.Add(ban.soban);
                }
                else if (action == EDIT)
                {
                    scm = new SqlCommand(
                        "update ban set " +
                        "trangthai = " + ((ban.trangthai == true) ? 1 : 0) +
                        " where " +
                        "soban = " + ban.soban, cnn);
                    int index = ds_ban.FindIndex(item => item.soban == ban.soban);
                    dgvTable.Rows[index].Cells[1].Value = (ban.trangthai == true) ? "Trống" : "Có Khách";
                    ds_ban[index] = ban;
                }
                scm.ExecuteNonQuery();
                cnn.Close();
                reset();
                dgvTable.ClearSelection();
            }
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
                if (ds_ban.Count > 0)
                {
                    cbId.Text = "" + (ds_ban[ds_ban.Count - 1].soban + 1);
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
            cbId.Text = "";
            cbStatus.Text = "";
            if(action == ADD)
            {
                cbId.Text = "" + (ds_ban[ds_ban.Count - 1].soban + 1);
            }
        }
        public void setEnabled(bool status)
        {
            cbId.Enabled = status;
            cbStatus.Enabled = status;
            btnSave.Enabled = status;
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

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void cbId_SelectedIndexChanged(object sender, EventArgs e)
        {
            Ban ban = ds_ban.Find(item => "" + item.soban == cbId.SelectedItem.ToString());
            if (ban != null)
            {
                setData(ban);
            }
        }
        public void setData(Ban ban)
        {
            cbStatus.SelectedIndex = ((ban.trangthai == true) ? 0 : 1);
        }
        private void ucQuanLyBan_Load(object sender, EventArgs e)
        {
            cnn = new SqlConnection(
                @"Data Source=DESKTOP-NIULDEP\SQLEXPRESS;Initial Catalog=btl_pttkht;User ID=sa;Password=password"
            );
            cbSearch.SelectedIndex = 2;
            cbId.Text = "Số Bàn";
            cnn.Open();
            scm = new SqlCommand("select * from ban", cnn);
            reader = scm.ExecuteReader();
            dgvTable.Rows.Clear();
            ds_ban.Clear();
            cbId.Items.Clear();
            while (reader.Read())
            {
                int soban = reader.GetInt32(0);
                bool trangthai = reader.GetBoolean(1);
                Ban ban = new Ban(soban, trangthai);
                cbId.Items.Add(ban.soban);
                ds_ban.Add(ban);
                dgvTable.Rows.Add(new object[]
                {
                    ban.soban.ToString(), (ban.trangthai==true)?"Trống":"Có Khách"
                });
            }
            cnn.Close();
            dgvTable.ClearSelection();
        }
        public Ban getData()
        {
            try
            {
                bool status = cbStatus.SelectedIndex == 0 ? true : false;
                Ban ban = new Ban(Convert.ToInt32(cbId.Text), status);
                return ban;
            }
            catch (FormatException err)
            {
                Console.WriteLine(err);
                MessageBox.Show(this, "Số bàn Không Hợp Lệ", "Chú ý", MessageBoxButtons.OK);
                return null;
            }
        }

        private void cbSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            cnn.Open();
            if(1 - cbSearch.SelectedIndex<=1&& 1 - cbSearch.SelectedIndex >= 0)
            {
                scm = new SqlCommand("select * from ban where trangthai = "+(1 - cbSearch.SelectedIndex), cnn);
            }
            else
            {
                scm = new SqlCommand("select * from ban", cnn);
            }
            reader = scm.ExecuteReader();
            dgvTable.Rows.Clear();
            cbId.Items.Clear();
            ds_ban.Clear();
            while (reader.Read())
            {
                int soban = reader.GetInt32(0);
                bool trangthai = reader.GetBoolean(1);
                Ban ban = new Ban(soban, trangthai);
                cbId.Items.Add(ban.soban);
                ds_ban.Add(ban);
                dgvTable.Rows.Add(new object[]
                {
                    ban.soban.ToString(), (ban.trangthai==true)?"Trống":"Có Khách"
                });
            }
            dgvTable.ClearSelection();
            cnn.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = dgvTable.SelectedRows.Count - 1; i >= 0; i--)
                {
                    int index = dgvTable.SelectedRows[i].Index;
                    DialogResult answer = MessageBox.Show(this, 
                        $@"Dữ liệu liên quan đến bàn <{ds_ban[index].soban}> cũng sẽ bị xoá. Bạn có chắc chắn xoá không ?", 
                        "Xác nhận", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    if (answer == DialogResult.Yes)
                    {
                        cnn.Open();
                        scm = new SqlCommand($"delete from ban where soban = {ds_ban[index].soban}", cnn);
                        scm.ExecuteNonQuery();
                        cnn.Close();
                        dgvTable.Rows.RemoveAt(index);
                        ds_ban.RemoveAt(index);
                        cbId.Items.RemoveAt(index);
                    }
                }
                dgvTable.ClearSelection();
            }
            catch (SqlException er)
            {
                cnn.Close();
                MessageBox.Show(this, "Xoá không thành công", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                Console.WriteLine(er);
            }
        }

        private void cbId_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cbStatus_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cbSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
