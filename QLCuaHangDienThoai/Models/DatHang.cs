using System;

namespace QLCuaHangDienThoai.Models
{
    class DatHang
    {
        public int Id { get; set; }

        public string TaiKhoan { get; set; }

        public int IdDienThoai { get; set; }

        public int TrangThai { get; set; }

        public DateTime NgayTao { get; set; }

        public int TongTien { get; set; }

        public DienThoai _DienThoai { get; set; }
    }
}
