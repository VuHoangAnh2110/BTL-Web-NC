/*
 Navicat Premium Dump SQL

 Source Server         : local_sql_server
 Source Server Type    : SQL Server
 Source Server Version : 16001000 (16.00.1000)
 Source Host           : DESKTOP-SHLIJ6C:1433
 Source Catalog        : giaodichvieclam
 Source Schema         : dbo

 Target Server Type    : SQL Server
 Target Server Version : 16001000 (16.00.1000)
 File Encoding         : 65001

 Date: 08/04/2025 18:59:44
*/


-- ----------------------------
-- Table structure for tblBanner
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[tblBanner]') AND type IN ('U'))
	DROP TABLE [dbo].[tblBanner]
GO

CREATE TABLE [dbo].[tblBanner] (
  [PK_sMaBanner] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [sTieuDe] nvarchar(225) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [sMoTa] nvarchar(max) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [sDuongDanAnh] nvarchar(225) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [sLienKet] nvarchar(225) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [tNgayTao] datetime DEFAULT getdate() NULL
)
GO

ALTER TABLE [dbo].[tblBanner] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of tblBanner
-- ----------------------------
INSERT INTO [dbo].[tblBanner] ([PK_sMaBanner], [sTieuDe], [sMoTa], [sDuongDanAnh], [sLienKet], [tNgayTao]) VALUES (N'BN001', N'Tìm việc nhanh chóng', N'Hàng ngàn công việc đang chờ bạn', N'/img/banner/banner1.jpg', NULL, N'2025-04-08 18:50:56.953')
GO

INSERT INTO [dbo].[tblBanner] ([PK_sMaBanner], [sTieuDe], [sMoTa], [sDuongDanAnh], [sLienKet], [tNgayTao]) VALUES (N'BN002', N'Tuyển dụng hiệu quả', N'Kết nối với ứng viên tiềm năng', N'/img/banner/banner2.jpg', NULL, N'2025-04-08 18:51:40.297')
GO

INSERT INTO [dbo].[tblBanner] ([PK_sMaBanner], [sTieuDe], [sMoTa], [sDuongDanAnh], [sLienKet], [tNgayTao]) VALUES (N'BN003', N'Cơ hội nghề nghiệp', N'Phát triển sự nghiệp của bạn', N'/img/banner/banner3.jpg', NULL, N'2025-04-08 18:52:14.847')
GO

INSERT INTO [dbo].[tblBanner] ([PK_sMaBanner], [sTieuDe], [sMoTa], [sDuongDanAnh], [sLienKet], [tNgayTao]) VALUES (N'BN004', N'Tìm kiếm cơ hội', N'Cùng tương tác và phát triển mạnh mẽ', N'/img/banner/banner4.jpg', NULL, N'2025-04-08 18:53:42.260')
GO


-- ----------------------------
-- Table structure for tblCongTy
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[tblCongTy]') AND type IN ('U'))
	DROP TABLE [dbo].[tblCongTy]
GO

CREATE TABLE [dbo].[tblCongTy] (
  [PK_sMaCongTy] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [FK_sTenTaiKhoan] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [sTenCongTy] nvarchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [sDiaChi] nvarchar(max) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [sMoTa] nvarchar(max) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [sWebsite] nvarchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [sLogo] nvarchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL
)
GO

ALTER TABLE [dbo].[tblCongTy] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of tblCongTy
-- ----------------------------

-- ----------------------------
-- Table structure for tblCongViec
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[tblCongViec]') AND type IN ('U'))
	DROP TABLE [dbo].[tblCongViec]
GO

CREATE TABLE [dbo].[tblCongViec] (
  [PK_sMaCongViec] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [FK_sMaCongTy] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [sTieuDe] nvarchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [sMoTa] nvarchar(max) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [sDiaDiem] nvarchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [dMucLuong] decimal(10,2)  NULL,
  [sLoaiHinh] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [tNgayDang] datetime DEFAULT getdate() NULL,
  [sTrangThai] nvarchar(25) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL
)
GO

ALTER TABLE [dbo].[tblCongViec] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of tblCongViec
-- ----------------------------

-- ----------------------------
-- Table structure for tblFile
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[tblFile]') AND type IN ('U'))
	DROP TABLE [dbo].[tblFile]
GO

CREATE TABLE [dbo].[tblFile] (
  [PK_sMaFile] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [sTenfile] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [FK_sTenTaiKhoan] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [sLoaiFile] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [sDuongDan] nvarchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [tNgayTaiLen] datetime DEFAULT getdate() NULL
)
GO

ALTER TABLE [dbo].[tblFile] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of tblFile
-- ----------------------------

-- ----------------------------
-- Table structure for tblHoSoUngVien
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[tblHoSoUngVien]') AND type IN ('U'))
	DROP TABLE [dbo].[tblHoSoUngVien]
GO

CREATE TABLE [dbo].[tblHoSoUngVien] (
  [PK_sMaHoSo] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [FK_sTenTaiKhoan] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [sGioiThieu] nvarchar(max) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [sKyNang] nvarchar(max) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [sKinhNghiem] nvarchar(max) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [FK_sMaFile] nvarchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [sCV] nvarchar(1) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL
)
GO

