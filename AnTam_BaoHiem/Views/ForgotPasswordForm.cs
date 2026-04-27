using System;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using AnTam_BaoHiem.Controllers;

namespace AnTam_BaoHiem.Views
{
    public partial class ForgotPasswordForm : Form
    {
        LoginController controller = new LoginController();

        public ForgotPasswordForm()
        {
            InitializeComponent();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            bool success = controller.ResetPassword(email);

            if (success)
            {
                MessageBox.Show("Mật khẩu đã được gửi đến email của bạn.");
                this.Close();
            }
            else
            {
                MessageBox.Show("Email không tồn tại hoặc lỗi xảy ra.");
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}