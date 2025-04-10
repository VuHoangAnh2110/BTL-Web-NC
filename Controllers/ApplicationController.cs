using Microsoft.AspNetCore.Mvc;
using BTL_Web_NC.Models;
using BTL_Web_NC.Repositories;
using BTL_Web_NC.Helpers;

namespace BTL_Web_NC.Controllers
{
    public class ApplicationController : Controller
    {
        private readonly IUngTuyenRepository _ungTuyenRepo;
        private readonly ITaiKhoanRepository _taiKhoanRepo;
        private readonly ICongViecRepository _congViecRepo;
        private readonly IHoSoUngVienRepository _hoSoUngVienRepo;
        private readonly IThongBaoRepository _thongBaoRepo;
        private readonly IFileUpLoadRepository _fileUploadRepo;

        public ApplicationController(IUngTuyenRepository ungTuyenRepo, ITaiKhoanRepository taiKhoanRepo, 
                                        ICongViecRepository congViecRepo, IHoSoUngVienRepository hoSoUngVienRepo,
                                        IThongBaoRepository thongBaoRepo, IFileUpLoadRepository fileUploadRepo)
        {
            _ungTuyenRepo = ungTuyenRepo;
            _taiKhoanRepo = taiKhoanRepo;
            _congViecRepo = congViecRepo;
            _hoSoUngVienRepo = hoSoUngVienRepo;
            _thongBaoRepo = thongBaoRepo;
            _fileUploadRepo = fileUploadRepo;
        }

        [HttpPost]
        [Route("Application/ApplyJob")]
        public async Task<IActionResult> ApplyJob(string maCongViec, IFormFile cv)
        {
            try
            {
                // Kiểm tra đăng nhập
                var tenTaiKhoan = HttpContext.Session.GetString("TenTaiKhoan");
                if (string.IsNullOrEmpty(tenTaiKhoan))
                {
                    return Json(new { success = false, message = "Vui lòng đăng nhập để ứng tuyển." });
                }

                // Lấy thông tin người dùng
                var user = await _taiKhoanRepo.GetByTenTaiKhoanAsync(tenTaiKhoan);
                if (user == null)
                {
                    return Json(new { success = false, message = "Không tìm thấy thông tin tài khoản." });
                }

                // Kiểm tra công việc tồn tại
                var job = await _congViecRepo.GetCongViecByIdAsync(maCongViec);
                if (job == null)
                {
                    return Json(new { success = false, message = "Công việc không tồn tại!" });
                }

                // Kiểm tra người dùng đã ứng tuyển chưa
                var existingApplication = await _ungTuyenRepo.GetByUserIdAndJobIdAsync(tenTaiKhoan, maCongViec);
                if (existingApplication != null)
                {
                    return Json(new { success = false, message = "Bạn đã ứng tuyển công việc này." });
                }

                // Kiểm tra file CV
                if (cv == null || cv.Length == 0)
                {
                    return Json(new { success = false, message = "Vui lòng tải lên CV." });
                }

                // Kiểm tra định dạng file
                var allowedExtensions = new[] { ".pdf", ".doc", ".docx" };
                var fileExtension = Path.GetExtension(cv.FileName).ToLowerInvariant();
                if (!allowedExtensions.Contains(fileExtension))
                {
                    return Json(new { success = false, message = "Chỉ chấp nhận file PDF, DOC, DOCX." });
                }

                // Kiểm tra kích thước file (tối đa 5MB)
                if (cv.Length > 5 * 1024 * 1024)
                {
                    return Json(new { success = false, message = "Kích thước file tối đa là 5MB." });
                }

                // Tạo thư mục nếu chưa tồn tại
                var uploadDir = Path.Combine("wwwroot", "uploads", "fiveCV", maCongViec);
                if (!Directory.Exists(uploadDir))
                {
                    Directory.CreateDirectory(uploadDir);
                }

                // Tạo tên file duy nhất để tránh trùng lặp
                var fileName = $"{tenTaiKhoan}_{DateTime.Now.ToString("yyyyMMdd_HHmmss")}{fileExtension}";
                var filePath = Path.Combine(uploadDir, fileName);

                // Lưu file CV
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await cv.CopyToAsync(stream);
                }

                // Đường dẫn tương đối để lưu vào DB
                var relativeFilePath = $"/upload/fiveCV/{maCongViec}/{fileName}";

                // Tạo mới ứng tuyển
                var ungTuyen = new UngTuyen
                {
                    MaUngTuyen = IdGenerator.GenerateUngTuyenId(),
                    TenTaiKhoan = tenTaiKhoan,
                    MaCongViec = maCongViec,
                    NgayUngTuyen = DateTime.Now,
                    TrangThai = "Đang chờ",
                    // DuongDanCV = relativeFilePath
                };
                
                var file = new FileUpload
                {
                    MaFile = IdGenerator.GenerateFileId(),
                    DuongDan = relativeFilePath,
                    TenFile = fileName,
                    LoaiFile = "CV",
                    TenTaiKhoan = tenTaiKhoan,
                    NgayTaiLen = DateTime.Now
                };

                // Tạo thông báo cho nhà tuyển dụng
                var thongBao = new ThongBao
                {
                    MaThongBao = IdGenerator.GenerateThongBaoId(),
                    MaCongTy = job.MaCongTy,
                    MaCongViec = maCongViec,
                    TenTaiKhoan = job.CongTy?.TenTaiKhoan, // Gửi thông báo cho chủ công ty
                    TieuDe = "Thông báo ứng tuyển mới",
                    LoaiThongBao = "Ứng tuyển",
                    NoiDung = $"Ứng viên {user.HoTen} đã ứng tuyển vào công việc {job.TieuDe}.",
                    DaXem = false,
                    NgayThongBao = DateTime.Now
                };

                // Lưu thông tin vào cơ sở dữ liệu
                await _fileUploadRepo.AddFileAsync(file);
                await _thongBaoRepo.AddThongBaoAsync(thongBao);
                await _ungTuyenRepo.AddHoSoUngTuyenAsync(ungTuyen);

                return Json(new { success = true, message = "Ứng tuyển thành công! Nhà tuyển dụng sẽ liên hệ với bạn sớm." });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = $"Có lỗi xảy ra: {ex.Message}" });
            }
        }


        
    }
}