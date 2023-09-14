using Org.BouncyCastle.Crypto.Generators;
using QuanLyPhanTuWeb.Iservices;
using QuanLyPhanTuWeb.Models;
using System.Text.RegularExpressions;

namespace QuanLyPhanTuWeb.Services
{
    public class RegisterServices : IRegisterSevices
    {
        private readonly AppDbContext appDbContext;

        public RegisterServices()
        {
            appDbContext = new AppDbContext();
        }

        public static bool IsValidEmail(string email)
        {

            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", RegexOptions.IgnoreCase);
            return regex.IsMatch(email);
        }

        public string dangKy(Register register)
        {
            bool isValidEmail = IsValidEmail(register.email);
            PhanTu phanTu = appDbContext.PhanTu.FirstOrDefault(x => x.email == register.email);
            TokenResetPassword tokenResetPassword = appDbContext.TokenResetPassword.FirstOrDefault(x => x.emailToken == register.email);
            if (phanTu != null)
            {
                
                return "email da ton tai";
            }
            else
            {
                if(isValidEmail == true)
                {
                    if(register.passwordHash.Length == 0 || register.repasswordHash.Length == 0)
                    {
                        
                        return "khong duoc de trong mat khau!";
                    }
                    else
                    {
                        if(register.passwordHash == register.repasswordHash)
                        {
                            PhanTu phanTuNew = new PhanTu();
                            phanTuNew.email = register.email;
                            phanTuNew.password = BCrypt.Net.BCrypt.HashPassword(register.passwordHash);
                            phanTuNew.Role = "ADMIN";
                            appDbContext.PhanTu.Add(phanTuNew);
                            appDbContext.SaveChanges();
                            if (tokenResetPassword == null)
                            {
                                TokenResetPassword tokenResetPasswordNew = new TokenResetPassword();
                                tokenResetPasswordNew.emailToken = phanTuNew.email;
                                tokenResetPasswordNew.phatTuId = phanTuNew.phatTuId;
                                appDbContext.TokenResetPassword.Add(tokenResetPasswordNew);
                            }
                            appDbContext.SaveChanges();
                            return "dang ky thanh cong";
                        }
                        else
                        {
                            return "mat khau khong trung nhau";
                        }
                    }
                }
                else
                {
                    return "email sai";
                }
            }
        }
    }
}