ALTER TABLE [dbo].[tblHoSoUngVien] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of tblHoSoUngVien
-- ----------------------------

-- ----------------------------
-- Table structure for tblTaiKhoan
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[tblTaiKhoan]') AND type IN ('U'))
	DROP TABLE [dbo].[tblTaiKhoan]
GO

CREATE TABLE [dbo].[tblTaiKhoan] (
  [PK_sTenTaiKhoan] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [sHoTen] nvarchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [sEmail] nvarchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [sMatKhau] nvarchar(max) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [sSoDienThoai] varchar(20) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [sDiaChi] nvarchar(max) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [sAnhDaiDien] nvarchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [sVaiTro] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS DEFAULT 'user' NOT NULL,
  [iTrangThai] int DEFAULT 1 NOT NULL,
  [tNgayTao] datetime DEFAULT getdate() NULL,
  [tNgayCapNhat] datetime DEFAULT getdate() NULL
)
GO

ALTER TABLE [dbo].[tblTaiKhoan] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of tblTaiKhoan
-- ----------------------------
INSERT INTO [dbo].[tblTaiKhoan] ([PK_sTenTaiKhoan], [sHoTen], [sEmail], [sMatKhau], [sSoDienThoai], [sDiaChi], [sAnhDaiDien], [sVaiTro], [iTrangThai], [tNgayTao], [tNgayCapNhat]) VALUES (N'admin', N'admin', N'22a1001d0027@students.hou.edu.vn', N'$2a$11$AgAkpxotMtaMNz88Uo6q7emgH0YzxBsMm6peX7AEIpSdYXxotK5FS', NULL, NULL, NULL, N'admin', N'2', N'2025-04-08 18:57:28.143', N'2025-04-08 18:57:28.143')
GO

INSERT INTO [dbo].[tblTaiKhoan] ([PK_sTenTaiKhoan], [sHoTen], [sEmail], [sMatKhau], [sSoDienThoai], [sDiaChi], [sAnhDaiDien], [sVaiTro], [iTrangThai], [tNgayTao], [tNgayCapNhat]) VALUES (N'vhanh2k4', N'Vũ Hoàng Anh', N'vhanh2k4@gmail.com', N'$2a$11$AgAkpxotMtaMNz88Uo6q7emgH0YzxBsMm6peX7AEIpSdYXxotK5FS', NULL, NULL, NULL, N'user', N'2', N'2025-04-08 18:55:49.903', N'2025-04-08 18:55:49.903')
GO


-- ----------------------------
-- Table structure for tblThongBao
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[tblThongBao]') AND type IN ('U'))
	DROP TABLE [dbo].[tblThongBao]
GO

CREATE TABLE [dbo].[tblThongBao] (
  [PK_sThongBao] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [FK_sTenTaiKhoan] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [sTieuDe] nvarchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [sNoiDung] nvarchar(max) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [sLoaiThongBao] nvarchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [tNgayThongBao] datetime DEFAULT getdate() NULL,
  [bDaXem] bit DEFAULT 0 NULL,
  [FK_sMaCongTy] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [FK_sMaCongViec] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL
)
GO

ALTER TABLE [dbo].[tblThongBao] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of tblThongBao
-- ----------------------------

-- ----------------------------
-- Table structure for tblUngTuyen
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[tblUngTuyen]') AND type IN ('U'))
	DROP TABLE [dbo].[tblUngTuyen]
GO

CREATE TABLE [dbo].[tblUngTuyen] (
  [PK_sMaUngTuyen] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [FK_sTenTaiKhoan] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [FK_sMaCongViec] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [tNgayUngTuyen] datetime DEFAULT getdate() NULL,
  [sTrangThai] nvarchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL
)
GO

