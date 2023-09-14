using QuanLyPhanTuWeb.Dto;
using QuanLyPhanTuWeb.Iservices;
using QuanLyPhanTuWeb.Models;

namespace QuanLyPhanTuWeb.Services
{
    public class ChuasServices : IChuasServices
    {
        private readonly AppDbContext appDbContext;

        public ChuasServices()
        {
            appDbContext = new AppDbContext();
        }

        public bool suaChuas(Chuas chuas)
        {
            Chuas chuasUpdate = appDbContext.Chuas.FirstOrDefault(x => x.chuaId == chuas.chuaId);
            if (chuasUpdate != null)
            {
                chuasUpdate.diaChi = chuas.diaChi;
                chuasUpdate.capNhap = DateTime.UtcNow;
                chuasUpdate.ngayThanhLap = chuas.ngayThanhLap;
                chuasUpdate.tenChua = chuas.tenChua;
                appDbContext.Chuas.Update(chuasUpdate);
                appDbContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public Chuas themChuas(ChuasDto chuasDto)
        {
            Chuas chuas = appDbContext.Chuas.FirstOrDefault(x => x.tenChua == chuasDto.tenChua);
            if(chuas == null)
            {
                Chuas chuasNew = new Chuas();
                chuasNew.capNhap = DateTime.UtcNow;
                chuasNew.diaChi = chuasDto.diaChi;
                chuasNew.tenChua = chuasDto.tenChua;
                chuasNew.ngayThanhLap = chuasDto.ngayThanhLap;
                appDbContext.Chuas.Add(chuasNew); 
                appDbContext.SaveChanges();
                return chuasNew;
            }
            return null;
        }

        public bool xoaChuas(int? id)
        {
            Chuas chuasDelete = appDbContext.Chuas.FirstOrDefault(x => x.chuaId == id);
            if (chuasDelete != null)
            {
                appDbContext.Chuas.Remove(chuasDelete);
                appDbContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public IQueryable<Chuas> layDsChua(string? tenchua, string? diachi)
        {
            var query = appDbContext.Chuas.AsQueryable();
            if (!string.IsNullOrEmpty(tenchua))
            {
                query = query.Where(x => x.tenChua.Contains(tenchua));
            }
            if(!string.IsNullOrEmpty(diachi))
            {
                query = query.Where(x => x.diaChi.Contains(diachi));
            }
            return query;
        }

    }
}
