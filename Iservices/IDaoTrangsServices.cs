
using QuanLyPhanTuWeb.Dto;
using QuanLyPhanTuWeb.Models;

namespace QuanLyPhanTuWeb.Iservices
{
    public interface IDaoTrangsServices
    {
        DaoTrangs themDaoTrangs(int? id, DaoTrangsDto daoTrangsDto);
        bool suaDaoTrangs(DaoTrangs daoTrangs);
        bool xoaDaoTrangs(int DaoTrangsId);
        IQueryable<DaoTrangs> layDsDaoTrangs(Boolean? daKetThuc, string? noiToChuc, DateTime? thoiGianToChuc);
    }
}
