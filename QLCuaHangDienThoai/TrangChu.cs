using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using QLCuaHangDienThoai.DAL;
using QLCuaHangDienThoai.GUI;
using QLCuaHangDienThoai.Models;

namespace QLCuaHangDienThoai
{
    public partial class TrangChu : Form
    {
        private TabPage tabGioHang, tabLichSuDatHang, tabTTCaNhan;
        private IList<DienThoai> listDienThoai;
        private IList<LoaiDienThoai> listLoaiDienThoai;
        public TrangChu()
        {
            InitializeComponent();
            tabGioHang = new TabPage("Giỏ Hàng");
            tabLichSuDatHang = new TabPage("Lịch Sử Đặt Hàng");
            tabTTCaNhan = new TabPage("Thông Tin Cá Nhân");
            checkLogin();
            listDienThoai = DienThoaiDAL.LayTatCa();
            listLoaiDienThoai = LoaiDienThoaiDAL.LayTatCa();

            TaoCBBLoaiDienThoai();
            LoadDienThoai(listDienThoai);

        }

        private void checkLogin()
        {
            if (TaiKhoan.taiKhoanSession.TenTaiKhoan == "")
            {
                lbDangNhap.Visible = true;
                lbDangKy.Visible = true;
                lbDangXuat.Visible = false;
                if (tabControlTrangChu.TabPages.Contains(tabGioHang))
                {
                    tabControlTrangChu.TabPages.Remove(tabGioHang);
                    tabControlTrangChu.TabPages.Remove(tabLichSuDatHang);
                    tabControlTrangChu.TabPages.Remove(tabTTCaNhan);
                }
            }
            else
            {
                lbDangNhap.Visible = false;
                lbDangKy.Visible = false;
                lbDangXuat.Visible = true;

                GioHangControl gioHangControl = new GioHangControl();
                gioHangControl.Dock = DockStyle.Fill;
                LichSuDatHangControl lichSuDatHangControl = new LichSuDatHangControl();
                lichSuDatHangControl.Dock = DockStyle.Fill;
                ThonTinCaNhanControl thonTinCaNhanControl = new ThonTinCaNhanControl();
                thonTinCaNhanControl.Dock = DockStyle.Fill;
                tabGioHang.Controls.Add(gioHangControl);
                tabLichSuDatHang.Controls.Add(lichSuDatHangControl);
                tabTTCaNhan.Controls.Add(thonTinCaNhanControl);
                tabControlTrangChu.TabPages.Add(tabGioHang);
                tabControlTrangChu.TabPages.Add(tabLichSuDatHang);
                tabControlTrangChu.TabPages.Add(tabTTCaNhan);
            }
        }

        private void TaoCBBLoaiDienThoai()
        {
            LoaiDienThoai tmpAll = new LoaiDienThoai
            {
                Id = 00,
                MoTa = "",
                Ten = "Tất Cả"
            };
            cbbLoaiDienThoai.Items.Add(tmpAll);

            foreach (var item in listLoaiDienThoai)
            {
                cbbLoaiDienThoai.Items.Add(item);
            }
            cbbLoaiDienThoai.Text = "Tất Cả";
        }

        private void LoadDienThoai(IList<DienThoai> listItems)
        {
            int i = 0;
            foreach (var item in listItems)
            {
                TaoKhung(20 + 280 * (i / 3), 50 + 250 * (i % 3), item);
                i++;
            }
        }

        private void TaoKhung(int topPN, int leftPN, DienThoai dienThoai)
        {
            Panel pn = new Panel();
            pn.Parent = pnMain;
            pn.Top = topPN;
            pn.Left = leftPN;
            pn.Width = 170;
            pn.Height = 260;
            pn.BackColor = Color.LightGray;
            pn.Anchor = AnchorStyles.Top;

            PictureBox ptb = new PictureBox();
            ptb.Parent = pn;
            ptb.Top = 10;
            ptb.Left = 15;
            ptb.Width = 140;
            ptb.Height = 150;
            ptb.BackColor = Color.Red;
            ptb.Image = Image.FromFile(dienThoai.UrlHinhAnh);
            ptb.SizeMode = PictureBoxSizeMode.StretchImage;

            int topLBTen = 170;
            Label lbTenDienThoai = new Label();
            lbTenDienThoai.Parent = pn;
            lbTenDienThoai.Top = topLBTen;
            lbTenDienThoai.Left = 15;
            lbTenDienThoai.Width = 140;
            lbTenDienThoai.Height = 14;
            lbTenDienThoai.Text = dienThoai.Ten;
            lbTenDienThoai.TextAlign = ContentAlignment.MiddleCenter;
            lbTenDienThoai.Font = new Font(Label.DefaultFont, FontStyle.Bold);

            Label lbGiaDienThoai = new Label();
            lbGiaDienThoai.Parent = pn;
            lbGiaDienThoai.Top = topLBTen + 20;
            lbGiaDienThoai.Left = 15;
            lbGiaDienThoai.Width = 140;
            lbGiaDienThoai.Height = 14;
            lbGiaDienThoai.Text = "Giá: " + dienThoai.Gia.ToString() + " vnđ";
            lbGiaDienThoai.TextAlign = ContentAlignment.MiddleCenter;

            Label lbSLDienThoai = new Label();
            lbSLDienThoai.Parent = pn;
            lbSLDienThoai.Top = topLBTen + 40;
            lbSLDienThoai.Left = 15;
            lbSLDienThoai.Width = 140;
            lbSLDienThoai.Height = 14;
            lbSLDienThoai.Text = "Số Lượng: " + dienThoai.SoLuong;
            lbSLDienThoai.TextAlign = ContentAlignment.MiddleCenter;

            Button btnThemVaoGio = new Button();
            btnThemVaoGio.Parent = pn;
            btnThemVaoGio.Top = topLBTen + 60;
            btnThemVaoGio.Left = 43;
            btnThemVaoGio.AutoSize = true;
            btnThemVaoGio.Text = "Thêm Vào Giỏ";
            btnThemVaoGio.Tag = dienThoai;
            btnThemVaoGio.Click += BtnThemVaoGio_Click;

        }

