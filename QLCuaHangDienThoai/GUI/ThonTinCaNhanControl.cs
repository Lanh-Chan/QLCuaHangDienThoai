using System;
using System.Windows.Forms;
using QLCuaHangDienThoai.DAL;
using QLCuaHangDienThoai.Models;

namespace QLCuaHangDienThoai.GUI
{
    public partial class ThonTinCaNhanControl : UserControl
    {
        public ThonTinCaNhanControl()
        {
            InitializeComponent();
            LoadThonTin();
        }

        private void LoadThonTin()
        {
            tbTenTK.Text = TaiKhoan.taiKhoanSession.TenTaiKhoan;
            tbMatKhau.Text = TaiKhoan.taiKhoanSession.MatKhau;
            tbHoTen.Text = TaiKhoan.taiKhoanSession.HoTen;

            if (TaiKhoan.taiKhoanSession.GioiTinh)
                cbbGT.Text = "Nam";
            else
                cbbGT.Text = "Nữ";

            tbSDT.Text = TaiKhoan.taiKhoanSession.SoDienThoai;
            tbEmail.Text = TaiKhoan.taiKhoanSession.Email;
            tbDiaChi.Text = TaiKhoan.taiKhoanSession.DiaChi;
        }

        private void btnCapNhatTK_Click(object sender, EventArgs e)
        {
            bool gt = false;
            if (cbbGT.Text == "Nam")
                gt = true;

            TaiKhoan tmp = new TaiKhoan
            {
                TenTaiKhoan = tbTenTK.Text,
                MatKhau = tbMatKhau.Text,
                HoTen = tbHoTen.Text,
                GioiTinh = gt,
                SoDienThoai = tbSDT.Text,
                Email = tbEmail.Text,
                DiaChi = tbDiaChi.Text,
                IsAdmin = false
            };

            bool rs = TaiKhoanDAL.CapNhat(tmp);

            if (rs)
            {
                MessageBox.Show("Cập Nhật Thông Tin Thành Công");
                TaiKhoan.taiKhoanSession = tmp;
            }
            else
            {
                MessageBox.Show("Lỗi, Cập Nhật Thông Tin Thất Bại");
            }

        }
    }
}
