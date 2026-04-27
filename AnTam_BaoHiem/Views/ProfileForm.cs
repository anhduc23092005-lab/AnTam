using AnTam_BaoHiem.Helpers;
using Guna.UI2.WinForms;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

public partial class ProfileForm : Form
{
    private string currentUser;
    private LoginController controller;
    private string originalHoTen, originalSoDienThoai, originalEmail;

    public ProfileForm(string username)
    {
        InitializeComponent();
        currentUser = username;
        controller = new LoginController();
        LoadUserInfo();
        SetControlsEnabled(false);
        UpdateButtonsState(false);
    }

    public ProfileForm()
    {
    }

    private void LoadUserInfo()
    {
        using (var conn = DatabaseHelper.GetConnection())
        {
            conn.Open();
            string sql = "SELECT HoTen, SoDienThoai, Email, CCCD FROM KhachHang WHERE TenDangNhap=@u";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@u", currentUser);
            var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                txtHoTen.Text = reader["HoTen"].ToString();
                txtSoDienThoai.Text = reader["SoDienThoai"].ToString();
                txtEmail.Text = reader["Email"].ToString();
                txtCCCD.Text = reader["CCCD"].ToString();

                // Lưu giá trị gốc
                originalHoTen = txtHoTen.Text;
                originalSoDienThoai = txtSoDienThoai.Text;
                originalEmail = txtEmail.Text;

                txtCCCD.Enabled = false;
            }
        }
    }

    private void SetControlsEnabled(bool enabled)
    {
        txtHoTen.Enabled = enabled;
        txtSoDienThoai.Enabled = enabled;
        txtEmail.Enabled = enabled;
    }

    private void UpdateButtonsState(bool isEditing)
    {
        btnChinhSua.Visible = !isEditing;
        btnLuu.Visible = isEditing;
        btnHuy.Visible = isEditing;
    }

    private void btnChinhSua_Click(object sender, EventArgs e)
    {
        SetControlsEnabled(true);
        UpdateButtonsState(true);
    }

    private void btnLuu_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtHoTen.Text) || 
            string.IsNullOrWhiteSpace(txtSoDienThoai.Text) || 
            string.IsNullOrWhiteSpace(txtEmail.Text))
        {
            MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        // Gọi hàm cập nhật dữ liệu
        controller.UpdateProfile(currentUser, txtHoTen.Text, txtSoDienThoai.Text, txtEmail.Text);
        MessageBox.Show("Thông tin đã được cập nhật", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

        // Cập nhật giá trị gốc
        originalHoTen = txtHoTen.Text;
        originalSoDienThoai = txtSoDienThoai.Text;
        originalEmail = txtEmail.Text;

        SetControlsEnabled(false);
        UpdateButtonsState(false);
    }

    private void btnHuy_Click(object sender, EventArgs e)
    {
        // Hoàn nguyên dữ liệu
        txtHoTen.Text = originalHoTen;
        txtSoDienThoai.Text = originalSoDienThoai;
        txtEmail.Text = originalEmail;

        SetControlsEnabled(false);
        UpdateButtonsState(false);
    }
}