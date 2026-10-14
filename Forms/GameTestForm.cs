using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using SnackGame3.Utils;

namespace SnackGame3.Test
{
    public partial class GameTestForm : Form
    {
        private enum Direction { Up, Down, Left, Right }

        // Cấu hình bàn cờ
        private const int CELL_SIZE = 20;
        private const int COLS = 25;
        private const int ROWS = 20;

        // Trạng thái game
        private List<Point> snake = new List<Point>();
        private Point food;
        private Direction currentDir = Direction.Right;
        private Direction nextDir = Direction.Right;
        private bool isGameStarted = false;
        private bool isGameOver = false;
        private bool isPaused = false;
        private int score = 0;
        private Random random = new Random();

        public GameTestForm()
        {
            InitializeComponent();

            // Cố định kích thước pixel chuẩn xác tuyệt đối không bị ảnh hưởng bởi DPI Windows
            this.ClientSize = new Size(COLS * CELL_SIZE + 40, ROWS * CELL_SIZE + 90);
            this.canvas.Size = new Size(COLS * CELL_SIZE, ROWS * CELL_SIZE);
            this.canvas.Location = new Point(20, 55);
            this.topPanel.Size = new Size(COLS * CELL_SIZE, 35);
            this.topPanel.Location = new Point(20, 10);

            // Bật DoubleBuffered cho canvas để tránh giật lag, nhấp nháy
            typeof(PictureBox).InvokeMember("DoubleBuffered",
                System.Reflection.BindingFlags.SetProperty | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic,
                null, this.canvas, new object[] { true });

            // Nếu đang trong Visual Studio Designer thì dừng lại, không kích hoạt logic chạy game
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime || this.DesignMode)
            {
                return;
            }

            InitGame();
        }

        private void InitGame()
        {
            gameTimer.Stop();

            if (pnlGameOverBox != null)
            {
                pnlGameOverBox.Visible = false;
            }

            snake.Clear();
            snake.Add(new Point(5, 10)); // Đầu
            snake.Add(new Point(4, 10)); // Thân
            snake.Add(new Point(3, 10)); // Đuôi

            currentDir = Direction.Right;
            nextDir = Direction.Right;
            score = 0;
            isGameOver = false;
            isPaused = false;
            isGameStarted = false;
            lblScore.Text = "🍎 ĐIỂM: 0";

            SpawnFood();
            UpdateDifficultySelectionUI();

            // Căn giữa hộp chọn độ khó
            pnlStartBox.Location = new Point((this.ClientSize.Width - pnlStartBox.Width) / 2, (this.ClientSize.Height - pnlStartBox.Height) / 2 + 15);
            pnlStartBox.Visible = true;
            pnlStartBox.BringToFront();

            canvas.Invalidate();
        }

        private void StartPlaying()
        {
            SoundManager.PlayButtonClick();
            pnlStartBox.Visible = false;
            isGameStarted = true;
            isPaused = false;
            isGameOver = false;

            int speed = GameConfig.GetSpeed(GameConfig.CurrentDifficulty);
            gameTimer.Interval = speed;
            gameTimer.Start();

            this.ActiveControl = null;
            canvas.Invalidate();
        }

        private void RestartGame()
        {
            InitGame();
            this.ActiveControl = null;
        }

