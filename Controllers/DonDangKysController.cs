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

        [HttpPost]
        public IActionResult themDonDangKys(int daoTrangId)
        {
            var jwt = Request.Cookies["token"];
            var id = TokenHelper.GetIdFromToken(jwt);
            if (id == -1)
            {
                Response.Cookies.Delete("token");
                return Unauthorized("Token has expired.");
            }
            if (ModelState.IsValid)
            {
                var res = _donDangKyServices.themDonDangKys(id, daoTrangId);
                if (res == null)
                {
                    ViewBag.IsRegistered = HttpContext.Session.GetString("isRegistered");

                }
                else
                {
                    TempData["SuccessMessage"] = "Bạn đã đăng ký thành công.";
                    
                }
                return RedirectToAction("Index", "DaoTrangs");
            }
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
            var id = TokenHelper.GetIdFromToken(jwt);
            if (id == -1)
            {
                Response.Cookies.Delete("token");
                return Unauthorized("Token has expired.");
            }
            var res = _donDangKyServices.duyetDon(id, duyetDon);
            return RedirectToAction("Index", "DonDangKys");
        }

        [HttpPost]
        public IActionResult xoaDonDangKys(int id)
        {
            var jwt = Request.Cookies["token"];
            var Id = TokenHelper.GetIdFromToken(jwt);
            if(Id == -1)
            {
                Response.Cookies.Delete("token");
                return Unauthorized("Token has expired.");
            }
            var donDangKysRemove = _donDangKyServices.xoaDonDangKys(id);
            return RedirectToAction("Index", "DonDangKys");
        }

    }
}
