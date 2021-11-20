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
        private const string NEW = "Thêm danh sách món";
        private const string OLD = "Cập nhật danh sách món";
        private string action = "";
        private SqlConnection cnn;
        private SqlCommand scm;
        private SqlDataReader reader;
        private NhanVien nv = new NhanVien();
        private List<Ban> ds_ban = new List<Ban>();
        private List<HoaDon> ds_hd = new List<HoaDon>();
        private List<NhanVien> ds_nv = new List<NhanVien>();
        private int totalPrice = 0;
        private int vi_tri_hoa_don = -1;
        private DAO.DAO_NhanVien dao_nv = new DAO.DAO_NhanVien();
        private List<ucBan> giaodien_ban = new List<ucBan>();
        public ucBanHang(NhanVien x)
        {
            InitializeComponent();
            nv = x;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void ucBanHang_Load(object sender, EventArgs e)
        {
            dgvFood.Rows.Add(new object[]
            {
                "","","",""
            });
            dgvFood.Rows.RemoveAt(0);
            cnn = new SqlConnection(
                @"Data Source=DESKTOP-NIULDEP\SQLEXPRESS;Initial Catalog=btl_pttkht;User ID=sa;Password=password"
            );
            cnn.Open();
            scm = new SqlCommand("select * from ban", cnn);
            reader = scm.ExecuteReader();
            while (reader.Read())
            {
                Ban ban = new Ban(reader.GetInt32(0), reader.GetBoolean(1));
                ds_ban.Add(ban);
                giaodien_ban.Add(new ucBan(this, ban));
                fpnlTable.Controls.Add(giaodien_ban[giaodien_ban.Count - 1]);
            }
            cnn.Close();
            //Lấy ra danh sách nhân viên
            ds_nv = dao_nv.getAll();
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

        public void xemThongTinBan(Ban b)
        {
            List<ChiTietHoaDon> ds_mon_trong_hd = new List<ChiTietHoaDon>();
            totalPrice = 0;
            dgvFood.Rows.Clear();
            cnn.Open();
            scm = new SqlCommand($@"select hd.sohd, m.mamon, m.tenmon, cthd.soluong , m.dvt, m.giatien, (cthd.soluong * m.giatien) as 'thanhtien', m.manhom, nh.tennhom
			from hoadon hd, monan m, chitiethoadon cthd, nhommon nh
			where hd.sohd = cthd.sohd and m.mamon = cthd.mamon and hd.giora = hd.giovao and m.manhom = nh.manhom and hd.soban = {b.soban}", cnn);
            reader = scm.ExecuteReader();
            while (reader.Read())
            {
                int mamon = reader.GetInt32(1);
                string ten = reader.GetString(2);
                int soluong = reader.GetInt32(3);
                string dvt = reader.GetString(4);
                int dongia = reader.GetInt32(5);
                int manhom = reader.GetInt32(7);
                string tennhom = reader.GetString(8);
                ds_mon_trong_hd.Add(new ChiTietHoaDon(new MonAn(new NhomMon(manhom,tennhom),mamon, ten, dvt, dongia), soluong));

                dgvFood.Rows.Add(new object[]
                {
                    ten, dvt, soluong, dongia.ToString("#,##")
                });
                totalPrice += soluong * dongia;
            }
            dgvFood.ClearSelection();
            cnn.Close();

            lblInfoTable.Text = "Bàn: " + b.soban;
            lbPriceSum.Text = "Tổng tiền: " + totalPrice.ToString("#,##") + "đ";
            vi_tri_hoa_don = ds_hd.FindIndex(item => item.ban.soban == b.soban && item.giora == item.giovao);
            if (vi_tri_hoa_don != -1)
            {
                lblTimeIn.Text = $"Giờ khách vào: {ds_hd[vi_tri_hoa_don].giovao.ToString("dd-MM-yyyy HH:mm:ss")}";
                ds_hd[vi_tri_hoa_don].ds_mon = ds_mon_trong_hd;
            }
            else
            {
                lblTimeIn.Text = "Giờ khách vào: ";
            }
            lbPriceSum.Text = "Tổng tiền: " + ((totalPrice == 0) ? "" + 0 : totalPrice.ToString("#,##")) + "đ";
            
        }
        public void datMon(Button btn_Ban, Ban b)
        {
            List<ChiTietHoaDon> ds_mon_trong_hd = new List<ChiTietHoaDon>();
            cnn.Open();
            scm = new SqlCommand($@"select hd.sohd, m.mamon, m.tenmon, cthd.soluong , m.dvt, m.giatien, (cthd.soluong * m.giatien) as 'thanhtien', m.manhom, nh.tennhom
			from hoadon hd, monan m, chitiethoadon cthd, nhommon nh
			where hd.sohd = cthd.sohd and m.mamon = cthd.mamon and hd.giora = hd.giovao and m.manhom = nh.manhom and hd.soban = {b.soban}", cnn);
            reader = scm.ExecuteReader();
            while (reader.Read())
            {
                int mamon = reader.GetInt32(1);
                string ten = reader.GetString(2);
                int soluong = reader.GetInt32(3);
                string dvt = reader.GetString(4);
                int dongia = reader.GetInt32(5);
                int manhom = reader.GetInt32(7);
                string tennhom = reader.GetString(8);
                ds_mon_trong_hd.Add(new ChiTietHoaDon(new MonAn(new NhomMon(manhom, tennhom), mamon, ten, dvt, dongia), soluong));
            }
            cnn.Close();

            HoaDon _hd = ds_hd.Find(item => item.ban.soban == b.soban && item.giora == item.giovao);
            if (_hd != null)
            {
                action = OLD;
                _hd.ds_mon = ds_mon_trong_hd;
            }
            else
            {
                action = NEW;
                //Bàn này chưa có hoá đơn
                DateTime now = DateTime.Now;
                _hd = new HoaDon((ds_hd.Count == 0) ? 1 : (ds_hd[ds_hd.Count - 1].sohd + 1), now, now, nv, b, new List<ChiTietHoaDon>());
            }
            new ThemMon(this, _hd, btn_Ban).Visible = true;
        }

        public void order(Button btn_Ban, HoaDon _hd)
        {
            if (_hd != null) 
            {
                totalPrice = 0;
                if (action == NEW)
                {
                    /*
                    create proc sp_datBan (@sohd int, @soban int, @manv int)
                    as
	                    begin
		                    declare @now datetime;
		                    set @now = getdate();
		                    update ban set trangthai = 0 where soban = @soban;
		                    insert into hoadon(sohd, giovao,giora, soban, manv) values (@sohd, @now,@now,@soban, @manv); 
	                    end
                     */
                    cnn.Open();
                    scm = new SqlCommand($"execute sp_datBan {_hd.sohd},{_hd.ban.soban},{_hd.nv.ma}", cnn);
                    scm.ExecuteNonQuery();
                    cnn.Close();
                    //Cập nhật lại giờ theo trong sql
                    cnn.Open();
                    scm = new SqlCommand($"select giovao from hoadon where sohd = {_hd.sohd}", cnn);
                    reader = scm.ExecuteReader();
                    if (reader.Read())
                    {
                        _hd.giovao = _hd.giora = reader.GetDateTime(0);
                    }
                    cnn.Close();
                    ds_hd.Add(_hd);
                    vi_tri_hoa_don = ds_hd.Count;
                    //Đổi màu cái bàn
                    btn_Ban.BackColor = Color.LightCoral;
                }
                else
                {
                    //Cập nhật danh sách món
                    //Xoá hết chi tiết hoá đơn 
                    //Rồi thêm lại chi tiết hoá đơn mới
                    cnn.Open();
                    if (ds_hd.Count > 0)
                        scm = new SqlCommand($"delete from chitiethoadon where sohd = {_hd.sohd}", cnn);
                    scm.ExecuteNonQuery();
                    cnn.Close();
                    vi_tri_hoa_don = ds_hd.FindIndex(item => _hd.sohd == item.sohd && item.giora == item.giovao);
                }
                action = "";
                dgvFood.Rows.Clear();
                //Lưu danh sách món
                _hd.ds_mon.ForEach(item =>
                {
                    if (item.soluong != 0)
                    {
                        cnn.Open();
                        scm = new SqlCommand($@"insert into chitiethoadon (sohd, mamon, soluong)  
                            values({_hd.sohd},{item.mon.mamon},{item.soluong})", cnn);
                        scm.ExecuteNonQuery();
                        cnn.Close();
                        dgvFood.Rows.Add(new object[]
                        {
                            item.mon.ten, item.mon.dvt, item.soluong, item.mon.gia.ToString("#,##")
                        });
                        totalPrice += item.soluong * item.mon.gia;
                    }
                });
                dgvFood.ClearSelection();
                lblInfoTable.Text = $"Bàn: {_hd.ban.soban}";
                lblTimeIn.Text = $"Giờ khách vào: {_hd.giovao.ToString("dd-MM-yyyy HH:mm:ss")}";
                lbPriceSum.Text = "Tổng tiền: " + totalPrice.ToString("#,##") + "đ";
            }
        }

        private void btnPrintBill_Click(object sender, EventArgs e)
        {
            Console.WriteLine(vi_tri_hoa_don);
            if (vi_tri_hoa_don != -1)
            {
                Console.WriteLine(ds_hd[vi_tri_hoa_don].ban.soban);
                ds_hd[vi_tri_hoa_don].giora = DateTime.Now;
                dgvFood.Rows.Clear();
                totalPrice = 0;
                lbPriceSum.Text = "Tổng tiền: 0đ";
                lblTimeIn.Text = "Giờ khách vào: ";
                new Report(ds_hd[vi_tri_hoa_don]).Visible = true;
                lblInfoTable.Text = "Bàn: ";
                giaodien_ban.ForEach(item =>
                {
                    item.sauKhiThanhToan(ds_hd[vi_tri_hoa_don].ban);
                });
                vi_tri_hoa_don = -1;
            }
        }
    }
}
