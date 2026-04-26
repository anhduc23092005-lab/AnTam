using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AnTam_BaoHiem.Models
{
    public class TaiKhoan
{
    public string TenDangNhap { get; set; }
    public string MatKhau { get; set; }
    public string Quyen { get; set; } // Admin hoặc User
}
