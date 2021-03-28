
namespace QLCuaHangDienThoai.Models
{
    class TaiKhoan
    {
        public string TenTaiKhoan { get; set; }
        public string MatKhau { get; set; }
        public string HoTen { get; set; }
        public bool GioiTinh { get; set; }
        public string SoDienThoai { get; set; }
        public string Email { get; set; }
        public string DiaChi { get; set; }
        public bool IsAdmin { get; set; }

        public static TaiKhoan taiKhoanSession = new TaiKhoan()
        {
            TenTaiKhoan = "",
            MatKhau = "",
            HoTen = "",
            GioiTinh = true,
            SoDienThoai = "",
            Email = "",
            DiaChi = "",
            IsAdmin = false
        };

    }
}
