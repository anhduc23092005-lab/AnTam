using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using AnTam_BaoHiem.Controllers;

namespace AnTam_BaoHiem.Views
{
    public partial class FormKhachHangbt : Form
    {
        private BoiThuongController _controller;
        private string duongDanAnhDaChon = "";
        private int maKhachHangHienTai = 2; 

        public FormKhachHangbt()
        {
            InitializeComponent();
            _controller = new BoiThuongController();
            LoadDanhSach();
        }

        private void LoadDanhSach()
        {
            dgvYeuCauKH.DataSource = _controller.LayYeuCauKhachHang(maKhachHangHienTai);
        }

        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    duongDanAnhDaChon = ofd.FileName;
                    picMinhChung.Image = Image.FromFile(duongDanAnhDaChon);
                    picMinhChung.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }
        }

        private void btnGuiYeuCau_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaHD.Text) || string.IsNullOrEmpty(rtxtNoiDung.Text))
            {
                MessageBox.Show("Vui lòng nhập Mã HĐ và Nội dung!");
                return;
            }
            string savedPath = "";
            if (!string.IsNullOrEmpty(duongDanAnhDaChon))
            {
                string folder = Path.Combine(Application.StartupPath, "Uploads");
                if (!Directory.Exists(folder)) Directory.CreateDirectory(folder);
                string fileName = DateTime.Now.Ticks + Path.GetExtension(duongDanAnhDaChon);
                savedPath = Path.Combine(folder, fileName);
                File.Copy(duongDanAnhDaChon, savedPath);
            }

            bool result = _controller.GuiYeuCau(int.Parse(txtMaHD.Text), rtxtNoiDung.Text, savedPath);
            if (result)
            {
                MessageBox.Show("Gửi yêu cầu thành công!");
                LoadDanhSach();
            }
        }

        private void FormKhachHangbt_Load(object sender, EventArgs e)
        {

        }
    }
}