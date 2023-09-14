using QuanLyPhanTuWeb.Dto;
using QuanLyPhanTuWeb.Models;

namespace QuanLyPhanTuWeb.Iservices
{
    public interface IphatuServices
    {
        PhanTu ThemPhatTu(int? id, PhatTuDto phatTuDto);
        bool XoaPhanTu(int? id);
        IQueryable<PhanTu> LayDsPhatTu(string? ten,
                                                string? email,
                                                string? phapdanh,
                                                string? gioitinh,
                                                bool? isActive,
                                                string sortOrder = "desc"
                                       );
    }
}
