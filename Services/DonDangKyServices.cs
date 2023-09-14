﻿using Microsoft.EntityFrameworkCore;
using QuanLyPhanTuWeb.Dto;
using QuanLyPhanTuWeb.Iservices;
using QuanLyPhanTuWeb.Models;

namespace QuanLyPhanTuWeb.Services
{
    public class DonDangKyServices : IDonDangKyServices
    {
        private readonly AppDbContext appDbContext;

        public DonDangKyServices()
        {
            appDbContext = new AppDbContext();
        }

        public IQueryable<DonDangKys> donDangKyList(bool? trangThaiDon, string? tenPhatTu, DateTime? ngayGuiDon)
        {
            var query = appDbContext.DonDangKys.Include(x => x.phatTu).AsQueryable();

            if (trangThaiDon.HasValue)
            {
                query = query.Where(x => x.trangThaiDon == trangThaiDon);
            }

            if (!string.IsNullOrEmpty(tenPhatTu))
            {
                query = query.Where(x => x.phatTu != null && x.phatTu.ten.Contains(tenPhatTu));
            }

            if (ngayGuiDon.HasValue)
            {
                query = query.Where(x => x.ngayGuiDon == ngayGuiDon);
            }
            return query;
        }

        public DonDangKys duyetDon(int? PhatTuId, DuyetDon duyetDon)
        {
            DonDangKys donDangKys = appDbContext.DonDangKys.FirstOrDefault(x => x.donDangkyId == duyetDon.donDangkyId);
            DaoTrangs daoTrangs = appDbContext.DaoTrangs.FirstOrDefault(x => x.daoTrangId == donDangKys.daoTrangId);
            if (donDangKys != null)
            {
                donDangKys.ngayXuLy = DateTime.UtcNow;
                donDangKys.phatTuId = PhatTuId;
                donDangKys.trangThaiDon = duyetDon.trangThaiDon;
            }
            appDbContext.DonDangKys.Update(donDangKys);
            appDbContext.SaveChanges();
            if (donDangKys.trangThaiDon == true)
            {
                daoTrangs.soThanhVienThamGia += 1;

            }
            else
            {
                daoTrangs.soThanhVienThamGia -= 1;
            }
            appDbContext.DaoTrangs.Update(daoTrangs);
            appDbContext.SaveChanges();
            return donDangKys;
        }

        public DonDangKys themDonDangKys(int? PhatTuId, DonDangKysDto? donDangKysDto)
        {
            DaoTrangs daoTrangs = appDbContext.DaoTrangs.FirstOrDefault(x => x.daoTrangId == donDangKysDto.daoTrangId);
            if(daoTrangs != null)
            {
                var donDangKy = new DonDangKys
                {
                    phatTuId = PhatTuId,
                    daoTrangId = donDangKysDto.daoTrangId,
                    ngayGuiDon = DateTime.UtcNow
                };
                appDbContext.DonDangKys.Add(donDangKy);
                appDbContext.SaveChanges();
                return donDangKy;
            }
            return null;
        }

        public bool xoaDonDangKys(int donDangKyId)
        {
            DonDangKys donDangKysDelete = appDbContext.DonDangKys.FirstOrDefault(x => x.donDangkyId == donDangKyId);
            DaoTrangs daoTrangs = appDbContext.DaoTrangs.FirstOrDefault(x => x.daoTrangId == donDangKysDelete.daoTrangId);
            if (donDangKysDelete != null)
            {
                appDbContext.DonDangKys.Remove(donDangKysDelete);
                appDbContext.SaveChanges();
                
                daoTrangs.soThanhVienThamGia -= 1;
                appDbContext.DaoTrangs.Update(daoTrangs);
                appDbContext.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
