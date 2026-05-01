namespace AnTam_BaoHiem.Views
{
    partial class FormAdminbt
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
            this.cboTrangThaiTimKiem = new System.Windows.Forms.ComboBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.dgvAdmin = new System.Windows.Forms.DataGridView();
            this.colTenGoi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblMaYeuCau = new System.Windows.Forms.Label();
            this.rtxtChiTiet = new System.Windows.Forms.RichTextBox();
            this.picAnhAdmin = new System.Windows.Forms.PictureBox();
            this.txtLyDoTuChoi = new System.Windows.Forms.TextBox();
            this.btnDuyet = new System.Windows.Forms.Button();
            this.btnTuChoi = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAdmin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAnhAdmin)).BeginInit();
            this.SuspendLayout();
            // 
            // cboTrangThaiTimKiem
            // 
            this.cboTrangThaiTimKiem.FormattingEnabled = true;
            this.cboTrangThaiTimKiem.Items.AddRange(new object[] {
            "Tất cả",
            "Chờ duyệt",
            "Đã duyệt",
            "Từ chối"});
            this.cboTrangThaiTimKiem.Location = new System.Drawing.Point(21, 384);
            this.cboTrangThaiTimKiem.Name = "cboTrangThaiTimKiem";
            this.cboTrangThaiTimKiem.Size = new System.Drawing.Size(121, 28);
            this.cboTrangThaiTimKiem.TabIndex = 0;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(12, 324);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(88, 38);
            this.btnTimKiem.TabIndex = 1;
            this.btnTimKiem.Text = "tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // dgvAdmin
            // 
            this.dgvAdmin.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAdmin.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTenGoi});
            this.dgvAdmin.Location = new System.Drawing.Point(2, 2);
            this.dgvAdmin.Name = "dgvAdmin";
            this.dgvAdmin.RowHeadersWidth = 62;
            this.dgvAdmin.RowTemplate.Height = 28;
            this.dgvAdmin.Size = new System.Drawing.Size(1273, 241);
            this.dgvAdmin.TabIndex = 2;
            this.dgvAdmin.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAdmin_CellClick);
            // 
            // colTenGoi
            // 
            this.colTenGoi.DataPropertyName = "TenGoi";
            this.colTenGoi.HeaderText = "Tên Bảo Hiểm";
            this.colTenGoi.MinimumWidth = 8;
            this.colTenGoi.Name = "colTenGoi";
            this.colTenGoi.Width = 150;
            // 
            // lblMaYeuCau
            // 
            this.lblMaYeuCau.AutoSize = true;
            this.lblMaYeuCau.Location = new System.Drawing.Point(225, 289);
            this.lblMaYeuCau.Name = "lblMaYeuCau";
            this.lblMaYeuCau.Size = new System.Drawing.Size(51, 20);
            this.lblMaYeuCau.TabIndex = 4;
            this.lblMaYeuCau.Text = "label2";
            // 
            // rtxtChiTiet
            // 
            this.rtxtChiTiet.Location = new System.Drawing.Point(342, 324);
            this.rtxtChiTiet.Name = "rtxtChiTiet";
            this.rtxtChiTiet.Size = new System.Drawing.Size(100, 96);
            this.rtxtChiTiet.TabIndex = 5;
            this.rtxtChiTiet.Text = "";
            // 
            // picAnhAdmin
            // 
            this.picAnhAdmin.Location = new System.Drawing.Point(498, 266);
            this.picAnhAdmin.Name = "picAnhAdmin";
            this.picAnhAdmin.Size = new System.Drawing.Size(147, 154);
            this.picAnhAdmin.TabIndex = 6;
            this.picAnhAdmin.TabStop = false;
            // 
            // txtLyDoTuChoi
            // 
            this.txtLyDoTuChoi.Location = new System.Drawing.Point(1085, 271);
            this.txtLyDoTuChoi.Name = "txtLyDoTuChoi";
            this.txtLyDoTuChoi.Size = new System.Drawing.Size(100, 26);
            this.txtLyDoTuChoi.TabIndex = 7;
            // 
            // btnDuyet
            // 
            this.btnDuyet.Location = new System.Drawing.Point(1085, 313);
            this.btnDuyet.Name = "btnDuyet";
            this.btnDuyet.Size = new System.Drawing.Size(100, 49);
            this.btnDuyet.TabIndex = 8;
            this.btnDuyet.Text = "duyet";
            this.btnDuyet.UseVisualStyleBackColor = true;
            this.btnDuyet.Click += new System.EventHandler(this.btnDuyet_Click);
            // 
            // btnTuChoi
            // 
            this.btnTuChoi.Location = new System.Drawing.Point(1085, 384);
            this.btnTuChoi.Name = "btnTuChoi";
            this.btnTuChoi.Size = new System.Drawing.Size(110, 36);
            this.btnTuChoi.TabIndex = 9;
            this.btnTuChoi.Text = "tu choi";
            this.btnTuChoi.UseVisualStyleBackColor = true;
            this.btnTuChoi.Click += new System.EventHandler(this.btnTuChoi_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1002, 274);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 20);
            this.label3.TabIndex = 11;
            this.label3.Text = "Lý Do";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(351, 274);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 20);
            this.label1.TabIndex = 12;
            this.label1.Text = "lý do yêu cầu";
            // 
            // FormAdminbt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1278, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnTuChoi);
            this.Controls.Add(this.btnDuyet);
            this.Controls.Add(this.txtLyDoTuChoi);
            this.Controls.Add(this.picAnhAdmin);
            this.Controls.Add(this.rtxtChiTiet);
            this.Controls.Add(this.lblMaYeuCau);
            this.Controls.Add(this.dgvAdmin);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.cboTrangThaiTimKiem);
            this.Name = "FormAdminbt";
            this.Text = "FormAdminbt";
            this.Load += new System.EventHandler(this.FormAdminbt_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAdmin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAnhAdmin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboTrangThaiTimKiem;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.DataGridView dgvAdmin;
        private System.Windows.Forms.Label lblMaYeuCau;
        private System.Windows.Forms.RichTextBox rtxtChiTiet;
        private System.Windows.Forms.PictureBox picAnhAdmin;
        private System.Windows.Forms.TextBox txtLyDoTuChoi;
        private System.Windows.Forms.Button btnDuyet;
        private System.Windows.Forms.Button btnTuChoi;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenGoi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
    }
}