using System;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using AnTam_BaoHiem.Controllers;

namespace AnTam_BaoHiem.Views
{
    public partial class RegisterForm : Form
    {
        LoginController controller = new LoginController();
        string imagePath = "";

        public RegisterForm()
        {
            InitializeComponent();
        }

        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image|*.jpg;*.png";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                imagePath = ofd.FileName;
                picCCCD.ImageLocation = imagePath;
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            bool success = controller.RegisterFull(
                txtUser.Text,
                txtPass.Text,
                txtHoTen.Text,
                txtCCCD.Text,
                imagePath,
                txtSDT.Text,
                txtEmail.Text
            );

            if (success)
            {
                MessageBox.Show("Đăng ký thành công");
                this.Close();
            }
            else
            {
                MessageBox.Show("Đăng ký thất bại");
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}