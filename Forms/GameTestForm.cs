using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using SnackGame3.Utils;

namespace SnackGame3.Test
{
    /// <summary>
    /// Form game rắn thử nghiệm độc lập trong thư mục Test.
    /// Dùng để test âm thanh ăn mồi (eatsnake), thua cuộc (eatdie), nhập tên & lưu điểm số.
    /// </summary>
    public class GameTestForm : Form
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
        private bool isGameOver = false;
        private bool isPaused = false;
        private int score = 0;
        private Random random = new Random();

        // Điều khiển giao diện
        private System.Windows.Forms.Timer gameTimer;
        private GameCanvas canvas;
        private Label lblScore;
        private Label lblGuide;
        private Button btnBack;
        private Button btnRestart;

        // Bảng In-game nhập tên khi Game Over
        private Panel pnlGameOverBox;
        private TextBox txtTenNguoiChoi;
        private Button btnLuuDiem;
        private Label lblThongBaoLuu;

        public GameTestForm()
        {
            this.Text = "Màn hình Game Thử Nghiệm (Test Âm Thanh & Lưu Điểm)";
            this.ClientSize = new Size(COLS * CELL_SIZE + 40, ROWS * CELL_SIZE + 100);
            this.BackColor = GameConfig.BgColor;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.KeyPreview = true;

            InitUI();
            InitGame();
        }