ALTER TABLE [dbo].[tblUngTuyen] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of tblUngTuyen
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table tblBanner
-- ----------------------------
ALTER TABLE [dbo].[tblBanner] ADD CONSTRAINT [PK__tblBanne__816110D6E38AA608] PRIMARY KEY CLUSTERED ([PK_sMaBanner])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Uniques structure for table tblCongTy
-- ----------------------------
ALTER TABLE [dbo].[tblCongTy] ADD CONSTRAINT [UQ__tblCongT__70BC7A8D56DC5763] UNIQUE NONCLUSTERED ([FK_sTenTaiKhoan] ASC)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table tblCongTy
-- ----------------------------
ALTER TABLE [dbo].[tblCongTy] ADD CONSTRAINT [PK__tblCongT__04F94CDE3EC68717] PRIMARY KEY CLUSTERED ([PK_sMaCongTy])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table tblCongViec
-- ----------------------------
ALTER TABLE [dbo].[tblCongViec] ADD CONSTRAINT [PK__tblCongV__CFD45EE4E24F9FFA] PRIMARY KEY CLUSTERED ([PK_sMaCongViec])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table tblFile
-- ----------------------------
ALTER TABLE [dbo].[tblFile] ADD CONSTRAINT [PK__tblFile__72E6F5FDE4E4BA65] PRIMARY KEY CLUSTERED ([PK_sMaFile])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table tblHoSoUngVien
-- ----------------------------
ALTER TABLE [dbo].[tblHoSoUngVien] ADD CONSTRAINT [PK__tblHoSoU__9B38FCA34A54A15B] PRIMARY KEY CLUSTERED ([PK_sMaHoSo])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Uniques structure for table tblTaiKhoan
-- ----------------------------
ALTER TABLE [dbo].[tblTaiKhoan] ADD CONSTRAINT [UQ__tblTaiKh__07DACB08B2BEBFA6] UNIQUE NONCLUSTERED ([sEmail] ASC)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table tblTaiKhoan
-- ----------------------------
ALTER TABLE [dbo].[tblTaiKhoan] ADD CONSTRAINT [PK__tblTaiKh__6C1590075BB8BE0E] PRIMARY KEY CLUSTERED ([PK_sTenTaiKhoan])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table tblThongBao
-- ----------------------------
ALTER TABLE [dbo].[tblThongBao] ADD CONSTRAINT [PK__tblThong__DAA95B75B22C813F] PRIMARY KEY CLUSTERED ([PK_sThongBao])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table tblUngTuyen
-- ----------------------------
ALTER TABLE [dbo].[tblUngTuyen] ADD CONSTRAINT [PK__tblUngTu__AA01AEB3EE3CFFC0] PRIMARY KEY CLUSTERED ([PK_sMaUngTuyen])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Foreign Keys structure for table tblCongTy
-- ----------------------------
ALTER TABLE [dbo].[tblCongTy] ADD CONSTRAINT [fk_congty_taikhoan] FOREIGN KEY ([FK_sTenTaiKhoan]) REFERENCES [dbo].[tblTaiKhoan] ([PK_sTenTaiKhoan]) ON DELETE CASCADE ON UPDATE CASCADE
GO


-- ----------------------------
-- Foreign Keys structure for table tblCongViec
-- ----------------------------
ALTER TABLE [dbo].[tblCongViec] ADD CONSTRAINT [fk_congviec_congty] FOREIGN KEY ([FK_sMaCongTy]) REFERENCES [dbo].[tblCongTy] ([PK_sMaCongTy]) ON DELETE CASCADE ON UPDATE CASCADE
GO


-- ----------------------------
-- Foreign Keys structure for table tblFile
-- ----------------------------
ALTER TABLE [dbo].[tblFile] ADD CONSTRAINT [fk_file_taikhoan] FOREIGN KEY ([FK_sTenTaiKhoan]) REFERENCES [dbo].[tblTaiKhoan] ([PK_sTenTaiKhoan]) ON DELETE CASCADE ON UPDATE CASCADE
GO


-- ----------------------------
-- Foreign Keys structure for table tblHoSoUngVien
-- ----------------------------
ALTER TABLE [dbo].[tblHoSoUngVien] ADD CONSTRAINT [fk_hoso_taikhoan] FOREIGN KEY ([FK_sTenTaiKhoan]) REFERENCES [dbo].[tblTaiKhoan] ([PK_sTenTaiKhoan]) ON DELETE CASCADE ON UPDATE CASCADE
GO


-- ----------------------------
-- Foreign Keys structure for table tblThongBao
-- ----------------------------
ALTER TABLE [dbo].[tblThongBao] ADD CONSTRAINT [fk_thongbao_taikhoan] FOREIGN KEY ([FK_sTenTaiKhoan]) REFERENCES [dbo].[tblTaiKhoan] ([PK_sTenTaiKhoan]) ON DELETE CASCADE ON UPDATE CASCADE
GO

ALTER TABLE [dbo].[tblThongBao] ADD CONSTRAINT [fk_thongbao_congty] FOREIGN KEY ([FK_sMaCongTy]) REFERENCES [dbo].[tblCongTy] ([PK_sMaCongTy]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO

ALTER TABLE [dbo].[tblThongBao] ADD CONSTRAINT [fk_thongbao_congviec] FOREIGN KEY ([FK_sMaCongViec]) REFERENCES [dbo].[tblCongViec] ([PK_sMaCongViec]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO


-- ----------------------------
-- Foreign Keys structure for table tblUngTuyen
-- ----------------------------
ALTER TABLE [dbo].[tblUngTuyen] ADD CONSTRAINT [fk_ungtuyen_taikhoan] FOREIGN KEY ([FK_sTenTaiKhoan]) REFERENCES [dbo].[tblTaiKhoan] ([PK_sTenTaiKhoan]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO

ALTER TABLE [dbo].[tblUngTuyen] ADD CONSTRAINT [fk_ungtuyen_congviec] FOREIGN KEY ([FK_sMaCongViec]) REFERENCES [dbo].[tblCongViec] ([PK_sMaCongViec]) ON DELETE CASCADE ON UPDATE CASCADE
GO

