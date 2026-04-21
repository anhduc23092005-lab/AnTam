using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using AnTam_BaoHiem.Helpers;
using AnTam_BaoHiem.Models;

namespace AnTam_BaoHiem.Controllers
{
    public class BoiThuongController
    {
        // 1. Lấy danh sách hợp đồng còn hiệu lực để khách hàng chọn bồi thường
        public DataTable LayDanhSachHopDongHieuLuc(int maKH)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string sql = @"SELECT hd.MaHD, gbh.TenGoi, hd.NgayHetHan 
                               FROM HopDong hd 
                               JOIN GoiBaoHiem gbh ON hd.MaGoi = gbh.MaGoi 
                               WHERE hd.MaKH = @MaKH AND hd.TrangThai = N'Đang hiệu lực'";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MaKH", maKH);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }

        // 2. Gửi yêu cầu bồi thường (Xử lý logic theo loại gói)
        public bool GuiYeuCauBoiThuong(int maHD, decimal soTienYC, string lyDo)
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string sql = @"INSERT INTO BoiThuong (MaHD, NgayYeuCau, SoTienYeuCau, LyDo, TinhTrang) 
                                   VALUES (@MaHD, @NgayYeuCau, @SoTien, @LyDo, N'Đang xử lý')";

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@MaHD", maHD);
                    cmd.Parameters.AddWithValue("@NgayYeuCau", DateTime.Now);
                    cmd.Parameters.AddWithValue("@SoTien", soTienYC);
                    cmd.Parameters.AddWithValue("@LyDo", lyDo);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                // Bạn có thể log lỗi ở đây
                return false;
            }
        }

        // 3. Lấy danh sách chờ duyệt cho Admin (Phân loại theo 5 loại gói)
        public DataTable LayDanhSachChoDuyetAdmin()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                // Query kết hợp 3 bảng để Admin thấy đủ thông tin phân loại
                string sql = @"SELECT bt.MaBT, kh.HoTen, gbh.TenGoi, bt.SoTienYeuCau, bt.NgayYeuCau, bt.LyDo
                               FROM BoiThuong bt
                               JOIN HopDong hd ON bt.MaHD = hd.MaHD
                               JOIN KhachHang kh ON hd.MaKH = kh.MaKH
                               JOIN GoiBaoHiem gbh ON hd.MaGoi = gbh.MaGoi
                               WHERE bt.TinhTrang = N'Đang xử lý'
                               ORDER BY gbh.TenGoi ASC"; // Sắp xếp theo loại gói để Admin dễ quản lý

                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }

        // 4. Duyệt hoặc Từ chối bồi thường
        public bool DuyetBoiThuong(int maBT, string trangThaiMoi, string ghiChuAdmin)
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    // Cập nhật trạng thái và có thể thêm ghi chú nếu database của bạn có cột GhiChu
                    string sql = @"UPDATE BoiThuong 
                                   SET TinhTrang = @TrangThai 
                                   WHERE MaBT = @MaBT";

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@TrangThai", trangThaiMoi); // 'Đã chi trả' hoặc 'Từ chối'
                    cmd.Parameters.AddWithValue("@MaBT", maBT);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}