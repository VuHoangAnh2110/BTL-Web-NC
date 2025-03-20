using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTL_Web_NC.Models
{
    [Table("tblFile")]
    public class FileUpload
    {
        [Key]
        [Column("PK_sMaFile")]
        [StringLength(50)]
        public string? MaFile { get; set; }

        [Column("sTenfile")]
        [StringLength(50)]
        public string? TenFile { get; set; }

        [Column("FK_sTenTaiKhoan")]
        [StringLength(50)]
        public string? TenTaiKhoan { get; set; }

        [Column("sLoaiFile")]
        [StringLength(50)]
        public string? LoaiFile { get; set; }

        [Column("sDuongDan")]
        [Required]
        [StringLength(255)]
        public string? DuongDan { get; set; }

        [Column("tNgayTaiLen")]
        public DateTime NgayTaiLen { get; set; } = DateTime.Now;

        // Navigation Property
        public virtual TaiKhoan? TaiKhoan { get; set; }


    }
}
