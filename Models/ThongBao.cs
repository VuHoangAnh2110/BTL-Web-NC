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
        [Required] // Thêm Required vì trong DB là NOT NULL
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

        [Column("tNgayThongBao")] // Sửa tên cột cho đúng
        public DateTime NgayThongBao { get; set; } = DateTime.Now;

        [Column("bDaXem")] // Thêm trường này
        public bool DaXem { get; set; } = false;

        [Column("FK_sMaCongTy")]
        [StringLength(50)]
        public string? MaCongTy { get; set; }

        [Column("FK_sMaCongViec")]
        [StringLength(50)]
        public string? MaCongViec { get; set; }

        // Navigation Properties - Thêm ForeignKey attributes
        [ForeignKey("TenTaiKhoan")]
        public virtual TaiKhoan? TaiKhoan { get; set; }

        [ForeignKey("MaCongTy")]
        public virtual CongTy? CongTy { get; set; }

        [ForeignKey("MaCongViec")]
        public virtual CongViec? CongViec { get; set; }
        
    }
}
