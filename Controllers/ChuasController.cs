using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using QuanLyPhanTuWeb.Dto;
using QuanLyPhanTuWeb.Helper;
using QuanLyPhanTuWeb.Iservices;
using QuanLyPhanTuWeb.Models;
using QuanLyPhanTuWeb.Services;

namespace QuanLyPhanTuWeb.Controllers
{
    public class ChuasController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IChuasServices _chuasServices;

        public ChuasController()
        {
            _db = new AppDbContext();
            _chuasServices = new ChuasServices();
        }

        [HttpGet]
        public IActionResult Index(string? tenchua, string? diachi,
                                    int pageNumber = 1, int pageSize = 10)
        {
            IQueryable<Chuas> chuasQuery = _chuasServices.layDsChua(tenchua, diachi);
            Pagination<Chuas> paginatedChuas = PageResult<Chuas>.ToPageResult(chuasQuery, pageNumber, pageSize);
            return View(paginatedChuas);
        }

        

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ChuasDto chuasDto)
        {
            
            if (ModelState.IsValid)
            {
                var chuasNew = _chuasServices.themChuas(chuasDto);
                if (chuasNew == null)
                {
                    ModelState.AddModelError("tenChua", "Tên chùa đã tồn tại.");
                }
                else
                {
                    return RedirectToAction("Index", "Chuas");
                }
            }
            
            return View(chuasDto);
        }

        public IActionResult Update(int? chuaId)
        {
            if (chuaId == null || chuaId == 0)
            {
                return NotFound();
            }
            Chuas? chuas = _db.Chuas.FirstOrDefault(x => x.chuaId == chuaId);
            if (chuas == null)
            {
                return NotFound();
            }    
            return View(chuas);
        }
        [HttpPost]
        public IActionResult Update(Chuas chuas)
        {
            if (ModelState.IsValid)
            {
                var chuasUpdate = _chuasServices.suaChuas(chuas);
                if (chuasUpdate)
                {
                    return RedirectToAction("Index", "Chuas");
                }
                else
                {
                    return BadRequest("lưu thất bại");
                }
            }
            return View(chuas);
        }

        [HttpPost]
        public IActionResult Delete(int? id)
        {
            var chuaRemove = _chuasServices.xoaChuas(id);
            if (chuaRemove)
            {
                return RedirectToAction("Index", "Chuas");
            }
            return View();
        }
    }
}
