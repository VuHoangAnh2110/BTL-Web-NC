using Microsoft.AspNetCore.Mvc;
using BTL_Web_NC.Models;
using BTL_Web_NC.Repositories;

namespace BTL_Web_NC.Controllers
{
    public class AdminEmployerController : Controller
    {
        private readonly ICongTyRepository _congTyRepo;

        public AdminEmployerController(ICongTyRepository congTyRepo)
        {
            _congTyRepo = congTyRepo;
        }

        public async Task<IActionResult> Index()
        {
            var danhSachNhaTuyenDung = await _congTyRepo.GetAllAsync();
            return View(danhSachNhaTuyenDung);
        }

        public async Task<IActionResult> Detail(string id)
        {
            var congTy = await _congTyRepo.GetByIdAsync(id);
            if (congTy == null)
                return NotFound();
            return View(congTy);
        }
    }

}
