using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using QuanLyPhanTuWeb.Iservices;
using QuanLyPhanTuWeb.Models;
using QuanLyPhanTuWeb.Services;

namespace QuanLyPhanTuWeb.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IRegisterSevices _registerSevices;

        public RegisterController()
        {
            _registerSevices = new RegisterServices();
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult dangKy(Register register)
        {
            var res = _registerSevices.dangKy(register);
            if(res != null)
            {
                TempData["SuccessMessage"] = "Đăng ký thành công";
            }
            
            return RedirectToAction("Index", "Login");
        }
    }
}
