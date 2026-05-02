using AnTam_BaoHiem.Helpers; // Nhớ gọi Helper để xài Database
using AnTam_BaoHiem.Models;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace AnTam_BaoHiem.Views
{
    public partial class frmThanhToanKhachHang : Form
    {
        
        // Các biến toàn cục để lưu trữ dữ liệu truyền vào và tính toán
        public int maKhachHang;
        private int maGoiBaoHiem;
        private decimal phiGoc = 0;
        private decimal tongTienCuoiCung = 0;
        public decimal tongTienThanhToan;

        // --- PHẦN MỚI THÊM: Biến lưu hình thức khách chọn ---
        private string _hinhThucChon = "Trả một lần"; // Mặc định là trả 1 lần
                                                      // ---------------------------------------------------

        // Cổng nhận dữ liệu (Constructor)
        public frmThanhToanKhachHang(int maKH, int maGoi)
        {
            InitializeComponent();

            // --- BƠM THẲNG DATA TEST VÀO ĐÂY ĐỂ ÉP NÓ CHẠY 100% ---
            this.maKhachHang = maKH;   // Khách hàng aNHDUC (Hạng Vàng)
            this.maGoiBaoHiem = 1;  // Gói 15 củ

            // Sinh mã hợp đồng ngẫu nhiên
            txtMaHopDong.Text = $"HD-{DateTime.Now.Year}-{new Random().Next(1000, 9999)}";

            // Gọi hàm tính toán và lôi data
            LoadDuLieuThanhToan();
            // ------------------------------------------------------
        }

        // Sự kiện khi Form vừa mở lên
        private void frmThanhToanKhachHang_Load(object sender, EventArgs e)
        {
         
            // --- PHẦN MỚI THÊM: Ẩn 2 panel phụ lúc mới mở form ---
            // LƯU Ý: Sếp đổi chữ pnlTraGop và pnlDatLich thành đúng (Name) của 2 cái Panel trên Form sếp nhé!
            pnlTraGop.Visible = false;
            pnlDatLich.Visible = false;
            // ------------------------------------------------------
        }

        private void LoadDuLieuThanhToan()
        {
            // (GIỮ NGUYÊN 100% CODE CỦA SẾP Ở ĐÂY, KHÔNG THAY ĐỔI GÌ)
            try
            {
                string queryKH = $"SELECT HoTen, CapBac FROM KhachHang WHERE MaKH = {maKhachHang}";
                DataTable dtKH = DatabaseHelper.ExecuteQuery(queryKH);

                string capBac = "Đồng";
                decimal phanTramGiam = 0m;

                if (dtKH.Rows.Count > 0)
                {
                    txtTenKhachHang.Text = dtKH.Rows[0]["HoTen"].ToString();
                    if (dtKH.Rows[0]["CapBac"] != DBNull.Value)
                    {
                        capBac = dtKH.Rows[0]["CapBac"].ToString();
                    }
                }

                txtCapBac.Text = "Hội viên " + capBac;

                switch (capBac.ToLower().Trim())
                {
                    case "bạc": phanTramGiam = 0.02m; break;
                    case "vàng": phanTramGiam = 0.05m; break;
                    case "kim cương": phanTramGiam = 0.10m; break;
                    default: phanTramGiam = 0m; break;
                }

                string queryGoi = $"SELECT TenGoi, GiaTien FROM GoiBaoHiem WHERE MaGoi = {maGoiBaoHiem}";
                DataTable dtGoi = DatabaseHelper.ExecuteQuery(queryGoi);

                if (dtGoi.Rows.Count > 0)
                {
                    txtTenGoi.Text = dtGoi.Rows[0]["TenGoi"].ToString();
                    phiGoc = Convert.ToDecimal(dtGoi.Rows[0]["GiaTien"]);

                    decimal chietKhau = phiGoc * phanTramGiam;
                    decimal giaSauChietKhau = phiGoc - chietKhau;
                    decimal vat = giaSauChietKhau * 0.10m;

                    tongTienCuoiCung = giaSauChietKhau + vat;

                    lblPhiGoc.Text = phiGoc.ToString("N0") + " đ";

                    if (phanTramGiam > 0)
                        lblChietKhau.Text = $"- {chietKhau:N0} đ (Giảm {phanTramGiam * 100}%)";
                    else
                        lblChietKhau.Text = "0 đ";

                    lblVAT.Text = vat.ToString("N0") + " đ";
                    
                    this.tongTienThanhToan = tongTienCuoiCung;
                    TinhLaiTien(0);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải thông tin: " + ex.Message, "Lỗi DB", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // HÀM MỚI: Tự động tính toán lại giá tiền khi bấm các nút
        private void TinhLaiTien(int soThang)
        {
            if (soThang == 0) // Khi sếp chọn "Trả 1 lần" hoặc "Tiền mặt"
            {
                tongTienThanhToan = tongTienCuoiCung;

                // Cập nhật số tiền to đùng là 1 cục
                lblGiaTienTong.Text = tongTienThanhToan.ToString("N0") + " VNĐ";

                // Ẩn cái dòng ghi chú nhỏ ở dưới đi
                lblGhiChuTongTien.Visible = false;
            }
            else // Khi sếp bấm vào các nút Trả góp (3, 6, 12 tháng)
            {
                // Trả góp 0% lãi suất nên tổng tiền vẫn giữ nguyên
                tongTienThanhToan = tongTienCuoiCung;

                // Băm đều tiền ra cho các tháng
                decimal tienMoiThang = tongTienThanhToan / soThang;

                // HIỂN THỊ LÊN GIAO DIỆN

                // Số to đùng màu tím: Hiển thị tiền đóng mỗi tháng
                lblGiaTienTong.Text = tienMoiThang.ToString("N0") + " VNĐ / Tháng";

                // Số nhỏ xíu bên dưới: Bật nó lên và nhét tổng tiền vào
                lblGhiChuTongTien.Visible = true;
                lblGhiChuTongTien.Text = $"Tổng giá trị thanh toán: {tongTienThanhToan:N0} đ (trong {soThang} tháng)";
            }
        }

        // --- PHẦN MỚI THÊM: SỰ KIỆN CLICK CHO 3 NÚT CHỌN HÌNH THỨC ---
        // LƯU Ý: Sếp qua giao diện, nhấp đúp vào 3 nút thanh toán để tạo sự kiện, rồi dán ruột vào nhé

        // -------------------------------------------------------------

        // Giữ lại nút Hủy của sếp
        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // ĐÂY LÀ NÚT XÁC NHẬN CHÍNH CỦA SẾP
        private void btnXacNhan_Click_1(object sender, EventArgs e)
        {
            if (this.maKhachHang <= 0)
            {
                MessageBox.Show("Lỗi: Không tìm thấy thông tin khách hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Xác nhận thanh toán hợp đồng này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection conn = DatabaseHelper.GetConnection())
                    {
                        conn.Open();
                        // 1. Câu lệnh SQL - Đảm bảo viết liền mạch hoặc nối chuỗi đúng
                        string query = "INSERT INTO HopDong (MaHD, MaKH, MaGoi, NgayMua, TrangThai, TongTien) " +
                                       "VALUES (@MaHD, @MaKH, @MaGoi, @NgayMua, @TrangThai, @TongTien)";

                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            // 2. Truyền tham số - Dùng giá trị trên form cho MaHD
                            cmd.Parameters.AddWithValue("@MaHD", txtMaHopDong.Text);
                            cmd.Parameters.AddWithValue("@MaKH", this.maKhachHang);
                            cmd.Parameters.AddWithValue("@MaGoi", this.maGoiBaoHiem);
                            cmd.Parameters.AddWithValue("@NgayMua", DateTime.Now);
                            cmd.Parameters.AddWithValue("@TrangThai", "Đã thanh toán");
                            cmd.Parameters.AddWithValue("@TongTien", this.tongTienThanhToan); // Dùng biến tổng tiền của Class

                            cmd.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Thanh toán và tạo hợp đồng thành công!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi Database: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Bỏ qua cái btnXacNhan_Click cũ (em nghĩ sếp không dùng tới nó vì không có tham số @)

        private void lblChietKhau_Click(object sender, EventArgs e) { }
        private void guna2PictureBox3_Click(object sender, EventArgs e) { }
        private void guna2Panel4_Paint(object sender, PaintEventArgs e) { }

        private void btnTraMotLan_Click_1(object sender, EventArgs e)
        {
            _hinhThucChon = "Trả một lần";

            // 1. Hiện bảng Trả 1 lần (quét QR/Chuyển khoản...), tắt 2 bảng kia
            plntra1lan.Visible = true;
            pnlTraGop.Visible = false;
            pnlDatLich.Visible = false;
            plntra1lan.BringToFront(); // Nổi lên trên cùng

            // 2. Đổi màu nút
            btnTraMotLan.FillColor = Color.FromArgb(128, 90, 255);
            btnTraGop.FillColor = Color.FromArgb(30, 30, 45);
            btnTienMat.FillColor = Color.FromArgb(30, 30, 45);

            // 3. Tính tiền 1 cục
            TinhLaiTien(0);
        }

        private void btnTraGop_Click(object sender, EventArgs e)
        {
            _hinhThucChon = "Trả góp";

            // 1. Hiện bảng Trả góp, tắt bảng Trả 1 lần và bảng Tiền mặt
            pnlTraGop.Visible = true;
            plntra1lan.Visible = false;
            pnlDatLich.Visible = false;
            pnlTraGop.BringToFront();

            // 2. Đổi màu nút
            btnTraMotLan.FillColor = Color.FromArgb(30, 30, 45);
            btnTraGop.FillColor = Color.FromArgb(128, 90, 255);
            btnTienMat.FillColor = Color.FromArgb(30, 30, 45);

            // 3. Ép chọn 3 tháng
            btn3Thang.PerformClick();
        }

        private void btnTienMat_Click(object sender, EventArgs e)
        {
            _hinhThucChon = "Tiền mặt";

            // 1. Hiện bảng Tiền mặt (pnlDatLich cũ của sếp), tắt 2 bảng kia
            pnlDatLich.Visible = true;
            plntra1lan.Visible = false;
            pnlTraGop.Visible = false;
            pnlDatLich.BringToFront();

            // 2. Đổi màu nút
            btnTraMotLan.FillColor = Color.FromArgb(30, 30, 45);
            btnTraGop.FillColor = Color.FromArgb(30, 30, 45);
            btnTienMat.FillColor = Color.FromArgb(128, 90, 255);

            // 3. Tính tiền 1 cục
            TinhLaiTien(0);
        }

        private void btn3Thang_Click(object sender, EventArgs e)
        {
           
            // Đổi màu để nhận diện nút đang chọn (Màu tím)
            btn3Thang.FillColor = Color.FromArgb(128, 90, 255);
            // 2 nút kia cho về màu tối
            btn6Thang.FillColor = Color.FromArgb(30, 30, 45);
            btn12Thang.FillColor = Color.FromArgb(30, 30, 45);
            TinhLaiTien(3); // Tính tiền chia 3 tháng
        }

        private void btn6Thang_Click(object sender, EventArgs e)
        {
            // 6 Tháng sáng (Màu tím)
            btn6Thang.FillColor = Color.FromArgb(128, 90, 255);
            // 3 Tháng và 12 Tháng tối (Màu đen)
            btn3Thang.FillColor = Color.FromArgb(30, 30, 45);
            btn12Thang.FillColor = Color.FromArgb(30, 30, 45);
            TinhLaiTien(6); // Tính tiền chia 6 tháng (thêm 5% lãi)
        }

        private void btn12Thang_Click(object sender, EventArgs e)
        {
            // 12 Tháng sáng (Màu tím)
            btn12Thang.FillColor = Color.FromArgb(128, 90, 255);
            // 3 Tháng và 6 Tháng tối (Màu đen)
            btn3Thang.FillColor = Color.FromArgb(30, 30, 45);
            btn6Thang.FillColor = Color.FromArgb(30, 30, 45);
            TinhLaiTien(12); // Tính tiền chia 12 tháng (thêm 10% lãi)
        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void label25_Click(object sender, EventArgs e)
        {

        }
    }
}