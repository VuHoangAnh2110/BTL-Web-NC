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

        // Sửa tên cột từ fMucLuong thành dMucLuong và kiểu dữ liệu từ double sang decimal
        [Column("dMucLuong")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal? MucLuong { get; set; }

        [Column("sLoaiHinh")]
        [StringLength(50)]
        public string? LoaiHinh { get; set; }

        [Column("tNgayDang")]
        public DateTime NgayDang { get; set; } = DateTime.Now;

        // Thêm trường TrangThai còn thiếu
        [Column("sTrangThai")]
        [StringLength(25)]
        public string? TrangThai { get; set; }

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
