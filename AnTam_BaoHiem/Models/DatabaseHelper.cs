using System;
using System.Data;
using System.Data.SqlClient;

// Đã thêm chữ .Models vào để fix lỗi số 1 (CS0234)
namespace AnTam_BaoHiem.Models
{
    public class DatabaseHelper
    {
        // Chuỗi kết nối của sếp
        private static string connectionString = @"Data Source=PCCUADUC;Initial Catalog=AnTam_DB;Integrated Security=True";

        // ĐÃ BỔ SUNG: Hàm này để fix lỗi số 2 (CS0117) - Trả lại hàm cho TaiKhoanController gọi
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

        // Hàm lấy dữ liệu đổ ra bảng (SELECT)
        public static DataTable GetData(string query)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            return dt;
        }

        // Hàm chạy lệnh Thêm, Sửa, Xóa (INSERT, UPDATE, DELETE)
        public static bool ExecuteQuery(string query)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show("Lỗi Database: " + ex.Message);
                    return false;
                }
            }
        }
    }
}