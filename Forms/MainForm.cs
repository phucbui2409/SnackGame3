using SnackGame3.Test;
using SnackGame3.Utils;
using System;
using System.Diagnostics;
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
            try
            {
                InitializeComponent();
                this.BackColor = GameConfig.BgColor; // dung mau tu config
                this.Load += MainForm_Load;
                this.FormClosing += MainForm_FormClosing;

                this.btnChoi.Click += new System.EventHandler(this.btnChoi_Click);
                this.btnDoKho.Click += new System.EventHandler(this.btnDoKho_Click);
                this.btnThanhTich.Click += new System.EventHandler(this.btnThanhTich_Click);
                this.btnHuongDan.Click += new System.EventHandler(this.btnHuongDan_Click);
                this.btnSound.Click += new System.EventHandler(this.btnSound_Click);
                this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[Lỗi khởi tạo MainForm]: {ex.Message}");
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                UpdateDifficultyButtonUI();
                SoundManager.PlayBackgroundMusic();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[Lỗi MainForm_Load]: {ex.Message}");
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                SoundManager.Cleanup();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[Lỗi MainForm_FormClosing]: {ex.Message}");
            }
        }

        private void UpdateDifficultyButtonUI()
        {
            try
            {
                switch (GameConfig.CurrentDifficulty)
                {
                    case GameDifficulty.Easy:
                        btnDoKho.Text = "⚡ Độ Khó: 🟢 DỄ (Chậm)";
                        btnDoKho.ForeColor = Color.FromArgb(70, 235, 70);
                        break;
                    case GameDifficulty.Hard:
                        btnDoKho.Text = "⚡ Độ Khó: 🔴 KHÓ (Nhanh)";
                        btnDoKho.ForeColor = Color.FromArgb(255, 90, 90);
                        break;
                    case GameDifficulty.Medium:
                    default:
                        btnDoKho.Text = "⚡ Độ Khó: 🟡 VỪA (Bình thường)";
                        btnDoKho.ForeColor = Color.FromArgb(255, 215, 0);
                        break;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[Lỗi UpdateDifficultyButtonUI]: {ex.Message}");
            }
        }

        private void btnDoKho_Click(object sender, EventArgs e)
        {
            try
            {
                SoundManager.PlayButtonClick();

                // Chuyển đổi tuần tự: Dễ -> Vừa -> Khó -> Dễ
                switch (GameConfig.CurrentDifficulty)
                {
                    case GameDifficulty.Easy:
                        GameConfig.CurrentDifficulty = GameDifficulty.Medium;
                        break;
                    case GameDifficulty.Medium:
                        GameConfig.CurrentDifficulty = GameDifficulty.Hard;
                        break;
                    case GameDifficulty.Hard:
                        GameConfig.CurrentDifficulty = GameDifficulty.Easy;
                        break;
                }

                UpdateDifficultyButtonUI();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[Lỗi btnDoKho_Click]: {ex.Message}");
            }
        }

        private void btnChoi_Click(object sender, EventArgs e)
        {
            try
            {
                SoundManager.PlayButtonClick();
                SoundManager.StopBackgroundMusic();

                GameTestForm frmGame = new GameTestForm();
                frmGame.FormClosed += (s, args) =>
                {
                    try
                    {
                        UpdateDifficultyButtonUI();
                        this.Show();
                        SoundManager.ResumeBackgroundMusic();
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine($"[Lỗi khi đóng GameTestForm]: {ex.Message}");
                    }
                };

                frmGame.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[Lỗi btnChoi_Click]: {ex.Message}");
                MessageBox.Show($"Không thể mở màn hình chơi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Show();
            }
        }

        private void btnThanhTich_Click(object sender, EventArgs e)
        {
            try
            {
                SoundManager.PlayButtonClick(); // Phát âm thanh nút bấm
                SoundManager.PauseBackgroundMusic(); // Tắt nhạc nền khi xem điểm số
                LeaderboardForm frm = new LeaderboardForm();
                frm.ShowDialog(); // Hiện form bảng thành tích
                SoundManager.ResumeBackgroundMusic(); // Phát lại khi quay lại menu
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[Lỗi btnThanhTich_Click]: {ex.Message}");
            }
        }

        private void btnHuongDan_Click(object sender, EventArgs e)
        {
            try
            {
                SoundManager.PlayButtonClick(); // Phát âm thanh nút bấm
                SoundManager.PauseBackgroundMusic(); // Tắt nhạc nền khi xem hướng dẫn
                HowToPlayForm frm = new HowToPlayForm();
                frm.ShowDialog(); // Hiện form hướng dẫn
                SoundManager.ResumeBackgroundMusic(); // Phát lại khi quay lại menu
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[Lỗi btnHuongDan_Click]: {ex.Message}");
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            try
            {
                SoundManager.PlayButtonClick(); // Phát âm thanh nút bấm
                SoundManager.Cleanup();
                Application.Exit();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[Lỗi btnThoat_Click]: {ex.Message}");
                Application.Exit();
            }
        }

        // Sự kiện khi bấm nút Âm Thanh
        private void btnSound_Click(object sender, EventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                Debug.WriteLine($"[Lỗi btnSound_Click]: {ex.Message}");
            }
        }
    }
}
