using System.Windows.Forms;
using QLCuaHangDienThoai.Models;

namespace QLCuaHangDienThoai
{
    public partial class TrangChu : Form
    {
        public TrangChu()
        {
            InitializeComponent();
            lbTaiKhoan.Text = TaiKhoan.taiKhoanSession.HoTen;
        }
    }
}
