using System.ComponentModel.DataAnnotations;

namespace BTL_Web_NC.ViewModels
{
    public class DoiMatKhauViewModel
    {
        [Required(ErrorMessage = "Vui lòng nhập mật khẩu hiện tại")]
        public string? MatKhauCu { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập mật khẩu mới")]
        [StringLength(100, ErrorMessage = "Mật khẩu phải có ít nhất {2} ký tự", MinimumLength = 8)]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$", 
            ErrorMessage = "Mật khẩu phải chứa ít nhất 8 ký tự, bao gồm chữ, số và ký tự đặc biệt")]
        public string? MatKhauMoi { get; set; }

        [Compare("MatKhauMoi", ErrorMessage = "Xác nhận mật khẩu không khớp")]
        public string? XacNhanMatKhau { get; set; }
    }
}