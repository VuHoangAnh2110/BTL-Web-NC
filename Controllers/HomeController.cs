using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BTL_Web_NC.Models;
using BTL_Web_NC.Repositories;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Text.Json;
using BTL_Web_NC.ViewModels;

namespace BTL_Web_NC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ITaiKhoanRepository _taiKhoanRepo;
    private readonly ICongTyRepository _congTyRepo;
    private readonly ICongViecRepository _congViecRepo;
    private readonly IBannerRepository _bannerRepository;

    public HomeController(ILogger<HomeController> logger, ITaiKhoanRepository TaiKhoanRepo, 
                        ICongTyRepository CongTyRepo, ICongViecRepository CongViecRepo, 
                        IBannerRepository BannerRepository)
    {
        _logger = logger;
        _taiKhoanRepo = TaiKhoanRepo;
        _congTyRepo = CongTyRepo;
        _congViecRepo = CongViecRepo;
        _bannerRepository = BannerRepository;
    }

    public async Task<IActionResult> Index()
    {
        var danhSachCongViec = await _congViecRepo.GetDsCongViecAsync();
        var dsBanner = await _bannerRepository.GetAllBannersAsync();
        var danhSachCongTy = await _congTyRepo.GetCongTyMoiNhatAsync(6);
        ViewBag.DanhSachCongViec = danhSachCongViec ?? new List<CongViec>();
        ViewBag.Banners = dsBanner ?? new List<Banner>();
        ViewBag.DanhSachCongTy = danhSachCongTy ?? new List<CongTy>();

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
        var TaiKhoan = await _taiKhoanRepo.GetByEmailAsync(email);

        if (TaiKhoan == null)
        {
            return RedirectToAction("Login", "Account");
        }
        //Kiểm tra người dùng đã có cty hay chưa
        var CongTy = await _congTyRepo.GetByUserIdAsync(TaiKhoan.TenTaiKhoan);

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

    public async Task<IActionResult> DanhSachCongViec(string keyword = "", string location = "", int page = 1)
    {
        // Thiết lập kích thước trang
        int pageSize = 10;
        
        // Lấy danh sách công việc kèm phân trang và bộ lọc
        var result = await _congViecRepo.LocDsCongViecAsync(keyword, page, pageSize);
        
        // Truyền dữ liệu tìm kiếm và bộ lọc vào ViewBag để giữ lại khi chuyển trang
        ViewBag.Keyword = keyword;
        ViewBag.CurrentPage = page;
        ViewBag.TotalPages = (int)Math.Ceiling(result.TotalCount / (double)pageSize);
        
        return View(result.Items);
    }

    public async Task<IActionResult> DanhSachCongTy(string keyword = "", int page = 1)
    {
        // Thiết lập kích thước trang
        int pageSize = 12;
        
        // Lấy danh sách công ty kèm phân trang và bộ lọc
        var result = await _congTyRepo.LocDsCongTyAsync(keyword, page, pageSize);
        
        // Truyền dữ liệu tìm kiếm và bộ lọc vào ViewBag để giữ lại khi chuyển trang
        ViewBag.Keyword = keyword;
        ViewBag.CurrentPage = page;
        ViewBag.TotalPages = (int)Math.Ceiling(result.TotalCount / (double)pageSize);
        
        return View(result.Items);
    }

    [HttpGet]
    public async Task<IActionResult> LichSuTruyCap()
    {
        // Lấy dữ liệu từ session và cookie
        var sessionAccess = LayTruyCapTuSession();
        var cookieAccess = LayTruyCapTuCookie();

        // Tạo ViewModel để hiển thị lịch sử truy cập
        var viewModel = new LichSuTruyCapViewModel 
        {
            SessionAccess = sessionAccess,
            CookieAccess = cookieAccess
        };

        // Nếu có mã công việc, lấy thông tin chi tiết công việc
        if (sessionAccess != null && !string.IsNullOrEmpty(sessionAccess.MaCongViec))
        {
            viewModel.CongViecSession = await _congViecRepo.GetCongViecByIdAsync(sessionAccess.MaCongViec);
        }
        
        if (cookieAccess != null && !string.IsNullOrEmpty(cookieAccess.MaCongViec))
        {
            viewModel.CongViecCookie = await _congViecRepo.GetCongViecByIdAsync(cookieAccess.MaCongViec);
        }

        // Lấy danh sách công việc đã xem từ session
        var dsXemSession = HttpContext.Session.GetString("LuotXem") ?? "";
        if (!string.IsNullOrEmpty(dsXemSession))
        {
            var maCongViecs = dsXemSession.Split(',').Distinct().ToArray();
            viewModel.DanhSachDaXemSession = await _congViecRepo.GetDSCongViecbyDSIdAsync(maCongViecs);
        }

        // Lấy danh sách công việc đã xem từ cookie
        var dsXemCookie = Request.Cookies["LuotXem"] ?? "";
        if (!string.IsNullOrEmpty(dsXemCookie))
        {
            var maCongViecs = dsXemCookie.Split(',').Distinct().ToArray();
            viewModel.DanhSachDaXemCookie = await _congViecRepo.GetDSCongViecbyDSIdAsync(maCongViecs);
        }

        // Thêm tất cả cookie vào ViewModel
        var allCookies = Request.Cookies.ToDictionary(c => c.Key, c => c.Value);
        viewModel.AllCookies = allCookies;

        return View(viewModel);
    }

    private TruyCapInfo LayTruyCapTuSession()
    {
        var lastAccessJson = HttpContext.Session.GetString("truyCapCuoi");
        if (string.IsNullOrEmpty(lastAccessJson))
        {
            return null;
        }
        
        try
        {
            // Đảm bảo deserialize đúng định dạng của JobController
            return JsonSerializer.Deserialize<TruyCapInfo>(lastAccessJson);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Lỗi khi đọc thông tin truy cập từ session: {ex.Message}");
            return null;
        }
    }

    private TruyCapInfo LayTruyCapTuCookie()
    {
        var lastAccessJson = Request.Cookies["truyCapCuoi"];
        if (string.IsNullOrEmpty(lastAccessJson))
        {
            return null;
        }
        
        try
        {
            // Đảm bảo deserialize đúng định dạng của JobController
            return JsonSerializer.Deserialize<TruyCapInfo>(lastAccessJson);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Lỗi khi đọc thông tin truy cập từ cookie: {ex.Message}");
            return null;
        }
    }



}
