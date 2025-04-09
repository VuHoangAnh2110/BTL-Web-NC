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
                HttpContext.Session.SetString("WarningMessage", "Đăng nhập để tiếp tục!");
                return RedirectToAction("Login", "Account");
            }

            // Lấy thông tin người dùng từ email
            var nguoiDung = await _taiKhoanRepo.GetByEmailAsync(email);
            if (nguoiDung == null)
            {
                HttpContext.Session.SetString("WarningMessage", "Đăng nhập để tiếp tục!");
                return RedirectToAction("Login", "Account");
            }

            // Lấy thông tin nhà tuyển dụng từ UserId
            var nhaTuyenDung = await _congTyRepo.GetByUserIdAsync(nguoiDung.TenTaiKhoan);
            if (nhaTuyenDung == null)
            {
                HttpContext.Session.SetString("InfoMessage", "Bạn chưa đăng ký công ty!");
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
        public async Task<IActionResult> EmployerRegister(CongTy nhaTuyenDung, IFormFile? LogoFile, bool agree)
        {
            // Kiểm tra người dùng đã đồng ý với điều khoản chưa
            if (!agree)
            {
                ModelState.AddModelError("", "Bạn phải đồng ý với điều khoản sử dụng");
            }
            // Kiểm tra các trường bắt buộc
            if (string.IsNullOrWhiteSpace(nhaTuyenDung.TenCongTy))
            {
                ModelState.AddModelError("TenCongTy", "Tên công ty không được để trống");
            }
            if (string.IsNullOrWhiteSpace(nhaTuyenDung.DiaChi))
            {
                ModelState.AddModelError("DiaChi", "Địa chỉ công ty không được để trống");
            }
            if (string.IsNullOrWhiteSpace(nhaTuyenDung.MoTa))
            {
                ModelState.AddModelError("MoTa", "Mô tả công ty không được để trống");
            }
            if (!ModelState.IsValid)
            {
                HttpContext.Session.SetString("WarningMessage", "Đăng ký không thành công!");
                return View("EmployerRegister", nhaTuyenDung);
            }

            var nguoiDungId = HttpContext.Session.GetString("TenTaiKhoan");
            if (nguoiDungId == null)
            {
                HttpContext.Session.SetString("WarningMessage", "Vui lòng đăng ký hoặc đăng nhập vào tài khoản.");
                return RedirectToAction("Login", "Account");
            }

            // Kiểm tra xem người dùng đã có công ty chưa
            var existingCongTy = await _congTyRepo.GetByUserIdAsync(nguoiDungId);
            if (existingCongTy != null)
            {
                HttpContext.Session.SetString("InfoMessage", "Tài khoản đã đăng ký công ty!");;
                return RedirectToAction("EmployerProfile");
            }

            // Tạo mã công ty tự động bằng IdGenerator
            nhaTuyenDung.MaCongTy = IdGenerator.GenerateCongTyId();
            nhaTuyenDung.TenTaiKhoan = nguoiDungId;
            var tenCT = nhaTuyenDung.TenCongTy;

            // Kiểm tra file logo trước khi lưu
            if (LogoFile != null && LogoFile.Length > 0)
            {
                // Kiểm tra kích thước file
                if (LogoFile.Length > 5 * 1024 * 1024) // 5MB limit
                {
                    ModelState.AddModelError("LogoFile", "Kích thước file không được vượt quá 5MB");
                    HttpContext.Session.SetString("WarningMessage", "File vượt quá 5MB.");

                    return View("EmployerRegister", nhaTuyenDung);
                }

                // Kiểm tra loại file
                var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
                var extension = Path.GetExtension(LogoFile.FileName).ToLowerInvariant();
                if (!allowedExtensions.Contains(extension))
                {
                    ModelState.AddModelError("LogoFile", "Chỉ chấp nhận file hình ảnh (jpg, jpeg, png, gif)");
                    HttpContext.Session.SetString("WarningMessage", "File không hợp lệ.");

                    return View("EmployerRegister", nhaTuyenDung);
                }

                var logoFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", "logoCongTy");
                if (!Directory.Exists(logoFolder))
                {
                    Directory.CreateDirectory(logoFolder);
                }

                var uniqueFileName = $"{tenCT}_{DateTime.Now:yyyyMMddHHmmss}_{Path.GetFileName(LogoFile.FileName)}";
                var filePath = Path.Combine(logoFolder, uniqueFileName);

                try
                {
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await LogoFile.CopyToAsync(stream);
                    }

                    // Kiểm tra xem file đã tồn tại chưa
                    if (System.IO.File.Exists(filePath))
                    {
                        Console.WriteLine($"Logo đã được tải lên: {filePath}");
                        nhaTuyenDung.Logo = $"/img/logoCongTy/{uniqueFileName}";
                    }
                    else
                    {
                        ModelState.AddModelError("LogoFile", "Không thể tải lên logo. Vui lòng thử lại.");
                        HttpContext.Session.SetString("WarningMessage", "Không thể tải lên logo. Vui lòng thử lại.");
                        return View("EmployerRegister", nhaTuyenDung);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi khi tải lên file: {ex.Message}");
                    ModelState.AddModelError("LogoFile", "Có lỗi xảy ra khi tải lên logo. Vui lòng thử lại.");
                    HttpContext.Session.SetString("WarningMessage", "Có lỗi xảy ra khi tải lên logo. Vui lòng thử lại.");

                    return View("EmployerRegister", nhaTuyenDung);
                }
            }
            else
            {
                // Sử dụng logo mặc định
                nhaTuyenDung.Logo = "/img/logo-congty-default.jpg";
            }

            try
            {
                await _congTyRepo.AddCongTyAsync(nhaTuyenDung);
                HttpContext.Session.SetString("SuccessMessage", "Đăng ký công ty thành công!");

                return RedirectToAction("EmployerProfile", "Employer");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi lưu thông tin công ty: {ex.Message}");
                ModelState.AddModelError("", "Có lỗi xảy ra khi đăng ký công ty. Vui lòng thử lại.");
                HttpContext.Session.SetString("WarningMessage", "Đăng ký không thành công! Vui lòng thử lại.");

                return View("EmployerRegister", nhaTuyenDung);
            }
        }

        //Edit
        public async Task<IActionResult> Edit(string id)
        {
            var nhaTuyenDung = await _congTyRepo.LayCongTyTheoMaCTAsync(id);
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
                // Lấy thông tin hiện tại của công ty từ database để giữ nguyên logo
                var existingCompany = await _congTyRepo.LayCongTyTheoMaCTAsync(nhaTuyenDung.MaCongTy);
                if (existingCompany != null)
                {
                    // Giữ lại logo hiện tại
                    nhaTuyenDung.Logo = existingCompany.Logo;
                }
                HttpContext.Session.SetString("WarningMessage", "Cập nhật không thành công. Vui lòng thử lại.");
                return View("Edit", nhaTuyenDung);
            }

            var existingNhaTuyenDung = await _congTyRepo.GetByUserIdAsync(nhaTuyenDung.TenTaiKhoan);
            if (existingNhaTuyenDung == null)
            {
                return NotFound();
            }

            // Kiểm tra file logo trước khi lưu
            if (LogoFile != null && LogoFile.Length > 0)
            {
                // Kiểm tra kích thước file
                if (LogoFile.Length > 5 * 1024 * 1024) // 5MB limit
                {
                    ModelState.AddModelError("LogoFile", "Kích thước file không được vượt quá 5MB");
                    HttpContext.Session.SetString("WarningMessage", "File vượt quá 5MB.");
                    return View("Edit", nhaTuyenDung);
                }

                // Kiểm tra loại file
                var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
                var extension = Path.GetExtension(LogoFile.FileName).ToLowerInvariant();
                if (!allowedExtensions.Contains(extension))
                {
                    ModelState.AddModelError("LogoFile", "Chỉ chấp nhận file hình ảnh (jpg, jpeg, png, gif)");
                    HttpContext.Session.SetString("WarningMessage", "File không hợp lệ.");
                    return View("Edit", nhaTuyenDung);
                }

                var logoFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", "logoCongTy");
                if (!Directory.Exists(logoFolder))
                {
                    Directory.CreateDirectory(logoFolder);
                }

                var uniqueFileName = $"{nhaTuyenDung.TenCongTy}_{DateTime.Now:yyyyMMddHHmmss}_{Path.GetFileName(LogoFile.FileName)}";
                var filePath = Path.Combine(logoFolder, uniqueFileName);

                try
                {
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await LogoFile.CopyToAsync(stream);
                    }

                    // Kiểm tra xem file đã tồn tại chưa
                    if (System.IO.File.Exists(filePath))
                    {
                        Console.WriteLine($"Logo đã được tải lên: {filePath}");
                        existingNhaTuyenDung.Logo = $"/img/logoCongTy/{uniqueFileName}";
                    }
                    else
                    {
                        ModelState.AddModelError("LogoFile", "Không thể tải lên logo. Vui lòng thử lại.");
                        HttpContext.Session.SetString("WarningMessage", "Không thể tải lên logo. Vui lòng thử lại.");
                        return View("Edit", nhaTuyenDung);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi khi tải lên file: {ex.Message}");
                    ModelState.AddModelError("LogoFile", "Có lỗi xảy ra khi tải lên logo. Vui lòng thử lại.");
                    HttpContext.Session.SetString("WarningMessage", "Có lỗi xảy ra khi tải lên logo. Vui lòng thử lại.");
                    return View("Edit", nhaTuyenDung);
                }
            }

            existingNhaTuyenDung.TenCongTy = nhaTuyenDung.TenCongTy;
            existingNhaTuyenDung.DiaChi = nhaTuyenDung.DiaChi;
            existingNhaTuyenDung.SoDienThoai = nhaTuyenDung.SoDienThoai;
            existingNhaTuyenDung.MoTa = nhaTuyenDung.MoTa;
            existingNhaTuyenDung.Website = nhaTuyenDung.Website;

            await _congTyRepo.UpdateCongTyAsync(existingNhaTuyenDung);
            HttpContext.Session.SetString("SuccessMessage", "Chỉnh sửa thông tin công ty thành công.");
            return RedirectToAction("EmployerProfile", "Employer");
        }

        



    }
}
