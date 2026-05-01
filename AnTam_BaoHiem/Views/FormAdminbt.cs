using AnTam_BaoHiem.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace AnTam_BaoHiem.Views
{
    public partial class FormAdminbt : Form
    {
        private BoiThuongController _controller;
        private int maYeuCauDuocChon = -1;

        public FormAdminbt()
        {
            InitializeComponent();
            _controller = new BoiThuongController();
            cboTrangThaiTimKiem.SelectedIndex = 0; // Chọn "Tất cả" mặc định
            LoadGirdView("Tất cả");
        }

        private void LoadGirdView(string trangThai)
        {
            dgvAdmin.DataSource = _controller.LọcYeuCauAdmin(trangThai);
        }
        private void FormAdminbt_Load(object sender, EventArgs e)
        {
            // Đảm bảo ComboBox đã có giá trị mặc định trước khi load
            if (cboTrangThaiTimKiem.Items.Count > 0)
            {
                cboTrangThaiTimKiem.SelectedIndex = 0; // Chọn "Tất cả"
            }
            LoadGirdView("Tất cả");
        }


        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            LoadGirdView(cboTrangThaiTimKiem.SelectedItem.ToString());
        }

        private void dgvAdmin_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvAdmin.Rows[e.RowIndex];
                maYeuCauDuocChon = Convert.ToInt32(row.Cells["MaYeuCau"].Value);
                rtxtChiTiet.Text = row.Cells["NoiDungYeuCau"].Value.ToString();

                string duongDanAnh = row.Cells["AnhMinhChung"].Value?.ToString();
                if (!string.IsNullOrEmpty(duongDanAnh) && System.IO.File.Exists(duongDanAnh))
                {
                    picAnhAdmin.Image = Image.FromFile(duongDanAnh);
                    picAnhAdmin.SizeMode = PictureBoxSizeMode.Zoom;
                }
                else
                {
                    picAnhAdmin.Image = null; // Khách hàng không gửi ảnh hoặc mất file
                }

                txtLyDoTuChoi.Text = row.Cells["LyDoTuChoi"].Value?.ToString();
            }
        }

        private void btnDuyet_Click(object sender, EventArgs e)
        {
            if (maYeuCauDuocChon == -1) return;
            if (_controller.CapNhatTrangThai(maYeuCauDuocChon, "Đã duyệt", null))
            {
                MessageBox.Show("Đã duyệt yêu cầu!");
                LoadGirdView(cboTrangThaiTimKiem.SelectedItem.ToString());
            }
        }

        private void btnTuChoi_Click(object sender, EventArgs e)
        {
            if (maYeuCauDuocChon == -1) return;
            if (string.IsNullOrWhiteSpace(txtLyDoTuChoi.Text))
            {
                MessageBox.Show("Vui lòng nhập lý do từ chối!");
                return;
            }

            if (_controller.CapNhatTrangThai(maYeuCauDuocChon, "Từ chối", txtLyDoTuChoi.Text))
            {
                MessageBox.Show("Đã từ chối yêu cầu!");
                LoadGirdView(cboTrangThaiTimKiem.SelectedItem.ToString());
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }

        
    }
