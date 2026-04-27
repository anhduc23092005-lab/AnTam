using System;

namespace AnTam_BaoHiem.Models
{
    public class GoiBaoHiem
    {
        // ==========================================
        // PHẦN CỦA TRƯỞNG NHÓM
        // ==========================================
        public string MaGoi { get; set; }
        public string TenGoi { get; set; }
        public decimal MucPhi { get; set; }
        public string MoTa { get; set; }

        public static readonly string[] LoaiBaoHiemGoc = { "Bảo hiểm xe cộ", "Bảo hiểm thất nghiệp", "Bảo hiểm tai nạn", "Bảo hiểm nhân thọ", "Bảo hiểm y tế" };

        // ==========================================
        // //Thắng thêm: CẬP NHẬT THEO UI 5 TAB
        // ==========================================

        // //Thắng thêm: Tab 1
        public string LoaiBaoHiem { get; set; }
        public string DoiTuongApDung { get; set; }
        public string TrangThai { get; set; }

        // //Thắng thêm: Tab 2
        public string ChuKyDongPhi { get; set; }
        public decimal SoTienBaoHiem { get; set; }
        public decimal MucKhauTru { get; set; }
        public decimal TienPhatTreHan { get; set; }

        // //Thắng thêm: Tab 3
        public string ThoiHanChuan { get; set; }
        public string ThoiGianCho { get; set; }
        public string DieuKhoanLoaiTru { get; set; }

        // //Thắng thêm: Tab 4
        public string QuyenLoiChinh { get; set; }
        public string QuyenLoiBoSung { get; set; }
        public string PhamViBaoHiem { get; set; }
        public string DieuKienNhanTien { get; set; }

        // //Thắng thêm: Tab 5
        public DateTime NgayTao { get; set; }
        public string NguoiTao { get; set; }
        public DateTime NgayCapNhat { get; set; }
        public string NguoiCapNhat { get; set; }

        public GoiBaoHiem()
        {
            NgayTao = DateTime.Now;
            NgayCapNhat = DateTime.Now;
            NguoiTao = "Trần Đức Thắng";
            NguoiCapNhat = "Trần Đức Thắng";
        }
    }
}