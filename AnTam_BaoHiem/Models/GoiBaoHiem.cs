using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AnTam_BaoHiem.Models
{
    public class GoiBaoHiem
    {
        public int MaGoi { get; set; }
        public string TenGoi { get; set; } // Xe cộ, Thất nghiệp, Tai nạn, Nhân thọ, Y tế
        public decimal MucPhi { get; set; }
        public string MoTa { get; set; }

        // Danh sách tĩnh để bạn dễ dàng quản lý logic 5 loại
        public static readonly string[] LoaiBaoHiem = { "Xe cộ", "Thất nghiệp", "Tai nạn", "Nhân thọ", "Y tế" };
    }
}