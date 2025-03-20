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

    public HomeController(ILogger<HomeController> logger, ITaiKhoanRepository TaiKhoanRepo, ICongTyRepository CongTyRepo)
    {
        _logger = logger;
        _TaiKhoanRepo = TaiKhoanRepo;
        _CongTyRepo = CongTyRepo;
    }

    public IActionResult Index()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
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