        private void UpdateDifficultySelectionUI()
        {
            Color unselectedBg = Color.FromArgb(35, 35, 55);
            Color unselectedBorder = Color.FromArgb(70, 70, 95);

            btnDoKhoDe.BackColor = unselectedBg;
            btnDoKhoDe.FlatAppearance.BorderColor = unselectedBorder;
            btnDoKhoDe.FlatAppearance.BorderSize = 1;

            btnDoKhoVua.BackColor = unselectedBg;
            btnDoKhoVua.FlatAppearance.BorderColor = unselectedBorder;
            btnDoKhoVua.FlatAppearance.BorderSize = 1;

            btnDoKhoKho.BackColor = unselectedBg;
            btnDoKhoKho.FlatAppearance.BorderColor = unselectedBorder;
            btnDoKhoKho.FlatAppearance.BorderSize = 1;

            switch (GameConfig.CurrentDifficulty)
            {
                case GameDifficulty.Easy:
                    btnDoKhoDe.BackColor = Color.FromArgb(30, 110, 50);
                    btnDoKhoDe.FlatAppearance.BorderColor = Color.FromArgb(70, 235, 70);
                    btnDoKhoDe.FlatAppearance.BorderSize = 2;
                    lblThongTinTocDo.Text = "⚡ Tốc độ 200ms: Rắn chạy chậm rãi, dễ né chướng ngại vật!";
                    lblThongTinTocDo.ForeColor = Color.FromArgb(70, 235, 70);
                    lblDifficulty.Text = "⚡ Độ khó: 🟢 Dễ";
                    lblDifficulty.ForeColor = Color.FromArgb(70, 235, 70);
                    break;
                case GameDifficulty.Hard:
                    btnDoKhoKho.BackColor = Color.FromArgb(130, 35, 35);
                    btnDoKhoKho.FlatAppearance.BorderColor = Color.FromArgb(255, 90, 90);
                    btnDoKhoKho.FlatAppearance.BorderSize = 2;
                    lblThongTinTocDo.Text = "⚡ Tốc độ 70ms: Rắn chạy siêu nhanh, thử thách phản xạ đỉnh cao!";
                    lblThongTinTocDo.ForeColor = Color.FromArgb(255, 90, 90);
                    lblDifficulty.Text = "⚡ Độ khó: 🔴 Khó";
                    lblDifficulty.ForeColor = Color.FromArgb(255, 90, 90);
                    break;
                case GameDifficulty.Medium:
                default:
                    btnDoKhoVua.BackColor = Color.FromArgb(120, 95, 20);
                    btnDoKhoVua.FlatAppearance.BorderColor = Color.FromArgb(255, 215, 0);
                    btnDoKhoVua.FlatAppearance.BorderSize = 2;
                    lblThongTinTocDo.Text = "⚡ Tốc độ 120ms: Rắn chạy vừa phải, cân bằng tốc độ & phản xạ!";
                    lblThongTinTocDo.ForeColor = Color.FromArgb(255, 215, 0);
                    lblDifficulty.Text = "⚡ Độ khó: 🟡 Vừa";
                    lblDifficulty.ForeColor = Color.FromArgb(255, 215, 0);
                    break;
            }
        }

        private void SpawnFood()
        {
            List<Point> emptyCells = new List<Point>();
            for (int x = 0; x < COLS; x++)
            {
                for (int y = 0; y < ROWS; y++)
                {
                    Point p = new Point(x, y);
                    if (!snake.Contains(p))
                    {
                        emptyCells.Add(p);
                    }
                }
            }

            if (emptyCells.Count > 0)
            {
                food = emptyCells[random.Next(emptyCells.Count)];
            }
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            if (isGameOver || isPaused || !isGameStarted) return;

            currentDir = nextDir;
            Point head = snake[0];
            Point newHead = head;

            switch (currentDir)
            {
                case Direction.Up: newHead = new Point(head.X, head.Y - 1); break;
                case Direction.Down: newHead = new Point(head.X, head.Y + 1); break;
                case Direction.Left: newHead = new Point(head.X - 1, head.Y); break;
                case Direction.Right: newHead = new Point(head.X + 1, head.Y); break;
            }

            // Đâm tường
            if (newHead.X < 0 || newHead.X >= COLS || newHead.Y < 0 || newHead.Y >= ROWS)
            {
                TriggerGameOver();
                return;
            }

            // Tự cắn thân
            if (snake.Contains(newHead))
            {
                TriggerGameOver();
                return;
            }

            snake.Insert(0, newHead);

            // Ăn mồi
            if (newHead == food)
            {
                score += 10;
                lblScore.Text = $"🍎 ĐIỂM: {score}";
                SoundManager.PlayEat();
                SpawnFood();
            }
            else
            {
                snake.RemoveAt(snake.Count - 1);
            }

            canvas.Invalidate();
        }

        private void TriggerGameOver()
        {
            isGameOver = true;
            isGameStarted = false;
            gameTimer.Stop();

            SoundManager.PlayDie();

            txtTenNguoiChoi.Text = "Người chơi";
            btnLuuDiem.Enabled = true;
            btnLuuDiem.Text = "💾 Lưu Điểm";
            lblThongBaoLuu.Text = $"Điểm của bạn: {score} ({GameConfig.GetDifficultyDisplayName(GameConfig.CurrentDifficulty)}) - Nhập tên để lưu kỉ lục:";
            lblThongBaoLuu.ForeColor = Color.LightGray;

            pnlGameOverBox.Location = new Point((this.ClientSize.Width - pnlGameOverBox.Width) / 2, (this.ClientSize.Height - pnlGameOverBox.Height) / 2 + 15);
            pnlGameOverBox.Visible = true;
            pnlGameOverBox.BringToFront();
            txtTenNguoiChoi.Focus();
            txtTenNguoiChoi.SelectAll();

            canvas.Invalidate();
        }

