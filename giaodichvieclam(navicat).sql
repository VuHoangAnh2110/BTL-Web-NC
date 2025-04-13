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

 Date: 14/04/2025 00:34:34
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

INSERT INTO [dbo].[tblCongTy] ([PK_sMaCongTy], [FK_sTenTaiKhoan], [sTenCongTy], [sDiaChi], [sMoTa], [sWebsite], [sLogo], [sSoDienThoai], [tNgayDangKy], [iTrangThai]) VALUES (N'CT100425ae98', N'nguoidung5', N'Hệ Thống MEGA HOLDING', N'34 Bạch Đằng, Phường 2, Tân Bình', N'Hệ thống Viện Thẩm Mỹ Quốc Tế Mega Korea là thương hiệu cung cấp các dịch vụ làm đẹp uy tín và chất lượng hàng đầu tại Việt Nam. Được thành lập với sứ mệnh chăm sóc sắc đẹp cho tất cả mọi người đặc biệt là các chị em phái nữ

Nhằm đáp ứng nhu cầu làm đẹp ngày càng cao của tất cả chị em, Viện Thẩm Mỹ Mega Korea không ngừng đầu tư hệ thống công nghệ hiện đại bậc nhất. Kết hợp với đội ngũ chuyên gia thẩm mỹ có chuyên môn cao, cùng với đó là sự đầu tư vào không gian sang trọng đẳng cấp 5 sao, mang lại sự thoải mái và cực kỳ thư giãn cho khách hàng khi trải nghiệm dịch vụ tại Mega Korea.', N'https://tuyendung.megakorea.vn/', N'/img/logoCongTy/Hệ Thống MEGA HOLDING_20250410224330_logo6.png', N'0899295757', N'2025-04-10 22:43:30.757', N'2')
GO

INSERT INTO [dbo].[tblCongTy] ([PK_sMaCongTy], [FK_sTenTaiKhoan], [sTenCongTy], [sDiaChi], [sMoTa], [sWebsite], [sLogo], [sSoDienThoai], [tNgayDangKy], [iTrangThai]) VALUES (N'CT100425gp86', N'nguoidung1', N'CÔNG TY TNHH OCHIGO VIỆT NAM', N'16.01 - Toà nhà Golden King, số 15 Nguyễn Lương Bằng, P.Tân Phú, Q7, TP.HCM', N'THÔNG TIN LIÊN HỆ
Địa chỉ: 16.01 - Toà nhà Golden King, số 15 Nguyễn Lương Bằng, P.Tân Phú, Q7, TP.HCM.

Email: info@ochigo.vn - contact@ochigo.vn    

Điện thoại: (028) 5411 2207

Hotline: 0946 606 007                  ', N'https://ochigo.vn/', N'/img/logoCongTy/CÔNG TY TNHH OCHIGO VIỆT NAM_20250410214822_logo2.png', N'0946606007', N'2025-04-10 21:48:22.423', N'2')
GO

INSERT INTO [dbo].[tblCongTy] ([PK_sMaCongTy], [FK_sTenTaiKhoan], [sTenCongTy], [sDiaChi], [sMoTa], [sWebsite], [sLogo], [sSoDienThoai], [tNgayDangKy], [iTrangThai]) VALUES (N'CT100425nu52', N'nguoidung6', N'CÔNG TY TNHH AI VINA', N'01DV8, KĐT Tây Nam Linh Đàm, phường Hoàng Liệt, quận Hoàng Mai, Hà Nội', N'Công ty TNHH AI VINA là đơn vị ủy quyền phân phối chính thức các sản phẩm phụ gia Senfineco Germany tại thị trường Việt Nam.

Với chính sách bán hàng linh hoạt, hỗ trợ chiết khấu cao cho các đại lý.

** Công ty AI VINA tìm đại lý kinh doanh, phân phối các sản phẩm của Senfineco Germany:
– Đại lý ủy quyền 5S
– Đại lý phân phối dầu nhớt và phụ tùng
– Garage sửa chữa và chăm sóc xe ô tô
– Doanh nghiệp bán hàng online

Senfineco Germany là thương hiệu phụ gia đang có doanh số hàng đầu Việt Nam với các ưu điểm:
- Sản phẩm uy tín và hiệu quả cao của Đức
- Đa dạng các mặt hàng: động cơ, nội – ngoại thất
- Giá cả cạnh tranh trong cùng phân khúc
- Nguồn hàng ổn định nhất thị trường
- Chính sách hỗ trợ linh hoạt theo từng vùng miền', N'https://senfinecovietnam.vn/gioi-thieu/', N'/img/logoCongTy/CÔNG TY TNHH AI VINA_20250410225047_logo7.png', N'0868460905', N'2025-04-10 22:48:42.830', N'2')
GO

INSERT INTO [dbo].[tblCongTy] ([PK_sMaCongTy], [FK_sTenTaiKhoan], [sTenCongTy], [sDiaChi], [sMoTa], [sWebsite], [sLogo], [sSoDienThoai], [tNgayDangKy], [iTrangThai]) VALUES (N'CT100425os31', N'nguoidung4', N'CÔNG TY TM&DV PHONG MINH', N'210 Lê Trọng Tấn, Thanh Xuân, Hà Nội', N'Gokana - thương hiệu chăm sóc sức khỏe, thiết bị làm đẹp và thiết bị gia đình hàng đầu Việt Nam. Gokana Chú trọng vào chất lượng cùng với đa dạng mẫu mã với các sản phẩm:

- Thiết bị y tế, thiết bị chăm sóc sức khỏe tại nhà cho gia đình như: Máy tăm nước du lịch, máy tăm nước cá nhân, máy tăm nước mini, Máy massage toàn thân, ghế massage toàn thân, máy chạy bộ điện, xe đạp tập thể dục toàn thân,…

- Thiết bị làm đẹp và thiết bị spa: máy triệt lông, máy rửa mặt, máy nâng cơ, máy hút mụn, máy đốt nốt ruồi… 

- Thiết bị gia đình như: robot hut bụi, máy nhào bột, máy đánh trứng, máy xay….

Ứng dụng công nghệ hiện đại bậc nhất Gokana đầu tư vào hệ thống nhà máy, đội ngũ kỹ sư đầu ngành cho ra đời nhiều dòng chăm sóc sức khỏe chất lượng cao.

Với hơn 10 năm hoạt động kinh doanh và phân phối hàng sức khỏe và thiết bị gia đình cao cấp tại Việt Nam, Gokana luôn dẫn vị thế đầu ngành TOP trong lĩnh vực chăm sóc sức khỏe gia đình, Cam kết 100% hàng chính hãng, được nhập khẩu và phân phối với chất lượng cao, bảo hành đầy đủ và bảo trì trọn đời sản phẩm.

Hiện nay, Gokana đã có hàng trăm đối tác lớn phủ rộng trên toàn bộ lãnh thổ Việt Nam và đang tiếp tục mở rộng để xây dựng thành một hệ thống phủ khắp toàn quốc. Với hệ thống showroom rộng lớn, cùng với đội ngũ nhân viên bán hàng chuyên nghiệp được đào tạo bài bản và đi kèm theo đó là nhiều chính sách vượt trội hậu bán hàng tuyệt vời, cam kết sẽ làm bạn hài lòng khi mua sắm, Gokana tự tin sẽ mang đến cho khách hàng những dòng máy chăm sóc sức khỏe cho chính bạn và người thân yêu.', N'https://gokana.vn/', N'/img/logoCongTy/CÔNG TY TNHH TM&DVDL PHONG MINH_20250410221539_logo5.jpeg', N'0907265333', N'2025-04-10 22:09:44.427', N'2')
GO

INSERT INTO [dbo].[tblCongTy] ([PK_sMaCongTy], [FK_sTenTaiKhoan], [sTenCongTy], [sDiaChi], [sMoTa], [sWebsite], [sLogo], [sSoDienThoai], [tNgayDangKy], [iTrangThai]) VALUES (N'CT100425pe76', N'nguoidung3', N'Công ty TNHH DVNH Vua Chả Cá', N'Số 9 Lý Thường Kiệt, P Phan Chu Trinh, Q Hoàn Kiếm, TP Hà Nội', N'Hệ thống nhà hàng VUA CHẢ CÁ là nhà hàng chả cá đầu tiên tại Hà Nội trang bị hệ thống hút mùi tiêu chuẩn Hàn Quốc, Bạn sẽ không còn lo lắng những mùi dầu mỡ khó chịu bám theo mình suốt cả ngày, Vua Chả Cá giới thiệu tới bạn một phong cách ẩm thực đặc sắc và hiện đại

Nếu bạn đang tìm một nơi hẹn hò lãng mạn, check in sang chảnh cùng bạn bè, những bữa ăn gia đình hay cuộc gặp gỡ đối tác quan trọng, Vua Chả Cá chính là sự lựa chọn tuyệt vời dành cho bạn. Một không gian lịch sự, ấm cúng với gam màu nâu, vàng và nội thất gỗ mộc đem lại sự gần gũi, thư giãn cho thực khách.

Bên cạnh nội thất độc đáo, Vua Chả Cá tự tin khẳng định chất lượng chả cá truyền thống với đầu bếp gần 20 năm kinh nghiệm chế biến sẽ đem lại sự hài lòng tuyệt đối cho bạn. Những nguyên liệu được lựa chọn kĩ lưỡng, bạn sẽ được trải nghiệm trọn vẹn tinh hoa ẩm thực truyền thống Hà Nội chỉ trong món chả cá.

Đội ngũ nhân viên được đào tạo bài bản chuyên nghiệp với thái độ phục vụ thân thiện, nhiệt tình chắc chắn sẽ thổi hồn vào cho không gian ấm áp này. Một nơi tuyệt vời để bạn cảm nhận những khoảnh khắc quý giá trong cuộc sống, chia sẻ niềm vui bên bạn bè và gia đình.', N'http://vuachaca.vn/', N'/img/logoCongTy/Công ty TNHH DVNH Vua Chả Cá_20250410220221_logo4.jpg', N'0965232216', N'2025-04-10 22:02:21.353', N'2')
GO

INSERT INTO [dbo].[tblCongTy] ([PK_sMaCongTy], [FK_sTenTaiKhoan], [sTenCongTy], [sDiaChi], [sMoTa], [sWebsite], [sLogo], [sSoDienThoai], [tNgayDangKy], [iTrangThai]) VALUES (N'CT100425xs59', N'nguoidung2', N'Công ty CP Xuất Nhập Khẩu Kein', N'Sunrise A, Manor 1st Street, The Manor Central Park, Đại Kim, Hoàng Mai, Hà Nội, Việt Nam', N'Công ty Cổ phần Xuất Nhập Khẩu KEIN được thành lập vào ngày 21/08/2012, hoạt động trong lĩnh vực nhập khẩu và phân phối hàng tiêu dùng nhanh (FMCG). Với nền tảng tài chính vững chắc cùng đội ngũ nhân sự giàu kinh nghiệm, nhanh nhạy và có chuyên môn cao, KEIN đã không ngừng phát triển, trở thành đối tác tin cậy của khách hàng trên khắp Việt Nam.

Là một trong những đơn vị nhập khẩu và phân phối thực phẩm Nhật Bản hàng đầu tại Việt Nam, KEIN tự hào là đối tác chiến lược của tập đoàn Kobe Bussan (Nhật Bản). Chúng tôi cam kết mang đến những sản phẩm chất lượng cao, đáp ứng nhu cầu đa dạng của thị trường trong nước.

Hiện nay, KEIN sở hữu mạng lưới phân phối rộng khắp cùng hai kho hàng lớn tại Hà Nội và TP. Hồ Chí Minh, đảm bảo cung ứng sản phẩm nhanh chóng, hiệu quả. Với định hướng phát triển bền vững, chúng tôi không ngừng mở rộng danh mục sản phẩm, nâng cao chất lượng dịch vụ, hướng tới mục tiêu trở thành đơn vị tiên phong trong lĩnh vực nhập khẩu và phân phối hàng tiêu dùng nhanh, đặc biệt là thực phẩm Nhật Bản tại Việt Nam.', NULL, N'/img/logoCongTy/Công ty CP Xuất Nhập Khẩu Kein_20250410215900_logo3.png', N'0337945969', N'2025-04-10 21:57:53.707', N'2')
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
  [sYeuCau] nvarchar(max) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [iLuotXem] int  NULL
)
GO

ALTER TABLE [dbo].[tblCongViec] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of tblCongViec
-- ----------------------------
INSERT INTO [dbo].[tblCongViec] ([PK_sMaCongViec], [FK_sMaCongTy], [sTieuDe], [sMoTa], [sDiaDiem], [sMucLuong], [sLoaiHinh], [tNgayDang], [sTrangThai], [iSoLuongTuyen], [tNgayHetHan], [sCapBac], [sNganhNghe], [sQuyenLoi], [sYeuCau], [iLuotXem]) VALUES (N'CV100425nk15', N'CT090425cf51', N'Huấn luyện viên cá nhân - PT Gym/Kick', N'Chịu trách nhiệm hoàn thành mục tiêu doanh số cá nhân và mục tiêu về tiết dạy hàng tháng
Tập luyện cho hội viên, khách hàng
Làm việc theo hệ thống và báo cáo
Tham gia đào tạo, rèn luyện và phát triển kỹ năng', N'Hoàng Mai, Hà Nội', N'20 -25 triệu', N'Part-time', N'2025-04-10 16:14:39.080', N'Đang tuyển', N'8', N'2025-04-15 00:00:00.000', N'Đào tạo viên', N'Thể thao/ Thể thao nước/ Golf, Gym', N'Thu nhập = Lương cứng + hoa hồng + thưởng: thu nhập từ 8tr - 40tr
Được phát triển theo lộ trình bài bản, chương trình đánh giá, thăng hạng cấp hằng quý.
Môi trường làm việc chuyên nghiệp, tôn trọng và luôn đổi mới
Chế độ thăng tiến và chính sách lương, thưởng, hoa hồng rõ ràng
Được đào tạo về chuyên môn và kỹ năng bán hàng, kỹ năng thuyết trình, kỹ năng giao tiếp.
Các chế độ đãi ngộ khác theo quy định của đơn vị
Được tập luyện FREE tại phòng tập và bể bơi 5 sao', N'Đã có kinh nghiệm tập luyện hoặc làm việc tại các đơn vị Fitness. Chấp nhận đào tạo ứng viên chưa có kinh nghiệm
Yêu cầu khả năng ngoại ngữ: Ngoại ngữ là một lợi thế
Chăm chỉ, có trách nhiệm với công việc', N'11')
GO

INSERT INTO [dbo].[tblCongViec] ([PK_sMaCongViec], [FK_sMaCongTy], [sTieuDe], [sMoTa], [sDiaDiem], [sMucLuong], [sLoaiHinh], [tNgayDang], [sTrangThai], [iSoLuongTuyen], [tNgayHetHan], [sCapBac], [sNganhNghe], [sQuyenLoi], [sYeuCau], [iLuotXem]) VALUES (N'CV130425ax70', N'CT100425os31', N'Nhân viên tư vấn vay trả góp tại cửa hàng', N'Đứng tại cửa hàng xe máy hoặc điện máy (FPT Shop, Cellphone S, Điện máy Nguyễn Kim, Honda…) tại khu vực
Phối hợp với đội ngũ sales tại cửa hàng
Tiếp đón khách hàng, hỗ trợ tư vấn sản phẩm 
Giới thiệu cho khách gói vay trả góp phù hợp
Làm hồ sơ, chăm sóc khách hàng', N'Đoàn Văn Bơ, Phường 13, Quận 4, TPHCM', N'10 - 15 triệu', N'Thực tập', N'2025-04-13 22:33:08.907', N'Đang tuyển', N'6', N'2025-04-18 00:00:00.000', N'Đào tạo viên', N'Hành chính/ Nhân sự/ Thư ký', N'Thử việc 100% lương, 15 ngày phép năm, các ngày nghỉ lễ, tết
​​​​​​​48 tiếng/ tuần, 1 tuần nghỉ 1 ngày theo lịch 
Xoay ca 8 tiếng theo giờ mở cửa của cửa hàng (nghỉ trưa 1 tiếng)
(lịch làm việc do Quản lý phân bổ hàng tháng)
HĐLĐ 12 tháng (bao gồm 2 tháng thử việc 100% lương)', N'Tối thiểu bằng THPT trở lên
Không yêu cầu kinh nghiệm, am hiểu về tài chính, ngân hàng là một lợi thế', NULL)
GO

INSERT INTO [dbo].[tblCongViec] ([PK_sMaCongViec], [FK_sMaCongTy], [sTieuDe], [sMoTa], [sDiaDiem], [sMucLuong], [sLoaiHinh], [tNgayDang], [sTrangThai], [iSoLuongTuyen], [tNgayHetHan], [sCapBac], [sNganhNghe], [sQuyenLoi], [sYeuCau], [iLuotXem]) VALUES (N'CV130425br44', N'CT090425cf51', N'Trưởng nhóm kinh doanh - Leader Sale', N'Hiểu về các dịch vụ của công ty để giới thiệu, tư vấn và giải đáp thắc mắc cho khách hàng. 
Chăm sóc khách hàng sau khi bán, duy trì mối quan hệ với khách hàng hiện tại. 
Hỗ trợ, giám sát và đánh giá hiệu suất làm việc của nhân viên. 
Tạo động lực, xây dựng môi trường làm việc tích cực cho đội nhóm.
Tìm kiếm nguồn khách hàng mới theo data được công ty cung cấp.
Thực hiện các công việc khác theo sự phân công của cấp trên', N'Dịch Vọng Hậu, Cầu Giấy, Hà Nôi', N'Thỏa thuận', N'Full-time', N'2025-04-13 17:33:40.257', N'Đang tuyển', N'8', N'2025-04-30 00:00:00.000', N'Trưởng bộ phận/ Trưởng phòng', N'Tài chính / Kế toán/ Thu mua/ Thủ kho', N'Thu nhập hấp dẫn từ 20tr – 25tr (mức lương cơ bản + hoa hồng + thưởng theo cơ chế mới năm 2025)
Môi trường làm việc chuyên nghiệp tại các clb 5 sao, năng động, được đào tạo với các chuyên gia về bán hàng, lộ trình thăng tiến rõ ràng 
Được tham gia các hoạt động chung của Công ty: du lịch, team building, sự kiện…
Được tập luyện tại phòng tập và bể bơi 5 sao
Review lương hằng quý, cơ hội thăng tiến tới quản lý', N'Năng động, nhiệt tình, trung thực trong công việc.
Khả năng giao tiếp tốt và làm việc theo nhóm.
Có kinh nghiệm ít nhất 01 năm ở vị trí tương đương. Ưu tiên có kinh nghiệm làm việc về lĩnh vực dịch vụ, thời trang, fitness.
Có Tiếng Anh, ngoại hình là một lợi thế.', NULL)
GO

INSERT INTO [dbo].[tblCongViec] ([PK_sMaCongViec], [FK_sMaCongTy], [sTieuDe], [sMoTa], [sDiaDiem], [sMucLuong], [sLoaiHinh], [tNgayDang], [sTrangThai], [iSoLuongTuyen], [tNgayHetHan], [sCapBac], [sNganhNghe], [sQuyenLoi], [sYeuCau], [iLuotXem]) VALUES (N'CV130425eg54', N'CT100425xs59', N'Tuyển Nhân Viên Cửa Hàng Gà Rán', N'*THU NGÂN:
Nhận order từ khách hàng & tư vấn món ăn;
Thực hiện công tác thu ngân: check bill, in bill, thanh toán tiền cho khách;
Chuyển thông tin món vào bếp Xử lý các vấn đề phát sinh tại quầy.

*PHỤC VỤ:
Chào đón khách đến với nhà hàng;
Mang món ăn, đồ uống lên bàn cho khách khi được chuẩn bị xong;
Hỗ trợ dọn dẹp nhà hàng sạch sẽ, thoáng mát;
Phục vụ khách trong suốt bữa ăn, hỗ trợ khách khi cần.', N'Quận Bình Thạnh, TP.HCM', N'3 - 5 triệu', N'Part-time', N'2025-04-13 22:49:06.270', N'Đang tuyển', N'19', N'2025-06-05 00:00:00.000', N'Nhân viên', N'Sales/ Marketing/ Guest Relation', N'Chế độ lương thưởng hấp dẫn;
Được đào tạo các kỹ năng nghiệp vụ miễn phí;
Làm việc trong môi trường năng động, giúp nhân viên phát triển kỹ năng giao tiếp, giải quyết vấn đề và quản lý công việc;
Cơ hội phát triển và thăng tiến lên vị trí Store Manager rõ ràng.', N'Độ tuổi: Nam Nữ từ đủ 16t - 30t (ưu tiên gắn bó lâu dài, không tuyển thời vụ);
Sẵn sàng làm việc các ngày cuối tuần, Lễ, Tết;
Ngoại hình ưa nhìn, sức khỏe tốt, nhanh nhẹn, không có hình xăm, yêu thích công việc phục vụ khách hàng.', NULL)
GO

INSERT INTO [dbo].[tblCongViec] ([PK_sMaCongViec], [FK_sMaCongTy], [sTieuDe], [sMoTa], [sDiaDiem], [sMucLuong], [sLoaiHinh], [tNgayDang], [sTrangThai], [iSoLuongTuyen], [tNgayHetHan], [sCapBac], [sNganhNghe], [sQuyenLoi], [sYeuCau], [iLuotXem]) VALUES (N'CV130425ej88', N'CT100425pe76', N'Tuyển Phục vụ, Lễ Tân, Pha chế', N'Nhân viên Bàn, pha chế, Lễ tân, thu ngân.
Nhân viên phục vụ bộ phần bàn.', N'Phan Chu Trinh,  Q.Hoàn Kiếm, TP.Hà Nội', N'5 - 8 triệu', N'Part-time', N'2025-04-13 22:28:42.370', N'Đang tuyển', N'5', N'2025-05-28 00:00:00.000', N'Thực tập sinh', N'Lễ tân/ Thu ngân/ Đặt phòng/ Tổng đài/ BC', N'Làm thêm giờ/ngày lễ được hỗ trợ tăng hệ số thu nhập

Hỗ trợ bữa ăn + đồng phục

Có xét hỗ trợ tăng thu nhập định kỳ (6 tháng/lần)

Đầy đủ hỗ trợ liên quan đến sức khỏe và phúc lợi (áp dụng theo quy định)', N'Có thể tham gia tối thiểu từ 3 – 6 tháng (ưu tiên ổn định lâu dài)

Ứng viên đăng ký hoàn toàn miễn phí, không qua trung gian', NULL)
GO

INSERT INTO [dbo].[tblCongViec] ([PK_sMaCongViec], [FK_sMaCongTy], [sTieuDe], [sMoTa], [sDiaDiem], [sMucLuong], [sLoaiHinh], [tNgayDang], [sTrangThai], [iSoLuongTuyen], [tNgayHetHan], [sCapBac], [sNganhNghe], [sQuyenLoi], [sYeuCau], [iLuotXem]) VALUES (N'CV130425eq15', N'CT100425xs59', N'Nhân viên Graphic Design Sàn Thương Mại Điện Tử', N'1. Thiết kế ấn phẩm truyền thông & nhận diện thương hiệu
Thiết kế poster, banner cho Fanpage, website, TikTok Carousel và các nền tảng digital khác.
Phát triển bộ nhận diện thương hiệu, đảm bảo tính nhất quán và chuyên nghiệp trong từng thiết kế.
Thiết kế các ấn phẩm in ấn như brochure, flyer, standee, POSM,… phục vụ hoạt động marketing & truyền thông.

2. Hợp tác & triển khai nội dung

Phối hợp chặt chẽ với Content Creator để xây dựng hình ảnh phù hợp với nội dung chiến dịch.
Đóng góp ý tưởng sáng tạo, nâng cao chất lượng hình ảnh & trải nghiệm thương hiệu.

3. Nghiên cứu & tối ưu giao diện số
Cập nhật xu hướng thiết kế hiện đại, ứng dụng vào sản phẩm nhằm nâng cao hiệu quả truyền thông.', N'Đại Kim, Hoàng Mai, Hà Nội', N'10 - 15 triệu', N'Freelance', N'2025-04-13 22:25:27.943', N'Đang tuyển', N'5', N'2025-05-05 00:00:00.000', N'Giám sát', N'IT', N'Thưởng theo KPI: Thu nhập có thể lên tới 15 triệu/tháng.
Trợ cấp ăn trưa và xăng xe.
Được làm việc trong một môi trường chuyên nghiệp, bài bản.
Được đào tạo và năng cấp kỹ năng thường xuyên.
Được cung cấp máy tính cá nhân và thiết bị quay chụp hiện đại phục vụ làm việc.
Được làm việc với các brand nội địa hàng đầu Nhật Bản.', N'Có kinh nghiệm design từ 2 năm trở lên.
Ứng viên vui lòng gửi sản phẩm đã làm đính kèm
Có tư duy thiết kế sáng tạo
Có tư duy hình ảnh tốt.
Có khả năng làm teamwork.', NULL)
GO

INSERT INTO [dbo].[tblCongViec] ([PK_sMaCongViec], [FK_sMaCongTy], [sTieuDe], [sMoTa], [sDiaDiem], [sMucLuong], [sLoaiHinh], [tNgayDang], [sTrangThai], [iSoLuongTuyen], [tNgayHetHan], [sCapBac], [sNganhNghe], [sQuyenLoi], [sYeuCau], [iLuotXem]) VALUES (N'CV130425gc59', N'CT100425ae98', N'TELESALES CA TỐI 18H30 - 21H30', N'Liên lạc với khách hàng thông qua data có sẵn để tư vấn các gói dịch vụ làm đẹp 
Đặt lịch hẹn cho khách hàng đến sử dụng dịch vụ
Làm ca tối, tháng off 3 ngày', N'34 Bạch Đằng, Phường 2, Tân Bình', N'3 - 5 triệu', N'Remote', N'2025-04-13 22:39:19.057', N'Đang tuyển', N'5', N'2025-05-08 00:00:00.000', N'Trưởng bộ phận/ Trưởng phòng', N'Sales/ Marketing/ Guest Relation', N'ĐƯỢC ĐÀO TẠO BÀI BẢN
CẤP ĐATA NÓNG MỖI NGÀY
Lương 2 triệu + HH 30k/khách ', N'GIAO TIẾP TỐT', NULL)
GO

INSERT INTO [dbo].[tblCongViec] ([PK_sMaCongViec], [FK_sMaCongTy], [sTieuDe], [sMoTa], [sDiaDiem], [sMucLuong], [sLoaiHinh], [tNgayDang], [sTrangThai], [iSoLuongTuyen], [tNgayHetHan], [sCapBac], [sNganhNghe], [sQuyenLoi], [sYeuCau], [iLuotXem]) VALUES (N'CV130425sz80', N'CT100425gp86', N'Nhân Viên Kinh Doanh Thuốc Bảo Vệ Thực Vật - Phân Bón Tại Văn Phòng', N'Chăm sóc khách hàng hiện có, duy trì và phát triển mối quan hệ lâu dài.
Giới thiệu, Tư vấn, bán hàng và hướng dẫn sử dụng các sản phẩm phân bón, thuốc bảo vệ thực vật của công ty
Tìm kiếm, tiếp cận và mở rộng kênh khách hàng: Đại lý, Nhà phân phối, cửa hàng vật tư nông nghiệp, Farm nông nghiệp, Nông dân,….
Đàm phán, ký kết hợp đồng và theo dõi đơn hàng, công nợ của khách hàng.
Cập nhật insigh khách hàng, thị trường, thu thập thông tin về đối thủ cạnh tranh và xu hướng nhu cầu phân bón.
Báo cáo tình hình kinh doanh và đề xuất giải pháp phát triển thị trường.', N'P.Tân Phú, Q7, TP.HCM', N'10 - 15 triệu', N'Full-time', N'2025-04-13 22:17:34.303', N'Đang tuyển', N'16', N'2025-05-07 00:00:00.000', N'Nhân viên', N'Sales/ Marketing/ Guest Relation', N'Thưởng nóng hàng tháng, thưởng lễ tết, cuối năm, thưởng doanh số bán hàng...
Lương: LCB + KPI công việc (thu nhập từ 10 - 30 triệu đồng, tùy theo khả năng đạt doanh số bán hàng
Chế độ BHXH đầy đủ ( BH thất nghiệp, y tế, tai nạn).
Khám sức khỏe định kỳ hằng năm và các chế độ phúc lợi khác.', N'Không yêu cầu kinh nghiệm trong lĩnh vực BVTV - Phân bón.
Độ tuổi :22 -32 tuổi 
Tốt nghiệp Cao đẳng trở lên, yêu thích lĩnh vực kinh doanh.
Khả năng đàm phán tốt, nhạy bén, linh hoạt, có năng khiếu tư vấn bán hàng.
Sử dụng tốt tin học văn phòng', NULL)
GO


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
INSERT INTO [dbo].[tblFile] ([PK_sMaFile], [sTenfile], [FK_sTenTaiKhoan], [sLoaiFile], [sDuongDan], [tNgayTaiLen]) VALUES (N'FL120425bt12', N'nguoidung1_20250412_102514.pdf', N'nguoidung1', N'CV', N'/uploads/fiveCV/CV100425nk15/nguoidung1_20250412_102514.pdf', N'2025-04-12 10:25:14.937')
GO

INSERT INTO [dbo].[tblFile] ([PK_sMaFile], [sTenfile], [FK_sTenTaiKhoan], [sLoaiFile], [sDuongDan], [tNgayTaiLen]) VALUES (N'FL120425lj18', N'nguoidung2_20250412_102610.pdf', N'nguoidung2', N'CV', N'/uploads/fiveCV/CV100425nk15/nguoidung2_20250412_102610.pdf', N'2025-04-12 10:26:10.180')
GO

INSERT INTO [dbo].[tblFile] ([PK_sMaFile], [sTenfile], [FK_sTenTaiKhoan], [sLoaiFile], [sDuongDan], [tNgayTaiLen]) VALUES (N'FL120425oi76', N'nguoidung3_20250412_102713.pdf', N'nguoidung3', N'CV', N'/uploads/fiveCV/CV100425nk15/nguoidung3_20250412_102713.pdf', N'2025-04-12 10:27:13.843')
GO

INSERT INTO [dbo].[tblFile] ([PK_sMaFile], [sTenfile], [FK_sTenTaiKhoan], [sLoaiFile], [sDuongDan], [tNgayTaiLen]) VALUES (N'FL120425tt78', N'vhanh2k4_20250412_155052.pdf', N'vhanh2k4', N'CV', N'/upload/fiveCV/CV100425nk15/vhanh2k4_20250412_155052.pdf', N'2025-04-12 15:50:53.010')
GO

INSERT INTO [dbo].[tblFile] ([PK_sMaFile], [sTenfile], [FK_sTenTaiKhoan], [sLoaiFile], [sDuongDan], [tNgayTaiLen]) VALUES (N'FL130425fh28', N'nguoidung5_20250413_224522.pdf', N'nguoidung5', N'CV', N'/uploads/fiveCV/CV130425ax70/nguoidung5_20250413_224522.pdf', N'2025-04-13 22:45:22.220')
GO

INSERT INTO [dbo].[tblFile] ([PK_sMaFile], [sTenfile], [FK_sTenTaiKhoan], [sLoaiFile], [sDuongDan], [tNgayTaiLen]) VALUES (N'FL130425ix49', N'nguoidung6_20250413_224646.pdf', N'nguoidung6', N'CV', N'/uploads/fiveCV/CV130425ax70/nguoidung6_20250413_224646.pdf', N'2025-04-13 22:46:46.270')
GO

INSERT INTO [dbo].[tblFile] ([PK_sMaFile], [sTenfile], [FK_sTenTaiKhoan], [sLoaiFile], [sDuongDan], [tNgayTaiLen]) VALUES (N'FL130425ix99', N'nguoidung5_20250413_224418.pdf', N'nguoidung5', N'CV', N'/uploads/fiveCV/CV130425br44/nguoidung5_20250413_224418.pdf', N'2025-04-13 22:44:18.820')
GO

INSERT INTO [dbo].[tblFile] ([PK_sMaFile], [sTenfile], [FK_sTenTaiKhoan], [sLoaiFile], [sDuongDan], [tNgayTaiLen]) VALUES (N'FL130425ue29', N'nguoidung6_20250413_224636.pdf', N'nguoidung6', N'CV', N'/uploads/fiveCV/CV130425br44/nguoidung6_20250413_224636.pdf', N'2025-04-13 22:46:36.007')
GO

INSERT INTO [dbo].[tblFile] ([PK_sMaFile], [sTenfile], [FK_sTenTaiKhoan], [sLoaiFile], [sDuongDan], [tNgayTaiLen]) VALUES (N'FL140425qw16', N'vhanh2k4_20250414_002514.pdf', N'vhanh2k4', N'CV', N'/uploads/fiveCV/CV130425gc59/vhanh2k4_20250414_002514.pdf', N'2025-04-14 00:25:14.307')
GO


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

INSERT INTO [dbo].[tblTaiKhoan] ([PK_sTenTaiKhoan], [sHoTen], [sEmail], [sMatKhau], [sSoDienThoai], [sDiaChi], [sAnhDaiDien], [sVaiTro], [iTrangThai], [tNgayTao], [tNgayCapNhat]) VALUES (N'nguoidung1', N'Hứa Quang Hán ', N'nguoi1@gmail.com', N'$2a$11$AgAkpxotMtaMNz88Uo6q7emgH0YzxBsMm6peX7AEIpSdYXxotK5FS', NULL, NULL, NULL, N'user', N'2', N'2025-04-10 21:28:23.493', N'2025-04-10 21:28:23.493')
GO

INSERT INTO [dbo].[tblTaiKhoan] ([PK_sTenTaiKhoan], [sHoTen], [sEmail], [sMatKhau], [sSoDienThoai], [sDiaChi], [sAnhDaiDien], [sVaiTro], [iTrangThai], [tNgayTao], [tNgayCapNhat]) VALUES (N'nguoidung10', N'Phạm Bảo Vinh', N'nguoi10@gmail.com', N'$2a$11$AgAkpxotMtaMNz88Uo6q7emgH0YzxBsMm6peX7AEIpSdYXxotK5FS', NULL, NULL, NULL, N'user', N'2', N'2025-04-10 22:52:41.940', N'2025-04-10 22:52:41.940')
GO

INSERT INTO [dbo].[tblTaiKhoan] ([PK_sTenTaiKhoan], [sHoTen], [sEmail], [sMatKhau], [sSoDienThoai], [sDiaChi], [sAnhDaiDien], [sVaiTro], [iTrangThai], [tNgayTao], [tNgayCapNhat]) VALUES (N'nguoidung2', N'Trần Phi Vũ', N'nguoi2@gmail.com', N'$2a$11$AgAkpxotMtaMNz88Uo6q7emgH0YzxBsMm6peX7AEIpSdYXxotK5FS', NULL, NULL, NULL, N'user', N'2', N'2025-04-10 21:29:22.233', N'2025-04-10 21:29:22.233')
GO

INSERT INTO [dbo].[tblTaiKhoan] ([PK_sTenTaiKhoan], [sHoTen], [sEmail], [sMatKhau], [sSoDienThoai], [sDiaChi], [sAnhDaiDien], [sVaiTro], [iTrangThai], [tNgayTao], [tNgayCapNhat]) VALUES (N'nguoidung3', N'Lâm Gia Đạt', N'nguoi3@gmail.com', N'$2a$11$AgAkpxotMtaMNz88Uo6q7emgH0YzxBsMm6peX7AEIpSdYXxotK5FS', NULL, NULL, NULL, N'user', N'2', N'2025-04-10 21:30:20.043', N'2025-04-10 21:30:20.043')
GO

INSERT INTO [dbo].[tblTaiKhoan] ([PK_sTenTaiKhoan], [sHoTen], [sEmail], [sMatKhau], [sSoDienThoai], [sDiaChi], [sAnhDaiDien], [sVaiTro], [iTrangThai], [tNgayTao], [tNgayCapNhat]) VALUES (N'nguoidung4', N'Nguyễn Nam Long', N'nguoi4@gmail.com', N'$2a$11$AgAkpxotMtaMNz88Uo6q7emgH0YzxBsMm6peX7AEIpSdYXxotK5FS', NULL, NULL, NULL, N'user', N'2', N'2025-04-10 21:30:48.497', N'2025-04-10 21:30:48.497')
GO

INSERT INTO [dbo].[tblTaiKhoan] ([PK_sTenTaiKhoan], [sHoTen], [sEmail], [sMatKhau], [sSoDienThoai], [sDiaChi], [sAnhDaiDien], [sVaiTro], [iTrangThai], [tNgayTao], [tNgayCapNhat]) VALUES (N'nguoidung5', N'Văn Thị Hương Giang', N'nguoi5@gmail.com', N'$2a$11$AgAkpxotMtaMNz88Uo6q7emgH0YzxBsMm6peX7AEIpSdYXxotK5FS', NULL, NULL, NULL, N'user', N'2', N'2025-04-10 21:31:36.350', N'2025-04-10 21:31:36.350')
GO

INSERT INTO [dbo].[tblTaiKhoan] ([PK_sTenTaiKhoan], [sHoTen], [sEmail], [sMatKhau], [sSoDienThoai], [sDiaChi], [sAnhDaiDien], [sVaiTro], [iTrangThai], [tNgayTao], [tNgayCapNhat]) VALUES (N'nguoidung6', N'Cao Thanh Nam', N'nguoi6@gmail.com', N'$2a$11$AgAkpxotMtaMNz88Uo6q7emgH0YzxBsMm6peX7AEIpSdYXxotK5FS', NULL, NULL, NULL, N'user', N'2', N'2025-04-10 21:32:21.063', N'2025-04-10 21:32:21.063')
GO

INSERT INTO [dbo].[tblTaiKhoan] ([PK_sTenTaiKhoan], [sHoTen], [sEmail], [sMatKhau], [sSoDienThoai], [sDiaChi], [sAnhDaiDien], [sVaiTro], [iTrangThai], [tNgayTao], [tNgayCapNhat]) VALUES (N'nguoidung7', N'Lê Hoài An', N'nguoi7@gmail.com', N'$2a$11$AgAkpxotMtaMNz88Uo6q7emgH0YzxBsMm6peX7AEIpSdYXxotK5FS', NULL, NULL, NULL, N'user', N'2', N'2025-04-10 21:32:56.660', N'2025-04-10 21:32:56.660')
GO

INSERT INTO [dbo].[tblTaiKhoan] ([PK_sTenTaiKhoan], [sHoTen], [sEmail], [sMatKhau], [sSoDienThoai], [sDiaChi], [sAnhDaiDien], [sVaiTro], [iTrangThai], [tNgayTao], [tNgayCapNhat]) VALUES (N'nguoidung8', N'Vương Văn Ngọc Bảo', N'nguoi8@gmail.com', N'$2a$11$AgAkpxotMtaMNz88Uo6q7emgH0YzxBsMm6peX7AEIpSdYXxotK5FS', NULL, NULL, NULL, N'user', N'2', N'2025-04-10 21:34:02.450', N'2025-04-10 21:34:02.450')
GO

INSERT INTO [dbo].[tblTaiKhoan] ([PK_sTenTaiKhoan], [sHoTen], [sEmail], [sMatKhau], [sSoDienThoai], [sDiaChi], [sAnhDaiDien], [sVaiTro], [iTrangThai], [tNgayTao], [tNgayCapNhat]) VALUES (N'nguoidung9', N'Lý Thanh Tuân', N'nguoi9@gmail.com', N'$2a$11$AgAkpxotMtaMNz88Uo6q7emgH0YzxBsMm6peX7AEIpSdYXxotK5FS', NULL, NULL, NULL, N'user', N'2', N'2025-04-10 21:34:36.090', N'2025-04-10 21:34:36.090')
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
INSERT INTO [dbo].[tblThongBao] ([PK_sThongBao], [FK_sTenTaiKhoan], [sTieuDe], [sNoiDung], [sLoaiThongBao], [tNgayThongBao], [bDaXem], [FK_sMaCongTy], [FK_sMaCongViec]) VALUES (N'TB100425ij25', N'user', N'Thông báo ứng tuyển', N'Ứng viên Người dùng  đã ứng tuyển vào công việc Việc làm .', N'Ứng tuyển', N'2025-04-10 18:03:50.490', N'0', N'CT090425cf51', N'CV100425nk15')
GO

INSERT INTO [dbo].[tblThongBao] ([PK_sThongBao], [FK_sTenTaiKhoan], [sTieuDe], [sNoiDung], [sLoaiThongBao], [tNgayThongBao], [bDaXem], [FK_sMaCongTy], [FK_sMaCongViec]) VALUES (N'TB110425hn27', N'user', N'Trạng thái ứng tuyển đã được cập nhật', N'Hồ sơ ứng tuyển của bạn cho vị trí ''Việc làm '' đã được cập nhật trạng thái thành: Từ chối', N'UngTuyen', N'2025-04-11 19:30:21.350', N'0', N'CT090425cf51', N'CV100425nk15')
GO

INSERT INTO [dbo].[tblThongBao] ([PK_sThongBao], [FK_sTenTaiKhoan], [sTieuDe], [sNoiDung], [sLoaiThongBao], [tNgayThongBao], [bDaXem], [FK_sMaCongTy], [FK_sMaCongViec]) VALUES (N'TB110425mj44', N'user', N'Trạng thái ứng tuyển đã được cập nhật', N'Hồ sơ ứng tuyển của bạn cho vị trí ''Việc làm '' đã được cập nhật trạng thái thành: Từ chối', N'UngTuyen', N'2025-04-11 18:55:25.157', N'0', N'CT090425cf51', N'CV100425nk15')
GO

INSERT INTO [dbo].[tblThongBao] ([PK_sThongBao], [FK_sTenTaiKhoan], [sTieuDe], [sNoiDung], [sLoaiThongBao], [tNgayThongBao], [bDaXem], [FK_sMaCongTy], [FK_sMaCongViec]) VALUES (N'TB110425ms15', N'vhanh2k4', N'Thông báo ứng tuyển mới', N'Ứng viên Người dùng  đã ứng tuyển vào công việc Việc làm .', N'Ứng tuyển', N'2025-04-11 02:13:04.647', N'0', N'CT090425cf51', N'CV100425nk15')
GO

INSERT INTO [dbo].[tblThongBao] ([PK_sThongBao], [FK_sTenTaiKhoan], [sTieuDe], [sNoiDung], [sLoaiThongBao], [tNgayThongBao], [bDaXem], [FK_sMaCongTy], [FK_sMaCongViec]) VALUES (N'TB110425nm31', N'nguoidung4', N'Trạng thái ứng tuyển đã được cập nhật', N'Hồ sơ ứng tuyển của bạn cho vị trí ''Việc làm '' đã được cập nhật trạng thái thành: Chấp nhận', N'UngTuyen', N'2025-04-11 18:59:01.183', N'0', N'CT090425cf51', N'CV100425nk15')
GO

INSERT INTO [dbo].[tblThongBao] ([PK_sThongBao], [FK_sTenTaiKhoan], [sTieuDe], [sNoiDung], [sLoaiThongBao], [tNgayThongBao], [bDaXem], [FK_sMaCongTy], [FK_sMaCongViec]) VALUES (N'TB110425qd53', N'user', N'Trạng thái ứng tuyển đã được cập nhật', N'Hồ sơ ứng tuyển của bạn cho vị trí ''Việc làm '' đã được cập nhật trạng thái thành: Chấp nhận', N'UngTuyen', N'2025-04-11 18:51:49.880', N'0', N'CT090425cf51', N'CV100425nk15')
GO

INSERT INTO [dbo].[tblThongBao] ([PK_sThongBao], [FK_sTenTaiKhoan], [sTieuDe], [sNoiDung], [sLoaiThongBao], [tNgayThongBao], [bDaXem], [FK_sMaCongTy], [FK_sMaCongViec]) VALUES (N'TB110425qw98', N'vhanh2k4', N'Thông báo ứng tuyển mới', N'Ứng viên Nguyễn Nam Long đã ứng tuyển vào công việc Việc làm .', N'Ứng tuyển', N'2025-04-11 18:58:05.660', N'0', N'CT090425cf51', N'CV100425nk15')
GO

INSERT INTO [dbo].[tblThongBao] ([PK_sThongBao], [FK_sTenTaiKhoan], [sTieuDe], [sNoiDung], [sLoaiThongBao], [tNgayThongBao], [bDaXem], [FK_sMaCongTy], [FK_sMaCongViec]) VALUES (N'TB110425uv58', N'nguoidung4', N'Trạng thái ứng tuyển đã được cập nhật', N'Hồ sơ ứng tuyển của bạn cho vị trí ''Việc làm '' đã được cập nhật trạng thái thành: Chấp nhận', N'UngTuyen', N'2025-04-11 19:30:18.507', N'0', N'CT090425cf51', N'CV100425nk15')
GO

INSERT INTO [dbo].[tblThongBao] ([PK_sThongBao], [FK_sTenTaiKhoan], [sTieuDe], [sNoiDung], [sLoaiThongBao], [tNgayThongBao], [bDaXem], [FK_sMaCongTy], [FK_sMaCongViec]) VALUES (N'TB110425vw82', N'nguoidung4', N'Trạng thái ứng tuyển đã được cập nhật', N'Hồ sơ ứng tuyển của bạn cho vị trí ''Việc làm '' đã được cập nhật trạng thái thành: Chấp nhận', N'UngTuyen', N'2025-04-11 19:21:45.180', N'0', N'CT090425cf51', N'CV100425nk15')
GO

INSERT INTO [dbo].[tblThongBao] ([PK_sThongBao], [FK_sTenTaiKhoan], [sTieuDe], [sNoiDung], [sLoaiThongBao], [tNgayThongBao], [bDaXem], [FK_sMaCongTy], [FK_sMaCongViec]) VALUES (N'TB110425wb48', N'user', N'Trạng thái ứng tuyển đã được cập nhật', N'Hồ sơ ứng tuyển của bạn cho vị trí ''Việc làm '' đã được cập nhật trạng thái thành: Từ chối', N'UngTuyen', N'2025-04-11 19:21:53.557', N'0', N'CT090425cf51', N'CV100425nk15')
GO

INSERT INTO [dbo].[tblThongBao] ([PK_sThongBao], [FK_sTenTaiKhoan], [sTieuDe], [sNoiDung], [sLoaiThongBao], [tNgayThongBao], [bDaXem], [FK_sMaCongTy], [FK_sMaCongViec]) VALUES (N'TB110425zb48', N'vhanh2k4', N'Thông báo ứng tuyển mới', N'Ứng viên Người dùng  đã ứng tuyển vào công việc Việc làm .', N'Ứng tuyển', N'2025-04-11 02:10:36.450', N'0', N'CT090425cf51', N'CV100425nk15')
GO

INSERT INTO [dbo].[tblThongBao] ([PK_sThongBao], [FK_sTenTaiKhoan], [sTieuDe], [sNoiDung], [sLoaiThongBao], [tNgayThongBao], [bDaXem], [FK_sMaCongTy], [FK_sMaCongViec]) VALUES (N'TB120425eg96', N'nguoidung3', N'Trạng thái ứng tuyển đã được cập nhật', N'Hồ sơ ứng tuyển của bạn cho vị trí ''Việc làm '' đã được cập nhật trạng thái thành: Chấp nhận', N'UngTuyen', N'2025-04-12 10:43:51.933', N'0', N'CT090425cf51', N'CV100425nk15')
GO

INSERT INTO [dbo].[tblThongBao] ([PK_sThongBao], [FK_sTenTaiKhoan], [sTieuDe], [sNoiDung], [sLoaiThongBao], [tNgayThongBao], [bDaXem], [FK_sMaCongTy], [FK_sMaCongViec]) VALUES (N'TB120425em75', N'nguoidung2', N'Trạng thái ứng tuyển đã được cập nhật', N'Hồ sơ ứng tuyển của bạn cho vị trí ''Việc làm '' đã được cập nhật trạng thái thành: Từ chối', N'UngTuyen', N'2025-04-12 10:44:04.220', N'0', N'CT090425cf51', N'CV100425nk15')
GO

INSERT INTO [dbo].[tblThongBao] ([PK_sThongBao], [FK_sTenTaiKhoan], [sTieuDe], [sNoiDung], [sLoaiThongBao], [tNgayThongBao], [bDaXem], [FK_sMaCongTy], [FK_sMaCongViec]) VALUES (N'TB120425ru43', N'vhanh2k4', N'Thông báo ứng tuyển mới', N'Ứng viên Vũ Hoàng Anh đã ứng tuyển vào công việc Việc làm .', N'Ứng tuyển', N'2025-04-12 15:50:53.017', N'0', N'CT090425cf51', N'CV100425nk15')
GO

INSERT INTO [dbo].[tblThongBao] ([PK_sThongBao], [FK_sTenTaiKhoan], [sTieuDe], [sNoiDung], [sLoaiThongBao], [tNgayThongBao], [bDaXem], [FK_sMaCongTy], [FK_sMaCongViec]) VALUES (N'TB120425wt26', N'vhanh2k4', N'Thông báo ứng tuyển mới', N'Ứng viên Trần Phi Vũ đã ứng tuyển vào công việc Việc làm .', N'Ứng tuyển', N'2025-04-12 10:26:10.180', N'0', N'CT090425cf51', N'CV100425nk15')
GO

INSERT INTO [dbo].[tblThongBao] ([PK_sThongBao], [FK_sTenTaiKhoan], [sTieuDe], [sNoiDung], [sLoaiThongBao], [tNgayThongBao], [bDaXem], [FK_sMaCongTy], [FK_sMaCongViec]) VALUES (N'TB120425xa44', N'vhanh2k4', N'Thông báo ứng tuyển mới', N'Ứng viên Hứa Quang Hán  đã ứng tuyển vào công việc Việc làm .', N'Ứng tuyển', N'2025-04-12 10:25:14.940', N'0', N'CT090425cf51', N'CV100425nk15')
GO

INSERT INTO [dbo].[tblThongBao] ([PK_sThongBao], [FK_sTenTaiKhoan], [sTieuDe], [sNoiDung], [sLoaiThongBao], [tNgayThongBao], [bDaXem], [FK_sMaCongTy], [FK_sMaCongViec]) VALUES (N'TB120425yw88', N'vhanh2k4', N'Thông báo ứng tuyển mới', N'Ứng viên Lâm Gia Đạt đã ứng tuyển vào công việc Việc làm .', N'Ứng tuyển', N'2025-04-12 10:27:13.843', N'0', N'CT090425cf51', N'CV100425nk15')
GO

INSERT INTO [dbo].[tblThongBao] ([PK_sThongBao], [FK_sTenTaiKhoan], [sTieuDe], [sNoiDung], [sLoaiThongBao], [tNgayThongBao], [bDaXem], [FK_sMaCongTy], [FK_sMaCongViec]) VALUES (N'TB130425ee11', N'vhanh2k4', N'Thông báo ứng tuyển mới', N'Ứng viên Cao Thanh Nam đã ứng tuyển vào công việc Trưởng nhóm kinh doanh - Leader Sale.', N'Ứng tuyển', N'2025-04-13 22:46:36.007', N'0', N'CT090425cf51', N'CV130425br44')
GO

INSERT INTO [dbo].[tblThongBao] ([PK_sThongBao], [FK_sTenTaiKhoan], [sTieuDe], [sNoiDung], [sLoaiThongBao], [tNgayThongBao], [bDaXem], [FK_sMaCongTy], [FK_sMaCongViec]) VALUES (N'TB130425iv44', N'nguoidung4', N'Thông báo ứng tuyển mới', N'Ứng viên Cao Thanh Nam đã ứng tuyển vào công việc Nhân viên tư vấn vay trả góp tại cửa hàng.', N'Ứng tuyển', N'2025-04-13 22:46:46.270', N'0', N'CT100425os31', N'CV130425ax70')
GO

INSERT INTO [dbo].[tblThongBao] ([PK_sThongBao], [FK_sTenTaiKhoan], [sTieuDe], [sNoiDung], [sLoaiThongBao], [tNgayThongBao], [bDaXem], [FK_sMaCongTy], [FK_sMaCongViec]) VALUES (N'TB130425rd76', N'nguoidung4', N'Thông báo ứng tuyển mới', N'Ứng viên Văn Thị Hương Giang đã ứng tuyển vào công việc Nhân viên tư vấn vay trả góp tại cửa hàng.', N'Ứng tuyển', N'2025-04-13 22:45:22.220', N'0', N'CT100425os31', N'CV130425ax70')
GO

INSERT INTO [dbo].[tblThongBao] ([PK_sThongBao], [FK_sTenTaiKhoan], [sTieuDe], [sNoiDung], [sLoaiThongBao], [tNgayThongBao], [bDaXem], [FK_sMaCongTy], [FK_sMaCongViec]) VALUES (N'TB130425ti19', N'vhanh2k4', N'Thông báo ứng tuyển mới', N'Ứng viên Văn Thị Hương Giang đã ứng tuyển vào công việc Trưởng nhóm kinh doanh - Leader Sale.', N'Ứng tuyển', N'2025-04-13 22:44:18.823', N'0', N'CT090425cf51', N'CV130425br44')
GO

INSERT INTO [dbo].[tblThongBao] ([PK_sThongBao], [FK_sTenTaiKhoan], [sTieuDe], [sNoiDung], [sLoaiThongBao], [tNgayThongBao], [bDaXem], [FK_sMaCongTy], [FK_sMaCongViec]) VALUES (N'TB140425fa74', N'vhanh2k4', N'Trạng thái ứng tuyển đã được cập nhật', N'Hồ sơ ứng tuyển của bạn cho vị trí ''TELESALES CA TỐI 18H30 - 21H30'' đã được cập nhật trạng thái thành: Từ chối', N'UngTuyen', N'2025-04-14 00:28:32.323', N'0', N'CT100425ae98', N'CV130425gc59')
GO

INSERT INTO [dbo].[tblThongBao] ([PK_sThongBao], [FK_sTenTaiKhoan], [sTieuDe], [sNoiDung], [sLoaiThongBao], [tNgayThongBao], [bDaXem], [FK_sMaCongTy], [FK_sMaCongViec]) VALUES (N'TB140425rk04', N'vhanh2k4', N'Trạng thái ứng tuyển đã được cập nhật', N'Hồ sơ ứng tuyển của bạn cho vị trí ''TELESALES CA TỐI 18H30 - 21H30'' đã được cập nhật trạng thái thành: Chấp nhận', N'UngTuyen', N'2025-04-14 00:33:10.270', N'0', N'CT100425ae98', N'CV130425gc59')
GO

INSERT INTO [dbo].[tblThongBao] ([PK_sThongBao], [FK_sTenTaiKhoan], [sTieuDe], [sNoiDung], [sLoaiThongBao], [tNgayThongBao], [bDaXem], [FK_sMaCongTy], [FK_sMaCongViec]) VALUES (N'TB140425uy62', N'vhanh2k4', N'Trạng thái ứng tuyển đã được cập nhật', N'Hồ sơ ứng tuyển của bạn cho vị trí ''TELESALES CA TỐI 18H30 - 21H30'' đã được cập nhật trạng thái thành: Chấp nhận', N'UngTuyen', N'2025-04-14 00:25:56.637', N'0', N'CT100425ae98', N'CV130425gc59')
GO

INSERT INTO [dbo].[tblThongBao] ([PK_sThongBao], [FK_sTenTaiKhoan], [sTieuDe], [sNoiDung], [sLoaiThongBao], [tNgayThongBao], [bDaXem], [FK_sMaCongTy], [FK_sMaCongViec]) VALUES (N'TB140425wg33', N'nguoidung5', N'Thông báo ứng tuyển mới', N'Ứng viên Vũ Hoàng Anh đã ứng tuyển vào công việc TELESALES CA TỐI 18H30 - 21H30.', N'Ứng tuyển', N'2025-04-14 00:25:14.307', N'0', N'CT100425ae98', N'CV130425gc59')
GO


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
INSERT INTO [dbo].[tblUngTuyen] ([PK_sMaUngTuyen], [FK_sTenTaiKhoan], [FK_sMaCongViec], [tNgayUngTuyen], [sTrangThai]) VALUES (N'UT120425bh06', N'nguoidung1', N'CV100425nk15', N'2025-04-12 10:25:14.937', N'Đang chờ')
GO

INSERT INTO [dbo].[tblUngTuyen] ([PK_sMaUngTuyen], [FK_sTenTaiKhoan], [FK_sMaCongViec], [tNgayUngTuyen], [sTrangThai]) VALUES (N'UT120425hp49', N'nguoidung3', N'CV100425nk15', N'2025-04-12 10:27:13.843', N'Chấp nhận')
GO

INSERT INTO [dbo].[tblUngTuyen] ([PK_sMaUngTuyen], [FK_sTenTaiKhoan], [FK_sMaCongViec], [tNgayUngTuyen], [sTrangThai]) VALUES (N'UT120425nb60', N'nguoidung2', N'CV100425nk15', N'2025-04-12 10:26:10.180', N'Từ chối')
GO

INSERT INTO [dbo].[tblUngTuyen] ([PK_sMaUngTuyen], [FK_sTenTaiKhoan], [FK_sMaCongViec], [tNgayUngTuyen], [sTrangThai]) VALUES (N'UT130425ph13', N'nguoidung6', N'CV130425br44', N'2025-04-13 22:46:36.007', N'Đang chờ')
GO

INSERT INTO [dbo].[tblUngTuyen] ([PK_sMaUngTuyen], [FK_sTenTaiKhoan], [FK_sMaCongViec], [tNgayUngTuyen], [sTrangThai]) VALUES (N'UT130425pi51', N'nguoidung5', N'CV130425br44', N'2025-04-13 22:44:18.817', N'Đang chờ')
GO

INSERT INTO [dbo].[tblUngTuyen] ([PK_sMaUngTuyen], [FK_sTenTaiKhoan], [FK_sMaCongViec], [tNgayUngTuyen], [sTrangThai]) VALUES (N'UT130425vm48', N'nguoidung5', N'CV130425ax70', N'2025-04-13 22:45:22.220', N'Đang chờ')
GO

INSERT INTO [dbo].[tblUngTuyen] ([PK_sMaUngTuyen], [FK_sTenTaiKhoan], [FK_sMaCongViec], [tNgayUngTuyen], [sTrangThai]) VALUES (N'UT130425xi24', N'nguoidung6', N'CV130425ax70', N'2025-04-13 22:46:46.270', N'Đang chờ')
GO

INSERT INTO [dbo].[tblUngTuyen] ([PK_sMaUngTuyen], [FK_sTenTaiKhoan], [FK_sMaCongViec], [tNgayUngTuyen], [sTrangThai]) VALUES (N'UT140425zd33', N'vhanh2k4', N'CV130425gc59', N'2025-04-14 00:25:14.307', N'Chấp nhận')
GO


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












