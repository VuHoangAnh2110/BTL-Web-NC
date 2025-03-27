using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace BTL_Web_NC.ViewModels
{
    public class RegisterViewModel : IValidatableObject
    {
        [Required(ErrorMessage = "Vui lòng nhập họ và tên.")]
        public string? HoTen { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tên tài khoản.")]
        public string? TenTaiKhoan { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập email.")]
        [EmailAddress(ErrorMessage = "Email không hợp lệ.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập mật khẩu.")]
        [DataType(DataType.Password)]
        public string? MatKhau { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập số điện thoại.")]
        [Phone(ErrorMessage = "Số điện thoại không hợp lệ.")]
        public string? SoDienThoai { get; set; }

        [Required(ErrorMessage = "Vui lòng xác nhận mật khẩu.")]
        [DataType(DataType.Password)]
        [Compare("MatKhau", ErrorMessage = "Mật khẩu xác nhận không khớp.")]
        public string? XacNhanMatKhau { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn vai trò.")]
        public string? VaiTro { get; set; } = "ung_vien";

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();

            // Kiểm tra ký tự đặc biệt tên tài khoản
            if (!string.IsNullOrEmpty(TenTaiKhoan))
            {
                var specialChars = Regex.Matches(TenTaiKhoan, @"[^a-zA-Z0-9]");
                if (specialChars.Count > 4)
                {
                    errors.Add(new ValidationResult("Tên tài khoản không được chứa quá 4 ký tự đặc biệt.", new[] { nameof(TenTaiKhoan) }));
                }
            }

            // Kiểm tra mật khẩu
            if (!string.IsNullOrEmpty(MatKhau))
            {
                if (MatKhau.Length < 8)
                {
                    errors.Add(new ValidationResult("Mật khẩu phải có ít nhất 8 ký tự.", new[] { nameof(MatKhau) }));
                }

                if (!Regex.IsMatch(MatKhau, @"[A-Za-z]") || !Regex.IsMatch(MatKhau, @"[0-9]"))
                {
                    errors.Add(new ValidationResult("Mật khẩu phải chứa cả chữ và số.", new[] { nameof(MatKhau) }));
                }

                if (!Regex.IsMatch(MatKhau, @"[^A-Za-z0-9]"))
                {
                    errors.Add(new ValidationResult("Mật khẩu phải chứa ít nhất 1 ký tự đặc biệt.", new[] { nameof(MatKhau) }));
                }
            }

            return errors;
        }
    }
}
