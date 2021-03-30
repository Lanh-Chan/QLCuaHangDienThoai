using System;
using System.Collections.Generic;
using System.Data;
using QLCuaHangDienThoai.Entity;
using QLCuaHangDienThoai.Models;

namespace QLCuaHangDienThoai.DAL
{
    class DatHangDAL
    {
        private static DatHang tmp;
        private static DataTable data;

        public static List<DatHang> LayTatCa()
        {
            List<DatHang> listItems = new List<DatHang>();
            data = new DataTable();
            string strQuery = "select * from DatHang";
            data = SQLServer.LayDuLieu(strQuery);
            foreach (DataRow item in data.Rows)
            {
                tmp = new DatHang
                {
                    Id = (int)item["Id"],
                    TaiKhoan = item["TaiKhoan"].ToString(),
                    TrangThai = (int)item["TrangThai"],
                    NgayTao = (DateTime)item["NgayTao"],
                    TongTien = (int)item["TongTien"]
                };

                listItems.Add(tmp);
            }
            return listItems;
        }

        public static List<DatHang> LayTheoTaiKhoan(string taiKhoan)
        {
            List<DatHang> listItems = new List<DatHang>();
            data = new DataTable();
            string strQuery = "select DH.Id as IdDatHang, TaiKhoan, IdDienThoai, TrangThai, NgayTao, TongTien, DT.Id as IdDienThoai, DT.Ten as TenDienThoai, DT.Gia, DT.UrlHinhAnh, DT.SoLuong from DatHang as DH join DienThoai as DT on DH.IdDienThoai = DT.Id  where DH.TaiKhoan = '" + taiKhoan + "'";
            data = SQLServer.LayDuLieu(strQuery);
            foreach (DataRow item in data.Rows)
            {
                tmp = new DatHang
                {
                    Id = (int)item["IdDatHang"],
                    TaiKhoan = item["TaiKhoan"].ToString(),
                    TrangThai = (int)item["TrangThai"],
                    NgayTao = (DateTime)item["NgayTao"],
                    TongTien = (int)item["TongTien"],
                    IdDienThoai = (int)item["IdDienThoai"],
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

        public static DatHang LayTheoId(string Id)
        {
            data = new DataTable();
            string strQuery = "select * from DatHang where Id = '" + Id + "'";
            data = SQLServer.LayDuLieu(strQuery);
            if (data.Rows.Count > 0)
            {
                tmp = new DatHang
                {
                    Id = (int)data.Rows[0]["Id"],
                    TaiKhoan = data.Rows[0]["TaiKhoan"].ToString(),
                    TrangThai = (int)data.Rows[0]["TrangThai"],
                    NgayTao = (DateTime)data.Rows[0]["NgayTao"],
                    TongTien = (int)data.Rows[0]["TongTien"],
                    IdDienThoai = (int)data.Rows[0]["IdDienThoai"]
                };
                return tmp;
            }
            return null;
        }

        public static bool Xoa(int Id)
        {
            string strQuery = "Delete from DatHang where Id='" + Id + "'";

            return SQLServer.ThucHienCauLenh(strQuery);
        }

        public static bool ThemMoi(DatHang item)
        {
            string strQuery = "Insert into DatHang values(" +
                "'" + item.TaiKhoan + "', " +
                "'" + item.IdDienThoai + "', " +
                "'" + item.TrangThai + "', " +
                "'" + item.NgayTao + "', " +
                "'" + item.TongTien + "')";

            return SQLServer.ThucHienCauLenh(strQuery);
        }

        public static bool CapNhatTrangThai(DatHang item)
        {
            string strQuery = "Update DatHang set " +
                "TrangThai='" + item.TrangThai + "'" +
                "where Id='" + item.Id + "'";

            return SQLServer.ThucHienCauLenh(strQuery);
        }
    }
}
