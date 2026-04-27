using System.Data.SqlClient;
using AnTam_BaoHiem.Models;

namespace AnTam_BaoHiem.Controllers
{
    public class TaiKhoanController
    {
        public bool KiemTraDangNhap(string user, string pass)
        {
            using (SqlConnection con = DatabaseHelper.GetConnection())
            {
                string sql = "SELECT COUNT(*) FROM TaiKhoan WHERE TenDangNhap = @user AND MatKhau = @pass";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@user", user);
                cmd.Parameters.AddWithValue("@pass", pass);

                con.Open();
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }
    }
}