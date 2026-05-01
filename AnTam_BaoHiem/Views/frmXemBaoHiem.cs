using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using AnTam_BaoHiem.Controllers;

namespace AnTam_BaoHiem.Views
{
    public partial class frmXemBaoHiem : Form
    {
        private BaoHiemController bus = new BaoHiemController();
        private string maGoiDangChon = "";
        private Panel selectedPanel = null;

        public frmXemBaoHiem()
        {
            InitializeComponent();
        }

        private void frmXemBaoHiem_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

            lblTenGoi_ChiTiet.Visible = false;
            lblMucPhi_ChiTiet.Visible = false;
            rtbChiTietGoi.Visible = false;
            picAnhChiTiet.Visible = false;

            if (cbxLocCongTy != null)
            {
                cbxLocCongTy.Items.Clear();
                cbxLocCongTy.Items.AddRange(new string[] {
                    "Tất cả công ty",
                    "Tổng Công ty Bảo Việt Nhân Thọ (Bảo Việt Life)",
                    "Công ty TNHH Bảo hiểm Nhân thọ Prudential Việt Nam",
                    "Công ty TNHH Bảo hiểm Nhân thọ Manulife Việt Nam",
                    "Công ty TNHH Bảo hiểm Nhân thọ AIA Việt Nam",
                    "Công ty THHH 1 thành viên DUCKCOP"
                });
                cbxLocCongTy.SelectedIndex = 0;
                cbxLocCongTy.SelectedIndexChanged += (s, ev) => LoadCards(null, false, txtTimKiem.Text);
            }

            if (cbxSapXep != null)
            {
                cbxSapXep.Items.Clear();
                cbxSapXep.Items.AddRange(new string[] { "Mặc định", "Giá: Thấp đến Cao", "Giá: Cao xuống Thấp" });
                cbxSapXep.SelectedIndex = 0;
                cbxSapXep.SelectedIndexChanged += (s, ev) => LoadCards(null, false, txtTimKiem.Text);
            }

            if (btnTuVan != null) btnTuVan.Click += btnTuVan_Click;
            if (btnSoSanh != null) btnSoSanh.Click += btnSoSanh_Click;

            LoadCards();
        }

