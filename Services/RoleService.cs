using Microsoft.EntityFrameworkCore;
using QuanLyPhanTuWeb.Iservices;
using QuanLyPhanTuWeb.Models;

namespace QuanLyPhanTuWeb.Services
{
    public class RoleService : IRoleService
    {
        private readonly AppDbContext _db;
        public RoleService()
        {
            _db = new AppDbContext();
        }
        public bool IsAdmin(string userId)
        {
            PhanTu check = _db.PhanTu.FirstOrDefault(x => x.phatTuId == int.Parse(userId));
            if(check.Role == "ADMIN") return true;
            else return false;
        }
    }
}
