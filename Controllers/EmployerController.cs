using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BTL_Web_NC.Models;
using BTL_Web_NC.Repositories;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace BTL_Web_NC.Controllers
{
    public class EmployerController : Controller
    {
        private readonly ICongTyRepository _CongTyRepo;
        private readonly ITaiKhoanRepository _TaiKhoanRepo;
        private readonly ICongViecRepository _congViecRepo;
       
        public EmployerController(ICongTyRepository CongTyRepo, ITaiKhoanRepository TaiKhoanRepo, ICongViecRepository congViecRepo)
        {
            _CongTyRepo = CongTyRepo;
            _TaiKhoanRepo = TaiKhoanRepo;
            _congViecRepo = congViecRepo;
    
        }

        public IActionResult EmployerRegister()
        {
            return View("EmployerRegister");
        }

        public async Task<IActionResult> EmployerProfile()
        {
            var email = HttpContext.Session.GetString("Email");
            if (string.IsNullOrEmpty(email))
            {
                return RedirectToAction("Login", "Account");
            }

            // Lấy thông tin người dùng từ email
            var TaiKhoan = await _TaiKhoanRepo.GetByEmailAsync(email);
            if (TaiKhoan == null)
            {
                return RedirectToAction("Login", "Account");
            }

            // Lấy thông tin nhà tuyển dụng từ UserId
            var CongTy = await _CongTyRepo.GetByUserIdAsync(TaiKhoan.TenTaiKhoan);
            if (CongTy == null)
            {
                return RedirectToAction("EmployerRegister", "Employer");
            }

           
            return View("EmployerProfile", CongTy);
        }

        // Đăng ký Nhà Tuyển Dụng
        [HttpPost]
        public async Task<IActionResult> EmployerRegister(CongTy CongTy)
        {
            string? TaiKhoanId = HttpContext.Session.GetString("Id");
            if (TaiKhoanId == null)
            {
                return RedirectToAction("Login", "Account");
            }

            CongTy.TenTaiKhoan = TaiKhoanId;
            await _CongTyRepo.AddCongTyAsync(CongTy);

            return RedirectToAction("EmployerProfile", "Employer"); // Chuyển hướng sau khi đăng ký
        }

        


    }
}
