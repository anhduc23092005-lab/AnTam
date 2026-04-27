using System;
using System.Data;
using System.Data.SqlClient;

namespace AnTam_BaoHiem.Helpers
{
    public static class DatabaseHelper
    {
        // Đã dán cứng chuỗi kết nối từ App.config của sếp vào đây luôn cho gọn!
        private static string connectionString = @"Data Source=PCCUADUC;Initial Catalog=AnTam_DB;Integrated Security=True";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

        // Hàm lấy dữ liệu dạng bảng (DataTable)
        public static DataTable ExecuteQuery(string query)
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        // Hàm lấy 1 giá trị duy nhất (dùng cho SUM, COUNT...)
        public static object ExecuteScalar(string query)
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    return cmd.ExecuteScalar();
                }
            }
        }

        internal static object GetData(string query)
        {
            throw new NotImplementedException();
        }
    }
}