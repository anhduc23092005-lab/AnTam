using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnTam_BaoHiem.Models
{
    public class BoiThuong
    {
        public int MaBT { get; set; }
        public int MaHD { get; set; }
        public DateTime NgayYeuCau { get; set; }
        public decimal SoTienYeuCau { get; set; }
        public string LyDo { get; set; }
        public string TinhTrang { get; set; } // Đang xử lý, Đã chi trả, Từ chối
    }
}
