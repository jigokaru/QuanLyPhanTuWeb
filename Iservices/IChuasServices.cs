

using QuanLyPhanTuWeb.Dto;
using QuanLyPhanTuWeb.Models;

namespace QuanLyPhanTuWeb.Iservices
{
    public interface IChuasServices
    {
        Chuas themChuas(ChuasDto chuasDto);
        bool suaChuas(Chuas chuas);
        bool xoaChuas(int? id);
        IQueryable<Chuas> layDsChua(string? tenchua, string? diachi);
    }
}
