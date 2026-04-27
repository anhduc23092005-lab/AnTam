using System;
using System.Windows.Forms;
using AnTam_BaoHiem.Views; // Phải có dòng này để nó thấy các Form trong thư mục Views

namespace AnTam_BaoHiem
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Chạy form Quản lý bảo hiểm đầu tiên
           // Application.Run(new frmQuanLyBaoHiem());
            Application.Run(new frmXemBaoHiem());
            
        }
    }
}