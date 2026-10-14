using System;
using System.Diagnostics;
using System.Windows.Forms;
using SnackGame3.Utils;

namespace SnackGame3.Forms
{
    public partial class HowToPlayForm : Form
    {
        public HowToPlayForm()
        {
            try
            {
                InitializeComponent();
                this.BackColor = GameConfig.BgColor; // Đồng bộ màu nền
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[Lỗi khởi tạo HowToPlayForm]: {ex.Message}");
            }
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            try
            {
                SoundManager.PlayButtonClick();
                this.Close(); // Đóng form hướng dẫn để quay lại menu
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[Lỗi đóng HowToPlayForm]: {ex.Message}");
                this.Close();
            }
        }
    }
}