        private void InitUI()
        {
            // Panel chứa thông tin điểm & nút chức năng
            Panel topPanel = new Panel
            {
                Location = new Point(20, 10),
                Size = new Size(COLS * CELL_SIZE, 40),
                BackColor = Color.FromArgb(30, 30, 50)
            };

            lblScore = new Label
            {
                Text = "🍎 Điểm: 0",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                ForeColor = Color.FromArgb(50, 205, 50),
                Location = new Point(10, 8),
                AutoSize = true
            };

            lblGuide = new Label
            {
                Text = "[P]: Tạm dừng | [Space]: Chơi lại",
                Font = new Font("Segoe UI", 9, FontStyle.Italic),
                ForeColor = Color.LightGray,
                Location = new Point(130, 11),
                AutoSize = true
            };

            btnRestart = new Button
            {
                Text = "🔄 Chơi Lại",
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.FromArgb(40, 120, 200),
                FlatStyle = FlatStyle.Flat,
                Size = new Size(90, 28),
                Location = new Point(COLS * CELL_SIZE - 200, 6),
                Cursor = Cursors.Hand
            };
            btnRestart.FlatAppearance.BorderSize = 0;
            btnRestart.Click += (s, e) => { SoundManager.PlayButtonClick(); RestartGame(); };

            btnBack = new Button
            {
                Text = "🔙 Menu",
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.FromArgb(180, 40, 40),
                FlatStyle = FlatStyle.Flat,
                Size = new Size(80, 28),
                Location = new Point(COLS * CELL_SIZE - 95, 6),
                Cursor = Cursors.Hand
            };
            btnBack.FlatAppearance.BorderSize = 0;
            btnBack.Click += (s, e) => { SoundManager.PlayButtonClick(); this.Close(); };

            topPanel.Controls.Add(lblScore);
            topPanel.Controls.Add(lblGuide);
            topPanel.Controls.Add(btnRestart);
            topPanel.Controls.Add(btnBack);
            this.Controls.Add(topPanel);

            // Bàn cờ vẽ game
            canvas = new GameCanvas
            {
                Location = new Point(20, 60),
                Size = new Size(COLS * CELL_SIZE, ROWS * CELL_SIZE),
                BackColor = Color.FromArgb(15, 15, 30)
            };
            canvas.Paint += Canvas_Paint;
            this.Controls.Add(canvas);

            // Bảng In-game nhập tên khi Game Over
            pnlGameOverBox = new Panel
            {
                Size = new Size(360, 210),
                BackColor = Color.FromArgb(30, 30, 55),
                BorderStyle = BorderStyle.FixedSingle,
                Visible = false
            };
            pnlGameOverBox.Location = new Point((this.ClientSize.Width - 360) / 2, (this.ClientSize.Height - 210) / 2);

            Label lblTieuDeOver = new Label
            {
                Text = "💀 GAME OVER 💀",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = Color.FromArgb(255, 70, 70),
                TextAlign = ContentAlignment.MiddleCenter,
                Size = new Size(360, 35),
                Location = new Point(0, 10)
            };

            lblThongBaoLuu = new Label
            {
                Text = "Nhập tên của bạn để lưu kỷ lục:",
                Font = new Font("Segoe UI", 11, FontStyle.Regular),
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleCenter,
                Size = new Size(360, 25),
                Location = new Point(0, 50)
            };

            txtTenNguoiChoi = new TextBox
            {
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Size = new Size(240, 30),
                Location = new Point(60, 85),
                TextAlign = HorizontalAlignment.Center,
                MaxLength = 20
            };

            btnLuuDiem = new Button
            {
                Text = "💾 Lưu Điểm",
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.FromArgb(40, 160, 60),
                FlatStyle = FlatStyle.Flat,
                Size = new Size(130, 38),
                Location = new Point(45, 135),
                Cursor = Cursors.Hand
            };
            btnLuuDiem.FlatAppearance.BorderSize = 0;
            btnLuuDiem.Click += (s, e) =>
            {
                SoundManager.PlayButtonClick();
                LuuDiemVaoBangXepHang(txtTenNguoiChoi.Text, score);
                btnLuuDiem.Enabled = false;
                btnLuuDiem.Text = "✅ Đã Lưu!";
                lblThongBaoLuu.Text = $"Đã lưu kỷ lục: {score} điểm!";
                lblThongBaoLuu.ForeColor = Color.FromArgb(50, 205, 50);
            };

            Button btnChoiLaiNhanh = new Button
            {
                Text = "🔄 Chơi Lại",
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.FromArgb(50, 120, 200),
                FlatStyle = FlatStyle.Flat,
                Size = new Size(130, 38),
                Location = new Point(185, 135),
                Cursor = Cursors.Hand
            };
            btnChoiLaiNhanh.FlatAppearance.BorderSize = 0;
            btnChoiLaiNhanh.Click += (s, e) =>
            {
                SoundManager.PlayButtonClick();
                pnlGameOverBox.Visible = false;
                RestartGame();
            };

            pnlGameOverBox.Controls.Add(lblTieuDeOver);
            pnlGameOverBox.Controls.Add(lblThongBaoLuu);
            pnlGameOverBox.Controls.Add(txtTenNguoiChoi);
            pnlGameOverBox.Controls.Add(btnLuuDiem);
            pnlGameOverBox.Controls.Add(btnChoiLaiNhanh);

            this.Controls.Add(pnlGameOverBox);
            pnlGameOverBox.BringToFront();

            // Timer điều khiển vòng lặp game
            gameTimer = new System.Windows.Forms.Timer();
            gameTimer.Interval = 120; // Tốc độ di chuyển
            gameTimer.Tick += GameTimer_Tick;

            this.KeyDown += GameTestForm_KeyDown;
        }

        private void InitGame()
        {
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
            lblScore.Text = "🍎 Điểm: 0";

            SpawnFood();
            gameTimer.Start();
            canvas.Invalidate();
        }

