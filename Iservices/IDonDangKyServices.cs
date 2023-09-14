
using QuanLyPhanTuWeb.Dto;
using QuanLyPhanTuWeb.Models;

namespace QuanLyPhanTuWeb.Iservices
{
    public interface IDonDangKyServices
    {
        DonDangKys themDonDangKys(int? PhatTuId, DonDangKysDto? donDangKysDto);
        DonDangKys duyetDon(int? PhatTuId, DuyetDon duyetDon);
        bool xoaDonDangKys(int donDangKyId);
        IQueryable<DonDangKys> donDangKyList(Boolean? trangThaiDon, string? tenPhatTu, DateTime? ngayGuiDon);
    }
}
