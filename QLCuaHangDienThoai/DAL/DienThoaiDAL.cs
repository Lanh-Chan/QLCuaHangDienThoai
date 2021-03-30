using System.Collections.Generic;
using System.Data;
using QLCuaHangDienThoai.Entity;
using QLCuaHangDienThoai.Models;

namespace QLCuaHangDienThoai.DAL
{
    class DienThoaiDAL
    {
        private static DienThoai tmp;
        private static DataTable data;

        public static List<DienThoai> LayTatCa()
        {
            List<DienThoai> listItems = new List<DienThoai>();
            data = new DataTable();
            string strQuery = "Select DT.Id, DT.Ten, DT.MoTa, SoLuong, UrlHinhAnh, Gia, IdLoaiDienThoai, LDT.Ten as LoaiDienThoai from DienThoai as DT join LoaiDienThoai as LDT on DT.IdLoaiDienThoai = LDT.Id";
            data = SQLServer.LayDuLieu(strQuery);
            foreach (DataRow item in data.Rows)
            {
                tmp = new DienThoai
                {
                    Id = (int)item["Id"],
                    Ten = item["Ten"].ToString(),
                    MoTa = item["MoTa"].ToString(),
                    SoLuong = (int)item["SoLuong"],
                    Gia = (int)item["Gia"],
                    UrlHinhAnh = item["UrlHinhAnh"].ToString(),
                    LoaiDienThoai = item["LoaiDienThoai"].ToString(),
                    IdLoaiDienThoai = (int)item["IdLoaiDienThoai"]
                };

                listItems.Add(tmp);
            }
            return listItems;
        }

        public static List<DienThoai> LayTheoLoaiDienThoai(int IdLoaiDienThoai)
        {
            List<DienThoai> listItems = new List<DienThoai>();
            data = new DataTable();
            string strQuery = "Select DT.Id, DT.Ten, DT.MoTa, SoLuong, UrlHinhAnh, Gia, IdLoaiDienThoai, LDT.Ten as LoaiDienThoai from DienThoai as DT join LoaiDienThoai as LDT on DT.IdLoaiDienThoai = LDT.Id Where LDT.Id=" + IdLoaiDienThoai.ToString();
            data = SQLServer.LayDuLieu(strQuery);
            foreach (DataRow item in data.Rows)
            {
                tmp = new DienThoai
                {
                    Id = (int)item["Id"],
                    Ten = item["Ten"].ToString(),
                    MoTa = item["MoTa"].ToString(),
                    SoLuong = (int)item["SoLuong"],
                    Gia = (int)item["Gia"],
                    UrlHinhAnh = item["UrlHinhAnh"].ToString(),
                    LoaiDienThoai = item["LoaiDienThoai"].ToString(),
                    IdLoaiDienThoai = (int)item["IdLoaiDienThoai"]
                };

                listItems.Add(tmp);
            }
            return listItems;
        }

        public static List<DienThoai> LayTheoTenDienThoai(string TenDienThoai)
        {
            List<DienThoai> listItems = new List<DienThoai>();
            data = new DataTable();
            string strQuery = "Select DT.Id, DT.Ten, DT.MoTa, SoLuong, UrlHinhAnh, Gia, IdLoaiDienThoai, LDT.Ten as LoaiDienThoai from DienThoai as DT join LoaiDienThoai as LDT on DT.IdLoaiDienThoai = LDT.Id Where DT.Ten like '%" + TenDienThoai + "%'";
            data = SQLServer.LayDuLieu(strQuery);
            foreach (DataRow item in data.Rows)
            {
                tmp = new DienThoai
                {
                    Id = (int)item["Id"],
                    Ten = item["Ten"].ToString(),
                    MoTa = item["MoTa"].ToString(),
                    SoLuong = (int)item["SoLuong"],
                    Gia = (int)item["Gia"],
                    UrlHinhAnh = item["UrlHinhAnh"].ToString(),
                    LoaiDienThoai = item["LoaiDienThoai"].ToString(),
                    IdLoaiDienThoai = (int)item["IdLoaiDienThoai"]
                };

                listItems.Add(tmp);
            }
            return listItems;
        }

        public static DienThoai LayTheoId(string Id)
        {
            data = new DataTable();
            string strQuery = "select * from DienThoai where Id = '" + Id + "'";
            data = SQLServer.LayDuLieu(strQuery);
            if (data.Rows.Count > 0)
            {
                tmp = new DienThoai
                {
                    Id = (int)data.Rows[0]["Id"],
                    Ten = data.Rows[0]["Ten"].ToString(),
                    MoTa = data.Rows[0]["MoTa"].ToString(),
                    SoLuong = (int)data.Rows[0]["SoLuong"],
                    Gia = (int)data.Rows[0]["Gia"],
                    UrlHinhAnh = data.Rows[0]["UrlHinhAnh"].ToString(),
                    LoaiDienThoai = data.Rows[0]["LoaiDienThoai"].ToString(),
                    IdLoaiDienThoai = (int)data.Rows[0]["IdLoaiDienThoai"]
                };
                return tmp;
            }
            return null;
        }

        public static bool CapNhat(DienThoai item)
        {
            string strQuery = "Update DienThoai set " +
                "Ten=N'" + item.Ten + "', " +
                "MoTa=N'" + item.MoTa + "', " +
                "SoLuong='" + item.SoLuong + "', " +
                "Gia='" + item.Gia + "', " +
                "UrlHinhAnh='" + item.UrlHinhAnh + "', " +
                "IdLoaiDienThoai='" + item.IdLoaiDienThoai + "'" +
                "where Id='" + item.Id + "'";

            return SQLServer.ThucHienCauLenh(strQuery);
        }

        public static bool CapNhatSoLuong(DienThoai item)
        {
            string strQuery = "Update DienThoai set " +
                "SoLuong='" + item.SoLuong + "'" +
                "where Id='" + item.Id + "'";

            return SQLServer.ThucHienCauLenh(strQuery);
        }

        public static bool Xoa(int Id)
        {
            string strQuery = "Delete from DienThoai where Id='" + Id + "'";

            return SQLServer.ThucHienCauLenh(strQuery);
        }

        public static bool ThemMoi(DienThoai item)
        {
            string strQuery = "Insert into DienThoai values(" +
                "N'" + item.Ten + "', " +
                "N'" + item.MoTa + "', " +
                "'" + item.SoLuong + "', " +
                "'" + item.UrlHinhAnh + "', " +
                "'" + item.Gia + "', " +
                "'" + item.IdLoaiDienThoai + "')";

            return SQLServer.ThucHienCauLenh(strQuery);
        }
    }
}
