using System.Windows.Forms;
using QLCuaHangDienThoai.Models;
using System.Collections.Generic;
using QLCuaHangDienThoai.DAL;
using System.Drawing;
using System;

namespace QLCuaHangDienThoai.GUI
{
    public partial class Admin : Form
    {

        private IList<TaiKhoan> listTaiKhoan;
        private IList<DienThoai> listDienThoai;
        private IList<LoaiDienThoai> listLoaiDienThoai;
        private string UrlHinhAnhTT;
        private string UrlHinhAnhTM;

        public Admin()
        {
            InitializeComponent();
            lbTaiKhoan.Text = TaiKhoan.taiKhoanSession.HoTen;
            cbbTMGT.Text = "Nam";

            listTaiKhoan = TaiKhoanDAL.LayTatCa();
            listDienThoai = DienThoaiDAL.LayTatCa();
            listLoaiDienThoai = LoaiDienThoaiDAL.LayTatCa();
            SetUpDGV();
            FillDataDGVTK(listTaiKhoan);
            FillDataDGVDT(listDienThoai);
            FillDataDGVLDT(listLoaiDienThoai);

            LoadTTTaiKhoanHienTai();
            LoadTTDienThoaiHienTai();
            LoadTTLoaiDienThoaiHienTai();
        }

        // ---  TAB TÀI KHOẢN
        private void SetUpDGV()
        {
            // Khởi tạo datagridview tài khoản
            BindingSource dts = new BindingSource();
            dts.DataSource = typeof(TaiKhoan);
            dgvTaiKhoan.DataSource = dts;
            dgvTaiKhoan.Columns["TenTaiKhoan"].Width = 130;
            dgvTaiKhoan.Columns["TenTaiKhoan"].HeaderText = "Tên Tài Khoản";
            dgvTaiKhoan.Columns["MatKhau"].HeaderText = "Mật Khẩu";
            dgvTaiKhoan.Columns["HoTen"].HeaderText = "Họ Tên";
            dgvTaiKhoan.Columns["GioiTinh"].HeaderText = "Giới Tính";
            dgvTaiKhoan.Columns["SoDienThoai"].HeaderText = "Số Điện Thoại";
            dgvTaiKhoan.Columns["Email"].HeaderText = "Email";
            dgvTaiKhoan.Columns["DiaChi"].HeaderText = "Địa Chỉ";
            dgvTaiKhoan.Columns["IsAdmin"].HeaderText = "Admin";

            // Khởi tạo datagridview điện thoại
            dts.DataSource = typeof(DienThoai);
            dgvDienThoai.DataSource = dts;
            dgvDienThoai.Columns["LoaiDienThoai"].Width = 130;
            dgvDienThoai.Columns["Id"].HeaderText = "Id";
            dgvDienThoai.Columns["LoaiDienThoai"].HeaderText = "Loại Điên Thoại";
            dgvDienThoai.Columns["Ten"].HeaderText = "Tên Điện Thoại";
            dgvDienThoai.Columns["MoTa"].HeaderText = "Mô Tả";
            dgvDienThoai.Columns["SoLuong"].HeaderText = "Số Lượng";
            dgvDienThoai.Columns["Gia"].HeaderText = "Giá";
            dgvDienThoai.Columns["UrlHinhAnh"].HeaderText = "Hình Ảnh";
            dgvDienThoai.Columns["IdLoaiDienThoai"].HeaderText = "IdLoaiDienThoai";

            // Khởi tạo datagridview loại điện thoại
            dts.DataSource = typeof(LoaiDienThoai);
            dgvLoaiDienThoai.DataSource = dts;
            dgvLoaiDienThoai.Columns["MoTa"].Width = 200;
            dgvLoaiDienThoai.Columns["Id"].HeaderText = "Id";
            dgvLoaiDienThoai.Columns["Ten"].HeaderText = "Tên";
            dgvLoaiDienThoai.Columns["MoTa"].HeaderText = "Mô Tả";


            // Khởi tạo combobox loại điện thoại
            foreach (var item in listLoaiDienThoai)
            {
                cbbTTLoaiDT.Items.Add(item);
                cbbTMLoaiDT.Items.Add(item);
            }
            cbbTMLoaiDT.Text = "IPhone";
        }

        private void FillDataDGVTK(IList<TaiKhoan> listItems)
        {
            BindingSource dts = new BindingSource();
            dts.DataSource = typeof(TaiKhoan);
            dgvTaiKhoan.DataSource = dts;
            foreach (var item in listItems)
            {
                dts.Add(item);
            }
        }

