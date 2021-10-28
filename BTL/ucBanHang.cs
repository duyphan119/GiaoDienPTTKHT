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
    public partial class ucBanHang : UserControl
    {
        public ucBanHang()
        {
            InitializeComponent();
        }

        private void lbPriceSum_Click(object sender, EventArgs e)
        {

        }

        private void btnAddDish_Click(object sender, EventArgs e)
        {
            new ThemMon().Visible = true;
        }

        private void metroPanel2_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void table7_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            //VScrollBar vScroller = new VScrollBar();
            //vScroller.Height = 200;
            //vScroller.Width = 5;
            //panel1.Controls.Add(vScroller);
        }

        private void listDishes_SelectedIndexChanged(object sender, EventArgs e)
        {

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
    }
}
