using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using QLCuaHangDienThoai.DAL;
using QLCuaHangDienThoai.Models;

namespace QLCuaHangDienThoai.GUI
{
    public partial class GioHangControl : UserControl
    {
        private IList<GioHang> listItems;
        public GioHangControl()
        {
            InitializeComponent();
            listItems = GioHangDAL.LayTheoTaiKhoan(TaiKhoan.taiKhoanSession.TenTaiKhoan);

            loadData();
        }

        private void loadData()
        {
            int i = 0;
            foreach (var item in listItems)
            {
                TaoKhung(20 + 100 * i, item);
                i++;
            }
        }

        private void TaoKhung(int topPN, GioHang item)
        {
            Panel pn = new Panel();
            pn.Parent = pnMain;
            pn.Top = topPN;
            pn.Left = 50;
            pn.Width = 200;
            pn.Height = 60;
            pn.BackColor = Color.LightGray;
            pn.Anchor = AnchorStyles.Top;

            int topLBTen = 10;
            Label lbTenDienThoai = new Label();
            lbTenDienThoai.Parent = pn;
            lbTenDienThoai.Top = topLBTen;
            lbTenDienThoai.Left = 15;
            lbTenDienThoai.Width = 140;
            lbTenDienThoai.Height = 14;
            lbTenDienThoai.Text = item.IdDienThoai.ToString();
            lbTenDienThoai.TextAlign = ContentAlignment.MiddleCenter;
            lbTenDienThoai.Font = new Font(Label.DefaultFont, FontStyle.Bold);
        }
    }
}
