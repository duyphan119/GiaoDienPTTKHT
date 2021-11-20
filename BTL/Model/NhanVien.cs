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
        public string ten, gioitinh, sdt, chucvu, diachi, matkhau;
        public DateTime ngaysinh;

        public NhanVien()
        {
        }

        public NhanVien(int ma,  string ten, DateTime ngaysinh, string gioitinh, string diachi, string sdt, string chucvu,  string matkhau)
        {
            this.ma = ma;
            this.ten = ten;
            this.ngaysinh = ngaysinh;
            this.gioitinh = gioitinh;
            this.diachi = diachi;
            this.sdt = sdt;
            this.chucvu = chucvu;
            this.matkhau = matkhau;
        }
    }
}
