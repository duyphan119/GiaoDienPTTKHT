using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL.Model
{
    public class Phieu
    {
        public int sophieu;
        public NhanVien nv;
        public DateTime ngay;
        public List<ChiTietPhieu> list = new List<ChiTietPhieu>();

        public Phieu()
        {
        }

        public Phieu(int s, DateTime d, NhanVien x, List<ChiTietPhieu> list)
        {
            sophieu = s;
            ngay = d;
            nv = x;
            this.list = list;
        }

        public int getTotalPrice()
        {
            int result = 0;
            list.ForEach(item =>
            {
                result += (item.soluong * item.nl.gia);
            });
            return result;
        }
    }
}
