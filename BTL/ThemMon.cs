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
    public partial class ThemMon : MetroForm
    {
        private SqlConnection cnn;
        private SqlCommand scm;
        private SqlDataReader reader;
        private List<NhomMon> ds_nhom = new List<NhomMon>();
        private List<MonAn> ds_mon = new List<MonAn>();
        private List<ChiTietHoaDon> ds_mon_da_chon = new List<ChiTietHoaDon>(); 
        private HoaDon hd;//Nhận từ ucBanHang
        private ucBanHang preComponent;
        private int total = 0;
        private Button ban_dang_dat_mon;
        public ThemMon(ucBanHang c, HoaDon x, Button btn)
        {
            InitializeComponent();
            hd = x;
            preComponent = c;
            ds_mon_da_chon = hd.ds_mon;
            ban_dang_dat_mon = btn;
        }

        private void ThemMon_Load(object sender, EventArgs e)
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
            cbGroup.SelectedIndex = 0;
            ds_mon_da_chon.ForEach(ct =>
            {
                dgvResult.Rows.Add(new object[]
                {
                    ct.mon.ten, ct.soluong
                });
            });
            total = hd.getTotal();
            lblTotalFood.Text = "Số món đã chọn: " + total;
        }

        private void cbGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            cnn.Open();
            ds_mon.Clear();
            fpnlFood.Controls.Clear();
            scm = new SqlCommand($@"select b.manhom,b.tennhom,a.mamon,a.tenmon,a.dvt,a.giatien from monan a, nhommon b 
                where a.manhom = b.manhom and a.manhom = {ds_nhom[cbGroup.SelectedIndex].ma}", cnn);
            reader = scm.ExecuteReader();
            int i = 0;
            while (reader.Read())
            {
                int manhom = reader.GetInt32(0);
                string tennhom = reader.GetString(1);
                int mamon = reader.GetInt32(2);
                string tenmon = reader.GetString(3);
                string dvt = reader.GetString(4);
                int giaban = reader.GetInt32(5);
                NhomMon _nhom = new NhomMon(manhom, tennhom);
                MonAn mon = new MonAn(
                    _nhom,
                    mamon,
                    tenmon,
                    dvt,
                    giaban
                );
                ds_mon.Add(mon);
                //Tên món
                ChiTietHoaDon ct = ds_mon_da_chon.Find(cthd => cthd.mon.mamon == mon.mamon);
                if(ct == null)
                {
                    fpnlFood.Controls.Add(new ucCardFood(this, mon.ten, 0));
                }
                else
                {
                    fpnlFood.Controls.Add(new ucCardFood(this, ct.mon.ten, ct.soluong));
                }
                i++;
            }
            
            cnn.Close();
        }

        public void themMon(string name, int soluong)
        {
            MonAn mon = ds_mon.Find(item => item.ten == name);
            if(mon != null)
            {
                int index = ds_mon_da_chon.FindIndex(cthd => cthd.mon.mamon == mon.mamon);
                if(index == -1)//Thêm món mới
                {
                    ds_mon_da_chon.Add(new ChiTietHoaDon(mon, soluong));
                    dgvResult.Rows.Add(new object[]
                    {
                        mon.ten, soluong
                    });
                    total++;
                }
                else//Cập nhật số lượng
                {
                    total -= ds_mon_da_chon[index].soluong;
                    ds_mon_da_chon[index].soluong = soluong;
                    dgvResult.Rows[index].Cells[1].Value = soluong;
                    total += ds_mon_da_chon[index].soluong;
                }
                lblTotalFood.Text = "Số món đã chọn: " + total;
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            hd.ds_mon = ds_mon_da_chon;
            preComponent.order(ban_dang_dat_mon, hd);
            Visible = false;
        }

        private void ThemMon_FormClosing(object sender, FormClosingEventArgs e)
        {
            preComponent.order(null, null);
        }
    }
}
