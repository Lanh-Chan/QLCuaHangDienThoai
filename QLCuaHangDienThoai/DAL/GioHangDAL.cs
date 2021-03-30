using System;
using System.Collections.Generic;
using System.Data;
using QLCuaHangDienThoai.Entity;
using QLCuaHangDienThoai.Models;

namespace QLCuaHangDienThoai.DAL
{
    class GioHangDAL
    {
        private static GioHang tmp;
        private static DataTable data;

        public static List<GioHang> LayTatCa()
        {
            List<GioHang> listItems = new List<GioHang>();
            data = new DataTable();
            string strQuery = "select * from GioHang";
            data = SQLServer.LayDuLieu(strQuery);
            foreach (DataRow item in data.Rows)
            {
                tmp = new GioHang
                {
                    Id = (int)item["Id"],
                    TaiKhoan = item["TaiKhoan"].ToString(),
                    IdDienThoai = (int)item["IdDienThoai"],
                    DaDatHang = (bool)item["DaDatHang"],
                    NgayThem = (DateTime)item["NgayThem"]
                };

                listItems.Add(tmp);
            }
            return listItems;
        }

        public static List<GioHang> LayTheoTaiKhoan(string TenTaiKhoan)
        {
            List<GioHang> listItems = new List<GioHang>();
            data = new DataTable();
            string strQuery = "select GH.Id as IdGioHang, TaiKhoan, IdDienThoai, DaDatHang, NgayThem, DT.Id as IdDienThoai, DT.Ten as TenDienThoai, DT.Gia, DT.UrlHinhAnh, DT.SoLuong from GioHang as GH join DienThoai as DT on GH.IdDienThoai = DT.Id  where GH.TaiKhoan = '" + TenTaiKhoan + "' and GH.DaDatHang = 0";
            data = SQLServer.LayDuLieu(strQuery);
            foreach (DataRow item in data.Rows)
            {
                tmp = new GioHang
                {
                    Id = (int)item["IdGioHang"],
                    TaiKhoan = item["TaiKhoan"].ToString(),
                    IdDienThoai = (int)item["IdDienThoai"],
                    DaDatHang = (bool)item["DaDatHang"],
                    NgayThem = (DateTime)item["NgayThem"],
                    _DienThoai = new DienThoai
                    {
                        Id = (int)item["IdDienThoai"],
                        Gia = (int)item["Gia"],
                        SoLuong = (int)item["SoLuong"],
                        Ten = item["TenDienThoai"].ToString(),
                        UrlHinhAnh = item["UrlHinhAnh"].ToString(),
                    }
                };

                listItems.Add(tmp);
            }
            return listItems;
        }

        public static GioHang CheckGioHang(string TaiKhoan, int IdDienThoai)
        {
            data = new DataTable();
            string strQuery = "select * from GioHang where TaiKhoan = '" + TaiKhoan + "' and IdDienThoai = '" + IdDienThoai + "'";
            data = SQLServer.LayDuLieu(strQuery);
            if (data.Rows.Count > 0)
            {
                tmp = new GioHang
                {
                    Id = (int)data.Rows[0]["Id"],
                    TaiKhoan = data.Rows[0]["TaiKhoan"].ToString(),
                    IdDienThoai = (int)data.Rows[0]["IdDienThoai"],
                    DaDatHang = (bool)data.Rows[0]["DaDatHang"],
                    NgayThem = (DateTime)data.Rows[0]["NgayThem"]
                };
                return tmp;
            }
            return null;
        }

        public static bool Xoa(int Id)
        {
            string strQuery = "Delete from GioHang where Id='" + Id + "'";

            return SQLServer.ThucHienCauLenh(strQuery);
        }

        public static bool ThemMoi(GioHang item)
        {
            string strQuery = "Insert into GioHang values(" +
                "'" + item.TaiKhoan + "', " +
                "'" + item.IdDienThoai + "', " +
                "'" + item.DaDatHang + "', " +
                "'" + item.NgayThem + "')";

            return SQLServer.ThucHienCauLenh(strQuery);
        }
    }
}
