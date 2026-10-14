using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using SnackGame3.Utils;

namespace SnackGame3.Forms
{
    public partial class LeaderboardForm : Form
    {
        class NguoiChoi 
        {
            public string Ten { get; set; } = string.Empty;
            public int Diem { get; set; }
        }

        private const string filePath = "scores.txt";

        // Popup xác nhận xóa (khởi tạo bằng code để không che khuất bảng xếp hạng trên Visual Studio Designer)
        private Panel pnlConfirmOverlay;
        private Panel pnlConfirmBox;
        private Label lblConfirmTitle;
        private Label lblConfirmMessage;
        private Button btnDongYXoa;
        private Button btnHuyXoa;

        public LeaderboardForm()
        {
            try
            {
                InitializeComponent();
                this.BackColor = GameConfig.BgColor;
                InitConfirmPopup();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[Lỗi khởi tạo LeaderboardForm]: {ex.Message}");
            }
        }

        private void InitConfirmPopup()
        {
            try
            {
                pnlConfirmOverlay = new Panel
                {
                    BackColor = Color.FromArgb(210, 10, 10, 25),
                    Dock = DockStyle.Fill,
                    Location = new Point(0, 0),
                    Size = new Size(this.ClientSize.Width, this.ClientSize.Height),
                    Visible = false
                };

                pnlConfirmBox = new Panel
                {
                    BackColor = Color.FromArgb(30, 30, 55),
                    BorderStyle = BorderStyle.FixedSingle,
                    Size = new Size(400, 230),
                    Location = new Point((this.ClientSize.Width - 400) / 2, (this.ClientSize.Height - 230) / 2)
                };

                lblConfirmTitle = new Label
                {
                    Font = new Font("Segoe UI", 16F, FontStyle.Bold),
                    ForeColor = Color.FromArgb(255, 80, 80),
                    Location = new Point(0, 15),
                    Size = new Size(400, 35),
                    Text = "⚠️ XÁC NHẬN XÓA",
                    TextAlign = ContentAlignment.MiddleCenter
                };

                lblConfirmMessage = new Label
                {
                    Font = new Font("Segoe UI", 11F, FontStyle.Regular),
                    ForeColor = Color.White,
                    Location = new Point(20, 60),
                    Size = new Size(360, 65),
                    Text = "Bạn có chắc chắn muốn xóa toàn bộ bảng xếp hạng không?\r\n\r\n(Thao tác này không thể hoàn tác!)",
                    TextAlign = ContentAlignment.MiddleCenter
                };

                btnDongYXoa = new Button
                {
                    BackColor = Color.FromArgb(200, 45, 45),
                    Cursor = Cursors.Hand,
                    FlatStyle = FlatStyle.Flat,
                    Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                    ForeColor = Color.White,
                    Location = new Point(35, 150),
                    Size = new Size(155, 45),
                    Text = "🗑️ Đồng Ý Xóa",
                    UseVisualStyleBackColor = false
                };
                btnDongYXoa.FlatAppearance.BorderSize = 0;
                btnDongYXoa.Click += btnDongYXoa_Click;

                btnHuyXoa = new Button
                {
                    BackColor = Color.FromArgb(70, 70, 100),
                    Cursor = Cursors.Hand,
                    FlatStyle = FlatStyle.Flat,
                    Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                    ForeColor = Color.White,
                    Location = new Point(210, 150),
                    Size = new Size(155, 45),
                    Text = "❌ Hủy Bỏ",
                    UseVisualStyleBackColor = false
                };
                btnHuyXoa.FlatAppearance.BorderSize = 0;
                btnHuyXoa.Click += btnHuyXoa_Click;

                pnlConfirmBox.Controls.Add(lblConfirmTitle);
                pnlConfirmBox.Controls.Add(lblConfirmMessage);
                pnlConfirmBox.Controls.Add(btnDongYXoa);
                pnlConfirmBox.Controls.Add(btnHuyXoa);

                pnlConfirmOverlay.Controls.Add(pnlConfirmBox);
                this.Controls.Add(pnlConfirmOverlay);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[Lỗi tạo popup xác nhận xóa]: {ex.Message}");
            }
        }

