using System;
using System.Collections.Generic;
using System.Linq;
using SnackGame3.Forms;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnackGame3
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra sự cố ngoài ý muốn trong game:\n{ex.Message}", "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
