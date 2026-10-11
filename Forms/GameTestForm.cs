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
        private Button btnBack;
        private Button btnRestart;

        // Khung Game Over
        private Panel pnlGameOverBox;
        private TextBox txtTenNguoiChoi;
        private Button btnLuuDiem;
        private Label lblThongBaoLuu;

        public GameTestForm()
        {
            Text = "Snake Game - Thử nghiệm";
            ClientSize = new Size(
                COLS * CELL_SIZE + 40,
                ROWS * CELL_SIZE + 100);

            BackColor = GameConfig.BgColor;
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            KeyPreview = true;

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
            // Thanh công cụ phía trên
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
                Text = "Chơi Lại",
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.FromArgb(40, 120, 200),
                FlatStyle = FlatStyle.Flat,
                Size = new Size(90, 28),
                Location = new Point(COLS * CELL_SIZE - 200, 6),
                Cursor = Cursors.Hand
            };

            btnRestart.FlatAppearance.BorderSize = 0;
            btnRestart.Click += (s, e) =>
            {
                SoundManager.PlayButtonClick();
                RestartGame();
            };

            btnBack = new Button
            {
                Text = "Menu",
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.FromArgb(180, 40, 40),
                FlatStyle = FlatStyle.Flat,
                Size = new Size(80, 28),
                Location = new Point(COLS * CELL_SIZE - 95, 6),
                Cursor = Cursors.Hand
            };

            btnBack.FlatAppearance.BorderSize = 0;
            btnBack.Click += (s, e) =>
            {
                SoundManager.PlayButtonClick();
                Close();
            };

            topPanel.Controls.Add(lblScore);
            topPanel.Controls.Add(lblGuide);
            topPanel.Controls.Add(btnRestart);
            topPanel.Controls.Add(btnBack);
            Controls.Add(topPanel);

            // Bàn cờ
            canvas = new GameCanvas
            {
                Location = new Point(20, 60),
                Size = new Size(
                    COLS * CELL_SIZE,
                    ROWS * CELL_SIZE),
                BackColor = Color.FromArgb(15, 15, 30)
            };

            canvas.Paint += Canvas_Paint;
            Controls.Add(canvas);

            // Khung Game Over
            pnlGameOverBox = new Panel
            {
                Size = new Size(360, 210),
                BackColor = Color.FromArgb(30, 30, 55),
                BorderStyle = BorderStyle.FixedSingle,
                Visible = false
            };

            pnlGameOverBox.Location = new Point(
                (ClientSize.Width - 360) / 2,
                (ClientSize.Height - 210) / 2);

            Label lblTieuDeOver = new Label
            {
                Text = "GAME OVER",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = Color.FromArgb(255, 70, 70),
                TextAlign = ContentAlignment.MiddleCenter,
                Size = new Size(360, 35),
                Location = new Point(0, 10)
            };

            lblThongBaoLuu = new Label
            {
                Text = "Nhập tên của bạn để lưu kỷ lục:",
                Font = new Font("Segoe UI", 10),
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
                Text = "Lưu Điểm",
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.FromArgb(40, 160, 60),
                FlatStyle = FlatStyle.Flat,
                Size = new Size(130, 38),
                Location = new Point(45, 135),
                Cursor = Cursors.Hand
            };

            btnLuuDiem.FlatAppearance.BorderSize = 0;
            btnLuuDiem.Click += BtnLuuDiem_Click;

            Button btnChoiLaiNhanh = new Button
            {
                Text = "Chơi Lại",
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
                RestartGame();
            };

            pnlGameOverBox.Controls.Add(lblTieuDeOver);
            pnlGameOverBox.Controls.Add(lblThongBaoLuu);
            pnlGameOverBox.Controls.Add(txtTenNguoiChoi);
            pnlGameOverBox.Controls.Add(btnLuuDiem);
            pnlGameOverBox.Controls.Add(btnChoiLaiNhanh);

            Controls.Add(pnlGameOverBox);
            pnlGameOverBox.BringToFront();

            // Timer
            gameTimer = new Timer
            {
                Interval = 120
            };

            gameTimer.Tick += GameTimer_Tick;
        }

        // Khởi tạo lại trạng thái giao diện.
        private void InitGame()
        {
            isPaused = false;
            gameOverShown = false;
            nextDir = Direction.Right;

            pnlGameOverBox.Visible = false;

            lblScore.Text = "🍎 Điểm: 0";
            lblGuide.Text = "[P]: Tạm dừng | [Space]: Chơi lại";

            btnLuuDiem.Enabled = true;
            btnLuuDiem.Text = "Lưu Điểm";

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
                return;
            }

            // Gửi hướng mới cho lớp Game/Snake.
            game.ChangeDirection(nextDir);

            // Game tự xử lý di chuyển, điểm số và va chạm.
            game.Update();

            lblScore.Text = $"🍎 Điểm: {game.Score}";

            canvas.Invalidate();

            if (game.IsGameOver)
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

            txtTenNguoiChoi.Text = "Người chơi";
            btnLuuDiem.Enabled = true;
            btnLuuDiem.Text = "Lưu Điểm";

            lblThongBaoLuu.Text =
                $"Điểm: {game.Score} - Nhập tên để lưu:";

            lblThongBaoLuu.ForeColor = Color.White;

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
            if (game == null)
            {
                return;
            }

            // Khi khung Game Over đang mở.
            if (gameOverShown && pnlGameOverBox.Visible)
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

                    lblGuide.Text = isPaused
                        ? "ĐANG TẠM DỪNG - Nhấn P để tiếp tục"
                        : "[P]: Tạm dừng | [Space]: Chơi lại";

                    canvas.Invalidate();
                }
            }
            else if (e.KeyCode == Keys.Space)
            {
                if (gameOverShown)
                {
                    RestartGame();
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

            // Vẽ lưới.
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

            if (game == null || game.Snake == null || game.Food == null)
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

            // Vẽ rắn.
            for (int i = 0; i < game.Snake.Body.Count; i++)
            {
                Point part = game.Snake.Body[i];

                Rectangle rect = new Rectangle(
                    part.X * CELL_SIZE + 1,
                    part.Y * CELL_SIZE + 1,
                    CELL_SIZE - 2,
                    CELL_SIZE - 2);

                Color color = i == 0
                    ? Color.FromArgb(70, 235, 70)
                    : Color.FromArgb(34, 160, 34);

                using (Brush brush = new SolidBrush(color))
                {
                    g.FillRectangle(brush, rect);
                }
            }

            // Hiển thị lớp phủ khi tạm dừng.
            if (isPaused)
            {
                using (Brush overlay =
                    new SolidBrush(Color.FromArgb(150, 0, 0, 0)))
                {
                    g.FillRectangle(
                        overlay,
                        0,
                        0,
                        canvas.Width,
                        canvas.Height);
                }

                using (Font font =
                    new Font("Segoe UI", 22, FontStyle.Bold))
                using (Brush brush = new SolidBrush(Color.Yellow))
                {
                    string text = "TẠM DỪNG";

                    SizeF size = g.MeasureString(text, font);

                    g.DrawString(
                        text,
                        font,
                        brush,
                        (canvas.Width - size.Width) / 2,
                        (canvas.Height - size.Height) / 2);
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

        // Panel hỗ trợ vẽ mượt, hạn chế nhấp nháy.
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
