using QuanLyPhanTuWeb.Iservices;
using QuanLyPhanTuWeb.Models;

namespace QuanLyPhanTuWeb.Services
{
    public class KieuThanhViensServices : IKieuThanhViensServices
    {
        private readonly AppDbContext appDbContext;

        public KieuThanhViensServices()
        {
            appDbContext = new AppDbContext();
        }
        public KieuThanhViens themkieuthanhvien(KieuThanhViens kieuThanhViens)
        {
            appDbContext.KieuThanhViens.Add(kieuThanhViens);
            appDbContext.SaveChanges();
            return kieuThanhViens;
        }
    }
}
