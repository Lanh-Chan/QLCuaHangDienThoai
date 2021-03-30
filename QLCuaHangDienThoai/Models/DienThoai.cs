
namespace QLCuaHangDienThoai.Models
{
    class DienThoai
    {
        public int Id { get; set; }
        public string Ten { get; set; }
        public string MoTa { get; set; }
        public int SoLuong { get; set; }
        public int Gia { get; set; }
        public string UrlHinhAnh { get; set; }
        public int IdLoaiDienThoai { get; set; }
        public string LoaiDienThoai { get; set; }
    }
}