        private void dgvTaiKhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tabCTTaiKhoan.SelectedTab = tabThongTinTK;
            lbTBTMTK.Text = "";
            LoadTTTaiKhoanHienTai();
        }

        private void btnCapNhatTK_Click(object sender, System.EventArgs e)
        {
            bool gt = false;
            if (cbbTTGT.Text == "Nam")
                gt = true;

            TaiKhoan tmp = new TaiKhoan
            {
                TenTaiKhoan = tbTTTK.Text,
                MatKhau = tbTTMK.Text,
                HoTen = tbTTHT.Text,
                GioiTinh = gt,
                SoDienThoai = tbTTSDT.Text,
                Email = tbTTEmail.Text,
                DiaChi = tbTTDC.Text,
                IsAdmin = cbTTIsAdmin.Checked
            };

            bool rs = TaiKhoanDAL.CapNhat(tmp);
            if (rs)
            {
                int i = dgvTaiKhoan.CurrentRow.Index;
                listTaiKhoan[i] = tmp;

                dgvTaiKhoan.Rows[i].Cells["HoTen"].Value = tmp.HoTen;
                dgvTaiKhoan.Rows[i].Cells["MatKhau"].Value = tmp.MatKhau;
                dgvTaiKhoan.Rows[i].Cells["GioiTinh"].Value = tmp.GioiTinh;
                dgvTaiKhoan.Rows[i].Cells["SoDienThoai"].Value = tmp.SoDienThoai;
                dgvTaiKhoan.Rows[i].Cells["Email"].Value = tmp.Email;
                dgvTaiKhoan.Rows[i].Cells["DiaChi"].Value = tmp.DiaChi;
                dgvTaiKhoan.Rows[i].Cells["IsAdmin"].Value = tmp.IsAdmin;

                lbTBCNTK.ForeColor = Color.Green;
                lbTBCNTK.Text = "Cập Nhật Thành Công!";
            }
            else
            {
                lbTBCNTK.ForeColor = Color.Red;
                lbTBCNTK.Text = "Cập Nhật Thất Bại!";
            }
        }

        private void btnHuyCapNhatTK_Click(object sender, System.EventArgs e)
        {
            LoadTTTaiKhoanHienTai();
        }

        private void LoadTTTaiKhoanHienTai()
        {
            lbTBCNTK.Text = "";
            int i = dgvTaiKhoan.CurrentRow.Index;
            tbTTTK.Text = dgvTaiKhoan.Rows[i].Cells["TenTaiKhoan"].Value.ToString();
            tbTTMK.Text = dgvTaiKhoan.Rows[i].Cells["MatKhau"].Value.ToString();
            tbTTHT.Text = dgvTaiKhoan.Rows[i].Cells["HoTen"].Value.ToString();

            if ((bool)dgvTaiKhoan.Rows[i].Cells["GioiTinh"].Value)
                cbbTTGT.Text = "Nam";
            else
                cbbTTGT.Text = "Nữ";

            tbTTSDT.Text = dgvTaiKhoan.Rows[i].Cells["SoDienThoai"].Value.ToString();
            tbTTEmail.Text = dgvTaiKhoan.Rows[i].Cells["Email"].Value.ToString();
            tbTTDC.Text = dgvTaiKhoan.Rows[i].Cells["DiaChi"].Value.ToString();
            cbTTIsAdmin.Checked = (bool)dgvTaiKhoan.Rows[i].Cells["IsAdmin"].Value;
        }


        private void btnThemMoiTK_Click(object sender, System.EventArgs e)
        {
            bool gt = false;
            if (cbbTMGT.Text == "Nam")
                gt = true;

            TaiKhoan tmp = new TaiKhoan
            {
                TenTaiKhoan = tbTMTTK.Text,
                MatKhau = tbTMMK.Text,
                HoTen = tbTMHT.Text,
                GioiTinh = gt,
                SoDienThoai = tbTMSDT.Text,
                Email = tbTMEmail.Text,
                DiaChi = tbTMDC.Text,
                IsAdmin = cbTMIsAdmin.Checked
            };

            bool rs = TaiKhoanDAL.ThemMoi(tmp);
            if (rs)
            {
                // Thêm Tài Khoản mới vào ds tạm
                listTaiKhoan.Add(tmp);
                FillDataDGVTK(listTaiKhoan);

                ResetInputTK();
                lbTBTMTK.ForeColor = Color.Green;
                lbTBTMTK.Text = "Thêm Mới Thành Công!";
            }
            else
            {
                lbTBTMTK.ForeColor = Color.Red;
                lbTBTMTK.Text = "Thất Bại! Tên tài khoản đã tồn tại";
            }
        }

