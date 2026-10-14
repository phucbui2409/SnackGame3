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
            this.label1 = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.btnChoi = new System.Windows.Forms.Button();
            this.btnDoKho = new System.Windows.Forms.Button();
            this.btnThanhTich = new System.Windows.Forms.Button();
            this.btnHuongDan = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnSound = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(205)))), ((int)(((byte)(50)))));
            this.label1.Location = new System.Drawing.Point(90, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(401, 62);
            this.label1.TabIndex = 0;
            this.label1.Text = "🐍 SNAKE GAME";
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Italic);
            this.lblSubtitle.ForeColor = System.Drawing.Color.LightGray;
            this.lblSubtitle.Location = new System.Drawing.Point(155, 115);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(0, 25);
            this.lblSubtitle.TabIndex = 7;
            // 
            // btnChoi
            // 
            this.btnChoi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(139)))), ((int)(((byte)(34)))));
            this.btnChoi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChoi.FlatAppearance.BorderSize = 0;
            this.btnChoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChoi.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnChoi.ForeColor = System.Drawing.Color.White;
            this.btnChoi.Location = new System.Drawing.Point(155, 130);
            this.btnChoi.Name = "btnChoi";
            this.btnChoi.Size = new System.Drawing.Size(260, 52);
            this.btnChoi.TabIndex = 1;
            this.btnChoi.Text = "🎮 Bắt Đầu (Start)";
            this.btnChoi.UseVisualStyleBackColor = false;
            // 
            // btnDoKho
            // 
            this.btnDoKho.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(60)))), ((int)(((byte)(95)))));
            this.btnDoKho.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDoKho.FlatAppearance.BorderSize = 0;
            this.btnDoKho.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDoKho.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnDoKho.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(215)))), ((int)(((byte)(0)))));
            this.btnDoKho.Location = new System.Drawing.Point(155, 195);
            this.btnDoKho.Name = "btnDoKho";
            this.btnDoKho.Size = new System.Drawing.Size(260, 52);
            this.btnDoKho.TabIndex = 2;
            this.btnDoKho.Text = "⚡ Độ Khó: 🟡 Vừa";
            this.btnDoKho.UseVisualStyleBackColor = false;
            // 
            // btnThanhTich
            // 
            this.btnThanhTich.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(139)))), ((int)(((byte)(34)))));
            this.btnThanhTich.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThanhTich.FlatAppearance.BorderSize = 0;
            this.btnThanhTich.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThanhTich.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnThanhTich.ForeColor = System.Drawing.Color.White;
            this.btnThanhTich.Location = new System.Drawing.Point(155, 260);
            this.btnThanhTich.Name = "btnThanhTich";
            this.btnThanhTich.Size = new System.Drawing.Size(260, 52);
            this.btnThanhTich.TabIndex = 3;
            this.btnThanhTich.Text = "🏆 Bảng Thành Tích";
            this.btnThanhTich.UseVisualStyleBackColor = false;
            // 
            // btnHuongDan
            // 
            this.btnHuongDan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(139)))), ((int)(((byte)(34)))));
            this.btnHuongDan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHuongDan.FlatAppearance.BorderSize = 0;
            this.btnHuongDan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHuongDan.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnHuongDan.ForeColor = System.Drawing.Color.White;
            this.btnHuongDan.Location = new System.Drawing.Point(155, 325);
            this.btnHuongDan.Name = "btnHuongDan";
            this.btnHuongDan.Size = new System.Drawing.Size(260, 52);
            this.btnHuongDan.TabIndex = 4;
            this.btnHuongDan.Text = "📖 Hướng Dẫn";
            this.btnHuongDan.UseVisualStyleBackColor = false;
            // 
            // btnThoat
            // 
            this.btnThoat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnThoat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThoat.FlatAppearance.BorderSize = 0;
            this.btnThoat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThoat.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnThoat.ForeColor = System.Drawing.Color.White;
            this.btnThoat.Location = new System.Drawing.Point(155, 390);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(260, 52);
            this.btnThoat.TabIndex = 5;
            this.btnThoat.Text = "❌ Thoát";
            this.btnThoat.UseVisualStyleBackColor = false;
            // 
            // btnSound
            // 
            this.btnSound.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(60)))), ((int)(((byte)(80)))));
            this.btnSound.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSound.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(120)))), ((int)(((byte)(160)))));
            this.btnSound.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSound.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSound.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(205)))), ((int)(((byte)(50)))));
            this.btnSound.Location = new System.Drawing.Point(389, 16);
            this.btnSound.Name = "btnSound";
            this.btnSound.Size = new System.Drawing.Size(149, 34);
            this.btnSound.TabIndex = 6;
            this.btnSound.Text = "🔊 Âm Thanh: BẬT";
            this.btnSound.UseVisualStyleBackColor = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(571, 480);
            this.Controls.Add(this.lblSubtitle);
            this.Controls.Add(this.btnSound);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnHuongDan);
            this.Controls.Add(this.btnThanhTich);
            this.Controls.Add(this.btnDoKho);
            this.Controls.Add(this.btnChoi);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Snake Game - Nhóm 5";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Button btnChoi;
        private System.Windows.Forms.Button btnDoKho;
        private System.Windows.Forms.Button btnThanhTich;
        private System.Windows.Forms.Button btnHuongDan;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnSound;
    }
}
