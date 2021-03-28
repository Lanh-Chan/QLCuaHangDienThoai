using System;
using System.Windows.Forms;
using QLCuaHangDienThoai.DAL;
using QLCuaHangDienThoai.Models;

namespace QLCuaHangDienThoai.GUI
{
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            this.XulyDangnhap();
        }


        private void tbMatKhau_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                XulyDangnhap();
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // xử lý khi người dùng ấn đăng nhập hoặc enter password
        private void XulyDangnhap()
        {
            var taiKhoan = TaiKhoanDAL.DangNhap(tbTaiKhoan.Text, tbMatKhau.Text);

            tbTaiKhoan.Focus();
            if (taiKhoan == null)
            {
                LbThongBao.Text = "Tài khoản / Mật khẩu không đúng !";
            }
            else
            {
                LbThongBao.Text = "";
                tbTaiKhoan.Text = "";
                tbMatKhau.Text = "";

                TaiKhoan.taiKhoanSession = new TaiKhoan()
                {
                    TenTaiKhoan = taiKhoan.TenTaiKhoan,
                    MatKhau = taiKhoan.MatKhau,
                    HoTen = taiKhoan.HoTen,
                    GioiTinh = taiKhoan.GioiTinh,
                    SoDienThoai = taiKhoan.SoDienThoai,
                    Email = taiKhoan.Email,
                    DiaChi = taiKhoan.DiaChi,
                    IsAdmin = taiKhoan.IsAdmin
                };
                if (taiKhoan.IsAdmin)
                {
                    Admin adminForm = new Admin();
                    this.Hide();
                    adminForm.ShowDialog();
                    this.Close();
                }
                else
                {
                    TrangChu trangChuForm = new TrangChu();
                    this.Hide();
                    trangChuForm.ShowDialog();
                    this.Close();
                }

            }
        }

    }
}
