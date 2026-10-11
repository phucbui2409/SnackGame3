using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;
using SnackGame3.Models;
using SnackGame3.Utils;

namespace SnackGame3.Test
{
    public class GameTestForm : Form
    {
        // Cấu hình bàn cờ
        private const int CELL_SIZE = 20;
        private const int COLS = 25;
        private const int ROWS = 20;

        // Đối tượng quản lý luật chơi
        private Game game;

        // Trạng thái giao diện
        private bool isPaused = false;
        private bool gameOverShown = false;

        // Hướng dự kiến cho lần di chuyển tiếp theo
        private Direction nextDir = Direction.Right;

        // Điều khiển giao diện
        private Timer gameTimer;
        private GameCanvas canvas;
        private Label lblScore;
        private Label lblGuide;

        // Bảng In-game nhập tên & điều hướng khi Game Over
        private Panel pnlGameOverBox;
        private TextBox txtTenNguoiChoi;
        private Button btnLuuDiem;
        private Label lblThongBaoLuu;
        private Button btnChoiLai;
        private Button btnVeMenu;

        public GameTestForm()
        {
            this.Text = "Snack Game - Màn Chơi";
            this.ClientSize = new Size(COLS * CELL_SIZE + 40, ROWS * CELL_SIZE + 90);
            this.BackColor = GameConfig.BgColor;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.KeyPreview = true;

            InitUI();

            // Game nhận kích thước bàn cờ theo pixel.
            game = new Game(
                COLS * CELL_SIZE,
                ROWS * CELL_SIZE,
                CELL_SIZE);

            InitGame();

            KeyDown += GameTestForm_KeyDown;
        }

        private void InitUI()
        {
            // Panel thanh trên cùng: Thiết kế gọn gàng, thanh thoát
            Panel topPanel = new Panel
            {
                Location = new Point(20, 10),
                Size = new Size(COLS * CELL_SIZE, 35),
                BackColor = Color.FromArgb(25, 25, 45)
            };

            lblScore = new Label
            {
                Text = "🍎 ĐIỂM: 0",
                Font = new Font("Segoe UI", 13, FontStyle.Bold),
                ForeColor = Color.FromArgb(50, 220, 50),
                Location = new Point(12, 6),
                AutoSize = true
            };

            lblGuide = new Label
            {
                Text = "⏸️ [P]: Tạm dừng  |  🎮 [W,A,S,D] / [Mũi tên]: Di chuyển",
                Font = new Font("Segoe UI", 10, FontStyle.Regular),
                ForeColor = Color.FromArgb(170, 170, 200),
                Location = new Point(160, 8),
                AutoSize = true
            };

            topPanel.Controls.Add(lblScore);
            topPanel.Controls.Add(lblGuide);
            this.Controls.Add(topPanel);

            // Bàn cờ
            canvas = new GameCanvas
            {
                Location = new Point(20, 55),
                Size = new Size(COLS * CELL_SIZE, ROWS * CELL_SIZE),
                BackColor = Color.FromArgb(15, 15, 30)
            };

            canvas.Paint += Canvas_Paint;
            Controls.Add(canvas);

            // ==================== BẢNG POPUP GAME OVER ====================
            pnlGameOverBox = new Panel
            {
                Size = new Size(380, 260),
                BackColor = Color.FromArgb(28, 28, 50),
                BorderStyle = BorderStyle.FixedSingle,
                Visible = false
            };
            // Căn giữa màn hình game
            pnlGameOverBox.Location = new Point((this.ClientSize.Width - 380) / 2, (this.ClientSize.Height - 260) / 2 + 15);

            Label lblTieuDeOver = new Label
            {
                Text = "💀 GAME OVER 💀",
                Font = new Font("Segoe UI", 18, FontStyle.Bold),
                ForeColor = Color.FromArgb(255, 75, 75),
                TextAlign = ContentAlignment.MiddleCenter,
                Size = new Size(380, 38),
                Location = new Point(0, 12)
            };

            lblThongBaoLuu = new Label
            {
                Text = "Nhập tên của bạn để lưu kỷ lục:",
                Font = new Font("Segoe UI", 11, FontStyle.Regular),
                ForeColor = Color.LightGray,
                TextAlign = ContentAlignment.MiddleCenter,
                Size = new Size(380, 25),
                Location = new Point(0, 55)
            };

            txtTenNguoiChoi = new TextBox
            {
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Size = new Size(240, 32),
                Location = new Point(70, 85),
                TextAlign = HorizontalAlignment.Center,
                MaxLength = 20
            };

            btnLuuDiem = new Button
            {
                Text = "💾 Lưu Điểm",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.FromArgb(35, 150, 60),
                FlatStyle = FlatStyle.Flat,
                Size = new Size(130, 36),
                Location = new Point(125, 125),
                Cursor = Cursors.Hand
            };

            btnLuuDiem.FlatAppearance.BorderSize = 0;
            btnLuuDiem.Click += (s, e) =>
            {
                SoundManager.PlayButtonClick();
                LuuDiemVaoBangXepHang(txtTenNguoiChoi.Text, score);
                btnLuuDiem.Enabled = false;
                btnLuuDiem.Text = "✅ Đã Lưu!";
                lblThongBaoLuu.Text = $"Đã lưu thành tích: {score} điểm!";
                lblThongBaoLuu.ForeColor = Color.FromArgb(50, 220, 50);
            };

            // Nút Chơi Lại sau khi chết
            btnChoiLai = new Button
            {
                Text = "Chơi Lại",
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.FromArgb(40, 110, 200),
                FlatStyle = FlatStyle.Flat,
                Size = new Size(140, 42),
                Location = new Point(35, 190),
                Cursor = Cursors.Hand
            };
            btnChoiLai.FlatAppearance.BorderSize = 0;
            btnChoiLai.Click += (s, e) =>
            {
                SoundManager.PlayButtonClick();
                RestartGame();
            };

            // Nút Về Menu sau khi chết
            btnVeMenu = new Button
            {
                Text = "🔙 Về Menu",
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.FromArgb(180, 45, 45),
                FlatStyle = FlatStyle.Flat,
                Size = new Size(140, 42),
                Location = new Point(205, 190),
                Cursor = Cursors.Hand
            };
            btnVeMenu.FlatAppearance.BorderSize = 0;
            btnVeMenu.Click += (s, e) =>
            {
                SoundManager.PlayButtonClick();
                this.Close(); // Đóng form về menu và bật lại nhạc
            };

            pnlGameOverBox.Controls.Add(lblTieuDeOver);
            pnlGameOverBox.Controls.Add(lblThongBaoLuu);
            pnlGameOverBox.Controls.Add(txtTenNguoiChoi);
            pnlGameOverBox.Controls.Add(btnLuuDiem);
            pnlGameOverBox.Controls.Add(btnChoiLai);
            pnlGameOverBox.Controls.Add(btnVeMenu);

            Controls.Add(pnlGameOverBox);
            pnlGameOverBox.BringToFront();

            // Timer game loop
            gameTimer = new System.Windows.Forms.Timer();
            gameTimer.Interval = 120;
            gameTimer.Tick += GameTimer_Tick;

            gameTimer.Tick += GameTimer_Tick;
        }

