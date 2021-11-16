using BTL.Model;
using MetroFramework.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL
{
    public partial class ucBanHang : UserControl
    {
        private SqlConnection cnn;
        private SqlCommand scm;
        private SqlDataReader reader;
        private NhanVien nv = new NhanVien();
        private List<MetroButton> tables;
        private List<Ban> ds_ban = new List<Ban>();
        private List<HoaDon> ds_hd = new List<HoaDon>();
        private List<NhanVien> ds_nv = new List<NhanVien>();
        private int totalPrice = 0;
        private int vi_tri_ban = -1;
        private int vi_tri_hoa_don = -1;
        public ucBanHang(NhanVien x)
        {
            InitializeComponent();
            nv = x;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            //VScrollBar vScroller = new VScrollBar();
            //vScroller.Height = 200;
            //vScroller.Width = 5;
            //panel1.Controls.Add(vScroller);
        }

        private void listDishes_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.Red, e.Bounds);
            e.DrawText();
        }

        private void btnAddDish_Click_1(object sender, EventArgs e)
        {
            if (vi_tri_ban != -1)
            {
                if(vi_tri_hoa_don != -1)
                {
                    new ThemMon(this, ds_hd[vi_tri_hoa_don]).Visible = true;
                }
                else
                {
                    MessageBox.Show(this, "Chưa đặt bàn", "Chú ý", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show(this, "Chưa chọn bàn", "Chú ý", MessageBoxButtons.OK);
            }
        }

        private void ucBanHang_Load(object sender, EventArgs e)
        {
            cnn = new SqlConnection(
                @"Data Source=DESKTOP-NIULDEP\SQLEXPRESS;Initial Catalog=btl_pttkht;User ID=sa;Password=password"
            );
            //Khởi tạo danh sách bàn
            tables =
                Enumerable.Range(1, 18)
                .Select(i => (MetroButton)panel1.Controls["table" + i.ToString()])
                .ToList();
            cnn.Open();
            scm = new SqlCommand("select * from ban", cnn);
            reader = scm.ExecuteReader();
            while (reader.Read())
            {
                Ban ban = new Ban(reader.GetInt32(0), reader.GetBoolean(1));
                ds_ban.Add(ban);
                if(ban.trangthai == false)
                {
                    tables[ds_ban.Count - 1].BackColor = Color.RoyalBlue;
                }
                else
                {
                    tables[ds_ban.Count - 1].BackColor = Color.White;
                }
                tables[ds_ban.Count - 1].Click += new EventHandler(xem_thong_tin_ban);
            }
            cnn.Close();
            //Lấy ra danh sách nhân viên
            cnn.Open();
            scm = new SqlCommand("select * from nhanvien ", cnn);
            reader = scm.ExecuteReader();
            while (reader.Read())
            {
                int manv = reader.GetInt32(0);
                string tennv = reader.GetString(1);
                DateTime ngaysinh = reader.GetDateTime(7);
                string gioitinh = reader.GetString(2);
                string sdt = reader.GetString(3);
                string chucvu = reader.GetString(4);
                string quyen = reader.GetString(6);
                string matkhau = reader.GetString(5);
                NhanVien nv = new NhanVien(
                    tennv, ngaysinh, gioitinh, manv, sdt, chucvu, quyen, matkhau
                );
                ds_nv.Add(nv);
            }
            cnn.Close();
            //Lấy ra danh sách hoá đơn
            cnn.Open();
            scm = new SqlCommand("select * from hoadon ", cnn);
            reader = scm.ExecuteReader();
            while (reader.Read())
            {
                HoaDon hd = new HoaDon(
                    reader.GetInt32(0),
                    reader.GetDateTime(1),
                    reader.GetDateTime(2),
                    ds_nv.Find(item=>item.ma == reader.GetInt32(3)),
                    ds_ban.Find(item=>item.soban == reader.GetInt32(4)),
                    new List<ChiTietHoaDon>()
                );
                ds_hd.Add(hd);
            }
            cnn.Close();
        }

        private void xem_thong_tin_ban(object sender, EventArgs e)
        {
            totalPrice = 0;
            MetroButton ban_dang_chon = (sender as MetroButton);
            cnn.Open();
            int index = tables.FindIndex(table => ban_dang_chon.Text == table.Text);
            vi_tri_ban = index;
            Ban ban = ds_ban[index];
            scm = new SqlCommand("execute sp_DanhSachMonAnCuaBan " + ban.soban, cnn);
            reader = scm.ExecuteReader();
            dgvFood.Rows.Clear();
            while (reader.Read())
            {
                string ten = reader.GetString(2);
                int soluong = reader.GetInt32(3);
                string dvt = reader.GetString(4);
                int dongia = reader.GetInt32(5);
                dgvFood.Rows.Add(new object[]
                {
                    ten, dvt, soluong, dongia
                });
                totalPrice += soluong * dongia;
            }
            cnn.Close();
            lblInfoTable.Text = "Bàn: " + ds_ban[vi_tri_ban].soban;
            lbPriceSum.Text = "Tổng tiền: " + totalPrice.ToString("#,##") + "đ";
            vi_tri_hoa_don = ds_hd.FindIndex(item => item.ban.soban == ds_ban[vi_tri_ban].soban && item.giora == item.giovao);
            if (vi_tri_hoa_don != -1)
            {
                lblTimeIn.Text = "Giờ khách vào: " + ds_hd[vi_tri_hoa_don].giovao.ToString();
            }
            else
            {
                lblTimeIn.Text = "Giờ khách vào: ";
            }
            lbPriceSum.Text = "Tổng tiền: "+ ((totalPrice == 0) ? ""+0 : totalPrice.ToString("#,##") )+ "đ";
        }

        private void btnPrintBill_Click(object sender, EventArgs e)
        {
            dgvFood.Rows.Clear();
            totalPrice = 0;
            lbPriceSum.Text = "Tổng tiền: 0đ";
            lblTimeIn.Text = "Giờ khách vào: ";
            tables[vi_tri_ban].BackColor = Color.RoyalBlue;
            new Report(ds_hd[vi_tri_hoa_don]).Visible = true;
            vi_tri_ban = -1;
            lblInfoTable.Text = "Bàn: ";
            vi_tri_hoa_don = -1;
        }

        private void btnAddTable_Click(object sender, EventArgs e)
        {
            if (ds_ban[vi_tri_ban].trangthai == true)
            {
                cnn.Open();
                if (ds_hd.Count > 0)
                {
                    scm = new SqlCommand("execute sp_datBan " + (ds_hd[ds_hd.Count - 1].sohd + 1) + "," + ds_ban[vi_tri_ban].soban + "," + 10, cnn);
                }
                else
                {
                    scm = new SqlCommand("execute sp_datBan " + 1 + "," + ds_ban[vi_tri_ban].soban + "," + 10, cnn);
                }
                
                scm.ExecuteNonQuery();
                cnn.Close();
                tables[vi_tri_ban].BackColor = Color.Red;
                HoaDon hd = new HoaDon(ds_hd.Count + 1, DateTime.Now, DateTime.Now, nv, ds_ban[vi_tri_ban], new List<ChiTietHoaDon>());
                lblTimeIn.Text = "Giờ khách vào: " + hd.giovao.ToString();
                ds_hd.Add(hd);
                vi_tri_hoa_don = ds_hd.Count - 1;
            }
            else
            {
                MessageBox.Show(this, "Bàn này đã có người", "Lưu ý", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void order(HoaDon _hd)
        {
            totalPrice = 0;
            ds_hd[vi_tri_hoa_don] = _hd;
            ds_hd[vi_tri_hoa_don].ds_mon.ForEach(item =>
            {
                dgvFood.Rows.Add(new object[]
                {
                    item.mon.ten, item.mon.dvt, item.soluong, item.mon.gia
                });
                totalPrice += item.soluong * item.mon.gia;
                cnn.Open();
                scm = new SqlCommand(
                    "insert into chitiethoadon (sohd, mamon, soluong) " +
                    "values("+ ds_hd[vi_tri_hoa_don].sohd+", "+item.mon.mamon+", "+item.soluong+")", cnn);
                scm.ExecuteNonQuery();
                cnn.Close();
            });
            lbPriceSum.Text = "Tổng tiền: " + totalPrice.ToString("#,##") + "đ";
        }
    }
}
