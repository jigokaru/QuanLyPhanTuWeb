using Microsoft.AspNetCore.Mvc;
using QuanLyPhanTuWeb.Dto;
using QuanLyPhanTuWeb.Helper;
using QuanLyPhanTuWeb.Iservices;
using QuanLyPhanTuWeb.Models;
using QuanLyPhanTuWeb.Services;
using System.IdentityModel.Tokens.Jwt;

namespace QuanLyPhanTuWeb.Controllers
{
    public class DaoTrangsController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IDaoTrangsServices _daoTrangsServices;
        public DaoTrangsController()
        {
            _db = new AppDbContext();
            _daoTrangsServices = new DaoTrangsServices();
        }

        public IActionResult Index(Boolean? daKetThuc, string? noiToChuc, DateTime? thoiGianToChuc,
                                    int pageNumber = 1, int pageSize = 10)
        {
            if (TempData.ContainsKey("SuccessMessage"))
            {
                ViewBag.SuccessMessage = TempData["SuccessMessage"].ToString();
            }
            IQueryable<DaoTrangs> daoTrangsQuery = _daoTrangsServices.layDsDaoTrangs(daKetThuc, noiToChuc, thoiGianToChuc);
            Pagination<DaoTrangs> paginatedDaoTrangs = PageResult<DaoTrangs>.ToPageResult(daoTrangsQuery, pageNumber, pageSize);
            return View(paginatedDaoTrangs);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(DaoTrangsDto daoTrangsDto)
        {
            var jwt = Request.Cookies["token"];
            var id = GetIdFromToken(jwt);
            var daoTrangsNew = _daoTrangsServices.themDaoTrangs(id, daoTrangsDto);
            if (ModelState.IsValid)
            {
                if (daoTrangsNew != null)
                {
                    return RedirectToAction("Index", "DaoTrangs");
                }
            }
            
            return View(daoTrangsDto);
        }

        public IActionResult Update(int? daoTrangId)
        {
            if (daoTrangId == null || daoTrangId == 0)
            {
                return NotFound();
            }
            DaoTrangs daoTrangs = _db.DaoTrangs.FirstOrDefault(x => x.daoTrangId == daoTrangId);
            if (daoTrangs == null)
            {
                return NotFound();
            }
            return View(daoTrangs);
        }

        [HttpPost]
        public IActionResult Update(DaoTrangs daoTrangs)
        {
            var jwt = Request.Cookies["token"];
            var id = GetIdFromToken(jwt);
            var daoTrangsUpdate = _daoTrangsServices.suaDaoTrangs(daoTrangs);
            if (ModelState.IsValid)
            {
                if(id != null)
                {
                    if (daoTrangsUpdate)
                    {
                        return RedirectToAction("Index", "DaoTrangs");
                    }
                }
                else
                {
                    return BadRequest("bạn không được phép hoạt động.");
                }
                
            }
            
            return View(daoTrangs);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var jwt = Request.Cookies["token"];
            var Id = GetIdFromToken(jwt);
            var daoTrangsRemove = _daoTrangsServices.xoaDaoTrangs(id);
            if (Id != null)
            {
                if (daoTrangsRemove)
                {
                    return RedirectToAction("Index", "DaoTrangs");
                }
            }
            else
            {
                return BadRequest("bạn không được phép hoạt động.");
            }

            return View();
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
