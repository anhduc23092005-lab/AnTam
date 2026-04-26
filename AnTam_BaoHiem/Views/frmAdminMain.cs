using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnTam_BaoHiem.Views
{
    public partial class frmAdminMain : Form
    {
        public frmAdminMain()
        {
            InitializeComponent();

        }
        // Biến lưu trữ Form đang mở hiện tại
        private Form activeForm = null;

        // Hàm mở Form con và nhét vào panel1
        private void OpenChildForm(Form childForm)
        {
            // Nếu đang có Form con nào mở thì đóng nó lại
            if (activeForm != null)
            {
                activeForm.Close();
            }

            // Gán form mới vào biến
            activeForm = childForm;

            // Ép form con biến thành một "Control" bình thường để nhét vừa vào Panel
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            // panel1 là cái khoảng trống màu xám to đùng trên giao diện Admin của sếp
            panel3.Controls.Add(childForm);
            panel3.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnthanhtoan_Click(object sender, EventArgs e)
        {
            ButtonOff();
            btnthanhtoan.FillColor = Color.FromArgb(50, 100, 201);
            btnthanhtoan.FillColor2 = Color.FromArgb(144, 117, 203);
            TitleLable.Text = btnthanhtoan.Text;
            OpenChildForm(new frmThongKeDoanhThu());
        }
            
        private void btnnguoilaodong_Click(object sender, EventArgs e)
        {
            ButtonOff();
            btnnguoilaodong.FillColor = Color.FromArgb(50, 100, 201);
            btnnguoilaodong.FillColor2 = Color.FromArgb(144, 117, 203);
            TitleLable.Text = btnnguoilaodong.Text;
            OpenChildForm(new frmQuanLyGoiBaoHiem());
        }

        private void btnbaohiem_Click(object sender, EventArgs e)
        {
            ButtonOff();
            btnbaohiem.FillColor = Color.FromArgb(50, 100, 201);
            btnbaohiem.FillColor2 = Color.FromArgb(144, 117, 203);
            TitleLable.Text = btnbaohiem.Text;
        }

        private void btntaikhoan_Click(object sender, EventArgs e)
        {
            ButtonOff();
            btntaikhoan.FillColor = Color.FromArgb(50, 100, 201);
            btntaikhoan.FillColor2 = Color.FromArgb(144, 117, 203);
            TitleLable.Text = btntaikhoan.Text;
        }

        private void btndangxuat_Click(object sender, EventArgs e)
        {
            ButtonOff();
            btndangxuat.FillColor = Color.FromArgb(50, 100, 201);
            btndangxuat.FillColor2 = Color.FromArgb(144, 117, 203);
            TitleLable.Text = btndangxuat.Text;
        }

        private void ButtonOff()
        {
            btnnguoilaodong.FillColor = Color.Transparent;
            btnnguoilaodong.FillColor2 = Color.Transparent;

            btnbaohiem.FillColor = Color.Transparent;
            btnbaohiem.FillColor2 = Color.Transparent;

            btntaikhoan.FillColor = Color.Transparent;
            btntaikhoan.FillColor2 = Color.Transparent;

            btnthanhtoan.FillColor = Color.Transparent;
            btnthanhtoan.FillColor2 = Color.Transparent;

            btndangxuat.FillColor = Color.Transparent;
            btndangxuat.FillColor2 = Color.Transparent;

        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnMax_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Normal;
            }
            else
            {
                WindowState = FormWindowState.Maximized;
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void TitleLable_Click(object sender, EventArgs e)
        {

        }

        private void form1_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
