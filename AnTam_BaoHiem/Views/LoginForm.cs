// Forms/LoginForm.cs
using System;
using System.Windows.Forms;

namespace AnTam_BaoHiem.Views
{
    public partial class LoginForm : Form
    {
        LoginController controller = new LoginController();

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var user = controller.Login(txtUser.Text, txtPass.Text);

            if (user == null)
            {
                MessageBox.Show("Sai tài khoản hoặc mật khẩu");
                return;
            }

            if (user.LoaiTaiKhoan == "Admin")
            {
                MainAdminForm mainAdminForm = new MainAdminForm();
                this.Hide();
                mainAdminForm.ShowDialog();
                this.Show();
                this.ClearLoginFields();
            }
            else
            {
                MainUserForm mainUserForm = new MainUserForm(user.TenDangNhap);
                this.Hide();
                mainUserForm.ShowDialog();
                this.Show();
                this.ClearLoginFields();
            }
        }

        private void ClearLoginFields()
        {
            txtUser.Text = "";
            txtPass.Text = "";
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            new RegisterForm().ShowDialog();
        }

        private void btnForgot_Click(object sender, EventArgs e)
        {
            new ForgotPasswordForm().ShowDialog();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}