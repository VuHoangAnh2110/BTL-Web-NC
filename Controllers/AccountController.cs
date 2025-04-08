using BTL_Web_NC.Models;
using BTL_Web_NC.Repositories;
using Microsoft.AspNetCore.Mvc;
using BTL_Web_NC.ViewModels;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using BTL_Web_NC.Services;

namespace BTL_Web_NC.Controllers
{
    public class AccountController : Controller
    {
        private readonly ITaiKhoanRepository _taiKhoanRepo;
        private readonly IEmailService _emailService;

        public AccountController(ITaiKhoanRepository TaiKhoanRepo, IEmailService EmailService)
        {
            _taiKhoanRepo = TaiKhoanRepo;
            _emailService = EmailService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        //Đăng ký
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            // Kiểm tra nếu có file được gửi lên
            var hasFile = Request.Form.Files.Any();
            if (hasFile)
            {
                ModelState.AddModelError(string.Empty, "Không được upload file trong form đăng ký.");
                HttpContext.Session.SetString("WarningMessage", "Đăng ký không thành công! Không được upload file.");
                return View(model);
            }

            TaiKhoan taiKhoan = new TaiKhoan();
            if (ModelState.IsValid)
            {
                // Kiểm tra email đã tồn tại
                var existingUser = await _taiKhoanRepo.GetByEmailAsync(model.Email);
                if (existingUser != null)
                {
                    ModelState.AddModelError(nameof(model.Email), "Email đã tồn tại!");
                }
                // Kiểm tra tên tài khoản đã tồn tại
                var existingUserName = await _taiKhoanRepo.GetByTenTaiKhoanAsync(model.TenTaiKhoan);
                if (existingUserName != null)
                {
                    ModelState.AddModelError(nameof(model.TenTaiKhoan), "Tên tài khoản đã tồn tại!");
                }
                // Kiểm tra số điện thoại đã tồn tại
                if (!string.IsNullOrEmpty(model.SoDienThoai)){
                    var existingPhone = await _taiKhoanRepo.GetBySoDienThoaiAsync(model.SoDienThoai);
                    if (existingPhone != null)
                    {
                        ModelState.AddModelError(nameof(model.SoDienThoai), "Số điện thoại đã tồn tại!");
                    }
                }
                // Nếu có bất kỳ lỗi nào thì trả về view kèm thông báo
                if (!ModelState.IsValid)
                {
                    HttpContext.Session.SetString("WarningMessage", "Đăng ký tài khoản không thành công!");
                    return View(model);
                }

                // Mã hóa mật khẩu sử dụng BCrypt
                string passwordHash = BCrypt.Net.BCrypt.HashPassword(model.MatKhau);

                // Gán dữ liệu
                taiKhoan.NgayTao = DateTime.Now;
                taiKhoan.NgayCapNhat = DateTime.Now;
                taiKhoan.TenTaiKhoan = model.TenTaiKhoan;
                taiKhoan.HoTen = model.HoTen;
                taiKhoan.Email = model.Email;
                taiKhoan.MatKhau = passwordHash;
                taiKhoan.SoDienThoai = model.SoDienThoai;
                taiKhoan.VaiTro = "user";
                taiKhoan.TrangThai = 2;
                // taiKhoan.VaiTro = model.VaiTro;

                // Gán trạng thái theo vai trò
                // if (model.VaiTro == "ung_vien")
                // {   
                //     taiKhoan.VaiTro = "user";
                //     taiKhoan.TrangThai = 2;
                // }
                // else if (model.VaiTro == "nha_tuyen_dung")
                // {
                //     taiKhoan.VaiTro = "user";
                //     taiKhoan.TrangThai = 2;
                // } else {
                //     taiKhoan.TrangThai = 1;
                // }

                await _taiKhoanRepo.AddTaiKhoanAsync(taiKhoan);

                // Gửi email xác nhận đăng ký thành công
                try
                {
                    // Gửi email xác nhận đăng ký thành công
                    await GuiEmailXacNhanDangKy(taiKhoan);
                    HttpContext.Session.SetString("SuccessMessage", "Đăng ký tài khoản thành công! Email xác nhận đã được gửi.");
                }
                catch (Exception)
                {
                    // Nếu gửi email thất bại, vẫn thông báo đăng ký thành công
                    HttpContext.Session.SetString("SuccessMessage", "Đăng ký tài khoản thành công! Nhưng không thể gửi email xác nhận.");
                }

                // HttpContext.Session.SetString("SuccessMessage", "Đăng ký tài khoản thành công!");
                return View();
            } else {
                HttpContext.Session.SetString("WarningMessage", "Đăng ký tài khoản không thành công!");
                return View(model);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var hasFile = Request.Form.Files.Any();
            if (hasFile)
            {
                ModelState.AddModelError(string.Empty, "Không được upload file.");
                HttpContext.Session.SetString("WarningMessage", "Đăng nhập không thành công! Không được upload file.");
                return View(model);            
            }

            if(ModelState.IsValid){
                // Lấy tài khoản theo email hoặc tên tài khoản
                var user = await _taiKhoanRepo.GetByUsernameOrEmailAsync(model.UsernameOrEmail);
                if(user == null || !BCrypt.Net.BCrypt.Verify(model.Password, user.MatKhau)){
                    HttpContext.Session.SetString("WarningMessage", "Tài khoản hoặc mật khẩu không chính xác!");
                    return View(model);
                }

                // Lưu thông tin người dùng vào Session
                HttpContext.Session.SetString("Email", user.Email ?? "");
                HttpContext.Session.SetString("HoTen", user.HoTen ?? "");
                HttpContext.Session.SetString("TenTaiKhoan", user.TenTaiKhoan ?? "");
                HttpContext.Session.SetString("VaiTro", user.VaiTro);

                if (user.TrangThai == 2)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.TenTaiKhoan),
                        new Claim(ClaimTypes.Role, user.VaiTro) 
                    };
                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var authProperties = new AuthenticationProperties
                    {
                        IsPersistent = false
                    };
                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity),
                        authProperties
                    );

