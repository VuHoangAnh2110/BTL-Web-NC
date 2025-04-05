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

        public ApplicationController(IUngTuyenRepository ungTuyenRepo, 
                                        ITaiKhoanRepository taiKhoanRepo, 
                                        ICongViecRepository congViecRepo,
                                        IHoSoUngVienRepository hoSoUngVienRepo,
                                        IThongBaoRepository thongBaoRepo)
        {
            _ungTuyenRepo = ungTuyenRepo;
            _taiKhoanRepo = taiKhoanRepo;
            _congViecRepo = congViecRepo;
            _hoSoUngVienRepo = hoSoUngVienRepo;
            _thongBaoRepo = thongBaoRepo;

        }

        [HttpPost]
        [Route("Application/ApplyJob")]
        public async Task<IActionResult> ApplyJob(string jobId, IFormFile cv, string fullName, string email, string phone)
        {
            if (cv == null || cv.Length == 0)
            {
                return BadRequest("Vui lòng tải lên CV.");
            }

            // Lưu file CV vào thư mục (nếu cần)
            var filePath = Path.Combine("wwwroot/uploads", cv.FileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await cv.CopyToAsync(stream);
            }

            // Kiểm tra nếu đã ứng tuyển rồi
            var user = await _taiKhoanRepo.GetByEmailAsync(email);
            if (user == null)
            {
                return BadRequest("Người dùng không tồn tại.");
            }

            var existingApplication = await _ungTuyenRepo.GetByUserIdAndJobIdAsync(user.TenTaiKhoan, jobId);
            if (existingApplication != null)
            {
                return BadRequest("Bạn đã ứng tuyển công việc này.");
            }

            // Tạo mới ứng tuyển
            var ungTuyen = new UngTuyen
            {
                MaUngTuyen = IdGenerator.GenerateUngTuyenId(),
                TenTaiKhoan = user.TenTaiKhoan,
                MaCongViec = jobId,
                NgayUngTuyen = DateTime.Now,
                TrangThai = "Đang chờ"
            };

            var job = await _congViecRepo.GetCongViecByIdAsync(jobId);
            if(job == null)
            {
                return BadRequest("Công việc không tồn tại");
            }
            var thongBao = new ThongBao
            {
                MaThongBao = IdGenerator.GenerateThongBaoId(),
                MaCongTy = job.MaCongTy,
                MaCongViec = jobId,
                TenTaiKhoan = user.TenTaiKhoan,
                TieuDe = "Thông báo ứng tuyển",
                LoaiThongBao = "Ứng tuyển",
                NoiDung = $"Ứng viên {user.HoTen} đã ứng tuyển vào công việc {job.TieuDe}.",
                DaXem = false,
                NgayThongBao = DateTime.Now
            };
           
            // await _thongBaoRepo.AddThongBaoAsync(thongBao);

            await _ungTuyenRepo.AddHoSoUngTuyenAsync(ungTuyen);
            return Ok("Ứng tuyển và gửi thông báo thành công!");
        }


        
    }
}