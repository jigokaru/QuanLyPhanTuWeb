using QuanLyPhanTuWeb.Models;

namespace QuanLyPhanTuWeb.Iservices
{
    public interface IChangePasswordServices
    {
        bool DoiMatKhau(string email, ChangePassword changePassword);
    }
}
