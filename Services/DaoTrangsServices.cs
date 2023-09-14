using QuanLyPhanTuWeb.Dto;
using QuanLyPhanTuWeb.Iservices;
using QuanLyPhanTuWeb.Models;

namespace QuanLyPhanTuWeb.Services
{
    public class DaoTrangsServices : IDaoTrangsServices
    {
        private readonly AppDbContext appDbContext;

        public DaoTrangsServices()
        {
            appDbContext = new AppDbContext();
        }

        public IQueryable<DaoTrangs> layDsDaoTrangs(bool? daKetThuc, string? noiToChuc, DateTime? thoiGianToChuc)
        {
            var query = appDbContext.DaoTrangs.AsQueryable();
            if(daKetThuc.HasValue)
            {
                query = query.Where(x => x.daKetThuc == daKetThuc);
            }
            if (!string.IsNullOrEmpty(noiToChuc))
            {
                query = query.Where(x => x.noiToChuc.Contains(noiToChuc));
            }
            if (thoiGianToChuc.HasValue)
            {
                query = query.Where(x => x.thoiGianToChuc == thoiGianToChuc);
            }
            
            return query;
        }

        public bool suaDaoTrangs(DaoTrangs daoTrangs)
        {
            DaoTrangs daoTrangsUpdate = appDbContext.DaoTrangs.FirstOrDefault(x => x.daoTrangId == daoTrangs.daoTrangId);
            if (daoTrangsUpdate != null)
            {
                daoTrangsUpdate.daKetThuc = daoTrangs.daKetThuc;
                daoTrangsUpdate.thoiGianToChuc = daoTrangs.thoiGianToChuc;
                daoTrangsUpdate.noiDung = daoTrangs.noiDung;
                daoTrangsUpdate.noiToChuc = daoTrangs.noiToChuc;
                appDbContext.DaoTrangs.Update(daoTrangsUpdate);
                appDbContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public DaoTrangs themDaoTrangs(int? id, DaoTrangsDto daoTrangsDto)
        {
            PhanTu phanTu = appDbContext.PhanTu.FirstOrDefault(x => x.phatTuId == id && x.isActive == true);
            if(phanTu != null)
            {
                DaoTrangs daoTrangsNew = new DaoTrangs();
                daoTrangsNew.noiDung = daoTrangsDto.noiDung;
                daoTrangsNew.noiToChuc = daoTrangsDto.noiToChuc;
                daoTrangsNew.thoiGianToChuc = daoTrangsDto.thoiGianToChuc;
                daoTrangsNew.phatTuId = id;
                appDbContext.DaoTrangs.Add(daoTrangsNew);
                appDbContext.SaveChanges();
                return daoTrangsNew;
            }

            return null;
        }

        public bool xoaDaoTrangs(int DaoTrangsId)
        {
            DaoTrangs daoTrangsDelete = appDbContext.DaoTrangs.FirstOrDefault(x => x.daoTrangId == DaoTrangsId);
            if (daoTrangsDelete != null)
            {
                appDbContext.DaoTrangs.Remove(daoTrangsDelete);
                appDbContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        

        
    }
}
