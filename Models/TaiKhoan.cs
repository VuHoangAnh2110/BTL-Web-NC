using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTL_Web_NC.Models
{
    [Table("tblTaiKhoan")]
    public class TaiKhoan
    {
        [Key]
        [Column("PK_sTenTaiKhoan")]
        [StringLength(50,ErrorMessage = "Không quá 50 ký tự!")]
        public string? TenTaiKhoan { get; set; }

        [Column("sHoTen")]
        [Required(ErrorMessage = "Không được để trống!")]
        [StringLength(255)]
        public string? HoTen { get; set; }

        [Column("sEmail")]
        [Required (ErrorMessage = "Không được để trống!")]
        [StringLength(255)]
        [EmailAddress]
        public string? Email { get; set; }

        [Column("sMatKhau")]
        [Required (ErrorMessage = "Không được để trống!")]
        public string? MatKhau { get; set; }

        [Column("sSoDienThoai")]
        [StringLength(20)]
        [Required (ErrorMessage = "Không được để trống!")]
        public string? SoDienThoai { get; set; }

        [Column("sDiaChi")]
        public string? DiaChi { get; set; }

        [Column("sAnhDaiDien")]
        public string? AnhDaiDien { get; set; }

        [Column("sVaiTro")]
        [StringLength(50)]
        public string VaiTro { get; set; } = "ung_vien";

        [Column("TrangThai")]
        public bool TrangThai { get; set; } = true;

        [Column("tNgayTao")]
        public DateTime NgayTao { get; set; } = DateTime.Now;

        [Column("tNgayCapNhat")]
        public DateTime NgayCapNhat { get; set; } = DateTime.Now;

        // Navigation Properties
        public virtual ICollection<CongTy>? CongTys { get; set; }
        public virtual ICollection<FileUpload>? Files { get; set; }
        public virtual ICollection<HoSoUngVien>? HoSoUngViens { get; set; }
        public virtual ICollection<ThongBao>? ThongBaos { get; set; }
    }
}
