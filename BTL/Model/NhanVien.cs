using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL.Model
{
    public class NhanVien
    {
        public int ma;
        public string ten, gioitinh, sdt, chucvu, quyen, matkhau;
        public DateTime ngaysinh;

        public NhanVien()
        {
        }

        public NhanVien(string ten, DateTime ngaysinh, string gioitinh, int ma, string sdt, string chucvu, string quyen, string matkhau)
        {
            this.ten = ten;
            this.ngaysinh = ngaysinh;
            this.gioitinh = gioitinh;
            this.ma = ma;
            this.sdt = sdt;
            this.chucvu = chucvu;
            this.quyen = quyen;
            this.matkhau = matkhau;
        }
    }
}
