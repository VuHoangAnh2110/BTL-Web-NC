using System;
using System.ComponentModel.DataAnnotations;

namespace BTL_Web_NC.ViewModels
{
    public class EditCongViecViewModel : IValidatableObject
    {
        public string MaCongViec { get; set; }
        
        [Required(ErrorMessage = "Vui lòng nhập tiêu đề công việc.")]
        [StringLength(255, ErrorMessage = "Tiêu đề không được vượt quá 255 ký tự.")]
        public string? TieuDe { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập mô tả công việc.")]
        public string? MoTa { get; set; }

        [StringLength(255, ErrorMessage = "Địa điểm không được vượt quá 255 ký tự.")]
        public string? DiaDiem { get; set; }

        [StringLength(225, ErrorMessage = "Mức lương không được vượt quá 225 ký tự.")]
        public string? MucLuong { get; set; }

        [StringLength(50, ErrorMessage = "Loại hình không được vượt quá 50 ký tự.")]
        public string? LoaiHinh { get; set; } = "Full-time";

        [Range(1, 1000, ErrorMessage = "Số lượng tuyển phải từ 1 đến 1000.")]
        public int SoLuongTuyen { get; set; } = 1;

        [DataType(DataType.Date)]
        public DateTime? NgayHetHan { get; set; }

        [StringLength(200, ErrorMessage = "Cấp bậc không được vượt quá 200 ký tự.")]
        public string? CapBac { get; set; }

        [StringLength(225, ErrorMessage = "Ngành nghề không được vượt quá 225 ký tự.")]
        public string? NganhNghe { get; set; }

        public string? QuyenLoi { get; set; }

        public string? YeuCau { get; set; }
        
        [StringLength(25, ErrorMessage = "Trạng thái không được vượt quá 25 ký tự.")]
        public string? TrangThai { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();

            // Kiểm tra độ dài của mô tả
            if (!string.IsNullOrEmpty(MoTa) && MoTa.Length < 50)
            {
                errors.Add(new ValidationResult(
                    "Mô tả công việc cần tối thiểu 50 ký tự để cung cấp đủ thông tin.",
                    new[] { nameof(MoTa) }
                ));
            }

            // Kiểm tra ngày hết hạn phải lớn hơn hoặc bằng ngày hiện tại
            if (NgayHetHan.HasValue && NgayHetHan.Value.Date < DateTime.Now.Date)
            {
                errors.Add(new ValidationResult(
                    "Ngày hết hạn phải lớn hơn hoặc bằng ngày hiện tại.",
                    new[] { nameof(NgayHetHan) }
                ));
            }

            return errors;
        }
    }
}