        // Khởi tạo lại trạng thái giao diện.
        private void InitGame()
        {
            isPaused = false;
            gameOverShown = false;
            nextDir = Direction.Right;

            pnlGameOverBox.Visible = false;

            currentDir = Direction.Right;
            nextDir = Direction.Right;
            score = 0;
            isGameOver = false;
            isPaused = false;
            lblScore.Text = "🍎 ĐIỂM: 0";

            canvas.Invalidate();
            gameTimer.Start();
        }

        private void RestartGame()
        {
            // Dùng lại đối tượng Game, không tự tạo luật chơi riêng.
            game.Start();

            InitGame();
            ActiveControl = null;
        }

        // Cập nhật game theo Timer.
        private void GameTimer_Tick(object sender, EventArgs e)
        {
            if (isPaused || game == null || game.IsGameOver)
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
                TriggerGameOver();
            }
        }

        // Xử lý khi game kết thúc.
        private void TriggerGameOver()
        {
            if (gameOverShown)
            {
                return;
            }

            gameOverShown = true;
            gameTimer.Stop();

            SoundManager.PlayDie();

            // Hiển thị khung Game Over đẹp mắt với nút Chơi Lại và Về Menu
            txtTenNguoiChoi.Text = "Người chơi";
            btnLuuDiem.Enabled = true;
            btnLuuDiem.Text = "💾 Lưu Điểm";
            lblThongBaoLuu.Text = $"Điểm của bạn: {score} - Nhập tên để lưu kỉ lục:";
            lblThongBaoLuu.ForeColor = Color.LightGray;

            pnlGameOverBox.Visible = true;
            pnlGameOverBox.BringToFront();

            txtTenNguoiChoi.Focus();
            txtTenNguoiChoi.SelectAll();

            canvas.Invalidate();
        }

