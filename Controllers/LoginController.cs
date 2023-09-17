using Microsoft.AspNetCore.Mvc;
using QuanLyPhanTuWeb.Iservices;
using QuanLyPhanTuWeb.Models;
using QuanLyPhanTuWeb.Services;
using System.Net;
using System;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace QuanLyPhanTuWeb.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginServices _loginServices;
        private readonly IConfiguration _configuration;
        private readonly AppDbContext _db;

        public LoginController(IConfiguration configuration)
        {
            _loginServices = new LoginServices();
            _configuration = configuration;
            _db = new AppDbContext();
        }

        public IActionResult Index()
        {
            if (TempData.ContainsKey("SuccessMessage"))
            {
                ViewBag.SuccessMessage = TempData["SuccessMessage"].ToString();
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(Login login)
        {
            var loginRespose = new LoginResponse();
            var UsernamePasswordValid = _loginServices.dangNhap(login);
            var Tokens = new Token();
            if (ModelState.IsValid)
            {
                if (UsernamePasswordValid != null)
                {
                    
                    string token = CreateToken(UsernamePasswordValid);
                    loginRespose.Token = token;
                    loginRespose.responseMsg = new HttpResponseMessage()
                    {
                        StatusCode = HttpStatusCode.OK,
                    };
                    _db.PhanTu.Update(UsernamePasswordValid);
                    Tokens.stoken = loginRespose.Token;
                    Tokens.expiresAt = DateTime.Now.AddHours(1);
                    Tokens.phatTuId = UsernamePasswordValid.phatTuId;
                    Response.Cookies.Append("token", token, new CookieOptions
                    {
                        HttpOnly = true,
                        Expires = DateTime.Now.AddHours(1)
                    });
                    HttpContext.Session.SetString("UserRole", UsernamePasswordValid.Role);
                    _db.Token.Add(Tokens);
                    _db.SaveChanges();
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("email", "Tên đăng nhập hoặc mật khẩu không đúng.");
                    ModelState.AddModelError("password", "Tên đăng nhập hoặc mật khẩu không đúng.");
                }
            }
            return View(login);
        }
        public IActionResult DangXuat()
        {
            Response.Cookies.Delete("token");
            return RedirectToAction("Index");
        }

        private string CreateToken(PhanTu phanTu)
        {
            List<Claim> claims = new();
            if (!string.IsNullOrEmpty(phanTu.ten))
            {
                claims.Add(new Claim("username", Convert.ToString(phanTu.ten)));
            }
            claims.Add(new Claim("email", Convert.ToString(phanTu.email)));
            claims.Add(new Claim("accountId", Convert.ToString(phanTu.phatTuId)));
            claims.Add(new Claim("role", Convert.ToString(phanTu.Role)));
            claims.Add(new Claim(ClaimTypes.Role, phanTu.Role));

            claims.Add(new Claim(ClaimTypes.NameIdentifier, phanTu.phatTuId.ToString()));

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(
                claims: claims,
                signingCredentials: cred,
                expires: DateTime.Now.AddHours(1));
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            var identity = new ClaimsIdentity(claims, JwtBearerDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);
            HttpContext.User = principal;
            
            return jwt;
        }
    }
}
