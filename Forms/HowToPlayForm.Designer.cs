using System;
using System.Drawing;
using System.Windows.Forms;

namespace SnackGame3.Forms
{
    partial class HowToPlayForm
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

        private void InitializeComponent()
        {
            label1 = new Label();
            btnQuayLai = new Button();
            lblHuongDanTitle = new Label();
            lblHuongDanText = new Label();
            lblLuatChoiTitle = new Label();
            lblLuatChoiText = new Label();
            panel1 = new Panel();
            panel2 = new Panel();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(50, 205, 50);
            label1.Location = new Point(63, 27);
            label1.Name = "label1";
            label1.Size = new Size(455, 54);
            label1.TabIndex = 0;
            label1.Text = "📖 HƯỚNG DẪN CHƠI";
            // 
            // btnQuayLai
            // 
            btnQuayLai.BackColor = Color.FromArgb(160, 30, 30);
            btnQuayLai.Cursor = Cursors.Hand;
            btnQuayLai.FlatAppearance.BorderSize = 0;
            btnQuayLai.FlatStyle = FlatStyle.Flat;
            btnQuayLai.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnQuayLai.ForeColor = Color.White;
            btnQuayLai.Location = new Point(160, 560);
            btnQuayLai.Margin = new Padding(3, 4, 3, 4);
            btnQuayLai.Name = "btnQuayLai";
            btnQuayLai.Size = new Size(229, 60);
            btnQuayLai.TabIndex = 2;
            btnQuayLai.Text = "🔙 Quay Lại";
            btnQuayLai.UseVisualStyleBackColor = false;
            btnQuayLai.Click += btnQuayLai_Click;
            // 
            // lblHuongDanTitle
            // 
            lblHuongDanTitle.AutoSize = true;
            lblHuongDanTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblHuongDanTitle.ForeColor = Color.FromArgb(50, 205, 50);
            lblHuongDanTitle.Location = new Point(11, 13);
            lblHuongDanTitle.Name = "lblHuongDanTitle";
            lblHuongDanTitle.Size = new Size(264, 32);
            lblHuongDanTitle.TabIndex = 0;
            lblHuongDanTitle.Text = "🎮 CÁCH ĐIỀU KHIỂN";
            // 
            // lblHuongDanText
            // 
            lblHuongDanText.AutoSize = true;
            lblHuongDanText.Font = new Font("Segoe UI", 12F);
            lblHuongDanText.ForeColor = Color.White;
            lblHuongDanText.Location = new Point(23, 60);
            lblHuongDanText.Name = "lblHuongDanText";
            lblHuongDanText.Size = new Size(413, 84);
            lblHuongDanText.TabIndex = 1;
            lblHuongDanText.Text = "• Chọn độ khó (Dễ / Vừa / Khó) và bấm Start để bắt đầu.\r\n• Dùng 4 phím Mũi Tên hoặc W, A, S, D để điều khiển.\r\n• Nhấn phím P để Tạm dừng, phím ESC để thoát.";
            // 
            // lblLuatChoiTitle
            // 
            lblLuatChoiTitle.AutoSize = true;
            lblLuatChoiTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblLuatChoiTitle.ForeColor = Color.FromArgb(50, 205, 50);
            lblLuatChoiTitle.Location = new Point(11, 13);
            lblLuatChoiTitle.Name = "lblLuatChoiTitle";
            lblLuatChoiTitle.Size = new Size(182, 32);
            lblLuatChoiTitle.TabIndex = 0;
            lblLuatChoiTitle.Text = "📜 LUẬT CHƠI";
            // 
            // lblLuatChoiText
            // 
            lblLuatChoiText.AutoSize = true;
            lblLuatChoiText.Font = new Font("Segoe UI", 12F);
            lblLuatChoiText.ForeColor = Color.White;
            lblLuatChoiText.Location = new Point(11, 62);
            lblLuatChoiText.Name = "lblLuatChoiText";
            lblLuatChoiText.Size = new Size(443, 84);
            lblLuatChoiText.TabIndex = 1;
            lblLuatChoiText.Text = "• Điều khiển rắn ăn các chấm mồi để ghi điểm.\r\n• Mỗi lần ăn mồi, rắn sẽ dài thêm 1 ô.\r\n• Game Over nếu rắn đâm vào tường hoặc tự cắn.";
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(30, 30, 50);
            panel1.Controls.Add(lblHuongDanText);
            panel1.Controls.Add(lblHuongDanTitle);
            panel1.Location = new Point(46, 113);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(457, 187);
            panel1.TabIndex = 3;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(30, 30, 50);
            panel2.Controls.Add(lblLuatChoiText);
            panel2.Controls.Add(lblLuatChoiTitle);
            panel2.Location = new Point(46, 327);
            panel2.Margin = new Padding(3, 4, 3, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(457, 200);
            panel2.TabIndex = 4;
            // 
            // HowToPlayForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(20, 20, 40);
            ClientSize = new Size(553, 668);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(btnQuayLai);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "HowToPlayForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Hướng Dẫn";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnQuayLai;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblHuongDanTitle;
        private System.Windows.Forms.Label lblHuongDanText;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblLuatChoiTitle;
        private System.Windows.Forms.Label lblLuatChoiText;
    }
}
