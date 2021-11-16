using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL.Model
{
    public class ChiTietPhieu
    {
        public NguyenLieu nl;
        public int soluong = 0;

        public ChiTietPhieu()
        {
        }

        public ChiTietPhieu(NguyenLieu nl, int soluong)
        {
            this.nl = nl;
            this.soluong = soluong;
        }
    }
}
