using System.Configuration;
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
    }
}