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
    public partial class ucThongKe : UserControl
    {
        private SqlConnection cnn;
        private SqlCommand scm;
        private SqlDataReader reader;
        private NhanVien nv = new NhanVien();
        private List<Ban> ds_ban = new List<Ban>();
        private List<HoaDon> ds_hd = new List<HoaDon>();
        private List<NhanVien> ds_nv = new List<NhanVien>();
        private List<MonAn> ds_mon = new List<MonAn>();
        private List<NhomMon> ds_nhom = new List<NhomMon>();
        private DAO.DAO_NhanVien dao_nv = new DAO.DAO_NhanVien();
        public ucThongKe()
        {
            InitializeComponent();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dtStart_ValueChanged(object sender, EventArgs e)
        {
            DateTime start = new DateTime(dtStart.Value.Year, dtStart.Value.Month, dtStart.Value.Day, 0, 0, 0);
            DateTime end = new DateTime(dtEnd.Value.Year, dtEnd.Value.Month, dtEnd.Value.Day, 23, 59, 59);
            thongKeHoaDon(start, end);
            thongKeSoLuongMonAn(start, end);
        }

        private void dtEnd_ValueChanged(object sender, EventArgs e)
        {
            DateTime start = new DateTime(dtStart.Value.Year, dtStart.Value.Month, dtStart.Value.Day, 0, 0, 0);
            DateTime end = new DateTime(dtEnd.Value.Year, dtEnd.Value.Month, dtEnd.Value.Day, 23, 59, 59);
            thongKeHoaDon(start, end);
            thongKeSoLuongMonAn(start, end);
        }

        public void thongKeHoaDon(DateTime start, DateTime end)
        {
            //Thống kê hoá đơn từ ngày đến ngày
            cnn.Open();
            scm = new SqlCommand("select * from hoadon  " +
                "where giovao != giora and giora between '"+start.ToString()+"' and '"+end.ToString() + "'", cnn);
            reader = scm.ExecuteReader();
            List<HoaDon> list_order = new List<HoaDon>();
            while (reader.Read())
            {
                HoaDon hd = new HoaDon(
                    reader.GetInt32(0),
                    reader.GetDateTime(1),
                    reader.GetDateTime(2),
                    ds_nv.Find(item => item.ma == reader.GetInt32(3)),
                    ds_ban.Find(item => item.soban == reader.GetInt32(4)),
                    new List<ChiTietHoaDon>()
                );
                list_order.Add(hd);
            }
            cnn.Close();
            //Hiển thị lên datagridview
            displayOrder_DataGridView(list_order);
            //Thống kê
            totalOrder.Text = "Tổng số hoá đơn: " + list_order.Count;
        }
        public void thongKeSoLuongMonAn(DateTime start, DateTime end)
        {
            cnn.Open();
            scm = new SqlCommand("execute sp_ThongKeSoLuongMonAnBanDuocTuNgayDenNgay  '" + start.ToString() + "' , '" + end.ToString() + "'", cnn);
            reader = scm.ExecuteReader();
            List<ChiTietHoaDon> result = new List<ChiTietHoaDon>();
            while (reader.Read())
            {
                int manhom = reader.GetInt32(0);
                string tennhom = reader.GetString(1);
                int mamon = reader.GetInt32(2);
                string tenmon = reader.GetString(3);
                string dvt = reader.GetString(4);
                int giatien = reader.GetInt32(5);
                int soluong = reader.GetInt32(6);
                NhomMon nhom = new NhomMon(manhom, tennhom);
                MonAn mon = new MonAn(
                   nhom, mamon, tenmon, dvt, giatien
                );
                ChiTietHoaDon cthd = new ChiTietHoaDon(mon, soluong);
                result.Add(cthd);
            }
            cnn.Close();
            displayOrderItem_DataGridView(result);
        }
        public void displayOrder_DataGridView(List<HoaDon> list_order)
        {
            dgvOrder.Rows.Clear();
            int total = 0;
            List<int> list_food = new List<int>();
            list_order.ForEach(order =>
            {
                int totalPrice = 0;
                cnn.Open();
                scm = new SqlCommand("execute sp_TinhTienCuaHoaDon " + order.sohd, cnn);
                reader = scm.ExecuteReader();
                while (reader.Read())
                {
                    totalPrice = reader.GetInt32(0);
                }
                cnn.Close();
                cnn.Open();
                scm = new SqlCommand("select mamon from chitiethoadon " +
                    "where sohd = " + order.sohd, cnn); ;
                reader = scm.ExecuteReader();
                while (reader.Read())
                {
                    int index = list_food.FindIndex(item => item == reader.GetInt32(0));
                    if (index == -1)
                    {
                        list_food.Add(reader.GetInt32(0));
                    }
                }
                cnn.Close();
                dgvOrder.Rows.Add(new object[]
                {
                    order.sohd, 
                    order.giovao.ToString("dd-MM-yyyy HH:mm:ss"), 
                    order.giora.ToString("dd-MM-yyyy HH:mm:ss"), 
                    order.ban.soban,
                    totalPrice.ToString("#,##"),
                    order.nv.ten
                });
                total += totalPrice;
            });
            dgvOrder.ClearSelection();
            totalPrice.Text = "Tổng tiền bán được: " + (total==0?""+0: total.ToString("#,##")) + "đ";
            totalFoodSelled.Text = "Số lượng món bán được: " + list_food.Count;
        }

        public void displayOrderItem_DataGridView(List<ChiTietHoaDon> items)
        {
            dgvFood.Rows.Clear();
            items.ForEach(item =>
            {
                dgvFood.Rows.Add(new object[]
                {
                    item.mon.mamon,
                    item.mon.ten,
                    item.mon.dvt,
                    item.soluong,
                    item.mon.gia,
                    item.mon.nhom.ten
                });
            });
            dgvFood.ClearSelection();
        }

        private void ucThongKe_Load(object sender, EventArgs e)
        {
            cnn = new SqlConnection(
                @"Data Source=DESKTOP-NIULDEP\SQLEXPRESS;Initial Catalog=btl_pttkht;User ID=sa;Password=password"
            );
            //Lấy danh sách bàn
            cnn.Open();
            scm = new SqlCommand("select * from ban", cnn);
            reader = scm.ExecuteReader();
            while (reader.Read())
            {
                Ban ban = new Ban(reader.GetInt32(0), reader.GetBoolean(1));
                ds_ban.Add(ban);
            }
            cnn.Close();
            //Lấy danh sách nhân viên
            ds_nv = dao_nv.getAll();
            //Lấy danh sách nhóm
            cnn.Open();
            scm = new SqlCommand("select * from nhommon", cnn);
            reader = scm.ExecuteReader();
            while (reader.Read())
            {
                int manhom = reader.GetInt32(0);
                string tennhom = reader.GetString(1);
                NhomMon nhom = new NhomMon(manhom, tennhom);
                ds_nhom.Add(nhom);
            }
            cnn.Close();
            //Lấy danh sách món ăn
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
                NhomMon _nhom = new NhomMon(manhom, tennhom);
                MonAn mon = new MonAn(
                    _nhom,
                    mamon,
                    tenmon,
                    dvt,
                    giaban
                );
                ds_mon.Add(mon);
            }
            cnn.Close();
            //Lấy danh sách hoá đơn
            cnn.Open();
            scm = new SqlCommand("select * from hoadon ", cnn);
            reader = scm.ExecuteReader();
            while (reader.Read())
            {
                HoaDon hd = new HoaDon(
                    reader.GetInt32(0),
                    reader.GetDateTime(1),
                    reader.GetDateTime(2),
                    ds_nv.Find(item => item.ma == reader.GetInt32(3)),
                    ds_ban.Find(item => item.soban == reader.GetInt32(4)),
                    new List<ChiTietHoaDon>()
                );
                ds_hd.Add(hd);
            }
            cnn.Close();
            //Mặc định là thống kê theo ngày hôm nay
            DateTime now = DateTime.Now;
            DateTime start = new DateTime(now.Year, now.Month, now.Day, 0, 0, 0);
            DateTime end = new DateTime(now.Year, now.Month, now.Day, 23, 59, 59);
            thongKeHoaDon(start, end);
            thongKeSoLuongMonAn(start, end);
            //Thống kê chung
            totalTable.Text = "Tổng số bàn: " + ds_ban.Count;
            totalFood.Text = "Tổng số món: " + ds_mon.Count;
            totalGroup.Text = "Tổng số nhóm món: " + ds_nhom.Count;
        }

        private void rjButton1_Click(object sender, EventArgs e)
        {

        }
    }
}
