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

 Date: 19/03/2025 18:05:19
*/


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
  [FK_sMaCongTy] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [sTieuDe] nvarchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [sMoTa] nvarchar(max) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [sDiaDiem] nvarchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [fMucLuong] float(53)  NULL,
  [sLoaiHinh] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [tNgayDang] datetime DEFAULT getdate() NULL
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
  [sTenfile] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [FK_sTenTaiKhoan] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
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
  [FK_sTenTaiKhoan] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [sGioiThieu] nvarchar(max) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [sKyNang] nvarchar(max) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [sKinhNghiem] nvarchar(max) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [FK_sMaFile] nvarchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL
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
  [sVaiTro] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS DEFAULT 'ung_vien' NULL,
  [TrangThai] bit DEFAULT 1 NULL,
  [tNgayTao] datetime DEFAULT getdate() NULL,
  [tNgayCapNhat] datetime DEFAULT getdate() NULL
)
GO

ALTER TABLE [dbo].[tblTaiKhoan] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of tblTaiKhoan
-- ----------------------------

-- ----------------------------
-- Table structure for tblThongBao
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[tblThongBao]') AND type IN ('U'))
	DROP TABLE [dbo].[tblThongBao]
GO

CREATE TABLE [dbo].[tblThongBao] (
  [PK_sThongBao] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [FK_sTenTaiKhoan] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [sTieuDe] nvarchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [sNoiDung] nvarchar(max) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [sLoaiThongBao] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [tNgayTao] datetime DEFAULT getdate() NULL
)
GO

ALTER TABLE [dbo].[tblThongBao] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of tblThongBao
-- ----------------------------

-- ----------------------------
-- Uniques structure for table tblCongTy
-- ----------------------------
ALTER TABLE [dbo].[tblCongTy] ADD CONSTRAINT [UQ__tblCongT__70BC7A8DC153F1D0] UNIQUE NONCLUSTERED ([FK_sTenTaiKhoan] ASC)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table tblCongTy
-- ----------------------------
ALTER TABLE [dbo].[tblCongTy] ADD CONSTRAINT [PK__tblCongT__04F94CDED86F2EF6] PRIMARY KEY CLUSTERED ([PK_sMaCongTy])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table tblCongViec
-- ----------------------------
ALTER TABLE [dbo].[tblCongViec] ADD CONSTRAINT [PK__tblCongV__CFD45EE4B4467F1A] PRIMARY KEY CLUSTERED ([PK_sMaCongViec])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table tblFile
-- ----------------------------
ALTER TABLE [dbo].[tblFile] ADD CONSTRAINT [PK__tblFile__72E6F5FDB49302CD] PRIMARY KEY CLUSTERED ([PK_sMaFile])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table tblHoSoUngVien
-- ----------------------------
ALTER TABLE [dbo].[tblHoSoUngVien] ADD CONSTRAINT [PK__tblHoSoU__9B38FCA320990ED0] PRIMARY KEY CLUSTERED ([PK_sMaHoSo])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Uniques structure for table tblTaiKhoan
-- ----------------------------
ALTER TABLE [dbo].[tblTaiKhoan] ADD CONSTRAINT [UQ__tblTaiKh__07DACB08C55DC0F4] UNIQUE NONCLUSTERED ([sEmail] ASC)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table tblTaiKhoan
-- ----------------------------
ALTER TABLE [dbo].[tblTaiKhoan] ADD CONSTRAINT [PK__tblTaiKh__6C1590076659EA98] PRIMARY KEY CLUSTERED ([PK_sTenTaiKhoan])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table tblThongBao
-- ----------------------------
ALTER TABLE [dbo].[tblThongBao] ADD CONSTRAINT [PK__tblThong__DAA95B75321CFD70] PRIMARY KEY CLUSTERED ([PK_sThongBao])
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