        private void RestartGame()
        {
            InitGame();
            this.ActiveControl = null;
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
            if (isGameOver || isPaused) return;

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

            // Kiểm tra đâm tường
            if (newHead.X < 0 || newHead.X >= COLS || newHead.Y < 0 || newHead.Y >= ROWS)
            {
                TriggerGameOver();
                return;
            }

            // Kiểm tra tự cắn đuôi
            if (snake.Contains(newHead))
            {
                TriggerGameOver();
                return;
            }

            // Di chuyển đầu rắn
            snake.Insert(0, newHead);

            // Kiểm tra ăn mồi
            if (newHead == food)
            {
                score += 10;
                lblScore.Text = $"🍎 Điểm: {score}";

                // PHÁT ÂM THANH ĂN MỒI
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
            gameTimer.Stop();

            // PHÁT ÂM THANH CHẾT
            SoundManager.PlayDie();

            // Hiện khung nhập tên lưu điểm
            txtTenNguoiChoi.Text = "Người chơi";
            btnLuuDiem.Enabled = true;
            btnLuuDiem.Text = "💾 Lưu Điểm";
            lblThongBaoLuu.Text = $"Điểm: {score} - Nhập tên để lưu kỷ lục:";
            lblThongBaoLuu.ForeColor = Color.White;
            pnlGameOverBox.Visible = true;
            pnlGameOverBox.BringToFront();
            txtTenNguoiChoi.Focus();
            txtTenNguoiChoi.SelectAll();

            canvas.Invalidate();
        }

        private void GameTestForm_KeyDown(object sender, KeyEventArgs e)
        {
            // Nếu đang mở khung nhập tên thì không nhận phím di chuyển
            if (isGameOver && pnlGameOverBox.Visible)
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
                if (!isGameOver)
                {
                    isPaused = !isPaused;
                    canvas.Invalidate();
                }
            }
            else if (e.KeyCode == Keys.Space)
            {
                if (isGameOver) RestartGame();
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

            // Vẽ lưới mờ
            using (Pen gridPen = new Pen(Color.FromArgb(25, 25, 45)))
            {
                for (int x = 0; x <= COLS; x++)
                    g.DrawLine(gridPen, x * CELL_SIZE, 0, x * CELL_SIZE, ROWS * CELL_SIZE);
                for (int y = 0; y <= ROWS; y++)
                    g.DrawLine(gridPen, 0, y * CELL_SIZE, COLS * CELL_SIZE, y * CELL_SIZE);
            }

            // Vẽ mồi đỏ
            using (Brush foodBrush = new SolidBrush(Color.FromArgb(255, 75, 75)))
            {
                g.FillEllipse(foodBrush, food.X * CELL_SIZE + 2, food.Y * CELL_SIZE + 2, CELL_SIZE - 4, CELL_SIZE - 4);
            }

            // Vẽ rắn
            for (int i = 0; i < snake.Count; i++)
            {
                Point part = snake[i];
                Rectangle rect = new Rectangle(part.X * CELL_SIZE + 1, part.Y * CELL_SIZE + 1, CELL_SIZE - 2, CELL_SIZE - 2);

                if (i == 0)
                {
                    // Đầu rắn: Xanh lá sáng
                    using (Brush headBrush = new SolidBrush(Color.FromArgb(70, 235, 70)))
                    {
                        g.FillRectangle(headBrush, rect);
                    }
                }
                else
                {
                    // Thân rắn: Xanh lá đậm hơn
                    using (Brush bodyBrush = new SolidBrush(Color.FromArgb(34, 160, 34)))
                    {
                        g.FillRectangle(bodyBrush, rect);
                    }
                }
            }

            if (isPaused)
            {
                using (Brush darkOverlay = new SolidBrush(Color.FromArgb(150, 0, 0, 0)))
                {
                    g.FillRectangle(darkOverlay, 0, 0, canvas.Width, canvas.Height);
                }

                using (Font fontPause = new Font("Segoe UI", 22, FontStyle.Bold))
                using (Brush brushYellow = new SolidBrush(Color.Yellow))
                {
                    string text = "TẠM DỪNG (PAUSED)";
                    SizeF size = g.MeasureString(text, fontPause);
                    g.DrawString(text, fontPause, brushYellow, (canvas.Width - size.Width) / 2, canvas.Height / 2 - 20);
                }
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            gameTimer?.Stop();
            gameTimer?.Dispose();
            base.OnFormClosed(e);
        }

        // Panel vẽ mượt mà, chống chớp nháy (DoubleBuffered)
        private class GameCanvas : Panel
        {
            public GameCanvas()
            {
                this.DoubleBuffered = true;
                this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            }
        }
    }
}