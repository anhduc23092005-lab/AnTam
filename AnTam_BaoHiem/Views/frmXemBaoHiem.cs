using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using AnTam_BaoHiem.Controllers;

namespace AnTam_BaoHiem.Views
{
    public partial class frmXemBaoHiem : Form
    {
        private BaoHiemController bus = new BaoHiemController();
        private string maGoiDangChon = "";

        public frmXemBaoHiem()
        {
            InitializeComponent();
        }

        private void frmXemBaoHiem_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized; // Chạy phát full màn cho sang
            LoadCards();
        }

        // --- HÀM 1: HIỂN THỊ DANH SÁCH BÊN TRÁI (ĐÃ BỎ ẢNH) ---
        private void LoadCards(string tuKhoa = "")
        {
            flpDanhSachGoi.Controls.Clear();
            DataTable dt = string.IsNullOrEmpty(tuKhoa) ? bus.LayDanhSachGoi() : bus.TimKiemTheoMaVaTen(tuKhoa, tuKhoa);

            foreach (DataRow row in dt.Rows)
            {
                if (row["TrangThai"].ToString() == "Ngừng bán") continue;

                // Tạo thẻ Card
                Panel card = new Panel
                {
                    Width = flpDanhSachGoi.Width - 25,
                    Height = 85, // Giảm chiều cao xuống vì không còn ảnh
                    BackColor = Color.White,
                    BorderStyle = BorderStyle.FixedSingle,
                    Margin = new Padding(5, 5, 5, 10),
                    Cursor = Cursors.Hand,
                    Tag = row
                };

                // Tên gói bảo hiểm (Cho to và đậm lên)
                Label lblTen = new Label
                {
                    Text = row["TenGoi"].ToString(),
                    Font = new Font("Segoe UI", 12, FontStyle.Bold),
                    ForeColor = Color.FromArgb(44, 62, 80), // Màu xanh đen sang trọng
                    Location = new Point(15, 15),
                    Width = card.Width - 30,
                    Height = 30,
                    AutoEllipsis = true
                };

                // Mức phí
                Label lblPhi = new Label
                {
                    Text = "Phí: " + Convert.ToDecimal(row["MucPhi"]).ToString("N0") + " VNĐ",
                    ForeColor = Color.Crimson,
                    Font = new Font("Segoe UI", 10, FontStyle.Bold),
                    Location = new Point(15, 45),
                    AutoSize = true
                };

                card.Controls.Add(lblTen);
                card.Controls.Add(lblPhi);

                // Hiệu ứng khi click
                card.Click += (s, ev) => ShowDetail(row);
                foreach (Control c in card.Controls) c.Click += (s, ev) => ShowDetail(row);

                flpDanhSachGoi.Controls.Add(card);
            }
        }

        // --- HÀM 2: HIỂN THỊ CHI TIẾT KHI CHỌN ---
        private void ShowDetail(DataRow row)
        {
            maGoiDangChon = row["MaGoi"].ToString();
            lblTenGoi_ChiTiet.Text = row["TenGoi"].ToString().ToUpper();
            lblMucPhi_ChiTiet.Text = "Giá niêm yết: " + Convert.ToDecimal(row["MucPhi"]).ToString("N0") + " VNĐ";

            // Load ảnh to (đã chỉnh SizeMode = Zoom ở Design nên sẽ rất đẹp)
            LoadLargeImage(maGoiDangChon);

            // Trình bày nội dung sạch sẽ, bỏ ký tự thừa, dùng xuống dòng để tạo khoảng cách
            rtbChiTietGoi.Clear();

            // Thêm nội dung theo từng khối, dùng các dòng trống để phân cách
            string noiDung = "";
            noiDung += "MÔ TẢ GÓI BẢO HIỂM\n";
            noiDung += row["MoTa"].ToString() + "\n\n";

            noiDung += "ĐỐI TƯỢNG ÁP DỤNG\n";
            noiDung += row["DoiTuongApDung"].ToString() + "\n\n";

            noiDung += "QUYỀN LỢI CHÍNH\n";
            noiDung += row["QuyenLoiChinh"].ToString() + "\n\n";

            noiDung += "ĐIỀU KHOẢN LOẠI TRỪ\n";
            noiDung += row["DieuKhoanLoaiTru"].ToString();

            rtbChiTietGoi.Text = noiDung; 
        }

        private void LoadLargeImage(string ma)
        {
            string pathPng = Path.Combine(Application.StartupPath, "Images", ma + ".png");
            string pathJpg = Path.Combine(Application.StartupPath, "Images", ma + ".jpg");
            string finalPath = File.Exists(pathPng) ? pathPng : (File.Exists(pathJpg) ? pathJpg : "");

            if (!string.IsNullOrEmpty(finalPath))
            {
                using (FileStream fs = new FileStream(finalPath, FileMode.Open, FileAccess.Read))
                {
                    picAnhChiTiet.Image = Image.FromStream(fs);
                }
            }
            else picAnhChiTiet.Image = null;
        }

        private void btnTimKiem_Click(object sender, EventArgs e) => LoadCards(txtTimKiem.Text.Trim());

        private void btnMuaBaoHiem_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra xem đã chọn gói bảo hiểm chưa
            if (string.IsNullOrEmpty(maGoiDangChon))
            {
                MessageBox.Show("Thắng ơi, bạn chưa chọn gói bảo hiểm nào ở bên trái kìa!", "Nhắc nhở");
                return;
            }

            // 2. Lấy dữ liệu từ các ô nhập
            string hoTen = txtHoTenKhach.Text.Trim();
            string sdt = txtSoDienThoai.Text.Trim();
            string email = txtEmail.Text.Trim();
            string diaChi = txtDiaChi.Text.Trim();

            // 3. KIỂM TRA HỌ TÊN (Không trống, không số, không ký tự đặc biệt)
            // \p{L} cho phép nhập chữ cái có dấu tiếng Việt
            if (string.IsNullOrWhiteSpace(hoTen))
            {
                MessageBox.Show("Vui lòng nhập Họ và tên!"); return;
            }
            if (!Regex.IsMatch(hoTen, @"^[a-zA-Z\s\p{L}]+$"))
            {
                MessageBox.Show("Họ tên không được chứa số hay ký tự đặc biệt (@, #, 1, 2...)!");
                txtHoTenKhach.Focus();
                return;
            }

            // 4. KIỂM TRA SỐ ĐIỆN THOẠI (Phải đúng 10 số, không có chữ)
            if (!Regex.IsMatch(sdt, @"^\d{10}$"))
            {
                MessageBox.Show("Số điện thoại phải nhập đúng 10 chữ số!");
                txtSoDienThoai.Focus();
                return;
            }

            // 5. KIỂM TRA EMAIL (Phải đúng định dạng @gmail.com...)
            if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Email không đúng định dạng (thiếu @ hoặc dấu chấm)!");
                txtEmail.Focus();
                return;
            }

            // 6. GỌI CONTROLLER ĐỂ LƯU VÀO SQL
            try
            {
                if (bus.DangKyMua(maGoiDangChon, hoTen, sdt, diaChi, email))
                {
                    MessageBox.Show($"Chúc mừng {hoTen}!\nTrần Đức Thắng thông báo: Bạn đã đăng ký mua gói {lblTenGoi_ChiTiet.Text} thành công!",
                                    "Mua thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Xóa trắng form sau khi mua xong cho chuyên nghiệp
                    txtHoTenKhach.Clear();
                    txtSoDienThoai.Clear();
                    txtDiaChi.Clear();
                    txtEmail.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hệ thống khi đăng ký: " + ex.Message);
            }
        }
    }
}