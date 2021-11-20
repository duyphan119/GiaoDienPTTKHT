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
    public partial class ucCardFood : UserControl
    {
        private ThemMon preComponent;
        public ucCardFood(ThemMon f, string ten, int soluong)
        {
            InitializeComponent();
            label1.Text = ten;
            label2.Text = "" + soluong;
            preComponent = f;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            label2.Text = "" + (Convert.ToInt32(label2.Text) + 1);
            preComponent.themMon(label1.Text, Convert.ToInt32(label2.Text));
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if(Convert.ToInt32(label2.Text) > 0)
            {
                label2.Text = "" + (Convert.ToInt32(label2.Text) - 1);
                preComponent.themMon(label1.Text, Convert.ToInt32(label2.Text));
            }
        }
    }
}
