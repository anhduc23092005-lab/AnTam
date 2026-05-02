using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace AnTam_BaoHiem.Controllers
{
    public class BoiThuongController
    {
        private string connectionString = @"Data Source=DESKTOP-FC4HE69;Initial Catalog=AnTam_DB;Integrated Security=True";

     
        public bool GuiYeuCau(int maHD, string noiDung, string duongDanAnh)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO BoiThuong (MaHD, NoiDungYeuCau, TrangThai, AnhMinhChung) VALUES (@MaHD, @NoiDung, N'Chờ duyệt', @Anh)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaHD", maHD);
                cmd.Parameters.AddWithValue("@NoiDung", noiDung);
                cmd.Parameters.AddWithValue("@Anh", string.IsNullOrEmpty(duongDanAnh) ? (object)DBNull.Value : duongDanAnh);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
        public DataTable LayYeuCauKhachHang(int maKH)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT bt.MaYeuCau, bt.MaHD, g.TenGoi, bt.NoiDungYeuCau, bt.NgayGui, bt.TrangThai, bt.LyDoTuChoi 
                                 FROM BoiThuong bt 
                                 INNER JOIN HopDong hd ON bt.MaHD = hd.MaHD 
                                 INNER JOIN GoiBaoHiem g ON hd.MaGoi = g.MaGoi
                                 WHERE hd.MaKH = @MaKH ORDER BY bt.NgayGui DESC";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.SelectCommand.Parameters.AddWithValue("@MaKH", maKH);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        public DataTable LọcYeuCauAdmin(string trangThai)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT bt.*, g.TenGoi 
                                 FROM BoiThuong bt 
                                 INNER JOIN HopDong hd ON bt.MaHD = hd.MaHD 
                                 INNER JOIN GoiBaoHiem g ON hd.MaGoi = g.MaGoi";

                if (!string.IsNullOrEmpty(trangThai) && trangThai != "Tất cả")
                {
                    query += " WHERE bt.TrangThai = @TrangThai";
                }
                query += " ORDER BY bt.NgayGui DESC";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                if (!string.IsNullOrEmpty(trangThai) && trangThai != "Tất cả")
                {
                    da.SelectCommand.Parameters.AddWithValue("@TrangThai", trangThai);
                }
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        public bool CapNhatTrangThai(int maYeuCau, string trangThai, string lyDo)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE BoiThuong SET TrangThai = @TrangThai, LyDoTuChoi = @LyDo WHERE MaYeuCau = @MaYeuCau";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TrangThai", trangThai);
                cmd.Parameters.AddWithValue("@LyDo", string.IsNullOrEmpty(lyDo) ? (object)DBNull.Value : lyDo);
                cmd.Parameters.AddWithValue("@MaYeuCau", maYeuCau);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}