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
    public partial class ucNhapKho : UserControl
    {
        private const string ADD = "Thêm";
        private const string EDIT = "Sửa";
        private SqlConnection cnn;
        private SqlCommand scm;
        private SqlDataReader reader;
        private string action;
        private List<NhaCungCap> ds_ncc = new List<NhaCungCap>();
        private List<NguyenLieu> ds_nl = new List<NguyenLieu>();
        private List<Phieu> ds_ph = new List<Phieu>();
        private List<int> ds_tonkho = new List<int>();
        private Phieu phieu = new Phieu();
        public NhanVien nv;
        public ucNhapKho(NhanVien x)
        {
            InitializeComponent();
            nv = x;
        }

        private void ucNhapKho_Load(object sender, EventArgs e)
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
                NhaCungCap ncc = ds_ncc.Find(item=>item.ma == reader.GetInt32(4));
                NguyenLieu nl = new NguyenLieu(ma, giatien, ten, dvt, ncc);
                ds_nl.Add(nl);
                int index = cbUnit.Items.IndexOf(nl.dvt); ;
                if (index == -1)
                {
                    cbUnit.Items.Add(nl.dvt);
                }
            }
            cnn.Close();
            for(int i = 0; i < ds_nl.Count; i++)
            {
                cnn.Open();
                scm = new SqlCommand($"execute sp_TonKhoCuaNguyenLieu {ds_nl[i].ma}", cnn);
                reader = scm.ExecuteReader();
                while (reader.Read())
                {
                    ds_tonkho.Add(reader.GetInt32(0));
                    //dgvProduct.Rows[i].Cells[4].Value = reader.GetInt32(0);
                }
                cnn.Close();
            }
            cnn.Open();
            scm = new SqlCommand("select * from phieunhap", cnn);
            reader = scm.ExecuteReader();
            while (reader.Read())
            {
                int ma = reader.GetInt32(0);
                DateTime ngaynhap = reader.GetDateTime(1);
                Phieu ph = new Phieu(ma, ngaynhap, null, new List<ChiTietPhieu>());
                ds_ph.Add(ph);
            }
            cnn.Close();
        }
        //Đầu tiên: Chọn nhà cung cấp 
        private void cbSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSupplier.SelectedIndex != -1)
            {
                List<NguyenLieu> ds_nl_new = new List<NguyenLieu>();
                ds_nl_new = ds_nl.FindAll(item => item.ncc.ma == ds_ncc[cbSupplier.SelectedIndex].ma);
                if (ds_nl_new.Count > 0)
                {
                    cbId.Items.Clear();
                    
                    ds_nl_new.ForEach(item =>
                    {
                        cbId.Items.Add(item.ma);
                    });
                }
            }
            else
            {
                setEnabled(false);
            }
        }
        //Bấm tạo phiếu
        private void btnCreate_Click(object sender, EventArgs e)
        {
            if(cbSupplier.Text != "")
            {
                if (txtId.Text == "")//Tạo phiếu
                {
                    groupDetail.Enabled = true;
                    cbSupplier.Enabled = false;
                    btnExport.Enabled = true;
                    phieu.sophieu = (ds_ph[ds_ph.Count - 1].sophieu + 1);
                    if (ds_ph.Count > 0)
                    {
                        txtId.Text = phieu.sophieu.ToString();
                    }
                    else
                    {
                        txtId.Text = "1";
                    }
                    phieu.list = new List<ChiTietPhieu>();
                }
                else//Huỷ phiếu
                {
                    txtId.Text = "";
                    groupDetail.Enabled = false;
                    cbSupplier.Enabled = true;
                    btnExport.Enabled = false;
                    phieu = new Phieu();
                }
            }
            else
            {
                MessageBox.Show(this, "Chưa chọn nhà cung cấp", "Lưu ý", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        //Thêm nguyên liệu mới
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
                if (ds_nl.Count > 0)
                {
                    cbId.Text = "" + (ds_nl[ds_nl.Count - 1].ma + 1);
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
        //Chọn mã nguyên liệu
        private void cbId_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = ds_nl.FindIndex(item => item.ma == ds_nl[cbId.SelectedIndex].ma);
            if (action == EDIT && index != -1)
            {
                setData(ds_nl[index].ma, index);
            }
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
                cbId.Text = "";
                txtName.Enabled = false;
                cbUnit.Enabled = false;
                txtPrice.Enabled = false;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            for (int i = dgvProduct.SelectedRows.Count - 1; i >= 0; i--)
            {
                int index = dgvProduct.SelectedRows[i].Index;
                int index2 = ds_nl.FindIndex(item => item.ma ==Convert.ToInt32(dgvProduct.Rows[index].Cells[0].Value));
                ds_tonkho[index2] -= Convert.ToInt32(dgvProduct.Rows[index].Cells[3].Value);
                dgvProduct.Rows.RemoveAt(index);
                phieu.list.RemoveAt(index);
            }
        }

        public NguyenLieu getData()
        {
            string error = "";
            if(cbId.Text == "")
            {
                error += "Chưa chọn nguyên liệu";
            }
            if(txtPrice.Text == "")
            {
                error += "Giá nguyên liệu phải > 0";
            }
            if(txtName.Text == "")
            {
                error += "Tên nguyên liệu không được để trống";
            }
            if (cbUnit.Text == "")
            {
                error += "Đơn vị tính không được để trống";
            }
            if(error == "")
            {
                int index = cbUnit.Items.IndexOf(cbUnit.Text);
                if(index == -1)
                {
                    cbUnit.Items.Add(cbUnit.Text);
                }
                NguyenLieu ncc = new NguyenLieu(
                Convert.ToInt32(cbId.Text),
                Convert.ToInt32(txtPrice.Text),
                txtName.Text,
                cbUnit.Text,
                ds_ncc[cbSupplier.SelectedIndex]);
                return ncc;
            }
            return null;
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            NguyenLieu nl = getData();
            if (nl != null)
            {
                int soluong = Convert.ToInt32(nudQuantity.Value);
                //cnn.Open();
                if (action == ADD)
                {
                    /*
                    scm = new SqlCommand(
                        $@"insert into nguyenlieu(manl, tennl, dvt, giatien, mancc)
                            values ({nl.ma},N'{nl.ten}',N'{nl.dvt}',{nl.gia},{nl.ncc.ma})
                            ", cnn);*/
                    phieu.list.Add(new ChiTietPhieu(nl, soluong));
                    ds_nl.Add(nl);
                    ds_tonkho.Add(soluong);
                    dgvProduct.Rows.Add(new object[]
                    {
                        nl.ma, nl.ten, nl.dvt, soluong, nl.gia.ToString("#,##")
                    });
                    cbId.Items.Add(nl.ma);
                }
                else if (action == EDIT)
                {
                    int index = ds_nl.FindIndex(item => ""+item.ma == cbId.SelectedItem.ToString());
                    phieu.list.Add(new ChiTietPhieu(nl, soluong));
                    ds_tonkho[index] += soluong;
                    dgvProduct.Rows.Add(new object[]
                    {
                            nl.ma, nl.ten, nl.dvt, soluong, nl.gia.ToString("#,##")
                    });
                }
                dgvProduct.ClearSelection();
                reset();
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            txtId.Text = "";
            groupDetail.Enabled = false;
            cbSupplier.Enabled = true;
            btnExport.Enabled = false;
            dgvProduct.Rows.Clear();
            phieu.ngay = DateTime.Now;
            /*phieu.list.ForEach(item =>
            {
                Console.WriteLine($"{item.nl.ten} - {item.soluong}");
            });*/
            cnn.Open();
            scm = new SqlCommand($@"insert into phieunhap(sopn, ngaynhap, manv)
                 values ({phieu.sophieu},getdate(),{nv.ma})
                ", cnn);
            scm.ExecuteNonQuery();
            cnn.Close();
            phieu.list.ForEach(item =>
            {
                bool nguyenLieuDaCo = false;
                cnn.Open();
                scm = new SqlCommand($"select manl from nguyenlieu where manl = {item.nl.ma}", cnn);
                reader = scm.ExecuteReader();
                if (reader.Read())
                {
                    nguyenLieuDaCo = true;
                }
                cnn.Close();
                if(nguyenLieuDaCo == false)
                {
                    cnn.Open();
                    scm = new SqlCommand(
                        $@"insert into nguyenlieu(manl, tennl, dvt, giatien, mancc)
                            values ({item.nl.ma},N'{item.nl.ten}',N'{item.nl.dvt}',{item.nl.gia},{item.nl.ncc.ma})
                            ", cnn);
                    scm.ExecuteNonQuery();
                    cnn.Close();
                }
                cnn.Open();
                scm = new SqlCommand($@"insert into chitietphieunhap(sopn, manl, soluong)
                         values ({phieu.sophieu},{item.nl.ma},{item.soluong})
                        ", cnn);
                scm.ExecuteNonQuery();
                cnn.Close();
            });
            phieu.ngay = DateTime.Now;
            ds_ph.Add(phieu);
            new Report(null).phieuNhap(phieu);
            phieu = new Phieu();
            action = "";
            setEnabled(false);
        }

        public void reset()
        {
            if (action == ADD)
            {
                cbId.Text = "" + (ds_nl[ds_nl.Count - 1].ma + 1);
            }
            else
            {
                cbId.Text = "";
            }
            txtName.Text = cbUnit.Text = txtPrice.Text = "";
            nudQuantity.Minimum = 0;
            nudQuantity.Value = 0;
        }

        public void setEnabled(bool status)
        {
            cbId.Enabled = status;
            txtName.Enabled = status;
            cbUnit.Enabled = status;
            nudQuantity.Enabled = status;
            txtPrice.Enabled = status;
            btnSave.Enabled = status;
        }
        public void setData(int  manl, int index)
        {
            cnn.Open();
            scm = new SqlCommand($"select * from nguyenlieu where maml = {manl}", cnn);
            reader = scm.ExecuteReader();
            while (reader.Read())
            {
                int ma = reader.GetInt32(0);
                string ten = reader.GetString(1);
                int giatien = reader.GetInt32(2);
                string dvt = reader.GetString(3);
                NhaCungCap ncc = ds_ncc.Find(item => item.ma == reader.GetInt32(4));
                NguyenLieu nl = new NguyenLieu(ma, giatien, ten, dvt, ncc);
                txtName.Text = nl.ten;
                txtPrice.Text = nl.gia.ToString();
                nudQuantity.Value = 0;
                cbUnit.Text = nl.dvt;
                ds_nl[index] = nl;
            }
            cnn.Close();
        }

        private void cbSupplier_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