        private void BtnThemVaoGio_Click(object sender, System.EventArgs e)
        {
            if (TaiKhoan.taiKhoanSession.TenTaiKhoan == "")
            {
                DangNhap loginForm = new DangNhap();
                this.Hide();
                loginForm.ShowDialog();
                this.Close();
            }
            else
            {
                Button btn = (Button)sender;
                DienThoai dienThoai = (DienThoai)btn.Tag;

                if (GioHangDAL.CheckGioHang(TaiKhoan.taiKhoanSession.TenTaiKhoan, dienThoai.Id) == null)
                {
                    DateTime today = DateTime.Today;
                    GioHang tmp = new GioHang
                    {
                        Id = 0,
                        TaiKhoan = TaiKhoan.taiKhoanSession.TenTaiKhoan,
                        IdDienThoai = dienThoai.Id,
                        DaDatHang = false,
                        NgayThem = today
                    };
                    bool rs = GioHangDAL.ThemMoi(tmp);
                    if (rs)
                    {
                        MessageBox.Show("Thành Công, Đã thêm vào giỏ hàng của bạn.");
                    }
                    else
                    {
                        MessageBox.Show("Thất bại, Không thêm được vào giỏ hàng.");
                    }
                }
                else
                {
                    MessageBox.Show("Thành Công, Đã thêm vào giỏ hàng của bạn.");
                }
            }
        }

        private void cbbLoaiDienThoai_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            int idLoaiDienThoai = ((LoaiDienThoai)cbbLoaiDienThoai.SelectedItem).Id;
            if (idLoaiDienThoai == 00)
            {
                listDienThoai = DienThoaiDAL.LayTatCa();
            }
            else
            {
                listDienThoai = DienThoaiDAL.LayTheoLoaiDienThoai(idLoaiDienThoai);
            }
            pnMain.Controls.Clear();
            LoadDienThoai(listDienThoai);
        }

        private void btnTimKiem_Click(object sender, System.EventArgs e)
        {
            string txtTimKiem = tbTimKiem.Text;
            listDienThoai = DienThoaiDAL.LayTheoTenDienThoai(txtTimKiem);
            pnMain.Controls.Clear();
            LoadDienThoai(listDienThoai);
        }

        private void lbDangKy_Click(object sender, System.EventArgs e)
        {
            DangKyTaiKhoan dktkForm = new DangKyTaiKhoan();
            this.Hide();
            dktkForm.ShowDialog();
            this.Close();
        }


        private void lbDangNhap_Click(object sender, System.EventArgs e)
        {
            DangNhap loginForm = new DangNhap();
            this.Hide();
            loginForm.ShowDialog();
            this.Close();
        }

        private void lbDangXuat_Click(object sender, System.EventArgs e)
        {
            TaiKhoan.taiKhoanSession = new TaiKhoan()
            {
                TenTaiKhoan = "",
                MatKhau = "",
                HoTen = "",
                GioiTinh = false,
                SoDienThoai = "",
                Email = "",
                DiaChi = "",
                IsAdmin = false
            };
            lbDangXuat.Visible = false;
            lbDangNhap.Visible = true;
            lbDangKy.Visible = true;

            if (tabControlTrangChu.TabPages.Contains(tabGioHang))
            {
                tabControlTrangChu.TabPages.Remove(tabGioHang);
                tabControlTrangChu.TabPages.Remove(tabLichSuDatHang);
                tabControlTrangChu.TabPages.Remove(tabTTCaNhan);
            }
        }
    }
}
