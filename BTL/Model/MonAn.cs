using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL.Model
{
    public class MonAn
    {
        public string ten, dvt;
        public int gia, mamon;
        public NhomMon nhom;

        public MonAn() { }
        public MonAn(NhomMon nhom, int mamon, string ten, string dvt, int gia)
        {
            this.nhom = nhom;
            this.mamon = mamon;
            this.ten = ten;
            this.dvt = dvt;
            this.gia = gia;
        }
    }
}
