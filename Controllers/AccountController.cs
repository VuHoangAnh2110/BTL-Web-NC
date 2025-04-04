using BTL_Web_NC.Models;
using BTL_Web_NC.Repositories;
using Microsoft.AspNetCore.Mvc;
using BTL_Web_NC.ViewModels;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace BTL_Web_NC.Controllers
{
    public class AccountController : Controller
    {
        private readonly ITaiKhoanRepository _taiKhoanRepo;

        public AccountController(ITaiKhoanRepository TaiKhoanRepo)
        {
            _taiKhoanRepo = TaiKhoanRepo;
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
                var existingPhone = await _taiKhoanRepo.GetBySoDienThoaiAsync(model.SoDienThoai);
                if (existingPhone != null)
                {
                    ModelState.AddModelError(nameof(model.SoDienThoai), "Số điện thoại đã tồn tại!");
                }
                // Nếu có bất kỳ lỗi nào thì trả về view kèm thông báo
                if (!ModelState.IsValid)
                {
                    HttpContext.Session.SetString("WarningMessage", "Đăng ký tài khoản không thành công!");
                    return View(model);
                }

                // Gán dữ liệu
                taiKhoan.NgayTao = DateTime.Now;
                taiKhoan.NgayCapNhat = DateTime.Now;
                taiKhoan.TenTaiKhoan = model.TenTaiKhoan;
                taiKhoan.HoTen = model.HoTen;
                taiKhoan.Email = model.Email;
                taiKhoan.MatKhau = model.MatKhau;
                taiKhoan.SoDienThoai = model.SoDienThoai;
                taiKhoan.VaiTro = model.VaiTro;

                // Gán trạng thái theo vai trò
                if (model.VaiTro == "ung_vien")
                {
                    taiKhoan.TrangThai = 2;
                }
                else if (model.VaiTro == "nha_tuyen_dung")
                {
                    taiKhoan.TrangThai = 1;
                } else {
                    taiKhoan.TrangThai = 1;
                }

                await _taiKhoanRepo.AddTaiKhoanAsync(taiKhoan);
                HttpContext.Session.SetString("SuccessMessage", "Đăng ký tài khoản thành công!");
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
                ModelState.AddModelError(string.Empty, "Không được upload file trong form đăng nhập.");
            }

            if(ModelState.IsValid){
                // Lấy tài khoản theo email hoặc tên tài khoản
                var user = await _taiKhoanRepo.GetByUsernameOrEmailAsync(model.UsernameOrEmail);
                if(user == null || user.MatKhau != model.Password){
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


        //Nhà tuyển dụng
       


    

    }
}
