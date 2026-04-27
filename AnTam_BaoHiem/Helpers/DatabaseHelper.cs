using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace AnTam_BaoHiem.Helpers
{
    public static class DatabaseHelper
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["AnTamConn"].ConnectionString;

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

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
    }
}