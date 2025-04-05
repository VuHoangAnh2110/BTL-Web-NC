using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTL_Web_NC.Models
{
    [Table("tblUngTuyen")]
    public class UngTuyen
    {
        [Key]
        [Column("PK_sMaUngTuyen")]
        [StringLength(50)]
        public string? MaUngTuyen { get; set; }

        [Column("FK_sTenTaiKhoan")]
        [StringLength(50)]
        [Required] // Thêm Required vì trong DB là NOT NULL
        public string? TenTaiKhoan { get; set; }

        [Column("FK_sMaCongViec")]
        [StringLength(50)]
        [Required] // Thêm Required vì trong DB là NOT NULL
        public string? MaCongViec { get; set; }

        [Column("tNgayUngTuyen")]
        public DateTime NgayUngTuyen { get; set; } = DateTime.Now;

        [Column("sTrangThai")]
        [StringLength(100)]
        public string? TrangThai { get; set; } = "Đang chờ";

        // Navigation Properties với ForeignKey attributes
        [ForeignKey("TenTaiKhoan")]
        public virtual TaiKhoan? TaiKhoan { get; set; }

        [ForeignKey("MaCongViec")]
        public virtual CongViec? CongViec { get; set; }

        
    }
}