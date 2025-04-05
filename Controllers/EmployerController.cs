using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BTL_Web_NC.Models;
using BTL_Web_NC.Repositories;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using BTL_Web_NC.Helpers;

namespace BTL_Web_NC.Controllers
{
    public class EmployerController : Controller
    {
        private readonly ICongTyRepository _congTyRepo;
        private readonly ITaiKhoanRepository _taiKhoanRepo;
        private readonly ICongViecRepository _congViecRepo;
       
        public EmployerController(ICongTyRepository CongTyRepo, ITaiKhoanRepository TaiKhoanRepo, ICongViecRepository CongViecRepo)
        {
            _congTyRepo = CongTyRepo;
            _taiKhoanRepo = TaiKhoanRepo;
            _congViecRepo = CongViecRepo;
    
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
            var nguoiDung = await _taiKhoanRepo.GetByEmailAsync(email);
            if (nguoiDung == null)
            {
                return RedirectToAction("Login", "Account");
            }

            // Lấy thông tin nhà tuyển dụng từ UserId
            var nhaTuyenDung = await _congTyRepo.GetByUserIdAsync(nguoiDung.TenTaiKhoan);
            if (nhaTuyenDung == null)
            {
                return RedirectToAction("EmployerRegister", "Employer");
            }
           
            //Lấy danh sách công việc của nhà tuyển dụng
            var danhSachCongViec = await _congViecRepo.GetDsCongViecByCongTyIdAsync(nhaTuyenDung.MaCongTy);
            ViewBag.nhaTuyenDung = nhaTuyenDung;
            ViewBag.DanhSachCongViec = danhSachCongViec;
           
            return View("EmployerProfile", nhaTuyenDung);
        }
        
        //Đăng ký
        [HttpPost]
        public async Task<IActionResult> EmployerRegister(CongTy nhaTuyenDung, IFormFile? LogoFile)
        {
            if (!ModelState.IsValid)
            {
                return View("EmployerRegister", nhaTuyenDung);
            }

            var nguoiDungId = HttpContext.Session.GetString("TenTaiKhoan");
            if (nguoiDungId == null)
            {
                return RedirectToAction("Login", "Account");
            }

            // Kiểm tra xem người dùng đã có công ty chưa
            var existingCongTy = await _congTyRepo.GetByUserIdAsync(nguoiDungId);
            if (existingCongTy != null)
            {
                TempData["Error"] = "Bạn đã đăng ký công ty rồi!";
                return RedirectToAction("EmployerProfile");
            }

            // Tạo mã công ty tự động bằng IdGenerator
            nhaTuyenDung.MaCongTy = IdGenerator.GenerateCongTyId();
            nhaTuyenDung.TenTaiKhoan = nguoiDungId;
            var tenCT = nhaTuyenDung.TenCongTy;

            // Kiểm tra file logo trước khi lưu
            if (LogoFile != null && LogoFile.Length > 0)
            {
                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                var uniqueFileName = $"{tenCT}_{Path.GetFileName(LogoFile.FileName)}";
                var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await LogoFile.CopyToAsync(stream);
                }

                // Kiểm tra xem file đã tồn tại chưa
                if (System.IO.File.Exists(filePath))
                {
                    Console.WriteLine($"✅ Logo đã được tải lên: {filePath}");
                    nhaTuyenDung.Logo = $"/uploads/{uniqueFileName}";
                }
                else
                {
                    Console.WriteLine("❌ Lỗi: File không tồn tại sau khi tải lên!");
                    ModelState.AddModelError("LogoFile", "Không thể tải lên logo. Vui lòng thử lại.");
                    return View("EmployerRegister", nhaTuyenDung);
                }
            }
            else
            {
                Console.WriteLine("⚠️ Không có logo được tải lên.");
            }

            await _congTyRepo.AddCongTyAsync(nhaTuyenDung);
            return RedirectToAction("EmployerProfile", "Employer");
        }

        //Edit
        public async Task<IActionResult> Edit(string id)
        {
            var nhaTuyenDung = await _congTyRepo.GetByUserIdAsync(id);
            if (nhaTuyenDung == null)
            {
                return NotFound();
            }
            return View("Edit", nhaTuyenDung);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CongTy nhaTuyenDung, IFormFile? LogoFile)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit", nhaTuyenDung);
            }

            var existingNhaTuyenDung = await _congTyRepo.GetByUserIdAsync(nhaTuyenDung.TenTaiKhoan);
            if (existingNhaTuyenDung == null)
            {
                return NotFound();
            }

            if (LogoFile != null && LogoFile.Length > 0)
            {
                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                var uniqueFileName = $"{nhaTuyenDung.TenCongTy}_{Path.GetFileName(LogoFile.FileName)}";
                var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await LogoFile.CopyToAsync(stream);
                }

                if (System.IO.File.Exists(filePath))
                {
                    existingNhaTuyenDung.Logo = $"/uploads/{uniqueFileName}";
                }
                else
                {
                    ModelState.AddModelError("LogoFile", "Không thể tải lên logo. Vui lòng thử lại.");
                    return View("Edit", nhaTuyenDung);
                }
            }

            existingNhaTuyenDung.TenCongTy = nhaTuyenDung.TenCongTy;
            existingNhaTuyenDung.DiaChi = nhaTuyenDung.DiaChi;
            existingNhaTuyenDung.MoTa = nhaTuyenDung.MoTa;
            existingNhaTuyenDung.Website = nhaTuyenDung.Website;

            await _congTyRepo.UpdateCongTyAsync(existingNhaTuyenDung);

            return RedirectToAction("EmployerProfile", "Employer");
        }

        



    }
}
