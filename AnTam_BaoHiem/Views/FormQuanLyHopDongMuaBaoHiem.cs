using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace FormQuanLyHopDongMuaBaoHiem
{
    public partial class FormQuanLyHopDongMuaBaoHiem : Form
    {
        QuanLyHopDongController controller = new QuanLyHopDongController();
        BindingList<HopDongBaoHiem> blHopDong;

        // BIẾN MỚI: Dùng để ghi nhớ người dùng đang bấm Thêm hay Sửa
        private string trangThaiThaoTac = "";

        public FormQuanLyHopDongMuaBaoHiem()
        {
            InitializeComponent();
            SetupComboBox();
        }

        private void SetupComboBox()
        {
            cboLocTrangThai.Items.Clear();
            cboLocTrangThai.Items.AddRange(new string[] { "Tất cả", "Có hiệu lực", "Chờ phê duyệt", "Sắp hết hạn" });
            cboLocTrangThai.SelectedIndex = 0;
            cboLocTrangThai.SelectedIndexChanged += (s, e) => LoadData();
        }

        private void FormQuanLyHopDongMuaBaoHiem_Load(object sender, EventArgs e)
        {
            dgvHopDong.AutoGenerateColumns = false;
            LoadData();
        }

        // ====================== HÀM KHÓA/MỞ BẢNG ======================
        private void LockGrid()
        {
            dgvHopDong.ReadOnly = true;            // Mặc định không cho sửa chữ trong bảng
            dgvHopDong.AllowUserToAddRows = false; // Ẩn dòng trắng dưới cùng (dòng có dấu *)
        }

        public void LoadData()
        {
            try
            {
                string key = txtTimKiem.Text.Trim();
                string status = cboLocTrangThai.SelectedItem?.ToString() ?? "Tất cả";

                var danhSach = controller.LayDanhSach(key, status);
                blHopDong = new BindingList<HopDongBaoHiem>(danhSach);

                dgvHopDong.DataSource = null;
                dgvHopDong.DataSource = blHopDong;

                UpdateSTT();
                UpdateThongKe();

                // Tải xong dữ liệu thì Khóa bảng lại để bảo vệ
                LockGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hiển thị dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateSTT()
        {
            if (dgvHopDong.Columns.Contains("STT"))
            {
                bool currentLock = dgvHopDong.ReadOnly;
                dgvHopDong.ReadOnly = false; // Mở tạm để điền STT

                for (int i = 0; i < dgvHopDong.Rows.Count; i++)
                {
                    if (!dgvHopDong.Rows[i].IsNewRow)
                        dgvHopDong.Rows[i].Cells["STT"].Value = (i + 1).ToString();
                }

                dgvHopDong.ReadOnly = currentLock; // Trả lại trạng thái khóa cũ
            }
        }

        private void UpdateThongKe()
        {
            var tatCa = controller.LayDanhSach("", "Tất cả");
            lblTongHopDong.Text = tatCa.Count.ToString() + " Hợp đồng";
            lblConHieuLuc.Text = tatCa.Count(x => x.TrangThai == "Có hiệu lực" || x.TrangThai == "Còn hiệu lực").ToString() + " Hợp đồng";
            lblChoPheDuyet.Text = tatCa.Count(x => x.TrangThai == "Chờ duyệt" || x.TrangThai == "Chờ phê duyệt").ToString() + " Hợp đồng";
            lblSapHetHan.Text = tatCa.Count(x => x.TrangThai == "Sắp hết hạn").ToString() + " Hợp đồng";
        }

        private void btnTimKiem_Click(object sender, EventArgs e) => LoadData();

        // ====================== XỬ LÝ NÚT BẤM ======================

        private void btnThem_Click(object sender, EventArgs e)
        {
            trangThaiThaoTac = "THEM";
            dgvHopDong.ReadOnly = false;           // Mở khóa bảng
            dgvHopDong.AllowUserToAddRows = true;  // Hiện ra dòng trắng có dấu * ở cuối bảng để nhập

            // Mở khóa cột MaHD (nếu trước đó lỡ bị nút Sửa khóa)
            if (dgvHopDong.Columns.Contains("MaHD"))
                dgvHopDong.Columns["MaHD"].ReadOnly = false;

            // Di chuyển màn hình xuống dòng dưới cùng cho dễ nhìn
            if (dgvHopDong.Rows.Count > 0)
                dgvHopDong.FirstDisplayedScrollingRowIndex = dgvHopDong.Rows.Count - 1;

            MessageBox.Show("Đã mở khóa!\nVui lòng NHẬP THÔNG TIN VÀO DÒNG DƯỚI CÙNG của bảng.\nSau khi nhập xong, bấm phím ENTER để Lưu.", "Hướng dẫn", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvHopDong.CurrentRow == null || dgvHopDong.CurrentRow.IsNewRow)
            {
                MessageBox.Show("Vui lòng click chọn một dòng dữ liệu để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            trangThaiThaoTac = "SUA";
            dgvHopDong.ReadOnly = false;           // Mở khóa bảng
            dgvHopDong.AllowUserToAddRows = false; // Không cho thêm dòng mới

            // Riêng Mã Hợp Đồng (Khóa chính) thì không được phép sửa
            if (dgvHopDong.Columns.Contains("MaHD"))
                dgvHopDong.Columns["MaHD"].ReadOnly = true;

            MessageBox.Show("Đã mở khóa!\nVui lòng SỬA TRỰC TIẾP TRÊN BẢNG.\nSau khi sửa xong, bấm phím ENTER để Lưu.", "Hướng dẫn", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Xóa thì không cần Enter, hỏi xong xóa luôn
            if (dgvHopDong.CurrentRow != null && !dgvHopDong.CurrentRow.IsNewRow)
            {
                var hd = dgvHopDong.CurrentRow.DataBoundItem as HopDongBaoHiem;
                if (hd != null && MessageBox.Show($"Bạn có chắc chắn muốn XÓA hợp đồng {hd.MaHD}?", "Xác nhận Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    if (controller.Xoa(hd.MaHD))
                    {
                        MessageBox.Show("Đã xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        trangThaiThaoTac = ""; // Reset trạng thái
                        LoadData();            // Load lại tự động khóa
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một hợp đồng để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // ====================== SỰ KIỆN BẤM PHÍM ENTER ======================

        // Hàm này của Windows Form, chuyên dùng để bắt phím trước khi hệ thống kịp xử lý
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            // Nếu bấm phím Enter và đang ở chế độ Thêm hoặc Sửa
            if (keyData == Keys.Enter && (trangThaiThaoTac == "THEM" || trangThaiThaoTac == "SUA"))
            {
                dgvHopDong.EndEdit(); // Bắt buộc chốt dữ liệu đang gõ dở trong ô

                if (dgvHopDong.CurrentRow != null)
                {
                    var hd = dgvHopDong.CurrentRow.DataBoundItem as HopDongBaoHiem;
                    if (hd != null)
                    {
                        string hanhDong = trangThaiThaoTac == "THEM" ? "THÊM MỚI" : "CẬP NHẬT";

                        // Hỏi xác nhận trước khi lưu
                        if (MessageBox.Show($"Bạn có chắc chắn muốn {hanhDong} thông tin này vào cơ sở dữ liệu không?", "Xác nhận Lưu", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            bool success = false;

                            if (trangThaiThaoTac == "THEM")
                            {
                                if (string.IsNullOrWhiteSpace(hd.MaHD))
                                {
                                    MessageBox.Show("Mã hợp đồng không được để trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return true; // Dừng lại, không cho enter
                                }
                                success = controller.Them(hd);
                            }
                            else if (trangThaiThaoTac == "SUA")
                            {
                                success = controller.Sua(hd);
                            }

                            if (success)
                            {
                                MessageBox.Show($"{hanhDong} thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                trangThaiThaoTac = ""; // Reset thao tác
                                LoadData();            // Load lại tự động khóa bảng
                            }
                        }
                    }
                }
                return true; // Báo cho Windows biết: "Tôi xử lý xong phím Enter rồi, đừng tự động nhảy xuống dòng nữa"
            }

            return base.ProcessCmdKey(ref msg, keyData); // Các phím khác cho chạy bình thường
        }

        // ====================== XUẤT FILE (Giữ nguyên code của bạn) ======================
        private void btnXuatFile_Click(object sender, EventArgs e)
        {
            if (dgvHopDong.Rows.Count == 0 || (dgvHopDong.Rows.Count == 1 && dgvHopDong.Rows[0].IsNewRow))
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
            sfd.Title = "Chọn nơi lưu file xuất";
            sfd.FileName = "DanhSachHopDong_" + DateTime.Now.ToString("ddMMyyyy_HHmmss") + ".csv";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (System.IO.StreamWriter sw = new System.IO.StreamWriter(sfd.FileName, false, new System.Text.UTF8Encoding(true)))
                    {
                        string[] columnNames = new string[dgvHopDong.Columns.Count];
                        for (int i = 0; i < dgvHopDong.Columns.Count; i++)
                        {
                            columnNames[i] = dgvHopDong.Columns[i].HeaderText;
                        }
                        sw.WriteLine(string.Join(",", columnNames));

                        foreach (DataGridViewRow row in dgvHopDong.Rows)
                        {
                            if (!row.IsNewRow)
                            {
                                string[] cellValues = new string[dgvHopDong.Columns.Count];
                                for (int i = 0; i < dgvHopDong.Columns.Count; i++)
                                {
                                    string value = row.Cells[i].Value?.ToString() ?? "";
                                    if (value.Contains(",") || value.Contains("\"") || value.Contains("\r") || value.Contains("\n"))
                                    {
                                        value = string.Format("\"{0}\"", value.Replace("\"", "\"\""));
                                    }
                                    cellValues[i] = value;
                                }
                                sw.WriteLine(string.Join(",", cellValues));
                            }
                        }
                    }
                    MessageBox.Show("Xuất file thành công!\nFile được lưu tại:\n" + sfd.FileName, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xuất file: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}