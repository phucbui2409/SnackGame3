using SnackGame3.Test;
using SnackGame3.Utils;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SnackGame3.Forms
{
    public partial class MainForm : Form
    {
        // Biến lưu trạng thái bật/tắt âm thanh
        private bool isSoundEnabled = true;

        public MainForm()
        {
            InitializeComponent();
            this.BackColor = GameConfig.BgColor; // dung mau tu config
            this.Load += MainForm_Load;
            this.FormClosing += MainForm_FormClosing;

            
            this.btnChoi.Click += new System.EventHandler(this.btnChoi_Click);
            this.btnThanhTich.Click += new System.EventHandler(this.btnThanhTich_Click);
            this.btnHuongDan.Click += new System.EventHandler(this.btnHuongDan_Click);
            this.btnSound.Click += new System.EventHandler(this.btnSound_Click);
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            SoundManager.PlayBackgroundMusic();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SoundManager.Cleanup();
        }

        private void btnChoi_Click(object sender, EventArgs e)
        {
            SoundManager.PlayButtonClick();
            SoundManager.StopBackgroundMusic();

            GameTestForm frmGame = new GameTestForm();
            frmGame.FormClosed += (s, args) =>
            {
                this.Show();
                SoundManager.ResumeBackgroundMusic();
            };

            frmGame.Show();
            this.Hide();
        }

        private void btnThanhTich_Click(object sender, EventArgs e)
        {
            SoundManager.PlayButtonClick(); // Phát âm thanh nút bấm
            SoundManager.PauseBackgroundMusic(); // Tắt nhạc nền khi xem điểm số
            LeaderboardForm frm = new LeaderboardForm();
            frm.ShowDialog(); // Hiện form bảng thành tích
            SoundManager.ResumeBackgroundMusic(); // Phát lại khi quay lại menu
        }

        private void btnHuongDan_Click(object sender, EventArgs e)
        {
            SoundManager.PlayButtonClick(); // Phát âm thanh nút bấm
            SoundManager.PauseBackgroundMusic(); // Tắt nhạc nền khi xem hướng dẫn
            HowToPlayForm frm = new HowToPlayForm();
            frm.ShowDialog(); // Hiện form hướng dẫn
            SoundManager.ResumeBackgroundMusic(); // Phát lại khi quay lại menu
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            SoundManager.PlayButtonClick(); // Phát âm thanh nút bấm
            SoundManager.Cleanup();
            Application.Exit();
        }

        // Sự kiện khi bấm nút Âm Thanh
        private void btnSound_Click(object sender, EventArgs e)
        {
            SoundManager.PlayButtonClick(); // Phát âm thanh nút bấm
            isSoundEnabled = !isSoundEnabled; // Đảo trạng thái
            SoundManager.IsSoundEnabled = isSoundEnabled;

            if (isSoundEnabled)
            {
                btnSound.Text = "🔊 Âm Thanh: BẬT";
                btnSound.ForeColor = Color.FromArgb(50, 205, 50); // Màu xanh
                SoundManager.PlayBackgroundMusic();
            }
            else
            {
                btnSound.Text = "🔇 Âm Thanh: TẮT";
                btnSound.ForeColor = Color.Gray; // Màu xám
                SoundManager.StopBackgroundMusic();
            }
        }

        private void lblSubtitle_Click(object sender, EventArgs e)
        {

        }

        private void MainForm_Load_1(object sender, EventArgs e)
        {

        }
    }
}
