using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuanLyPhanTuWeb.Dto;
using QuanLyPhanTuWeb.Helper;
using QuanLyPhanTuWeb.Iservices;
using QuanLyPhanTuWeb.Models;
using QuanLyPhanTuWeb.Services;
using System.IdentityModel.Tokens.Jwt;

namespace QuanLyPhanTuWeb.Controllers
{
    public class GiamSatHocTapController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IphatuServices _phantuServices;
        public GiamSatHocTapController()
        {
            _db = new AppDbContext();
            _phantuServices = new PhanTuServices();
        }
        [HttpGet]
        public IActionResult Index(             string? ten,
                                                string? email,
                                                string? phapdanh,
                                                string? gioitinh,
                                                bool? isActive,
                                                string sortOrder = "desc",
                                                int pageNumber = 1,
                                                int pageSize = 10)
        {
            var jwt = Request.Cookies["token"];
            var role = GetRolesFromToken(jwt);
            if (role.Equals("ADMIN"))
            {
                IQueryable<PhanTu> phanTuQuery = _phantuServices.LayDsPhatTu(ten, email, phapdanh, gioitinh, isActive, sortOrder);
                if(isActive == null)
                {
                    phanTuQuery = phanTuQuery.Where(x => x.isActive == true);
                }
                Pagination<PhanTu> paginatedPhanTus = PageResult<PhanTu>.ToPageResult(phanTuQuery, pageNumber, pageSize);
                return View(paginatedPhanTus);
            }
            else
            {
                return BadRequest("bạn không được phép truy cập.");
            }
            
        }
        [HttpPost]
        public IActionResult SuaThongTinPhatTu(int? id, PhatTuDto phatTuDto)
        {
            var phatuUpdate = _phantuServices.ThemPhatTu(id, phatTuDto);
            if(phatuUpdate == null)
            {
                return NotFound();
            }
            return RedirectToAction("Index", "GiamSatHocTap");
        }
        [HttpPost]
        public IActionResult XoaPhatTu(int? id)
        {
            var phatuRemove = _phantuServices.XoaPhanTu(id);
            if (phatuRemove == false)
            {
                return NotFound();
            }
            return RedirectToAction("Index", "GiamSatHocTap");
        }

        private string GetRolesFromToken(string jwtToken)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            if (!string.IsNullOrEmpty(jwtToken))
            {
                var token = tokenHandler.ReadJwtToken(jwtToken);
                var expiration = token.ValidTo;
                if (DateTime.UtcNow <= expiration)
                {
                    var roleClaim = token.Claims.FirstOrDefault(c => c.Type == "role");
                    string role = roleClaim.Value;
                    return role;
                }
                else
                {
                    Response.Cookies.Delete("token");
                    throw new InvalidOperationException("Token has expired.");
                }
            }
            else
            {
                return "token null";
            }
            
        }

    }
}
