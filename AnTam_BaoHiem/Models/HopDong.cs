using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnTam_BaoHiem.Models
{
    public class HopDong
    {
        public int MaHD { get; set; }
        public int MaKH { get; set; }
        public int MaGoi { get; set; }
        public DateTime NgayKy { get; set; }
        public DateTime NgayHetHan { get; set; }
        public decimal TongTien { get; set; }
        public string TrangThai { get; set; } // Chờ duyệt, Đang hiệu lực, Đã hủy
    }
}
