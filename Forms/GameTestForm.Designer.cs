using System;
using System.Drawing;
using System.Windows.Forms;

namespace SnackGame3.Test
{
    partial class GameTestForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.topPanel = new System.Windows.Forms.Panel();
            this.lblScore = new System.Windows.Forms.Label();
            this.lblDifficulty = new System.Windows.Forms.Label();
            this.lblGuide = new System.Windows.Forms.Label();
            this.canvas = new System.Windows.Forms.PictureBox();
            this.pnlStartBox = new System.Windows.Forms.Panel();
            this.lblTieuDeStart = new System.Windows.Forms.Label();
            this.lblMotaDoKho = new System.Windows.Forms.Label();
            this.btnDoKhoDe = new System.Windows.Forms.Button();
            this.btnDoKhoVua = new System.Windows.Forms.Button();
            this.btnDoKhoKho = new System.Windows.Forms.Button();
            this.lblThongTinTocDo = new System.Windows.Forms.Label();
            this.btnBatDauStart = new System.Windows.Forms.Button();
            this.lblStartHint = new System.Windows.Forms.Label();
            this.pnlGameOverBox = new System.Windows.Forms.Panel();
            this.lblTieuDeOver = new System.Windows.Forms.Label();
            this.lblThongBaoLuu = new System.Windows.Forms.Label();
            this.txtTenNguoiChoi = new System.Windows.Forms.TextBox();
            this.btnLuuDiem = new System.Windows.Forms.Button();
            this.btnChoiLai = new System.Windows.Forms.Button();
            this.btnVeMenu = new System.Windows.Forms.Button();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.topPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).BeginInit();
            this.pnlStartBox.SuspendLayout();
            this.pnlGameOverBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // topPanel
            // 
            this.topPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(45)))));
            this.topPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.topPanel.Controls.Add(this.lblScore);
            this.topPanel.Controls.Add(this.lblDifficulty);
            this.topPanel.Controls.Add(this.lblGuide);
            this.topPanel.Location = new System.Drawing.Point(20, 10);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(500, 36);
            this.topPanel.TabIndex = 0;
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblScore.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(220)))), ((int)(((byte)(50)))));
            this.lblScore.Location = new System.Drawing.Point(10, 6);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(107, 21);
            this.lblScore.TabIndex = 0;
            this.lblScore.Text = "🍎 ĐIỂM: 0";
            // 
            // lblDifficulty
            // 
            this.lblDifficulty.AutoSize = true;
            this.lblDifficulty.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblDifficulty.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(215)))), ((int)(((byte)(0)))));
            this.lblDifficulty.Location = new System.Drawing.Point(135, 7);
            this.lblDifficulty.Name = "lblDifficulty";
            this.lblDifficulty.Size = new System.Drawing.Size(115, 19);
            this.lblDifficulty.TabIndex = 1;
            this.lblDifficulty.Text = "⚡ Độ khó: 🟡 Vừa";
            // 
            // lblGuide
            // 
            this.lblGuide.AutoSize = true;
            this.lblGuide.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblGuide.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(200)))));
            this.lblGuide.Location = new System.Drawing.Point(265, 9);
            this.lblGuide.Name = "lblGuide";
            this.lblGuide.Size = new System.Drawing.Size(225, 15);
            this.lblGuide.TabIndex = 2;
            this.lblGuide.Text = "⏸️ [P]: Dừng | 🎮 [W,A,S,D] / [Mũi tên]";
            // 
            // canvas
            // 
            this.canvas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(30)))));
            this.canvas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.canvas.Location = new System.Drawing.Point(20, 55);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(500, 400);
            this.canvas.TabIndex = 1;
            this.canvas.TabStop = false;
            this.canvas.Paint += new System.Windows.Forms.PaintEventHandler(this.Canvas_Paint);
            // 
            // pnlStartBox
            // 
            this.pnlStartBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(50)))));
            this.pnlStartBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlStartBox.Controls.Add(this.lblTieuDeStart);
            this.pnlStartBox.Controls.Add(this.lblMotaDoKho);
            this.pnlStartBox.Controls.Add(this.btnDoKhoDe);
            this.pnlStartBox.Controls.Add(this.btnDoKhoVua);
            this.pnlStartBox.Controls.Add(this.btnDoKhoKho);
            this.pnlStartBox.Controls.Add(this.lblThongTinTocDo);
            this.pnlStartBox.Controls.Add(this.btnBatDauStart);
            this.pnlStartBox.Controls.Add(this.lblStartHint);
            this.pnlStartBox.Location = new System.Drawing.Point(60, 115);
            this.pnlStartBox.Name = "pnlStartBox";
            this.pnlStartBox.Size = new System.Drawing.Size(420, 275);
            this.pnlStartBox.TabIndex = 2;
            this.pnlStartBox.Visible = false;
            // 
            // lblTieuDeStart
            // 
            this.lblTieuDeStart.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTieuDeStart.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(220)))), ((int)(((byte)(50)))));
            this.lblTieuDeStart.Location = new System.Drawing.Point(0, 12);
            this.lblTieuDeStart.Name = "lblTieuDeStart";
            this.lblTieuDeStart.Size = new System.Drawing.Size(420, 32);
            this.lblTieuDeStart.TabIndex = 0;
            this.lblTieuDeStart.Text = "🐍 CHỌN ĐỘ KHÓ & BẮT ĐẦU 🐍";
            this.lblTieuDeStart.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMotaDoKho
            // 
            this.lblMotaDoKho.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblMotaDoKho.ForeColor = System.Drawing.Color.LightGray;
            this.lblMotaDoKho.Location = new System.Drawing.Point(0, 46);
            this.lblMotaDoKho.Name = "lblMotaDoKho";
            this.lblMotaDoKho.Size = new System.Drawing.Size(420, 22);
            this.lblMotaDoKho.TabIndex = 1;
            this.lblMotaDoKho.Text = "Chọn mức độ rắn chạy (tốc độ game):";
            this.lblMotaDoKho.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnDoKhoDe
            // 
            this.btnDoKhoDe.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDoKhoDe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDoKhoDe.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnDoKhoDe.ForeColor = System.Drawing.Color.White;
            this.btnDoKhoDe.Location = new System.Drawing.Point(25, 74);
            this.btnDoKhoDe.Name = "btnDoKhoDe";
            this.btnDoKhoDe.Size = new System.Drawing.Size(115, 48);
            this.btnDoKhoDe.TabIndex = 2;
            this.btnDoKhoDe.Text = "🟢 DỄ\n(200ms)";
            this.btnDoKhoDe.UseVisualStyleBackColor = true;
            this.btnDoKhoDe.Click += new System.EventHandler(this.btnDoKhoDe_Click);
            // 
            // btnDoKhoVua
            // 
            this.btnDoKhoVua.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDoKhoVua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDoKhoVua.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnDoKhoVua.ForeColor = System.Drawing.Color.White;
            this.btnDoKhoVua.Location = new System.Drawing.Point(152, 74);
            this.btnDoKhoVua.Name = "btnDoKhoVua";
            this.btnDoKhoVua.Size = new System.Drawing.Size(115, 48);
            this.btnDoKhoVua.TabIndex = 3;
            this.btnDoKhoVua.Text = "🟡 VỪA\n(120ms)";
            this.btnDoKhoVua.UseVisualStyleBackColor = true;
            this.btnDoKhoVua.Click += new System.EventHandler(this.btnDoKhoVua_Click);
            // 
            // btnDoKhoKho
            // 
            this.btnDoKhoKho.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDoKhoKho.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDoKhoKho.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnDoKhoKho.ForeColor = System.Drawing.Color.White;
            this.btnDoKhoKho.Location = new System.Drawing.Point(280, 74);
            this.btnDoKhoKho.Name = "btnDoKhoKho";
            this.btnDoKhoKho.Size = new System.Drawing.Size(115, 48);
            this.btnDoKhoKho.TabIndex = 4;
            this.btnDoKhoKho.Text = "🔴 KHÓ\n(70ms)";
            this.btnDoKhoKho.UseVisualStyleBackColor = true;
            this.btnDoKhoKho.Click += new System.EventHandler(this.btnDoKhoKho_Click);
            // 
            // lblThongTinTocDo
            // 
            this.lblThongTinTocDo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.lblThongTinTocDo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(215)))), ((int)(((byte)(0)))));
            this.lblThongTinTocDo.Location = new System.Drawing.Point(0, 130);
            this.lblThongTinTocDo.Name = "lblThongTinTocDo";
            this.lblThongTinTocDo.Size = new System.Drawing.Size(420, 24);
            this.lblThongTinTocDo.TabIndex = 5;
            this.lblThongTinTocDo.Text = "⚡ Tốc độ 120ms: Rắn chạy vừa phải, cân bằng tốc độ & phản xạ!";
            this.lblThongTinTocDo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnBatDauStart
            // 
            this.btnBatDauStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(150)))), ((int)(((byte)(60)))));
            this.btnBatDauStart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBatDauStart.FlatAppearance.BorderSize = 0;
            this.btnBatDauStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBatDauStart.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnBatDauStart.ForeColor = System.Drawing.Color.White;
            this.btnBatDauStart.Location = new System.Drawing.Point(85, 162);
            this.btnBatDauStart.Name = "btnBatDauStart";
            this.btnBatDauStart.Size = new System.Drawing.Size(250, 48);
            this.btnBatDauStart.TabIndex = 6;
            this.btnBatDauStart.Text = "▶️ BẮT ĐẦU (START)";
            this.btnBatDauStart.UseVisualStyleBackColor = false;
            this.btnBatDauStart.Click += new System.EventHandler(this.btnBatDauStart_Click);
            // 
            // lblStartHint
            // 
            this.lblStartHint.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblStartHint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(190)))));
            this.lblStartHint.Location = new System.Drawing.Point(0, 222);
            this.lblStartHint.Name = "lblStartHint";
            this.lblStartHint.Size = new System.Drawing.Size(420, 20);
            this.lblStartHint.TabIndex = 7;
            this.lblStartHint.Text = "💡 Mẹo: Nhấn [Space] hoặc [Enter] để bắt đầu chơi";
            this.lblStartHint.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlGameOverBox
            // 
            this.pnlGameOverBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(50)))));
            this.pnlGameOverBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlGameOverBox.Controls.Add(this.lblTieuDeOver);
            this.pnlGameOverBox.Controls.Add(this.lblThongBaoLuu);
            this.pnlGameOverBox.Controls.Add(this.txtTenNguoiChoi);
            this.pnlGameOverBox.Controls.Add(this.btnLuuDiem);
            this.pnlGameOverBox.Controls.Add(this.btnChoiLai);
            this.pnlGameOverBox.Controls.Add(this.btnVeMenu);
            this.pnlGameOverBox.Location = new System.Drawing.Point(80, 125);
            this.pnlGameOverBox.Name = "pnlGameOverBox";
            this.pnlGameOverBox.Size = new System.Drawing.Size(380, 260);
            this.pnlGameOverBox.TabIndex = 3;
            this.pnlGameOverBox.Visible = false;
            // 
            // lblTieuDeOver
            // 
            this.lblTieuDeOver.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTieuDeOver.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.lblTieuDeOver.Location = new System.Drawing.Point(0, 12);
            this.lblTieuDeOver.Name = "lblTieuDeOver";
            this.lblTieuDeOver.Size = new System.Drawing.Size(380, 38);
            this.lblTieuDeOver.TabIndex = 0;
            this.lblTieuDeOver.Text = "💀 GAME OVER 💀";
            this.lblTieuDeOver.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblThongBaoLuu
            // 
            this.lblThongBaoLuu.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblThongBaoLuu.ForeColor = System.Drawing.Color.LightGray;
            this.lblThongBaoLuu.Location = new System.Drawing.Point(0, 55);
            this.lblThongBaoLuu.Name = "lblThongBaoLuu";
            this.lblThongBaoLuu.Size = new System.Drawing.Size(380, 25);
            this.lblThongBaoLuu.TabIndex = 1;
            this.lblThongBaoLuu.Text = "Nhập tên của bạn để lưu kỷ lục:";
            this.lblThongBaoLuu.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtTenNguoiChoi
            // 
            this.txtTenNguoiChoi.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtTenNguoiChoi.Location = new System.Drawing.Point(70, 85);
            this.txtTenNguoiChoi.MaxLength = 20;
            this.txtTenNguoiChoi.Name = "txtTenNguoiChoi";
            this.txtTenNguoiChoi.Size = new System.Drawing.Size(240, 29);
            this.txtTenNguoiChoi.TabIndex = 2;
            this.txtTenNguoiChoi.Text = "Người chơi";
            this.txtTenNguoiChoi.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnLuuDiem
            // 
            this.btnLuuDiem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(150)))), ((int)(((byte)(60)))));
            this.btnLuuDiem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLuuDiem.FlatAppearance.BorderSize = 0;
            this.btnLuuDiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuuDiem.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnLuuDiem.ForeColor = System.Drawing.Color.White;
            this.btnLuuDiem.Location = new System.Drawing.Point(125, 125);
            this.btnLuuDiem.Name = "btnLuuDiem";
            this.btnLuuDiem.Size = new System.Drawing.Size(130, 36);
            this.btnLuuDiem.TabIndex = 3;
            this.btnLuuDiem.Text = "💾 Lưu Điểm";
            this.btnLuuDiem.UseVisualStyleBackColor = false;
            this.btnLuuDiem.Click += new System.EventHandler(this.btnLuuDiem_Click);
            // 
            // btnChoiLai
            // 
            this.btnChoiLai.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(110)))), ((int)(((byte)(200)))));
            this.btnChoiLai.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChoiLai.FlatAppearance.BorderSize = 0;
            this.btnChoiLai.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChoiLai.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnChoiLai.ForeColor = System.Drawing.Color.White;
            this.btnChoiLai.Location = new System.Drawing.Point(35, 190);
            this.btnChoiLai.Name = "btnChoiLai";
            this.btnChoiLai.Size = new System.Drawing.Size(140, 42);
            this.btnChoiLai.TabIndex = 4;
            this.btnChoiLai.Text = "🔄 Chơi Lại";
            this.btnChoiLai.UseVisualStyleBackColor = false;
            this.btnChoiLai.Click += new System.EventHandler(this.btnChoiLai_Click);
            // 
            // btnVeMenu
            // 
            this.btnVeMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.btnVeMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVeMenu.FlatAppearance.BorderSize = 0;
            this.btnVeMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVeMenu.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnVeMenu.ForeColor = System.Drawing.Color.White;
            this.btnVeMenu.Location = new System.Drawing.Point(205, 190);
            this.btnVeMenu.Name = "btnVeMenu";
            this.btnVeMenu.Size = new System.Drawing.Size(140, 42);
            this.btnVeMenu.TabIndex = 5;
            this.btnVeMenu.Text = "🔙 Về Menu";
            this.btnVeMenu.UseVisualStyleBackColor = false;
            this.btnVeMenu.Click += new System.EventHandler(this.btnVeMenu_Click);
            // 
            // gameTimer
            // 
            this.gameTimer.Tick += new System.EventHandler(this.GameTimer_Tick);
            // 
            // GameTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(540, 475);
            this.Controls.Add(this.pnlStartBox);
            this.Controls.Add(this.pnlGameOverBox);
            this.Controls.Add(this.canvas);
            this.Controls.Add(this.topPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "GameTestForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Snack Game - Màn Chơi";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.GameTestForm_FormClosed);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GameTestForm_KeyDown);
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).EndInit();
            this.pnlStartBox.ResumeLayout(false);
            this.pnlGameOverBox.ResumeLayout(false);
            this.pnlGameOverBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Label lblDifficulty;
        private System.Windows.Forms.Label lblGuide;
        private System.Windows.Forms.PictureBox canvas;
        private System.Windows.Forms.Panel pnlStartBox;
        private System.Windows.Forms.Label lblTieuDeStart;
        private System.Windows.Forms.Label lblMotaDoKho;
        private System.Windows.Forms.Button btnDoKhoDe;
        private System.Windows.Forms.Button btnDoKhoVua;
        private System.Windows.Forms.Button btnDoKhoKho;
        private System.Windows.Forms.Label lblThongTinTocDo;
        private System.Windows.Forms.Button btnBatDauStart;
        private System.Windows.Forms.Label lblStartHint;
        private System.Windows.Forms.Panel pnlGameOverBox;
        private System.Windows.Forms.Label lblTieuDeOver;
        private System.Windows.Forms.Label lblThongBaoLuu;
        private System.Windows.Forms.TextBox txtTenNguoiChoi;
        private System.Windows.Forms.Button btnLuuDiem;
        private System.Windows.Forms.Button btnChoiLai;
        private System.Windows.Forms.Button btnVeMenu;
        private System.Windows.Forms.Timer gameTimer;
    }
}
