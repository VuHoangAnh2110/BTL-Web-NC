using System.ComponentModel.DataAnnotations;

namespace BTL_Web_NC.ViewModels
{
    public class CapNhatTKViewModel
    {
        [Required(ErrorMessage = "Tên tài khoản không được để trống")]
        public string? TenTaiKhoan { get; set; }

        [Required(ErrorMessage = "Họ tên không được để trống")]
        [StringLength(255, ErrorMessage = "Họ tên không quá 255 ký tự")]
        public string? HoTen { get; set; }

        [Required(ErrorMessage = "Email không được để trống")]
        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        [StringLength(255, ErrorMessage = "Email không quá 255 ký tự")]
        public string? Email { get; set; }

        [Phone(ErrorMessage = "Số điện thoại không hợp lệ")]
        [StringLength(20, ErrorMessage = "Số điện thoại không quá 20 ký tự")]
        public string? SoDienThoai { get; set; }

        public string? DiaChi { get; set; }

        [Required(ErrorMessage = "Vai trò không được để trống")]
        [StringLength(50, ErrorMessage = "Vai trò không quá 50 ký tự")]
        public string? VaiTro { get; set; }

        [Required(ErrorMessage = "Trạng thái không được để trống")]
        [Range(1, 3, ErrorMessage = "Trạng thái không hợp lệ")]
        public int TrangThai { get; set; }

        // Thuộc tính để hiển thị text của trạng thái
        public string? TrangThaiText 
        { 
            get 
            {
                return TrangThai switch
                {
                    1 => "Chờ duyệt",
                    2 => "Hoạt động",
                    3 => "Đã khóa",
                    _ => "Không xác định"
                };
            }
        }
    }
}