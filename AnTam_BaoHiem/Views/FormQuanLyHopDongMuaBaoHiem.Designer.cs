namespace FormQuanLyHopDongMuaBaoHiem
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTongHopDong = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.lblConHieuLuc = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblChoPheDuyet = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblSapHetHan = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.dgvHopDong = new System.Windows.Forms.DataGridView();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnXuatFile = new System.Windows.Forms.Button();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.cboLocTrangThai = new System.Windows.Forms.ComboBox();
            this.colSTT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaHD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaKH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenCongTy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaCongTy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaGoi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNgayKy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNgayHetHan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTongTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTrangThai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHopDong)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(25)))), ((int)(((byte)(53)))));
            this.panel1.Controls.Add(this.lblTongHopDong);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(415, 211);
            this.panel1.TabIndex = 0;
            // 
            // lblTongHopDong
            // 
            this.lblTongHopDong.AutoSize = true;
            this.lblTongHopDong.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongHopDong.ForeColor = System.Drawing.Color.Lime;
            this.lblTongHopDong.Location = new System.Drawing.Point(91, 103);
            this.lblTongHopDong.Name = "lblTongHopDong";
            this.lblTongHopDong.Size = new System.Drawing.Size(237, 45);
            this.lblTongHopDong.TabIndex = 6;
            this.lblTongHopDong.Text = "30 Hợp đồng";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(26, 23);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(269, 37);
            this.label8.TabIndex = 7;
            this.label8.Text = "Tổng số hợp đồng";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(25)))), ((int)(((byte)(53)))));
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.lblConHieuLuc);
            this.panel2.Location = new System.Drawing.Point(1486, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(415, 211);
            this.panel2.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(101, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(196, 37);
            this.label4.TabIndex = 3;
            this.label4.Text = "Còn hiệu lực";
            // 
            // lblConHieuLuc
            // 
            this.lblConHieuLuc.AutoSize = true;
            this.lblConHieuLuc.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConHieuLuc.ForeColor = System.Drawing.Color.Lime;
            this.lblConHieuLuc.Location = new System.Drawing.Point(100, 103);
            this.lblConHieuLuc.Name = "lblConHieuLuc";
            this.lblConHieuLuc.Size = new System.Drawing.Size(237, 45);
            this.lblConHieuLuc.TabIndex = 2;
            this.lblConHieuLuc.Text = "10 Hợp đồng";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(25)))), ((int)(((byte)(53)))));
            this.panel3.Controls.Add(this.lblChoPheDuyet);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Location = new System.Drawing.Point(503, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(415, 211);
            this.panel3.TabIndex = 0;
            // 
            // lblChoPheDuyet
            // 
            this.lblChoPheDuyet.AutoSize = true;
            this.lblChoPheDuyet.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChoPheDuyet.ForeColor = System.Drawing.Color.Yellow;
            this.lblChoPheDuyet.Location = new System.Drawing.Point(95, 103);
            this.lblChoPheDuyet.Name = "lblChoPheDuyet";
            this.lblChoPheDuyet.Size = new System.Drawing.Size(217, 45);
            this.lblChoPheDuyet.TabIndex = 4;
            this.lblChoPheDuyet.Text = "2 Hợp đồng";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(67, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(222, 37);
            this.label6.TabIndex = 5;
            this.label6.Text = "Chờ phê duyệt";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(25)))), ((int)(((byte)(53)))));
            this.panel4.Controls.Add(this.lblSapHetHan);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Location = new System.Drawing.Point(999, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(415, 211);
            this.panel4.TabIndex = 0;
            // 
            // lblSapHetHan
            // 
            this.lblSapHetHan.AutoSize = true;
            this.lblSapHetHan.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSapHetHan.ForeColor = System.Drawing.Color.Red;
            this.lblSapHetHan.Location = new System.Drawing.Point(104, 103);
            this.lblSapHetHan.Name = "lblSapHetHan";
            this.lblSapHetHan.Size = new System.Drawing.Size(217, 45);
            this.lblSapHetHan.TabIndex = 1;
            this.lblSapHetHan.Text = "5 Hợp đồng";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(93, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sắp hết hạn";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Yellow;
            this.label9.Location = new System.Drawing.Point(335, 277);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(1496, 90);
            this.label9.TabIndex = 8;
            this.label9.Text = "QUẢN LÝ HỢP ĐỒNG MUA BẢO HIỂM";
            // 
            // dgvHopDong
            // 
            this.dgvHopDong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHopDong.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSTT,
            this.colMaHD,
            this.colMaKH,
            this.colTenCongTy,
            this.colMaCongTy,
            this.colMaGoi,
            this.colNgayKy,
            this.colNgayHetHan,
            this.colTongTien,
            this.colTrangThai});
            this.dgvHopDong.Location = new System.Drawing.Point(0, 503);
            this.dgvHopDong.Name = "dgvHopDong";
            this.dgvHopDong.RowHeadersWidth = 51;
            this.dgvHopDong.RowTemplate.Height = 24;
            this.dgvHopDong.Size = new System.Drawing.Size(1901, 535);
            this.dgvHopDong.TabIndex = 9;
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(64, 437);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(99, 44);
            this.btnThem.TabIndex = 10;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnXuatFile
            // 
            this.btnXuatFile.Location = new System.Drawing.Point(475, 436);
            this.btnXuatFile.Name = "btnXuatFile";
            this.btnXuatFile.Size = new System.Drawing.Size(99, 43);
            this.btnXuatFile.TabIndex = 11;
            this.btnXuatFile.Text = "Xuất File";
            this.btnXuatFile.UseVisualStyleBackColor = true;
            this.btnXuatFile.Click += new System.EventHandler(this.btnXuatFile_Click);
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(1594, 427);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(99, 43);
            this.btnTimKiem.TabIndex = 12;
            this.btnTimKiem.Text = "Tìm Kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(206, 437);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(99, 43);
            this.btnSua.TabIndex = 13;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(339, 436);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(99, 44);
            this.btnXoa.TabIndex = 14;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(1263, 448);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(254, 22);
            this.txtTimKiem.TabIndex = 15;
            // 
            // cboLocTrangThai
            // 
            this.cboLocTrangThai.FormattingEnabled = true;
            this.cboLocTrangThai.Items.AddRange(new object[] {
            "Tất cả",
            "Còn hiệu lực",
            "Chờ phê duyệt",
            "Sắp hết hạn"});
            this.cboLocTrangThai.Location = new System.Drawing.Point(1769, 446);
            this.cboLocTrangThai.Name = "cboLocTrangThai";
            this.cboLocTrangThai.Size = new System.Drawing.Size(121, 24);
            this.cboLocTrangThai.TabIndex = 16;
            // 
            // colSTT
            // 
            this.colSTT.HeaderText = "STT";
            this.colSTT.MinimumWidth = 6;
            this.colSTT.Name = "colSTT";
            this.colSTT.Width = 125;
            // 
            // colMaHD
            // 
            this.colMaHD.DataPropertyName = "MaHD";
            this.colMaHD.HeaderText = "Mã Hợp Đồng";
            this.colMaHD.MinimumWidth = 6;
            this.colMaHD.Name = "colMaHD";
            this.colMaHD.Width = 125;
            // 
            // colMaKH
            // 
            this.colMaKH.DataPropertyName = "MaKH";
            this.colMaKH.HeaderText = "Mã Khách Hàng";
            this.colMaKH.MinimumWidth = 6;
            this.colMaKH.Name = "colMaKH";
            this.colMaKH.Width = 125;
            // 
            // colTenCongTy
            // 
            this.colTenCongTy.DataPropertyName = "TenCongTy";
            this.colTenCongTy.HeaderText = "Tên Công Ty";
            this.colTenCongTy.MinimumWidth = 6;
            this.colTenCongTy.Name = "colTenCongTy";
            this.colTenCongTy.Width = 125;
            // 
            // colMaCongTy
            // 
            this.colMaCongTy.DataPropertyName = "MaCongTy";
            this.colMaCongTy.HeaderText = "Mã Công Ty";
            this.colMaCongTy.MinimumWidth = 6;
            this.colMaCongTy.Name = "colMaCongTy";
            this.colMaCongTy.Width = 125;
            // 
            // colMaGoi
            // 
            this.colMaGoi.DataPropertyName = "MaGoi";
            this.colMaGoi.HeaderText = "Mã Gói";
            this.colMaGoi.MinimumWidth = 6;
            this.colMaGoi.Name = "colMaGoi";
            this.colMaGoi.Width = 125;
            // 
            // colNgayKy
            // 
            this.colNgayKy.DataPropertyName = "NgayKy";
            this.colNgayKy.HeaderText = "Ngày Ký";
            this.colNgayKy.MinimumWidth = 6;
            this.colNgayKy.Name = "colNgayKy";
            this.colNgayKy.Width = 125;
            // 
            // colNgayHetHan
            // 
            this.colNgayHetHan.DataPropertyName = "NgayHetHan";
            this.colNgayHetHan.HeaderText = "Ngày Hết Hạn";
            this.colNgayHetHan.MinimumWidth = 6;
            this.colNgayHetHan.Name = "colNgayHetHan";
            this.colNgayHetHan.Width = 125;
            // 
            // colTongTien
            // 
            this.colTongTien.DataPropertyName = "TongTien";
            this.colTongTien.HeaderText = "Tổng Tiền";
            this.colTongTien.MinimumWidth = 6;
            this.colTongTien.Name = "colTongTien";
            this.colTongTien.Width = 125;
            // 
            // colTrangThai
            // 
            this.colTrangThai.DataPropertyName = "TrangThai";
            this.colTrangThai.HeaderText = "Trạng Thái";
            this.colTrangThai.MinimumWidth = 6;
            this.colTrangThai.Name = "colTrangThai";
            this.colTrangThai.Width = 125;
            // 
            // FormQuanLyHopDongMuaBaoHiem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(34)))));
            this.ClientSize = new System.Drawing.Size(1902, 1033);
            this.Controls.Add(this.cboLocTrangThai);
            this.Controls.Add(this.txtTimKiem);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.btnXuatFile);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.dgvHopDong);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FormQuanLyHopDongMuaBaoHiem";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FormQuanLyHopDongMuaBaoHiem_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHopDong)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblTongHopDong;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblChoPheDuyet;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblConHieuLuc;
        private System.Windows.Forms.Label lblSapHetHan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView dgvHopDong;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnXuatFile;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.ComboBox cboLocTrangThai;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSTT;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaHD;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaKH;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenCongTy;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaCongTy;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaGoi;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNgayKy;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNgayHetHan;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTongTien;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTrangThai;
    }
}

