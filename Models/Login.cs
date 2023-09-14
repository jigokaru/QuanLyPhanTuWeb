using System.ComponentModel.DataAnnotations;

namespace QuanLyPhanTuWeb.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Vui lòng nhập tên đăng nhập.")]
        public string email { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập mật khẩu.")]
        public string password { get; set; }
    }
}
