using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCuaHangDienThoai.Models
{
    class GioHang
    {
        public int Id { get; set; }

        public string TaiKhoan { get; set; }

        public int IdDienThoai { get; set; }

        public bool DaDatHang { get; set; }

        public DateTime NgayThem { get; set; }
    }
}
