using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AnTam_BaoHiem.Controllers;
using AnTam_BaoHiem.Models;

namespace AnTam_BaoHiem
{
    public partial class FormKhachHangbt : Form
    {
        BoiThuongController _controller = new BoiThuongController();
        int _maKH_HienTai = 1; // Giả sử ID khách hàng đăng nhập là 1
        public FormKhachHangbt()
        {
            InitializeComponent();
            LoadHopDong();
        }
        private void LoadHopDong()
        {
            // Lấy các hợp đồng đang hiệu lực của khách hàng
            DataTable dt = _controller.LayDanhSachHopDongHieuLuc(_maKH_HienTai);

            cboHopDong.DataSource = dt;
            cboHopDong.DisplayMember = "TenGoi"; // Hiển thị tên gói (Xe cộ, Y tế...)
            cboHopDong.ValueMember = "MaHD";    // Giá trị ẩn là mã hợp đồng
        }

        private void btnGuiYeuCau_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtLyDo.Text) || string.IsNullOrEmpty(txtSoTien.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ lý do và số tiền!");
                return;
            }

            int maHD = (int)cboHopDong.SelectedValue;
            decimal soTien = decimal.Parse(txtSoTien.Text);
            string lyDo = txtLyDo.Text;

            bool thanhCong = _controller.GuiYeuCauBoiThuong(maHD, soTien, lyDo);

            if (thanhCong)
            {
                MessageBox.Show("Gửi yêu cầu bồi thường thành công! Vui lòng chờ Admin duyệt.");
                txtLyDo.Clear();
                txtSoTien.Clear();
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra, vui lòng thử lại.");
            }
        }
        public int MaKH_HienTai;

        public FormKhachHangbt(int maKH) // Thêm tham số nhận vào
        {
            InitializeComponent();
            this.MaKH_HienTai = maKH;
            // Bây giờ bạn có thể dùng MaKH_HienTai để thực hiện mua bảo hiểm hoặc bồi thường
        }
    }
}
