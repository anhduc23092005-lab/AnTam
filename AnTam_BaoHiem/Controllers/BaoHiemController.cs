using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using AnTam_BaoHiem.Models;
using AnTam_BaoHiem.Helpers;

namespace AnTam_BaoHiem.Controllers
{
    public class BaoHiemController
    {
        public DataTable LayDanhSachGoi()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string sql = "SELECT * FROM GoiBaoHiem";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                da.Fill(dt);
            }
            return dt;
        }

        // //Thắng thêm: Hàm tìm kiếm theo Mã và Tên kết hợp
        public DataTable TimKiemTheoMaVaTen(string maGoi, string tenGoi)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string sql = "SELECT * FROM GoiBaoHiem WHERE MaGoi LIKE @MaGoi AND TenGoi LIKE @TenGoi";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                da.SelectCommand.Parameters.AddWithValue("@MaGoi", "%" + maGoi + "%");
                da.SelectCommand.Parameters.AddWithValue("@TenGoi", "%" + tenGoi + "%");
                da.Fill(dt);
            }
            return dt;
        }

        public bool ThemGoi(GoiBaoHiem g)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string sql = @"INSERT INTO GoiBaoHiem (MaGoi, TenGoi, MucPhi, MoTa, LoaiBaoHiem, DoiTuongApDung, TrangThai, 
                             ChuKyDongPhi, SoTienBaoHiem, MucKhauTru, TienPhatTreHan, ThoiHanChuan, ThoiGianCho, 
                             DieuKhoanLoaiTru, QuyenLoiChinh, QuyenLoiBoSung, PhamViBaoHiem, DieuKienNhanTien, NgayTao, NguoiTao) 
                             VALUES (@MaGoi, @TenGoi, @MucPhi, @MoTa, @LoaiBaoHiem, @DoiTuongApDung, @TrangThai, 
                             @ChuKyDongPhi, @SoTienBaoHiem, @MucKhauTru, @TienPhatTreHan, @ThoiHanChuan, @ThoiGianCho, 
                             @DieuKhoanLoaiTru, @QuyenLoiChinh, @QuyenLoiBoSung, @PhamViBaoHiem, @DieuKienNhanTien, @NgayTao, @NguoiTao)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                AddParameters(cmd, g);
                try
                {
                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    // Mã lỗi 2627 là mã lỗi vi phạm khóa chính (Primary Key) trong SQL
                    if (ex.Number == 2627)
                    {
                        System.Windows.Forms.MessageBox.Show("Mã gói này đã tồn tại rồi! Vui lòng nhập mã khác hoặc nhấn Sửa để cập nhật nhé.", "Trùng Mã", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                    }
                    else
                    {
                        System.Windows.Forms.MessageBox.Show("Lỗi kết nối CSDL: " + ex.Message, "Lỗi Hệ Thống", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                    }
                    return false;
                }
       
            }
        }

        public bool SuaGoi(GoiBaoHiem g)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string sql = @"UPDATE GoiBaoHiem SET TenGoi=@TenGoi, MucPhi=@MucPhi, MoTa=@MoTa, LoaiBaoHiem=@LoaiBaoHiem, 
                             DoiTuongApDung=@DoiTuongApDung, TrangThai=@TrangThai, ChuKyDongPhi=@ChuKyDongPhi, 
                             SoTienBaoHiem=@SoTienBaoHiem, MucKhauTru=@MucKhauTru, TienPhatTreHan=@TienPhatTreHan, 
                             ThoiHanChuan=@ThoiHanChuan, ThoiGianCho=@ThoiGianCho, DieuKhoanLoaiTru=@DieuKhoanLoaiTru, 
                             QuyenLoiChinh=@QuyenLoiChinh, QuyenLoiBoSung=@QuyenLoiBoSung, PhamViBaoHiem=@PhamViBaoHiem, 
                             DieuKienNhanTien=@DieuKienNhanTien, NgayCapNhat=GETDATE(), NguoiCapNhat=@NguoiCapNhat 
                             WHERE MaGoi=@MaGoi";
                SqlCommand cmd = new SqlCommand(sql, conn);
                AddParameters(cmd, g);
                cmd.Parameters.AddWithValue("@NguoiCapNhat", "Trần Đức Thắng");
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool XoaGoi(string maGoi)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string sql = "DELETE FROM GoiBaoHiem WHERE MaGoi=@MaGoi";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MaGoi", maGoi);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        private void AddParameters(SqlCommand cmd, GoiBaoHiem g)
        {
            cmd.Parameters.AddWithValue("@MaGoi", g.MaGoi);
            cmd.Parameters.AddWithValue("@TenGoi", g.TenGoi);
            cmd.Parameters.AddWithValue("@MucPhi", g.MucPhi);
            cmd.Parameters.AddWithValue("@MoTa", g.MoTa ?? "");
            cmd.Parameters.AddWithValue("@LoaiBaoHiem", g.LoaiBaoHiem ?? "");
            cmd.Parameters.AddWithValue("@DoiTuongApDung", g.DoiTuongApDung ?? "");
            cmd.Parameters.AddWithValue("@TrangThai", g.TrangThai ?? "");
            cmd.Parameters.AddWithValue("@ChuKyDongPhi", g.ChuKyDongPhi ?? "");
            cmd.Parameters.AddWithValue("@SoTienBaoHiem", g.SoTienBaoHiem);
            cmd.Parameters.AddWithValue("@MucKhauTru", g.MucKhauTru);
            cmd.Parameters.AddWithValue("@TienPhatTreHan", g.TienPhatTreHan);
            cmd.Parameters.AddWithValue("@ThoiHanChuan", g.ThoiHanChuan ?? "");
            cmd.Parameters.AddWithValue("@ThoiGianCho", g.ThoiGianCho ?? "");
            cmd.Parameters.AddWithValue("@DieuKhoanLoaiTru", g.DieuKhoanLoaiTru ?? "");
            cmd.Parameters.AddWithValue("@QuyenLoiChinh", g.QuyenLoiChinh ?? "");
            cmd.Parameters.AddWithValue("@QuyenLoiBoSung", g.QuyenLoiBoSung ?? "");
            cmd.Parameters.AddWithValue("@PhamViBaoHiem", g.PhamViBaoHiem ?? "");
            cmd.Parameters.AddWithValue("@DieuKienNhanTien", g.DieuKienNhanTien ?? "");
            cmd.Parameters.AddWithValue("@NgayTao", g.NgayTao);
            cmd.Parameters.AddWithValue("@NguoiTao", "Trần Đức Thắng");
        }

        public void ClearForm(Control.ControlCollection controls)
        {
            foreach (Control c in controls)
            {
                if (c is TextBox) ((TextBox)c).Clear();
                else if (c is RichTextBox) ((RichTextBox)c).Clear();
                else if (c is ComboBox) ((ComboBox)c).SelectedIndex = -1;
                else if (c.HasChildren) ClearForm(c.Controls);
            }
        }
        // Hàm lưu thông tin mua bảo hiểm của khách hàng
        public bool DangKyMua(string maGoi, string hoTen, string sdt, string diaChi, string email)
        {
            try
            {
                using (System.Data.SqlClient.SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    // Giả sử tên bảng trong SQL của bạn là HopDongBaoHiem
                    string sql = "INSERT INTO HopDongBaoHiem (MaGoi, HoTenKhach, SoDienThoai, DiaChi, Email, NgayMua) " +
                                 "VALUES (@MaGoi, @HoTen, @SDT, @DiaChi, @Email, GETDATE())";
                    System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@MaGoi", maGoi);
                    cmd.Parameters.AddWithValue("@HoTen", hoTen);
                    cmd.Parameters.AddWithValue("@SDT", sdt);
                    cmd.Parameters.AddWithValue("@DiaChi", diaChi);
                    cmd.Parameters.AddWithValue("@Email", email);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                // Nếu bảng HopDongBaoHiem của bạn có tên khác hoặc thiếu cột, nó sẽ báo lỗi ở đây
                System.Windows.Forms.MessageBox.Show("Lỗi kết nối CSDL: " + ex.Message);
                return false;
            }
        }
    }
}