using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BTL_Web_NC.Repositories;


namespace BTL_Web_NC.Controllers
{
    [Authorize(Roles = "admin")] // Chỉ admin mới vào được
    public class QLyTaiKhoanController : Controller
    {
        private readonly ITaiKhoanRepository _taiKhoanRepo;

        public QLyTaiKhoanController(ITaiKhoanRepository taiKhoanRepo)
        {
            _taiKhoanRepo = taiKhoanRepo;
        }

        public async Task<IActionResult> Index()
        {
            var danhSachTaiKhoan = await _taiKhoanRepo.GetAllAsync(); // Lấy tất cả tài khoản
            return View(danhSachTaiKhoan);
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

        // public async Task<IActionResult> Edit(int id)
        // {
        //     var account = await _taiKhoanRepo.GetByIdAsync(id);
        //     if (account == null)
        //     {
        //         return NotFound();
        //     }
        //     return View(account);
        // }

        // [HttpPost]
    //     public async Task<IActionResult> Edit(AccountViewModel model)
    //     {
    //         if (ModelState.IsValid)
    //         {
    //             await _taiKhoanRepo.UpdateAsync(model);
    //             TempData["SuccessMessage"] = "Cập nhật tài khoản thành công!";
    //             return RedirectToAction(nameof(Index));
    //         }
    //         return View(model);
    //     }

    //     public async Task<IActionResult> Delete(int id)
    //     {
    //         var account = await _taiKhoanRepo.GetByIdAsync(id);
    //         if (account == null)
    //         {
    //             return NotFound();
    //         }
    //         return View(account);
    //     }

    //     [HttpPost, ActionName("Delete")]
    //     public async Task<IActionResult> DeleteConfirmed(int id)
    //     {
    //         await _taiKhoanRepo.DeleteAsync(id);
    //         TempData["SuccessMessage"] = "Xóa tài khoản thành công!";
    //         return RedirectToAction(nameof(Index));
    //     }
    
    
    }
}
