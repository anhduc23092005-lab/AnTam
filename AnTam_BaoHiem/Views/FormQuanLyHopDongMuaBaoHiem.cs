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
                for (int i = 0; i < dgvHopDong.Rows.Count; i++)
                {
                    dgvHopDong.Rows[i].Cells["STT"].Value = (i + 1).ToString();
                }
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

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (dgvHopDong.CurrentRow == null) return;

            var hd = dgvHopDong.CurrentRow.DataBoundItem as HopDongBaoHiem;

            if (hd != null)
            {
                if (string.IsNullOrWhiteSpace(hd.MaHD))
                {
                    MessageBox.Show("Vui lòng nhập Mã Hợp Đồng trực tiếp vào bảng trước!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (controller.Them(hd))
                {
                    MessageBox.Show("Thêm thành công!", "Thông báo");
                    LoadData();
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvHopDong.CurrentRow != null && !dgvHopDong.CurrentRow.IsNewRow)
            {
                var hd = dgvHopDong.CurrentRow.DataBoundItem as HopDongBaoHiem;
                if (hd != null)
                {
                    if (controller.Sua(hd))
                    {
                        MessageBox.Show("Cập nhật thành công!", "Thông báo");
                        LoadData();
                    }
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvHopDong.CurrentRow != null && !dgvHopDong.CurrentRow.IsNewRow)
            {
                var hd = dgvHopDong.CurrentRow.DataBoundItem as HopDongBaoHiem;
                if (hd != null && MessageBox.Show($"Xóa hợp đồng {hd.MaHD}?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (controller.Xoa(hd.MaHD))
                    {
                        LoadData();
                    }
                }
            }
        }

        private void btnXuatFile_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có dữ liệu để xuất không
            if (dgvHopDong.Rows.Count == 0 || (dgvHopDong.Rows.Count == 1 && dgvHopDong.Rows[0].IsNewRow))
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Mở hộp thoại chọn nơi lưu file
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
            sfd.Title = "Chọn nơi lưu file xuất";
            sfd.FileName = "DanhSachHopDong_" + DateTime.Now.ToString("ddMMyyyy_HHmmss") + ".csv";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Dùng UTF8Encoding(true) để file có BOM, giúp Excel đọc tiếng Việt không bị lỗi font
                    using (System.IO.StreamWriter sw = new System.IO.StreamWriter(sfd.FileName, false, new System.Text.UTF8Encoding(true)))
                    {
                        // 1. Ghi tiêu đề cột (Header)
                        string[] columnNames = new string[dgvHopDong.Columns.Count];
                        for (int i = 0; i < dgvHopDong.Columns.Count; i++)
                        {
                            columnNames[i] = dgvHopDong.Columns[i].HeaderText;
                        }
                        sw.WriteLine(string.Join(",", columnNames));

                        // 2. Ghi dữ liệu từng dòng
                        foreach (DataGridViewRow row in dgvHopDong.Rows)
                        {
                            if (!row.IsNewRow) // Bỏ qua dòng trắng cuối cùng dùng để thêm mới
                            {
                                string[] cellValues = new string[dgvHopDong.Columns.Count];
                                for (int i = 0; i < dgvHopDong.Columns.Count; i++)
                                {
                                    string value = row.Cells[i].Value?.ToString() ?? "";

                                    // Xử lý an toàn: nếu chuỗi có chứa dấu phẩy hoặc ngoặc kép thì bọc nó trong ngoặc kép
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