                    HttpContext.Session.SetString("SuccessMessage", "Đăng nhập thành công!");
                    return RedirectToAction("Index", "Home");
                }
                else if (user.TrangThai == 3)
                {
                    HttpContext.Session.SetString("ErrorMessage", "Tài khoản đã bị khóa. Liên hệ quản trị viên!");
                    return View(model);
                } else 
                {
                    HttpContext.Session.SetString("WarningMessage", "Tài khoản đang chờ phê duyệt. Quay lại sau!");
                    return View(model);
                }
            } else {
                HttpContext.Session.SetString("WarningMessage", "Tài khoản hoặc mật khẩu không chính xác!");
                return View(model);
            }            
        }

        public async Task<IActionResult> LogoutAsync()
        {
            // Xóa thông tin người dùng khỏi Session 
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
    
            // Xóa toàn bộ session
            HttpContext.Session.Clear();
            
            // Xóa cookie xác thực
            Response.Cookies.Delete(".AspNetCore.Cookies");          
               
            return RedirectToAction("Login");
        }

        [HttpGet]
        public async Task<IActionResult> LayThongTinTK(string TenTaiKhoan)
        {
            if (string.IsNullOrEmpty(TenTaiKhoan))
                return BadRequest(new { success = false, message = "Không có dữ liệu tên tài khoản" });

            var account = await _taiKhoanRepo.GetByTenTaiKhoanAsync(TenTaiKhoan);

            if (account == null)
                return NotFound(new { success = false, message = "Không tìm thấy tài khoản" });

            return Json(new
            {
                success = true,
                taikhoan = new
                {
                    tenTaiKhoan = account.TenTaiKhoan,
                    hoTen = account.HoTen,
                    email = account.Email,
                    soDienThoai = account.SoDienThoai,
                    diaChi = account.DiaChi,
                    anhDaiDien = account.AnhDaiDien,
                    vaiTro = account.VaiTro,
                    trangThai = account.TrangThai,
                    ngayTao = account.NgayTao,
                    ngayCapNhat = account.NgayCapNhat
                }
            });
        }

        // Gửi email xác nhận tài khoản
        private async Task GuiEmailXacNhanDangKy(TaiKhoan taiKhoan)
        {
            string subject = "Xác nhận đăng ký tài khoản thành công";
            string body = $@"
                <html>
                <head>
                    <style>
                        body {{
                            font-family: Arial, sans-serif;
                            line-height: 1.6;
                            color: #333;
                        }}
                        .container {{
                            max-width: 600px;
                            margin: 0 auto;
                            padding: 20px;
                            border: 1px solid #ddd;
                            border-radius: 5px;
                        }}
                        .header {{
                            background-color: #4CAF50;
                            color: white;
                            padding: 10px;
                            text-align: center;
                            border-radius: 5px 5px 0 0;
                        }}
                        .content {{
                            padding: 20px;
                        }}
                        .footer {{
                            background-color: #f1f1f1;
                            padding: 10px;
                            text-align: center;
                            border-radius: 0 0 5px 5px;
                        }}
                    </style>
                </head>
                <body>
                    <div class='container'>
                        <div class='header'>
                            <h2>Đăng Ký Thành Công</h2>
                        </div>
                        <div class='content'>
                            <p>Xin chào <b>{taiKhoan.HoTen}</b>,</p>
                            <p>Chúc mừng bạn đã đăng ký tài khoản thành công! Dưới đây là thông tin tài khoản của bạn:</p>
                            <ul>
                                <li><b>Tên tài khoản:</b> {taiKhoan.TenTaiKhoan}</li>
                                <li><b>Email:</b> {taiKhoan.Email}</li>
                                <li><b>Ngày đăng ký:</b> {taiKhoan.NgayTao.ToString("dd/MM/yyyy HH:mm:ss")}</li>
                            </ul>
                            <p>Bạn có thể đăng nhập ngay bây giờ để trải nghiệm các dịch vụ của chúng tôi.</p>
                            <p>Nếu bạn có bất kỳ thắc mắc nào, vui lòng liên hệ với chúng tôi qua email hỗ trợ.</p>
                            <p>Trân trọng,<br>Đội ngũ hỗ trợ</p>
                        </div>
                        <div class='footer'>
                            <p>© {DateTime.Now.Year} Công Ty Tuyển Dụng - Mọi quyền được bảo lưu</p>
                        </div>
                    </div>
                </body>
                </html>
            ";

            await _emailService.SendEmailAsync(taiKhoan.Email, subject, body);
        }
       
        // Phương thức này chỉ dùng để kiểm tra xem có gửi email được hay không
        [HttpGet]
        public async Task<IActionResult> TestEmail()
        {
            try
            {
                await _emailService.SendEmailAsync("vhanh2k4@gmail.com", 
                    "Kiểm tra gửi email", 
                    "<h1>Đây là email kiểm tra</h1><p>Hệ thống gửi email hoạt động bình thường.</p>");
                return Content("Đã gửi email kiểm tra thành công!");
            }
            catch (Exception ex)
            {
                return Content($"Lỗi gửi email: {ex.Message}");
            }
        }

        // Thông tin tài khoản đang đăng nhập
        [HttpGet]   
        public async Task<IActionResult> ThongTinTK()
        {
            // Lấy tên tài khoản từ người dùng đang đăng nhập
            var tenTaiKhoan = HttpContext.Session.GetString("TenTaiKhoan");
            
            // Kiểm tra xem người dùng đã đăng nhập chưa
            if (string.IsNullOrEmpty(tenTaiKhoan))
            {
                return RedirectToAction("Login");
            }

            // Lấy thông tin tài khoản từ repository
            var taiKhoan = await _taiKhoanRepo.GetByTenTaiKhoanAsync(tenTaiKhoan);
            
            if (taiKhoan == null)
            {
                return NotFound();
            }

            // Trả về view với thông tin tài khoản
            return View(taiKhoan);
        }
        
        [HttpPost]
        public async Task<IActionResult> CapNhatThongTinTK(TaiKhoan model)
        {
            if (!ModelState.IsValid)
            {
                return View("ThongTinTK", model);
            }

            // Lấy thông tin tài khoản hiện tại từ database
            var taiKhoan = await _taiKhoanRepo.GetByTenTaiKhoanAsync(model.TenTaiKhoan);
            
            if (taiKhoan == null)
            {
                return NotFound();
            }

            // Cập nhật thông tin (chỉ những trường cho phép cập nhật)
            taiKhoan.HoTen = model.HoTen;
            taiKhoan.SoDienThoai = model.SoDienThoai;
            taiKhoan.DiaChi = model.DiaChi;
            taiKhoan.NgayCapNhat = DateTime.Now;
            
            // Lưu thay đổi
            await _taiKhoanRepo.UpdateAsync(taiKhoan);
            
            // Hiển thị thông báo thành công
            HttpContext.Session.SetString("SuccessMessage", "Cập nhật thông tin tài khoản thành công!");
            
            // Cập nhật lại session nếu cần
            HttpContext.Session.SetString("HoTen", taiKhoan.HoTen ?? "");
            
            return RedirectToAction("ThongTinTK");
        }

        [HttpPost]
        public async Task<IActionResult> DoiMatKhau([FromBody] DoiMatKhauViewModel model)
        {
            // Kiểm tra model
            if (!ModelState.IsValid)
            {
                var errors = ModelState
                    .Where(x => x.Value.Errors.Count > 0)
                    .ToDictionary(
                        x => x.Key,
                        x => x.Value.Errors.First().ErrorMessage
                    );

                return Json(new { success = false, errors });
            }

            // Lấy tên tài khoản từ người dùng đã đăng nhập
            var tenTaiKhoan = HttpContext.Session.GetString("TenTaiKhoan");
            if (string.IsNullOrEmpty(tenTaiKhoan))
            {
                return Json(new { success = false, message = "Bạn chưa đăng nhập" });
            }

            // Lấy thông tin tài khoản từ repository
            var taiKhoan = await _taiKhoanRepo.GetByTenTaiKhoanAsync(tenTaiKhoan);
            if (taiKhoan == null)
            {
                return Json(new { success = false, message = "Không tìm thấy thông tin tài khoản" });
            }

            // Kiểm tra mật khẩu cũ
            bool passwordValid = BCrypt.Net.BCrypt.Verify(model.MatKhauCu, taiKhoan.MatKhau);
            if (!passwordValid)
            {
                return Json(new { 
                    success = false, 
                    errors = new { matKhauCu = "Mật khẩu hiện tại không chính xác" } 
                });
            }

            // Mã hóa mật khẩu mới
            string newPasswordHash = BCrypt.Net.BCrypt.HashPassword(model.MatKhauMoi);
            
            // Cập nhật mật khẩu mới
            taiKhoan.MatKhau = newPasswordHash;
            taiKhoan.NgayCapNhat = DateTime.Now;
            
            // Lưu thay đổi
            await _taiKhoanRepo.UpdateAsync(taiKhoan);

            return Json(new { success = true, message = "Đổi mật khẩu thành công" });
        }

        

    }
}
