namespace AnTam_BaoHiem.Views
{
    partial class frmXemBaoHiem
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
            this.flpDanhSachGoi = new System.Windows.Forms.FlowLayoutPanel();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnMuaBaoHiem = new System.Windows.Forms.Button();
            this.rtbChiTietGoi = new System.Windows.Forms.RichTextBox();
            this.lblMucPhi_ChiTiet = new System.Windows.Forms.Label();
            this.lblTenGoi_ChiTiet = new System.Windows.Forms.Label();
            this.picAnhChiTiet = new System.Windows.Forms.PictureBox();
            this.cbxLocCongTy = new System.Windows.Forms.ComboBox();
            this.cbxSapXep = new System.Windows.Forms.ComboBox();
            this.btnTuVan = new System.Windows.Forms.Button();
            this.btnSoSanh = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAnhChiTiet)).BeginInit();
            this.SuspendLayout();
            // 
            // flpDanhSachGoi
            // 
            this.flpDanhSachGoi.BackColor = System.Drawing.Color.RoyalBlue;
            this.flpDanhSachGoi.Dock = System.Windows.Forms.DockStyle.Left;
            this.flpDanhSachGoi.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flpDanhSachGoi.Location = new System.Drawing.Point(0, 0);
            this.flpDanhSachGoi.Name = "flpDanhSachGoi";
            this.flpDanhSachGoi.Size = new System.Drawing.Size(249, 604);
            this.flpDanhSachGoi.TabIndex = 0;
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtTimKiem.Location = new System.Drawing.Point(497, 12);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(253, 34);
            this.txtTimKiem.TabIndex = 0;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimKiem.Location = new System.Drawing.Point(558, 65);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(119, 46);
            this.btnTimKiem.TabIndex = 1;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel1.Controls.Add(this.btnSoSanh);
            this.panel1.Controls.Add(this.btnTuVan);
            this.panel1.Controls.Add(this.cbxSapXep);
            this.panel1.Controls.Add(this.cbxLocCongTy);
            this.panel1.Controls.Add(this.btnMuaBaoHiem);
            this.panel1.Controls.Add(this.txtTimKiem);
            this.panel1.Controls.Add(this.btnTimKiem);
            this.panel1.Controls.Add(this.rtbChiTietGoi);
            this.panel1.Controls.Add(this.flpDanhSachGoi);
            this.panel1.Controls.Add(this.lblMucPhi_ChiTiet);
            this.panel1.Controls.Add(this.lblTenGoi_ChiTiet);
            this.panel1.Controls.Add(this.picAnhChiTiet);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1286, 604);
            this.panel1.TabIndex = 1;
            // 
            // btnMuaBaoHiem
            // 
            this.btnMuaBaoHiem.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnMuaBaoHiem.ForeColor = System.Drawing.SystemColors.InfoText;
            this.btnMuaBaoHiem.Location = new System.Drawing.Point(638, 528);
            this.btnMuaBaoHiem.Name = "btnMuaBaoHiem";
            this.btnMuaBaoHiem.Size = new System.Drawing.Size(162, 64);
            this.btnMuaBaoHiem.TabIndex = 8;
            this.btnMuaBaoHiem.Text = "Mua ";
            this.btnMuaBaoHiem.UseVisualStyleBackColor = true;
            this.btnMuaBaoHiem.Click += new System.EventHandler(this.btnMuaBaoHiem_Click);
            // 
            // rtbChiTietGoi
            // 
            this.rtbChiTietGoi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbChiTietGoi.BackColor = System.Drawing.SystemColors.Info;
            this.rtbChiTietGoi.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbChiTietGoi.Location = new System.Drawing.Point(248, 276);
            this.rtbChiTietGoi.Name = "rtbChiTietGoi";
            this.rtbChiTietGoi.ReadOnly = true;
            this.rtbChiTietGoi.Size = new System.Drawing.Size(1035, 246);
            this.rtbChiTietGoi.TabIndex = 3;
            this.rtbChiTietGoi.Text = "";
            // 
            // lblMucPhi_ChiTiet
            // 
            this.lblMucPhi_ChiTiet.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblMucPhi_ChiTiet.AutoSize = true;
            this.lblMucPhi_ChiTiet.Font = new System.Drawing.Font("Segoe UI Semibold", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMucPhi_ChiTiet.Location = new System.Drawing.Point(969, 238);
            this.lblMucPhi_ChiTiet.Name = "lblMucPhi_ChiTiet";
            this.lblMucPhi_ChiTiet.Size = new System.Drawing.Size(121, 38);
            this.lblMucPhi_ChiTiet.TabIndex = 2;
            this.lblMucPhi_ChiTiet.Text = "Mức phí";
            // 
            // lblTenGoi_ChiTiet
            // 
            this.lblTenGoi_ChiTiet.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTenGoi_ChiTiet.AutoSize = true;
            this.lblTenGoi_ChiTiet.Font = new System.Drawing.Font("Segoe UI Semibold", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenGoi_ChiTiet.Location = new System.Drawing.Point(973, 192);
            this.lblTenGoi_ChiTiet.Name = "lblTenGoi_ChiTiet";
            this.lblTenGoi_ChiTiet.Size = new System.Drawing.Size(109, 38);
            this.lblTenGoi_ChiTiet.TabIndex = 1;
            this.lblTenGoi_ChiTiet.Text = "Tên gói";
            // 
            // picAnhChiTiet
            // 
            this.picAnhChiTiet.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.picAnhChiTiet.Location = new System.Drawing.Point(840, 12);
            this.picAnhChiTiet.Name = "picAnhChiTiet";
            this.picAnhChiTiet.Size = new System.Drawing.Size(384, 177);
            this.picAnhChiTiet.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picAnhChiTiet.TabIndex = 0;
            this.picAnhChiTiet.TabStop = false;
            // 
            // cbxLocCongTy
            // 
            this.cbxLocCongTy.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxLocCongTy.FormattingEnabled = true;
            this.cbxLocCongTy.Items.AddRange(new object[] {
            "Tất cả công ty",
            "Tổng Công ty Bảo Việt Nhân Thọ (Bảo Việt Life)",
            "Công ty TNHH Bảo hiểm Nhân thọ Prudential Việt Nam",
            "Công ty TNHH Bảo hiểm Nhân thọ Manulife Việt Nam",
            "Công ty TNHH Bảo hiểm Nhân thọ AIA Việt Nam",
            "Công ty THHH 1 thành viên DUCKCOP"});
            this.cbxLocCongTy.Location = new System.Drawing.Point(271, 12);
            this.cbxLocCongTy.Name = "cbxLocCongTy";
            this.cbxLocCongTy.Size = new System.Drawing.Size(220, 36);
            this.cbxLocCongTy.TabIndex = 9;
            // 
            // cbxSapXep
            // 
            this.cbxSapXep.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cbxSapXep.FormattingEnabled = true;
            this.cbxSapXep.Location = new System.Drawing.Point(271, 71);
            this.cbxSapXep.Name = "cbxSapXep";
            this.cbxSapXep.Size = new System.Drawing.Size(220, 36);
            this.cbxSapXep.TabIndex = 10;
            // 
            // btnTuVan
            // 
            this.btnTuVan.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTuVan.Location = new System.Drawing.Point(298, 163);
            this.btnTuVan.Name = "btnTuVan";
            this.btnTuVan.Size = new System.Drawing.Size(80, 50);
            this.btnTuVan.TabIndex = 11;
            this.btnTuVan.Text = "Tư vấn gói phù hợp";
            this.btnTuVan.UseVisualStyleBackColor = true;
            // 
            // btnSoSanh
            // 
            this.btnSoSanh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSoSanh.Location = new System.Drawing.Point(420, 163);
            this.btnSoSanh.Name = "btnSoSanh";
            this.btnSoSanh.Size = new System.Drawing.Size(80, 50);
            this.btnSoSanh.TabIndex = 12;
            this.btnSoSanh.Text = "So sánh gói";
            this.btnSoSanh.UseVisualStyleBackColor = true;
            // 
            // frmXemBaoHiem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1286, 604);
            this.Controls.Add(this.panel1);
            this.Name = "frmXemBaoHiem";
            this.Text = "frmXemBaoHiem";
            this.Load += new System.EventHandler(this.frmXemBaoHiem_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAnhChiTiet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpDanhSachGoi;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RichTextBox rtbChiTietGoi;
        private System.Windows.Forms.Label lblMucPhi_ChiTiet;
        private System.Windows.Forms.Label lblTenGoi_ChiTiet;
        private System.Windows.Forms.PictureBox picAnhChiTiet;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Button btnMuaBaoHiem;
        private System.Windows.Forms.ComboBox cbxSapXep;
        private System.Windows.Forms.ComboBox cbxLocCongTy;
        private System.Windows.Forms.Button btnSoSanh;
        private System.Windows.Forms.Button btnTuVan;
    }
}