using System;

namespace FormQuanLyHopDongMuaBaoHiem
{
    public class HopDongBaoHiem
    {
        public string MaHD { get; set; }
        public string MaKH { get; set; }

        // Dữ liệu lấy thêm từ bảng KhachHang
        public string TenCongTy { get; set; }
        public string MaCongTy { get; set; }

        public string MaGoi { get; set; }
        public DateTime? NgayKy { get; set; }
        public DateTime? NgayHetHan { get; set; }
        public decimal? TongTien { get; set; }
        public string TrangThai { get; set; }
    }
}