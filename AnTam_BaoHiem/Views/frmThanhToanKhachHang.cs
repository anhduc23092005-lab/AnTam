using AnTam_BaoHiem.Helpers; // Nhớ gọi Helper để xài Database
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AnTam_BaoHiem.Views
{
    public partial class frmThanhToanKhachHang : Form
    {
        // Các biến toàn cục để lưu trữ dữ liệu truyền vào và tính toán
        private int maKhachHang;
        private int maGoiBaoHiem;
        private decimal phiGoc = 0;
        private decimal tongTienCuoiCung = 0;
        public decimal tongTienThanhToan; // <--- THÊM DÒNG NÀY VÀO ĐÂY
        // Cổng nhận dữ liệu (Constructor)
        public frmThanhToanKhachHang(int maKH, int maGoi)
        {
            InitializeComponent();

            // Gán ID từ form khác truyền sang (hoặc từ Program.cs truyền vào)
            this.maKhachHang = maKH;
            this.maGoiBaoHiem = maGoi;

            // SẾP PHẢI THÊM DÒNG NÀY ĐỂ NÓ KÉO DỮ LIỆU NHÉ!
            LoadDuLieuThanhToan();
        }

        // Sự kiện khi Form vừa mở lên
        private void frmThanhToanKhachHang_Load(object sender, EventArgs e)
        {
            // 1. Tự động sinh Mã Hợp Đồng cho ngầu (VD: HD-2026-1234)
            // Sếp nhớ đặt tên ô TextBox Mã hợp đồng là txtMaHopDong nhé
            txtMaHopDong.Text = $"HD-{DateTime.Now.Year}-{new Random().Next(1000, 9999)}";

            // 2. Chạy hàm load dữ liệu
            LoadDuLieuThanhToan();
        }

        private void LoadDuLieuThanhToan()
        {
            try
            {
                // 1. Kéo tên Khách hàng VÀ Cấp bậc từ Database
                // Giả sử bảng KhachHang có cột CapBac (chứa các chữ: Đồng, Bạc, Vàng, Kim Cương)
                string queryKH = $"SELECT HoTen, CapBac FROM KhachHang WHERE MaKH = {maKhachHang}";
                DataTable dtKH = DatabaseHelper.ExecuteQuery(queryKH);

                string capBac = "Đồng"; // Mặc định nếu không có dữ liệu thì là Đồng
                decimal phanTramGiam = 0m;

                if (dtKH.Rows.Count > 0)
                {
                    txtTenKhachHang.Text = dtKH.Rows[0]["HoTen"].ToString();

                    // Lấy cấp bậc (Kiểm tra an toàn tránh lỗi NULL)
                    if (dtKH.Rows[0]["CapBac"] != DBNull.Value)
                    {
                        capBac = dtKH.Rows[0]["CapBac"].ToString();
                    }
                }

                // Hiển thị chữ Hội viên lên Form (Sếp đặt Name cho TextBox này là txtCapBac nhé)
                txtCapBac.Text = "Hội viên " + capBac;

                // XÁC ĐỊNH % GIẢM GIÁ DỰA TRÊN CẤP BẬC
                // Sếp có thể tự chỉnh lại con số % này cho hợp với ý đồ đồ án nhé
                switch (capBac.ToLower().Trim())
                {
                    case "bạc":
                        phanTramGiam = 0.02m; // Giảm 2%
                        break;
                    case "vàng":
                        phanTramGiam = 0.05m; // Giảm 5%
                        break;
                    case "kim cương":
                        phanTramGiam = 0.10m; // Giảm 10%
                        break;
                    default:
                        phanTramGiam = 0m;    // Đồng hoặc chưa có hạng: Giảm 0%
                        break;
                }

                // 2. Kéo tên Gói bảo hiểm và Giá tiền từ Database
                string queryGoi = $"SELECT TenGoi, GiaTien FROM GoiBaoHiem WHERE MaGoi = {maGoiBaoHiem}";
                DataTable dtGoi = DatabaseHelper.ExecuteQuery(queryGoi);

                if (dtGoi.Rows.Count > 0)
                {
                    txtTenGoi.Text = dtGoi.Rows[0]["TenGoi"].ToString();
                    phiGoc = Convert.ToDecimal(dtGoi.Rows[0]["GiaTien"]);

                    // 3. Tính toán tiền với cái phanTramGiam vừa tìm được ở trên
                    decimal chietKhau = phiGoc * phanTramGiam;
                    decimal giaSauChietKhau = phiGoc - chietKhau;
                    decimal vat = giaSauChietKhau * 0.10m; // Thuế VAT 10%

                    tongTienCuoiCung = giaSauChietKhau + vat;

                    // 4. Đổ dữ liệu ra các Label
                    lblPhiGoc.Text = phiGoc.ToString("N0") + " đ";

                    // Nếu phần trăm giảm > 0 thì in ra số tiền trừ, không thì in 0 đ
                    if (phanTramGiam > 0)
                        lblChietKhau.Text = $"- {chietKhau:N0} đ (Giảm {phanTramGiam * 100}%)";
                    else
                        lblChietKhau.Text = "0 đ";

                    lblVAT.Text = vat.ToString("N0") + " đ";
                    lblGiaTienTong.Text = tongTienCuoiCung.ToString("N0");
                    // Gán giá trị vào biến toàn cục trước khi in ra label
                    this.tongTienThanhToan = tongTienCuoiCung;
                    lblGiaTienTong.Text = tongTienCuoiCung.ToString("N0");
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải thông tin: " + ex.Message, "Lỗi DB", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Sự kiện khi bấm nút XÁC NHẬN THANH TOÁN (Màu tím)
        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show(
                $"Bạn có chắc chắn muốn thanh toán số tiền: {tongTienCuoiCung:N0} VNĐ?",
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialog == DialogResult.Yes)
            {
                try
                {
                    // Câu lệnh chèn Hợp đồng mới vào DB
                    // (Lưu ý: Tên cột sếp phải kiểm tra lại cho khớp với SQL Server của sếp nhé)
                    string queryInsert = $@"
                        INSERT INTO HopDong (MaKH, MaGoi, TrangThai, NgayMua) 
                        VALUES ({maKhachHang}, {maGoiBaoHiem}, N'Đã thanh toán', GETDATE())";

                    DatabaseHelper.ExecuteScalar(queryInsert);

                    MessageBox.Show("Thanh toán thành công! Hợp đồng đã được kích hoạt.",
                                    "Tuyệt vời", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Xong việc thì đóng form lại
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi lưu hợp đồng: " + ex.Message, "Lỗi DB", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Sự kiện khi bấm nút HỦY GIAO DỊCH (Hoặc nút X trên góc)
        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXacNhan_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xác nhận thanh toán hợp đồng này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection conn = DatabaseHelper.GetConnection())
                    {
                        conn.Open();
                        // Query chuẩn theo các cột sếp vừa soi được trong SQL
                        string query = @"INSERT INTO HopDong (MaKH, MaGoi, NgayMua, TrangThai, TongTien) 
                                 VALUES (@MaKH, @MaGoi, @NgayMua, @TrangThai, @TongTien)";

                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@MaKH", this.maKhachHang);
                            cmd.Parameters.AddWithValue("@MaGoi", this.maGoiBaoHiem);
                            cmd.Parameters.AddWithValue("@NgayMua", DateTime.Now); // Tự lấy ngày hôm nay
                            cmd.Parameters.AddWithValue("@TrangThai", "Đã thanh toán");

                            // Lấy số tiền cuối cùng (ví dụ 15,675,000) lưu vào cột TongTien
                            // Đảm bảo biến tongTienThanhToan đã được sếp gán giá trị ở hàm Load
                            cmd.Parameters.AddWithValue("@TongTien", this.tongTienThanhToan);

                            cmd.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Thanh toán thành công và đã lưu vào hệ thống!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi Database: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void lblChietKhau_Click(object sender, EventArgs e)
        {

        }
    }
    }
