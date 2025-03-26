using System.ComponentModel.DataAnnotations;

public class RegisterViewModel
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
    public string? VaiTro { get; set; }  = "ung_vien";


}
