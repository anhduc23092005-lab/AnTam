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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnMuaBaoHiem = new System.Windows.Forms.Button();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.txtSoDienThoai = new System.Windows.Forms.TextBox();
            this.txtHoTenKhach = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rtbChiTietGoi = new System.Windows.Forms.RichTextBox();
            this.lblMucPhi_ChiTiet = new System.Windows.Forms.Label();
            this.lblTenGoi_ChiTiet = new System.Windows.Forms.Label();
            this.picAnhChiTiet = new System.Windows.Forms.PictureBox();
            this.flpDanhSachGoi.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAnhChiTiet)).BeginInit();
            this.SuspendLayout();
            // 
            // flpDanhSachGoi
            // 
            this.flpDanhSachGoi.Controls.Add(this.txtTimKiem);
            this.flpDanhSachGoi.Controls.Add(this.btnTimKiem);
            this.flpDanhSachGoi.Dock = System.Windows.Forms.DockStyle.Left;
            this.flpDanhSachGoi.Location = new System.Drawing.Point(0, 0);
            this.flpDanhSachGoi.Name = "flpDanhSachGoi";
            this.flpDanhSachGoi.Size = new System.Drawing.Size(249, 604);
            this.flpDanhSachGoi.TabIndex = 0;
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(3, 3);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(167, 22);
            this.txtTimKiem.TabIndex = 0;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(3, 31);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(85, 23);
            this.btnTimKiem.TabIndex = 1;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.rtbChiTietGoi);
            this.panel1.Controls.Add(this.flpDanhSachGoi);
            this.panel1.Controls.Add(this.lblMucPhi_ChiTiet);
            this.panel1.Controls.Add(this.lblTenGoi_ChiTiet);
            this.panel1.Controls.Add(this.picAnhChiTiet);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(911, 604);
            this.panel1.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.groupBox1.Controls.Add(this.btnMuaBaoHiem);
            this.groupBox1.Controls.Add(this.txtEmail);
            this.groupBox1.Controls.Add(this.txtDiaChi);
            this.groupBox1.Controls.Add(this.txtSoDienThoai);
            this.groupBox1.Controls.Add(this.txtHoTenKhach);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(258, 459);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(572, 145);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Đăng ký ngay";
            // 
            // btnMuaBaoHiem
            // 
            this.btnMuaBaoHiem.Location = new System.Drawing.Point(420, 46);
            this.btnMuaBaoHiem.Name = "btnMuaBaoHiem";
            this.btnMuaBaoHiem.Size = new System.Drawing.Size(95, 64);
            this.btnMuaBaoHiem.TabIndex = 8;
            this.btnMuaBaoHiem.Text = "Mua ";
            this.btnMuaBaoHiem.UseVisualStyleBackColor = true;
            this.btnMuaBaoHiem.Click += new System.EventHandler(this.btnMuaBaoHiem_Click);
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(105, 117);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(223, 22);
            this.txtEmail.TabIndex = 7;
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(105, 88);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(223, 22);
            this.txtDiaChi.TabIndex = 6;
            // 
            // txtSoDienThoai
            // 
            this.txtSoDienThoai.Location = new System.Drawing.Point(105, 57);
            this.txtSoDienThoai.Name = "txtSoDienThoai";
            this.txtSoDienThoai.Size = new System.Drawing.Size(223, 22);
            this.txtSoDienThoai.TabIndex = 5;
            // 
            // txtHoTenKhach
            // 
            this.txtHoTenKhach.Location = new System.Drawing.Point(105, 27);
            this.txtHoTenKhach.Name = "txtHoTenKhach";
            this.txtHoTenKhach.Size = new System.Drawing.Size(223, 22);
            this.txtHoTenKhach.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Email:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Địa chỉ:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Số điện thoại:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Họ và tên:";
            // 
            // rtbChiTietGoi
            // 
            this.rtbChiTietGoi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbChiTietGoi.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbChiTietGoi.Location = new System.Drawing.Point(267, 276);
            this.rtbChiTietGoi.Name = "rtbChiTietGoi";
            this.rtbChiTietGoi.ReadOnly = true;
            this.rtbChiTietGoi.Size = new System.Drawing.Size(618, 164);
            this.rtbChiTietGoi.TabIndex = 3;
            this.rtbChiTietGoi.Text = "";
            // 
            // lblMucPhi_ChiTiet
            // 
            this.lblMucPhi_ChiTiet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMucPhi_ChiTiet.AutoSize = true;
            this.lblMucPhi_ChiTiet.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold);
            this.lblMucPhi_ChiTiet.Location = new System.Drawing.Point(533, 232);
            this.lblMucPhi_ChiTiet.Name = "lblMucPhi_ChiTiet";
            this.lblMucPhi_ChiTiet.Size = new System.Drawing.Size(120, 32);
            this.lblMucPhi_ChiTiet.TabIndex = 2;
            this.lblMucPhi_ChiTiet.Text = "Mức phí";
            // 
            // lblTenGoi_ChiTiet
            // 
            this.lblTenGoi_ChiTiet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTenGoi_ChiTiet.AutoSize = true;
            this.lblTenGoi_ChiTiet.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenGoi_ChiTiet.Location = new System.Drawing.Point(537, 186);
            this.lblTenGoi_ChiTiet.Name = "lblTenGoi_ChiTiet";
            this.lblTenGoi_ChiTiet.Size = new System.Drawing.Size(116, 32);
            this.lblTenGoi_ChiTiet.TabIndex = 1;
            this.lblTenGoi_ChiTiet.Text = "Tên gói";
            // 
            // picAnhChiTiet
            // 
            this.picAnhChiTiet.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.picAnhChiTiet.Location = new System.Drawing.Point(425, 6);
            this.picAnhChiTiet.Name = "picAnhChiTiet";
            this.picAnhChiTiet.Size = new System.Drawing.Size(384, 177);
            this.picAnhChiTiet.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picAnhChiTiet.TabIndex = 0;
            this.picAnhChiTiet.TabStop = false;
            // 
            // frmXemBaoHiem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(911, 604);
            this.Controls.Add(this.panel1);
            this.Name = "frmXemBaoHiem";
            this.Text = "frmXemBaoHiem";
            this.Load += new System.EventHandler(this.frmXemBaoHiem_Load);
            this.flpDanhSachGoi.ResumeLayout(false);
            this.flpDanhSachGoi.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.TextBox txtSoDienThoai;
        private System.Windows.Forms.TextBox txtHoTenKhach;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnMuaBaoHiem;
    }
}