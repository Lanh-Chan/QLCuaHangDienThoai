using System.Collections.Generic;
using System.Data;
using QLCuaHangDienThoai.Entity;
using QLCuaHangDienThoai.Models;

namespace QLCuaHangDienThoai.DAL
{
    class GioHangDAL
    {
        private static TaiKhoan tmp;
        private static DataTable data;

        public static List<TaiKhoan> LayTatCa()
        {
            List<TaiKhoan> listItems = new List<TaiKhoan>();
            data = new DataTable();
            string strQuery = "select * from TaiKhoan";
            data = SQLServer.LayDuLieu(strQuery);
            foreach (DataRow item in data.Rows)
            {
                tmp = new TaiKhoan
                {
                    TenTaiKhoan = item["MaGiaoVien"].ToString(),
                    MatKhau = item["MatKhau"].ToString(),
                    HoTen = item["QueQuan"].ToString(),
                    GioiTinh = (bool)item["QueQuan"],
                    SoDienThoai = item["QueQuan"].ToString(),
                    Email = item["DiaChi"].ToString(),
                    DiaChi = item["DiaChi"].ToString(),
                    IsAdmin = (bool)item["DiaChi"],
                };

                listItems.Add(tmp);
            }
            return listItems;
        }

        public static TaiKhoan LayTheoId(string Id)
        {
            data = new DataTable();
            string strQuery = "select * from TaiKhoan where TenTaiKhoan = '" + Id + "'";
            data = SQLServer.LayDuLieu(strQuery);
            if (data.Rows.Count > 0)
            {
                tmp = new TaiKhoan
                {
                    TenTaiKhoan = data.Rows[0]["MaGiaoVien"].ToString(),
                    MatKhau = data.Rows[0]["MatKhau"].ToString(),
                    HoTen = data.Rows[0]["QueQuan"].ToString(),
                    GioiTinh = (bool)data.Rows[0]["QueQuan"],
                    SoDienThoai = data.Rows[0]["QueQuan"].ToString(),
                    Email = data.Rows[0]["DiaChi"].ToString(),
                    DiaChi = data.Rows[0]["DiaChi"].ToString(),
                    IsAdmin = (bool)data.Rows[0]["DiaChi"]
                };
                return tmp;
            }
            return null;
        }
    }
}
