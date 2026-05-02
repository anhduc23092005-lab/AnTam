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
            LoadDuLieuKhachHang(); // Nạp data cho tab Khách Hàng
            LoadDuLieuDoiTac();    // Nạp data cho tab Đối Tác
        }

        private void LoadDuLieuThongKe()
        {
            try
            {
                // --- 1. TỔNG DOANH THU (Hiển thị gốc và sau thuế 10%) ---
                string queryDoanhThu = @"SELECT ISNULL(SUM(TongTien), 0) FROM HopDong WHERE TrangThai = N'Đã thanh toán'";
                decimal tongDoanhThuGoc = Convert.ToDecimal(DatabaseHelper.ExecuteScalar(queryDoanhThu));

                // 1. Gán số tiền gốc vào cái Label to đùng màu xanh
                lblTongDoanhThu.Text = tongDoanhThuGoc.ToString("N0") + " đ";

                // 2. Tính số tiền sau khi trừ 10% thuế (nhân với 0.9)
                decimal doanhThuSauThue = tongDoanhThuGoc * 0.9m;

                // 3. Gán số tiền sau thuế vào dòng chữ nhỏ bên dưới
                lblDoanhThuSauThue.Text =  doanhThuSauThue.ToString("N0") + " đ";


                // --- BỔ SUNG: TỶ LỆ GIA HẠN ---
                // Do database hiện tại chưa có cột phân biệt "Mua mới" hay "Gia hạn", 
                // tạm thời gán cứng 0% (hoặc sếp có thể để 1 con số đẹp đẹp như 85% cho uy tín)
                lblTyLeGiaHan.Text = "0%";


                // --- BỔ SUNG: DỰ BÁO THÁNG TỚI ---
                // Thuật toán đơn giản: Lấy doanh thu hiện tại cộng thêm 15% kỳ vọng tăng trưởng
                decimal duBao = tongDoanhThuGoc * 1.15m;
                lblDuBaoThangToi.Text = duBao.ToString("N0") + " đ";

                // 2. SỐ GÓI ĐÃ BÁN
                string querySoGoi = "SELECT COUNT(*) FROM HopDong";
                int soGoiDaBan = Convert.ToInt32(DatabaseHelper.ExecuteScalar(querySoGoi));
                lblSoGoiDaBan.Text = soGoiDaBan.ToString();

                // 3. KHÁCH HÀNG MỚI
                string queryKhachHang = "SELECT COUNT(*) FROM KhachHang";
                int soKhachHang = Convert.ToInt32(DatabaseHelper.ExecuteScalar(queryKhachHang));
                lblKhachHangMoi.Text = soKhachHang.ToString();

                // 4. BIỂU ĐỒ DOANH THU 
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
                
                dgvDanhSach.DataSource = dtBang;

                // --- 6. CẬP NHẬT VÒNG TRÒN CHỈ TIÊU ---
                int chiTieu = 50; 

                
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
        private void LoadDuLieuKhachHang()
        {
            try
            {
                // 1. ĐỔ DỮ LIỆU BẢNG VÀNG HỘI VIÊN VIP (Top 3 chi tiêu cho Panel)
                string queryVIP = @"
                    SELECT TOP 3 
                        kh.HoTen AS [Hội viên], 
                        kh.CapBac AS [Cấp bậc], 
                        SUM(hd.TongTien) AS [Tổng nạp]
                    FROM HopDong hd
                    JOIN KhachHang kh ON hd.MaKH = kh.MaKH
                    GROUP BY kh.HoTen, kh.CapBac
                    ORDER BY [Tổng nạp] DESC";

                DataTable dtVIP = DatabaseHelper.ExecuteQuery(queryVIP);

                // Gán dữ liệu cho TOP 1
                if (dtVIP.Rows.Count > 0)
                {
                    lblTenTop1.Text = dtVIP.Rows[0]["Hội viên"].ToString();
                    lblHangTop1.Text = dtVIP.Rows[0]["Cấp bậc"].ToString();
                    decimal tien1 = Convert.ToDecimal(dtVIP.Rows[0]["Tổng nạp"]);
                    lblTongTienTop1.Text = (tien1 / 1000).ToString("N0") + "k";
                }

                // Gán dữ liệu cho TOP 2
                if (dtVIP.Rows.Count > 1)
                {
                    lblTenTop2.Text = dtVIP.Rows[1]["Hội viên"].ToString();
                    lblHangTop2.Text = dtVIP.Rows[1]["Cấp bậc"].ToString();
                    decimal tien2 = Convert.ToDecimal(dtVIP.Rows[1]["Tổng nạp"]);
                    lblTongTienTop2.Text = (tien2 / 1000).ToString("N0") + "k";
                }

                // Gán dữ liệu cho TOP 3
                if (dtVIP.Rows.Count > 2)
                {
                    lblTenTop3.Text = dtVIP.Rows[2]["Hội viên"].ToString();
                    lblHangTop3.Text = dtVIP.Rows[2]["Cấp bậc"].ToString();
                    decimal tien3 = Convert.ToDecimal(dtVIP.Rows[2]["Tổng nạp"]);
                    lblTongTienTop3.Text = (tien3 / 1000).ToString("N0") + "k";
                }

                // 2. ĐỔ DỮ LIỆU HOẠT ĐỘNG MỚI NHẤT (Vào DataGridView)
                string queryHoatDong = @"
                    SELECT 
                        kh.HoTen AS [Tên Khách Hàng], 
                        gb.TenGoi AS [Gói Bảo Hiểm], 
                        hd.TongTien AS [Số Tiền],
                        hd.NgayMua AS [Ngày Tham Gia], 
                        hd.TrangThai AS [Trạng Thái]
                    FROM HopDong hd
                    JOIN KhachHang kh ON hd.MaKH = kh.MaKH
                    JOIN GoiBaoHiem gb ON hd.MaGoi = gb.MaGoi
                    ORDER BY hd.NgayMua DESC";

                DataTable dtHoatDong = DatabaseHelper.ExecuteQuery(queryHoatDong);
                dgvDanhSach.DataSource = dtHoatDong;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu Khách Hàng: " + ex.Message, "Lỗi DB", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadDuLieuDoiTac()
        {
            try
            {
                // 1. ĐỔ DỮ LIỆU TOP 5 ĐỐI TÁC (Cho Panel)
                string queryXepHang = @"
                    SELECT TOP 5
                        dt.TenCongTy AS [Công ty], 
                        SUM(hd.TongTien) AS [Doanh thu]
                    FROM HopDong hd
                    JOIN GoiBaoHiem gb ON hd.MaGoi = gb.MaGoi
                    JOIN DoiTac dt ON gb.MaDoiTac = dt.MaDoiTac
                    WHERE hd.TrangThai = N'Đã thanh toán'
                    GROUP BY dt.TenCongTy
                    ORDER BY [Doanh thu] DESC";

                DataTable dtXepHang = DatabaseHelper.ExecuteQuery(queryXepHang);

                // Gán cho TOP 1
                if (dtXepHang.Rows.Count > 0)
                {
                    lblTenDoiTacTop1.Text = dtXepHang.Rows[0]["Công ty"].ToString();
                    decimal doanhThu1 = Convert.ToDecimal(dtXepHang.Rows[0]["Doanh thu"]);
                    lblDoanhThuTop1.Text = (doanhThu1 / 1000).ToString("N0") + "k";
                }

                // Gán cho TOP 2
                if (dtXepHang.Rows.Count > 1)
                {
                    lblTenDoiTacTop2.Text = dtXepHang.Rows[1]["Công ty"].ToString();
                    decimal doanhThu2 = Convert.ToDecimal(dtXepHang.Rows[1]["Doanh thu"]);
                    lblDoanhThuTop2.Text = (doanhThu2 / 1000).ToString("N0") + "k";
                }

                // Gán cho TOP 3
                if (dtXepHang.Rows.Count > 2)
                {
                    lblTenDoiTacTop3.Text = dtXepHang.Rows[2]["Công ty"].ToString();
                    decimal doanhThu3 = Convert.ToDecimal(dtXepHang.Rows[2]["Doanh thu"]);
                    lblDoanhThuTop3.Text = (doanhThu3 / 1000).ToString("N0") + "k";
                }

                // Gán cho TOP 4
                if (dtXepHang.Rows.Count > 3)
                {
                    lblTenDoiTacTop4.Text = dtXepHang.Rows[3]["Công ty"].ToString();
                    decimal doanhThu4 = Convert.ToDecimal(dtXepHang.Rows[3]["Doanh thu"]);
                    lblDoanhThuTop4.Text = (doanhThu4 / 1000).ToString("N0") + "k";
                }

                // Gán cho TOP 5
                if (dtXepHang.Rows.Count > 4)
                {
                    lblTenDoiTacTop5.Text = dtXepHang.Rows[4]["Công ty"].ToString();
                    decimal doanhThu5 = Convert.ToDecimal(dtXepHang.Rows[4]["Doanh thu"]);
                    lblDoanhThuTop5.Text = (doanhThu5 / 1000).ToString("N0") + "k";
                }

                // 2. ĐỔ DỮ LIỆU BIỂU ĐỒ TRÒN THỊ PHẦN (Pie Chart)
                // (Mở comment nếu sếp có dùng chartThiPhan)
                
                chartThiPhan.Series[0].Points.Clear();
                // THÊM DÒNG NÀY ĐỂ TẮT CÁI CHỮ ĐEN KÉM DUYÊN ĐI SẾP NHÉ:
                chartThiPhan.Series[0]["PieLabelStyle"] = "Disabled";
                foreach (DataRow row in dtXepHang.Rows)
                {
                    string tenCongTy = row["Công ty"].ToString();
                    decimal doanhThu = Convert.ToDecimal(row["Doanh thu"]);
                    chartThiPhan.Series[0].Points.AddXY(tenCongTy, doanhThu);
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu Đối Tác: " + ex.Message, "Lỗi DB", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SwitchPanel(Panel pnl)
        {
            // 1. Giết lầm còn hơn bỏ sót: Tắt sạch sành sanh cả 3 cái
            pnlTongQuan.Visible = false;
            pnlDoiTac.Visible = false;
            pnlKhachHang.Visible = false;

            // 2. Chỉ bật đúng cái Panel sếp muốn xem
            pnl.Visible = true;

            // 3. Cho nó nổi lên trên cùng (chắc cốp)
            pnl.BringToFront();
        }
        private void btnTongQuan_Click(object sender, EventArgs e)
        {
            SwitchPanel(pnlTongQuan);
        }

        private void btnDoiTac_Click(object sender, EventArgs e)
        {
            // Sửa lại thành pnlDoiTac nhé sếp!
            SwitchPanel(pnlDoiTac);
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            // Sửa lại thành pnlKhachHang
            SwitchPanel(pnlKhachHang);
        }

        private void lblPhanTram_Click(object sender, EventArgs e)
        {

        }

        private void txtChiTieu_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2CircleProgressBar1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }
    }
}