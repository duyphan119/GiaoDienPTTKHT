using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL.Model
{
    public class NhaCungCap
    {
        public int ma;
        public string ten, diachi, sdt;

        public NhaCungCap()
        {
        }

        public NhaCungCap(int ma, string ten, string diachi, string sdt)
        {
            this.ma = ma;
            this.ten = ten;
            this.diachi = diachi;
            this.sdt = sdt;
        }
    }
}
