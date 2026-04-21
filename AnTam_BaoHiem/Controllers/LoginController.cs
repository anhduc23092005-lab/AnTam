using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using AnTam_BaoHiem.Helpers;
namespace AnTam_BaoHiem.Controllers
{
    public class LoginController
    {
        public (string loaiTK, int maKH, string hoTen) ThucHienDangNhap(string user, string pass)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                // Truy vấn bảng TaiKhoan kết hợp bảng KhachHang để lấy MaKH và HoTen
                string sql = @"SELECT tk.LoaiTaiKhoan, kh.MaKH, kh.HoTen 
                               FROM TaiKhoan tk
                               LEFT JOIN KhachHang kh ON tk.TenDangNhap = kh.TenDangNhap
                               WHERE tk.TenDangNhap = @user AND tk.MatKhau = @pass";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@user", user);
                cmd.Parameters.AddWithValue("@pass", pass);

                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        string loai = reader["LoaiTaiKhoan"].ToString();
                        // Nếu là Admin thì MaKH sẽ là 0, nếu là Khách hàng thì lấy mã từ DB
                        int maKH = reader["MaKH"] != DBNull.Value ? Convert.ToInt32(reader["MaKH"]) : 0;
                        string ten = reader["HoTen"] != DBNull.Value ? reader["HoTen"].ToString() : "Quản trị viên";

                        return (loai, maKH, ten);
                    }
                }
                catch (Exception) { /* Handle error */ }
            }
            return (null, 0, null); // Trả về null nếu sai tài khoản
        }
    }
}