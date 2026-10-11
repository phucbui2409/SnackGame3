using System;
using System.Drawing;
using System.Windows.Forms;

namespace SnackGame3.Forms
{
    partial class MainForm
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
            label1 = new Label();
            lblSubtitle = new Label();
            btnChoi = new Button();
            btnThanhTich = new Button();
            btnHuongDan = new Button();
            btnThoat = new Button();
            btnSound = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 28F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(50, 205, 50);
            label1.Location = new Point(97, 80);
            label1.Name = "label1";
            label1.Size = new Size(401, 62);
            label1.TabIndex = 0;
            label1.Text = "🐍 SNAKE GAME";
            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("Segoe UI", 11.25F, FontStyle.Italic);
            lblSubtitle.ForeColor = Color.LightGray;
            lblSubtitle.Location = new Point(140, 153);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(313, 25);
            lblSubtitle.TabIndex = 6;
            lblSubtitle.Text = "Lập Trình Windows — Nhóm TamKa";
            lblSubtitle.Click += lblSubtitle_Click;
            // 
            // btnChoi
            // 
            btnChoi.BackColor = Color.FromArgb(34, 139, 34);
            btnChoi.Cursor = Cursors.Hand;
            btnChoi.FlatAppearance.BorderSize = 0;
            btnChoi.FlatStyle = FlatStyle.Flat;
            btnChoi.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnChoi.ForeColor = Color.White;
            btnChoi.Location = new Point(160, 240);
            btnChoi.Margin = new Padding(3, 4, 3, 4);
            btnChoi.Name = "btnChoi";
            btnChoi.Size = new Size(251, 69);
            btnChoi.TabIndex = 1;
            btnChoi.Text = "🎮 Chơi Game";
            btnChoi.UseVisualStyleBackColor = false;
            btnChoi.Click += btnChoi_Click;
            // 
            // btnThanhTich
            // 
            btnThanhTich.BackColor = Color.FromArgb(34, 139, 34);
            btnThanhTich.Cursor = Cursors.Hand;
            btnThanhTich.FlatAppearance.BorderSize = 0;
            btnThanhTich.FlatStyle = FlatStyle.Flat;
            btnThanhTich.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnThanhTich.ForeColor = Color.White;
            btnThanhTich.Location = new Point(160, 333);
            btnThanhTich.Margin = new Padding(3, 4, 3, 4);
            btnThanhTich.Name = "btnThanhTich";
            btnThanhTich.Size = new Size(251, 69);
            btnThanhTich.TabIndex = 2;
            btnThanhTich.Text = "🏆 Bảng Thành Tích";
            btnThanhTich.UseVisualStyleBackColor = false;
            btnThanhTich.Click += btnThanhTich_Click;
            // 
            // btnHuongDan
            // 
            btnHuongDan.BackColor = Color.FromArgb(34, 139, 34);
            btnHuongDan.Cursor = Cursors.Hand;
            btnHuongDan.FlatAppearance.BorderSize = 0;
            btnHuongDan.FlatStyle = FlatStyle.Flat;
            btnHuongDan.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnHuongDan.ForeColor = Color.White;
            btnHuongDan.Location = new Point(160, 427);
            btnHuongDan.Margin = new Padding(3, 4, 3, 4);
            btnHuongDan.Name = "btnHuongDan";
            btnHuongDan.Size = new Size(251, 69);
            btnHuongDan.TabIndex = 3;
            btnHuongDan.Text = "📖 Hướng Dẫn";
            btnHuongDan.UseVisualStyleBackColor = false;
            btnHuongDan.Click += btnHuongDan_Click;
            // 
            // btnThoat
            // 
            btnThoat.BackColor = Color.FromArgb(160, 30, 30);
            btnThoat.Cursor = Cursors.Hand;
            btnThoat.FlatAppearance.BorderSize = 0;
            btnThoat.FlatStyle = FlatStyle.Flat;
            btnThoat.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnThoat.ForeColor = Color.White;
            btnThoat.Location = new Point(160, 520);
            btnThoat.Margin = new Padding(3, 4, 3, 4);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(251, 69);
            btnThoat.TabIndex = 4;
            btnThoat.Text = "❌ Thoát";
            btnThoat.UseVisualStyleBackColor = false;
            btnThoat.Click += btnThoat_Click;
            // 
            // btnSound
            // 
            btnSound.BackColor = Color.FromArgb(40, 60, 80);
            btnSound.Cursor = Cursors.Hand;
            btnSound.FlatAppearance.BorderColor = Color.FromArgb(80, 120, 160);
            btnSound.FlatStyle = FlatStyle.Flat;
            btnSound.Font = new Font("Segoe UI", 9F);
            btnSound.ForeColor = Color.FromArgb(50, 205, 50);
            btnSound.Location = new Point(389, 20);
            btnSound.Margin = new Padding(3, 4, 3, 4);
            btnSound.Name = "btnSound";
            btnSound.Size = new Size(149, 43);
            btnSound.TabIndex = 5;
            btnSound.Text = "🔊 Âm Thanh: BẬT";
            btnSound.UseVisualStyleBackColor = false;
            btnSound.Click += btnSound_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(20, 20, 40);
            ClientSize = new Size(571, 667);
            Controls.Add(lblSubtitle);
            Controls.Add(btnSound);
            Controls.Add(btnThoat);
            Controls.Add(btnHuongDan);
            Controls.Add(btnThanhTich);
            Controls.Add(btnChoi);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Snake Game - Nhóm 5";
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Button btnChoi;
        private System.Windows.Forms.Button btnThanhTich;
        private System.Windows.Forms.Button btnHuongDan;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnSound;
    }
}
