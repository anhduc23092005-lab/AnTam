-- 1. Bảng Tài khoản (Dùng cho Đăng nhập/Đăng ký)
CREATE TABLE TaiKhoan (
    TenDangNhap NVARCHAR(50) PRIMARY KEY,
    MatKhau NVARCHAR(100) NOT NULL,
    LoaiTaiKhoan NVARCHAR(20) -- 'Admin' hoặc 'KhachHang'
);

-- 2. Bảng Khách hàng (Lưu thông tin cá nhân)
CREATE TABLE KhachHang (
    MaKH INT IDENTITY(1,1) PRIMARY KEY,
    TenDangNhap NVARCHAR(50) FOREIGN KEY REFERENCES TaiKhoan(TenDangNhap),
    HoTen NVARCHAR(100),
    CCCD NVARCHAR(20), -- Lưu số CCCD
    AnhCCCD NVARCHAR(255), -- Lưu đường dẫn ảnh CCCD
    SoDienThoai NVARCHAR(15),
    Email NVARCHAR(100)
);

-- 3. Bảng Gói bảo hiểm (Xe cộ, Thất nghiệp, Tai nạn, Nhân thọ, Doanh nghiệp)
CREATE TABLE GoiBaoHiem (
    MaGoi INT IDENTITY(1,1) PRIMARY KEY,
    TenGoi NVARCHAR(100),
    LoaiGoi NVARCHAR(50), -- VD: 'Bảo hiểm xe cộ'
    GiaTien DECIMAL(18, 2),
    MoTa NVARCHAR(MAX),
    HinhAnh NVARCHAR(255) -- Lưu ảnh gói bảo hiểm để hiển thị
);

-- 4. Bảng Hợp đồng (Lưu lịch sử mua hàng)
CREATE TABLE HopDong (
    MaHD INT IDENTITY(1,1) PRIMARY KEY,
    MaKH INT FOREIGN KEY REFERENCES KhachHang(MaKH),
    MaGoi INT FOREIGN KEY REFERENCES GoiBaoHiem(MaGoi),
    NgayMua DATETIME DEFAULT GETDATE(),
    TrangThai NVARCHAR(50) -- 'Chờ thanh toán', 'Đã thanh toán'
);

-- 5. Bảng Bồi thường
CREATE TABLE BoiThuong (
    MaYeuCau INT IDENTITY(1,1) PRIMARY KEY,
    MaHD INT FOREIGN KEY REFERENCES HopDong(MaHD),
    NoiDungYeuCau NVARCHAR(MAX),
    NgayGui DATETIME DEFAULT GETDATE(),
    TrangThai NVARCHAR(50) -- 'Đang xử lý', 'Đã duyệt', 'Từ chối'
);