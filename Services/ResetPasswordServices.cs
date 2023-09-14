using QuanLyPhanTuWeb.Iservices;
using QuanLyPhanTuWeb.Models;

namespace QuanLyPhanTuWeb.Services
{
    public class ResetPasswordServices : IResetPasswordServices
    {
        private readonly AppDbContext appDbContext;
        private readonly Login login;

        public ResetPasswordServices()
        {
            appDbContext = new AppDbContext();
            login = new Login();
        }

        public string DatLaiMatKhau(ResetPassword resetPassword)
        {


            var tokenResetPassword = appDbContext.TokenResetPassword.FirstOrDefault(x => x.PasswordResetToken == resetPassword.token);
            
            if (tokenResetPassword == null )
            {
                return "Invalid Token.";
            }
            else
            {
                if (resetPassword.passwordHash == resetPassword.repasswordHash)
                {
                    var user = appDbContext.PhanTu.FirstOrDefault(x => x.email == tokenResetPassword.emailToken);
                    user.password = BCrypt.Net.BCrypt.HashPassword(resetPassword.passwordHash);
                    tokenResetPassword.PasswordResetToken = null;
                    tokenResetPassword.ResetTokenExpires = null;
                    appDbContext.TokenResetPassword.Update(tokenResetPassword);
                    appDbContext.PhanTu.Update(user);
                    appDbContext.SaveChanges();
                    return "doi mat khau thanh cong!";
                }
                else
                {
                    return "mat khau khong trung nhau!";
                }

            }
        }
    }
}
