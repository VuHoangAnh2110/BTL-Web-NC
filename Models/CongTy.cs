using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTL_Web_NC.Models
{
    [Table("tblCongTy")]
    public class CongTy
    {
        [Key]
        [Column("PK_sMaCongTy")]
        [StringLength(50)]
        public string? MaCongTy { get; set; }

        [Column("FK_sTenTaiKhoan")]
        [StringLength(50)]
        public string? TenTaiKhoan { get; set; }

        [Column("sTenCongTy")]
        [Required]
        [StringLength(255)]
        public string? TenCongTy { get; set; }

        [Column("sDiaChi")]
        public string? DiaChi { get; set; }

        [Column("sMoTa")]
        public string? MoTa { get; set; }

        [Column("sWebsite")]
        [StringLength(255)]
        public string? Website { get; set; }

        [Column("sLogo")]
        [StringLength(255)]
        public string? Logo { get; set; }

        [Column("sSoDienThoai")]
        [StringLength(20)]
        // SoDienThoai là NULL trong database nên không bắt buộc
        public string? SoDienThoai { get; set; }

        [Column("iTrangThai")]
        public int TrangThai { get; set; } = 2;

        [Column("tNgayDangKy")]
        public DateTime NgayTao { get; set; } = DateTime.Now;

        // Navigation Property - Sửa lại ForeignKey để trỏ đến tên property chứ không phải tên cột
        [ForeignKey("TenTaiKhoan")]
        public virtual TaiKhoan? TaiKhoan { get; set; }
        
        // 
        public virtual ICollection<CongViec>? DanhSachCongViec { get; set; }
    }
}