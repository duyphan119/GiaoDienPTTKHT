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
    public partial class ucQuanLyThucDon : UserControl
    {
        private const string ADD = "Thêm";
        private const string EDIT = "Sửa";
        private SqlConnection cnn;
        private SqlCommand scm;
        private SqlDataReader reader;
        private string action = "";
        private List<NhomMon> ds_nhom = new List<NhomMon>();
        private List<MonAn> ds_mon = new List<MonAn>();
        public ucQuanLyThucDon()
        {
            InitializeComponent();
        }

        private void ucQuanLyThucDon_Load(object sender, EventArgs e)
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
                ds_nhom.Add(nhom);
                cbGroup.Items.Add(tennhom);
            }
            cnn.Close();
            cnn.Open();
            scm = new SqlCommand(
                "select " +
                "b.manhom, " +
                "b.tennhom, " +
                "a.mamon, " +
                "a.tenmon, " +
                "a.dvt, " +
                "a.giatien " +
                "from monan a, nhommon b " +
                "where a.manhom = b.manhom", cnn);
            reader = scm.ExecuteReader();
            while (reader.Read())
            {
                int manhom = reader.GetInt32(0);
                string tennhom = reader.GetString(1);
                int mamon = reader.GetInt32(2);
                string tenmon = reader.GetString(3);
                string dvt = reader.GetString(4);
                int giaban = reader.GetInt32(5);
                dgvFood.Rows.Add(new object[]{
                    tennhom,
                    mamon,
                    tenmon,
                    dvt,
                    giaban.ToString("#,##")
                });
                NhomMon _nhom = new NhomMon(manhom, tennhom);
                MonAn mon = new MonAn(
                    _nhom,
                    mamon,
                    tenmon,
                    dvt,
                    giaban
                );
                ds_mon.Add(mon);
                cbId.Items.Add(mon.mamon);
            }
            cnn.Close();
        }

        public void setEnabled(bool status)
        {
            cbGroup.Enabled = status;
            cbId.Enabled = status;
            txtName.Enabled = status;
            cbUnit.Enabled = status;
            txtPrice.Enabled = status;
            btnSave.Enabled = status;
        }

        public void setData(MonAn mon)
        {
            cbGroup.Text = mon.nhom.ten;
            cbId.Text = ""+mon.nhom.ma;
            txtName.Text = mon.ten;
            cbUnit.Text = mon.dvt;
            txtPrice.Text = ""+mon.gia;
        }

        public MonAn getData()
        {
            try
            {
                MonAn mon = new MonAn(
                    ds_nhom[cbGroup.SelectedIndex],
                    Convert.ToInt32(cbId.Text),
                    txtName.Text,
                    cbUnit.Text,
                    Convert.ToInt32(txtPrice.Text)
                );
                return mon;
            }
            catch (FormatException err)
            {
                MessageBox.Show(this, "Mã Món Không Hợp Lệ", "Chú ý", MessageBoxButtons.OK);
                Console.WriteLine(err);
                return null;
            }

        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar)) e.Handled = true;
            if (e.KeyChar == (char)8) e.Handled = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            reset();
            if (action == ADD)
            {
                setEnabled(false);
                action = "";
            }
            else
            {
                if (ds_mon.Count > 0)
                {
                    cbId.Text = "" + (ds_mon[ds_mon.Count - 1].mamon + 1);
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
            txtName.Text = "";
            txtPrice.Text = "";
            if(action == ADD)
            {
                cbId.Text = "" + (ds_mon[ds_mon.Count - 1].mamon + 1);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            reset();
            setEnabled(false);
            if (action == EDIT)
            {
                action = "";
            }
            else
            {
                cbId.Enabled = true;
                action = EDIT;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            MonAn mon = getData();
            if (mon != null)
            {
                cnn.Open();
                if (action == ADD)
                {
                    scm = new SqlCommand(
                        "insert into monan" +
                        "(mamon, tenmon, dvt, giatien, manhom) " +
                        "values(" +
                            mon.mamon + ", " +
                            "N'" + mon.ten + "', " +
                            "N'" + mon.dvt + "', " +
                            mon.gia +
                            "," + mon.nhom.ma + ")", cnn);
                    dgvFood.Rows.Add(new object[]{
                        mon.nhom.ten,
                        mon.mamon,
                        mon.ten,
                        mon.dvt,
                        mon.gia.ToString("#,##")
                    });
                    ds_mon.Add(mon);
                    cbId.Items.Add(mon.mamon);
                }
                else if (action == EDIT)
                {
                    scm = new SqlCommand(
                        "update monan set " +
                        "tenmon = N'" + mon.ten + "'," +
                        "dvt=N'" + mon.dvt + "', " +
                        "giatien=" + mon.gia + ", " +
                        "manhom=" + mon.nhom.ma + " where " +
                        "mamon = " + mon.mamon, cnn);
                    int index = ds_mon.FindIndex(item => item.mamon == mon.mamon);
                    ds_mon[index] = mon;
                    dgvFood.Rows[index].Cells[0].Value = mon.nhom.ten;
                    dgvFood.Rows[index].Cells[2].Value = mon.ten;
                    dgvFood.Rows[index].Cells[3].Value = mon.dvt;
                    dgvFood.Rows[index].Cells[4].Value = mon.gia;
                }
                scm.ExecuteNonQuery();
                cnn.Close();
                reset();
                int ind = cbUnit.Items.IndexOf(cbUnit.Text);
                if(ind == -1)
                {
                    cbUnit.Items.Add(cbUnit.Text);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = dgvFood.SelectedRows.Count - 1; i >= 0; i--)
                {
                    int index = dgvFood.SelectedRows[i].Index;
                    DialogResult answer = MessageBox.Show(this,
                        $@"Dữ liệu liên quan đến món <{ds_mon[index].ten}> cũng sẽ bị xoá. Bạn có chắc chắn xoá không ?",
                        "Xác nhận", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    if (answer == DialogResult.Yes)
                    {
                        cnn.Open();
                        scm = new SqlCommand($"delete from monan where mamon = {ds_mon[index].mamon}", cnn);
                        scm.ExecuteNonQuery();
                        cnn.Close();
                        dgvFood.Rows.RemoveAt(index);
                        ds_mon.RemoveAt(index);
                        cbId.Items.RemoveAt(index);
                    }
                }
                dgvFood.ClearSelection();
            }
            catch (SqlException er)
            {
                MessageBox.Show(this, "Xoá không thành công", "Chú ý", MessageBoxButtons.OK);
                Console.WriteLine(er);
            }
        }

        private void cbId_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(action == EDIT && cbId.SelectedIndex != -1)
            {
                MonAn mon = ds_mon[cbId.SelectedIndex];
                cbGroup.Text = mon.nhom.ten;
                txtName.Text = mon.ten;
                cbUnit.Text = mon.dvt;
                txtPrice.Text = mon.gia.ToString();
                setEnabled(true);
            }
        }

        private void txtKeyword_TextChanged(object sender, EventArgs e)
        {
            cnn.Open();
            scm = new SqlCommand("select "  +
                "b.manhom, " +
                "b.tennhom, " +
                "a.mamon, " +
                "a.tenmon, " +
                "a.dvt, " +
                "a.giatien " +
                "from monan a, nhommon b " +
                "where a.manhom = b.manhom and a.tenmon like N'%" + txtKeyword.Text + "%'", cnn);
            reader = scm.ExecuteReader();
            ds_mon.Clear();
            cbId.Items.Clear();
            dgvFood.Rows.Clear();
            while (reader.Read())
            {
                int manhom = reader.GetInt32(0);
                string tennhom = reader.GetString(1);
                int mamon = reader.GetInt32(2);
                string tenmon = reader.GetString(3);
                string dvt = reader.GetString(4);
                int giaban = reader.GetInt32(5);
                dgvFood.Rows.Add(new object[]{
                    tennhom,
                    mamon,
                    tenmon,
                    dvt,
                    giaban.ToString("#,##")
                });
                NhomMon _nhom = new NhomMon(manhom, tennhom);
                MonAn mon = new MonAn(
                    _nhom,
                    mamon,
                    tenmon,
                    dvt,
                    giaban
                );
                ds_mon.Add(mon);
                cbId.Items.Add(mon.mamon);
            }
            cnn.Close();
        }

        private void cbUnit_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbGroup_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbId_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cbGroup_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
