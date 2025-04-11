using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BTL_Web_NC.Models;
using BTL_Web_NC.Repositories;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using BTL_Web_NC.Helpers;
using BTL_Web_NC.ViewModels;

namespace BTL_Web_NC.Controllers
{
    public class JobController : Controller{

        private readonly ICongViecRepository _congViecRepo;
        private readonly ICongTyRepository _congTyRepo;
        private readonly ITaiKhoanRepository _taiKhoanRepo;

        public JobController(ICongViecRepository congViecRepo, ICongTyRepository congTyRepo, ITaiKhoanRepository taiKhoanRepo)
        {
            _congViecRepo = congViecRepo;
            _congTyRepo = congTyRepo;
            _taiKhoanRepo = taiKhoanRepo;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View("Create", new CreateCongViecViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCongViecViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", model);
            }

            var email = HttpContext.Session.GetString("Email");
            if (string.IsNullOrEmpty(email))
            {
                return RedirectToAction("Login", "Account");
            }

            // Lấy thông tin người dùng từ email
            var TaiKhoan = await _taiKhoanRepo.GetByEmailAsync(email);
            if (TaiKhoan == null)
            {
                return RedirectToAction("Login", "Account");
            }

            // Lấy thông tin nhà tuyển dụng từ UserId
            var CongTy = await _congTyRepo.GetByUserIdAsync(TaiKhoan.TenTaiKhoan);
            if (CongTy == null)
            {
                TempData["Error"] = "Bạn cần đăng ký thông tin công ty trước khi đăng việc làm.";
                return RedirectToAction("EmployerRegister", "Employer");
            }

            // Tạo mới công việc
            var congViec = new CongViec
            {
                MaCongViec = IdGenerator.GenerateCongViecId(),
                MaCongTy = CongTy.MaCongTy,
                TieuDe = model.TieuDe,
                MoTa = model.MoTa,
                DiaDiem = model.DiaDiem,
                MucLuong = model.MucLuong,
                LoaiHinh = model.LoaiHinh,
                NgayDang = DateTime.Now,
                TrangThai = "Đang tuyển",
            };
            await _congViecRepo.AddCongViecAsync(congViec);

            return RedirectToAction("EmployerProfile", "Employer");
        }
        [HttpGet]
public async Task<IActionResult> Edit(string id)
{
            var congViec = await _congViecRepo.GetCongViecByIdAsync(id);
            if (congViec == null)
    {
        return NotFound();
    }

    var viewModel = new CreateCongViecViewModel
    {
        MaCongViec = congViec.MaCongViec,
        TieuDe = congViec.TieuDe,
        MoTa = congViec.MoTa,
        DiaDiem = congViec.DiaDiem,
        MucLuong = congViec.MucLuong,
        LoaiHinh = congViec.LoaiHinh
    };

    return View(viewModel);
}


        
        //Chi tiết
        public async Task<IActionResult> Detail(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return RedirectToAction("Index", "Home");
            }
            
            var congViec = await _congViecRepo.GetCongViecByIdAsync(id);
            if (congViec == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View("Detail", congViec);
        }


    }
}