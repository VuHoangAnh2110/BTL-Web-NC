using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTL_Web_NC.Models
{
    [Table("tblThongBao")]
    public class ThongBao
    {
        [Key]
        [Column("PK_sThongBao")]
        [StringLength(50)]
        public string? MaThongBao { get; set; }

        [Column("FK_sTenTaiKhoan")]
        [StringLength(50)]
        public string? TenTaiKhoan { get; set; }

        [Column("sTieuDe")]
        [Required]
        [StringLength(255)]
        public string? TieuDe { get; set; }

        [Column("sNoiDung")]
        [Required]
        public string? NoiDung { get; set; }

        [Column("sLoaiThongBao")]
        [StringLength(50)]
        public string? LoaiThongBao { get; set; }

        [Column("tNgayTao")]
        public DateTime NgayTao { get; set; } = DateTime.Now;

        // Navigation Property
        public virtual TaiKhoan? TaiKhoan { get; set; }

    }
}
