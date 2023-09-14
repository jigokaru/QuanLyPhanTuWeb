using QuanLyPhanTuWeb.Models;

namespace QuanLyPhanTuWeb.Iservices
{
    public interface ITokenResetPasswordServices
    {
        TokenResetPassword ThemToken(TokenResetPassword tokenResetPassword);
    }
}
