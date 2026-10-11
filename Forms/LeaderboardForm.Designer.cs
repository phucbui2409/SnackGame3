using System;
using System.Drawing;
using System.Windows.Forms;

namespace SnackGame3.Forms
{
    partial class LeaderboardForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.btnQuayLai = new System.Windows.Forms.Button();
            this.btnXoaBang = new System.Windows.Forms.Button();
            this.dgvDiem = new System.Windows.Forms.DataGridView();
            this.colHang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDiem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlConfirmOverlay = new System.Windows.Forms.Panel();
            this.pnlConfirmBox = new System.Windows.Forms.Panel();
            this.lblConfirmTitle = new System.Windows.Forms.Label();
            this.lblConfirmMessage = new System.Windows.Forms.Label();
            this.btnDongYXoa = new System.Windows.Forms.Button();
            this.btnHuyXoa = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiem)).BeginInit();
            this.pnlConfirmOverlay.SuspendLayout();
            this.pnlConfirmBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(205)))), ((int)(((byte)(50)))));
            this.label1.Location = new System.Drawing.Point(65, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(359, 45);
            this.label1.TabIndex = 0;
            this.label1.Text = "🏆 BẢNG THÀNH TÍCH";
            // 
            // btnXoaBang
            // 
            this.btnXoaBang.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnXoaBang.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXoaBang.FlatAppearance.BorderSize = 0;
            this.btnXoaBang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaBang.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnXoaBang.ForeColor = System.Drawing.Color.White;
            this.btnXoaBang.Location = new System.Drawing.Point(30, 420);
            this.btnXoaBang.Name = "btnXoaBang";
            this.btnXoaBang.Size = new System.Drawing.Size(200, 45);
            this.btnXoaBang.TabIndex = 4;
            this.btnXoaBang.Text = "🗑️ Xóa Thành Tích";
            this.btnXoaBang.UseVisualStyleBackColor = false;
            this.btnXoaBang.Click += new System.EventHandler(this.btnXoaBang_Click);
            // 
            // btnQuayLai
            // 
            this.btnQuayLai.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(90)))));
            this.btnQuayLai.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuayLai.FlatAppearance.BorderSize = 0;
            this.btnQuayLai.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuayLai.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnQuayLai.ForeColor = System.Drawing.Color.White;
            this.btnQuayLai.Location = new System.Drawing.Point(250, 420);
            this.btnQuayLai.Name = "btnQuayLai";
            this.btnQuayLai.Size = new System.Drawing.Size(200, 45);
            this.btnQuayLai.TabIndex = 2;
            this.btnQuayLai.Text = "🔙 Quay Lại";
            this.btnQuayLai.UseVisualStyleBackColor = false;
            this.btnQuayLai.Click += new System.EventHandler(this.btnQuayLai_Click);
            // 
            // dgvDiem
            // 
            this.dgvDiem.AllowUserToAddRows = false;
            this.dgvDiem.AllowUserToDeleteRows = false;
            this.dgvDiem.AllowUserToResizeColumns = false;
            this.dgvDiem.AllowUserToResizeRows = false;
            this.dgvDiem.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(40)))));
            this.dgvDiem.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDiem.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvDiem.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(139)))), ((int)(((byte)(34)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(139)))), ((int)(((byte)(34)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDiem.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDiem.ColumnHeadersHeight = 45;
            this.dgvDiem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDiem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colHang,
            this.colTen,
            this.colDiem});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(50)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(205)))), ((int)(((byte)(50)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDiem.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDiem.EnableHeadersVisualStyles = false;
            this.dgvDiem.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(80)))));
            this.dgvDiem.Location = new System.Drawing.Point(30, 85);
            this.dgvDiem.MultiSelect = false;
            this.dgvDiem.Name = "dgvDiem";
            this.dgvDiem.ReadOnly = true;
            this.dgvDiem.RowHeadersVisible = false;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.dgvDiem.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDiem.RowTemplate.Height = 40;
            this.dgvDiem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDiem.Size = new System.Drawing.Size(420, 315);
            this.dgvDiem.TabIndex = 3;
            // 
            // colHang
            // 
            this.colHang.HeaderText = "Thứ Hạng";
            this.colHang.Name = "colHang";
            this.colHang.ReadOnly = true;
            this.colHang.Width = 110;
            // 
            // colTen
            // 
            this.colTen.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colTen.HeaderText = "Người Chơi";
            this.colTen.Name = "colTen";
            this.colTen.ReadOnly = true;
            // 
            // colDiem
            // 
            this.colDiem.HeaderText = "Điểm Số";
            this.colDiem.Name = "colDiem";
            this.colDiem.ReadOnly = true;
            this.colDiem.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            // 
            // pnlConfirmOverlay
            // 
            this.pnlConfirmOverlay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(25)))));
            this.pnlConfirmOverlay.Controls.Add(this.pnlConfirmBox);
            this.pnlConfirmOverlay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlConfirmOverlay.Location = new System.Drawing.Point(0, 0);
            this.pnlConfirmOverlay.Name = "pnlConfirmOverlay";
            this.pnlConfirmOverlay.Size = new System.Drawing.Size(484, 491);
            this.pnlConfirmOverlay.TabIndex = 10;
            this.pnlConfirmOverlay.Visible = false;
            // 
            // pnlConfirmBox
            // 
            this.pnlConfirmBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(55)))));
            this.pnlConfirmBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlConfirmBox.Controls.Add(this.lblConfirmTitle);
            this.pnlConfirmBox.Controls.Add(this.lblConfirmMessage);
            this.pnlConfirmBox.Controls.Add(this.btnDongYXoa);
            this.pnlConfirmBox.Controls.Add(this.btnHuyXoa);
            this.pnlConfirmBox.Location = new System.Drawing.Point(42, 120);
            this.pnlConfirmBox.Name = "pnlConfirmBox";
            this.pnlConfirmBox.Size = new System.Drawing.Size(400, 230);
            this.pnlConfirmBox.TabIndex = 0;
            // 
            // lblConfirmTitle
            // 
            this.lblConfirmTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblConfirmTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.lblConfirmTitle.Location = new System.Drawing.Point(0, 15);
            this.lblConfirmTitle.Name = "lblConfirmTitle";
            this.lblConfirmTitle.Size = new System.Drawing.Size(400, 35);
            this.lblConfirmTitle.TabIndex = 0;
            this.lblConfirmTitle.Text = "⚠️ XÁC NHẬN XÓA";
            this.lblConfirmTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblConfirmMessage
            // 
            this.lblConfirmMessage.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblConfirmMessage.ForeColor = System.Drawing.Color.White;
            this.lblConfirmMessage.Location = new System.Drawing.Point(20, 60);
            this.lblConfirmMessage.Name = "lblConfirmMessage";
            this.lblConfirmMessage.Size = new System.Drawing.Size(360, 65);
            this.lblConfirmMessage.TabIndex = 1;
            this.lblConfirmMessage.Text = "Bạn có chắc chắn muốn xóa toàn bộ bảng xếp hạng không?\r\n\r\n(Thao tác này không thể hoàn tác!)";
            this.lblConfirmMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnDongYXoa
            // 
            this.btnDongYXoa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.btnDongYXoa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDongYXoa.FlatAppearance.BorderSize = 0;
            this.btnDongYXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDongYXoa.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnDongYXoa.ForeColor = System.Drawing.Color.White;
            this.btnDongYXoa.Location = new System.Drawing.Point(35, 150);
            this.btnDongYXoa.Name = "btnDongYXoa";
            this.btnDongYXoa.Size = new System.Drawing.Size(155, 45);
            this.btnDongYXoa.TabIndex = 2;
            this.btnDongYXoa.Text = "🗑️ Đồng Ý Xóa";
            this.btnDongYXoa.UseVisualStyleBackColor = false;
            this.btnDongYXoa.Click += new System.EventHandler(this.btnDongYXoa_Click);
            // 
            // btnHuyXoa
            // 
            this.btnHuyXoa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(100)))));
            this.btnHuyXoa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHuyXoa.FlatAppearance.BorderSize = 0;
            this.btnHuyXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHuyXoa.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnHuyXoa.ForeColor = System.Drawing.Color.White;
            this.btnHuyXoa.Location = new System.Drawing.Point(210, 150);
            this.btnHuyXoa.Name = "btnHuyXoa";
            this.btnHuyXoa.Size = new System.Drawing.Size(155, 45);
            this.btnHuyXoa.TabIndex = 3;
            this.btnHuyXoa.Text = "❌ Hủy Bỏ";
            this.btnHuyXoa.UseVisualStyleBackColor = false;
            this.btnHuyXoa.Click += new System.EventHandler(this.btnHuyXoa_Click);
            // 
            // LeaderboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(484, 491);
            this.Controls.Add(this.pnlConfirmOverlay);
            this.Controls.Add(this.btnXoaBang);
            this.Controls.Add(this.dgvDiem);
            this.Controls.Add(this.btnQuayLai);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "LeaderboardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Bảng Thành Tích";
            this.Load += new System.EventHandler(this.LeaderboardForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiem)).EndInit();
            this.pnlConfirmOverlay.ResumeLayout(false);
            this.pnlConfirmBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnQuayLai;
        private System.Windows.Forms.Button btnXoaBang;
        private System.Windows.Forms.DataGridView dgvDiem;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHang;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDiem;
        private System.Windows.Forms.Panel pnlConfirmOverlay;
        private System.Windows.Forms.Panel pnlConfirmBox;
        private System.Windows.Forms.Label lblConfirmTitle;
        private System.Windows.Forms.Label lblConfirmMessage;
        private System.Windows.Forms.Button btnDongYXoa;
        private System.Windows.Forms.Button btnHuyXoa;
    }
}
