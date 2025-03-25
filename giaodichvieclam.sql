IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='tblTaiKhoan' AND xtype='U')
CREATE TABLE tblTaiKhoan (
    PK_sTenTaiKhoan VARCHAR(50) PRIMARY KEY,
    sHoTen NVARCHAR(255) NOT NULL,
    sEmail NVARCHAR(255) UNIQUE NOT NULL,
    sMatKhau NVARCHAR(MAX) NOT NULL,
    sSoDienThoai VARCHAR(20),
    sDiaChi NVARCHAR(MAX),
    sAnhDaiDien NVARCHAR(255),
    sVaiTro VARCHAR(50) NOT NULL DEFAULT 'ung_vien',
    iTrangThai INT DEFAULT 1 NOT NULL,
    tNgayTao DATETIME DEFAULT GETDATE(),
    tNgayCapNhat DATETIME DEFAULT GETDATE(),
    CONSTRAINT chk_sVaitro CHECK (sVaiTro IN ('admin', 'nha_tuyen_dung', 'ung_vien'))
);

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='tblThongBao' AND xtype='U')
CREATE TABLE tblThongBao (
    PK_sThongBao VARCHAR(50) PRIMARY KEY,
    FK_sTenTaiKhoan VARCHAR(50) NOT NULL,
    sTieuDe NVARCHAR(255) NOT NULL,
    sNoiDung NVARCHAR(MAX) NOT NULL,
    sLoaiThongBao VARCHAR(50),
    tNgayTao DATETIME DEFAULT GETDATE(),
    CONSTRAINT fk_thongbao_taikhoan FOREIGN KEY (FK_sTenTaiKhoan) 
        REFERENCES tblTaiKhoan(PK_sTenTaiKhoan) ON DELETE CASCADE ON UPDATE CASCADE
);

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='tblCongTy' AND xtype='U')
CREATE TABLE tblCongTy (
    PK_sMaCongTy VARCHAR(50) PRIMARY KEY,
    FK_sTenTaiKhoan VARCHAR(50) UNIQUE,
    sTenCongTy NVARCHAR(255) NOT NULL,
    sDiaChi NVARCHAR(MAX),
    sMoTa NVARCHAR(MAX),
    sWebsite NVARCHAR(255),
    sLogo NVARCHAR(255),
    CONSTRAINT fk_congty_taikhoan FOREIGN KEY (FK_sTenTaiKhoan) 
        REFERENCES tblTaiKhoan(PK_sTenTaiKhoan) ON DELETE CASCADE ON UPDATE CASCADE
);

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='tblCongViec' AND xtype='U')
CREATE TABLE tblCongViec (
    PK_sMaCongViec VARCHAR(50) PRIMARY KEY,
    FK_sMaCongTy VARCHAR(50) NOT NULL,
    sTieuDe NVARCHAR(255) NOT NULL,
    sMoTa NVARCHAR(MAX) NOT NULL,
    sDiaDiem NVARCHAR(255),
    fMucLuong FLOAT,
    sLoaiHinh VARCHAR(50),
    tNgayDang DATETIME DEFAULT GETDATE(),
    CONSTRAINT fk_congviec_congty FOREIGN KEY (FK_sMaCongTy) 
        REFERENCES tblCongTy(PK_sMaCongTy) ON DELETE CASCADE ON UPDATE CASCADE
);

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='tblHoSoUngVien' AND xtype='U')
CREATE TABLE tblHoSoUngVien (
    PK_sMaHoSo VARCHAR(50) PRIMARY KEY,
    FK_sTenTaiKhoan VARCHAR(50) NOT NULL,
    sGioiThieu NVARCHAR(MAX),
    sKyNang NVARCHAR(MAX),
    sKinhNghiem NVARCHAR(MAX),
    FK_sMaFile NVARCHAR(255),
    CONSTRAINT fk_hoso_taikhoan FOREIGN KEY (FK_sTenTaiKhoan) 
        REFERENCES tblTaiKhoan(PK_sTenTaiKhoan) ON DELETE CASCADE ON UPDATE CASCADE
);

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='tblFile' AND xtype='U')
CREATE TABLE tblFile (
    PK_sMaFile VARCHAR(50) PRIMARY KEY,
    sTenfile VARCHAR(50) NOT NULL,
    FK_sTenTaiKhoan VARCHAR(50) NOT NULL,
    sLoaiFile VARCHAR(50),
    sDuongDan NVARCHAR(255) NOT NULL,
    tNgayTaiLen DATETIME DEFAULT GETDATE(),
    CONSTRAINT fk_file_taikhoan FOREIGN KEY (FK_sTenTaiKhoan) 
        REFERENCES tblTaiKhoan(PK_sTenTaiKhoan) ON DELETE CASCADE ON UPDATE CASCADE
);
