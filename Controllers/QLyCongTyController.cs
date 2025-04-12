using BTL_Web_NC.Data;
using BTL_Web_NC.Helpers;
using BTL_Web_NC.Models;
using BTL_Web_NC.Repositories;
using BTL_Web_NC.Services;
using BTL_Web_NC.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace BTL_Web_NC.Controllers
{
    public class QLyCongTyController : Controller
    {

        private readonly ICongTyRepository _congTyRepository;

        public QLyCongTyController(ICongTyRepository congTyRepository)
        {
            _congTyRepository = congTyRepository;
        }

        public async Task<IActionResult> QuanLyCongTy()
        {
            var danhSachCongTy = await _congTyRepository.GetAllAsync(); // sử dụng từ GenericRepository
            return View(danhSachCongTy);
        }
        [HttpGet]
        public async Task<IActionResult> ThemCongTy()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ThemCongTy(ThemCongTyViewModel congTy)
        {
            if (!ModelState.IsValid)
            return View(congTy);
            if (!string.IsNullOrEmpty(congTy.TenTaiKhoan))
            {
                var daTonTai = await _congTyRepository.GetByUserIdAsync(congTy.TenTaiKhoan);
                if (daTonTai != null)
                {
                    ModelState.AddModelError("TenTaiKhoan", "Tài khoản này đã liên kết với một công ty khác.");
                    return View(congTy);
                }
            }

            var congTyMoi = new CongTy
            {
                MaCongTy = IdGenerator.GenerateCongTyId(),
                TenCongTy = congTy.TenCongTy,
                DiaChi = congTy.DiaChi,
                SoDienThoai = congTy.SoDienThoai,
                Website = congTy.Website,
                TenTaiKhoan = congTy.TenTaiKhoan,
                Logo = congTy.Logo,
                MoTa = congTy.MoTa,
                NgayTao = DateTime.Now
            };
            await _congTyRepository.AddCongTyAsync(congTyMoi);
            await _congTyRepository.SaveChangesAsync(); 

            return RedirectToAction("QuanLyCongTy");
        }
    }
}
