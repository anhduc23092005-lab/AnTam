namespace AnTam_BaoHiem
{
    partial class FormAdmin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvBoiThuong = new System.Windows.Forms.DataGridView();
            this.cboLocLoaiBH = new System.Windows.Forms.ComboBox();
            this.btnDuyet = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBoiThuong)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvBoiThuong
            // 
            this.dgvBoiThuong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBoiThuong.Location = new System.Drawing.Point(460, 51);
            this.dgvBoiThuong.Name = "dgvBoiThuong";
            this.dgvBoiThuong.RowHeadersWidth = 62;
            this.dgvBoiThuong.RowTemplate.Height = 28;
            this.dgvBoiThuong.Size = new System.Drawing.Size(240, 150);
            this.dgvBoiThuong.TabIndex = 0;
            // 
            // cboLocLoaiBH
            // 
            this.cboLocLoaiBH.FormattingEnabled = true;
            this.cboLocLoaiBH.Location = new System.Drawing.Point(116, 61);
            this.cboLocLoaiBH.Name = "cboLocLoaiBH";
            this.cboLocLoaiBH.Size = new System.Drawing.Size(121, 28);
            this.cboLocLoaiBH.TabIndex = 1;
            // 
            // btnDuyet
            // 
            this.btnDuyet.Location = new System.Drawing.Point(116, 111);
            this.btnDuyet.Name = "btnDuyet";
            this.btnDuyet.Size = new System.Drawing.Size(75, 23);
            this.btnDuyet.TabIndex = 2;
            this.btnDuyet.Text = "button1";
            this.btnDuyet.UseVisualStyleBackColor = true;
            this.btnDuyet.Click += new System.EventHandler(this.btnDuyet_Click);
            // 
            // FormAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnDuyet);
            this.Controls.Add(this.cboLocLoaiBH);
            this.Controls.Add(this.dgvBoiThuong);
            this.Name = "FormAdmin";
            this.Text = "FormAdmin";
            ((System.ComponentModel.ISupportInitialize)(this.dgvBoiThuong)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvBoiThuong;
        private System.Windows.Forms.ComboBox cboLocLoaiBH;
        private System.Windows.Forms.Button btnDuyet;
    }
}