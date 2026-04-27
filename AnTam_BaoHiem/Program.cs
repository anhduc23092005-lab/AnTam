using AnTam_BaoHiem.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnTam_BaoHiem
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
             Application.Run(new AnTam_BaoHiem.Views.frmAdminMain());
            // Thay số 1 đầu tiên thành số 2 (Vì ông aNHDUC có MaKH = 2)
            Application.Run(new AnTam_BaoHiem.Views.frmThanhToanKhachHang(2, 1));
        }
    }
}
