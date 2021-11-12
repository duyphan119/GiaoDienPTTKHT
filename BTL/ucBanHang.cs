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
        private decimal totalPrice = 0;
        private int vi_tri_ban = -1;
        private int so_hoa_don_thanh_toan;
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
            new ThemMon().Visible = true;
        }

        private void ucBanHang_Load(object sender, EventArgs e)
        {
            cnn = new SqlConnection(
                @"Data Source=DESKTOP-NIULDEP\SQLEXPRESS;Initial Catalog=btl_pttkht;User ID=sa;Password=password"
            );
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
                    tables[ds_ban.Count - 1].BackColor = Color.Red;
                }
                else
                {
                    tables[ds_ban.Count - 1].BackColor = Color.RoyalBlue;
                }
                tables[ds_ban.Count - 1].Click += new EventHandler(xem_thong_tin_ban);
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
            listDishes.Items.Clear();
            ListViewItem item;
            while (reader.Read())
            {
                so_hoa_don_thanh_toan = reader.GetInt32(0);
                decimal soluong = reader.GetInt32(3);
                decimal dongia = reader.GetInt32(5);
                item = new ListViewItem(new string[]{
                    reader.GetString(2),
                    ""+soluong,
                    ""+dongia
                });
                totalPrice += soluong * dongia;
                listDishes.Items.Add(item);
            }
            cnn.Close();
            NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;
            nfi.CurrencyGroupSeparator = ".";
            lbPriceSum.Text = "Tổng tiền: " + totalPrice.ToString("#,##") + "đ";
        }

        private void btnPrintBill_Click(object sender, EventArgs e)
        {
            listDishes.Items.Clear();
            totalPrice = 0;
            lbPriceSum.Text = "Tổng tiền: 0đ";
            tables[vi_tri_ban].BackColor = Color.RoyalBlue;
            cnn.Open();
            scm = new SqlCommand("execute sp_ThanhToan " + so_hoa_don_thanh_toan, cnn);
            scm.ExecuteNonQuery();
            cnn.Close();
        }
    }
}
