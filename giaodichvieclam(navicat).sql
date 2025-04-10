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

 Date: 10/04/2025 15:25:04
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
INSERT INTO [dbo].[tblBanner] ([PK_sMaBanner], [sTieuDe], [sMoTa], [sDuongDanAnh], [sLienKet], [tNgayTao]) VALUES (N'BN001', N'Tìm việc nhanh chóng', N'Hàng ngàn công việc đang chờ bạn', N'/img/banner/banner5.jpg', NULL, N'2025-04-08 18:50:56.953')
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
  [sLogo] nvarchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [sSoDienThoai] varchar(20) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [tNgayDangKy] datetime DEFAULT getdate() NULL,
  [iTrangThai] int DEFAULT 2 NULL
)
GO

ALTER TABLE [dbo].[tblCongTy] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of tblCongTy
-- ----------------------------
INSERT INTO [dbo].[tblCongTy] ([PK_sMaCongTy], [FK_sTenTaiKhoan], [sTenCongTy], [sDiaChi], [sMoTa], [sWebsite], [sLogo], [sSoDienThoai], [tNgayDangKy], [iTrangThai]) VALUES (N'CT090425cf51', N'vhanh2k4', N'Trương Phan Đình Vũ', N'15-17 Cộng Hoà, p4, quận Tân Bình', N'Công Ty CP Người Bạn Vàng được thành lập năm 2017, tới 2018 chúng tôi tự hào trở thành đối tác chiến lược của PNJ Việt Nam.Trải qua hơn 5 năm phát triển, cho tới hiện tại chuỗi Cầm đồ và Thu mua Người Bạn Vàng đã mở rộng mô hình cầm đồ hiện đại tới trên 25 tỉnh thành với 65 cửa hàng hoạt động. Người Bạn Vàng nhận được sự yêu mến và tin tưởng từ Quý Khách Hàng bởi những lợi thế cạnh tranh sau.

Sau 5 năm hoạt động, NBV đã cho ra 2 lĩnh vực mũi nhọn là Cầm Cố (kim cương, trang sức đá quý, vàng bạc các loại, điện thoại, laptop, túi xách, đồng hồ,… và Thu Mua các sản phẩm có giá trị (kim cương, vàng, trang sức, đồng hồ cơ, túi xách hàng hiệu,….)
ĐỊA ĐIỂM HOẠT ĐỘNG 
1.Văn Phòng Miền Nam: Tầng 6, Toà nhà PLS, 240 Nguyễn Đình Chính, Phường 11, Phú Nhuận, TP. Hồ Chí Minh

2.  Văn Phòng Miền Bắc: Tầng 13, Tòa nhà M3M4, 91 Nguyễn Chí Thanh, Trung Hoà, Đống Đa, Hà Nội', N'https://nguoibanvang.vn/', N'/img/logoCongTy/Trương Phan Đình Vũ_20250409012255_logo1.png', N'0829285025', N'2025-04-09 01:22:55.527', N'2')
GO


-- ----------------------------
-- Table structure for tblCongViec
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[tblCongViec]') AND type IN ('U'))
	DROP TABLE [dbo].[tblCongViec]
GO

CREATE TABLE [dbo].[tblCongViec] (
  [PK_sMaCongViec] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [FK_sMaCongTy] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [sTieuDe] nvarchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [sMoTa] nvarchar(max) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [sDiaDiem] nvarchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [sMucLuong] nvarchar(225) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [sLoaiHinh] nvarchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [tNgayDang] datetime DEFAULT getdate() NULL,
  [sTrangThai] nvarchar(25) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [iSoLuongTuyen] int DEFAULT 1 NULL,
  [tNgayHetHan] datetime  NULL,
  [sCapBac] nvarchar(200) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [sNganhNghe] nvarchar(225) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [sQuyenLoi] nvarchar(max) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [sYeuCau] nvarchar(max) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL
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
  [iTrangThai] int DEFAULT 2 NOT NULL,
  [tNgayTao] datetime DEFAULT getdate() NULL,
  [tNgayCapNhat] datetime DEFAULT getdate() NULL
)
GO

ALTER TABLE [dbo].[tblTaiKhoan] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of tblTaiKhoan
-- ----------------------------
INSERT INTO [dbo].[tblTaiKhoan] ([PK_sTenTaiKhoan], [sHoTen], [sEmail], [sMatKhau], [sSoDienThoai], [sDiaChi], [sAnhDaiDien], [sVaiTro], [iTrangThai], [tNgayTao], [tNgayCapNhat]) VALUES (N'22a1001d0027', N'admin', N'22a1001d0027@students.hou.edu.vn', N'$2a$11$AgAkpxotMtaMNz88Uo6q7emgH0YzxBsMm6peX7AEIpSdYXxotK5FS', NULL, NULL, NULL, N'admin', N'2', N'2025-04-08 18:57:28.143', N'2025-04-10 14:23:12.833')
GO

INSERT INTO [dbo].[tblTaiKhoan] ([PK_sTenTaiKhoan], [sHoTen], [sEmail], [sMatKhau], [sSoDienThoai], [sDiaChi], [sAnhDaiDien], [sVaiTro], [iTrangThai], [tNgayTao], [tNgayCapNhat]) VALUES (N'admin', N'Quản trị viên', N'admin@gmail.com', N'$2a$11$AgAkpxotMtaMNz88Uo6q7emgH0YzxBsMm6peX7AEIpSdYXxotK5FS', NULL, NULL, NULL, N'admin', N'2', N'2025-04-10 14:33:09.827', N'2025-04-10 14:33:09.827')
GO

INSERT INTO [dbo].[tblTaiKhoan] ([PK_sTenTaiKhoan], [sHoTen], [sEmail], [sMatKhau], [sSoDienThoai], [sDiaChi], [sAnhDaiDien], [sVaiTro], [iTrangThai], [tNgayTao], [tNgayCapNhat]) VALUES (N'user', N'Người dùng ', N'user@gmail.com', N'$2a$11$AgAkpxotMtaMNz88Uo6q7emgH0YzxBsMm6peX7AEIpSdYXxotK5FS', NULL, NULL, NULL, N'user', N'2', N'2025-04-10 14:33:46.767', N'2025-04-10 14:33:46.767')
GO

INSERT INTO [dbo].[tblTaiKhoan] ([PK_sTenTaiKhoan], [sHoTen], [sEmail], [sMatKhau], [sSoDienThoai], [sDiaChi], [sAnhDaiDien], [sVaiTro], [iTrangThai], [tNgayTao], [tNgayCapNhat]) VALUES (N'vhanh2k4', N'Vũ Hoàng Anh', N'vhanh2k4@gmail.com', N'$2a$11$AgAkpxotMtaMNz88Uo6q7emgH0YzxBsMm6peX7AEIpSdYXxotK5FS', NULL, NULL, NULL, N'user', N'2', N'2025-04-08 18:55:49.903', N'2025-04-10 14:09:55.250')
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

