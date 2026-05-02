CREATE DATABASE AnTamBaoHiem;
GO
USE AnTamBaoHiem;
GO

-- 1. BẢNG TÀI KHOẢN
CREATE TABLE TaiKhoan (
    TenDangNhap NVARCHAR(50) PRIMARY KEY,
    MatKhau NVARCHAR(100) NOT NULL,
    LoaiTaiKhoan NVARCHAR(20)
);

-- 2. BẢNG QUẢN LÝ CẤP BẬC
CREATE TABLE QuanLyCapBac (
    TenCap NVARCHAR(50) PRIMARY KEY,
    EXPToiThieu INT,
    MoTa NVARCHAR(MAX)
);

-- 3. BẢNG ĐỐI TÁC (Tuyệt chiêu Thống kê của sếp)
CREATE TABLE DoiTac (
    MaDoiTac NVARCHAR(50) PRIMARY KEY, -- Dùng chuỗi như AIA, BV, DUCKCOP
    TenCongTy NVARCHAR(100) NOT NULL,
    TrangThai NVARCHAR(50) DEFAULT N'Đang hợp tác'
);

-- 4. BẢNG KHÁCH HÀNG
CREATE TABLE KhachHang (
    MaKH INT IDENTITY(1,1) PRIMARY KEY,
    TenDangNhap NVARCHAR(50) FOREIGN KEY REFERENCES TaiKhoan(TenDangNhap),
    HoTen NVARCHAR(100),
    CCCD NVARCHAR(20),
    AnhCCCD NVARCHAR(255),
    SoDienThoai NVARCHAR(15),
    Email NVARCHAR(100),
    DiaChi NVARCHAR(MAX),
    EXP INT DEFAULT 0,
    TenCap NVARCHAR(50) DEFAULT N'Thường' FOREIGN KEY REFERENCES QuanLyCapBac(TenCap)
);

-- 5. BẢNG GÓI BẢO HIỂM
CREATE TABLE GoiBaoHiem (
    MaGoi NVARCHAR(50) PRIMARY KEY, 
    TenGoi NVARCHAR(200) NOT NULL,
    MucPhi DECIMAL(18, 2) NOT NULL,
    MaDoiTac NVARCHAR(50) FOREIGN KEY REFERENCES DoiTac(MaDoiTac), -- Liên kết với Đối tác
    DoiTuongApDung NVARCHAR(255),
    TrangThai NVARCHAR(50) DEFAULT N'Còn bán',
    ChuKyDongPhi NVARCHAR(50),
    SoTienBaoHiem DECIMAL(18, 2),
    EXPNhan INT, 
    MoTa NVARCHAR(MAX),
    HinhAnh NVARCHAR(255),
    ThoiHanChuan NVARCHAR(100),
    QuyenLoiChinh NVARCHAR(MAX),
    DieuKhoanLoaiTru NVARCHAR(MAX),
    NgayTao DATETIME DEFAULT GETDATE()
);

-- 6. BẢNG HỢP ĐỒNG (Đã thêm các cột để sếp code Thanh Toán)
CREATE TABLE HopDong (
    MaHD NVARCHAR(50) PRIMARY KEY,
    MaKH INT FOREIGN KEY REFERENCES KhachHang(MaKH),
    MaGoi NVARCHAR(50) FOREIGN KEY REFERENCES GoiBaoHiem(MaGoi),
    NgayKy DATETIME DEFAULT GETDATE(),
    NgayHetHan DATETIME,
    TongTien DECIMAL(18, 2),
    HinhThucThanhToan NVARCHAR(50), -- Nơi lưu "Trả 1 lần", "Trả góp", "Tiền mặt" từ C# của sếp
    TrangThai NVARCHAR(100) -- 'Chờ thanh toán', 'Đã thanh toán', 'Hết hạn'
);

-- 7. BẢNG BỒI THƯỜNG
CREATE TABLE BoiThuong (
    MaYeuCau INT IDENTITY(1,1) PRIMARY KEY,
    MaHD NVARCHAR(50) FOREIGN KEY REFERENCES HopDong(MaHD),
    NoiDungYeuCau NVARCHAR(MAX),
    AnhMinhChung NVARCHAR(255), 
    LyDoTuChoi NVARCHAR(MAX),   
    NgayGui DATETIME DEFAULT GETDATE(),
    TrangThai NVARCHAR(50) 
);
GO

-- 8. TRIGGER TỰ ĐỘNG CỘNG EXP KHI THANH TOÁN (Từ phần của bạn số 3)
CREATE OR ALTER TRIGGER trg_CongEXP ON HopDong AFTER UPDATE AS
BEGIN
    IF UPDATE(TrangThai)
    BEGIN
        UPDATE kh SET EXP = kh.EXP + gb.EXPNhan
        FROM KhachHang kh
        JOIN inserted i ON kh.MaKH = i.MaKH
        JOIN GoiBaoHiem gb ON gb.MaGoi = i.MaGoi
        WHERE i.TrangThai = N'Đã thanh toán'
    END
END
GO