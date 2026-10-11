using System;
using System.Collections.Generic;
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

        public LeaderboardForm()
        {
            InitializeComponent();
            this.BackColor = GameConfig.BgColor; 
        }

        private void LeaderboardForm_Load(object sender, EventArgs e)
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

        private void LoadLeaderboardData()
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

        // Sự kiện khi bấm nút "Xóa Thành Tích": Mở popup in-game xác nhận
        private void btnXoaBang_Click(object sender, EventArgs e)
        {
            SoundManager.PlayButtonClick();
            pnlConfirmOverlay.Visible = true;
            pnlConfirmOverlay.BringToFront();
        }

        // Sự kiện khi bấm "Đồng Ý Xóa" trên giao diện in-game
        private void btnDongYXoa_Click(object sender, EventArgs e)
        {
            SoundManager.PlayButtonClick();
            try
            {
                // Xóa rỗng nội dung file scores.txt
                File.WriteAllText(filePath, string.Empty);

                // Cập nhật lại giao diện bảng trống
                LoadLeaderboardData();
            }
            catch
            {
            }

            // Đóng popup
            pnlConfirmOverlay.Visible = false;
        }

        // Sự kiện khi bấm "Hủy Bỏ" trên giao diện in-game
        private void btnHuyXoa_Click(object sender, EventArgs e)
        {
            SoundManager.PlayButtonClick();
            pnlConfirmOverlay.Visible = false;
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            SoundManager.PlayButtonClick();
            this.Close(); 
        }
    }
}
