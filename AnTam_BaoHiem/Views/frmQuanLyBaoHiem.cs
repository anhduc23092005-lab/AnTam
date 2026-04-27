using System;
using System.Data;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using AnTam_BaoHiem.Models;
using AnTam_BaoHiem.Controllers;

namespace AnTam_BaoHiem.Views
{
    public partial class frmQuanLyBaoHiem : Form
    {
        private BaoHiemController bus = new BaoHiemController();
        private string duongDanAnhNguon = ""; // Biến tạm để giữ đường dẫn ảnh Admin vừa chọn

        public frmQuanLyBaoHiem()
        {
            InitializeComponent();
        }

        private void frmQuanLyBaoHiem_Load(object sender, EventArgs e)
        {
            SetupCombos();
            LoadData();
        }

        private void SetupCombos()
        {
            cbxLoaiBaoHiem.Items.Clear();
            cbxLoaiBaoHiem.Items.AddRange(GoiBaoHiem.LoaiBaoHiemGoc);

            cbxTrangThai.Items.Clear();
            cbxTrangThai.Items.AddRange(new string[] { "Còn bán", "Ngừng bán" });

            cbxChuKyDongPhi.Items.Clear();
            cbxChuKyDongPhi.Items.AddRange(new string[] { "Tháng", "Quý", "Năm" });
        }

        private void LoadData()
        {
            dgvDanhSachBaoHiem.DataSource = bus.LayDanhSachGoi();

            if (dgvDanhSachBaoHiem.Columns.Count > 0)
            {
                dgvDanhSachBaoHiem.Columns["MaGoi"].HeaderText = "Mã Gói";
                dgvDanhSachBaoHiem.Columns["TenGoi"].HeaderText = "Tên Gói";
                dgvDanhSachBaoHiem.Columns["MucPhi"].HeaderText = "Mức Phí";
                dgvDanhSachBaoHiem.Columns["MoTa"].HeaderText = "Mô Tả";
                dgvDanhSachBaoHiem.Columns["LoaiBaoHiem"].HeaderText = "Loại Bảo Hiểm";
                dgvDanhSachBaoHiem.Columns["DoiTuongApDung"].HeaderText = "Đối Tượng Áp Dụng";
                dgvDanhSachBaoHiem.Columns["TrangThai"].HeaderText = "Trạng Thái";
                dgvDanhSachBaoHiem.Columns["ChuKyDongPhi"].HeaderText = "Chu Kỳ Đóng Phí";
                dgvDanhSachBaoHiem.Columns["SoTienBaoHiem"].HeaderText = "Số Tiền Bảo Hiểm";
                dgvDanhSachBaoHiem.Columns["MucKhauTru"].HeaderText = "Mức Khấu Trừ";
                dgvDanhSachBaoHiem.Columns["TienPhatTreHan"].HeaderText = "Tiền Phạt Trễ Hạn";
                dgvDanhSachBaoHiem.Columns["ThoiHanChuan"].HeaderText = "Thời Hạn Chuẩn";
                dgvDanhSachBaoHiem.Columns["ThoiGianCho"].HeaderText = "Thời Gian Chờ";
                dgvDanhSachBaoHiem.Columns["DieuKhoanLoaiTru"].HeaderText = "Điều Khoản Loại Trừ";
                dgvDanhSachBaoHiem.Columns["QuyenLoiChinh"].HeaderText = "Quyền Lợi Chính";
                dgvDanhSachBaoHiem.Columns["QuyenLoiBoSung"].HeaderText = "Quyền Lợi Bổ Sung";
                dgvDanhSachBaoHiem.Columns["PhamViBaoHiem"].HeaderText = "Phạm Vi Bảo Hiểm";
                dgvDanhSachBaoHiem.Columns["DieuKienNhanTien"].HeaderText = "Điều Kiện Nhận Tiền";
                dgvDanhSachBaoHiem.Columns["NgayTao"].HeaderText = "Ngày Tạo";
                dgvDanhSachBaoHiem.Columns["NguoiTao"].HeaderText = "Người Tạo";
                dgvDanhSachBaoHiem.Columns["NgayCapNhat"].HeaderText = "Ngày Cập Nhật";
                dgvDanhSachBaoHiem.Columns["NguoiCapNhat"].HeaderText = "Người Cập Nhật";
                dgvDanhSachBaoHiem.Columns["MucPhi"].DefaultCellStyle.Format = "N0";
                dgvDanhSachBaoHiem.Columns["SoTienBaoHiem"].DefaultCellStyle.Format = "N0";
                dgvDanhSachBaoHiem.Columns["MucKhauTru"].DefaultCellStyle.Format = "N0";
                dgvDanhSachBaoHiem.Columns["TienPhatTreHan"].DefaultCellStyle.Format = "N0";
            }
        }

