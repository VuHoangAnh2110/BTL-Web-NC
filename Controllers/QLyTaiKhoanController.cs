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

        public IActionResult Index()
        {
            // var accounts = await _taiKhoanRepo.GetAllAsync();
            return View();
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

        public async Task<IActionResult> Edit(int id)
        {
            var account = await _taiKhoanRepo.GetByIdAsync(id);
            if (account == null)
            {
                return NotFound();
            }
            return View(account);
        }

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
