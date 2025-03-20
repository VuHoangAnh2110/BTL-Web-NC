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

        // Navigation Property
        public virtual TaiKhoan? TaiKhoan { get; set; }
        public virtual FileUpload? File { get; set; }

    }
}
