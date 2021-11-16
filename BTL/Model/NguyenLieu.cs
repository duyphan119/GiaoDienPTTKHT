using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL.Model
{
    public class NguyenLieu
    {
        public int ma, gia;
        public string ten, dvt;
        public NhaCungCap ncc;

        public NguyenLieu()
        {
        }

        public NguyenLieu(int ma, int gia, string ten, string dvt, NhaCungCap ncc)
        {
            this.ma = ma;
            this.gia = gia;
            this.ten = ten;
            this.dvt = dvt;
            this.ncc = ncc;
        }
    }
}
