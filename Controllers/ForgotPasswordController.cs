using Microsoft.AspNetCore.Mvc;
using QuanLyPhanTuWeb.Iservices;
using QuanLyPhanTuWeb.Models;
using QuanLyPhanTuWeb.Services;
using QuanLyPhanTuWebWeb.Services;
using System.Security.Cryptography;

namespace QuanLyPhanTuWeb.Controllers
{
    public class ForgotPasswordController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IEmailServices _emailServices;
       

        public ForgotPasswordController(IEmailServices emailServices)
        {
            _db = new AppDbContext();
            _emailServices = emailServices;
            
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult QuenMatKhau(string email)
        {

            var user = _db.TokenResetPassword.FirstOrDefault(x => x.emailToken == email);

            if (user == null)
            {
                return BadRequest("user not found.");
            }
            else
            {
                user.PasswordResetToken = CreateRandomCode();
                user.ResetTokenExpires = DateTime.Now.AddHours(1);
                _db.TokenResetPassword.Update(user);
                _db.SaveChanges();
                var sendEmail = _emailServices.sendEmail(email);
            }
            return RedirectToAction("Index", "ResetPassword");

        }
        
        private string CreateRandomCode()
        {
            return Convert.ToHexString(RandomNumberGenerator.GetBytes(3));
        }
    }
}
