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
        private readonly IFileUpLoadRepository _fileRepo; // Thêm repository cho File nếu cần

        public JobController(ICongViecRepository congViecRepo, ICongTyRepository congTyRepo, 
                            ITaiKhoanRepository taiKhoanRepo, IUngTuyenRepository ungTuyenRepo,
                            IThongBaoRepository thongBaoRepo, IFileUpLoadRepository fileRepo)
        {
            _congViecRepo = congViecRepo;
            _congTyRepo = congTyRepo;
            _taiKhoanRepo = taiKhoanRepo;
            _ungTuyenRepo = ungTuyenRepo;
            _thongBaoRepo = thongBaoRepo;
            _fileRepo = fileRepo; // Khởi tạo repository cho File nếu cần
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
                HttpContext.Session.SetString("WarningMessage", "Thêm công việc thất bại!");
                return View("Create", model);
            }

            var email = HttpContext.Session.GetString("Email");
            if (string.IsNullOrEmpty(email))
            {
                HttpContext.Session.SetString("WarningMessage", "Vui lòng đăng nhập để tiếp tục!");
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
                HttpContext.Session.SetString("WarningMessage", "Tài khoản chưa đăng ký công ty!");
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
                SoLuongTuyen = model.SoLuongTuyen,
                NgayHetHan = model.NgayHetHan,
                CapBac = model.CapBac,
                NganhNghe = model.NganhNghe,
                QuyenLoi = model.QuyenLoi,
                YeuCau = model.YeuCau
            };
            await _congViecRepo.AddCongViecAsync(congViec);
            HttpContext.Session.SetString("SuccessMessage", "Thêm mới công việc thành công!");
            return RedirectToAction("EmployerProfile", "Employer");
        }
        
        [HttpGet]
        public async Task<IActionResult> EditCongViec(string id)
        {
            if (string.IsNullOrEmpty(id))
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
            var congViec = await _congViecRepo.GetCongViecByIdAsync(id);
            if (congViec == null)
            {
                return NotFound();
            }

            // Kiểm tra quyền truy cập (người dùng phải là chủ của công ty sở hữu công việc này)
            var congTy = await _congTyRepo.GetByUserIdAsync(tenTaiKhoan);
            if (congTy == null || congTy.MaCongTy != congViec.MaCongTy)
            {
                HttpContext.Session.SetString("WarningMessage", "Bạn không có quyền chỉnh sửa công việc này!");
                return RedirectToAction("EmployerProfile", "Employer");
            }

            var viewModel = new EditCongViecViewModel
            {
                MaCongViec = congViec.MaCongViec,
                TieuDe = congViec.TieuDe,
                MoTa = congViec.MoTa,
                DiaDiem = congViec.DiaDiem,
                MucLuong = congViec.MucLuong,
                LoaiHinh = congViec.LoaiHinh,
                SoLuongTuyen = congViec.SoLuongTuyen ?? 1,
                NgayHetHan = congViec.NgayHetHan,
                CapBac = congViec.CapBac,
                NganhNghe = congViec.NganhNghe,
                QuyenLoi = congViec.QuyenLoi,
                YeuCau = congViec.YeuCau,
                TrangThai = congViec.TrangThai
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditCongViec(EditCongViecViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // Kiểm tra đăng nhập
            var tenTaiKhoan = HttpContext.Session.GetString("TenTaiKhoan");
            if (string.IsNullOrEmpty(tenTaiKhoan))
            {
                HttpContext.Session.SetString("WarningMessage", "Vui lòng đăng nhập để tiếp tục!");
                return RedirectToAction("Login", "Account");
            }

            // Lấy thông tin công việc từ database
            var congViec = await _congViecRepo.GetCongViecByIdAsync(model.MaCongViec);
            if (congViec == null)
            {
                return NotFound();
            }

            // Kiểm tra quyền truy cập
            var congTy = await _congTyRepo.GetByUserIdAsync(tenTaiKhoan);
            if (congTy == null || congTy.MaCongTy != congViec.MaCongTy)
            {
                HttpContext.Session.SetString("WarningMessage", "Bạn không có quyền chỉnh sửa công việc này!");
                return RedirectToAction("EmployerProfile", "Employer");
            }

            // Cập nhật thông tin công việc
            congViec.TieuDe = model.TieuDe;
            congViec.MoTa = model.MoTa;
            congViec.DiaDiem = model.DiaDiem;
            congViec.MucLuong = model.MucLuong;
            congViec.LoaiHinh = model.LoaiHinh;
            congViec.SoLuongTuyen = model.SoLuongTuyen;
            congViec.NgayHetHan = model.NgayHetHan;
            congViec.CapBac = model.CapBac;
            congViec.NganhNghe = model.NganhNghe;
            congViec.QuyenLoi = model.QuyenLoi;
            congViec.YeuCau = model.YeuCau;
            congViec.TrangThai = model.TrangThai;

            // Lưu thay đổi vào database
            await _congViecRepo.UpdateCongViecAsync(congViec);

            // Thông báo cập nhật thành công
            HttpContext.Session.SetString("SuccessMessage", "Cập nhật công việc thành công!");
            return RedirectToAction("EmployerProfile", "Employer");
        }

        //Chi tiết công việc (view của công ty đó)
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

        [HttpGet]
        public async Task<IActionResult> XemCV(string tenTaiKhoan, string maCongViec)
        {
            try
            {
                // Kiểm tra đăng nhập
                var currentUser = HttpContext.Session.GetString("TenTaiKhoan");
                if (string.IsNullOrEmpty(currentUser))
                {
                    return Json(new { success = false, message = "Vui lòng đăng nhập để xem CV" });
                }

                // Kiểm tra tham số đầu vào
                if (string.IsNullOrEmpty(tenTaiKhoan) || string.IsNullOrEmpty(maCongViec))
                {
                    return Json(new { success = false, message = "Dữ liệu không hợp lệ" });
                }

                // Lấy thông tin công việc
                var congViec = await _congViecRepo.GetCongViecByIdAsync(maCongViec);
                if (congViec == null)
                {
                    return Json(new { success = false, message = "Không tìm thấy thông tin công việc" });
                }

                // Kiểm tra quyền truy cập (người dùng phải là nhà tuyển dụng của công việc này)
                var congTy = await _congTyRepo.GetByUserIdAsync(currentUser);
                if (congTy == null || congTy.MaCongTy != congViec.MaCongTy)
                {
                    return Json(new { success = false, message = "Bạn không có quyền xem CV này" });
                }

                // Lấy thông tin ứng tuyển để kiểm tra người dùng đã ứng tuyển công việc này chưa
                var ungTuyen = await _ungTuyenRepo.GetByUserIdAndJobIdAsync(tenTaiKhoan, maCongViec);
                if (ungTuyen == null)
                {
                    return Json(new { success = false, message = "Không tìm thấy thông tin ứng tuyển" });
                }

                // Nếu đường dẫn CV đã được lưu trực tiếp trong bảng UngTuyen
                // if (!string.IsNullOrEmpty(ungTuyen.DuongDanCV))
                // {
                //     return Json(new { success = true, fileUrl = ungTuyen.DuongDanCV });
                // }

                // Truy vấn bảng File để tìm CV của ứng viên
                var files = await _fileRepo.GetFilesByUserIdAsync(tenTaiKhoan);
                if (files == null || !files.Any())
                {
                    return Json(new { success = false, message = "Không tìm thấy CV của ứng viên" });
                }

                // Tìm file CV phù hợp với mã công việc này
                // Đường dẫn file thường có dạng "/uploads/fiveCV/{maCongViec}/{tenFile}"
                var cvFile = files.FirstOrDefault(f => 
                    f.DuongDan != null && 
                    f.DuongDan.Contains($"/fiveCV/{maCongViec}/")
                );

                if (cvFile == null)
                {
                    return Json(new { success = false, message = "Không tìm thấy CV cho công việc này" });
                }

                return Json(new { success = true, fileUrl = cvFile.DuongDan });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = $"Lỗi: {ex.Message}" });
            }
        }

        [HttpGet]
        public async Task<IActionResult> DownloadCV(string tenTaiKhoan, string maCongViec)
        {
            try
            {
                // Kiểm tra đăng nhập
                var currentUser = HttpContext.Session.GetString("TenTaiKhoan");
                if (string.IsNullOrEmpty(currentUser))
                {
                    return Json(new { success = false, message = "Vui lòng đăng nhập để tải CV" });
                }

                // Kiểm tra 
                if (string.IsNullOrEmpty(tenTaiKhoan) || string.IsNullOrEmpty(maCongViec))
                {
                    return Json(new { success = false, message = "Dữ liệu không hợp lệ" });
                }

                // Lấy thông tin công việc
                var congViec = await _congViecRepo.GetCongViecByIdAsync(maCongViec);
                if (congViec == null)
                {
                    return Json(new { success = false, message = "Không tìm thấy thông tin công việc" });
                }

                // Kiểm tra quyền truy cập (người dùng phải là nhà tuyển dụng của công việc này)
                var congTy = await _congTyRepo.GetByUserIdAsync(currentUser);
                if (congTy == null || congTy.MaCongTy != congViec.MaCongTy)
                {
                    return Json(new { success = false, message = "Bạn không có quyền tải CV này" });
                }

                // Lấy thông tin ứng tuyển
                var ungTuyen = await _ungTuyenRepo.GetByUserIdAndJobIdAsync(tenTaiKhoan, maCongViec);
                if (ungTuyen == null)
                {
                    return Json(new { success = false, message = "Không tìm thấy thông tin ứng tuyển" });
                }

                // Tìm bảng File để tìm CV của ứng viên
                var files = await _fileRepo.GetFilesByUserIdAsync(tenTaiKhoan);
                if (files == null || !files.Any())
                {
                    return Json(new { success = false, message = "Không tìm thấy CV của ứng viên" });
                }

                // Tìm file CV phù hợp với mã công việc này
                var cvFile = files.FirstOrDefault(f => 
                    f.DuongDan != null && 
                    f.DuongDan.Contains($"/fiveCV/{maCongViec}/")
                );

                if (cvFile == null)
                {
                    return Json(new { success = false, message = "Không tìm thấy CV cho công việc này" });
                }

                // Lấy đường dẫn vật lý của file
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", cvFile.DuongDan.TrimStart('/'));
                
                if (!System.IO.File.Exists(filePath))
                {
                    return Json(new { success = false, message = "Không tìm thấy file CV" });
                }

                // Lấy tên file gốc hoặc tạo tên file mới nếu không có
                // var fileName = Path.GetFileName(filePath);
                // if (string.IsNullOrEmpty(fileName))
                // {
                    var fileName = $"CV_{tenTaiKhoan}_{DateTime.Now.ToString("yyyyMMdd")}.pdf";
                // }

                // Đọc file và trả về để download
                var fileBytes = await System.IO.File.ReadAllBytesAsync(filePath);
                var contentType = GetContentType(filePath);
                
                return File(fileBytes, contentType, fileName);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = $"Lỗi: {ex.Message}" });
            }
        }

        private string GetContentType(string filePath)
        {
            var extension = Path.GetExtension(filePath).ToLowerInvariant();
            return extension switch
            {
                ".pdf" => "application/pdf",
                ".doc" => "application/msword",
                ".docx" => "application/vnd.openxmlformats-officedocument.wordprocessingml.document",
                ".jpg" or ".jpeg" => "image/jpeg",
                ".png" => "image/png",
                _ => "application/octet-stream"
            };
        }
    
    
    }
}