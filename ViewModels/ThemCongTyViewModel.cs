using System.ComponentModel.DataAnnotations;

namespace BTL_Web_NC.ViewModels
{
    public class ThemCongTyViewModel
    {
        [Required(ErrorMessage = "Tên công ty không được bỏ trống")]
        [StringLength(255, ErrorMessage = "Tên công ty không được vượt quá 255 ký tự")]
        [Display(Name = "Tên công ty")]
        public string TenCongTy { get; set; }

        [StringLength(255, ErrorMessage = "Địa chỉ không được vượt quá 255 ký tự")]
        [Display(Name = "Địa chỉ")]
        public string? DiaChi { get; set; }

        [StringLength(500, ErrorMessage = "Mô tả không được vượt quá 500 ký tự")]
        [Display(Name = "Mô tả")]
        public string? MoTa { get; set; }

        [StringLength(255, ErrorMessage = "Website không được vượt quá 255 ký tự")]
        [Display(Name = "Website")]
        [Url(ErrorMessage = "Website không hợp lệ")]
        [Required(ErrorMessage = "Website không được bỏ trống")]
        public string? Website { get; set; }

        [StringLength(255, ErrorMessage = "Logo (URL) không được vượt quá 255 ký tự")]
        [Display(Name = "Logo (URL)")]
        public string? Logo { get; set; }

        [StringLength(20, ErrorMessage = "Số điện thoại không được vượt quá 20 ký tự")]
        [Phone(ErrorMessage = "Số điện thoại không hợp lệ")]
        [Display(Name = "Số điện thoại")]
        [Required(ErrorMessage = "Số điện thoại không được bỏ trống")]
        public string? SoDienThoai { get; set; }

        [StringLength(255, ErrorMessage = "Tài khoản liên kết không được vượt quá 255 ký tự")]
        [Display(Name = "Tài khoản liên kết (nếu có)")]
        public string? TenTaiKhoan { get; set; }
    }
}
