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
    public partial class ucKhoHang : UserControl
    {
        private bool status = true;//true: nhập kho, false: xuất kho
        private DataTable dt = new DataTable();
        //private List<nguyenlieu> ListAll;
        //private List<nhacungcap> ListSupplier;
        //private List<nguyenlieu> ListBySupplier = new List<nguyenlieu>();
        private List<string> listUnit = new List<string>();
        public ucKhoHang()
        {
            InitializeComponent();
            //ComboBox nhà cung cấp
            //cbSupplier.DataSource = ListSupplier;
            //cbSupplier.ValueMember = "mancc";
            //cbSupplier.DisplayMember = "tenncc";
            //cbSupplier.SelectedIndex = -1;
        }

        private void ucKhoHang_Load(object sender, EventArgs e)
        {
            //ListAll = context.nguyenlieux.ToList();
            if (checkBox1.Checked)
            {
                dt.Columns.Add("Mã NL", System.Type.GetType("System.String"));
                dt.Columns.Add("Tên NL", System.Type.GetType("System.String"));
                dt.Columns.Add("ĐVT", System.Type.GetType("System.String"));
                dt.Columns.Add("Đơn Giá", System.Type.GetType("System.Int32"));
                dt.Columns.Add("Nhà Cung Cấp", System.Type.GetType("System.String"));
                //dgv.DataSource = ListAll;
                //LoadDataTable(ListAll);
                dgv.DataSource = dt;
                dgv.Columns[0].Width = 66;
                dgv.Columns[1].Width = 130;
                dgv.Columns[2].Width = 46;
                dgv.Columns[3].Width = 76;
                dgv.Columns[4].Width = 110;
            }
            
        }

        private void rjButton2_Click_1(object sender, EventArgs e)
        {
            if (status)
            {
                rjButton2.Text = "Nhập Kho";
                rjButton3.Text = "Xuất Kho";
            }
            else
            {
                rjButton2.Text = "Xuất Kho";
                rjButton3.Text = "Nhập Kho";
            }
            status = !status;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            //Check xem tất cả
            if(checkBox1.Checked)
            {
                //LoadDataTable(ListAll);
            }
            else
            {
                dt.Rows.Clear();
                dgv.DataSource = dt;
            }
        }

        //public void LoadDataTable(List<nguyenlieu> list)
        //{
            //for (int i = 0; i < list.Count; i++)
            //{
                //dt.Rows.Add(new object[]
                //{
                    //list[i].manl,
                    //list[i].tennl,
                    //list[i].dvt,
                    //list[i].giatien,
                    //ListSupplier.Find(item=>item.mancc == list[i].mancc).tenncc,
                //});
            //}
        //}

        private void cbSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*if (ListSupplier!=null&& ListAll!=null&& cbSupplier.SelectedIndex!=-1)
            {
                cbName.Enabled = true;
                ListBySupplier.Clear();
                ListAll.ForEach(item =>
                {
                    if (item.mancc == ListSupplier[cbSupplier.SelectedIndex].mancc)
                    {
                        ListBySupplier.Add(item);
                    }
                    if (!listUnit.Contains(item.dvt))
                    {
                        listUnit.Add(item.dvt);
                    }
                });
                cbName.DataSource = null;
                cbName.DataSource = ListBySupplier;
                cbName.ValueMember = "manl";
                cbName.DisplayMember = "tennl";
                cbUnit.DataSource = listUnit;
            }*/
        }

        private void cbName_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*if (cbName.SelectedIndex != -1)
            {
                txtId.Text = "" + ListBySupplier[cbName.SelectedIndex].manl;
                nudPrice.Value = ListBySupplier[cbName.SelectedIndex].giatien;
                int quantity = context.Database.SqlQuery<int>("execute sp_LayRaTonKhoCuaNguyenLieu {0}", ListBySupplier[cbName.SelectedIndex].manl).FirstOrDefault(); ;
                nudQuantity.Value = quantity;
                //Console.WriteLine(listUnit[listUnit.FindIndex(item => item == ListBySupplier[cbName.SelectedIndex].dvt)]);
                cbUnit.DataSource = listUnit;
                cbUnit.SelectedIndex = listUnit.FindIndex(item => item == ListBySupplier[cbName.SelectedIndex].dvt);
            }*/
        }

        private void cbSupplier_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void rjButton6_Click(object sender, EventArgs e)
        {
            cbSupplier.SelectedIndex = -1;
            txtId.Text = "";
            cbName.SelectedIndex = -1;
            cbName.Enabled = false;
            cbUnit.SelectedIndex = -1;
            cbUnit.Enabled = false;
            nudPrice.Value = 0;
            nudPrice.Enabled = false;
            nudQuantity.Value = 0;
            nudQuantity.Enabled = false;
        }
    }
}
