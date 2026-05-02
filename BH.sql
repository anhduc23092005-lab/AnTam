CREATE DATABASE AnTam_BaoHiem;
GO

USE AnTam_BaoHiem;
GO

-- =========================================
-- 1. TÀI KHOẢN
-- =========================================
CREATE TABLE TaiKhoan (
    TenDangNhap NVARCHAR(50) PRIMARY KEY,
    MatKhau NVARCHAR(100) NOT NULL,
    LoaiTaiKhoan NVARCHAR(20)
);

INSERT INTO TaiKhoan VALUES
('admin', 'admin123', 'Admin'),
('user1', '123456', 'KhachHang'),
('user2', '123456', 'KhachHang');

-- =========================================
-- 2. KHÁCH HÀNG (EXP + TEN CAP)
-- =========================================
CREATE TABLE KhachHang (
    MaKH INT IDENTITY(1,1) PRIMARY KEY,
    TenDangNhap NVARCHAR(50) FOREIGN KEY REFERENCES TaiKhoan(TenDangNhap),
    HoTen NVARCHAR(100),
    CCCD NVARCHAR(20),
    AnhCCCD NVARCHAR(255),
    SoDienThoai NVARCHAR(15),
    Email NVARCHAR(100),
    EXP INT DEFAULT 0,
    TenCap NVARCHAR(50) DEFAULT N'Thường'
);

INSERT INTO KhachHang 
(TenDangNhap, HoTen, CCCD, SoDienThoai, Email, EXP, TenCap) VALUES
('user1', N'Nguyễn Văn A', '123456789', '0901111111', 'a@gmail.com', 5000, N'Vàng'),
('user2', N'Trần Văn B', '987654321', '0902222222', 'b@gmail.com', 0, N'Thường');

-- =========================================
-- 3. GÓI BẢO HIỂM
-- =========================================
CREATE TABLE GoiBaoHiem (
    MaGoi INT IDENTITY(1,1) PRIMARY KEY,
    TenGoi NVARCHAR(100),
    LoaiGoi NVARCHAR(50),
    GiaTien DECIMAL(18,2),
    MoTa NVARCHAR(MAX),
    HinhAnh NVARCHAR(255),
    EXPNhan INT
);

INSERT INTO GoiBaoHiem (TenGoi, LoaiGoi, GiaTien, MoTa, EXPNhan) VALUES
(N'Bảo hiểm xe cơ bản', N'Xe cộ', 500000, N'Bảo hiểm xe máy', 50),
(N'Bảo hiểm tai nạn', N'Cá nhân', 1000000, N'Bảo hiểm tai nạn', 120),
(N'Bảo hiểm nhân thọ', N'Nhân thọ', 3000000, N'Bảo hiểm dài hạn', 300);

-- =========================================
-- 4. HỢP ĐỒNG
-- =========================================
CREATE TABLE HopDong (
    MaHD INT IDENTITY(1,1) PRIMARY KEY,
    MaKH INT FOREIGN KEY REFERENCES KhachHang(MaKH),
    MaGoi INT FOREIGN KEY REFERENCES GoiBaoHiem(MaGoi),
    NgayMua DATETIME DEFAULT GETDATE(),
    TrangThai NVARCHAR(50)
);

-- =========================================
-- 5. QUẢN LÝ CẤP
-- =========================================
CREATE TABLE QuanLyCapBac (
    TenCap NVARCHAR(50) PRIMARY KEY,
    EXPToiThieu INT,
    MoTa NVARCHAR(MAX)
);

INSERT INTO QuanLyCapBac VALUES
(N'Thường', 0, N'Không có ưu đãi'),
(N'Bạc', 1000, N'Giảm 10%'),
(N'Vàng', 3000, N'Giảm 20%'),
(N'Kim Cương', 6000, N'VIP');

-- 6. Bảng Bồi thường
CREATE TABLE BoiThuong (
    MaYeuCau INT IDENTITY(1,1) PRIMARY KEY,
    MaHD INT FOREIGN KEY REFERENCES HopDong(MaHD),
    NoiDungYeuCau NVARCHAR(MAX),
    NgayGui DATETIME DEFAULT GETDATE(),
    TrangThai NVARCHAR(50) -- 'Đang xử lý', 'Đã duyệt', 'Từ chối'
);

-- =========================================
-- 🔥 TRIGGER 1: CỘNG EXP
-- =========================================
GO
CREATE OR ALTER TRIGGER trg_CongEXP
ON HopDong
AFTER INSERT
AS
BEGIN
    UPDATE kh
    SET EXP = kh.EXP + gb.EXPNhan
    FROM KhachHang kh
    JOIN inserted i ON kh.MaKH = i.MaKH
    JOIN GoiBaoHiem gb ON gb.MaGoi = i.MaGoi
    WHERE i.TrangThai = N'Đã thanh toán'
END
GO

-- =========================================
-- 🔥 TRIGGER 2: UPDATE TEN CAP
-- =========================================
GO
CREATE OR ALTER TRIGGER trg_UpdateCap
ON KhachHang
AFTER UPDATE
AS
BEGIN
    IF UPDATE(EXP)
    BEGIN
        UPDATE kh
        SET TenCap = (
            SELECT TOP 1 cb.TenCap
            FROM QuanLyCapBac cb
            WHERE kh.EXP >= cb.EXPToiThieu
            ORDER BY cb.EXPToiThieu DESC
        )
        FROM KhachHang kh
        JOIN inserted i ON kh.MaKH = i.MaKH
    END
END
GO