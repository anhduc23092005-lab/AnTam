namespace AnTam_BaoHiem.Views
{
    partial class FormQuanLyHopDongMuaBaoHiem
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblTieuDeChinh = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblTitleTongSo = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.dgvDanhSachHopDong = new Guna.UI2.WinForms.Guna2DataGridView();
            this.pnlTongSoHopDong = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlHopDongChoDuyet = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlSapHetHan = new Guna.UI2.WinForms.Guna2Panel();
            this.STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ma_hd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ten_khach_hang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.loai_bao_hiem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tong_phi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.thoi_han = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.trang_thai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtTimKiem = new Guna.UI2.WinForms.Guna2TextBox();
            this.cboTrangThai = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btnLoc = new Guna.UI2.WinForms.Guna2Button();
            this.lblTitleChoDuyet = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblTitleSapHetHan = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblSoLuongTong = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblSoLuongChoDuyet = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblSoLuongSapHetHan = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btnChinhSua = new Guna.UI2.WinForms.Guna2Button();
            this.btnThemMoi = new Guna.UI2.WinForms.Guna2Button();
            this.btnXoa = new Guna.UI2.WinForms.Guna2Button();
            this.guna2PictureBox2 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2PictureBox3 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSachHopDong)).BeginInit();
            this.pnlTongSoHopDong.SuspendLayout();
            this.pnlHopDongChoDuyet.SuspendLayout();
            this.pnlSapHetHan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTieuDeChinh
            // 
            this.lblTieuDeChinh.BackColor = System.Drawing.Color.Transparent;
            this.lblTieuDeChinh.Font = new System.Drawing.Font("Times New Roman", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTieuDeChinh.ForeColor = System.Drawing.Color.Yellow;
            this.lblTieuDeChinh.Location = new System.Drawing.Point(163, 112);
            this.lblTieuDeChinh.Name = "lblTieuDeChinh";
            this.lblTieuDeChinh.Size = new System.Drawing.Size(487, 55);
            this.lblTieuDeChinh.TabIndex = 0;
            this.lblTieuDeChinh.Text = "QUẢN LÝ HỢP ĐỒNG";
            this.lblTieuDeChinh.Click += new System.EventHandler(this.guna2HtmlLabel1_Click);
            // 
            // lblTitleTongSo
            // 
            this.lblTitleTongSo.BackColor = System.Drawing.Color.Transparent;
            this.lblTitleTongSo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitleTongSo.Location = new System.Drawing.Point(51, 3);
            this.lblTitleTongSo.Name = "lblTitleTongSo";
            this.lblTitleTongSo.Size = new System.Drawing.Size(150, 25);
            this.lblTitleTongSo.TabIndex = 1;
            this.lblTitleTongSo.Text = "Tổng số hợp đồng";
            this.lblTitleTongSo.Click += new System.EventHandler(this.guna2HtmlLabel2_Click);
            // 
            // dgvDanhSachHopDong
            // 
            this.dgvDanhSachHopDong.AllowUserToAddRows = false;
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.White;
            this.dgvDanhSachHopDong.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle13;
            this.dgvDanhSachHopDong.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDanhSachHopDong.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(25)))), ((int)(((byte)(53)))));
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDanhSachHopDong.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this.dgvDanhSachHopDong.ColumnHeadersHeight = 36;
            this.dgvDanhSachHopDong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvDanhSachHopDong.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.STT,
            this.ma_hd,
            this.ten_khach_hang,
            this.loai_bao_hiem,
            this.tong_phi,
            this.thoi_han,
            this.trang_thai});
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDanhSachHopDong.DefaultCellStyle = dataGridViewCellStyle15;
            this.dgvDanhSachHopDong.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvDanhSachHopDong.Location = new System.Drawing.Point(-2, 235);
            this.dgvDanhSachHopDong.Name = "dgvDanhSachHopDong";
            this.dgvDanhSachHopDong.RowHeadersVisible = false;
            this.dgvDanhSachHopDong.RowHeadersWidth = 51;
            this.dgvDanhSachHopDong.RowTemplate.Height = 24;
            this.dgvDanhSachHopDong.Size = new System.Drawing.Size(801, 216);
            this.dgvDanhSachHopDong.TabIndex = 2;
            this.dgvDanhSachHopDong.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvDanhSachHopDong.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvDanhSachHopDong.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvDanhSachHopDong.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvDanhSachHopDong.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvDanhSachHopDong.ThemeStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(25)))), ((int)(((byte)(53)))));
            this.dgvDanhSachHopDong.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvDanhSachHopDong.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvDanhSachHopDong.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvDanhSachHopDong.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvDanhSachHopDong.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvDanhSachHopDong.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvDanhSachHopDong.ThemeStyle.HeaderStyle.Height = 36;
            this.dgvDanhSachHopDong.ThemeStyle.ReadOnly = false;
            this.dgvDanhSachHopDong.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvDanhSachHopDong.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvDanhSachHopDong.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvDanhSachHopDong.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvDanhSachHopDong.ThemeStyle.RowsStyle.Height = 24;
            this.dgvDanhSachHopDong.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvDanhSachHopDong.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // pnlTongSoHopDong
            // 
            this.pnlTongSoHopDong.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(34)))));
            this.pnlTongSoHopDong.BorderRadius = 15;
            this.pnlTongSoHopDong.Controls.Add(this.guna2PictureBox1);
            this.pnlTongSoHopDong.Controls.Add(this.lblTitleTongSo);
            this.pnlTongSoHopDong.Controls.Add(this.lblSoLuongTong);
            this.pnlTongSoHopDong.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(25)))), ((int)(((byte)(53)))));
            this.pnlTongSoHopDong.Location = new System.Drawing.Point(12, 12);
            this.pnlTongSoHopDong.Name = "pnlTongSoHopDong";
            this.pnlTongSoHopDong.Size = new System.Drawing.Size(272, 80);
            this.pnlTongSoHopDong.TabIndex = 3;
            // 
            // pnlHopDongChoDuyet
            // 
            this.pnlHopDongChoDuyet.Controls.Add(this.guna2PictureBox2);
            this.pnlHopDongChoDuyet.Controls.Add(this.lblTitleChoDuyet);
            this.pnlHopDongChoDuyet.Controls.Add(this.lblSoLuongChoDuyet);
            this.pnlHopDongChoDuyet.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(25)))), ((int)(((byte)(53)))));
            this.pnlHopDongChoDuyet.Location = new System.Drawing.Point(290, 12);
            this.pnlHopDongChoDuyet.Name = "pnlHopDongChoDuyet";
            this.pnlHopDongChoDuyet.Size = new System.Drawing.Size(248, 80);
            this.pnlHopDongChoDuyet.TabIndex = 0;
            // 
            // pnlSapHetHan
            // 
            this.pnlSapHetHan.Controls.Add(this.lblSoLuongSapHetHan);
            this.pnlSapHetHan.Controls.Add(this.guna2PictureBox3);
            this.pnlSapHetHan.Controls.Add(this.lblTitleSapHetHan);
            this.pnlSapHetHan.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(25)))), ((int)(((byte)(53)))));
            this.pnlSapHetHan.Location = new System.Drawing.Point(544, 12);
            this.pnlSapHetHan.Name = "pnlSapHetHan";
            this.pnlSapHetHan.Size = new System.Drawing.Size(244, 80);
            this.pnlSapHetHan.TabIndex = 0;
            // 
            // STT
            // 
            this.STT.HeaderText = "STT";
            this.STT.MinimumWidth = 6;
            this.STT.Name = "STT";
            // 
            // ma_hd
            // 
            this.ma_hd.HeaderText = "Mã HĐ";
            this.ma_hd.MinimumWidth = 6;
            this.ma_hd.Name = "ma_hd";
            // 
            // ten_khach_hang
            // 
            this.ten_khach_hang.HeaderText = "Tên Khách Hàng";
            this.ten_khach_hang.MinimumWidth = 6;
            this.ten_khach_hang.Name = "ten_khach_hang";
            // 
            // loai_bao_hiem
            // 
            this.loai_bao_hiem.HeaderText = "Loại Bảo Hiểm";
            this.loai_bao_hiem.MinimumWidth = 6;
            this.loai_bao_hiem.Name = "loai_bao_hiem";
            // 
            // tong_phi
            // 
            this.tong_phi.HeaderText = "Tổng Phí";
            this.tong_phi.MinimumWidth = 6;
            this.tong_phi.Name = "tong_phi";
            // 
            // thoi_han
            // 
            this.thoi_han.HeaderText = "Thời Hạn";
            this.thoi_han.MinimumWidth = 6;
            this.thoi_han.Name = "thoi_han";
            // 
            // trang_thai
            // 
            this.trang_thai.HeaderText = "Trạng Thái";
            this.trang_thai.MinimumWidth = 6;
            this.trang_thai.Name = "trang_thai";
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.BorderRadius = 6;
            this.txtTimKiem.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTimKiem.DefaultText = "";
            this.txtTimKiem.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtTimKiem.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtTimKiem.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTimKiem.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTimKiem.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTimKiem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtTimKiem.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTimKiem.Location = new System.Drawing.Point(417, 184);
            this.txtTimKiem.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.PlaceholderText = "Nhập thông tin";
            this.txtTimKiem.SelectedText = "";
            this.txtTimKiem.Size = new System.Drawing.Size(159, 25);
            this.txtTimKiem.TabIndex = 4;
            // 
            // cboTrangThai
            // 
            this.cboTrangThai.BackColor = System.Drawing.Color.Transparent;
            this.cboTrangThai.BorderRadius = 6;
            this.cboTrangThai.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboTrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTrangThai.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboTrangThai.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboTrangThai.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboTrangThai.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboTrangThai.ItemHeight = 30;
            this.cboTrangThai.Items.AddRange(new object[] {
            "Tất cả",
            "Chờ duyệt",
            "Đang hiệu lực",
            "Đã hủy"});
            this.cboTrangThai.Location = new System.Drawing.Point(680, 184);
            this.cboTrangThai.Name = "cboTrangThai";
            this.cboTrangThai.Size = new System.Drawing.Size(108, 36);
            this.cboTrangThai.StartIndex = 0;
            this.cboTrangThai.TabIndex = 5;
            // 
            // btnLoc
            // 
            this.btnLoc.BorderRadius = 6;
            this.btnLoc.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLoc.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnLoc.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLoc.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnLoc.FillColor = System.Drawing.Color.Gray;
            this.btnLoc.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnLoc.ForeColor = System.Drawing.Color.White;
            this.btnLoc.Location = new System.Drawing.Point(582, 184);
            this.btnLoc.Name = "btnLoc";
            this.btnLoc.Size = new System.Drawing.Size(92, 25);
            this.btnLoc.TabIndex = 6;
            this.btnLoc.Text = "Tìm kiếm";
            // 
            // lblTitleChoDuyet
            // 
            this.lblTitleChoDuyet.BackColor = System.Drawing.Color.Transparent;
            this.lblTitleChoDuyet.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitleChoDuyet.Location = new System.Drawing.Point(30, 3);
            this.lblTitleChoDuyet.Name = "lblTitleChoDuyet";
            this.lblTitleChoDuyet.Size = new System.Drawing.Size(171, 25);
            this.lblTitleChoDuyet.TabIndex = 7;
            this.lblTitleChoDuyet.Text = "Hợp đồng chờ duyệt";
            // 
            // lblTitleSapHetHan
            // 
            this.lblTitleSapHetHan.BackColor = System.Drawing.Color.Transparent;
            this.lblTitleSapHetHan.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitleSapHetHan.Location = new System.Drawing.Point(65, 3);
            this.lblTitleSapHetHan.Name = "lblTitleSapHetHan";
            this.lblTitleSapHetHan.Size = new System.Drawing.Size(101, 25);
            this.lblTitleSapHetHan.TabIndex = 8;
            this.lblTitleSapHetHan.Text = "Sắp hết hạn";
            // 
            // lblSoLuongTong
            // 
            this.lblSoLuongTong.BackColor = System.Drawing.Color.Transparent;
            this.lblSoLuongTong.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoLuongTong.ForeColor = System.Drawing.Color.Lime;
            this.lblSoLuongTong.Location = new System.Drawing.Point(27, 34);
            this.lblSoLuongTong.Name = "lblSoLuongTong";
            this.lblSoLuongTong.Size = new System.Drawing.Size(222, 37);
            this.lblSoLuongTong.TabIndex = 9;
            this.lblSoLuongTong.Text = "12.000 Hợp đồng";
            // 
            // lblSoLuongChoDuyet
            // 
            this.lblSoLuongChoDuyet.BackColor = System.Drawing.Color.Transparent;
            this.lblSoLuongChoDuyet.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoLuongChoDuyet.ForeColor = System.Drawing.Color.Yellow;
            this.lblSoLuongChoDuyet.Location = new System.Drawing.Point(43, 34);
            this.lblSoLuongChoDuyet.Name = "lblSoLuongChoDuyet";
            this.lblSoLuongChoDuyet.Size = new System.Drawing.Size(169, 37);
            this.lblSoLuongChoDuyet.TabIndex = 10;
            this.lblSoLuongChoDuyet.Text = "50 Hợp đồng";
            // 
            // lblSoLuongSapHetHan
            // 
            this.lblSoLuongSapHetHan.BackColor = System.Drawing.Color.Transparent;
            this.lblSoLuongSapHetHan.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoLuongSapHetHan.ForeColor = System.Drawing.Color.Red;
            this.lblSoLuongSapHetHan.Location = new System.Drawing.Point(38, 34);
            this.lblSoLuongSapHetHan.Name = "lblSoLuongSapHetHan";
            this.lblSoLuongSapHetHan.Size = new System.Drawing.Size(169, 37);
            this.lblSoLuongSapHetHan.TabIndex = 11;
            this.lblSoLuongSapHetHan.Text = "12 Hợp đồng";
            // 
            // btnChinhSua
            // 
            this.btnChinhSua.BorderRadius = 6;
            this.btnChinhSua.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnChinhSua.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnChinhSua.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnChinhSua.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnChinhSua.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(156)))), ((int)(((byte)(18)))));
            this.btnChinhSua.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnChinhSua.ForeColor = System.Drawing.Color.White;
            this.btnChinhSua.Location = new System.Drawing.Point(137, 184);
            this.btnChinhSua.Name = "btnChinhSua";
            this.btnChinhSua.Size = new System.Drawing.Size(102, 25);
            this.btnChinhSua.TabIndex = 7;
            this.btnChinhSua.Text = "Chỉnh sửa";
            // 
            // btnThemMoi
            // 
            this.btnThemMoi.BorderRadius = 6;
            this.btnThemMoi.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnThemMoi.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnThemMoi.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnThemMoi.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnThemMoi.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnThemMoi.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnThemMoi.ForeColor = System.Drawing.Color.White;
            this.btnThemMoi.Location = new System.Drawing.Point(12, 184);
            this.btnThemMoi.Name = "btnThemMoi";
            this.btnThemMoi.Size = new System.Drawing.Size(104, 25);
            this.btnThemMoi.TabIndex = 8;
            this.btnThemMoi.Text = "Thêm mới";
            // 
            // btnXoa
            // 
            this.btnXoa.BorderRadius = 6;
            this.btnXoa.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnXoa.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnXoa.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnXoa.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnXoa.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnXoa.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.Location = new System.Drawing.Point(264, 184);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(91, 25);
            this.btnXoa.TabIndex = 9;
            this.btnXoa.Text = "Xóa";
            // 
            // guna2PictureBox2
            // 
            this.guna2PictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(25)))), ((int)(((byte)(53)))));
            this.guna2PictureBox2.Image = global::AnTam_BaoHiem.Properties.Resources.pending_removebg_preview;
            this.guna2PictureBox2.ImageRotate = 0F;
            this.guna2PictureBox2.Location = new System.Drawing.Point(198, 3);
            this.guna2PictureBox2.Name = "guna2PictureBox2";
            this.guna2PictureBox2.Size = new System.Drawing.Size(35, 27);
            this.guna2PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox2.TabIndex = 11;
            this.guna2PictureBox2.TabStop = false;
            // 
            // guna2PictureBox3
            // 
            this.guna2PictureBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(25)))), ((int)(((byte)(53)))));
            this.guna2PictureBox3.Image = global::AnTam_BaoHiem.Properties.Resources._170417_200_removebg_preview;
            this.guna2PictureBox3.ImageRotate = 0F;
            this.guna2PictureBox3.Location = new System.Drawing.Point(162, 0);
            this.guna2PictureBox3.Name = "guna2PictureBox3";
            this.guna2PictureBox3.Size = new System.Drawing.Size(32, 24);
            this.guna2PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox3.TabIndex = 12;
            this.guna2PictureBox3.TabStop = false;
            this.guna2PictureBox3.Click += new System.EventHandler(this.guna2PictureBox3_Click);
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(25)))), ((int)(((byte)(53)))));
            this.guna2PictureBox1.Image = global::AnTam_BaoHiem.Properties.Resources.box1_removebg_preview;
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(207, 2);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(29, 26);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox1.TabIndex = 10;
            this.guna2PictureBox1.TabStop = false;
            // 
            // FormQuanLyHopDongMuaBaoHiem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(34)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnThemMoi);
            this.Controls.Add(this.btnChinhSua);
            this.Controls.Add(this.btnLoc);
            this.Controls.Add(this.cboTrangThai);
            this.Controls.Add(this.txtTimKiem);
            this.Controls.Add(this.pnlHopDongChoDuyet);
            this.Controls.Add(this.pnlSapHetHan);
            this.Controls.Add(this.pnlTongSoHopDong);
            this.Controls.Add(this.dgvDanhSachHopDong);
            this.Controls.Add(this.lblTieuDeChinh);
            this.Name = "FormQuanLyHopDongMuaBaoHiem";
            this.Text = "FormQuanLyHopDongMuaBaoHiem";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSachHopDong)).EndInit();
            this.pnlTongSoHopDong.ResumeLayout(false);
            this.pnlTongSoHopDong.PerformLayout();
            this.pnlHopDongChoDuyet.ResumeLayout(false);
            this.pnlHopDongChoDuyet.PerformLayout();
            this.pnlSapHetHan.ResumeLayout(false);
            this.pnlSapHetHan.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2HtmlLabel lblTieuDeChinh;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTitleTongSo;
        private Guna.UI2.WinForms.Guna2DataGridView dgvDanhSachHopDong;
        private Guna.UI2.WinForms.Guna2Panel pnlTongSoHopDong;
        private Guna.UI2.WinForms.Guna2Panel pnlHopDongChoDuyet;
        private Guna.UI2.WinForms.Guna2Panel pnlSapHetHan;
        private System.Windows.Forms.DataGridViewTextBoxColumn STT;
        private System.Windows.Forms.DataGridViewTextBoxColumn ma_hd;
        private System.Windows.Forms.DataGridViewTextBoxColumn ten_khach_hang;
        private System.Windows.Forms.DataGridViewTextBoxColumn loai_bao_hiem;
        private System.Windows.Forms.DataGridViewTextBoxColumn tong_phi;
        private System.Windows.Forms.DataGridViewTextBoxColumn thoi_han;
        private System.Windows.Forms.DataGridViewTextBoxColumn trang_thai;
        private Guna.UI2.WinForms.Guna2TextBox txtTimKiem;
        private Guna.UI2.WinForms.Guna2ComboBox cboTrangThai;
        private Guna.UI2.WinForms.Guna2Button btnLoc;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblSoLuongTong;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTitleChoDuyet;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblSoLuongChoDuyet;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblSoLuongSapHetHan;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTitleSapHetHan;
        private Guna.UI2.WinForms.Guna2Button btnChinhSua;
        private Guna.UI2.WinForms.Guna2Button btnThemMoi;
        private Guna.UI2.WinForms.Guna2Button btnXoa;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox2;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox3;
    }
}