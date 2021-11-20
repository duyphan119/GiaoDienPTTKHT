using BTL.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL.DAO
{
    public class DAO_NhanVien
    {
        private SqlConnection cnn;
        private SqlCommand scm;
        private SqlDataReader reader;

        public DAO_NhanVien()
        {
            ConnectDatabase ConnectDB = new ConnectDatabase();
            cnn = ConnectDB.Connect();
        }

        public List<NhanVien> getAll()
        {
            List<NhanVien> result = new List<NhanVien>();
            cnn.Open();
            scm = new SqlCommand("select * from nhanvien", cnn);
            reader = scm.ExecuteReader();
            while (reader.Read())
            {
                int ma = reader.GetInt32(0);
                string tennv = reader.GetString(1);
                DateTime ngaysinh = reader.GetDateTime(2);
                string gioitinh = reader.GetString(3);
                string diachi = reader.GetString(4);
                string sdt = reader.GetString(5);
                string chucvu = reader.GetString(6);
                string mk = reader.GetString(7);
                NhanVien nv = new NhanVien(
                    ma,
                    tennv,
                    ngaysinh,
                    gioitinh,
                    diachi,
                    sdt,
                    chucvu,
                    mk
                );
                result.Add(nv);
            }
            cnn.Close();
            return result;
        }

        public void deleteById(int id)
        {
            cnn.Open();
            scm = new SqlCommand($"delete from nhanvien where manv = {id}" , cnn);
            scm.ExecuteNonQuery();
            cnn.Close();
        }

        public NhanVien login(int manv, string matkhau)
        {
            cnn.Open();
            scm = new SqlCommand($"select * from nhanvien where manv = {manv} and matkhau = '{matkhau}'", cnn);
            reader = scm.ExecuteReader();
            if (reader.Read())
            {
                int ma = reader.GetInt32(0);
                string tennv = reader.GetString(1);
                DateTime ngaysinh = reader.GetDateTime(2);
                string gioitinh = reader.GetString(3);
                string diachi = reader.GetString(4);
                string sdt = reader.GetString(5);
                string chucvu = reader.GetString(6);
                string mk = reader.GetString(7);
                NhanVien nv = new NhanVien(
                    ma,
                    tennv,
                    ngaysinh,
                    gioitinh,
                    diachi,
                    sdt,
                    chucvu,
                    mk
                );
                cnn.Close();
                return nv;
            }
            else
            {
                cnn.Close();
                return null;
            }
            
        }
    }
}
