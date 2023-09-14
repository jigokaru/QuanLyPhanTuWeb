using Microsoft.AspNetCore.Mvc.ModelBinding;
using QuanLyPhanTuWeb.Iservices;
using QuanLyPhanTuWeb.Models;
using System.Text.RegularExpressions;

namespace QuanLyPhanTuWeb.Services
{
    public class LoginServices : ILoginServices
    {
        private readonly AppDbContext appDbContext;
        

        public LoginServices()
        {
            appDbContext = new AppDbContext();
            
        }

        

        public PhanTu dangNhap(Login login)
        {

            var user = appDbContext.PhanTu.FirstOrDefault(x => x.email == login.email);
            if (user != null)
            {
                if(login.password == null)
                {
                    return null;
                }
                if (BCrypt.Net.BCrypt.Verify(login.password, user.password))
                {
                    return user;
                }
                return null;
            }
            return null;

        }
    }
}
