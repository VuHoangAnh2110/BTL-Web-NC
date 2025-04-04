using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTL_Web_NC.Models
{
    [Table("tblHoSoUngVien")]
    public class HoSoUngVien
    {
        [Key]
        [Column("PK_sMaHoSo")]
        [StringLength(50)]
        public string? MaHoSo { get; set; }

        [Column("FK_sTenTaiKhoan")]
        [StringLength(50)]
        [Required] // Thêm Required vì trong DB là NOT NULL
        public string? TenTaiKhoan { get; set; }

        [Column("sGioiThieu")]
        public string? GioiThieu { get; set; }

        [Column("sKyNang")]
        public string? KyNang { get; set; }

        [Column("sKinhNghiem")]
        public string? KinhNghiem { get; set; }

        [Column("FK_sMaFile")]
        [StringLength(255)]
        public string? MaFile { get; set; }

        // Navigation Property với ForeignKey attribute
        [ForeignKey("TenTaiKhoan")]
        public virtual TaiKhoan? TaiKhoan { get; set; }
        
        // [ForeignKey("MaFile")]
        // public virtual FileUpload? File { get; set; }

    }
}
