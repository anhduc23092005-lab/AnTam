using AnTam_BaoHiem.Models;
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
    public partial class frmQuanLyGoiBaoHiem : Form
    {
        public frmQuanLyGoiBaoHiem()
        {
            InitializeComponent();
        }

        // Hàm này tự chạy khi Form Người lao động vừa được mở lên
        private void frmNguoiLaoDong_Load(object sender, EventArgs e)
        {
            // Viết câu lệnh SQL lấy toàn bộ dữ liệu bảng NhanVien
            string query = "SELECT *  FROM GoiBaoHiem";

            // Gọi hàm GetData bên DatabaseHelper và nhét nó vào cái bảng DataGridView của sếp
            // Lưu ý: Đổi "guna2DataGridView1" thành đúng tên cái bảng mà sếp đã kéo thả ở phần Design nhé!
            guna2DataGridView1.DataSource = DatabaseHelper.GetData(query);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