        // --- ĐÃ SỬA LỖI GIAO DIỆN THẺ BẢO HIỂM Ở ĐÂY ---
        private void LoadCards(DataTable dtNguon = null, bool isTuVan = false, string tuKhoa = "")
        {
            flpDanhSachGoi.Controls.Clear();
            DataTable dt = dtNguon ?? bus.LayDanhSachGoi();
            if (dt == null || dt.Rows.Count == 0) return;

            string searchLower = tuKhoa.Trim().ToLower();
            var query = dt.AsEnumerable().Where(row => row["TrangThai"].ToString() != "Ngừng bán");

            if (!isTuVan)
            {
                if (cbxLocCongTy != null && cbxLocCongTy.SelectedIndex > 0)
                {
                    string congTyLoc = cbxLocCongTy.Text;
                    query = query.Where(row => row["LoaiBaoHiem"].ToString() == congTyLoc);
                }

                if (!string.IsNullOrEmpty(searchLower))
                {
                    query = query.Where(row =>
                        row["TenGoi"].ToString().ToLower().Contains(searchLower) ||
                        row["MaGoi"].ToString().ToLower().Contains(searchLower)
                    );
                }

                if (cbxSapXep != null)
                {
                    if (cbxSapXep.SelectedIndex == 1) query = query.OrderBy(row => Convert.ToDecimal(row["MucPhi"]));
                    else if (cbxSapXep.SelectedIndex == 2) query = query.OrderByDescending(row => Convert.ToDecimal(row["MucPhi"]));
                }
            }

            if (!query.Any()) return;

            foreach (DataRow row in query)
            {
                Panel card = new Panel
                {
                    Width = flpDanhSachGoi.Width - 30,
                    // Tăng chiều cao thẻ lên một chút để nhét vừa Checkbox xuống dưới
                    Height = isTuVan ? 115 : 105,
                    BackColor = isTuVan ? Color.LightYellow : Color.White,
                    BorderStyle = BorderStyle.FixedSingle,
                    Margin = new Padding(5, 5, 5, 10),
                    Cursor = Cursors.Hand,
                    Tag = row
                };

                Label lblTen = new Label
                {
                    Text = (isTuVan ? "⭐ " : "") + row["TenGoi"].ToString(),
                    Font = new Font("Segoe UI", 11, FontStyle.Bold), // Chữ nhỏ lại xíu cho đỡ tràn
                    ForeColor = isTuVan ? Color.DarkOrange : Color.FromArgb(44, 62, 80),
                    Location = new Point(10, 10),
                    Width = card.Width - 20, // Trả lại toàn bộ không gian chiều ngang cho tên gói
                    Height = 40, // Đủ để tên gói tự rớt xuống 2 dòng nếu quá dài
                    AutoEllipsis = true
                };

                Label lblPhi = new Label
                {
                    Text = "Phí: " + Convert.ToDecimal(row["MucPhi"]).ToString("N0") + "đ", // Rút gọn chữ VNĐ thành đ cho đỡ chật
                    ForeColor = Color.Crimson,
                    Font = new Font("Segoe UI", 10, FontStyle.Bold),
                    Location = new Point(10, 50),
                    AutoSize = true
                };

                // ĐƯA CHECKBOX XUỐNG DƯỚI CÙNG TRÁNH CHE TÊN GÓI
                CheckBox chkSoSanh = new CheckBox
                {
                    Text = "So sánh",
                    Location = new Point(10, 75),
                    AutoSize = true,
                    Cursor = Cursors.Default,
                    Tag = row
                };

                if (isTuVan)
                {
                    Label lblTag = new Label
                    {
                        Text = "Dành riêng cho bạn",
                        BackColor = Color.Green,
                        ForeColor = Color.White,
                        Font = new Font("Segoe UI", 8, FontStyle.Bold),
                        Location = new Point(card.Width - 110, 80), // Đẩy nhãn xanh sang góc phải
                        AutoSize = true
                    };
                    card.Controls.Add(lblTag);
                }

                card.Controls.Add(lblTen);
                card.Controls.Add(lblPhi);
                card.Controls.Add(chkSoSanh);

                Action selectAction = () => {
                    if (selectedPanel != null) selectedPanel.BackColor = Color.White;
                    selectedPanel = card;
                    selectedPanel.BackColor = Color.AliceBlue;
                    ShowDetail(row);
                };

                card.Click += (s, ev) => selectAction();
                lblTen.Click += (s, ev) => selectAction();
                lblPhi.Click += (s, ev) => selectAction();

                flpDanhSachGoi.Controls.Add(card);
            }
        }

