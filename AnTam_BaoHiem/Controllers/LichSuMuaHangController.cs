using System;
using System.Data;
using System.Data.SqlClient;

namespace FormLichSuMuaHang
{
    internal class LichSuMuaHangController
    {
        // Chuỗi kết nối đúng theo SQL LocalDB của bạn
        private string strConn = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AnTamBaoHiem;Integrated Security=True";

        public DataTable LayLichSu(string maKH, string tuKhoa, string trangThai)
        {
            DataTable dt = new DataTable();

            // Xử lý logic lệch chữ "Có hiệu lực" (trên form) và "Còn hiệu lực" (trong SQL)
            if (trangThai == "Có hiệu lực")
            {
                trangThai = "Còn hiệu lực";
            }

            using (SqlConnection conn = new SqlConnection(strConn))
            {
                string sql = @"
                    SELECT MaHD, TenCongTy, MaCongTy, MaGoi, NgayKy, NgayHetHan, TongTien, TrangThai 
                    FROM dbo.HopDong 
                    WHERE MaKH = @MaKH 
                      AND (@TuKhoa = '' OR MaHD LIKE '%' + @TuKhoa + '%' OR TenCongTy LIKE '%' + @TuKhoa + '%')
                      AND (@TrangThai = N'Tất cả' OR TrangThai = @TrangThai)";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@MaKH", maKH);
                    cmd.Parameters.AddWithValue("@TuKhoa", tuKhoa);
                    cmd.Parameters.AddWithValue("@TrangThai", trangThai);

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }
    }
}