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
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            
          Application.Run(new frmQuanLyBaoHiem());
          Application.Run(new frmXemBaoHiem());
            
        }
    }
}