using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormLichSuMuaHang
{
    public partial class FormLichSuMuaHang : Form
    {
        LichSuMuaHangController controller = new LichSuMuaHangController();
        private string maKhachHangHienTai = "KH02";

        public FormLichSuMuaHang()
        {
            InitializeComponent();

            dgvLichSu.AutoGenerateColumns = false;
            dgvLichSu.AllowUserToAddRows = false; // Tắt dòng trống mặc định dưới cùng

            this.Load += FormLichSuMuaHang_Load;
            cboLocTrangThai.SelectedIndexChanged += CboLocTrangThai_SelectedIndexChanged;
            dgvLichSu.CellFormatting += DgvLichSu_CellFormatting;
        }

        private void FormLichSuMuaHang_Load(object sender, EventArgs e)
        {
            lblMaKH.Text = maKhachHangHienTai;

            if (cboLocTrangThai.Items.Count > 0)
            {
                cboLocTrangThai.SelectedIndex = 0;
            }

            // Gọi cả 2 hàm khi mới mở form
            LoadThongKeTongQuat();
            LoadDanhSach();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            // Khi tìm kiếm, CHỈ cập nhật lại bảng danh sách ở dưới
            LoadDanhSach();
        }

        private void CboLocTrangThai_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Khi đổi trạng thái lọc, cũng CHỈ cập nhật bảng danh sách
            LoadDanhSach();
        }

        // ================= 1. HÀM LOAD BẢNG DANH SÁCH =================
        private void LoadDanhSach()
        {
            try
            {
                string tuKhoa = txtTimKiem.Text.Trim();
                string trangThai = cboLocTrangThai.SelectedItem?.ToString() ?? "Tất cả";

                DataTable dt = controller.LayLichSu(maKhachHangHienTai, tuKhoa, trangThai);
                dgvLichSu.DataSource = dt;

                CapNhatSTT();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách: " + ex.Message, "Thông báo");
            }
        }

        // ================= 2. HÀM LOAD 4 LABEL THỐNG KÊ =================
        private void LoadThongKeTongQuat()
        {
            try
            {
                // Mẹo: Gọi SQL với từ khóa rỗng "" và trạng thái "Tất cả" để lấy toàn bộ dữ liệu của KH này
                DataTable dtAll = controller.LayLichSu(maKhachHangHienTai, "", "Tất cả");

                if (dtAll == null || dtAll.Rows.Count == 0)
                {
                    lblTongChiTieu.Text = "0 VNĐ";
                    lblMuaNhieuNhat.Text = "---";
                    lblThoiHan.Text = "---";
                    lblChoPheDuyet.Text = "0";

                    lblTongChiTieu.ForeColor = Color.Lime;
                    lblMuaNhieuNhat.ForeColor = Color.Lime;
                    lblThoiHan.ForeColor = Color.Lime;
                    lblChoPheDuyet.ForeColor = Color.Lime;
                    return;
                }

                lblTongChiTieu.ForeColor = Color.Lime;
                lblMuaNhieuNhat.ForeColor = Color.Lime;
                lblChoPheDuyet.ForeColor = Color.Lime;

                // Tính tổng chi tiêu
                decimal tongTien = dtAll.AsEnumerable()
                                     .Where(r => r["TongTien"] != DBNull.Value)
                                     .Sum(r => Convert.ToDecimal(r["TongTien"]));
                lblTongChiTieu.Text = tongTien.ToString("N0") + " VNĐ";

                // Mua nhiều nhất
                var cty = dtAll.AsEnumerable()
                            .GroupBy(r => r.Field<string>("TenCongTy"))
                            .OrderByDescending(g => g.Count())
                            .FirstOrDefault();
                if (cty != null) lblMuaNhieuNhat.Text = cty.Key;

                // Thời hạn
                var hdMoi = dtAll.AsEnumerable()
                              .Where(r => r["NgayHetHan"] != DBNull.Value)
                              .OrderByDescending(r => r.Field<DateTime>("NgayHetHan"))
                              .FirstOrDefault();

                if (hdMoi != null)
                {
                    DateTime ngayHetHan = hdMoi.Field<DateTime>("NgayHetHan");
                    int soNgay = (ngayHetHan.Date - DateTime.Now.Date).Days;

                    if (soNgay < 0)
                    {
                        lblThoiHan.Text = "Đã hết hạn";
                        lblThoiHan.ForeColor = Color.Red;
                    }
                    else
                    {
                        lblThoiHan.Text = "Còn " + soNgay + " ngày";
                        lblThoiHan.ForeColor = Color.Lime;
                    }
                }

                // Tính số lượng Chờ phê duyệt (MỚI)
                // Lưu ý: Đảm bảo chuỗi "Chờ phê duyệt" khớp chính xác với chữ trong Database của bạn
                int soLuongCho = dtAll.AsEnumerable()
                                      .Count(r => r["TrangThai"] != DBNull.Value &&
                                                  r.Field<string>("TrangThai").Trim() == "Chờ phê duyệt");

                lblChoPheDuyet.Text = soLuongCho.ToString();

                // Nếu có đơn chờ, đổi sang màu Cam/Vàng cho nổi bật nhắc nhở, nếu không có thì giữ màu Xanh
                if (soLuongCho > 0)
                {
                    lblChoPheDuyet.ForeColor = Color.Orange;
                }

            }
            catch (Exception ex)
            {
                // Không báo lỗi pop-up ở đây tránh làm phiền người dùng
                Console.WriteLine("Lỗi tải thống kê: " + ex.Message);
            }
        }

        private void CapNhatSTT()
        {
            for (int i = 0; i < dgvLichSu.Rows.Count; i++)
            {
                dgvLichSu.Rows[i].Cells["colSTT"].Value = (i + 1).ToString();
            }
        }

        private void DgvLichSu_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex == dgvLichSu.NewRowIndex) return;

            if (dgvLichSu.Columns[e.ColumnIndex].DataPropertyName == "TrangThai")
            {
                var valTrangThai = e.Value?.ToString();
                if (valTrangThai == "Sắp hết hạn" || valTrangThai == "Hết hạn")
                {
                    e.CellStyle.ForeColor = Color.Red;
                }
                else if (valTrangThai == "Chờ phê duyệt")
                {
                    e.CellStyle.ForeColor = Color.Orange; // Tô màu cam cho cột trạng thái chờ phê duyệt
                }
            }

            if (dgvLichSu.Columns[e.ColumnIndex].DataPropertyName == "NgayHetHan")
            {
                if (e.Value != null && e.Value != DBNull.Value)
                {
                    DateTime ngayHetHan = Convert.ToDateTime(e.Value);
                    if (ngayHetHan.Date < DateTime.Now.Date)
                    {
                        e.CellStyle.ForeColor = Color.Red;
                    }
                }
            }
        }
    }
}