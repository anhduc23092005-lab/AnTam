using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AnTam_BaoHiem.Helpers;

namespace AnTam_BaoHiem.Views
{
    public partial class frmThongKeDoanhThu : Form
    {
        public frmThongKeDoanhThu()
        {
            InitializeComponent();
            LoadDuLieuThongKe();
        }

        private void LoadDuLieuThongKe()
        {
            try
            {
                // 1. TỔNG DOANH THU (Lấy từ cột TongTien mới tạo)
                string queryDoanhThu = @"SELECT ISNULL(SUM(TongTien), 0) FROM HopDong WHERE TrangThai = N'Đã thanh toán'";
                object dtResult = DatabaseHelper.ExecuteScalar(queryDoanhThu);
                decimal tongDoanhThu = Convert.ToDecimal(dtResult);
                lblTongDoanhThu.Text = tongDoanhThu.ToString("N0") + " đ";

                // 2. SỐ GÓI ĐÃ BÁN
                string querySoGoi = "SELECT COUNT(*) FROM HopDong";
                int soGoiDaBan = Convert.ToInt32(DatabaseHelper.ExecuteScalar(querySoGoi));
                lblSoGoiDaBan.Text = soGoiDaBan.ToString();

                // 3. KHÁCH HÀNG MỚI
                string queryKhachHang = "SELECT COUNT(*) FROM KhachHang";
                int soKhachHang = Convert.ToInt32(DatabaseHelper.ExecuteScalar(queryKhachHang));
                lblKhachHangMoi.Text = soKhachHang.ToString();

                // 4. BIỂU ĐỒ DOANH THU (Cập nhật lấy theo TongTien)
                string queryBieuDo = @"
                    SELECT 
                        MONTH(NgayMua) AS Thang, 
                        SUM(TongTien) AS DoanhThu
                    FROM HopDong
                    WHERE YEAR(NgayMua) = YEAR(GETDATE()) AND TrangThai = N'Đã thanh toán'
                    GROUP BY MONTH(NgayMua)
                    ORDER BY Thang";

                DataTable dtBieuDo = DatabaseHelper.ExecuteQuery(queryBieuDo);
                chart1.Series[0].Points.Clear();

                foreach (DataRow row in dtBieuDo.Rows)
                {
                    string thang = "T" + row["Thang"].ToString();
                    decimal doanhThuThang = Convert.ToDecimal(row["DoanhThu"]);
                    chart1.Series[0].Points.AddXY(thang, doanhThuThang);
                }

                // 5. ĐỔ DỮ LIỆU VÀO BẢNG DANH SÁCH (DataGridView)
                dgvDanhSach.AutoGenerateColumns = false;
                string queryBang = @"
                    SELECT 
                        k.HoTen AS [Tên Khách Hàng], 
                        g.TenGoi AS [Gói Bảo Hiểm], 
                        h.TongTien AS [Số Tiền],
                        h.NgayMua AS [Ngày Tham Gia], 
                        h.TrangThai AS [Trạng Thái]
                    FROM HopDong h
                    JOIN KhachHang k ON h.MaKH = k.MaKH
                    JOIN GoiBaoHiem g ON h.MaGoi = g.MaGoi
                    ORDER BY h.NgayMua DESC";

                DataTable dtBang = DatabaseHelper.ExecuteQuery(queryBang);
                dgvDanhSach.AutoGenerateColumns = false;
                dgvDanhSach.DataSource = dtBang;
                // Sếp kiểm tra nếu cái bảng của sếp tên khác dgvThongKe thì sửa lại tên này nhé
                dgvDanhSach.DataSource = dtBang;

                // --- 6. CẬP NHẬT VÒNG TRÒN CHỈ TIÊU ---
                int chiTieu = 50; // Mặc định là 50

                
                if (!string.IsNullOrEmpty(txtChiTieu.Text))
                {
                    int.TryParse(txtChiTieu.Text, out chiTieu);
                }

                int phanTram = 0;
                if (chiTieu > 0)
                {
                 
                    phanTram = (soGoiDaBan * 100) / chiTieu;
                }

            
                if (phanTram > 100) phanTram = 100;

                // Cập nhật lên giao diện
                guna2CircleProgressBar1.Value = phanTram;
                lblPhanTram.Text = phanTram.ToString() + "%";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu thống kê: " + ex.Message, "Lỗi DB", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

  
        private void guna2Panel3_Paint(object sender, PaintEventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void chart1_Click(object sender, EventArgs e) { }
        private void guna2PictureBox2_Click(object sender, EventArgs e) { }
        private void label7_Click(object sender, EventArgs e) { }
        private void label9_Click(object sender, EventArgs e) { }
        private void label8_Click(object sender, EventArgs e) { }
        private void label11_Click(object sender, EventArgs e) { }
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e) { }
        private void guna2Panel1_Paint(object sender, PaintEventArgs e) { }
        private void guna2Panel2_Paint(object sender, PaintEventArgs e) { }

        private void dgvDanhSach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            // Gọi lại hàm load dữ liệu để nó tính toán lại phần trăm theo số mới
            LoadDuLieuThongKe();

            // Hiện thông báo cho nó chuyên nghiệp
            MessageBox.Show("Đã cập nhật chỉ tiêu mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        
    }
    }
}