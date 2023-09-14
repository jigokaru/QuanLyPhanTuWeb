using Microsoft.AspNetCore.Mvc;
using QuanLyPhanTuWeb.Iservices;
using QuanLyPhanTuWeb.Models;
using QuanLyPhanTuWeb.Services;

namespace QuanLyPhanTuWeb.Controllers
{
    public class ResetPasswordController : Controller
    {
        private readonly IResetPasswordServices resetPasswordServices;

        public ResetPasswordController()
        {
            resetPasswordServices = new ResetPasswordServices();
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult DatLaiMatKhau(ResetPassword resetPassword)
        {
            var res = resetPasswordServices.DatLaiMatKhau(resetPassword);
            string password =
                BCrypt.Net.BCrypt.HashPassword(resetPassword.passwordHash);
            resetPassword.passwordHash = password;
            string repassword =
                BCrypt.Net.BCrypt.HashPassword(resetPassword.repasswordHash);
            resetPassword.repasswordHash = repassword;
            return RedirectToAction("Index", "Login");

        }
    }
}
