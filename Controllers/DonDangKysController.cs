using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using QuanLyPhanTuWeb.Dto;
using QuanLyPhanTuWeb.Helper;
using QuanLyPhanTuWeb.Iservices;
using QuanLyPhanTuWeb.Models;
using QuanLyPhanTuWeb.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace QuanLyPhanTuWeb.Controllers
{
    public class DonDangKysController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IDonDangKyServices _donDangKyServices;
        private readonly IRoleService _roleService;

        public DonDangKysController()
        {
            _db = new AppDbContext();
            _donDangKyServices = new DonDangKyServices();
            _roleService = new RoleService();
        }

        public IActionResult Index(bool? trangThaiDon, string? tenPhatTu, DateTime? ngayGuiDon,
                                    int pageNumber = 1, int pageSize = 10)
        {
            IQueryable<DonDangKys> donDangKysQuery = _donDangKyServices.donDangKyList(trangThaiDon, tenPhatTu, ngayGuiDon);
            Pagination<DonDangKys> paginatedDonDangKys = PageResult<DonDangKys>.ToPageResult(donDangKysQuery, pageNumber, pageSize);
            return View(paginatedDonDangKys);
        }

        //public IActionResult themDonDangKys()
        //{
        //    return View();
        //}

        [HttpPost]
        public IActionResult themDonDangKys(int daoTrangId)
        {
            var jwt = Request.Cookies["token"];
            var id = GetIdFromToken(jwt);
            if (ModelState.IsValid)
            {
                var res = _donDangKyServices.themDonDangKys(id, daoTrangId);
                if (res == null)
                {
                    ModelState.AddModelError("daoTrangId", "đạo tràng Id không tồn tại.");
                }
                return RedirectToAction("Index", "DaoTrangs");
            }
            ViewData["ErrorMessage"] = "bắt buộc nhập.";
            return View();
            
        }

        public IActionResult duyetDon(int? donDangkyId)
        {
            if (donDangkyId == null || donDangkyId == 0)
            {
                return NotFound();
            }
            DonDangKys donDangKys = _db.DonDangKys.FirstOrDefault(x => x.donDangkyId == donDangkyId);
            if (donDangkyId == null)
            {
                return NotFound();
            }
            DuyetDon duyetDon = new()
            {
                donDangkyId = donDangKys.donDangkyId
            };
            return View(duyetDon);
        }

        [HttpPost]
        public IActionResult duyetDon(DuyetDon? duyetDon)
        {
            var jwt = Request.Cookies["token"];
            var id = GetIdFromToken(jwt);
            var res = _donDangKyServices.duyetDon(id, duyetDon);
            return RedirectToAction("Index", "DonDangKys");
        }

        [HttpPost]
        public IActionResult xoaDonDangKys(int id)
        {
            var jwt = Request.Cookies["token"];
            var Id = GetIdFromToken(jwt);
            if(Id == null)
            {
                return BadRequest("bạn không có quyền xóa.");
            }
            var donDangKysRemove = _donDangKyServices.xoaDonDangKys(id);
            return RedirectToAction("Index", "DonDangKys");
        }

        private int? GetIdFromToken(string jwtToken)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            if (!string.IsNullOrEmpty(jwtToken))
            {
                var token = tokenHandler.ReadJwtToken(jwtToken);
                var expiration = token.ValidTo;
                if (DateTime.UtcNow <= expiration)
                {
                    var idClaim = token.Claims.FirstOrDefault(c => c.Type == "accountId");
                    int Id;
                    if (int.TryParse(idClaim.Value, out Id))
                    {
                        return Id;
                    }
                }
                else
                {
                    Response.Cookies.Delete("token");
                    throw new InvalidOperationException("Token has expired.");
                }
            }
            return null;

        }
    }
}
