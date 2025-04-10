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
        private readonly IUngTuyenRepository _ungTuyenRepo;
        private readonly IThongBaoRepository _thongBaoRepo;

        public JobController(ICongViecRepository congViecRepo, ICongTyRepository congTyRepo, 
                            ITaiKhoanRepository taiKhoanRepo, IUngTuyenRepository ungTuyenRepo,
                            IThongBaoRepository thongBaoRepo)
        {
            _congViecRepo = congViecRepo;
            _congTyRepo = congTyRepo;
            _taiKhoanRepo = taiKhoanRepo;
            _ungTuyenRepo = ungTuyenRepo;
            _thongBaoRepo = thongBaoRepo;
        }

        public IActionResult CreateJob()
        {
            return View("Create", new CreateCongViecViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> CreateJob(CreateCongViecViewModel model)
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

        public async Task<IActionResult> DuyetHoSo(string idCongViec)
        {
            // Kiểm tra id
            if (string.IsNullOrEmpty(idCongViec))
            {
                return NotFound();
            }

            // Kiểm tra đăng nhập
            var tenTaiKhoan = HttpContext.Session.GetString("TenTaiKhoan");
            if (string.IsNullOrEmpty(tenTaiKhoan))
            {
                HttpContext.Session.SetString("WarningMessage", "Vui lòng đăng nhập để tiếp tục!");
                return RedirectToAction("Login", "Account");
            }

            // Lấy thông tin công việc
            var congViec = await _congViecRepo.GetCongViecByIdAsync(idCongViec);
            if (congViec == null)
            {
                return NotFound();
            }

            // Kiểm tra quyền truy cập (người dùng phải là chủ của công ty sở hữu công việc này)
            var congTy = await _congTyRepo.GetByUserIdAsync(tenTaiKhoan);
            if (congTy == null || congTy.MaCongTy != congViec.MaCongTy)
            {
                HttpContext.Session.SetString("WarningMessage", "Bạn không có quyền truy cập trang này!");
                return RedirectToAction("EmployerProfile", "Employer");
            }

            // Lấy danh sách ứng tuyển
            var danhSachUngTuyen = await _ungTuyenRepo.GetDSUngTuyenByCongViecAsync(idCongViec);

            // Truyền dữ liệu sang view
            ViewBag.DanhSachUngTuyen = danhSachUngTuyen;

            return View(congViec);
        }

        public async Task<IActionResult> CapNhatTrangThaiUngTuyen(string maUngTuyen, string trangThai)
        {
            // Kiểm tra dữ liệu đầu vào
            if (string.IsNullOrEmpty(maUngTuyen) || string.IsNullOrEmpty(trangThai))
            {
                return Json(new { success = false, message = "Dữ liệu không hợp lệ" });
            }

            // Kiểm tra đăng nhập
            var tenTaiKhoan = HttpContext.Session.GetString("TenTaiKhoan");
            if (string.IsNullOrEmpty(tenTaiKhoan))
            {
                HttpContext.Session.SetString("WarningMessage", "Vui lòng đăng nhập để tiếp tục!");
                return Json(new { success = false, message = "Bạn chưa đăng nhập" });
            }

            // Lấy thông tin ứng tuyển
            var ungTuyen = await _ungTuyenRepo.GetUngTuyenByIdAsync(maUngTuyen);
            if (ungTuyen == null)
            {
                return Json(new { success = false, message = "Không tìm thấy thông tin ứng tuyển" });
            }

            // Lấy thông tin công việc
            var congViec = await _congViecRepo.GetCongViecByIdAsync(ungTuyen.MaCongViec);
            if (congViec == null)
            {
                return Json(new { success = false, message = "Không tìm thấy thông tin công việc" });
            }

            // Kiểm tra quyền truy cập
            var congTy = await _congTyRepo.GetByUserIdAsync(tenTaiKhoan);
            if (congTy == null || congTy.MaCongTy != congViec.MaCongTy)
            {
                return Json(new { success = false, message = "Bạn không có quyền thực hiện hành động này" });
            }

            // Cập nhật trạng thái
            ungTuyen.TrangThai = trangThai;
            await _ungTuyenRepo.UpdateUngTuyenAsync(ungTuyen);

            // Tạo thông báo cho ứng viên
            var thongBao = new ThongBao
            {
                MaThongBao = IdGenerator.GenerateThongBaoId(),
                TenTaiKhoan = ungTuyen.TenTaiKhoan,
                TieuDe = $"Trạng thái ứng tuyển đã được cập nhật",
                NoiDung = $"Hồ sơ ứng tuyển của bạn cho vị trí '{congViec.TieuDe}' đã được cập nhật trạng thái thành: {trangThai}",
                LoaiThongBao = "UngTuyen",
                NgayThongBao = DateTime.Now,
                DaXem = false,
                MaCongTy = congViec.MaCongTy,
                MaCongViec = congViec.MaCongViec
            };
            await _thongBaoRepo.AddThongBaoAsync(thongBao);

            return Json(new { success = true, message = "Cập nhật trạng thái thành công" });
        }



    }
}