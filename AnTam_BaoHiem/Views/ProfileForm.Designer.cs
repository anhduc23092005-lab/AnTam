using System;
using System.Windows.Forms;
using Guna.UI2.WinForms;

partial class ProfileForm
{
    private System.ComponentModel.IContainer components = null;

    private Guna.UI2.WinForms.Guna2HtmlLabel lblTitle;
    private Guna.UI2.WinForms.Guna2HtmlLabel lblHoTen;
    private Guna.UI2.WinForms.Guna2HtmlLabel lblSoDienThoai;
    private Guna.UI2.WinForms.Guna2HtmlLabel lblEmail;
    private Guna.UI2.WinForms.Guna2HtmlLabel lblCCCD;

    private Guna.UI2.WinForms.Guna2TextBox txtHoTen;
    private Guna.UI2.WinForms.Guna2TextBox txtSoDienThoai;
    private Guna.UI2.WinForms.Guna2TextBox txtEmail;
    private Guna.UI2.WinForms.Guna2TextBox txtCCCD;

    private Guna.UI2.WinForms.Guna2Button btnChinhSua;
    private Guna.UI2.WinForms.Guna2Button btnLuu;
    private Guna.UI2.WinForms.Guna2Button btnHuy;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
            this.lblTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblHoTen = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblSoDienThoai = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblEmail = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblCCCD = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.txtHoTen = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtSoDienThoai = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtEmail = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtCCCD = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnChinhSua = new Guna.UI2.WinForms.Guna2Button();
            this.btnLuu = new Guna.UI2.WinForms.Guna2Button();
            this.btnHuy = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(80, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(246, 39);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Thông Tin Cá Nhân";
            this.lblTitle.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHoTen
            // 
            this.lblHoTen.BackColor = System.Drawing.Color.Transparent;
            this.lblHoTen.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblHoTen.Location = new System.Drawing.Point(40, 90);
            this.lblHoTen.Name = "lblHoTen";
            this.lblHoTen.Size = new System.Drawing.Size(65, 25);
            this.lblHoTen.TabIndex = 1;
            this.lblHoTen.Text = "Họ Tên:";
            // 
            // lblSoDienThoai
            // 
            this.lblSoDienThoai.BackColor = System.Drawing.Color.Transparent;
            this.lblSoDienThoai.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSoDienThoai.Location = new System.Drawing.Point(36, 145);
            this.lblSoDienThoai.Name = "lblSoDienThoai";
            this.lblSoDienThoai.Size = new System.Drawing.Size(56, 25);
            this.lblSoDienThoai.TabIndex = 3;
            this.lblSoDienThoai.Text = "Số ĐT:";
            // 
            // lblEmail
            // 
            this.lblEmail.BackColor = System.Drawing.Color.Transparent;
            this.lblEmail.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblEmail.Location = new System.Drawing.Point(40, 200);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(52, 25);
            this.lblEmail.TabIndex = 5;
            this.lblEmail.Text = "Email:";
            // 
            // lblCCCD
            // 
            this.lblCCCD.BackColor = System.Drawing.Color.Transparent;
            this.lblCCCD.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblCCCD.Location = new System.Drawing.Point(42, 255);
            this.lblCCCD.Name = "lblCCCD";
            this.lblCCCD.Size = new System.Drawing.Size(54, 25);
            this.lblCCCD.TabIndex = 7;
            this.lblCCCD.Text = "CCCD:";
            // 
            // txtHoTen
            // 
            this.txtHoTen.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtHoTen.DefaultText = "";
            this.txtHoTen.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.txtHoTen.Location = new System.Drawing.Point(140, 80);
            this.txtHoTen.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.PlaceholderText = "Nhập họ tên";
            this.txtHoTen.SelectedText = "";
            this.txtHoTen.Size = new System.Drawing.Size(220, 35);
            this.txtHoTen.TabIndex = 2;
            // 
            // txtSoDienThoai
            // 
            this.txtSoDienThoai.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSoDienThoai.DefaultText = "";
            this.txtSoDienThoai.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.txtSoDienThoai.Location = new System.Drawing.Point(140, 135);
            this.txtSoDienThoai.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSoDienThoai.Name = "txtSoDienThoai";
            this.txtSoDienThoai.PlaceholderText = "Nhập số điện thoại";
            this.txtSoDienThoai.SelectedText = "";
            this.txtSoDienThoai.Size = new System.Drawing.Size(220, 35);
            this.txtSoDienThoai.TabIndex = 4;
            // 
            // txtEmail
            // 
            this.txtEmail.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEmail.DefaultText = "";
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.txtEmail.Location = new System.Drawing.Point(140, 190);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.PlaceholderText = "Nhập email";
            this.txtEmail.SelectedText = "";
            this.txtEmail.Size = new System.Drawing.Size(220, 35);
            this.txtEmail.TabIndex = 6;
            // 
            // txtCCCD
            // 
            this.txtCCCD.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCCCD.DefaultText = "";
            this.txtCCCD.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.txtCCCD.Location = new System.Drawing.Point(140, 245);
            this.txtCCCD.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCCCD.Name = "txtCCCD";
            this.txtCCCD.PlaceholderText = "";
            this.txtCCCD.SelectedText = "";
            this.txtCCCD.Size = new System.Drawing.Size(220, 35);
            this.txtCCCD.TabIndex = 8;
            // 
            // btnChinhSua
            // 
            this.btnChinhSua.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnChinhSua.ForeColor = System.Drawing.Color.White;
            this.btnChinhSua.Location = new System.Drawing.Point(140, 310);
            this.btnChinhSua.Name = "btnChinhSua";
            this.btnChinhSua.Size = new System.Drawing.Size(220, 40);
            this.btnChinhSua.TabIndex = 9;
            this.btnChinhSua.Text = "Chỉnh Sửa";
            this.btnChinhSua.Click += new System.EventHandler(this.btnChinhSua_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLuu.ForeColor = System.Drawing.Color.White;
            this.btnLuu.Location = new System.Drawing.Point(140, 310);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(100, 40);
            this.btnLuu.TabIndex = 10;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.Visible = false;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.FillColor = System.Drawing.Color.Gray;
            this.btnHuy.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnHuy.ForeColor = System.Drawing.Color.White;
            this.btnHuy.Location = new System.Drawing.Point(260, 310);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(100, 40);
            this.btnHuy.TabIndex = 11;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.Visible = false;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // ProfileForm
            // 
            this.ClientSize = new System.Drawing.Size(419, 380);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblHoTen);
            this.Controls.Add(this.txtHoTen);
            this.Controls.Add(this.lblSoDienThoai);
            this.Controls.Add(this.txtSoDienThoai);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblCCCD);
            this.Controls.Add(this.txtCCCD);
            this.Controls.Add(this.btnChinhSua);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.btnHuy);
            this.Name = "ProfileForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thông Tin Cá Nhân";
            this.ResumeLayout(false);
            this.PerformLayout();

    }
}