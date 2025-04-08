using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BTL_Web_NC.Models;
using BTL_Web_NC.Repositories;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace BTL_Web_NC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ITaiKhoanRepository _TaiKhoanRepo;
    private readonly ICongTyRepository _CongTyRepo;
    private readonly ICongViecRepository _congViecRepo;
    private readonly IBannerRepository _bannerRepository;

    public HomeController(ILogger<HomeController> logger, ITaiKhoanRepository TaiKhoanRepo, 
                        ICongTyRepository CongTyRepo, ICongViecRepository CongViecRepo, 
                        IBannerRepository BannerRepository)
    {
        _logger = logger;
        _TaiKhoanRepo = TaiKhoanRepo;
        _CongTyRepo = CongTyRepo;
        _congViecRepo = CongViecRepo;
        _bannerRepository = BannerRepository;
    }

    public async Task<IActionResult> Index()
    {
        var danhSachCongViec = await _congViecRepo.GetDsCongViecAsync();
        var dsBanner = await _bannerRepository.GetAllBannersAsync();
        ViewBag.DanhSachCongViec = danhSachCongViec ?? new List<CongViec>();
        ViewBag.Banners = dsBanner ?? new List<Banner>();

        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    [HttpPost]
    public IActionResult ClearSessionMessages()
    {
        HttpContext.Session.Remove("SuccessMessage");
        HttpContext.Session.Remove("WarningMessage");
        HttpContext.Session.Remove("ErrorMessage");
        HttpContext.Session.Remove("InfoMessage");
        return Ok();
    }

    // Nhà tuyển dụng
    public async Task<IActionResult> RedirectToEmployer()
    {
        var email = HttpContext.Session.GetString("Email");

        if (string.IsNullOrEmpty(email))
        {
            return RedirectToAction("Login", "Account"); // Nếu chưa đăng nhập, chuyển đến trang Login
        }
       
        // Lấy thông tin người dùng từ email
        var TaiKhoan = await _TaiKhoanRepo.GetByEmailAsync(email);

        if (TaiKhoan == null)
        {
            return RedirectToAction("Login", "Account");
        }
        //Kiểm tra người dùng đã có cty hay chưa
        var CongTy = await _CongTyRepo.GetByUserIdAsync(TaiKhoan.TenTaiKhoan);

        if(CongTy == null)
        {
            return RedirectToAction("EmployerRegister", "Employer"); // Nếu chưa có cty, chuyển đến trang Đăng ký Nhà tuyển dụng
        }

        return RedirectToAction("EmployerProfile", "Employer"); // Nếu đã đăng nhập, chuyển đến trang Nhà tuyển dụng
    }

    // Ứng viên
    public IActionResult RedirectToCandidate()
    {
        var email = HttpContext.Session.GetString("Email");

        if (string.IsNullOrEmpty(email))
        {
            return RedirectToAction("Login", "Account"); // Nếu chưa đăng nhập, chuyển đến trang Login
        }

        return RedirectToAction("Index", "Home"); // Nếu đã đăng nhập, chuyển đến trang Ứng viên
    }




}
