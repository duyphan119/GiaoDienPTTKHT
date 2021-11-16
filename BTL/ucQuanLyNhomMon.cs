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
    public partial class ucQuanLyNhomMon : UserControl
    {
        private const string ADD = "Thêm";
        private const string EDIT = "Sửa";
        private SqlConnection cnn;
        private SqlCommand scm;
        private SqlDataReader reader;
        private List<NhomMon> ds_nhom = new List<NhomMon>();
        private string action;
        private List<int> rowIndexs = new List<int>();
        public ucQuanLyNhomMon()
        {
            InitializeComponent();
        }

        private void ucQuanLyNhomMon_Load(object sender, EventArgs e)
        {
            cnn = new SqlConnection(
                @"Data Source=DESKTOP-NIULDEP\SQLEXPRESS;Initial Catalog=btl_pttkht;User ID=sa;Password=password"
            );
            cnn.Open();
            scm = new SqlCommand("select * from nhommon", cnn);
            reader = scm.ExecuteReader();
            while (reader.Read())
            {
                int manhom = reader.GetInt32(0);
                string tennhom = reader.GetString(1);
                NhomMon nhom = new NhomMon(manhom, tennhom);
                cbId.Items.Add(nhom.ma);
                ds_nhom.Add(nhom);
                dgvGroup.Rows.Add(new object[]
                {
                    nhom.ma, nhom.ten
                });
            }
            cnn.Close();
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
                if (ds_nhom.Count > 0)
                {
                    cbId.Text = "" + (ds_nhom[ds_nhom.Count - 1].ma + 1);
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
                cbId.Text = "" + (ds_nhom[ds_nhom.Count-1].ma + 1);
            }
            else
            {
                cbId.Text = "";
            }
            txtName.Text = "";
        }
        public void setEnabled(bool status)
        {
            cbId.Enabled = status;
            txtName.Enabled = status;
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = dgvGroup.SelectedRows.Count - 1; i >= 0; i--)
                {
                    int index = dgvGroup.SelectedRows[i].Index;
                    cnn.Open();
                    scm = new SqlCommand("delete from nhommon where manhom = " + ds_nhom[index].ma, cnn);
                    scm.ExecuteNonQuery();
                    cnn.Close();
                    dgvGroup.Rows.RemoveAt(index);
                    ds_nhom.RemoveAt(index);
                    cbId.Items.RemoveAt(index);
                }
            }
            catch(SqlException er)
            {
                MessageBox.Show(this, "Xoá không thành công", "Chú ý", MessageBoxButtons.OK);
                Console.WriteLine(er);
            }
        }
        public NhomMon getData()
        {
            try
            {
                NhomMon nhom = new NhomMon(Convert.ToInt32(cbId.Text), txtName.Text);
                return nhom;
            }
            catch(FormatException err)
            {
                Console.WriteLine(err);
                MessageBox.Show(this, "Mã Nhóm Không Hợp Lệ", "Chú ý", MessageBoxButtons.OK);
                return null;
            }
        }

        public void setData(NhomMon nhom)
        {
            txtName.Text = nhom.ten;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            NhomMon nhom = getData();
            if (nhom != null)
            {
                string error = validate_nhom(nhom);
                if (error == "")
                {
                    cnn.Open();
                    if (action == ADD)
                    {
                        scm = new SqlCommand(
                            "insert into nhommon (manhom, tennhom) " +
                            "values(" +
                                nhom.ma + ", " +
                                "N'" + nhom.ten + "')", cnn);
                        ds_nhom.Add(nhom);
                        dgvGroup.Rows.Add(new object[]
                        {
                            nhom.ma, nhom.ten
                        });
                        cbId.Items.Add(nhom.ma);
                    }
                    else if (action == EDIT)
                    {
                        scm = new SqlCommand(
                            "update nhommon set " +
                            "tennhom = N'" + nhom.ten +
                            "' where " +
                            "manhom = " + nhom.ma, cnn);
                        int index = ds_nhom.FindIndex(item => item.ma == nhom.ma);
                        dgvGroup.Rows[index].Cells[1].Value = nhom.ten;
                        ds_nhom[index] = nhom;
                    }
                    scm.ExecuteNonQuery();
                    cnn.Close();
                    reset();
                }
                else
                {
                    MessageBox.Show(this, error, "Chú ý", MessageBoxButtons.OK);
                }
            }
            
        }
        public string validate_nhom(NhomMon nhom)
        {
            string error = "";
            if (nhom.ten == "")
            {
                error += "Tên không được để trống\n";
            }
            return error;
        }
        private void cbId_SelectedIndexChanged(object sender, EventArgs e)
        {
            NhomMon nhom = ds_nhom.Find(item => "" + item.ma == cbId.SelectedItem.ToString());
            if(nhom != null)
            {
                setData(nhom);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void cbId_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void dgvGroup_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(action == EDIT)
            {
                if(e.RowIndex>-1 && e.RowIndex < dgvGroup.RowCount - 1)
                {
                    cbId.SelectedIndex = e.RowIndex;
                    txtName.Text = ds_nhom[e.RowIndex].ten;
                }
            }
        }
    }
}