        // Lưu điểm và chỉ thông báo thành công khi ghi file thành công.
        private void BtnLuuDiem_Click(object sender, EventArgs e)
        {
            SoundManager.PlayButtonClick();

            string ten = txtTenNguoiChoi.Text.Trim();

            if (string.IsNullOrWhiteSpace(ten))
            {
                ten = "Người chơi";
            }

            // Tránh ký tự phân cách làm sai định dạng file.
            ten = ten.Replace("|", "-")
                     .Replace("\r", "")
                     .Replace("\n", "");

            try
            {
                string filePath = Path.Combine(
                    Application.StartupPath,
                    "scores.txt");

                string dongMoi =
                    $"{ten}|{game.Score}{Environment.NewLine}";

                File.AppendAllText(filePath, dongMoi);

                btnLuuDiem.Enabled = false;
                btnLuuDiem.Text = "Đã Lưu";

                lblThongBaoLuu.Text =
                    $"Đã lưu thành công: {game.Score} điểm!";

                lblThongBaoLuu.ForeColor =
                    Color.FromArgb(50, 205, 50);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể lưu điểm.\nChi tiết: " + ex.Message,
                    "Lỗi lưu điểm",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // Xử lý bàn phím.
        private void GameTestForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (isGameOver && pnlGameOverBox.Visible)
            {
                if (e.KeyCode == Keys.Enter && btnLuuDiem.Enabled)
                {
                    btnLuuDiem.PerformClick();
                }

                return;
            }

            Direction currentDir = game.Snake.CurrentDirection;

            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.W)
            {
                if (nextDir != Direction.Down &&
                    currentDir != Direction.Down)
                {
                    nextDir = Direction.Up;
                }
            }
            else if (e.KeyCode == Keys.Down || e.KeyCode == Keys.S)
            {
                if (nextDir != Direction.Up &&
                    currentDir != Direction.Up)
                {
                    nextDir = Direction.Down;
                }
            }
            else if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
            {
                if (nextDir != Direction.Right &&
                    currentDir != Direction.Right)
                {
                    nextDir = Direction.Left;
                }
            }
            else if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
            {
                if (nextDir != Direction.Left &&
                    currentDir != Direction.Left)
                {
                    nextDir = Direction.Right;
                }
            }
            else if (e.KeyCode == Keys.P)
            {
                if (!game.IsGameOver)
                {
                    isPaused = !isPaused;
                    SoundManager.PlayButtonClick();
                    canvas.Invalidate();
                }
            }
            else if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        // Vẽ bàn cờ và các đối tượng do Game quản lý.
        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            // Lưới bàn cờ
            using (Pen gridPen = new Pen(Color.FromArgb(25, 25, 45)))
            {
                for (int x = 0; x <= COLS; x++)
                {
                    g.DrawLine(
                        gridPen,
                        x * CELL_SIZE,
                        0,
                        x * CELL_SIZE,
                        ROWS * CELL_SIZE);
                }

                for (int y = 0; y <= ROWS; y++)
                {
                    g.DrawLine(
                        gridPen,
                        0,
                        y * CELL_SIZE,
                        COLS * CELL_SIZE,
                        y * CELL_SIZE);
                }
            }

            // Mồi quả táo đỏ
            using (Brush foodBrush = new SolidBrush(Color.FromArgb(255, 75, 75)))
            {
                return;
            }

            // Vẽ thức ăn.
            Point foodPosition = game.Food.Position;

            using (Brush foodBrush =
                new SolidBrush(Color.FromArgb(255, 75, 75)))
            {
                g.FillEllipse(
                    foodBrush,
                    foodPosition.X * CELL_SIZE + 2,
                    foodPosition.Y * CELL_SIZE + 2,
                    CELL_SIZE - 4,
                    CELL_SIZE - 4);
            }

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

            // Màn hình TẠM DỪNG (PAUSED) thiết kế bóng bẩy
            if (isPaused)
            {
                using (Brush darkOverlay = new SolidBrush(Color.FromArgb(170, 0, 0, 0)))
                {
                    g.FillRectangle(
                        overlay,
                        0,
                        0,
                        canvas.Width,
                        canvas.Height);
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

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            if (gameTimer != null)
            {
                gameTimer.Stop();
                gameTimer.Dispose();
            }

            base.OnFormClosed(e);
        }

        private class GameCanvas : Panel
        {
            public GameCanvas()
            {
                DoubleBuffered = true;

                SetStyle(
                    ControlStyles.OptimizedDoubleBuffer |
                    ControlStyles.AllPaintingInWmPaint |
                    ControlStyles.UserPaint,
                    true);
            }
        }
    }
}
