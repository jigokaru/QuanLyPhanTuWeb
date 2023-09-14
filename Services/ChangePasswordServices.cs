using Microsoft.EntityFrameworkCore;
using QuanLyPhanTuWeb.Iservices;
using QuanLyPhanTuWeb.Models;

namespace QuanLyPhanTuWeb.Services
{
    public class ChangePasswordServices : IChangePasswordServices
    {
        private readonly AppDbContext appDbContext;

        public ChangePasswordServices()
        {
            appDbContext = new AppDbContext();
        }

        public bool DoiMatKhau(string email ,ChangePassword changePassword)
        {
            var user = appDbContext.PhanTu.FirstOrDefault(x => x.email == email);

            if (user == null)
            {
                return false;
            }

            if (changePassword.oldPasswordHash != user.password)
            {
                return false;
            }

            if(changePassword.passwordHash == changePassword.repasswordHash)
            {
                user.password = changePassword.repasswordHash;
                appDbContext.PhanTu.Update(user);
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
