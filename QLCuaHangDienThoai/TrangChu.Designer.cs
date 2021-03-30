
namespace QLCuaHangDienThoai
{
    partial class TrangChu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControlTrangChu = new System.Windows.Forms.TabControl();
            this.tabTrangChu = new System.Windows.Forms.TabPage();
            this.pnDienThoai = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbDangKy = new System.Windows.Forms.Label();
            this.lbDangXuat = new System.Windows.Forms.Label();
            this.lbDangNhap = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.tbTimKiem = new System.Windows.Forms.TextBox();
            this.cbbLoaiDienThoai = new System.Windows.Forms.ComboBox();
            this.tabControlTrangChu.SuspendLayout();
            this.tabTrangChu.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlTrangChu
            // 
            this.tabControlTrangChu.Controls.Add(this.tabTrangChu);
            this.tabControlTrangChu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlTrangChu.Location = new System.Drawing.Point(0, 0);
            this.tabControlTrangChu.Name = "tabControlTrangChu";
            this.tabControlTrangChu.SelectedIndex = 0;
            this.tabControlTrangChu.Size = new System.Drawing.Size(800, 450);
            this.tabControlTrangChu.TabIndex = 0;
            // 
            // tabTrangChu
            // 
            this.tabTrangChu.Controls.Add(this.pnDienThoai);
            this.tabTrangChu.Controls.Add(this.panel1);
            this.tabTrangChu.Location = new System.Drawing.Point(4, 22);
            this.tabTrangChu.Name = "tabTrangChu";
            this.tabTrangChu.Padding = new System.Windows.Forms.Padding(3);
            this.tabTrangChu.Size = new System.Drawing.Size(792, 424);
            this.tabTrangChu.TabIndex = 0;
            this.tabTrangChu.Text = "Trang Chủ";
            this.tabTrangChu.UseVisualStyleBackColor = true;
            // 
            // pnDienThoai
            // 
            this.pnDienThoai.AutoScroll = true;
            this.pnDienThoai.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnDienThoai.Location = new System.Drawing.Point(3, 64);
            this.pnDienThoai.Name = "pnDienThoai";
            this.pnDienThoai.Size = new System.Drawing.Size(786, 357);
            this.pnDienThoai.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.lbDangKy);
            this.panel1.Controls.Add(this.lbDangXuat);
            this.panel1.Controls.Add(this.lbDangNhap);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnTimKiem);
            this.panel1.Controls.Add(this.tbTimKiem);
            this.panel1.Controls.Add(this.cbbLoaiDienThoai);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(786, 61);
            this.panel1.TabIndex = 0;
            // 
            // lbDangKy
            // 
            this.lbDangKy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbDangKy.AutoSize = true;
            this.lbDangKy.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbDangKy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbDangKy.Location = new System.Drawing.Point(718, 20);
            this.lbDangKy.Name = "lbDangKy";
            this.lbDangKy.Size = new System.Drawing.Size(47, 13);
            this.lbDangKy.TabIndex = 6;
            this.lbDangKy.Text = "Đăng ký";
            this.lbDangKy.Click += new System.EventHandler(this.lbDangKy_Click);
            // 
            // lbDangXuat
            // 
            this.lbDangXuat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbDangXuat.AutoSize = true;
            this.lbDangXuat.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbDangXuat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbDangXuat.Location = new System.Drawing.Point(718, 20);
            this.lbDangXuat.Name = "lbDangXuat";
            this.lbDangXuat.Size = new System.Drawing.Size(56, 13);
            this.lbDangXuat.TabIndex = 5;
            this.lbDangXuat.Text = "Đăng xuất";
            this.lbDangXuat.Visible = false;
            this.lbDangXuat.Click += new System.EventHandler(this.lbDangXuat_Click);
            // 
            // lbDangNhap
            // 
            this.lbDangNhap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbDangNhap.AutoSize = true;
            this.lbDangNhap.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbDangNhap.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbDangNhap.Location = new System.Drawing.Point(652, 20);
            this.lbDangNhap.Name = "lbDangNhap";
            this.lbDangNhap.Size = new System.Drawing.Size(60, 13);
            this.lbDangNhap.TabIndex = 4;
            this.lbDangNhap.Text = "Đăng nhập";
            this.lbDangNhap.Click += new System.EventHandler(this.lbDangNhap_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(356, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Loại Điện Thoại";
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnTimKiem.AutoSize = true;
            this.btnTimKiem.Location = new System.Drawing.Point(271, 15);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(30, 23);
            this.btnTimKiem.TabIndex = 2;
            this.btnTimKiem.Text = "tìm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // tbTimKiem
            // 
            this.tbTimKiem.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tbTimKiem.Location = new System.Drawing.Point(56, 16);
            this.tbTimKiem.Name = "tbTimKiem";
            this.tbTimKiem.Size = new System.Drawing.Size(199, 20);
            this.tbTimKiem.TabIndex = 1;
            // 
            // cbbLoaiDienThoai
            // 
            this.cbbLoaiDienThoai.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbbLoaiDienThoai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbLoaiDienThoai.FormattingEnabled = true;
            this.cbbLoaiDienThoai.Location = new System.Drawing.Point(444, 16);
            this.cbbLoaiDienThoai.Name = "cbbLoaiDienThoai";
            this.cbbLoaiDienThoai.Size = new System.Drawing.Size(177, 21);
            this.cbbLoaiDienThoai.TabIndex = 0;
            this.cbbLoaiDienThoai.SelectedIndexChanged += new System.EventHandler(this.cbbLoaiDienThoai_SelectedIndexChanged);
            // 
            // TrangChu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControlTrangChu);
            this.Name = "TrangChu";
            this.Text = "TrangChu";
            this.tabControlTrangChu.ResumeLayout(false);
            this.tabTrangChu.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlTrangChu;
        private System.Windows.Forms.TabPage tabTrangChu;
        private System.Windows.Forms.Panel pnDienThoai;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.TextBox tbTimKiem;
        private System.Windows.Forms.ComboBox cbbLoaiDienThoai;
        private System.Windows.Forms.Label lbDangNhap;
        private System.Windows.Forms.Label lbDangXuat;
        private System.Windows.Forms.Label lbDangKy;
    }
}

