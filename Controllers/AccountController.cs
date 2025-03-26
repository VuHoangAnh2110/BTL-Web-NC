using BTL_Web_NC.Models;
using BTL_Web_NC.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace BTL_Web_NC.Controllers
{
    public class AccountController : Controller
    {
        private readonly ITaiKhoanRepository _TaiKhoanRepo;

        public AccountController(ITaiKhoanRepository TaiKhoanRepo)
        {
            _TaiKhoanRepo = TaiKhoanRepo;
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
                var existingUser = await _TaiKhoanRepo.GetByEmailAsync(model.Email);
                if (existingUser != null)
                {
                    ModelState.AddModelError("Email", "Email đã tồn tại!");
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

                await _TaiKhoanRepo.AddTaiKhoanAsync(taiKhoan);
                HttpContext.Session.SetString("SuccessMessage", "Đăng ký tài khoản thành công!");
                return View();
            } else {
                HttpContext.Session.SetString("WarningMessage", "Đăng ký tài khoản không thành công!");
                return View(model);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Login(string usernameOrEmail, string password)
        {
            if (usernameOrEmail == null || password == null){
                HttpContext.Session.SetString("WarningMessage", "Nhập tài khoản và mật khẩu");
                return View();
            }

            var user = await _TaiKhoanRepo.GetByEmailAsync(usernameOrEmail);
           
            if(ModelState.IsValid){

                if(user == null || user.MatKhau != password){
                    ModelState.AddModelError("mk", "Email hoặc mật khẩu không đúng!");
                    HttpContext.Session.SetString("WarningMessage", "Tài khoản hoặc mật khẩu không chính xác!");
                    return View();
                }

                // Lưu thông tin người dùng vào Session
                HttpContext.Session.SetString("Email", user.Email ?? "");
                HttpContext.Session.SetString("HoTen", user.HoTen ?? "");
                HttpContext.Session.SetString("Id", user.TenTaiKhoan ?? "");


                var currentEmail = HttpContext.Session.GetInt32("Id");
                Console.WriteLine(currentEmail);

                HttpContext.Session.SetString("SuccessMessage", "Đăng nhập thành công!");
                return RedirectToAction("Index", "Home");
            }
            
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear(); // Xóa toàn bộ Session
            return RedirectToAction("Login");
        }

        //Nhà tuyển dụng
       


    

    }
}