        // --- BỘ CÔNG CỤ BẮT LỖI (VALIDATE) SIÊU CHẶT ---
        private bool ChuyenHuongLoi(int tabIndex, Control oNhapLieu, string thongBao)
        {
            MessageBox.Show(thongBao, "Thiếu hoặc sai định dạng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            tabControl1.SelectedIndex = tabIndex;
            oNhapLieu.Focus();
            return false;
        }

        private bool KiemTraDuLieuHopLe()
        {
            // 1. KIỂM TRA TAB THÔNG TIN (Index = 0)
            if (string.IsNullOrWhiteSpace(txtMaGoi.Text))
                return ChuyenHuongLoi(0, txtMaGoi, "Vui lòng nhập Mã gói!");
            if (!Regex.IsMatch(txtMaGoi.Text, @"^[a-zA-Z0-9_-]+$"))
                return ChuyenHuongLoi(0, txtMaGoi, "Mã gói phải viết liền không dấu, không có khoảng trắng và ký tự đặc biệt!");

            if (string.IsNullOrWhiteSpace(txtTenGoi.Text))
                return ChuyenHuongLoi(0, txtTenGoi, "Vui lòng nhập Tên gói!");
            if (!Regex.IsMatch(txtTenGoi.Text, @"^[a-zA-Z0-9\s\p{L}]+$"))
                return ChuyenHuongLoi(0, txtTenGoi, "Tên gói không được chứa ký tự đặc biệt (@, #, !,...)!");

            if (string.IsNullOrWhiteSpace(cbxLoaiBaoHiem.Text))
                return ChuyenHuongLoi(0, cbxLoaiBaoHiem, "Vui lòng chọn Loại bảo hiểm!");

            if (string.IsNullOrWhiteSpace(txtDoiTuongApDung.Text))
                return ChuyenHuongLoi(0, txtDoiTuongApDung, "Vui lòng nhập Đối tượng áp dụng!");

            if (string.IsNullOrWhiteSpace(cbxTrangThai.Text))
                return ChuyenHuongLoi(0, cbxTrangThai, "Vui lòng chọn Trạng thái!");

            // 2. KIỂM TRA TAB TÀI CHÍNH (Index = 1)
            if (string.IsNullOrWhiteSpace(txtMucPhi.Text))
                return ChuyenHuongLoi(1, txtMucPhi, "Vui lòng nhập Mức phí!");
            if (!Regex.IsMatch(txtMucPhi.Text, @"^\d+$"))
                return ChuyenHuongLoi(1, txtMucPhi, "Mức phí chỉ được nhập SỐ, không chứa chữ cái hay khoảng trắng!");

            if (string.IsNullOrWhiteSpace(cbxChuKyDongPhi.Text))
                return ChuyenHuongLoi(1, cbxChuKyDongPhi, "Vui lòng chọn Chu kỳ đóng phí!");

            if (string.IsNullOrWhiteSpace(txtSoTienBaoHiem.Text))
                return ChuyenHuongLoi(1, txtSoTienBaoHiem, "Vui lòng nhập Số tiền bảo hiểm!");
            if (!Regex.IsMatch(txtSoTienBaoHiem.Text, @"^\d+$"))
                return ChuyenHuongLoi(1, txtSoTienBaoHiem, "Số tiền bảo hiểm chỉ được nhập SỐ!");

            // Bắt buộc nhập Mức khấu trừ & Phạt trễ hạn
            if (string.IsNullOrWhiteSpace(txtMucKhauTru.Text))
                return ChuyenHuongLoi(1, txtMucKhauTru, "Vui lòng nhập Mức khấu trừ (nếu không có, hãy nhập số 0)!");
            if (!Regex.IsMatch(txtMucKhauTru.Text, @"^\d+$"))
                return ChuyenHuongLoi(1, txtMucKhauTru, "Mức khấu trừ chỉ được nhập SỐ!");

            if (string.IsNullOrWhiteSpace(txtTienPhatTreHan.Text))
                return ChuyenHuongLoi(1, txtTienPhatTreHan, "Vui lòng nhập Tiền phạt trễ hạn (nếu không có, hãy nhập số 0)!");
            if (!Regex.IsMatch(txtTienPhatTreHan.Text, @"^\d+$"))
                return ChuyenHuongLoi(1, txtTienPhatTreHan, "Tiền phạt trễ hạn chỉ được nhập SỐ!");

            // 3. KIỂM TRA TAB QUYỀN LỢI (Index = 2)
            if (string.IsNullOrWhiteSpace(rtbQuyenLoiChinh.Text))
                return ChuyenHuongLoi(2, rtbQuyenLoiChinh, "Vui lòng nhập Quyền lợi chính!");
            if (string.IsNullOrWhiteSpace(rtbPhamViBaoHiem.Text))
                return ChuyenHuongLoi(2, rtbPhamViBaoHiem, "Vui lòng nhập Phạm vi bảo hiểm!");
            if (string.IsNullOrWhiteSpace(rtbDieuKienNhanTien.Text))
                return ChuyenHuongLoi(2, rtbDieuKienNhanTien, "Vui lòng nhập Điều kiện nhận tiền!");

            // 4. KIỂM TRA TAB ĐIỀU KHOẢN (Index = 3)
            if (string.IsNullOrWhiteSpace(txtThoiHanChuan.Text))
                return ChuyenHuongLoi(3, txtThoiHanChuan, "Vui lòng nhập Thời hạn chuẩn!");
            if (string.IsNullOrWhiteSpace(txtThoiGianCho.Text))
                return ChuyenHuongLoi(3, txtThoiGianCho, "Vui lòng nhập Thời gian chờ!");

            return true;
        }

        private GoiBaoHiem GetEntityFromUI()
        {
            try
            {
                return new GoiBaoHiem
                {
                    MaGoi = txtMaGoi.Text.Trim(),
                    TenGoi = txtTenGoi.Text.Trim(),
                    LoaiBaoHiem = cbxLoaiBaoHiem.Text,
                    MoTa = txtMoTa.Text,
                    DoiTuongApDung = txtDoiTuongApDung.Text,
                    TrangThai = cbxTrangThai.Text,

                    // Dùng Replace để xóa sạch dấu chấm/phẩy phân cách trước khi Parse
                    MucPhi = decimal.Parse(string.IsNullOrEmpty(txtMucPhi.Text) ? "0" : txtMucPhi.Text.Replace(".", "").Replace(",", "")),
                    ChuKyDongPhi = cbxChuKyDongPhi.Text,
                    SoTienBaoHiem = decimal.Parse(string.IsNullOrEmpty(txtSoTienBaoHiem.Text) ? "0" : txtSoTienBaoHiem.Text.Replace(".", "").Replace(",", "")),
                    MucKhauTru = decimal.Parse(string.IsNullOrEmpty(txtMucKhauTru.Text) ? "0" : txtMucKhauTru.Text.Replace(".", "").Replace(",", "")),
                    TienPhatTreHan = decimal.Parse(string.IsNullOrEmpty(txtTienPhatTreHan.Text) ? "0" : txtTienPhatTreHan.Text.Replace(".", "").Replace(",", "")),

                    ThoiHanChuan = txtThoiHanChuan.Text,
                    ThoiGianCho = txtThoiGianCho.Text,
                    DieuKhoanLoaiTru = rtbDieuKhoanLoaiTru.Text,

                    QuyenLoiChinh = rtbQuyenLoiChinh.Text,
                    QuyenLoiBoSung = rtbQuyenLoiBoSung.Text,
                    PhamViBaoHiem = rtbPhamViBaoHiem.Text,
                    DieuKienNhanTien = rtbDieuKienNhanTien.Text
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi định dạng số: " + ex.Message);
                return null;
            }
        }

        // --- HÀM HỖ TRỢ XỬ LÝ LƯU ẢNH VÀO FOLDER ---
        private void LuuAnhVaoHeThong()
        {
            if (!string.IsNullOrEmpty(duongDanAnhNguon))
            {
                try
                {
                    string thuMucAnh = Application.StartupPath + @"\Images";
                    if (!System.IO.Directory.Exists(thuMucAnh))
                    {
                        System.IO.Directory.CreateDirectory(thuMucAnh);
                    }

                    string duoiFile = System.IO.Path.GetExtension(duongDanAnhNguon);
                    string duongDanMoi = thuMucAnh + @"\" + txtMaGoi.Text.Trim() + duoiFile;

                    System.IO.File.Copy(duongDanAnhNguon, duongDanMoi, true); // true để ghi đè nếu sửa ảnh
                    duongDanAnhNguon = ""; // Reset sau khi copy xong
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Dữ liệu chữ đã lưu nhưng lỗi khi copy ảnh: " + ex.Message, "Lỗi Copy", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // --- SỰ KIỆN CLICK CHỌN ẢNH TỪ MÁY ---
        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files(*.jpg; *.jpeg; *.png)|*.jpg; *.jpeg; *.png";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                picAnhBaoHiem.ImageLocation = ofd.FileName;
                duongDanAnhNguon = ofd.FileName;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!KiemTraDuLieuHopLe()) return;

            var obj = GetEntityFromUI();
            if (obj != null)
            {
                if (bus.ThemGoi(obj))
                {
                    LuuAnhVaoHeThong(); // Gọi hàm lưu ảnh
                    MessageBox.Show("Trần Đức Thắng đã thêm thành công!");
                    LoadData();
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!KiemTraDuLieuHopLe()) return;

            var obj = GetEntityFromUI();
            if (obj != null)
            {
                if (bus.SuaGoi(obj))
                {
                    LuuAnhVaoHeThong(); // Gọi hàm lưu ảnh
                    MessageBox.Show("Trần Đức Thắng đã cập nhật thành công!");
                    LoadData();
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtMaGoi.Text))
            {
                if (bus.XoaGoi(txtMaGoi.Text))
                {
                    MessageBox.Show("Trần Đức Thắng đã xóa thành công!");
                    LoadData();
                    btnLamMoi.PerformClick();
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            bus.ClearForm(this.Controls);
            txtMaGoi.Enabled = true;
            txtMaGoi.Focus();
            picAnhBaoHiem.Image = null; // Dọn sạch ảnh trên form
            duongDanAnhNguon = "";
            LoadData();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string ma = txtMaGoi.Text.Trim();
            string ten = txtTenGoi.Text.Trim();

            if (string.IsNullOrEmpty(ma) && string.IsNullOrEmpty(ten))
            {
                LoadData();
                return;
            }

            DataTable dtKetQua = bus.TimKiemTheoMaVaTen(ma, ten);
            dgvDanhSachBaoHiem.DataSource = dtKetQua;

            if (dtKetQua.Rows.Count > 0)
            {
                DataGridViewCellEventArgs args = new DataGridViewCellEventArgs(0, 0);
                dgvDanhSachBaoHiem_CellClick(dgvDanhSachBaoHiem, args);
            }
            else
            {
                MessageBox.Show("Trần Đức Thắng thông báo: Không tìm thấy gói bảo hiểm nào khớp yêu cầu!", "Kết quả tìm kiếm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                bus.ClearForm(this.Controls);
                picAnhBaoHiem.Image = null;
            }
        }

        private void dgvDanhSachBaoHiem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow r = dgvDanhSachBaoHiem.Rows[e.RowIndex];

            txtMaGoi.Text = r.Cells["MaGoi"].Value.ToString();
            txtTenGoi.Text = r.Cells["TenGoi"].Value.ToString();
            cbxLoaiBaoHiem.Text = r.Cells["LoaiBaoHiem"].Value.ToString();
            txtMoTa.Text = r.Cells["MoTa"].Value.ToString();
            txtDoiTuongApDung.Text = r.Cells["DoiTuongApDung"].Value.ToString();
            cbxTrangThai.Text = r.Cells["TrangThai"].Value.ToString();

            txtMucPhi.Text = Convert.ToDecimal(r.Cells["MucPhi"].Value).ToString("N0");
            txtSoTienBaoHiem.Text = Convert.ToDecimal(r.Cells["SoTienBaoHiem"].Value).ToString("N0");
            txtMucKhauTru.Text = Convert.ToDecimal(r.Cells["MucKhauTru"].Value).ToString("N0");
            txtTienPhatTreHan.Text = Convert.ToDecimal(r.Cells["TienPhatTreHan"].Value).ToString("N0");

            txtThoiHanChuan.Text = r.Cells["ThoiHanChuan"].Value.ToString();
            txtThoiGianCho.Text = r.Cells["ThoiGianCho"].Value.ToString();
            rtbDieuKhoanLoaiTru.Text = r.Cells["DieuKhoanLoaiTru"].Value.ToString();

            rtbQuyenLoiChinh.Text = r.Cells["QuyenLoiChinh"].Value.ToString();
            rtbQuyenLoiBoSung.Text = r.Cells["QuyenLoiBoSung"].Value.ToString();
            rtbPhamViBaoHiem.Text = r.Cells["PhamViBaoHiem"].Value.ToString();
            rtbDieuKienNhanTien.Text = r.Cells["DieuKienNhanTien"].Value.ToString();

            txtNgayTao.Text = r.Cells["NgayTao"].Value.ToString();
            txtNguoiTao.Text = r.Cells["NguoiTao"].Value.ToString();
            txtNgayCapNhat.Text = r.Cells["NgayCapNhat"].Value.ToString();
            txtNguoiCapNhat.Text = r.Cells["NguoiCapNhat"].Value.ToString();
            txtMaGoi.Enabled = false;

            // --- LOAD ẢNH LÊN KHI CLICK VÀO 1 DÒNG DỮ LIỆU ---
            string ma = r.Cells["MaGoi"].Value.ToString();
            string duongDanPng = Application.StartupPath + @"\Images\" + ma + ".png";
            string duongDanJpg = Application.StartupPath + @"\Images\" + ma + ".jpg";

            if (System.IO.File.Exists(duongDanPng)) picAnhBaoHiem.ImageLocation = duongDanPng;
            else if (System.IO.File.Exists(duongDanJpg)) picAnhBaoHiem.ImageLocation = duongDanJpg;
            else picAnhBaoHiem.Image = null; // Không có ảnh thì làm trống
        }

        private void txtThoiHanChuan_MaskInputRejected(object sender, MaskInputRejectedEventArgs e) { }
        private void rtbDieuKhoanLoaiTru_TextChanged(object sender, EventArgs e) { }
        private void txtThoiGianCho_MaskInputRejected(object sender, MaskInputRejectedEventArgs e) { }
        private void tabDieuKhoan_Click(object sender, EventArgs e) { }
    }
}