using System;
using System.Windows.Forms;
using SnackGame3.Utils;

namespace SnackGame3.Forms
{
    public partial class HowToPlayForm : Form
    {
        public HowToPlayForm()
        {
            InitializeComponent();
            this.BackColor = GameConfig.BgColor; // Đồng bộ màu nền
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            SoundManager.PlayButtonClick();
            this.Close(); // Đóng form hướng dẫn để quay lại menu
        }
    }
}
