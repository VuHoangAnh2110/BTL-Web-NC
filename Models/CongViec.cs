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

        [Column("fMucLuong")]
        public double? MucLuong { get; set; }

        [Column("sLoaiHinh")]
        [StringLength(50)]
        public string? LoaiHinh { get; set; }

        [Column("tNgayDang")]
        public DateTime NgayDang { get; set; } = DateTime.Now;

        public virtual CongTy? CongTy { get; set; }

    }
}