        private void LuuDiemVaoBangXepHang(string tenNguoiChoi, int diemSo)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(tenNguoiChoi))
                {
                    tenNguoiChoi = "Người chơi";
                }

                tenNguoiChoi = tenNguoiChoi.Replace("|", "-").Trim();
                string filePath = "scores.txt";
                string dongMoi = $"{tenNguoiChoi}|{diemSo}{Environment.NewLine}";

                File.AppendAllText(filePath, dongMoi);
            }
            catch
            {
            }
        }

        private void btnDoKhoDe_Click(object sender, EventArgs e)
        {
            SoundManager.PlayButtonClick();
            GameConfig.CurrentDifficulty = GameDifficulty.Easy;
            UpdateDifficultySelectionUI();
        }

        private void btnDoKhoVua_Click(object sender, EventArgs e)
        {
            SoundManager.PlayButtonClick();
            GameConfig.CurrentDifficulty = GameDifficulty.Medium;
            UpdateDifficultySelectionUI();
        }

        private void btnDoKhoKho_Click(object sender, EventArgs e)
        {
            SoundManager.PlayButtonClick();
            GameConfig.CurrentDifficulty = GameDifficulty.Hard;
            UpdateDifficultySelectionUI();
        }

        private void btnBatDauStart_Click(object sender, EventArgs e)
        {
            StartPlaying();
        }

        private void btnLuuDiem_Click(object sender, EventArgs e)
        {
            SoundManager.PlayButtonClick();
            LuuDiemVaoBangXepHang(txtTenNguoiChoi.Text, score);
            btnLuuDiem.Enabled = false;
            btnLuuDiem.Text = "✅ Đã Lưu!";
            lblThongBaoLuu.Text = $"Đã lưu: {score} điểm ({GameConfig.GetDifficultyDisplayName(GameConfig.CurrentDifficulty)})!";
            lblThongBaoLuu.ForeColor = Color.FromArgb(50, 220, 50);
        }

        private void btnChoiLai_Click(object sender, EventArgs e)
        {
            SoundManager.PlayButtonClick();
            pnlGameOverBox.Visible = false;
            RestartGame();
        }

        private void btnVeMenu_Click(object sender, EventArgs e)
        {
            SoundManager.PlayButtonClick();
            this.Close();
        }

        private void GameTestForm_KeyDown(object sender, KeyEventArgs e)
        {
            // Khi chưa bấm Start mà đang hiện bảng chọn độ khó
            if (!isGameStarted && pnlStartBox != null && pnlStartBox.Visible)
            {
                if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Space)
                {
                    btnBatDauStart.PerformClick();
                    return;
                }
                else if (e.KeyCode == Keys.D1 || e.KeyCode == Keys.NumPad1)
                {
                    btnDoKhoDe.PerformClick();
                    return;
                }
                else if (e.KeyCode == Keys.D2 || e.KeyCode == Keys.NumPad2)
                {
                    btnDoKhoVua.PerformClick();
                    return;
                }
                else if (e.KeyCode == Keys.D3 || e.KeyCode == Keys.NumPad3)
                {
                    btnDoKhoKho.PerformClick();
                    return;
                }
                else if (e.KeyCode == Keys.Escape)
                {
                    this.Close();
                    return;
                }
            }

            if (isGameOver && pnlGameOverBox != null && pnlGameOverBox.Visible)
            {
                if (e.KeyCode == Keys.Enter && btnLuuDiem.Enabled)
                {
                    btnLuuDiem.PerformClick();
                }
                return;
            }

            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.W)
            {
                if (currentDir != Direction.Down) nextDir = Direction.Up;
            }
            else if (e.KeyCode == Keys.Down || e.KeyCode == Keys.S)
            {
                if (currentDir != Direction.Up) nextDir = Direction.Down;
            }
            else if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
            {
                if (currentDir != Direction.Right) nextDir = Direction.Left;
            }
            else if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
            {
                if (currentDir != Direction.Left) nextDir = Direction.Right;
            }
            else if (e.KeyCode == Keys.P)
            {
                if (!isGameOver && isGameStarted)
                {
                    isPaused = !isPaused;
                    SoundManager.PlayButtonClick();
                    canvas.Invalidate();
                }
            }
            else if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // Xóa nền màu chuẩn cho bàn cờ
            using (SolidBrush bgBrush = new SolidBrush(Color.FromArgb(15, 15, 30)))
            {
                g.FillRectangle(bgBrush, 0, 0, canvas.Width, canvas.Height);
            }

            // Lưới bàn cờ
            using (Pen gridPen = new Pen(Color.FromArgb(25, 25, 45)))
            {
                for (int x = 0; x <= COLS; x++)
                    g.DrawLine(gridPen, x * CELL_SIZE, 0, x * CELL_SIZE, ROWS * CELL_SIZE);
                for (int y = 0; y <= ROWS; y++)
                    g.DrawLine(gridPen, 0, y * CELL_SIZE, COLS * CELL_SIZE, y * CELL_SIZE);
            }

            // Đường viền bao quanh bàn cờ
            using (Pen borderPen = new Pen(Color.FromArgb(50, 50, 80), 1))
            {
                g.DrawRectangle(borderPen, 0, 0, COLS * CELL_SIZE - 1, ROWS * CELL_SIZE - 1);
            }

            // Dữ liệu mẫu khi ở chế độ Visual Studio Designer để giáo viên thấy trực quan ô ma trận có con rắn
            List<Point> renderSnake = snake;
            Point renderFood = food;

            bool isDesignMode = (LicenseManager.UsageMode == LicenseUsageMode.Designtime) || this.DesignMode;
            if (isDesignMode || renderSnake == null || renderSnake.Count == 0)
            {
                renderSnake = new List<Point>
                {
                    new Point(8, 10), // Đầu rắn
                    new Point(7, 10), // Thân
                    new Point(6, 10), // Thân
                    new Point(5, 10)  // Đuôi
                };
                renderFood = new Point(15, 10);
            }

            // Mồi quả táo đỏ
            using (Brush foodBrush = new SolidBrush(Color.FromArgb(255, 75, 75)))
            {
                g.FillEllipse(foodBrush, renderFood.X * CELL_SIZE + 2, renderFood.Y * CELL_SIZE + 2, CELL_SIZE - 4, CELL_SIZE - 4);
            }

            // Vẽ rắn
            for (int i = 0; i < renderSnake.Count; i++)
            {
                Point part = renderSnake[i];
                Rectangle rect = new Rectangle(part.X * CELL_SIZE + 1, part.Y * CELL_SIZE + 1, CELL_SIZE - 2, CELL_SIZE - 2);

                if (i == 0)
                {
                    using (Brush headBrush = new SolidBrush(Color.FromArgb(70, 235, 70)))
                    {
                        g.FillRectangle(headBrush, rect);
                    }
                }
                else
                {
                    using (Brush bodyBrush = new SolidBrush(Color.FromArgb(34, 160, 34)))
                    {
                        g.FillRectangle(bodyBrush, rect);
                    }
                }
            }

            // Màn hình TẠM DỪNG (PAUSED)
            if (isPaused && !isDesignMode)
            {
                using (Brush darkOverlay = new SolidBrush(Color.FromArgb(170, 0, 0, 0)))
                {
                    g.FillRectangle(darkOverlay, 0, 0, canvas.Width, canvas.Height);
                }

                using (Font fontPause = new Font("Segoe UI", 24, FontStyle.Bold))
                using (Brush brushYellow = new SolidBrush(Color.FromArgb(255, 215, 0)))
                {
                    string text = "⏸️ ĐANG TẠM DỪNG";
                    SizeF size = g.MeasureString(text, fontPause);
                    g.DrawString(text, fontPause, brushYellow, (canvas.Width - size.Width) / 2, canvas.Height / 2 - 40);
                }

                using (Font fontSub = new Font("Segoe UI", 12, FontStyle.Regular))
                using (Brush brushWhite = new SolidBrush(Color.White))
                {
                    string text = "Nhấn phím [P] để tiếp tục chơi";
                    SizeF size = g.MeasureString(text, fontSub);
                    g.DrawString(text, fontSub, brushWhite, (canvas.Width - size.Width) / 2, canvas.Height / 2 + 10);
                }
            }
        }

        private void GameTestForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            gameTimer?.Stop();
        }
    }
}