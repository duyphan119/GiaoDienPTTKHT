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
        private const string ADD = "Thêm";
        private const string EDIT = "Sửa";
        private SqlConnection cnn;
        private SqlCommand scm;
        private SqlDataReader reader;
        private string action = "";
        private List<NhomMon> ds_nhom = new List<NhomMon>();
        private List<MonAn> ds_mon = new List<MonAn>();
        private List<Button> ds_btn_mon = new List<Button>();
        private List<ChiTietHoaDon> ds_mon_da_chon = new List<ChiTietHoaDon>(); 
        private int vi_tri_mon = -1;
        private HoaDon hd;
        private ucBanHang preComponent;
        public ThemMon(ucBanHang c, HoaDon x)
        {
            InitializeComponent();
            hd = x;
            preComponent = c;
        }

        private void ThemMon_Load(object sender, EventArgs e)
        {
            cnn = new SqlConnection(
                @"Data Source=DESKTOP-NIULDEP\SQLEXPRESS;Initial Catalog=btl_pttkht;User ID=sa;Password=password"
            );

            ds_btn_mon =
                Enumerable.Range(1, 12)
                .Select(i => (Button)metroPanel1.Controls["button" + i.ToString()])
                .ToList();
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
        }

        private void cbGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            cnn.Open();
            ds_mon.Clear();
            scm = new SqlCommand(
                "select " +
                "b.manhom, " +
                "b.tennhom, " +
                "a.mamon, " +
                "a.tenmon, " +
                "a.dvt, " +
                "a.giatien " +
                "from monan a, nhommon b " +
                "where a.manhom = b.manhom and a.manhom = "+ds_nhom[cbGroup.SelectedIndex].ma, cnn);
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
                ds_btn_mon[i].Text = mon.ten;
                ds_btn_mon[i].Visible = true;
                ds_btn_mon[i].Click += new EventHandler(selectFood);
                i++;
            }
            for(int ip = i; ip< ds_btn_mon.Count; ip++)
            {
                ds_btn_mon[ip].Visible = false;
            }
            cnn.Close();
        }

        private void selectFood(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            for (int ip = 0; ip < ds_btn_mon.Count; ip++)
            {
                if (ds_btn_mon[ip].Visible == true)
                {
                    if (ds_btn_mon[ip].Text == btn.Text)
                    {
                        vi_tri_mon = ip;
                        btn.BackColor = Color.Firebrick;
                        numQuantity.Value = 1;
                    }
                }
                else
                {
                    break;
                }
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            ChiTietHoaDon cthd = new ChiTietHoaDon(ds_mon[vi_tri_mon], Convert.ToInt32(numQuantity.Value));
            ds_mon_da_chon.Add(cthd);
            numQuantity.Value = 0;
            ds_btn_mon[vi_tri_mon].BackColor = Color.CornflowerBlue;
            vi_tri_mon = -1;
            lblTotalFood.Text = "Số món đã chọn: " + ds_mon_da_chon.Count;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            //Nếu quên bấm chọn thì chọn cái món vừa click
            if(ds_mon_da_chon.Count == 0)
            {
                ChiTietHoaDon cthd = new ChiTietHoaDon(ds_mon[vi_tri_mon], Convert.ToInt32(numQuantity.Value));
                ds_mon_da_chon.Add(cthd);
            }
            hd.ds_mon = ds_mon_da_chon;
            preComponent.order(hd);
            Visible = false;
        }
    }
}
