using Microsoft.AspNetCore.Mvc;
using QuanLyPhanTuWeb.Dto;
using QuanLyPhanTuWeb.Helper;
using QuanLyPhanTuWeb.Iservices;
using QuanLyPhanTuWeb.Models;
using QuanLyPhanTuWeb.Services;
using System.IdentityModel.Tokens.Jwt;

namespace QuanLyPhanTuWeb.Controllers
{
    public class PhatTuController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IphatuServices _phatuServices;

        public PhatTuController()
        {
            _db = new AppDbContext();
            _phatuServices = new PhanTuServices();
        }
        
        public IActionResult Index()
        {
            var jwt = Request.Cookies["token"];
            var id = GetIdFromToken(jwt);
            PhanTu phanTu = _db.PhanTu.FirstOrDefault(x => x.phatTuId == id);
            return View(phanTu);
        }
        public async Task<IActionResult> Upsert(PhatTuDto phatTuDto)
        {
            var jwt = Request.Cookies["token"];
            var id = GetIdFromToken(jwt);
            var phanTuUpdate = _phatuServices.ThemPhatTu(id, phatTuDto);
            if (phanTuUpdate != null)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> fileUpload(IFormFile? file)
        {
            var jwt = Request.Cookies["token"];
            var id = GetIdFromToken(jwt);
            PhanTu phanTu = _db.PhanTu.FirstOrDefault(x => x.phatTuId == id);
            if(phanTu != null)
            {
                if(file != null && file.Length > 0)
                {
                    string link = await uplloadFile.UploadFile(file);
                    phanTu.anhChup = link;
                    _db.PhanTu.Update(phanTu);
                    _db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");
        }

        private int GetIdFromToken(string jwtToken)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.ReadJwtToken(jwtToken);
            var expiration = token.ValidTo;
            if (DateTime.UtcNow <= expiration)
            {
                var IdClaim = token.Claims.FirstOrDefault(c => c.Type == "accountId");
                int Id = int.Parse(IdClaim.Value);
                return Id;
            }
            else
            {
                Response.Cookies.Delete("token");
                throw new InvalidOperationException("Token has expired.");
            }
        }
    }
}
