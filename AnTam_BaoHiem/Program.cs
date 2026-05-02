using AnTam_BaoHiem.Views;
using System;
using System.Windows.Forms;
using AnTam_BaoHiem.Views; 

namespace AnTam_BaoHiem
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
             //Application.Run(new AnTam_BaoHiem.Views.frmAdminMain());
           
            Application.Run(new AnTam_BaoHiem.Views.frmThanhToanKhachHang(3, 2));
        }
    }
}