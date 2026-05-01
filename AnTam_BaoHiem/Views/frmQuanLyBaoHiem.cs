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
        private string duongDanAnhNguon = "";

        public frmQuanLyBaoHiem()
        {
            InitializeComponent();
        }

        private void frmQuanLyBaoHiem_Load(object sender, EventArgs e)
        {
            SetupCombos();
            LoadData();

            // Tự động gán sự kiện xổ dữ liệu khi chọn Công ty bảo hiểm
            this.cbxLoaiBaoHiem.SelectedIndexChanged += new System.EventHandler(this.cbxLoaiBaoHiem_SelectedIndexChanged);

            if (pnlThongTin != null) pnlThongTin.BringToFront();
        }

        private void SetupCombos()
        {
            // 1. CÔNG TY BẢO HIỂM
            cbxLoaiBaoHiem.Items.Clear();
            cbxLoaiBaoHiem.Items.AddRange(new string[] {
                "Tổng Công ty Bảo Việt Nhân Thọ (Bảo Việt Life)",
                "Công ty TNHH Bảo hiểm Nhân thọ Prudential Việt Nam",
                "Công ty TNHH Bảo hiểm Nhân thọ Manulife Việt Nam",
                "Công ty TNHH Bảo hiểm Nhân thọ AIA Việt Nam",
                "Công ty THHH 1 thành viên DUCKCOP"
            });

            // 2. TRẠNG THÁI
            cbxTrangThai.Items.Clear();
            cbxTrangThai.Items.AddRange(new string[] { "Còn bán", "Ngừng bán" });

            // 3. CHU KỲ ĐÓNG PHÍ
            cbxChuKyDongPhi.Items.Clear();
            cbxChuKyDongPhi.Items.AddRange(new string[] { "Tháng", "Quý", "Năm" });

            // 4. ĐỐI TƯỢNG ÁP DỤNG (MỚI THÊM)
            if (cbxDoiTuong != null)
            {
                cbxDoiTuong.Items.Clear();
                cbxDoiTuong.Items.AddRange(new string[] {
                    "Mọi đối tượng",
                    "Trẻ em 0 - 15 tuổi",
                    "1 tháng tuổi - 65 tuổi",
                    "0 - 60 tuổi",
                    "0 - 65 tuổi",
                    "18 - 50 tuổi",
                    "18 - 55 tuổi",
                    "18 - 65 tuổi",
                    "Trên 18 tuổi",
                    "30 - 55 tuổi"
                });
            }
        }

        // --- HÀM TỰ ĐỘNG XỔ DANH SÁCH GÓI THEO CÔNG TY ---
        private void cbxLoaiBaoHiem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxTenGoi == null) return;

            cbxTenGoi.Items.Clear();
            cbxTenGoi.Text = ""; // Xóa tên gói cũ khi đổi công ty

            string congTy = cbxLoaiBaoHiem.Text;

            switch (congTy)
            {
                case "Tổng Công ty Bảo Việt Nhân Thọ (Bảo Việt Life)":
                    cbxTenGoi.Items.AddRange(new string[] { "An Phát Cát Tường", "An Khang Hạnh Phúc" });
                    break;
                case "Công ty TNHH Bảo hiểm Nhân thọ Prudential Việt Nam":
                    cbxTenGoi.Items.AddRange(new string[] { "PRU - Chủ Động Cuộc Sống", "PRU - Đầu Tư Linh Hoạt" });
                    break;
                case "Công ty TNHH Bảo hiểm Nhân thọ Manulife Việt Nam":
                    cbxTenGoi.Items.AddRange(new string[] { "Hành Trình Hạnh Phúc", "Điểm Tựa Đầu Tư" });
                    break;
                case "Công ty TNHH Bảo hiểm Nhân thọ AIA Việt Nam":
                    cbxTenGoi.Items.AddRange(new string[] { "AIA - Trọn Vẹn Cuộc Sống", "AIA - Bước Đệm Tương Lai" });
                    break;
                case "Công ty THHH 1 thành viên DUCKCOP":
                    cbxTenGoi.Items.AddRange(new string[] { "Vịt Vàng Bình An (Bảo vệ toàn diện)", "Vịt Kim Cương (Đầu tư sinh lời)" });
                    break;
            }
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
                dgvDanhSachBaoHiem.Columns["LoaiBaoHiem"].HeaderText = "Công ty Bảo Hiểm";
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

        private bool ChuyenHuongLoi(int tabIndex, Control oNhapLieu, string thongBao)
        {
            MessageBox.Show(thongBao, "Thiếu hoặc sai định dạng", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            if (tabIndex == 0) pnlThongTin.BringToFront();
            else if (tabIndex == 1) pnlTaiChinh.BringToFront();
            else if (tabIndex == 2) pnlQuyenLoi.BringToFront();
            else if (tabIndex == 3) pnlDieuKhoan.BringToFront();

            oNhapLieu.Focus();
            return false;
        }

        private bool KiemTraDuLieuHopLe()
        {
            // 1. KIỂM TRA TAB THÔNG TIN
            if (string.IsNullOrWhiteSpace(txtMaGoi.Text))
                return ChuyenHuongLoi(0, txtMaGoi, "Vui lòng nhập Mã gói!");
            if (!Regex.IsMatch(txtMaGoi.Text, @"^[a-zA-Z0-9_-]+$"))
                return ChuyenHuongLoi(0, txtMaGoi, "Mã gói phải viết liền không dấu, không có khoảng trắng và ký tự đặc biệt!");

            if (string.IsNullOrWhiteSpace(cbxTenGoi.Text))
                return ChuyenHuongLoi(0, cbxTenGoi, "Vui lòng nhập hoặc chọn Tên gói!");
            if (!Regex.IsMatch(cbxTenGoi.Text, @"^[a-zA-Z0-9\s\p{L}\-\(\)]+$"))
                return ChuyenHuongLoi(0, cbxTenGoi, "Tên gói chứa ký tự không hợp lệ!");

            if (string.IsNullOrWhiteSpace(cbxLoaiBaoHiem.Text))
                return ChuyenHuongLoi(0, cbxLoaiBaoHiem, "Vui lòng chọn Công ty bảo hiểm!");

            // ĐÃ SỬA THÀNH cbxDoiTuong
            if (string.IsNullOrWhiteSpace(cbxDoiTuong.Text))
                return ChuyenHuongLoi(0, cbxDoiTuong, "Vui lòng chọn hoặc nhập Đối tượng áp dụng!");

            if (string.IsNullOrWhiteSpace(cbxTrangThai.Text))
                return ChuyenHuongLoi(0, cbxTrangThai, "Vui lòng chọn Trạng thái!");

            // 2. KIỂM TRA TAB TÀI CHÍNH 
            string mucPhiClean = txtMucPhi.Text.Replace(".", "").Replace(",", "").Trim();
            if (string.IsNullOrWhiteSpace(mucPhiClean))
                return ChuyenHuongLoi(1, txtMucPhi, "Vui lòng nhập Mức phí!");
            if (!Regex.IsMatch(mucPhiClean, @"^\d+$"))
                return ChuyenHuongLoi(1, txtMucPhi, "Mức phí chỉ được nhập SỐ!");

            if (string.IsNullOrWhiteSpace(cbxChuKyDongPhi.Text))
                return ChuyenHuongLoi(1, cbxChuKyDongPhi, "Vui lòng chọn Chu kỳ đóng phí!");

            string soTienBaoHiemClean = txtSoTienBaoHiem.Text.Replace(".", "").Replace(",", "").Trim();
            if (string.IsNullOrWhiteSpace(soTienBaoHiemClean))
                return ChuyenHuongLoi(1, txtSoTienBaoHiem, "Vui lòng nhập Số tiền bảo hiểm!");
            if (!Regex.IsMatch(soTienBaoHiemClean, @"^\d+$"))
                return ChuyenHuongLoi(1, txtSoTienBaoHiem, "Số tiền bảo hiểm chỉ được nhập SỐ!");

            string mucKhauTruClean = txtMucKhauTru.Text.Replace(".", "").Replace(",", "").Trim();
            if (string.IsNullOrWhiteSpace(mucKhauTruClean))
                return ChuyenHuongLoi(1, txtMucKhauTru, "Vui lòng nhập Mức khấu trừ (nếu không có, hãy nhập số 0)!");
            if (!Regex.IsMatch(mucKhauTruClean, @"^\d+$"))
                return ChuyenHuongLoi(1, txtMucKhauTru, "Mức khấu trừ chỉ được nhập SỐ!");

            string tienPhatTreHanClean = txtTienPhatTreHan.Text.Replace(".", "").Replace(",", "").Trim();
            if (string.IsNullOrWhiteSpace(tienPhatTreHanClean))
                return ChuyenHuongLoi(1, txtTienPhatTreHan, "Vui lòng nhập Tiền phạt trễ hạn (nếu không có, hãy nhập số 0)!");
            if (!Regex.IsMatch(tienPhatTreHanClean, @"^\d+$"))
                return ChuyenHuongLoi(1, txtTienPhatTreHan, "Tiền phạt trễ hạn chỉ được nhập SỐ!");

            // 3. KIỂM TRA TAB QUYỀN LỢI
            if (string.IsNullOrWhiteSpace(rtbQuyenLoiChinh.Text))
                return ChuyenHuongLoi(2, rtbQuyenLoiChinh, "Vui lòng nhập Quyền lợi chính!");
            if (string.IsNullOrWhiteSpace(rtbPhamViBaoHiem.Text))
                return ChuyenHuongLoi(2, rtbPhamViBaoHiem, "Vui lòng nhập Phạm vi bảo hiểm!");
            if (string.IsNullOrWhiteSpace(rtbDieuKienNhanTien.Text))
                return ChuyenHuongLoi(2, rtbDieuKienNhanTien, "Vui lòng nhập Điều kiện nhận tiền!");

            // 4. KIỂM TRA TAB ĐIỀU KHOẢN
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
                    TenGoi = cbxTenGoi.Text.Trim(),
                    LoaiBaoHiem = cbxLoaiBaoHiem.Text,
                    // SỬA LẠI CHO CHUẨN: txtMoTa và cbxDoiTuong
                    MoTa = txtMoTa.Text.Trim(),
                    DoiTuongApDung = cbxDoiTuong.Text.Trim(),
                    TrangThai = cbxTrangThai.Text,
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

        private void LuuAnhVaoHeThong()
        {
            if (!string.IsNullOrEmpty(duongDanAnhNguon))
            {
                try
                {
                    string thuMucAnh = Application.StartupPath + @"\Images";
                    if (!System.IO.Directory.Exists(thuMucAnh)) System.IO.Directory.CreateDirectory(thuMucAnh);
                    string duoiFile = System.IO.Path.GetExtension(duongDanAnhNguon);
                    string duongDanMoi = thuMucAnh + @"\" + txtMaGoi.Text.Trim() + duoiFile;
                    System.IO.File.Copy(duongDanAnhNguon, duongDanMoi, true);
                    duongDanAnhNguon = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Dữ liệu chữ đã lưu nhưng lỗi khi copy ảnh: " + ex.Message);
                }
            }
        }

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
            if (obj != null && bus.ThemGoi(obj))
            {
                LuuAnhVaoHeThong();
                MessageBox.Show("Trần Đức Thắng đã thêm thành công!");
                LoadData();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!KiemTraDuLieuHopLe()) return;
            var obj = GetEntityFromUI();
            if (obj != null && bus.SuaGoi(obj))
            {
                LuuAnhVaoHeThong();
                MessageBox.Show("Trần Đức Thắng đã cập nhật thành công!");
                LoadData();
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
            cbxTenGoi.Text = "";
            cbxDoiTuong.Text = ""; // Reset Đối tượng
            txtMaGoi.Focus();
            picAnhBaoHiem.Image = null;
            duongDanAnhNguon = "";
            LoadData();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string ma = txtMaGoi.Text.Trim();
            string ten = cbxTenGoi.Text.Trim();
            if (string.IsNullOrEmpty(ma) && string.IsNullOrEmpty(ten)) { LoadData(); return; }
            DataTable dtKetQua = bus.TimKiemTheoMaVaTen(ma, ten);
            dgvDanhSachBaoHiem.DataSource = dtKetQua;
            if (dtKetQua.Rows.Count > 0) dgvDanhSachBaoHiem_CellClick(dgvDanhSachBaoHiem, new DataGridViewCellEventArgs(0, 0));
            else { MessageBox.Show("Không tìm thấy!"); bus.ClearForm(this.Controls); picAnhBaoHiem.Image = null; }
        }

        private void dgvDanhSachBaoHiem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow r = dgvDanhSachBaoHiem.Rows[e.RowIndex];
            txtMaGoi.Text = r.Cells["MaGoi"].Value.ToString();

            cbxLoaiBaoHiem.Text = r.Cells["LoaiBaoHiem"].Value.ToString();
            cbxTenGoi.Text = r.Cells["TenGoi"].Value.ToString();

            txtMoTa.Text = r.Cells["MoTa"].Value.ToString();
            cbxDoiTuong.Text = r.Cells["DoiTuongApDung"].Value.ToString();

            cbxTrangThai.Text = r.Cells["TrangThai"].Value.ToString();

            txtMucPhi.Text = Convert.ToDecimal(r.Cells["MucPhi"].Value).ToString("N0");
            cbxChuKyDongPhi.Text = r.Cells["ChuKyDongPhi"].Value.ToString();
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

            string ma = r.Cells["MaGoi"].Value.ToString();
            string pP = Application.StartupPath + @"\Images\" + ma + ".png";
            string pJ = Application.StartupPath + @"\Images\" + ma + ".jpg";
            if (System.IO.File.Exists(pP)) picAnhBaoHiem.ImageLocation = pP;
            else if (System.IO.File.Exists(pJ)) picAnhBaoHiem.ImageLocation = pJ;
            else picAnhBaoHiem.Image = null;
        }

        // --- CÁC NÚT BẤM SIDEBAR ---
        private void btnThongTin_Click(object sender, EventArgs e) { pnlThongTin.BringToFront(); }
        private void btnTaiChinh_Click(object sender, EventArgs e) { pnlTaiChinh.BringToFront(); }
        private void btnQuyenLoi_Click(object sender, EventArgs e) { pnlQuyenLoi.BringToFront(); }
        private void btnDieuKhoan_Click(object sender, EventArgs e) { pnlDieuKhoan.BringToFront(); }
        private void btnQuanLyNoiBo_Click(object sender, EventArgs e) { pnlQuanLyNoiBo.BringToFront(); }

        private void txtThoiHanChuan_MaskInputRejected(object sender, MaskInputRejectedEventArgs e) { }
        private void rtbDieuKhoanLoaiTru_TextChanged(object sender, EventArgs e) { }
        private void txtThoiGianCho_MaskInputRejected(object sender, MaskInputRejectedEventArgs e) { }
        private void tabDieuKhoan_Click(object sender, EventArgs e) { }

        private void pnlQuyenLoi_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}