using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using AnTam_BaoHiem.Helpers;

namespace AnTam_BaoHiem.Views
{
    public partial class TaiKhoanForm : Form
    {
        public TaiKhoanForm()
        {
            InitializeComponent();
            LoadData();
        }

        // READ
        private void LoadData()
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string sql = @"SELECT tk.TenDangNhap, tk.MatKhau, tk.LoaiTaiKhoan,
                                      kh.HoTen, kh.CCCD, kh.SoDienThoai, kh.Email
                               FROM TaiKhoan tk
                               LEFT JOIN KhachHang kh 
                               ON tk.TenDangNhap = kh.TenDangNhap";

                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgv.DataSource = dt;

                // ❗ KHÓA SỬA TRÊN BẢNG
                dgv.ReadOnly = true;
                dgv.AllowUserToAddRows = false;
                dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgv.MultiSelect = false;
                dgv.EditMode = DataGridViewEditMode.EditProgrammatically;
            }
        }

        // CREATE
        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();

                try
                {
                    SqlCommand cmd1 = new SqlCommand(
                        "INSERT INTO TaiKhoan VALUES (@u,@p,@r)", conn, tran);

                    cmd1.Parameters.AddWithValue("@u", txtUser.Text);
                    cmd1.Parameters.AddWithValue("@p", txtPass.Text);
                    cmd1.Parameters.AddWithValue("@r", cboRole.Text);
                    cmd1.ExecuteNonQuery();

                    SqlCommand cmd2 = new SqlCommand(
                        @"INSERT INTO KhachHang
                          (TenDangNhap,HoTen,CCCD,SoDienThoai,Email)
                          VALUES(@u,@name,@cccd,@sdt,@mail)", conn, tran);

                    cmd2.Parameters.AddWithValue("@u", txtUser.Text);
                    cmd2.Parameters.AddWithValue("@name", txtName.Text);
                    cmd2.Parameters.AddWithValue("@cccd", txtCCCD.Text);
                    cmd2.Parameters.AddWithValue("@sdt", txtSDT.Text);
                    cmd2.Parameters.AddWithValue("@mail", txtEmail.Text);
                    cmd2.ExecuteNonQuery();

                    tran.Commit();
                    MessageBox.Show("Thêm thành công");
                    LoadData();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    MessageBox.Show("Lỗi thêm: " + ex.Message);
                }
            }
        }

        // UPDATE
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();

                try
                {
                    SqlCommand cmd1 = new SqlCommand(
                        @"UPDATE TaiKhoan 
                          SET MatKhau=@p, LoaiTaiKhoan=@r
                          WHERE TenDangNhap=@u", conn, tran);

                    cmd1.Parameters.AddWithValue("@u", txtUser.Text);
                    cmd1.Parameters.AddWithValue("@p", txtPass.Text);
                    cmd1.Parameters.AddWithValue("@r", cboRole.Text);
                    cmd1.ExecuteNonQuery();

                    SqlCommand cmd2 = new SqlCommand(
                        @"UPDATE KhachHang 
                          SET HoTen=@name, CCCD=@cccd, 
                              SoDienThoai=@sdt, Email=@mail
                          WHERE TenDangNhap=@u", conn, tran);

                    cmd2.Parameters.AddWithValue("@u", txtUser.Text);
                    cmd2.Parameters.AddWithValue("@name", txtName.Text);
                    cmd2.Parameters.AddWithValue("@cccd", txtCCCD.Text);
                    cmd2.Parameters.AddWithValue("@sdt", txtSDT.Text);
                    cmd2.Parameters.AddWithValue("@mail", txtEmail.Text);
                    cmd2.ExecuteNonQuery();

                    tran.Commit();
                    MessageBox.Show("Cập nhật thành công");
                    LoadData();

                    txtUser.Enabled = true; // reset lại
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    MessageBox.Show("Lỗi sửa: " + ex.Message);
                }
            }
        }

        // DELETE
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgv.CurrentRow == null) return;

            string user = dgv.CurrentRow.Cells["TenDangNhap"].Value.ToString();

            if (MessageBox.Show("Xóa tài khoản này?", "Confirm",
                MessageBoxButtons.YesNo) == DialogResult.No) return;

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                SqlCommand cmd1 = new SqlCommand(
                    "DELETE FROM KhachHang WHERE TenDangNhap=@u", conn);
                cmd1.Parameters.AddWithValue("@u", user);
                cmd1.ExecuteNonQuery();

                SqlCommand cmd2 = new SqlCommand(
                    "DELETE FROM TaiKhoan WHERE TenDangNhap=@u", conn);
                cmd2.Parameters.AddWithValue("@u", user);
                cmd2.ExecuteNonQuery();
            }

            LoadData();
        }

        // CLICK GRID → ĐỔ XUỐNG Ô NHẬP
        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgv.Rows[e.RowIndex];
            if (row == null) return;

            txtUser.Text = row.Cells["TenDangNhap"]?.Value?.ToString() ?? "";
            txtPass.Text = row.Cells["MatKhau"]?.Value?.ToString() ?? "";
            cboRole.Text = row.Cells["LoaiTaiKhoan"]?.Value?.ToString() ?? "";

            txtName.Text = row.Cells["HoTen"]?.Value?.ToString() ?? "";
            txtCCCD.Text = row.Cells["CCCD"]?.Value?.ToString() ?? "";
            txtSDT.Text = row.Cells["SoDienThoai"]?.Value?.ToString() ?? "";
            txtEmail.Text = row.Cells["Email"]?.Value?.ToString() ?? "";

            // ❗ khóa username khi sửa
            txtUser.Enabled = false;
        }
    }
}
