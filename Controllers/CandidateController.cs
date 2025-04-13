using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using BTL_Web_NC.Data;
using BTL_Web_NC.Models;
using BTL_Web_NC.Repositories;
using BTL_Web_NC.Helpers;

namespace BTL_Web_NC.Controllers
{
    public class CandidateController : Controller
    {
        private readonly IHoSoUngVienRepository _hoSoUngVienRepo;
        private readonly ICongTyRepository _congTyRepo;
        private readonly ITaiKhoanRepository _taiKhoanRepo;

        public CandidateController(IHoSoUngVienRepository HoSoUngVienRepo, ICongTyRepository CongTyRepo, ITaiKhoanRepository TaiKhoanRepo)
        {
            _hoSoUngVienRepo = HoSoUngVienRepo;
            _congTyRepo = CongTyRepo;
            _taiKhoanRepo = TaiKhoanRepo;
        }

        public IActionResult Create(){
            return View("Create");
        }

        [HttpPost]
        public async Task<IActionResult> Create(HoSoUngVien HoSoUngVien, IFormFile? cvFile)
        {
            var userId = HttpContext.Session.GetString("TenTaiKhoan");
            if (userId == null)
            {
                return RedirectToAction("Login", "Account");
            }

            // Kiểm tra xem người này đã có hồ sơ chưa
            var existingHoSoUngVien = await _hoSoUngVienRepo.GetByUserIdAsync(userId);
            if (existingHoSoUngVien != null)
            {
                return RedirectToAction("CandidateProfile", new { id = existingHoSoUngVien.MaHoSo });
            }

            if (cvFile != null && cvFile.Length > 0)
            {
                // Đảm bảo thư mục uploads tồn tại
                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads");
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                // Lưu file với tên duy nhất
                var fileName = $"{Guid.NewGuid()}_{cvFile.FileName}";
                var filePath = Path.Combine(uploadsFolder, fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await cvFile.CopyToAsync(stream);
                }

                // Lưu tên file vào database
                HoSoUngVien.CV = fileName;
            }

            HoSoUngVien.MaHoSo = IdGenerator.GenerateHoSoId();
            HoSoUngVien.TenTaiKhoan = userId;
            await _hoSoUngVienRepo.AddHoSoUngVienAsync(HoSoUngVien);

            return RedirectToAction("CandidateProfile", new { id = HoSoUngVien.MaHoSo });
        }


        public async Task<IActionResult> CandidateProfile()
        {
            var userId = HttpContext.Session.GetString("TenTaiKhoan");

            if (userId == null)
            {
                return RedirectToAction("Login", "Account");
            }

            // Kiểm tra xem hồ sơ ứng viên đã tồn tại chưa
            var existingHoSoUngVien = await _hoSoUngVienRepo.GetByUserIdAsync(userId);
            
            if (existingHoSoUngVien == null)
            {
                return RedirectToAction("Create");
            }
            return View("CandidateProfile", existingHoSoUngVien);
        }


        

    }
}
