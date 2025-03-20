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
        public async Task<IActionResult> Register(TaiKhoan TaiKhoan)
        {
            if (ModelState.IsValid)
            {
                var existingUser = await _TaiKhoanRepo.GetByEmailAsync(TaiKhoan.Email);
                if (existingUser != null)
                {
                    ModelState.AddModelError("Email", "Email đã tồn tại!");
                    return View(TaiKhoan);
                }

                await _TaiKhoanRepo.AddTaiKhoanAsync(TaiKhoan);
                return RedirectToAction("Login");
            }
            return View(TaiKhoan);
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            var user = await _TaiKhoanRepo.GetByEmailAsync(email);
           
            if(ModelState.IsValid){

                if(user == null || user.MatKhau != password){
                    ModelState.AddModelError("mk", "Email hoặc mật khẩu không đúng!");
                    return View();
                }

                // Lưu thông tin người dùng vào Session
                HttpContext.Session.SetString("Email", user.Email ?? "");
                HttpContext.Session.SetString("HoTen", user.HoTen ?? "");
                HttpContext.Session.SetString("Id", user.TenTaiKhoan ?? "");


                var currentEmail = HttpContext.Session.GetInt32("Id");
                Console.WriteLine(currentEmail);

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
