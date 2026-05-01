namespace AnTam_BaoHiem.Views
{
    partial class FormKhachHangbt
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
            this.txtMaHD = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rtxtNoiDung = new System.Windows.Forms.RichTextBox();
            this.btnGuiYeuCau = new System.Windows.Forms.Button();
            this.btnChonAnh = new System.Windows.Forms.Button();
            this.dgvYeuCauKH = new System.Windows.Forms.DataGridView();
            this.colTenGoi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.picMinhChung = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvYeuCauKH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMinhChung)).BeginInit();
            this.SuspendLayout();
            // 
            // txtMaHD
            // 
            this.txtMaHD.Location = new System.Drawing.Point(152, 42);
            this.txtMaHD.Name = "txtMaHD";
            this.txtMaHD.Size = new System.Drawing.Size(100, 26);
            this.txtMaHD.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mã Hợp Đồng";
            // 
            // rtxtNoiDung
            // 
            this.rtxtNoiDung.Location = new System.Drawing.Point(152, 74);
            this.rtxtNoiDung.Name = "rtxtNoiDung";
            this.rtxtNoiDung.Size = new System.Drawing.Size(100, 96);
            this.rtxtNoiDung.TabIndex = 2;
            this.rtxtNoiDung.Text = "";
            // 
            // btnGuiYeuCau
            // 
            this.btnGuiYeuCau.Location = new System.Drawing.Point(137, 237);
            this.btnGuiYeuCau.Name = "btnGuiYeuCau";
            this.btnGuiYeuCau.Size = new System.Drawing.Size(101, 33);
            this.btnGuiYeuCau.TabIndex = 3;
            this.btnGuiYeuCau.Text = "Gửi";
            this.btnGuiYeuCau.UseVisualStyleBackColor = true;
            this.btnGuiYeuCau.Click += new System.EventHandler(this.btnGuiYeuCau_Click);
            // 
            // btnChonAnh
            // 
            this.btnChonAnh.Location = new System.Drawing.Point(436, 190);
            this.btnChonAnh.Name = "btnChonAnh";
            this.btnChonAnh.Size = new System.Drawing.Size(123, 43);
            this.btnChonAnh.TabIndex = 4;
            this.btnChonAnh.Text = "Chọn ảnh";
            this.btnChonAnh.UseVisualStyleBackColor = true;
            this.btnChonAnh.Click += new System.EventHandler(this.btnChonAnh_Click);
            // 
            // dgvYeuCauKH
            // 
            this.dgvYeuCauKH.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvYeuCauKH.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTenGoi});
            this.dgvYeuCauKH.Location = new System.Drawing.Point(12, 304);
            this.dgvYeuCauKH.Name = "dgvYeuCauKH";
            this.dgvYeuCauKH.RowHeadersWidth = 62;
            this.dgvYeuCauKH.RowTemplate.Height = 28;
            this.dgvYeuCauKH.Size = new System.Drawing.Size(1239, 150);
            this.dgvYeuCauKH.TabIndex = 5;
            // 
            // colTenGoi
            // 
            this.colTenGoi.DataPropertyName = "TenGoi";
            this.colTenGoi.HeaderText = "Tên Bảo Hiểm";
            this.colTenGoi.MinimumWidth = 8;
            this.colTenGoi.Name = "colTenGoi";
            this.colTenGoi.Width = 150;
            // 
            // picMinhChung
            // 
            this.picMinhChung.Location = new System.Drawing.Point(436, 26);
            this.picMinhChung.Name = "picMinhChung";
            this.picMinhChung.Size = new System.Drawing.Size(316, 144);
            this.picMinhChung.TabIndex = 6;
            this.picMinhChung.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "nhập lý do";
            // 
            // FormKhachHangbt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1263, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.picMinhChung);
            this.Controls.Add(this.dgvYeuCauKH);
            this.Controls.Add(this.btnChonAnh);
            this.Controls.Add(this.btnGuiYeuCau);
            this.Controls.Add(this.rtxtNoiDung);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMaHD);
            this.Name = "FormKhachHangbt";
            this.Text = "FormKhachHangbt";
            this.Load += new System.EventHandler(this.FormKhachHangbt_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvYeuCauKH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMinhChung)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMaHD;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox rtxtNoiDung;
        private System.Windows.Forms.Button btnGuiYeuCau;
        private System.Windows.Forms.Button btnChonAnh;
        private System.Windows.Forms.DataGridView dgvYeuCauKH;
        private System.Windows.Forms.PictureBox picMinhChung;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenGoi;
        private System.Windows.Forms.Label label2;
    }
}