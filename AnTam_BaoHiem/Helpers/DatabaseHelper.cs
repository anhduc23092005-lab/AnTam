using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace AnTam_BaoHiem.Helpers
{
    public static class DatabaseHelper
    {
        // Lấy từ App.config (vừa an toàn, vừa trỏ chuẩn về PCCUADUC của sếp do nãy mình đã gộp chuẩn App.config)
        private static string connectionString = ConfigurationManager.ConnectionStrings["AnTamConn"].ConnectionString;

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

        // Hàm của nhóm sếp
        public static bool CheckConnection()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    return conn.State == ConnectionState.Open;
                }
            }
            catch
            {
                return false;
            }
        }

        // Hàm của nhóm sếp (đã sửa cái lỗi NotImplementedException của máy sếp)
        public static DataTable GetData(string query)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = GetConnection())
            {
                using (SqlDataAdapter da = new SqlDataAdapter(query, conn))
                {
                    da.Fill(dt);
                }
            }
            return dt;
        }

        // Hàm sếp viết thêm cho Form Thanh Toán
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

        // Hàm sếp viết thêm cho Form Thanh Toán
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
    }
}