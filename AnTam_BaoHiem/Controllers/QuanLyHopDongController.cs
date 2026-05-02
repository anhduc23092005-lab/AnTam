using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace FormQuanLyHopDongMuaBaoHiem
{
    public class QuanLyHopDongController
    {
        // Chuỗi kết nối chuẩn tới LocalDB
        private string strConn = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AnTamBaoHiem;Integrated Security=True;TrustServerCertificate=True";

        public List<HopDongBaoHiem> LayDanhSach(string keyword = "", string status = "Tất cả")
        {
            List<HopDongBaoHiem> ds = new List<HopDongBaoHiem>();
            try
            {
                using (SqlConnection conn = new SqlConnection(strConn))
                {
                    // ĐÃ SỬA: Chỉ Select từ bảng HopDong vì nó đã chứa đủ các cột
                    string sql = @"
                        SELECT 
                            MaHD, MaKH, TenCongTy, MaCongTy, 
                            MaGoi, NgayKy, NgayHetHan, TongTien, TrangThai 
                        FROM dbo.HopDong 
                        WHERE 1=1";

                    if (!string.IsNullOrEmpty(keyword))
                        sql += " AND (MaHD LIKE @key OR MaKH LIKE @key OR TenCongTy LIKE @key)";

                    if (status != "Tất cả")
                        sql += " AND TrangThai = @status";

                    SqlCommand cmd = new SqlCommand(sql, conn);

                    if (!string.IsNullOrEmpty(keyword))
                        cmd.Parameters.AddWithValue("@key", "%" + keyword + "%");

                    if (status != "Tất cả")
                        cmd.Parameters.AddWithValue("@status", status);

                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    DateTime tempDate;
                    decimal tempDecimal;

                    while (dr.Read())
                    {
                        ds.Add(new HopDongBaoHiem
                        {
                            MaHD = dr["MaHD"].ToString(),
                            MaKH = dr["MaKH"].ToString(),
                            TenCongTy = dr["TenCongTy"].ToString(),
                            MaCongTy = dr["MaCongTy"].ToString(),
                            MaGoi = dr["MaGoi"].ToString(),
                            NgayKy = DateTime.TryParse(dr["NgayKy"].ToString(), out tempDate) ? tempDate : (DateTime?)null,
                            NgayHetHan = DateTime.TryParse(dr["NgayHetHan"].ToString(), out tempDate) ? tempDate : (DateTime?)null,
                            TongTien = decimal.TryParse(dr["TongTien"].ToString(), out tempDecimal) ? tempDecimal : (decimal?)null,
                            TrangThai = dr["TrangThai"].ToString()
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lấy danh sách dữ liệu: " + ex.Message, "Lỗi SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return ds;
        }

        public bool Them(HopDongBaoHiem hd)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(strConn))
                {
                    // ĐÃ SỬA: Bổ sung TenCongTy, MaCongTy vào lệnh INSERT
                    string sql = "INSERT INTO dbo.HopDong (MaHD, MaKH, TenCongTy, MaCongTy, MaGoi, NgayKy, NgayHetHan, TongTien, TrangThai) " +
                                 "VALUES (@mahd, @makh, @tencongty, @macongty, @magoi, @ngayky, @ngayhethan, @tongtien, @tt)";
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@mahd", hd.MaHD);
                    cmd.Parameters.AddWithValue("@makh", hd.MaKH ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@tencongty", hd.TenCongTy ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@macongty", hd.MaCongTy ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@magoi", hd.MaGoi ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@ngayky", hd.NgayKy ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@ngayhethan", hd.NgayHetHan ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@tongtien", hd.TongTien ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@tt", hd.TrangThai ?? (object)DBNull.Value);

                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm hợp đồng: " + ex.Message, "Lỗi SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool Sua(HopDongBaoHiem hd)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(strConn))
                {
                    // ĐÃ SỬA: Bổ sung TenCongTy, MaCongTy vào lệnh UPDATE
                    string sql = "UPDATE dbo.HopDong SET MaKH=@makh, TenCongTy=@tencongty, MaCongTy=@macongty, MaGoi=@magoi, NgayKy=@ngayky, " +
                                 "NgayHetHan=@ngayhethan, TongTien=@tongtien, TrangThai=@tt WHERE MaHD=@mahd";
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@mahd", hd.MaHD);
                    cmd.Parameters.AddWithValue("@makh", hd.MaKH ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@tencongty", hd.TenCongTy ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@macongty", hd.MaCongTy ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@magoi", hd.MaGoi ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@ngayky", hd.NgayKy ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@ngayhethan", hd.NgayHetHan ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@tongtien", hd.TongTien ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@tt", hd.TrangThai ?? (object)DBNull.Value);

                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi sửa hợp đồng: " + ex.Message, "Lỗi SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool Xoa(string maHD)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(strConn))
                {
                    string sql = "DELETE FROM dbo.HopDong WHERE MaHD = @mahd";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@mahd", maHD);

                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xóa hợp đồng: " + ex.Message, "Lỗi SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}