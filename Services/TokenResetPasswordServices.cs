using QuanLyPhanTuWeb.Iservices;
using QuanLyPhanTuWeb.Models;

namespace QuanLyPhanTuWeb.Services
{
    public class TokenResetPasswordServices : ITokenResetPasswordServices
    {
        private readonly AppDbContext appDbContext;

        public TokenResetPasswordServices()
        {
            appDbContext = new AppDbContext();
        }

        public TokenResetPassword ThemToken(TokenResetPassword tokenResetPassword)
        {
            TokenResetPassword tokenResetPassword1 = appDbContext.TokenResetPassword.FirstOrDefault(x =>  x.emailToken == tokenResetPassword.emailToken);
            if (tokenResetPassword1 != null)
            {
                appDbContext.TokenResetPassword.Update(tokenResetPassword1);
                appDbContext.SaveChanges();
                
            }
            return tokenResetPassword1;
        }
            
    }
}
