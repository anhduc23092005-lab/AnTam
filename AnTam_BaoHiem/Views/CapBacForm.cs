using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using AnTam_BaoHiem.Helpers;

namespace AnTam_BaoHiem.Views
{
    public partial class CapBacForm : Form
    {
        private string _username;
        private int _exp = 0;
        private bool isExpanded = false;

        Timer animationTimer = new Timer();

        public CapBacForm(string username)
        {
            InitializeComponent();
            _username = username;

            animationTimer.Interval = 10;
            animationTimer.Tick += AnimatePanel;
        }

        private void CapBacForm_Load(object sender, EventArgs e)
        {
            LoadCapBac();
        }

        private void LoadCapBac()
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                SqlCommand cmdExp = new SqlCommand(
                    "SELECT EXP FROM KhachHang WHERE TenDangNhap=@u", conn);
                cmdExp.Parameters.AddWithValue("@u", _username);

                _exp = Convert.ToInt32(cmdExp.ExecuteScalar() ?? 0);

                SqlCommand cmd = new SqlCommand(@"
                    SELECT TOP 1 * FROM QuanLyCapBac
                    WHERE @exp >= EXPToiThieu
                    ORDER BY EXPToiThieu DESC", conn);

                cmd.Parameters.AddWithValue("@exp", _exp);

                var rd = cmd.ExecuteReader();

                if (!rd.Read()) return;

                lblCap.Text = $"Cấp hiện tại: {rd["TenCap"]}";
                lblUuDai.Text = $"Ưu đãi: {rd["MoTa"]}";

                rd.Close();
            }
        }

        private void lblToggle_Click(object sender, EventArgs e)
        {
            animationTimer.Start();

            if (!isExpanded)
                LoadDanhSachCap();
        }

        private void AnimatePanel(object sender, EventArgs e)
        {
            if (!isExpanded)
            {
                panelLevels.Height += 30;

                if (panelLevels.Height >= 350)
                {
                    panelLevels.Height = 350;
                    animationTimer.Stop();
                    isExpanded = true;
                    lblToggle.Text = "Thu gọn ▲";
                }
            }
            else
            {
                panelLevels.Height -= 30;

                if (panelLevels.Height <= 0)
                {
                    panelLevels.Height = 0;
                    animationTimer.Stop();
                    isExpanded = false;
                    lblToggle.Text = "Xem cấp bậc ▸";
                }
            }
        }

        private void LoadDanhSachCap()
        {
            flowLayoutPanel1.Controls.Clear();

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string sql = "SELECT * FROM QuanLyCapBac ORDER BY EXPToiThieu";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {
                    flowLayoutPanel1.Controls.Add(CreateCard(row));
                }
            }
        }

        private Guna.UI2.WinForms.Guna2Panel CreateCard(DataRow row)
        {
            var card = new Guna.UI2.WinForms.Guna2Panel();
            card.Size = new Size(600, 300); // 🔥 TO HƠN
            card.Margin = new Padding(15);
            card.BorderRadius = 18;
            card.FillColor = Color.White;
            card.ShadowDecoration.Enabled = true;

            string tenCap = row["TenCap"].ToString();
            int expMin = Convert.ToInt32(row["EXPToiThieu"]);
            string mota = row["MoTa"].ToString();

            if (_exp >= expMin)
                card.FillColor = Color.FromArgb(255, 248, 220);

            Label lblName = new Label();
            lblName.Text = tenCap;
            lblName.Font = new Font("Segoe UI", 18, FontStyle.Bold); // 🔥 TO HƠN
            lblName.Location = new Point(20, 15);
            lblName.AutoSize = true;
            lblName.MaximumSize = new Size(550, 0); // 🔥 KHÔNG CẮT CHỮ

            Label lblExp = new Label();
            lblExp.Text = $"EXP: {expMin}";
            lblExp.Font = new Font("Segoe UI", 13, FontStyle.Regular);
            lblExp.Location = new Point(20, 60);
            lblExp.AutoSize = true;

            Label lblDesc = new Label();
            lblDesc.Text = mota;
            lblDesc.Font = new Font("Segoe UI", 13);
            lblDesc.Location = new Point(20, 95);
            lblDesc.MaximumSize = new Size(550, 0); // 🔥 WRAP TEXT
            lblDesc.AutoSize = true;

            Label lblStatus = new Label();
            lblStatus.Font = new Font("Segoe UI", 13, FontStyle.Bold);
            lblStatus.Location = new Point(20, 170);
            lblStatus.AutoSize = true;

            if (_exp >= expMin)
            {
                lblStatus.Text = "✔ Đã đạt";
                lblStatus.ForeColor = Color.Green;
            }
            else
            {
                lblStatus.Text = $"Còn {expMin - _exp} EXP";
                lblStatus.ForeColor = Color.Red;
            }

            card.Controls.Add(lblName);
            card.Controls.Add(lblExp);
            card.Controls.Add(lblDesc);
            card.Controls.Add(lblStatus);

            return card;
        }
    }
}