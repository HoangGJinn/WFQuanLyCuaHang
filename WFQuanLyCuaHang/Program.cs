using System;
using System.Threading;
using System.Windows.Forms;

namespace WFQuanLyCuaHang
{
    static class Program
    {
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();

        [STAThread]
        static void Main()
        {
            SetProcessDPIAware(); // chống Windows tự scale
            bool createdNew;
            // Tạo một mutex để kiểm tra instance duy nhất
            using (Mutex mutex = new Mutex(true, "WFQuanLyCuaHang_UniqueMutexName", out createdNew))
            {
                if (!createdNew)
                {
                    MessageBox.Show("Ứng dụng đã được khởi động trước đó!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return; // Thoát ứng dụng
                }

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new FormLogin());
            }
        }
    }
}
