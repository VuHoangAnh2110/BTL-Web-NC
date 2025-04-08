using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BTL_Web_NC.Repositories;
using BTL_Web_NC.ViewModels;
using BTL_Web_NC.Models;
using BTL_Web_NC.Services;


namespace BTL_Web_NC.Controllers
{
    [Authorize(Roles = "admin")] // Chỉ admin mới vào được
    public class QLyTaiKhoanController : Controller
    {
        private readonly ITaiKhoanRepository _taiKhoanRepo;
        private readonly IEmailService _emailService;

        public QLyTaiKhoanController(ITaiKhoanRepository taiKhoanRepo, IEmailService emailService)
        {
            _emailService = emailService;
            _taiKhoanRepo = taiKhoanRepo;
        }

        public async Task<IActionResult> Index(string inpSearch, string selectVaiTro, string selectTrangThai)
        {
            // var danhSachTaiKhoan = await _taiKhoanRepo.GetAllAsync(); // Lấy tất cả tài khoản
            // return View(danhSachTaiKhoan);

            // Lấy danh sách tài khoản với bộ lọc
            var accounts = await _taiKhoanRepo.BoLocTimKiemTKAsync(inpSearch, selectVaiTro, selectTrangThai);
            
            // Lưu các giá trị tìm kiếm vào ViewBag để giữ lại trong form
            ViewBag.CurrentSearch = inpSearch ?? "";
            ViewBag.CurrentVaiTro = selectVaiTro ?? "all";
            ViewBag.CurrentTrangThai = selectTrangThai ?? "all";
            
            // Thêm thông báo nếu không có kết quả
            if (!accounts.Any() && (!string.IsNullOrEmpty(inpSearch) || 
                                selectVaiTro != "all" || selectTrangThai != "all"))
            {
                ViewBag.SearchMessage = "Không tìm thấy tài khoản phù hợp với điều kiện tìm kiếm";
            }
            
            return View(accounts);
        }

        [HttpPost]
        public async Task<IActionResult> KhoaTaiKhoan(string ipKhoaid)
        {
            if (string.IsNullOrEmpty(ipKhoaid))
            {
                return Json(new { success = false, message = "Thiếu thông tin tài khoản" });
            }

            var account = await _taiKhoanRepo.GetByTenTaiKhoanAsync(ipKhoaid);
            if (account == null)
            {
                return Json(new { success = false, message = "Không tìm thấy tài khoản" });
            }

            string message;

            // Nếu trạng thái = 2 (Hoạt động) thì chuyển thành 3 (Bị khóa) và ngược lại
            if (account.TrangThai == 2)
            {
                account.TrangThai = 3;
                message = "Tài khoản đã bị khóa";
            }
            else if (account.TrangThai == 3)
            {
                account.TrangThai = 2;
                message = "Tài khoản đã được mở khóa";
            }
            else
            {
                return Json(new { success = false, message = "Tài khoản không thể khóa" });
            }
            await _taiKhoanRepo.UpdateAsync(account);
            HttpContext.Session.SetString("SuccessMessage", "Cập nhật trạng thái thành công!");

            return Json(new
            {
                success = true,
                message = message
            });
        }

        public async Task<IActionResult> Details(int id)
        {
            var account = await _taiKhoanRepo.GetByIdAsync(id);
            if (account == null)
            {
                return NotFound();
            }
            return View(account);
        }

