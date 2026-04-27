namespace AnTam_BaoHiem.Views
{
    partial class FormLichSuMuaHang
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlMuaHang = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlThoiHan = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlChiPhi = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTieuDe = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.dgvLichSuMuaHang = new Guna.UI2.WinForms.Guna2DataGridView();
            this.lblTitleMuaHang = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblTitleThoiHan = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblTitleChiPhi = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblTenGoiBaoHiem = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblSoNgayConLai = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblTongTienDaDong = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2PictureBox3 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2PictureBox2 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.loai_bao_hiem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gia_tien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.thoi_han = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.trang_thai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtTimKiem = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnLoc = new Guna.UI2.WinForms.Guna2Button();
            this.cboTrangThai = new Guna.UI2.WinForms.Guna2ComboBox();
            this.pnlMuaHang.SuspendLayout();
            this.pnlThoiHan.SuspendLayout();
            this.pnlChiPhi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichSuMuaHang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMuaHang
            // 
            this.pnlMuaHang.Controls.Add(this.lblTenGoiBaoHiem);
            this.pnlMuaHang.Controls.Add(this.guna2PictureBox2);
            this.pnlMuaHang.Controls.Add(this.lblTitleMuaHang);
            this.pnlMuaHang.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(25)))), ((int)(((byte)(53)))));
            this.pnlMuaHang.Location = new System.Drawing.Point(12, 12);
            this.pnlMuaHang.Name = "pnlMuaHang";
            this.pnlMuaHang.Size = new System.Drawing.Size(260, 80);
            this.pnlMuaHang.TabIndex = 0;
            this.pnlMuaHang.Paint += new System.Windows.Forms.PaintEventHandler(this.guna2Panel1_Paint);
            // 
            // pnlThoiHan
            // 
            this.pnlThoiHan.Controls.Add(this.guna2PictureBox1);
            this.pnlThoiHan.Controls.Add(this.lblSoNgayConLai);
            this.pnlThoiHan.Controls.Add(this.lblTitleThoiHan);
            this.pnlThoiHan.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(25)))), ((int)(((byte)(53)))));
            this.pnlThoiHan.Location = new System.Drawing.Point(278, 12);
            this.pnlThoiHan.Name = "pnlThoiHan";
            this.pnlThoiHan.Size = new System.Drawing.Size(240, 80);
            this.pnlThoiHan.TabIndex = 0;
            this.pnlThoiHan.Paint += new System.Windows.Forms.PaintEventHandler(this.guna2Panel3_Paint);
            // 
            // pnlChiPhi
            // 
            this.pnlChiPhi.Controls.Add(this.guna2PictureBox3);
            this.pnlChiPhi.Controls.Add(this.lblTongTienDaDong);
            this.pnlChiPhi.Controls.Add(this.lblTitleChiPhi);
            this.pnlChiPhi.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(25)))), ((int)(((byte)(53)))));
            this.pnlChiPhi.Location = new System.Drawing.Point(524, 12);
            this.pnlChiPhi.Name = "pnlChiPhi";
            this.pnlChiPhi.Size = new System.Drawing.Size(264, 80);
            this.pnlChiPhi.TabIndex = 1;
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.BackColor = System.Drawing.Color.Transparent;
            this.lblTieuDe.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTieuDe.ForeColor = System.Drawing.Color.Yellow;
            this.lblTieuDe.Location = new System.Drawing.Point(1, 108);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(406, 47);
            this.lblTieuDe.TabIndex = 2;
            this.lblTieuDe.Text = "LỊCH SỬ MUA HÀNG";
            // 
            // dgvLichSuMuaHang
            // 
            this.dgvLichSuMuaHang.AllowUserToAddRows = false;
            dataGridViewCellStyle16.BackColor = System.Drawing.Color.White;
            this.dgvLichSuMuaHang.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle16;
            this.dgvLichSuMuaHang.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLichSuMuaHang.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(25)))), ((int)(((byte)(53)))));
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle17.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLichSuMuaHang.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle17;
            this.dgvLichSuMuaHang.ColumnHeadersHeight = 25;
            this.dgvLichSuMuaHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvLichSuMuaHang.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.STT,
            this.loai_bao_hiem,
            this.gia_tien,
            this.thoi_han,
            this.trang_thai});
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(25)))), ((int)(((byte)(53)))));
            dataGridViewCellStyle18.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle18.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvLichSuMuaHang.DefaultCellStyle = dataGridViewCellStyle18;
            this.dgvLichSuMuaHang.GridColor = System.Drawing.Color.White;
            this.dgvLichSuMuaHang.Location = new System.Drawing.Point(1, 174);
            this.dgvLichSuMuaHang.Name = "dgvLichSuMuaHang";
            this.dgvLichSuMuaHang.RowHeadersVisible = false;
            this.dgvLichSuMuaHang.RowHeadersWidth = 51;
            this.dgvLichSuMuaHang.RowTemplate.Height = 24;
            this.dgvLichSuMuaHang.Size = new System.Drawing.Size(801, 277);
            this.dgvLichSuMuaHang.TabIndex = 0;
            this.dgvLichSuMuaHang.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvLichSuMuaHang.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvLichSuMuaHang.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvLichSuMuaHang.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvLichSuMuaHang.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvLichSuMuaHang.ThemeStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(25)))), ((int)(((byte)(53)))));
            this.dgvLichSuMuaHang.ThemeStyle.GridColor = System.Drawing.Color.White;
            this.dgvLichSuMuaHang.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvLichSuMuaHang.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvLichSuMuaHang.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvLichSuMuaHang.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvLichSuMuaHang.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvLichSuMuaHang.ThemeStyle.HeaderStyle.Height = 25;
            this.dgvLichSuMuaHang.ThemeStyle.ReadOnly = false;
            this.dgvLichSuMuaHang.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvLichSuMuaHang.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvLichSuMuaHang.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvLichSuMuaHang.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvLichSuMuaHang.ThemeStyle.RowsStyle.Height = 24;
            this.dgvLichSuMuaHang.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvLichSuMuaHang.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvLichSuMuaHang.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.guna2DataGridView1_CellContentClick);
            // 
            // lblTitleMuaHang
            // 
            this.lblTitleMuaHang.BackColor = System.Drawing.Color.Transparent;
            this.lblTitleMuaHang.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitleMuaHang.Location = new System.Drawing.Point(43, 12);
            this.lblTitleMuaHang.Name = "lblTitleMuaHang";
            this.lblTitleMuaHang.Size = new System.Drawing.Size(156, 25);
            this.lblTitleMuaHang.TabIndex = 0;
            this.lblTitleMuaHang.Text = "Mua hàng gần đây";
            // 
            // lblTitleThoiHan
            // 
            this.lblTitleThoiHan.BackColor = System.Drawing.Color.Transparent;
            this.lblTitleThoiHan.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitleThoiHan.Location = new System.Drawing.Point(13, 12);
            this.lblTitleThoiHan.Name = "lblTitleThoiHan";
            this.lblTitleThoiHan.Size = new System.Drawing.Size(187, 25);
            this.lblTitleThoiHan.TabIndex = 1;
            this.lblTitleThoiHan.Text = "Thời hạn gói bảo hiểm";
            this.lblTitleThoiHan.Click += new System.EventHandler(this.guna2HtmlLabel3_Click);
            // 
            // lblTitleChiPhi
            // 
            this.lblTitleChiPhi.BackColor = System.Drawing.Color.Transparent;
            this.lblTitleChiPhi.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitleChiPhi.Location = new System.Drawing.Point(36, 8);
            this.lblTitleChiPhi.Name = "lblTitleChiPhi";
            this.lblTitleChiPhi.Size = new System.Drawing.Size(176, 25);
            this.lblTitleChiPhi.TabIndex = 2;
            this.lblTitleChiPhi.Text = "Tổng chi phí đã đóng";
            this.lblTitleChiPhi.Click += new System.EventHandler(this.guna2HtmlLabel4_Click);
            // 
            // lblTenGoiBaoHiem
            // 
            this.lblTenGoiBaoHiem.BackColor = System.Drawing.Color.Transparent;
            this.lblTenGoiBaoHiem.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenGoiBaoHiem.ForeColor = System.Drawing.Color.Lime;
            this.lblTenGoiBaoHiem.Location = new System.Drawing.Point(33, 43);
            this.lblTenGoiBaoHiem.Name = "lblTenGoiBaoHiem";
            this.lblTenGoiBaoHiem.Size = new System.Drawing.Size(191, 27);
            this.lblTenGoiBaoHiem.TabIndex = 3;
            this.lblTenGoiBaoHiem.Text = "Bảo hiểm sức khỏe";
            this.lblTenGoiBaoHiem.Click += new System.EventHandler(this.guna2HtmlLabel5_Click);
            // 
            // lblSoNgayConLai
            // 
            this.lblSoNgayConLai.BackColor = System.Drawing.Color.Transparent;
            this.lblSoNgayConLai.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoNgayConLai.ForeColor = System.Drawing.Color.Lime;
            this.lblSoNgayConLai.Location = new System.Drawing.Point(46, 37);
            this.lblSoNgayConLai.Name = "lblSoNgayConLai";
            this.lblSoNgayConLai.Size = new System.Drawing.Size(154, 33);
            this.lblSoNgayConLai.TabIndex = 4;
            this.lblSoNgayConLai.Text = "Còn 20 Ngày";
            this.lblSoNgayConLai.Click += new System.EventHandler(this.guna2HtmlLabel6_Click);
            // 
            // lblTongTienDaDong
            // 
            this.lblTongTienDaDong.BackColor = System.Drawing.Color.Transparent;
            this.lblTongTienDaDong.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongTienDaDong.ForeColor = System.Drawing.Color.Lime;
            this.lblTongTienDaDong.Location = new System.Drawing.Point(36, 43);
            this.lblTongTienDaDong.Name = "lblTongTienDaDong";
            this.lblTongTienDaDong.Size = new System.Drawing.Size(195, 33);
            this.lblTongTienDaDong.TabIndex = 5;
            this.lblTongTienDaDong.Text = "20.000.000 VND";
            this.lblTongTienDaDong.Click += new System.EventHandler(this.guna2HtmlLabel7_Click);
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(25)))), ((int)(((byte)(53)))));
            this.guna2PictureBox1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(25)))), ((int)(((byte)(53)))));
            this.guna2PictureBox1.Image = global::AnTam_BaoHiem.Properties.Resources.clock_removebg_preview;
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(199, 3);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(38, 39);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox1.TabIndex = 5;
            this.guna2PictureBox1.TabStop = false;
            // 
            // guna2PictureBox3
            // 
            this.guna2PictureBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(25)))), ((int)(((byte)(53)))));
            this.guna2PictureBox3.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(25)))), ((int)(((byte)(53)))));
            this.guna2PictureBox3.Image = global::AnTam_BaoHiem.Properties.Resources.money_removebg_preview;
            this.guna2PictureBox3.ImageRotate = 0F;
            this.guna2PictureBox3.Location = new System.Drawing.Point(208, 3);
            this.guna2PictureBox3.Name = "guna2PictureBox3";
            this.guna2PictureBox3.Size = new System.Drawing.Size(41, 34);
            this.guna2PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox3.TabIndex = 5;
            this.guna2PictureBox3.TabStop = false;
            // 
            // guna2PictureBox2
            // 
            this.guna2PictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(25)))), ((int)(((byte)(53)))));
            this.guna2PictureBox2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(25)))), ((int)(((byte)(53)))));
            this.guna2PictureBox2.Image = global::AnTam_BaoHiem.Properties.Resources.ticket_removebg_preview;
            this.guna2PictureBox2.ImageRotate = 0F;
            this.guna2PictureBox2.Location = new System.Drawing.Point(197, 3);
            this.guna2PictureBox2.Name = "guna2PictureBox2";
            this.guna2PictureBox2.Size = new System.Drawing.Size(41, 39);
            this.guna2PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox2.TabIndex = 4;
            this.guna2PictureBox2.TabStop = false;
            // 
            // STT
            // 
            this.STT.HeaderText = "STT";
            this.STT.MinimumWidth = 6;
            this.STT.Name = "STT";
            // 
            // loai_bao_hiem
            // 
            this.loai_bao_hiem.HeaderText = "Loại Bảo Hiểm";
            this.loai_bao_hiem.MinimumWidth = 6;
            this.loai_bao_hiem.Name = "loai_bao_hiem";
            // 
            // gia_tien
            // 
            this.gia_tien.HeaderText = "Giá Tiền";
            this.gia_tien.MinimumWidth = 6;
            this.gia_tien.Name = "gia_tien";
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
            this.txtTimKiem.Location = new System.Drawing.Point(431, 121);
            this.txtTimKiem.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.PlaceholderText = "Nhập thông tin";
            this.txtTimKiem.SelectedText = "";
            this.txtTimKiem.Size = new System.Drawing.Size(159, 25);
            this.txtTimKiem.TabIndex = 5;
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
            this.btnLoc.Location = new System.Drawing.Point(596, 121);
            this.btnLoc.Name = "btnLoc";
            this.btnLoc.Size = new System.Drawing.Size(92, 25);
            this.btnLoc.TabIndex = 7;
            this.btnLoc.Text = "Tìm kiếm";
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
            this.cboTrangThai.Location = new System.Drawing.Point(694, 119);
            this.cboTrangThai.Name = "cboTrangThai";
            this.cboTrangThai.Size = new System.Drawing.Size(108, 36);
            this.cboTrangThai.StartIndex = 0;
            this.cboTrangThai.TabIndex = 8;
            // 
            // FormLichSuMuaHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(34)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cboTrangThai);
            this.Controls.Add(this.btnLoc);
            this.Controls.Add(this.txtTimKiem);
            this.Controls.Add(this.dgvLichSuMuaHang);
            this.Controls.Add(this.lblTieuDe);
            this.Controls.Add(this.pnlThoiHan);
            this.Controls.Add(this.pnlChiPhi);
            this.Controls.Add(this.pnlMuaHang);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormLichSuMuaHang";
            this.Text = "FormLichSuMuaHang";
            this.Load += new System.EventHandler(this.FormLichSuMuaHang_Load);
            this.pnlMuaHang.ResumeLayout(false);
            this.pnlMuaHang.PerformLayout();
            this.pnlThoiHan.ResumeLayout(false);
            this.pnlThoiHan.PerformLayout();
            this.pnlChiPhi.ResumeLayout(false);
            this.pnlChiPhi.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichSuMuaHang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pnlMuaHang;
        private Guna.UI2.WinForms.Guna2Panel pnlThoiHan;
        private Guna.UI2.WinForms.Guna2Panel pnlChiPhi;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTieuDe;
        private Guna.UI2.WinForms.Guna2DataGridView dgvLichSuMuaHang;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTitleMuaHang;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTitleThoiHan;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTitleChiPhi;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTenGoiBaoHiem;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblSoNgayConLai;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTongTienDaDong;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox2;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox3;
        private System.Windows.Forms.DataGridViewTextBoxColumn STT;
        private System.Windows.Forms.DataGridViewTextBoxColumn loai_bao_hiem;
        private System.Windows.Forms.DataGridViewTextBoxColumn gia_tien;
        private System.Windows.Forms.DataGridViewTextBoxColumn thoi_han;
        private System.Windows.Forms.DataGridViewTextBoxColumn trang_thai;
        private Guna.UI2.WinForms.Guna2TextBox txtTimKiem;
        private Guna.UI2.WinForms.Guna2Button btnLoc;
        private Guna.UI2.WinForms.Guna2ComboBox cboTrangThai;
    }
}