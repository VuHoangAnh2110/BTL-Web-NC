using BTL_Web_NC.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BTL_Web_NC.Controllers
{
    public class ErrorController : Controller
    {
        private readonly ITaiKhoanRepository _taiKhoanRepo;

        public ErrorController(ITaiKhoanRepository taiKhoanRepo)
        {
            _taiKhoanRepo = taiKhoanRepo;
        }

        public IActionResult ThongBaoTuChoi()
        {
            return View();
        }


    }    
}