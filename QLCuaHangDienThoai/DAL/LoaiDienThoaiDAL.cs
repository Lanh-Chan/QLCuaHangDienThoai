using System.Collections.Generic;
using System.Data;
using QLCuaHangDienThoai.Entity;
using QLCuaHangDienThoai.Models;

namespace QLCuaHangDienThoai.DAL
{
    class LoaiDienThoaiDAL
    {
        private static LoaiDienThoai tmp;
        private static DataTable data;

        public static List<LoaiDienThoai> LayTatCa()
        {
            List<LoaiDienThoai> listItems = new List<LoaiDienThoai>();
            data = new DataTable();
            string strQuery = "Select * from LoaiDienThoai";
            data = SQLServer.LayDuLieu(strQuery);
            foreach (DataRow item in data.Rows)
            {
                tmp = new LoaiDienThoai
                {
                    Id = (int)item["Id"],
                    Ten = item["Ten"].ToString(),
                    MoTa = item["MoTa"].ToString()
                };

                listItems.Add(tmp);
            }
            return listItems;
        }

        public static LoaiDienThoai LayTheoId(string Id)
        {
            data = new DataTable();
            string strQuery = "Select * from LoaiDienThoai where Id = '" + Id + "'";
            data = SQLServer.LayDuLieu(strQuery);
            if (data.Rows.Count > 0)
            {
                tmp = new LoaiDienThoai
                {
                    Id = (int)data.Rows[0]["Id"],
                    Ten = data.Rows[0]["Ten"].ToString(),
                    MoTa = data.Rows[0]["MoTa"].ToString()
                };
                return tmp;
            }
            return null;
        }

        public static bool CapNhat(LoaiDienThoai item)
        {
            string strQuery = "Update LoaiDienThoai set " +
                "Ten=N'" + item.Ten + "', " +
                "MoTa=N'" + item.MoTa + "'" +
                "where Id='" + item.Id + "'";

            return SQLServer.ThucHienCauLenh(strQuery);
        }

        public static bool Xoa(int Id)
        {
            string strQuery = "Delete from LoaiDienThoai where Id='" + Id + "'";

            return SQLServer.ThucHienCauLenh(strQuery);
        }

        public static bool ThemMoi(LoaiDienThoai item)
        {
            string strQuery = "Insert into LoaiDienThoai values(" +
                "N'" + item.Ten + "', " +
                "N'" + item.MoTa + "')";

            return SQLServer.ThucHienCauLenh(strQuery);
        }
    }
}
