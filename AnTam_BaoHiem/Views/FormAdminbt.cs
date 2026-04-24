using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AnTam_BaoHiem.Controllers;

namespace AnTam_BaoHiem
{
    public partial class FormAdmin : Form
    {
        BoiThuongController _controller = new BoiThuongController();
        DataTable _dtYeuCau; // Lưu trữ dữ liệu gốc để lọc
        public FormAdmin()
        {
            InitializeComponent();
            LoadData();
            LoadComboFilter();
        }
        private void LoadComboFilter()
        {
            // Thêm các lựa chọn vào ComboBox lọc
            cboLocLoaiBH.Items.Add("--- Tất cả ---");
            cboLocLoaiBH.Items.AddRange(new string[] { "Xe cộ", "Thất nghiệp", "Tai nạn", "Nhân thọ", "Y tế" });
            cboLocLoaiBH.SelectedIndex = 0;
        }

        private void LoadData()
        {
            _dtYeuCau = _controller.LayDanhSachChoDuyetAdmin();
            dgvBoiThuong.DataSource = _dtYeuCau;

            // Tùy chỉnh tiêu đề cột cho đẹp
            dgvBoiThuong.Columns["MaBT"].HeaderText = "Mã số";
            dgvBoiThuong.Columns["HoTen"].HeaderText = "Khách hàng";
            dgvBoiThuong.Columns["TenGoi"].HeaderText = "Loại bảo hiểm";
            dgvBoiThuong.Columns["SoTienYeuCau"].HeaderText = "Số tiền (VNĐ)";
        }
        // Sự kiện lọc dữ liệu khi chọn ComboBox
        private void cboLocLoaiBH_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_dtYeuCau == null) return;

            string filterValue = cboLocLoaiBH.SelectedItem.ToString();

            if (filterValue == "--- Tất cả ---")
            {
                dgvBoiThuong.DataSource = _dtYeuCau;
            }
            else
            {
                // Sử dụng RowFilter để lọc trực tiếp trên DataTable mà không cần truy vấn lại Database
                DataView dv = _dtYeuCau.DefaultView;
                dv.RowFilter = string.Format("TenGoi LIKE '%{0}%'", filterValue);
                dgvBoiThuong.DataSource = dv;
            }
        }

        private void btnDuyet_Click(object sender, EventArgs e)
        {
            if (dgvBoiThuong.CurrentRow != null)
            {
                int maBT = Convert.ToInt32(dgvBoiThuong.CurrentRow.Cells["MaBT"].Value);

                DialogResult dr = MessageBox.Show("Xác nhận chi trả bồi thường cho yêu cầu này?", "Xác nhận", MessageBoxButtons.YesNo);

                if (dr == DialogResult.Yes)
                {
                    if (_controller.DuyetBoiThuong(maBT, "Đã chi trả", "Đã duyệt bởi Admin"))
                    {
                        MessageBox.Show("Đã cập nhật trạng thái thành công.");
                        LoadData(); // Tải lại danh sách
                    }
                }
            }
        }
    }
}
