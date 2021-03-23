using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using QLCuaHangDienThoai.Entity;
using QLCuaHangDienThoai.Models;

namespace QLCuaHangDienThoai.DAL
{
    class TaiKhoanDAL
    {
        private static TaiKhoan tmp;
        private static DataTable data;

        public static TaiKhoan DangNhap(string TaiKhoan, string MatKhau)
        {
            data = new DataTable();
            string strQuery = "spDangNhap '" + TaiKhoan + "', '" + MatKhau + "'";
            data = SQLServer.LayDuLieu(strQuery);
            if (data.Rows.Count > 0)
            {
                tmp = new TaiKhoan
                {
                    TenTaiKhoan = data.Rows[0]["TenTaiKhoan"].ToString(),
                    MatKhau = data.Rows[0]["MatKhau"].ToString(),
                    HoTen = data.Rows[0]["HoTen"].ToString(),
                    GioiTinh = (bool)data.Rows[0]["GioiTinh"],
                    SoDienThoai = data.Rows[0]["SoDienThoai"].ToString(),
                    Email = data.Rows[0]["Email"].ToString(),
                    DiaChi = data.Rows[0]["DiaChi"].ToString(),
                    IsAdmin = (bool)data.Rows[0]["IsAdmin"]
                };
                return tmp;
            }
            return null;
        }

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
                    TenTaiKhoan = item["TenTaiKhoan"].ToString(),
                    MatKhau = item["MatKhau"].ToString(),
                    HoTen = item["HoTen"].ToString(),
                    GioiTinh = (bool)item["GioiTinh"],
                    SoDienThoai = item["SoDienThoai"].ToString(),
                    Email = item["Email"].ToString(),
                    DiaChi = item["DiaChi"].ToString(),
                    IsAdmin = (bool)item["IsAdmin"],
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
                    TenTaiKhoan = data.Rows[0]["TenTaiKhoan"].ToString(),
                    MatKhau = data.Rows[0]["MatKhau"].ToString(),
                    HoTen = data.Rows[0]["HoTen"].ToString(),
                    GioiTinh = (bool)data.Rows[0]["GioiTinh"],
                    SoDienThoai = data.Rows[0]["SoDienThoai"].ToString(),
                    Email = data.Rows[0]["Email"].ToString(),
                    DiaChi = data.Rows[0]["DiaChi"].ToString(),
                    IsAdmin = (bool)data.Rows[0]["IsAdmin"]
                };
                return tmp;
            }
            return null;
        }

        public static bool CapNhat(TaiKhoan item)
        {
            string strQuery = "Update TaiKhoan set " +
                "MatKhau='" + item.MatKhau + "', " +
                "HoTen=N'" + item.HoTen + "', " +
                "GioiTinh='" + item.GioiTinh + "', " +
                "SoDienThoai='" + item.SoDienThoai + "', " +
                "Email='" + item.Email + "', " +
                "DiaChi=N'" + item.DiaChi + "', " +
                "IsAdmin='" + item.IsAdmin + "' " +
                "where TenTaiKhoan='" + item.TenTaiKhoan + "'";

            return SQLServer.ThucHienCauLenh(strQuery);
        }

        public static bool Xoa(string TenTaiKhoan)
        {
            string strQuery = "Delete from TaiKhoan where TenTaiKhoan='" + TenTaiKhoan + "'";

            return SQLServer.ThucHienCauLenh(strQuery);
        }

        public static bool ThemMoi(TaiKhoan item)
        {
            string strQuery = "Insert into TaiKhoan values(" +
                "'" + item.TenTaiKhoan + "', " +
                "'" + item.MatKhau + "', " +
                "N'" + item.HoTen + "', " +
                "'" + item.GioiTinh + "', " +
                "'" + item.SoDienThoai + "', " +
                "'" + item.Email + "', " +
                "N'" + item.DiaChi + "', " +
                "'" + item.IsAdmin + "')";

            return SQLServer.ThucHienCauLenh(strQuery);
        }

    }
}
