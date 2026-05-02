using AnTam_BaoHiem.Helpers;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AnTam_BaoHiem.Views
{
    public partial class QLCapBac : Form
    {
        public QLCapBac()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string sql = "SELECT TenCap, EXPToiThieu, MoTa FROM QuanLyCapBac ORDER BY EXPToiThieu";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgv.DataSource = dt;
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtTenCap.Text))
            {
                MessageBox.Show("Nhập tên cấp");
                return false;
            }

            if (!int.TryParse(txtEXP.Text, out _))
            {
                MessageBox.Show("EXP phải là số");
                return false;
            }

            return true;
        }

        // ADD
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                // check trùng
                SqlCommand check = new SqlCommand(
                    "SELECT COUNT(*) FROM QuanLyCapBac WHERE TenCap=@ten", conn);
                check.Parameters.AddWithValue("@ten", txtTenCap.Text);

                int exists = (int)check.ExecuteScalar();
                if (exists > 0)
                {
                    MessageBox.Show("Tên cấp đã tồn tại");
                    return;
                }

                SqlCommand cmd = new SqlCommand(
                    @"INSERT INTO QuanLyCapBac(TenCap, EXPToiThieu, MoTa)
                      VALUES(@ten, @exp, @mota)", conn);

                cmd.Parameters.AddWithValue("@ten", txtTenCap.Text);
                cmd.Parameters.AddWithValue("@exp", int.Parse(txtEXP.Text));
                cmd.Parameters.AddWithValue("@mota", txtMoTa.Text);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Thêm thành công");
                LoadData();
            }
        }

        // UPDATE
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;
            if (dgv.CurrentRow == null) return;

            string oldTenCap = dgv.CurrentRow.Cells["TenCap"].Value.ToString();

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(
                    @"UPDATE QuanLyCapBac 
                      SET TenCap=@ten, EXPToiThieu=@exp, MoTa=@mota
                      WHERE TenCap=@old", conn);

                cmd.Parameters.AddWithValue("@old", oldTenCap);
                cmd.Parameters.AddWithValue("@ten", txtTenCap.Text);
                cmd.Parameters.AddWithValue("@exp", int.Parse(txtEXP.Text));
                cmd.Parameters.AddWithValue("@mota", txtMoTa.Text);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Cập nhật thành công");
                LoadData();
            }
        }

        // DELETE
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgv.CurrentRow == null) return;

            string tenCap = dgv.CurrentRow.Cells["TenCap"].Value.ToString();

            if (MessageBox.Show("Xóa cấp này?", "Confirm",
                MessageBoxButtons.YesNo) == DialogResult.No) return;

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(
                    "DELETE FROM QuanLyCapBac WHERE TenCap=@ten", conn);

                cmd.Parameters.AddWithValue("@ten", tenCap);
                cmd.ExecuteNonQuery();
            }

            LoadData();
        }

        // CLICK GRID
        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgv.Rows[e.RowIndex];

            txtTenCap.Text = row.Cells["TenCap"]?.Value?.ToString() ?? "";
            txtEXP.Text = row.Cells["EXPToiThieu"]?.Value?.ToString() ?? "";
            txtMoTa.Text = row.Cells["MoTa"]?.Value?.ToString() ?? "";
        }
    }
}