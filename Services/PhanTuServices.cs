using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using QuanLyPhanTuWeb.Dto;
using QuanLyPhanTuWeb.Iservices;
using QuanLyPhanTuWeb.Models;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace QuanLyPhanTuWeb.Services
{
    public class PhanTuServices : IphatuServices
    {
        private readonly AppDbContext appDbContext;

        public PhanTuServices()
        {
            appDbContext = new AppDbContext();
        }

        [Authorize(Roles ="ADMIN")]
        public IQueryable<PhanTu> LayDsPhatTu(string? ten, 
                                                string? email, 
                                                string? phapdanh,
                                                string? gioitinh,
                                                bool? isActive,
                                                string sortOrder = "desc"
                                                )
        {
            
            var query = appDbContext.PhanTu.Include(x => x.DaoTrang).AsQueryable();
            if(sortOrder == "asc")
            {
                query = query.OrderBy(x => x.ten);
            }
            if (sortOrder == "desc")
            {
                query = query.OrderByDescending(x => x.ten);
            }

            if(!string.IsNullOrEmpty(ten))
            {
                query = query.Where(x => x.ten.Contains(ten.ToLower().Trim()));
            }
           
            if (!string.IsNullOrEmpty(email))
            {
                query = query.Where(x => x.email.Contains(email.ToLower()));
            }

            if (!string.IsNullOrEmpty(phapdanh))
            {
                query = query.Where(x => x.phapDanh.Contains(phapdanh.ToLower()));
                
            }
            if (!string.IsNullOrEmpty(gioitinh))
            {
                query = query.Where(x => x.gioiTinh == gioitinh);
            }
            if (isActive.HasValue)
            {
                query = query.Where(x => x.isActive == isActive);
            }
            return query;
        }

        public PhanTu ThemPhatTu(int? id, PhatTuDto phatTuDto)
        {
            PhanTu phanTuUpdate = appDbContext.PhanTu.FirstOrDefault(x => x.phatTuId == id);
            if(phanTuUpdate != null)
            {
                phanTuUpdate.ten = phatTuDto.ten;
                phanTuUpdate.ho = phatTuDto.ho;
                phanTuUpdate.tenDem = phatTuDto.tenDem;
                phanTuUpdate.phapDanh = phatTuDto.phapDanh;
                phanTuUpdate.ngaySinh =  phatTuDto.ngaySinh;
                phanTuUpdate.gioiTinh = phatTuDto.gioiTinh;
                phanTuUpdate.ngayXuatGia = phanTuUpdate.ngayXuatGia;
                phanTuUpdate.ngayCapNhap = DateTime.UtcNow;
                phanTuUpdate.soDienThoai = phatTuDto.soDienThoai;
                appDbContext.PhanTu.Update(phanTuUpdate);
                appDbContext.SaveChanges();
                return phanTuUpdate;
            }
            return null;
        }

        public bool XoaPhanTu(int? id)
        {
            PhanTu phanTuRemove = appDbContext.PhanTu.FirstOrDefault(x => x.phatTuId == id);
            if(phanTuRemove != null )
            {
                phanTuRemove.isActive = false;
                appDbContext.PhanTu.Update(phanTuRemove);
                appDbContext.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