        [HttpGet]
        public async Task<IActionResult> CapNhatTK(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            var taiKhoan = await _taiKhoanRepo.GetByTenTaiKhoanAsync(id);
            if (taiKhoan == null)
            {
                return NotFound();
            }

            // Tạo ViewModel để hiển thị và cập nhật thông tin
            var viewModel = new CapNhatTKViewModel
            {
                TenTaiKhoan = taiKhoan.TenTaiKhoan,
                HoTen = taiKhoan.HoTen,
                Email = taiKhoan.Email,
                SoDienThoai = taiKhoan.SoDienThoai,
                DiaChi = taiKhoan.DiaChi,
                VaiTro = taiKhoan.VaiTro,
                TrangThai = taiKhoan.TrangThai
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CapNhatTK(CapNhatTKViewModel model)
        {
            if (!ModelState.IsValid)
            {
                HttpContext.Session.SetString("WarningMessage", "Cập nhật tài khoản không thành công!");
                return View(model);
            }

            var taiKhoan = await _taiKhoanRepo.GetByTenTaiKhoanAsync(model.TenTaiKhoan);
            if (taiKhoan == null)
            {
                HttpContext.Session.SetString("WarningMessage", "Cập nhật tài khoản không thành công!");
                return NotFound();
            }

            // Cập nhật thông tin tài khoản
            taiKhoan.HoTen = model.HoTen;
            taiKhoan.Email = model.Email;
            taiKhoan.SoDienThoai = model.SoDienThoai;
            taiKhoan.DiaChi = model.DiaChi;
            taiKhoan.VaiTro = model.VaiTro;
            taiKhoan.TrangThai = model.TrangThai;
            taiKhoan.NgayCapNhat = DateTime.Now;

            // Lưu thay đổi vào cơ sở dữ liệu
            await _taiKhoanRepo.UpdateAsync(taiKhoan);
            // Thông báo thành công qua session
            HttpContext.Session.SetString("SuccessMessage", "Cập nhật thông tin tài khoản thành công!");
            return RedirectToAction("CapNhatTK");
        }
    
        [HttpGet]
        public IActionResult ThemTK()
        {
            // Kiểm tra quyền admin
            if (!User.IsInRole("admin"))
            {
                return RedirectToAction("AccessDenied", "Account");
            }
            
            // Hiển thị form tạo mới tài khoản với giá trị mặc định
            var model = new ThemTKViewModel
            {
                VaiTro = "user",
                TrangThai = 2 // Mặc định là hoạt động
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ThemTK(ThemTKViewModel model)
        {
            // Kiểm tra quyền admin
            if (!User.IsInRole("admin"))
            {
                return RedirectToAction("AccessDenied", "Account");
            }

            if (ModelState.IsValid)
            {   
                var isvalid = true;
                // Kiểm tra email đã tồn tại
                var existingEmail = await _taiKhoanRepo.GetByEmailAsync(model.Email);
                if (existingEmail != null)
                {
                    ModelState.AddModelError(nameof(model.Email), "Email đã tồn tại trong hệ thống");
                    isvalid = false;
                }
                // Kiểm tra tên tài khoản đã tồn tại
                var existingUsername = await _taiKhoanRepo.GetByTenTaiKhoanAsync(model.TenTaiKhoan);
                if (existingUsername != null)
                {
                    ModelState.AddModelError(nameof(model.TenTaiKhoan), "Tên tài khoản đã tồn tại trong hệ thống");
                    isvalid = false;
                }
                // Kiểm tra số điện thoại đã tồn tại (nếu có)
                if (!string.IsNullOrEmpty(model.SoDienThoai))
                {
                    var existingPhone = await _taiKhoanRepo.GetBySoDienThoaiAsync(model.SoDienThoai);
                    if (existingPhone != null)
                    {
                        ModelState.AddModelError(nameof(model.SoDienThoai), "Số điện thoại đã tồn tại trong hệ thống");
                        isvalid = false;
                    }
                }
                if (!isvalid){
                    HttpContext.Session.SetString("WarningMessage", "Thêm tài khoản mới không thành công!");
                    return View(model);
                }

                // Tạo tài khoản mới
                var taiKhoan = new TaiKhoan
                {
                    TenTaiKhoan = model.TenTaiKhoan,
                    HoTen = model.HoTen,
                    Email = model.Email,
                    MatKhau = BCrypt.Net.BCrypt.HashPassword(model.MatKhau), // Mã hóa mật khẩu
                    SoDienThoai = model.SoDienThoai,
                    DiaChi = model.DiaChi,
                    VaiTro = model.VaiTro,
                    TrangThai = model.TrangThai,
                    NgayTao = DateTime.Now,
                    NgayCapNhat = DateTime.Now
                };

                // Lưu tài khoản vào cơ sở dữ liệu
                await _taiKhoanRepo.AddTaiKhoanAsync(taiKhoan);

                // Thông báo thành công
                HttpContext.Session.SetString("SuccessMessage", "Thêm tài khoản mới thành công!");
                return RedirectToAction("Index");
            }
            // Nếu có lỗi, hiển thị lại form với thông báo lỗi
            HttpContext.Session.SetString("WarningMessage", "Thêm tài khoản mới không thành công!");
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(string tenTaiKhoan)
        {
            if (string.IsNullOrEmpty(tenTaiKhoan))
            {
                return Json(new { success = false, message = "Không có thông tin tài khoản" });
            }

            try
            {
                // Lấy thông tin tài khoản
                var taiKhoan = await _taiKhoanRepo.GetByTenTaiKhoanAsync(tenTaiKhoan);
                if (taiKhoan == null)
                {
                    return Json(new { success = false, message = "Không tìm thấy thông tin tài khoản" });
                }

                // Mật khẩu mới mặc định
                string newPassword = "reset@123";
                // Mã hóa mật khẩu mới
                string passwordHash = BCrypt.Net.BCrypt.HashPassword(newPassword);
                
                // Cập nhật mật khẩu mới vào database
                taiKhoan.MatKhau = passwordHash;
                taiKhoan.NgayCapNhat = DateTime.Now;
                await _taiKhoanRepo.UpdateAsync(taiKhoan);
                
                // Gửi email thông báo về việc reset mật khẩu
                await SendResetPasswordEmail(taiKhoan, newPassword);
                
                return Json(new { success = true, message = "Đặt lại mật khẩu thành công và đã gửi email thông báo!" });
            }
            catch (Exception ex)
            {
                // Log lỗi nếu có
                Console.WriteLine($"Reset password error: {ex.Message}");
                return Json(new { success = false, message = $"Lỗi: {ex.Message}" });
            }
        }

        private async Task SendResetPasswordEmail(TaiKhoan taiKhoan, string newPassword)
        {
            string subject = "Thông báo đặt lại mật khẩu";
            string body = $@"
                <html>
                <head>
                    <style>
                        body {{
                            font-family: Arial, sans-serif;
                            line-height: 1.6;
                        }}
                        .container {{
                            max-width: 600px;
                            margin: 0 auto;
                            padding: 20px;
                            border: 1px solid #ddd;
                            border-radius: 5px;
                        }}
                        .header {{
                            background-color:rgb(105, 226, 157);
                            color: #333;
                            padding: 15px;
                            text-align: center;
                            border-radius: 5px 5px 0 0;
                        }}
                        .content {{
                            padding: 20px;
                            background-color: #fff;
                        }}
                        .footer {{
                            background-color: #f1f1f1;
                            padding: 10px;
                            text-align: center;
                            font-size: 12px;
                            border-radius: 0 0 5px 5px;
                        }}
                        .alert {{
                            background-color: #f8f9fa;
                            border-left: 4px solid #f8d210;
                            padding: 10px 15px;
                            margin: 15px 0;
                        }}
                        .button {{
                            display: inline-block;
                            background-color: #007bff;
                            color: white;
                            padding: 10px 20px;
                            text-decoration: none;
                            border-radius: 5px;
                            margin-top: 15px;
                        }}
                        table {{
                            width: 100%;
                            border-collapse: collapse;
                        }}
                        table td, table th {{
                            padding: 8px;
                            border: 1px solid #ddd;
                        }}
                        table th {{
                            background-color: #f2f2f2;
                        }}
                    </style>
                </head>
                <body>
                    <div class='container'>
                        <div class='header'>
                            <h2>Thông Báo Đặt Lại Mật Khẩu</h2>
                        </div>
                        <div class='content'>
                            <p>Xin chào <b>{taiKhoan.HoTen}</b>,</p>
                            <p>Mật khẩu tài khoản của bạn đã được đặt lại bởi quản trị viên. Dưới đây là thông tin đăng nhập mới của bạn:</p>
                            
                            <div class='alert'>
                                <table>
                                    <tr>
                                        <th>Tên tài khoản</th>
                                        <td>{taiKhoan.TenTaiKhoan}</td>
                                    </tr>
                                    <tr>
                                        <th>Email</th>
                                        <td>{taiKhoan.Email}</td>
                                    </tr>
                                    <tr>
                                        <th>Mật khẩu mới</th>
                                        <td><strong>{newPassword}</strong></td>
                                    </tr>
                                </table>
                            </div>
                            
                            <p>Vui lòng đăng nhập và đổi mật khẩu ngay để đảm bảo an toàn cho tài khoản của bạn.</p>
                            
                            <p>Nếu bạn không yêu cầu đặt lại mật khẩu, hãy liên hệ với quản trị viên ngay lập tức.</p>
                            
                            <p>Trân trọng,<br><b>Ban quản trị</b></p>
                        </div>
                        <div class='footer'>
                            <p>© {DateTime.Now.Year} Công Ty Tuyển Dụng - Mọi quyền được bảo lưu.</p>
                            <p>Email này được gửi tự động, vui lòng không trả lời.</p>
                        </div>
                    </div>
                </body>
                </html>
            ";

            try
            {
                if (_emailService != null)
                {
                    await _emailService.SendEmailAsync(taiKhoan.Email, subject, body);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Send email error: {ex.Message}");
                throw;
            }
        }



    }
}