        private void LeaderboardForm_Load(object sender, EventArgs e)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    File.WriteAllLines(filePath, new string[] {
                        "Chuyên Gia|500",
                        "Thành Viên Nhóm|350",
                        "Gà Mờ|100",
                        "Cao Thủ|420",
                        "Người Qua Đường|50"
                    });
                }

                LoadLeaderboardData();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[Lỗi LeaderboardForm_Load]: {ex.Message}");
            }
        }

        private void LoadLeaderboardData()
        {
            try
            {
                dgvDiem.Rows.Clear();

                if (!File.Exists(filePath)) return;

                List<NguoiChoi> danhSach = new List<NguoiChoi>();
                string[] lines = File.ReadAllLines(filePath);
                
                foreach (string line in lines)
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;

                    string[] parts = line.Split('|');
                    if (parts.Length == 2)
                    {
                        NguoiChoi nc = new NguoiChoi();
                        nc.Ten = parts[0];
                        
                        int diem = 0;
                        int.TryParse(parts[1], out diem);
                        nc.Diem = diem;
                        
                        danhSach.Add(nc);
                    }
                }

                danhSach = danhSach.OrderByDescending(x => x.Diem).ToList();

                // Đổ dữ liệu vào bảng DataGridView
                for (int i = 0; i < danhSach.Count; i++)
                {
                    string xepHang = "";
                    
                    if (i == 0) xepHang = "🥇 Hạng 1";
                    else if (i == 1) xepHang = "🥈 Hạng 2";
                    else if (i == 2) xepHang = "🥉 Hạng 3";
                    else xepHang = $"   Hạng {i + 1}";

                    dgvDiem.Rows.Add(xepHang, danhSach[i].Ten, danhSach[i].Diem);
                }
                
                dgvDiem.ClearSelection(); // Xóa bôi xanh dòng đầu tiên
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[Lỗi tải dữ liệu bảng xếp hạng]: {ex.Message}");
            }
        }

        // Sự kiện khi bấm nút "Xóa Thành Tích": Mở popup in-game xác nhận
        private void btnXoaBang_Click(object sender, EventArgs e)
        {
            try
            {
                SoundManager.PlayButtonClick();
                pnlConfirmOverlay.Visible = true;
                pnlConfirmOverlay.BringToFront();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[Lỗi mở popup xóa]: {ex.Message}");
            }
        }

        // Sự kiện khi bấm "Đồng Ý Xóa" trên giao diện in-game
        private void btnDongYXoa_Click(object sender, EventArgs e)
        {
            try
            {
                SoundManager.PlayButtonClick();

                // Xóa rỗng nội dung file scores.txt
                File.WriteAllText(filePath, string.Empty);

                // Cập nhật lại giao diện bảng trống
                LoadLeaderboardData();

                // Đóng popup
                pnlConfirmOverlay.Visible = false;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[Lỗi xóa bảng xếp hạng]: {ex.Message}");
                MessageBox.Show($"Không thể xóa bảng xếp hạng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                pnlConfirmOverlay.Visible = false;
            }
        }

        // Sự kiện khi bấm "Hủy Bỏ" trên giao diện in-game
        private void btnHuyXoa_Click(object sender, EventArgs e)
        {
            try
            {
                SoundManager.PlayButtonClick();
                pnlConfirmOverlay.Visible = false;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[Lỗi btnHuyXoa_Click]: {ex.Message}");
            }
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            try
            {
                SoundManager.PlayButtonClick();
                this.Close(); 
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[Lỗi btnQuayLai_Click]: {ex.Message}");
                this.Close();
            }
        }
    }
}
