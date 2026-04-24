namespace AnTam_BaoHiem
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
            this.cboHopDong = new System.Windows.Forms.ComboBox();
            this.txtLyDo = new System.Windows.Forms.TextBox();
            this.txtSoTien = new System.Windows.Forms.TextBox();
            this.btnGuiYeuCau = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cboHopDong
            // 
            this.cboHopDong.FormattingEnabled = true;
            this.cboHopDong.Location = new System.Drawing.Point(240, 84);
            this.cboHopDong.Name = "cboHopDong";
            this.cboHopDong.Size = new System.Drawing.Size(121, 28);
            this.cboHopDong.TabIndex = 2;
            // 
            // txtLyDo
            // 
            this.txtLyDo.Location = new System.Drawing.Point(240, 144);
            this.txtLyDo.Name = "txtLyDo";
            this.txtLyDo.Size = new System.Drawing.Size(100, 26);
            this.txtLyDo.TabIndex = 3;
            // 
            // txtSoTien
            // 
            this.txtSoTien.Location = new System.Drawing.Point(240, 194);
            this.txtSoTien.Name = "txtSoTien";
            this.txtSoTien.Size = new System.Drawing.Size(100, 26);
            this.txtSoTien.TabIndex = 4;
            // 
            // btnGuiYeuCau
            // 
            this.btnGuiYeuCau.Location = new System.Drawing.Point(240, 247);
            this.btnGuiYeuCau.Name = "btnGuiYeuCau";
            this.btnGuiYeuCau.Size = new System.Drawing.Size(75, 23);
            this.btnGuiYeuCau.TabIndex = 5;
            this.btnGuiYeuCau.Text = "Gui";
            this.btnGuiYeuCau.UseVisualStyleBackColor = true;
            this.btnGuiYeuCau.Click += new System.EventHandler(this.btnGuiYeuCau_Click);
            // 
            // FormKhachHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnGuiYeuCau);
            this.Controls.Add(this.txtSoTien);
            this.Controls.Add(this.txtLyDo);
            this.Controls.Add(this.cboHopDong);
            this.Name = "FormKhachHang";
            this.Text = "FormKhachHang";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboHopDong;
        private System.Windows.Forms.TextBox txtLyDo;
        private System.Windows.Forms.TextBox txtSoTien;
        private System.Windows.Forms.Button btnGuiYeuCau;
    }
}