        private void btnXoaTK_Click(object sender, System.EventArgs e)
        {
            int i = dgvTaiKhoan.CurrentRow.Index;
            string tenTK = dgvTaiKhoan.Rows[i].Cells["TenTaiKhoan"].Value.ToString();
            bool rs = TaiKhoanDAL.Xoa(tenTK);
            if (rs)
            {
                listTaiKhoan.RemoveAt(i);
                FillDataDGVTK(listTaiKhoan);
                LoadTTTaiKhoanHienTai();
                lbTBCNTK.ForeColor = Color.Green;
                lbTBCNTK.Text = "Xoá Thành Công!";
            }
            else
            {
                lbTBCNTK.ForeColor = Color.Red;
                lbTBCNTK.Text = "Xoá Thất Bại!";
            }
        }

        private void btnHuyThemMoiTK_Click(object sender, System.EventArgs e)
        {
            lbTBTMTK.Text = "";
            ResetInputTK();
        }

        private void ResetInputTK()
        {
            tbTMTTK.Text = "";
            tbTMMK.Text = "";
            tbTMHT.Text = "";
            cbbTMGT.Text = "Nam";
            tbTMSDT.Text = "";
            tbTMEmail.Text = "";
            tbTMDC.Text = "";
            cbTMIsAdmin.Checked = false;
        }


        // ---  TAB ĐIỆN THOẠI
        private void FillDataDGVDT(IList<DienThoai> listItems)
        {
            BindingSource dts = new BindingSource();
            dts.DataSource = typeof(DienThoai);
            dgvDienThoai.DataSource = dts;
            foreach (var item in listItems)
            {
                dts.Add(item);
            }
        }


