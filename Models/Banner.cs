using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTL_Web_NC.Models
{
    [Table("tblBanner")]
    public class Banner
    {
        [Key]
        [Column("PK_sMaBanner")]
        public string? MaBanner { get; set; }

        [Column("sTieuDe")]
        public string? TieuDe { get; set; }

        [Column("sMoTa")]
        public string? MoTa { get; set; }

        [Column("sDuongDanAnh")]
        public string? DuongDanAnh { get; set; }

        [Column("sLienKet")]
        public string? LienKet { get; set; }

        [Column("tNgayTao")]
        public DateTime NgayTao { get; set; }
    }
}