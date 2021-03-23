
namespace QLCuaHangDienThoai.Models
{
    class LoaiDienThoai
    {
        public int Id { get; set; }
        public string Ten { get; set; }
        public string MoTa { get; set; }

        public override string ToString()
        {
            return Ten;
        }
    }
}