        private void btnFileTTDT_Click(object sender, System.EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Pictures files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png)|*.jpg; *.jpeg; *.jpe; *.jfif; *.png|All files (*.*)|*.*";
            openFile.FilterIndex = 1;
            openFile.RestoreDirectory = true;
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                string fullPath = openFile.FileName;
                Image tmpImage = Image.FromFile(fullPath);
                string[] strs = fullPath.Split('\\');
                string fileName = strs[strs.Length - 1];
                UrlHinhAnhTT = "Images/" + fileName;
                tmpImage.Save(UrlHinhAnhTT);
                pbTTDT.Image = Image.FromFile(UrlHinhAnhTT);
            }
        }

        private void dgvDienThoai_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tabCTDienThoai.SelectedTab = tabTTDienThoai;
            lbTBTMDT.Text = "";

            LoadTTDienThoaiHienTai();
        }

        private void btnCapNhatDT_Click(object sender, System.EventArgs e)
        {
            if (cbbTTLoaiDT.SelectedItem == null)
            {
                lbTBCNDT.ForeColor = Color.Red;
                lbTBCNDT.Text = "Bạn chưa chọn điện thoại";
            }
            else
            {
                int i = dgvDienThoai.CurrentRow.Index;
                DienThoai tmp = new DienThoai
                {
                    Id = (int)dgvDienThoai.Rows[i].Cells["Id"].Value,
                    IdLoaiDienThoai = ((LoaiDienThoai)cbbTTLoaiDT.SelectedItem).Id,
                    LoaiDienThoai = ((LoaiDienThoai)cbbTTLoaiDT.SelectedItem).Ten,
                    Ten = tbTTTenDT.Text,
                    MoTa = tbTTMTDT.Text,
                    SoLuong = (int)nbTTSLDT.Value,
                    Gia = (int)nbTTGiaDT.Value,
                    UrlHinhAnh = UrlHinhAnhTT
                };

                bool rs = DienThoaiDAL.CapNhat(tmp);
                if (rs)
                {
                    listDienThoai[i] = tmp;

                    dgvDienThoai.Rows[i].Cells["IdLoaiDienThoai"].Value = tmp.IdLoaiDienThoai;
                    dgvDienThoai.Rows[i].Cells["LoaiDienThoai"].Value = tmp.LoaiDienThoai;
                    dgvDienThoai.Rows[i].Cells["Ten"].Value = tmp.Ten;
                    dgvDienThoai.Rows[i].Cells["MoTa"].Value = tmp.MoTa;
                    dgvDienThoai.Rows[i].Cells["SoLuong"].Value = tmp.SoLuong;
                    dgvDienThoai.Rows[i].Cells["Gia"].Value = tmp.Gia;
                    dgvDienThoai.Rows[i].Cells["UrlHinhAnh"].Value = tmp.UrlHinhAnh;

                    lbTBCNDT.ForeColor = Color.Green;
                    lbTBCNDT.Text = "Cập Nhật Thành Công!";
                }
                else
                {
                    lbTBCNDT.ForeColor = Color.Red;
                    lbTBCNDT.Text = "Cập Nhật Thất Bại!";
                }
            }

        }

        private void btnHuyCNDT_Click(object sender, System.EventArgs e)
        {
            LoadTTDienThoaiHienTai();
        }

        private void LoadTTDienThoaiHienTai()
        {
            lbTBCNDT.Text = "";

            int i = dgvDienThoai.CurrentRow.Index;
            string UrlHinhAnh = dgvDienThoai.Rows[i].Cells["UrlHinhAnh"].Value.ToString();
            if (UrlHinhAnh.Contains("Images/"))
            {
                pbTTDT.Image = Image.FromFile(UrlHinhAnh);
            } 
            
            cbbTTLoaiDT.Text = dgvDienThoai.Rows[i].Cells["LoaiDienThoai"].Value.ToString();
            tbTTTenDT.Text = dgvDienThoai.Rows[i].Cells["Ten"].Value.ToString();
            tbTTMTDT.Text = dgvDienThoai.Rows[i].Cells["MoTa"].Value.ToString();
            nbTTSLDT.Value = (int)dgvDienThoai.Rows[i].Cells["SoLuong"].Value;
            nbTTGiaDT.Value = (int)dgvDienThoai.Rows[i].Cells["Gia"].Value;
        }

        private void btnTMDT_Click(object sender, System.EventArgs e)
        {
            if (UrlHinhAnhTM == null || UrlHinhAnhTM == ""){
                lbTBTMDT.ForeColor = Color.Red;
                lbTBTMDT.Text = "Bạn chưa chọn hình ảnh";
            }
            else
            {
                DienThoai tmp = new DienThoai
                {
                    IdLoaiDienThoai = ((LoaiDienThoai)cbbTMLoaiDT.SelectedItem).Id,
                    Ten = tbTMTenDT.Text,
                    MoTa = tbTMMTDT.Text,
                    SoLuong = (int)nbTMSLDT.Value,
                    Gia = (int)nbTMGiaDT.Value,
                    UrlHinhAnh = UrlHinhAnhTM,
                    Id = 0,
                    LoaiDienThoai = ((LoaiDienThoai)cbbTMLoaiDT.SelectedItem).Ten
                };

                bool rs = DienThoaiDAL.ThemMoi(tmp);
                if (rs)
                {
                    listDienThoai.Add(tmp);
                    FillDataDGVDT(listDienThoai);
                    ResetInputDienThoai();
                    lbTBTMDT.ForeColor = Color.Green;
                    lbTBTMDT.Text = "Thêm Mới Thành Công!";
                }
                else
                {
                    lbTBTMDT.ForeColor = Color.Red;
                    lbTBTMDT.Text = "Thêm Mới Thất Bại!";
                }
            }
        }

        private void btnFileTMDT_Click(object sender, System.EventArgs e)
        {
            lbTBTMDT.Text = "";
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Pictures files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png)|*.jpg; *.jpeg; *.jpe; *.jfif; *.png|All files (*.*)|*.*";
            openFile.FilterIndex = 1;
            openFile.RestoreDirectory = true;
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                string fullPath = openFile.FileName;
                Image tmpImage = Image.FromFile(fullPath);
                string[] strs = fullPath.Split('.');
                string fileName = strs[strs.Length - 1];
                string timeStamp = DateTime.Now.ToString("yyyyMMddHHmmss");
                UrlHinhAnhTM = "Images/" + timeStamp + "." + fileName;
                tmpImage.Save(UrlHinhAnhTM);
                pbTMDT.Image = Image.FromFile(UrlHinhAnhTM);
            }
        }

        private void btnHuyTMDT_Click(object sender, System.EventArgs e)
        {
            lbTBTMDT.Text = "";
            ResetInputDienThoai();
        }

        private void ResetInputDienThoai()
        {
            pbTMDT.Image = null;

            tbTMTenDT.Text = "";
            tbTMMTDT.Text = "";
            nbTMSLDT.Value = 0;
            nbTMGiaDT.Value = 0;
            UrlHinhAnhTM = "";
        }

        private void btnXoaDienThoai_Click(object sender, System.EventArgs e)
        {
            int i = dgvDienThoai.CurrentRow.Index;

            bool rs = DienThoaiDAL.Xoa((int)dgvDienThoai.Rows[i].Cells["Id"].Value);
            if (rs)
            {
                listDienThoai.RemoveAt(i);
                FillDataDGVDT(listDienThoai);
                LoadTTDienThoaiHienTai();

                lbTBCNDT.ForeColor = Color.Green;
                lbTBCNDT.Text = "Xoá Thành Công!";
            }
            else
            {
                lbTBCNDT.ForeColor = Color.Red;
                lbTBCNDT.Text = "Xoá Thất Bại!";
            }
        }

        // ---  TAB LOẠI ĐIỆN THOẠI
        private void FillDataDGVLDT(IList<LoaiDienThoai> listItems)
        {
            BindingSource dts = new BindingSource();
            dts.DataSource = typeof(LoaiDienThoai);
            dgvLoaiDienThoai.DataSource = dts;
            foreach (var item in listItems)
            {
                dts.Add(item);
            }
        }

        private void LoadTTLoaiDienThoaiHienTai()
        {
            lbTBCNLDT.Text = "";

            int i = dgvLoaiDienThoai.CurrentRow.Index;
            tbTTTenLDT.Text = dgvLoaiDienThoai.Rows[i].Cells["Ten"].Value.ToString();
            tbTTMTLDT.Text = dgvLoaiDienThoai.Rows[i].Cells["MoTa"].Value.ToString();
        }

        private void ResetInputLoaiDienThoai()
        {
            tbTMTenLDT.Text = "";
            tbTMMTLDT.Text = "";
        }

        private void dgvLDT_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tabCTLDT.SelectedTab = tabTTLDT;
            LoadTTLoaiDienThoaiHienTai();
        }

        private void btnHuyCNLDT_Click(object sender, System.EventArgs e)
        {
            LoadTTLoaiDienThoaiHienTai();
        }

        private void btnCNLDT_Click(object sender, System.EventArgs e)
        {
            int i = dgvLoaiDienThoai.CurrentRow.Index;
            LoaiDienThoai tmp = new LoaiDienThoai
            {
                Id = (int)dgvLoaiDienThoai.Rows[i].Cells["Id"].Value,
                Ten = tbTTTenLDT.Text,
                MoTa = tbTTMTLDT.Text,
            };

            bool rs = LoaiDienThoaiDAL.CapNhat(tmp);
            if (rs)
            {
                listLoaiDienThoai[i] = tmp;
                dgvLoaiDienThoai.Rows[i].Cells["Ten"].Value = tmp.Ten;
                dgvLoaiDienThoai.Rows[i].Cells["MoTa"].Value = tmp.MoTa;

                lbTBCNLDT.ForeColor = Color.Green;
                lbTBCNLDT.Text = "Cập Nhật Thành Công!";
            }
            else
            {
                lbTBCNLDT.ForeColor = Color.Red;
                lbTBCNLDT.Text = "Cập Nhật Thất Bại!";
            }
        }


        private void btnXoaLDT_Click(object sender, System.EventArgs e)
        {
            bool rs = LoaiDienThoaiDAL.Xoa((int)dgvLoaiDienThoai.CurrentRow.Cells["Id"].Value);
            if (rs)
            {
                int i = dgvLoaiDienThoai.CurrentRow.Index;
                listLoaiDienThoai.RemoveAt(i);
                FillDataDGVLDT(listLoaiDienThoai);
                LoadTTLoaiDienThoaiHienTai();

                lbTBCNLDT.ForeColor = Color.Green;
                lbTBCNLDT.Text = "Xoá Thành Công!";
            }
            else
            {
                lbTBCNLDT.ForeColor = Color.Red;
                lbTBCNLDT.Text = "Xoá Thất Bại!";
            }
        }

        private void btnTMLDT_Click(object sender, System.EventArgs e)
        {
            LoaiDienThoai tmp = new LoaiDienThoai
            {
                Ten = tbTMTenLDT.Text,
                MoTa = tbTMMTLDT.Text
            };

            bool rs = LoaiDienThoaiDAL.ThemMoi(tmp);
            if (rs)
            {
                listLoaiDienThoai.Add(tmp);
                FillDataDGVLDT(listLoaiDienThoai);
                ResetInputLoaiDienThoai();
                lbTBTMLDT.ForeColor = Color.Green;
                lbTBTMLDT.Text = "Thêm Mới Thành Công!";
            }
            else
            {
                lbTBTMLDT.ForeColor = Color.Red;
                lbTBTMLDT.Text = "Thêm Mới Thất Bại!";
            }
        }

        private void btnHuyTMLDT_Click(object sender, System.EventArgs e)
        {
            lbTBTMLDT.Text = "";
            ResetInputLoaiDienThoai();
        }

        private void lbDangXuat_Click(object sender, EventArgs e)
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
            DangNhap dangNhapForm = new DangNhap();
            this.Hide();
            dangNhapForm.ShowDialog();
            this.Close();
        }
    }
}
