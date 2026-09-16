using ketoan.Client.Enums;
using ketoan.Client.FormsUI.Hethong;
using ketoan.Client.FormsUI.Nhaphang;

namespace ketoan.Client
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new DangNhap());
            //Application.Run(new PhieuNhapXuat(LoaiPhieuNhapXuat.Nhaphang));
        }
    }
}