using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AnTam_BaoHiem.Models
{
    public class BoiThuongModel
    {
        public int MaYeuCau { get; set; }
        public int MaHD { get; set; }
        public string NoiDungYeuCau { get; set; }
        public DateTime NgayGui { get; set; }
        public string TrangThai { get; set; }
        public string AnhMinhChung { get; set; }
        public string LyDoTuChoi { get; set; }
    }
}