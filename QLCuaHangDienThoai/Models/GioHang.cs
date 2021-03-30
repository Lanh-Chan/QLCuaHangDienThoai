using System;

namespace QLCuaHangDienThoai.Models
{
    class GioHang
    {
        public int Id { get; set; }

        public string TaiKhoan { get; set; }

        public int IdDienThoai { get; set; }

        public bool DaDatHang { get; set; }

        public DateTime NgayThem { get; set; }

        public DienThoai _DienThoai { get; set; }
    }
}