        private void btnTuVan_Click(object sender, EventArgs e)
        {
            using (Form frmPopup = new Form())
            {
                frmPopup.Text = "DuckCop - Tư vấn gói bảo hiểm";
                frmPopup.Size = new Size(380, 220);
                frmPopup.StartPosition = FormStartPosition.CenterParent;
                frmPopup.FormBorderStyle = FormBorderStyle.FixedDialog;
                frmPopup.MaximizeBox = false;
                frmPopup.MinimizeBox = false;
                frmPopup.BackColor = Color.White;

                Label lblTuoi = new Label() { Text = "Tuổi của bạn:", Location = new Point(20, 30), AutoSize = true, Font = new Font("Segoe UI", 10) };
                Label lblNganSach = new Label() { Text = "Ngân sách tối đa/kỳ:", Location = new Point(20, 75), AutoSize = true, Font = new Font("Segoe UI", 10) };

                TextBox txtTuoiPopup = new TextBox() { Location = new Point(160, 27), Width = 180, Font = new Font("Segoe UI", 10) };
                TextBox txtNganSachPopup = new TextBox() { Location = new Point(160, 72), Width = 180, Font = new Font("Segoe UI", 10) };

                Button btnTimKiemPopup = new Button()
                {
                    Text = "Tìm kiếm ngay",
                    Location = new Point(130, 120),
                    Width = 120,
                    Height = 35,
                    BackColor = Color.FromArgb(41, 128, 185),
                    ForeColor = Color.White,
                    Font = new Font("Segoe UI", 10, FontStyle.Bold),
                    FlatStyle = FlatStyle.Flat,
                    Cursor = Cursors.Hand
                };
                btnTimKiemPopup.FlatAppearance.BorderSize = 0;

                frmPopup.Controls.Add(lblTuoi);
                frmPopup.Controls.Add(txtTuoiPopup);
                frmPopup.Controls.Add(lblNganSach);
                frmPopup.Controls.Add(txtNganSachPopup);
                frmPopup.Controls.Add(btnTimKiemPopup);

                btnTimKiemPopup.Click += (senderBtn, evBtn) =>
                {
                    if (!int.TryParse(txtTuoiPopup.Text, out int tuoi) || !decimal.TryParse(txtNganSachPopup.Text, out decimal nganSach))
                    {
                        MessageBox.Show("Vui lòng nhập số hợp lệ vào ô Tuổi và Ngân sách!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    DataTable dt = bus.LayDanhSachGoi();
                    var query = dt.AsEnumerable().Where(r => r["TrangThai"].ToString() != "Ngừng bán");

                    var listGoiLyTuong = query.Where(r =>
                    {
                        decimal phi = Convert.ToDecimal(r["MucPhi"]);
                        string doiTuong = r["DoiTuongApDung"].ToString();

                        if (phi > nganSach) return false;
                        if (doiTuong.Contains("Mọi") || doiTuong.Contains("Tất cả")) return true;

                        var numbers = Regex.Matches(doiTuong, @"\d+");
                        if (numbers.Count >= 2)
                        {
                            int min = int.Parse(numbers[0].Value);
                            int max = int.Parse(numbers[1].Value);
                            return tuoi >= min && tuoi <= max;
                        }
                        if (numbers.Count == 1 && doiTuong.Contains("Trên")) return tuoi >= int.Parse(numbers[0].Value);
                        return true;
                    })
                    .OrderByDescending(r => Convert.ToDecimal(r["MucPhi"]))
                    .Take(3);

                    if (listGoiLyTuong.Any())
                    {
                        LoadCards(listGoiLyTuong.CopyToDataTable(), true);
                        MessageBox.Show($"Tìm thấy {listGoiLyTuong.Count()} gói siêu phù hợp với ngân sách {nganSach:N0} VNĐ của bạn!", "Tư vấn thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Rất tiếc, chưa có gói bảo hiểm nào phù hợp với mức ngân sách này.", "Gợi ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadCards();
                    }

                    frmPopup.DialogResult = DialogResult.OK;
                    frmPopup.Close();
                };

                frmPopup.ShowDialog();
            }
        }

        private void btnSoSanh_Click(object sender, EventArgs e)
        {
            List<DataRow> selectedRows = new List<DataRow>();

            foreach (Control card in flpDanhSachGoi.Controls)
            {
                foreach (Control c in card.Controls)
                {
                    if (c is CheckBox chk && chk.Checked)
                    {
                        selectedRows.Add(chk.Tag as DataRow);
                    }
                }
            }

            if (selectedRows.Count != 2)
            {
                MessageBox.Show("Vui lòng tick chọn ĐÚNG 2 gói bảo hiểm để so sánh!", "Nghiệp vụ So sánh", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            TaoFormSoSanh(selectedRows[0], selectedRows[1]);
        }

        // --- ĐÃ SỬA LỖI BỊ CẮT CHỮ TRONG BẢNG SO SÁNH Ở ĐÂY ---
        private void TaoFormSoSanh(DataRow r1, DataRow r2)
        {
            Form frmSoSanh = new Form
            {
                Text = "So Sánh Gói Bảo Hiểm - An Tâm",
                Size = new Size(950, 600),
                StartPosition = FormStartPosition.CenterScreen,
                BackColor = Color.White
            };

            TableLayoutPanel table = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 3,
                RowCount = 6, // Chỉ định đúng 6 dòng
                CellBorderStyle = TableLayoutPanelCellBorderStyle.Single,
                AutoScroll = true // Cho phép cuộn nếu dữ liệu quá dài
            };

            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));

            // THUẬT TOÁN CO GIÃN: Cho phép các dòng tự động bung chiều cao theo nội dung
            for (int i = 0; i < 6; i++)
            {
                table.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            }

            Label CreateLbl(string txt, bool isHeader = false) => new Label
            {
                Text = txt,
                Dock = DockStyle.Fill,
                TextAlign = isHeader ? ContentAlignment.MiddleCenter : ContentAlignment.MiddleLeft,
                Font = new Font("Segoe UI", isHeader ? 11 : 10, isHeader ? FontStyle.Bold : FontStyle.Regular),
                ForeColor = isHeader ? Color.DarkBlue : Color.Black,
                Padding = new Padding(8), // Tăng lề cho đẹp
                AutoSize = true // CRITICAL FIX: Lệnh này giúp Label không bị cắt chữ
            };

            // Đổi chữ "TIÊU CHÍ" thành "TÊN GÓI"
            table.Controls.Add(CreateLbl("TÊN GÓI", true), 0, 0);
            table.Controls.Add(CreateLbl(r1["TenGoi"].ToString().ToUpper(), true), 1, 0);
            table.Controls.Add(CreateLbl(r2["TenGoi"].ToString().ToUpper(), true), 2, 0);

            string chuKy1 = r1.Table.Columns.Contains("ChuKyDongPhi") ? r1["ChuKyDongPhi"].ToString() : "Năm";
            string chuKy2 = r2.Table.Columns.Contains("ChuKyDongPhi") ? r2["ChuKyDongPhi"].ToString() : "Năm";

            table.Controls.Add(CreateLbl("Mức Phí", true), 0, 1);
            table.Controls.Add(CreateLbl($"{Convert.ToDecimal(r1["MucPhi"]):N0} VNĐ / {chuKy1}"), 1, 1);
            table.Controls.Add(CreateLbl($"{Convert.ToDecimal(r2["MucPhi"]):N0} VNĐ / {chuKy2}"), 2, 1);

            table.Controls.Add(CreateLbl("Thời gian chờ", true), 0, 2);
            table.Controls.Add(CreateLbl(r1["ThoiGianCho"].ToString()), 1, 2);
            table.Controls.Add(CreateLbl(r2["ThoiGianCho"].ToString()), 2, 2);

            table.Controls.Add(CreateLbl("Mức khấu trừ", true), 0, 3);
            table.Controls.Add(CreateLbl($"{Convert.ToDecimal(r1["MucKhauTru"]):N0} VNĐ"), 1, 3);
            table.Controls.Add(CreateLbl($"{Convert.ToDecimal(r2["MucKhauTru"]):N0} VNĐ"), 2, 3);

            table.Controls.Add(CreateLbl("Quyền lợi chính", true), 0, 4);
            table.Controls.Add(CreateLbl(r1["QuyenLoiChinh"].ToString()), 1, 4);
            table.Controls.Add(CreateLbl(r2["QuyenLoiChinh"].ToString()), 2, 4);

            table.Controls.Add(CreateLbl("Công ty cấp", true), 0, 5);
            table.Controls.Add(CreateLbl(r1["LoaiBaoHiem"].ToString()), 1, 5);
            table.Controls.Add(CreateLbl(r2["LoaiBaoHiem"].ToString()), 2, 5);

            frmSoSanh.Controls.Add(table);
            frmSoSanh.ShowDialog();
        }

        private void ShowDetail(DataRow row)
        {
            lblTenGoi_ChiTiet.Visible = true;
            lblMucPhi_ChiTiet.Visible = true;
            rtbChiTietGoi.Visible = true;
            picAnhChiTiet.Visible = true;

            maGoiDangChon = row["MaGoi"].ToString();
            string tenGoi = row["TenGoi"].ToString();
            string congTy = row["LoaiBaoHiem"].ToString();
            decimal mucPhi = Convert.ToDecimal(row["MucPhi"]);
            string chuKy = row.Table.Columns.Contains("ChuKyDongPhi") ? row["ChuKyDongPhi"].ToString() : "Năm";

            lblTenGoi_ChiTiet.Text = tenGoi.ToUpper();
            lblMucPhi_ChiTiet.Text = "Giá niêm yết: " + mucPhi.ToString("N0") + " VNĐ / " + chuKy;

            LoadLargeImage(maGoiDangChon);

            rtbChiTietGoi.Clear();

            string noiDung = $"🌟 GIỚI THIỆU GÓI {tenGoi.ToUpper()} 🌟\n";
            noiDung += $"Được thiết kế và bảo trợ bởi {congTy}, đây là giải pháp tài chính toàn diện giúp bạn và những người thân yêu vững bước trước mọi biến cố. Với các quyền lợi ưu việt và thủ tục minh bạch, {tenGoi} tự hào là lựa chọn hàng đầu cho tương lai của bạn.\n\n";

            DateTime ngayMua = DateTime.Now;
            DateTime kyTiepTheo = chuKy == "Tháng" ? ngayMua.AddMonths(1) : (chuKy == "Quý" ? ngayMua.AddMonths(3) : ngayMua.AddYears(1));

            noiDung += $"📅 DỰ TOÁN LỊCH ĐÓNG PHÍ (Nếu đăng ký hôm nay)\n";
            noiDung += $"- Kỳ đóng phí đầu tiên: {ngayMua:dd/MM/yyyy} - Số tiền: {mucPhi:N0} VNĐ\n";
            noiDung += $"- Kỳ đóng phí tiếp theo: {kyTiepTheo:dd/MM/yyyy} - Số tiền: {mucPhi:N0} VNĐ\n";
            noiDung += $"- Phạt trễ hạn (nếu có): {Convert.ToDecimal(row["TienPhatTreHan"]):N0} VNĐ/lần.\n";
            noiDung += "--------------------------------------------------\n\n";

            noiDung += "📌 MÔ TẢ NGẮN:\n" + row["MoTa"].ToString() + "\n\n";
            noiDung += "👨‍👩‍👧‍👦 ĐỐI TƯỢNG ÁP DỤNG:\n" + row["DoiTuongApDung"].ToString() + "\n\n";
            noiDung += "✅ QUYỀN LỢI CHÍNH:\n" + row["QuyenLoiChinh"].ToString() + "\n\n";

            if (row.Table.Columns.Contains("QuyenLoiBoSung"))
                noiDung += "🎁 QUYỀN LỢI BỔ SUNG:\n" + row["QuyenLoiBoSung"].ToString() + "\n\n";

            if (row.Table.Columns.Contains("PhamViBaoHiem"))
                noiDung += "🌍 PHẠM VI BẢO HIỂM:\n" + row["PhamViBaoHiem"].ToString() + "\n\n";

            if (row.Table.Columns.Contains("DieuKienNhanTien"))
                noiDung += "💰 ĐIỀU KIỆN NHẬN TIỀN:\n" + row["DieuKienNhanTien"].ToString() + "\n\n";

            noiDung += "⚠️ ĐIỀU KHOẢN LOẠI TRỪ:\n" + row["DieuKhoanLoaiTru"].ToString();

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

        private void btnTimKiem_Click(object sender, EventArgs e) => LoadCards(null, false, txtTimKiem.Text.Trim());

        private void btnMuaBaoHiem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(maGoiDangChon))
            {
                MessageBox.Show("Vui lòng chọn một gói bảo hiểm ở bên trái trước khi mua!", "Nhắc nhở");
                return;
            }

            string hoTenKhach = "Khách hàng (Lấy từ Session Login)";

            MessageBox.Show(
                $"Đăng ký thành công gói {lblTenGoi_ChiTiet.Text}!\n\n" +
                $"Hệ thống đã tự động liên kết hợp đồng này với tài khoản '{hoTenKhach}' đang đăng nhập trên hệ thống.\n" +
                "Vui lòng kiểm tra email để xem chi tiết hợp đồng.",
                "Giao dịch thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}