using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace AnTam_BaoHiem.Views // (Nếu chữ Views của sếp bị sai thì sếp nhớ sửa lại cho đúng tên thư mục nhé)
{
    public partial class frmThanhCong : Form
    {
        // Tạo 4 biến để hứng dữ liệu
        private string _hinhThuc;
        private string _maHD;
        private string _tenKH;
        private string _soTien;

        // Cổng nhận 4 thông tin
        public frmThanhCong(string hinhThuc, string maHD, string tenKH, string soTien)
        {
            InitializeComponent();
            _hinhThuc = hinhThuc;
            _maHD = maHD;
            _tenKH = tenKH;
            _soTien = soTien;
        }

        // ---------- TỪ ĐOẠN NÀY TRỞ XUỐNG SẾP GIỮ NGUYÊN CÁC HÀM CŨ CỦA SẾP ----------

        // Cổng nhận 4 thông tin từ Form trước
  

            // 4. Khi form bật lên thì chạy thiết lập giao diện
            private void frmThanhCong_Load(object sender, EventArgs e)
        {
            // Kiểm tra xem khách thanh toán kiểu gì
            if (_hinhThuc == "Tiền mặt") // <--- SỬA CHỮ NÀY ĐÂY SẾP
            {
                lblTieuDe.Text = "ĐẶT LỊCH THÀNH CÔNG!";
                lblMoTa.Text = "Yêu cầu của bạn đã được ghi nhận. Vui lòng đến đúng giờ hẹn.";
                btnTaiHoaDon.Visible = false; // Ẩn nút tải hóa đơn
            }
            else
            {
                lblTieuDe.Text = "XÁC NHẬN THÀNH CÔNG!";
                lblMoTa.Text = "Giao dịch của bạn đã được ghi nhận vào hệ thống.";
                btnTaiHoaDon.Visible = true; // Hiện nút tải hóa đơn
            }

            // In mã hợp đồng ra màn hình
            lblMaHD.Text = "Mã hợp đồng: " + _maHD;
        }

        // 5. Nút Quay lại
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close(); // Đóng form này
        }

        // 6. Nút Tải Hóa Đơn
        private void btnTaiHoaDon_Click(object sender, EventArgs e)
        {
            
            
            // 1. Mở cửa sổ cho sếp chọn nơi lưu file PDF
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "PDF file (*.pdf)|*.pdf";
            sfd.FileName = "HoaDon_BaoHiem_" + _maHD + ".pdf"; // Tên file mặc định

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // 2. Lấy Font Arial của Windows để gõ tiếng Việt không bị lỗi
                    string fontPath = Environment.GetFolderPath(Environment.SpecialFolder.Fonts) + "\\arial.ttf";
                    BaseFont bf = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                    iTextSharp.text.Font fontTieuDe = new iTextSharp.text.Font(bf, 18, iTextSharp.text.Font.BOLD);
                    iTextSharp.text.Font fontThuong = new iTextSharp.text.Font(bf, 12, iTextSharp.text.Font.NORMAL);

                    // 3. Khởi tạo tờ giấy trắng PDF (Khổ A4)
                    Document pdfDoc = new Document(PageSize.A4, 40f, 40f, 40f, 40f);
                    PdfWriter.GetInstance(pdfDoc, new FileStream(sfd.FileName, FileMode.Create));
                    pdfDoc.Open();

                    // 4. Bắt đầu vẽ chữ lên tờ giấy
                    Paragraph title1 = new Paragraph("CÔNG TY BẢO HIỂM AN TÂM", fontTieuDe);
                    title1.Alignment = Element.ALIGN_CENTER;
                    pdfDoc.Add(title1);

                    Paragraph title2 = new Paragraph("HÓA ĐƠN THANH TOÁN\n\n", fontTieuDe);
                    title2.Alignment = Element.ALIGN_CENTER;
                    pdfDoc.Add(title2);

                    // SỬA ĐÚNG 5 DÒNG NÀY ĐỂ DÙNG BIẾN MỚI
                    pdfDoc.Add(new Paragraph("Mã hợp đồng: " + _maHD, fontThuong));
                    pdfDoc.Add(new Paragraph("Tên khách hàng: " + _tenKH, fontThuong));
                    pdfDoc.Add(new Paragraph("Hình thức thanh toán: " + _hinhThuc, fontThuong));
                    pdfDoc.Add(new Paragraph("Số tiền thanh toán: " + _soTien, fontThuong));
                    pdfDoc.Add(new Paragraph("Ngày lập hóa đơn: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm"), fontThuong));

                    pdfDoc.Add(new Paragraph("\n--------------------------------------------------\n", fontThuong));

                    Paragraph footer = new Paragraph("Cảm ơn quý khách đã sử dụng dịch vụ!", fontThuong);
                    footer.Alignment = Element.ALIGN_CENTER;
                    pdfDoc.Add(footer);

                    // 5. Đóng file lại và báo thành công
                    pdfDoc.Close();
                    MessageBox.Show("Tuyệt vời! File PDF đã được xuất thành công ra máy của sếp!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ấy, có lỗi rồi: " + ex.Message, "Lỗi kỹ thuật", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // 7. Hàm rỗng để "dỗ" cái lỗi Designer lúc nãy của sếp
        private void lblTieuDe_Click(object sender, EventArgs e)
        {
            // Cứ để trống, không cần viết gì
        }
    }
}