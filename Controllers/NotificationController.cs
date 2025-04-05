using Microsoft.AspNetCore.Mvc;
using BTL_Web_NC.Repositories;
using BTL_Web_NC.Models;
using AspNetCoreGeneratedDocument;

namespace BTL_Web_NC.Controllers
{
    public class NotificationController : Controller
    {
        private readonly IThongBaoRepository _thongBaoRepo;
        private readonly ITaiKhoanRepository _taiKhoanRepo;
        private readonly ICongTyRepository _congTyRepo;


        public NotificationController(IThongBaoRepository ThongBaoRepo,
                                        ITaiKhoanRepository TaiKhoanRepo,
                                        ICongTyRepository CongTyrepo)
        {
            _thongBaoRepo = ThongBaoRepo;
            _taiKhoanRepo = TaiKhoanRepo;
            _congTyRepo = CongTyrepo; 
        }

        //Lấy số lượng thông báo chưa đọc
        // public async Task<IActionResult> GetNotificationCount()
        // {
        //     var email = HttpContext.Session.GetString("Email");
        //     // Tìm người dùng theo email
        //     var TaiKhoan = await _taiKhoanRepo.GetByEmailAsync(email);
        //     if (TaiKhoan == null)
        //     {
        //         return Json(new { count = 0 }); 
        //     }

            
        //     // Lấy id công ty nếu người dùng là nhà tuyển dụng
        //     var CongTy = await _congTyRepo.GetByUserIdAsync(TaiKhoan.Id);
        //     if (CongTy == null)
        //     {
        //         return Json(new { count = 0 }); // Không phải nhà tuyển dụng
        //     }
           
        //     int idCongTy = CongTy.Id;
        //     var thongBaos = await _thongBaoRepo.GetAllThongBaoByIdCongTy(idCongTy);


        //     return Json(new { count = thongBaos.Count() });
        // }

        // [HttpGet]
        // public async Task<IActionResult> GetNotifications()
        // {
        //     // 1. Lấy email từ Session
        //     string email = HttpContext.Session.GetString("Email");

        //     if (string.IsNullOrEmpty(email))
        //     {
        //         return Json(new { success = false, message = "Người dùng chưa đăng nhập" });
        //     }

        //     // 2. Tìm người dùng từ email
        //     var TaiKhoan = await _taiKhoanRepo.GetByEmailAsync(email);
        //     if (TaiKhoan == null)
        //     {
        //         return Json(new { success = false, message = "Không tìm thấy thông tin người dùng" });
        //     }

        //     // 3. Lấy ID công ty từ người dùng (nếu là nhà tuyển dụng)
        //     var CongTy = await _congTyRepo.GetByUserIdAsync(TaiKhoan.Id);
        //     if (CongTy == null)
        //     {
        //         return Json(new { success = false, message = "Không tìm thấy thông tin công ty" });
        //     }

        //     int idCongTy = CongTy.Id;

        //     // 4. Lấy danh sách thông báo
        //     var notifications = await _thongBaoRepo.GetAllThongBaoByIdCongTy(idCongTy);
        //     var result = notifications.Select(tb => new { id = tb.Id, title = tb.NoiDung });

        //     return Json(result);
        // }
        

         // Lấy số lượng thông báo chưa đọc
        public async Task<IActionResult> GetNotificationCount()
        {
            var email = HttpContext.Session.GetString("Email");
            if (string.IsNullOrEmpty(email))
            {
                return Json(new { count = 0 });
            }

            var TaiKhoan = await _taiKhoanRepo.GetByEmailAsync(email);
            if (TaiKhoan == null)
            {
                return Json(new { count = 0 });
            }

            var CongTy = await _congTyRepo.GetByUserIdAsync(TaiKhoan.TenTaiKhoan);
            if (CongTy == null)
            {
                return Json(new { count = 0 });
            }

            var thongBaos = await _thongBaoRepo.GetUnreadNotificationCount(CongTy.MaCongTy);
            return Json(new { count = thongBaos });
        }

        // Lấy danh sách thông báo
        [HttpGet]
        public async Task<IActionResult> GetNotifications()
        {
            var email = HttpContext.Session.GetString("Email");
            if (string.IsNullOrEmpty(email))
            {
                return Json(new { success = false, message = "Người dùng chưa đăng nhập" });
            }

            var TaiKhoan = await _taiKhoanRepo.GetByEmailAsync(email);
            if (TaiKhoan == null)
            {
                return Json(new { success = false, message = "Không tìm thấy thông tin người dùng" });
            }

            var CongTy = await _congTyRepo.GetByUserIdAsync(TaiKhoan.TenTaiKhoan);
            if (CongTy == null)
            {
                return Json(new { success = false, message = "Không tìm thấy thông tin công ty" });
            }

            var notifications = await _thongBaoRepo.GetAllThongBaoByIdCongTy(CongTy.MaCongTy);
            var result = notifications.Select(tb => new
            {
                id = tb.MaThongBao,
                title = tb.NoiDung,
                daXem = tb.DaXem,
                ngayTao = tb.NgayThongBao.ToString("dd/MM/yyyy HH:mm")
            });

            return Json(result);
        }

        // Đánh dấu thông báo đã đọc
        [HttpPost]
        public async Task<IActionResult> MarkAsRead(string id)
        {
            var thongBao = await _thongBaoRepo.GetThongBaoByIdAsync(id);
            if (thongBao == null)
            {
                return Json(new { success = false, message = "Thông báo không tồn tại" });
            }

            thongBao.DaXem = true;
            await _thongBaoRepo.UpdateThongBaoAsync(thongBao);
            return Json(new { success = true, message = "Thông báo đã được đánh dấu là đã đọc" });
        }

        //Chi tiết
        public async Task<IActionResult> Detail(string id)
        {
            var thongBao = await _thongBaoRepo.GetThongBaoByIdAsync(id);
            if (thongBao == null)
            {
                return NotFound("Thông báo không tồn tại");
            }

            return View("Detail", thongBao);
        }
       



    }
}