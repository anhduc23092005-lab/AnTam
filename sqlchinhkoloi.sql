USE [master]
GO

-- 1. Xóa database cũ nếu đã tồn tại để tránh lỗi
IF EXISTS (SELECT name FROM sys.databases WHERE name = N'AnTam_DB')
BEGIN
    ALTER DATABASE [AnTam_DB] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE [AnTam_DB];
END
GO

-- 2. Tạo Database mới
CREATE DATABASE [AnTam_DB]
GO

USE [AnTam_DB]
GO

-- 3. Tạo bảng TaiKhoan
CREATE TABLE [dbo].[TaiKhoan](
	[TenDangNhap] [nvarchar](50) NOT NULL,
	[MatKhau] [nvarchar](100) NOT NULL,
	[LoaiTaiKhoan] [nvarchar](20) NULL,
PRIMARY KEY CLUSTERED ([TenDangNhap] ASC)
) 
GO

-- 4. Tạo bảng KhachHang
CREATE TABLE [dbo].[KhachHang](
	[MaKH] [int] IDENTITY(1,1) NOT NULL,
	[TenDangNhap] [nvarchar](50) NULL,
	[HoTen] [nvarchar](100) NULL,
	[CCCD] [nvarchar](20) NULL,
	[AnhCCCD] [nvarchar](255) NULL,
	[SoDienThoai] [nvarchar](15) NULL,
	[Email] [nvarchar](100) NULL,
	[CapBac] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED ([MaKH] ASC)
) 
GO

-- 5. Tạo bảng GoiBaoHiem
CREATE TABLE [dbo].[GoiBaoHiem](
	[MaGoi] [int] IDENTITY(1,1) NOT NULL,
	[TenGoi] [nvarchar](100) NULL,
	[LoaiGoi] [nvarchar](50) NULL,
	[GiaTien] [decimal](18, 2) NULL,
	[MoTa] [nvarchar](max) NULL,
	[HinhAnh] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED ([MaGoi] ASC)
) 
GO

-- 6. Tạo bảng HopDong
CREATE TABLE [dbo].[HopDong](
	[MaHD] [int] IDENTITY(1,1) NOT NULL,
	[MaKH] [int] NULL,
	[MaGoi] [int] NULL,
	[NgayMua] [datetime] DEFAULT (getdate()) NULL,
	[TrangThai] [nvarchar](50) NULL,
	[TongTien] [decimal](18, 2) NULL,
PRIMARY KEY CLUSTERED ([MaHD] ASC)
) 
GO

-- 7. Tạo bảng BoiThuong (Đã bao gồm sẵn 2 cột Ảnh và Lý do từ chối)
CREATE TABLE [dbo].[BoiThuong](
	[MaYeuCau] [int] IDENTITY(1,1) NOT NULL,
	[MaHD] [int] NULL,
	[NoiDungYeuCau] [nvarchar](max) NULL,
	[NgayGui] [datetime] DEFAULT (getdate()) NULL,
	[TrangThai] [nvarchar](50) NULL,
	[AnhMinhChung] [nvarchar](255) NULL,
	[LyDoTuChoi] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED ([MaYeuCau] ASC)
) 
GO

-- 8. Thêm Khóa Ngoại (Foreign Keys)
ALTER TABLE [dbo].[BoiThuong] WITH CHECK ADD FOREIGN KEY([MaHD]) REFERENCES [dbo].[HopDong] ([MaHD])
GO
ALTER TABLE [dbo].[HopDong] WITH CHECK ADD FOREIGN KEY([MaGoi]) REFERENCES [dbo].[GoiBaoHiem] ([MaGoi])
GO
ALTER TABLE [dbo].[HopDong] WITH CHECK ADD FOREIGN KEY([MaKH]) REFERENCES [dbo].[KhachHang] ([MaKH])
GO
ALTER TABLE [dbo].[KhachHang] WITH CHECK ADD FOREIGN KEY([TenDangNhap]) REFERENCES [dbo].[TaiKhoan] ([TenDangNhap])
GO

-- ==========================================
-- 9. THÊM DỮ LIỆU MẪU ĐỂ TEST CHƯƠNG TRÌNH
-- ==========================================

-- Thêm Gói bảo hiểm nhân thọ
SET IDENTITY_INSERT [dbo].[GoiBaoHiem] ON 
INSERT [dbo].[GoiBaoHiem] ([MaGoi], [TenGoi], [LoaiGoi], [GiaTien], [MoTa], [HinhAnh]) 
VALUES (1, N'Bảo hiểm nhân thọ', NULL, CAST(15000000.00 AS Decimal(18, 2)), NULL, NULL)
SET IDENTITY_INSERT [dbo].[GoiBaoHiem] OFF
GO

-- Thêm Khách hàng mẫu
SET IDENTITY_INSERT [dbo].[KhachHang] ON 
INSERT [dbo].[KhachHang] ([MaKH], [TenDangNhap], [HoTen], [CCCD], [AnhCCCD], [SoDienThoai], [Email], [CapBac]) 
VALUES (2, NULL, N'aNHDUC', NULL, NULL, NULL, NULL, N'Vàng')
SET IDENTITY_INSERT [dbo].[KhachHang] OFF
GO

-- Thêm 2 Hợp đồng mẫu cho khách hàng aNHDUC
SET IDENTITY_INSERT [dbo].[HopDong] ON 
INSERT [dbo].[HopDong] ([MaHD], [MaKH], [MaGoi], [NgayMua], [TrangThai], [TongTien]) 
VALUES (1, 2, 1, GETDATE(), N'Đã thanh toán', CAST(15675000.00 AS Decimal(18, 2)))

INSERT [dbo].[HopDong] ([MaHD], [MaKH], [MaGoi], [NgayMua], [TrangThai], [TongTien]) 
VALUES (2, 2, 1, GETDATE(), N'Đã thanh toán', CAST(15675000.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[HopDong] OFF
GO