using Microsoft.EntityFrameworkCore;

namespace QuanLyPhanTuWeb.Models
{
    public class AppDbContext : DbContext
    {
        public virtual DbSet<PhanTu> PhanTu { get; set; }
        public virtual DbSet<Chuas> Chuas { get; set; }
        public virtual DbSet<PhatTuDaoTrangs> PhatTuDaoTrangs { get; set; }
        public virtual DbSet<DaoTrangs> DaoTrangs { get; set; }
        public virtual DbSet<DonDangKys> DonDangKys { get; set; }
        public virtual DbSet<Token> Token { get; set; }
        public virtual DbSet<KieuThanhViens> KieuThanhViens { get; set; }
        public virtual DbSet<TokenResetPassword> TokenResetPassword { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer($"server = DESKTOP-OIAL4C8; database = QuanLyPhanTuWeb; trusted_connection = true; trustservercertificate = true");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            for (int i = 21; i < 40; i++)
            {
                modelBuilder.Entity<PhanTu>().HasData(
                    new PhanTu
                    {
                        phatTuId = i,
                        ten = $"phat tu {i}"

                    });
            }
        }
    }
}
