using System;
using System.Drawing;
using System.Windows.Forms;
using QLCuaHangDienThoai.DAL;
using QLCuaHangDienThoai.Models;

namespace QLCuaHangDienThoai.GUI
{
    public partial class DangKyTaiKhoan : Form
    {
        public DangKyTaiKhoan()
        {
            InitializeComponent();
            cbbGioiTinh.Text = "Nam";
        }

        private void btnThemMoiTK_Click(object sender, EventArgs e)
        {
            bool gt = false;
            if (cbbGioiTinh.Text == "Nam")
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

            bool rs = TaiKhoanDAL.ThemMoi(tmp);
            if (rs)
            {

                DangNhap dangNhapForm = new DangNhap();
                this.Hide();
                dangNhapForm.ShowDialog();
                this.Close();

            }
            else
            {
                lbThongBao.ForeColor = Color.Red;
                lbThongBao.Text = "Thất Bại! Tên tài khoản đã tồn tại";
            }
        }
    }
}
