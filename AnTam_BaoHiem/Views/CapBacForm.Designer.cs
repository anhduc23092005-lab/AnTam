using System.Windows.Forms;

namespace AnTam_BaoHiem.Views
{
    partial class CapBacForm
    {
        private System.ComponentModel.IContainer components = null;

        private Guna.UI2.WinForms.Guna2HtmlLabel lblCap;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblUuDai;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblToggle;

        private Guna.UI2.WinForms.Guna2Panel panelLevels;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblCap = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblUuDai = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblToggle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.panelLevels = new Guna.UI2.WinForms.Guna2Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panelLevels.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCap
            // 
            this.lblCap.BackColor = System.Drawing.Color.Transparent;
            this.lblCap.Font = new System.Drawing.Font("Segoe UI", 26F, System.Drawing.FontStyle.Bold);
            this.lblCap.Location = new System.Drawing.Point(40, 30);
            this.lblCap.Name = "lblCap";
            this.lblCap.Size = new System.Drawing.Size(303, 61);
            this.lblCap.TabIndex = 0;
            this.lblCap.Text = "Cấp hiện tại: ...";
            // 
            // lblUuDai
            // 
            this.lblUuDai.BackColor = System.Drawing.Color.Transparent;
            this.lblUuDai.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblUuDai.Location = new System.Drawing.Point(40, 100);
            this.lblUuDai.MaximumSize = new System.Drawing.Size(800, 0);
            this.lblUuDai.Name = "lblUuDai";
            this.lblUuDai.Size = new System.Drawing.Size(72, 30);
            this.lblUuDai.TabIndex = 1;
            this.lblUuDai.Text = "Ưu đãi...";
            // 
            // lblToggle
            // 
            this.lblToggle.BackColor = System.Drawing.Color.Transparent;
            this.lblToggle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblToggle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Underline);
            this.lblToggle.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblToggle.Location = new System.Drawing.Point(40, 161);
            this.lblToggle.Name = "lblToggle";
            this.lblToggle.Size = new System.Drawing.Size(216, 33);
            this.lblToggle.TabIndex = 2;
            this.lblToggle.Text = "Xem tất cả cấp bậc ▸";
            this.lblToggle.Click += new System.EventHandler(this.lblToggle_Click);
            // 
            // panelLevels
            // 
            this.panelLevels.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelLevels.BackColor = System.Drawing.Color.Transparent;
            this.panelLevels.BorderRadius = 15;
            this.panelLevels.Controls.Add(this.flowLayoutPanel1);
            this.panelLevels.FillColor = System.Drawing.Color.White;
            this.panelLevels.Location = new System.Drawing.Point(40, 200);
            this.panelLevels.Name = "panelLevels";
            this.panelLevels.ShadowDecoration.Enabled = true;
            this.panelLevels.Size = new System.Drawing.Size(350, 0);
            this.panelLevels.TabIndex = 3;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(10);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(350, 0);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // CapBacForm
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.lblCap);
            this.Controls.Add(this.lblUuDai);
            this.Controls.Add(this.lblToggle);
            this.Controls.Add(this.panelLevels);
            this.Name = "CapBacForm";
            this.Text = "Cấp bậc ";
            this.Load += new System.EventHandler(this.CapBacForm_Load);
            this.panelLevels.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}