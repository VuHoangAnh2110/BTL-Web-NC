using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace BTL_Web_NC.ViewModels
{
    public class LoginViewModel : IValidatableObject
    {
        [Required(ErrorMessage = "Vui lòng nhập email hoặc tên tài khoản.")]
        [StringLength(255, ErrorMessage = "Không vượt quá 255 ký tự.")]
        [Display(Name = "Email/Tên tài khoản")]
        public string? UsernameOrEmail { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập mật khẩu.")]
        [MinLength(8, ErrorMessage = "Mật khẩu phải có ít nhất 8 ký tự.")]
        [Display(Name = "Mật khẩu")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();

            if (!string.IsNullOrEmpty(UsernameOrEmail))
            {
                var specialChars = Regex.Matches(UsernameOrEmail, @"[^a-zA-Z0-9]");
                if (specialChars.Count > 4)
                {
                    errors.Add(new ValidationResult("Tên tài khoản không được chứa quá 4 ký tự đặc biệt.",
                        new[] { nameof(UsernameOrEmail) }));
                }
            }

            if (!string.IsNullOrEmpty(Password))
            {
                // if (!Regex.IsMatch(Password, @"[A-Za-z]") || !Regex.IsMatch(Password, @"[0-9]"))
                // {
                //     errors.Add(new ValidationResult("Mật khẩu phải chứa cả chữ và số.", new[] { nameof(Password) }));
                // }
                // if (!Regex.IsMatch(Password, @"[^A-Za-z0-9]"))
                // {
                //     errors.Add(new ValidationResult("Mật khẩu phải chứa ít nhất 1 ký tự đặc biệt.", new[] { nameof(Password) }));
                // }
            }

            return errors;
        }
    }
}
