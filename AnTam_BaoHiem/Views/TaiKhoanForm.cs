// Views/TaiKhoanForm.cs
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
        }

        private void TaiKhoanForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        // ================= READ =================
        private void LoadData()
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    string sql = @"SELECT tk.TenDangNhap, tk.MatKhau, tk.LoaiTaiKhoan,
                                          kh.HoTen, kh.CCCD, kh.SoDienThoai, kh.Email, kh.TenCap
                                   FROM TaiKhoan tk
                                   LEFT JOIN KhachHang kh 
                                   ON tk.TenDangNhap = kh.TenDangNhap";

                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgv.DataSource = dt;

                    dgv.ReadOnly = true;
                    dgv.AllowUserToAddRows = false;
                    dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dgv.MultiSelect = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load dữ liệu: " + ex.Message);
            }
        }

        // ================= VALIDATE =================
        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtUser.Text) ||
                string.IsNullOrWhiteSpace(txtPass.Text) ||
                string.IsNullOrWhiteSpace(cboRole.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return false;
            }
            return true;
        }

        // ================= CREATE =================
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();

                try
                {
                    // Insert tài khoản
                    SqlCommand cmd1 = new SqlCommand(
                        "INSERT INTO TaiKhoan(TenDangNhap,MatKhau,LoaiTaiKhoan) VALUES (@u,@p,@r)",
                        conn, tran);

                    cmd1.Parameters.Add("@u", SqlDbType.NVarChar).Value = txtUser.Text;
                    cmd1.Parameters.Add("@p", SqlDbType.NVarChar).Value = txtPass.Text;
                    cmd1.Parameters.Add("@r", SqlDbType.NVarChar).Value = cboRole.Text;
                    cmd1.ExecuteNonQuery();

                    // Insert khách hàng
                    SqlCommand cmd2 = new SqlCommand(
                        @"INSERT INTO KhachHang
                          (TenDangNhap,HoTen,CCCD,SoDienThoai,Email)
                          VALUES(@u,@name,@cccd,@sdt,@mail)",
                        conn, tran);

                    cmd2.Parameters.Add("@u", SqlDbType.NVarChar).Value = txtUser.Text;
                    cmd2.Parameters.Add("@name", SqlDbType.NVarChar).Value = txtName.Text;
                    cmd2.Parameters.Add("@cccd", SqlDbType.NVarChar).Value = txtCCCD.Text;
                    cmd2.Parameters.Add("@sdt", SqlDbType.NVarChar).Value = txtSDT.Text;
                    cmd2.Parameters.Add("@mail", SqlDbType.NVarChar).Value = txtEmail.Text;
                    cmd2.ExecuteNonQuery();

                    tran.Commit();
                    MessageBox.Show("Thêm thành công");

                    ClearForm();
                    LoadData();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    MessageBox.Show("Lỗi thêm: " + ex.Message);
                }
            }
        }

        // ================= UPDATE =================
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();

                try
                {
                    SqlCommand cmd1 = new SqlCommand(
                        @"UPDATE TaiKhoan 
                          SET MatKhau=@p, LoaiTaiKhoan=@r
                          WHERE TenDangNhap=@u",
                        conn, tran);

                    cmd1.Parameters.Add("@u", SqlDbType.NVarChar).Value = txtUser.Text;
                    cmd1.Parameters.Add("@p", SqlDbType.NVarChar).Value = txtPass.Text;
                    cmd1.Parameters.Add("@r", SqlDbType.NVarChar).Value = cboRole.Text;
                    cmd1.ExecuteNonQuery();

                    SqlCommand cmd2 = new SqlCommand(
                        @"UPDATE KhachHang 
                          SET HoTen=@name, CCCD=@cccd,
                              SoDienThoai=@sdt, Email=@mail
                          WHERE TenDangNhap=@u",
                        conn, tran);

                    cmd2.Parameters.Add("@u", SqlDbType.NVarChar).Value = txtUser.Text;
                    cmd2.Parameters.Add("@name", SqlDbType.NVarChar).Value = txtName.Text;
                    cmd2.Parameters.Add("@cccd", SqlDbType.NVarChar).Value = txtCCCD.Text;
                    cmd2.Parameters.Add("@sdt", SqlDbType.NVarChar).Value = txtSDT.Text;
                    cmd2.Parameters.Add("@mail", SqlDbType.NVarChar).Value = txtEmail.Text;
                    cmd2.ExecuteNonQuery();

                    tran.Commit();
                    MessageBox.Show("Cập nhật thành công");

                    ClearForm();
                    LoadData();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    MessageBox.Show("Lỗi sửa: " + ex.Message);
                }
            }
        }

        // ================= DELETE =================
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgv.CurrentRow == null) return;

            string user = dgv.CurrentRow.Cells["TenDangNhap"]?.Value?.ToString();
            if (string.IsNullOrEmpty(user)) return;

            if (MessageBox.Show("Xóa tài khoản này?", "Xác nhận",
                MessageBoxButtons.YesNo) == DialogResult.No) return;

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                SqlCommand cmd1 = new SqlCommand(
                    "DELETE FROM KhachHang WHERE TenDangNhap=@u", conn);
                cmd1.Parameters.Add("@u", SqlDbType.NVarChar).Value = user;
                cmd1.ExecuteNonQuery();

                SqlCommand cmd2 = new SqlCommand(
                    "DELETE FROM TaiKhoan WHERE TenDangNhap=@u", conn);
                cmd2.Parameters.Add("@u", SqlDbType.NVarChar).Value = user;
                cmd2.ExecuteNonQuery();
            }

            LoadData();
        }

        // ================= CLICK GRID =================
        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dgv.Rows[e.RowIndex] == null) return;

            var row = dgv.Rows[e.RowIndex];

            txtUser.Text = row.Cells["TenDangNhap"]?.Value?.ToString() ?? "";
            txtPass.Text = row.Cells["MatKhau"]?.Value?.ToString() ?? "";
            cboRole.Text = row.Cells["LoaiTaiKhoan"]?.Value?.ToString() ?? "";

            txtName.Text = row.Cells["HoTen"]?.Value?.ToString() ?? "";
            txtCCCD.Text = row.Cells["CCCD"]?.Value?.ToString() ?? "";
            txtSDT.Text = row.Cells["SoDienThoai"]?.Value?.ToString() ?? "";
            txtEmail.Text = row.Cells["Email"]?.Value?.ToString() ?? "";

            txtUser.Enabled = false;
        }

        // ================= CLEAR =================
        private void ClearForm()
        {
            txtUser.Text = "";
            txtPass.Text = "";
            cboRole.SelectedIndex = -1;
            txtName.Text = "";
            txtCCCD.Text = "";
            txtSDT.Text = "";
            txtEmail.Text = "";

            txtUser.Enabled = true;
        }
    }
}
