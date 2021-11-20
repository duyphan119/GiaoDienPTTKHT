using BTL.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL
{
    public partial class ucBan : UserControl
    {
        private Ban ban;
        private ucBanHang preComponent;
        public ucBan(ucBanHang f, Ban b)
        {
            InitializeComponent();
            ban = b;
            rjButton1.Text = $"Bàn {ban.soban}";
            preComponent = f;
        }
        private void ucBan_Load(object sender, EventArgs e)
        {
             if(ban.trangthai == true)
            {
                rjButton1.BackColor = Color.RoyalBlue;
                rjButton1.ForeColor = Color.White;
            }
            else
            {
                rjButton1.BackColor = Color.Red;
                rjButton1.ForeColor = Color.White;
            }
        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            //Xem thông tin
            preComponent.xemThongTinBan(ban);
        }

        private void rjButton2_Click(object sender, EventArgs e)
        {
            //Xem thông tin
            preComponent.datMon(rjButton1, ban);
        }
    }
}
