using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTL_Web_NC.Models
{
    [Table("tblCongViec")]
    public class CongViec
    {
        [Key]
        [Column("PK_sMaCongViec")]
        [StringLength(50)]
        public string? MaCongViec { get; set; }

        [Column("FK_sMaCongTy")]
        [StringLength(50)]
        [Required] // Bổ sung Required vì trong DB là NOT NULL
        public string? MaCongTy { get; set; }

        [Column("sTieuDe")]
        [Required]
        [StringLength(255)]
        public string? TieuDe { get; set; }

        [Column("sMoTa")]
        [Required]
        public string? MoTa { get; set; }

        [Column("sDiaDiem")]
        [StringLength(255)]
        public string? DiaDiem { get; set; }

        [Column("sMucLuong")]
        [StringLength(225)]
        public string? MucLuong { get; set; }

        [Column("sLoaiHinh")]
        [StringLength(50)]
        public string? LoaiHinh { get; set; }

        [Column("tNgayDang")]
        public DateTime NgayDang { get; set; } = DateTime.Now;

        // Thêm trường TrangThai còn thiếu
        [Column("sTrangThai")]
        [StringLength(25)]
        public string? TrangThai { get; set; }

        [Column("iSoLuongTuyen")]
        public int? SoLuongTuyen { get; set; } = 1;

        [Column("tNgayHetHan")]
        public DateTime? NgayHetHan { get; set; }

        [Column("sCapBac")]
        [StringLength(200)]
        public string? CapBac { get; set; }

        [Column("sNganhNghe")]
        [StringLength(225)]
        public string? NganhNghe { get; set; }

        [Column("sQuyenLoi")]
        public string? QuyenLoi { get; set; }

        [Column("sYeuCau")]
        public string? YeuCau { get; set; }

        // Quan hệ với bảng CongTy
        [ForeignKey("MaCongTy")]
        public virtual CongTy? CongTy { get; set; }

        // Quan hệ 1-nhiều với bảng UngTuyen ()
        public virtual ICollection<UngTuyen>? DanhSachUngTuyen { get; set; }

        // Quan hệ 1-nhiều với bảng ThongBao ()
        [InverseProperty("CongViec")] 
        public virtual ICollection<ThongBao>? DanhSachThongBao { get; set; }

    }
}
