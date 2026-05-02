// Forms/LoginForm.Designer.cs
using Guna.UI2.WinForms;
using System.Windows.Forms;

namespace AnTam_BaoHiem.Views
{
    partial class LoginForm
    {
        private Guna2Panel panel;
        private Guna2CirclePictureBox logo;

        private Guna2TextBox txtUser;
        private Guna2TextBox txtPass;

        private Guna2Button btnLogin;
        private Guna2Button btnRegister;
        private Guna2Button btnForgot;

        private void InitializeComponent()
        {
            this.panel = new Guna.UI2.WinForms.Guna2Panel();
            this.logo = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.txtUser = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtPass = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnLogin = new Guna.UI2.WinForms.Guna2Button();
            this.btnRegister = new Guna.UI2.WinForms.Guna2Button();
            this.btnForgot = new Guna.UI2.WinForms.Guna2Button();
            this.panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).BeginInit();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.BackColor = System.Drawing.Color.Transparent;
            this.panel.BorderRadius = 15;
            this.panel.Controls.Add(this.logo);
            this.panel.Controls.Add(this.txtUser);
            this.panel.Controls.Add(this.txtPass);
            this.panel.Controls.Add(this.btnLogin);
            this.panel.Controls.Add(this.btnRegister);
            this.panel.Controls.Add(this.btnForgot);
            this.panel.FillColor = System.Drawing.Color.White;
            this.panel.Location = new System.Drawing.Point(-8, -6);
            this.panel.Name = "panel";
            this.panel.ShadowDecoration.Enabled = true;
            this.panel.Size = new System.Drawing.Size(370, 406);
            this.panel.TabIndex = 0;
            // 
            // logo
            // 
            this.logo.Image = global::AnTam_BaoHiem.Properties.Resources.Ảnh_chụp_màn_hình_2026_04_21_155931;
            this.logo.ImageRotate = 0F;
            this.logo.Location = new System.Drawing.Point(35, 18);
            this.logo.Name = "logo";
            this.logo.Size = new System.Drawing.Size(289, 90);
            this.logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.logo.TabIndex = 0;
            this.logo.TabStop = false;
            // 
            // txtUser
            // 
            this.txtUser.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtUser.DefaultText = "";
            this.txtUser.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtUser.Location = new System.Drawing.Point(49, 129);
            this.txtUser.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtUser.Name = "txtUser";
            this.txtUser.PlaceholderText = "Username";
            this.txtUser.SelectedText = "";
            this.txtUser.Size = new System.Drawing.Size(251, 48);
            this.txtUser.TabIndex = 1;
            // 
            // txtPass
            // 
            this.txtPass.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPass.DefaultText = "";
            this.txtPass.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtPass.Location = new System.Drawing.Point(49, 194);
            this.txtPass.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPass.Name = "txtPass";
            this.txtPass.PasswordChar = '*';
            this.txtPass.PlaceholderText = "Password";
            this.txtPass.SelectedText = "";
            this.txtPass.Size = new System.Drawing.Size(251, 48);
            this.txtPass.TabIndex = 2;
            // 
            // btnLogin
            // 
            this.btnLogin.BorderRadius = 10;
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(49, 262);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(251, 45);
            this.btnLogin.TabIndex = 3;
            this.btnLogin.Text = "Đăng nhập";
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnRegister
            // 
            this.btnRegister.AutoRoundedCorners = true;
            this.btnRegister.FillColor = System.Drawing.Color.Gray;
            this.btnRegister.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnRegister.ForeColor = System.Drawing.Color.White;
            this.btnRegister.Location = new System.Drawing.Point(49, 324);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(116, 44);
            this.btnRegister.TabIndex = 4;
            this.btnRegister.Text = "Đăng ký";
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // btnForgot
            // 
            this.btnForgot.AutoRoundedCorners = true;
            this.btnForgot.FillColor = System.Drawing.Color.Orange;
            this.btnForgot.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnForgot.ForeColor = System.Drawing.Color.White;
            this.btnForgot.Location = new System.Drawing.Point(190, 324);
            this.btnForgot.Name = "btnForgot";
            this.btnForgot.Size = new System.Drawing.Size(110, 44);
            this.btnForgot.TabIndex = 5;
            this.btnForgot.Text = "Quên MK";
            this.btnForgot.Click += new System.EventHandler(this.btnForgot_Click);
            // 
            // LoginForm
            // 
            this.ClientSize = new System.Drawing.Size(339, 397);
            this.Controls.Add(this.panel);
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.logo)).EndInit();
            this.ResumeLayout(false);

        }
    }
}