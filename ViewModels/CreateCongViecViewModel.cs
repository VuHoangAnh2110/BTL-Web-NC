using System;
using System.ComponentModel.DataAnnotations;

namespace BTL_Web_NC.ViewModels
{
    public class CreateCongViecViewModel : IValidatableObject
    {
        [Required(ErrorMessage = "Vui lòng nhập tiêu đề công việc.")]
        [StringLength(255, ErrorMessage = "Tiêu đề không được vượt quá 255 ký tự.")]
        public string? TieuDe { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập mô tả công việc.")]
        public string? MoTa { get; set; }

        [StringLength(255, ErrorMessage = "Địa điểm không được vượt quá 255 ký tự.")]
        public string? DiaDiem { get; set; }

        [StringLength(225)]
        public string? MucLuong { get; set; }

        [StringLength(50, ErrorMessage = "Loại hình không được vượt quá 50 ký tự.")]
        public string? LoaiHinh { get; set; } = "Full-time";

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();

            // Kiểm tra MucLuong nếu được nhập phải lớn hơn 0
            // if (MucLuong.HasValue && MucLuong <= 0)
            // {
            //     errors.Add(new ValidationResult(
            //         "Mức lương phải lớn hơn 0.",
            //         new[] { nameof(MucLuong) }
            //     ));
            // }

            // Kiểm tra độ dài của mô tả
            if (!string.IsNullOrEmpty(MoTa) && MoTa.Length < 50)
            {
                errors.Add(new ValidationResult(
                    "Mô tả công việc cần tối thiểu 50 ký tự để cung cấp đủ thông tin.",
                    new[] { nameof(MoTa) }
                ));
            }

            return errors;
        }
    }
}