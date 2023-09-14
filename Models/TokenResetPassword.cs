using System.ComponentModel.DataAnnotations;

namespace QuanLyPhanTuWeb.Models
{
    public class TokenResetPassword
    {
        [Key]
        public int? PasswordResetTokenId { get; set; }
        public string? emailToken { get; set; } = string.Empty;
        public string? PasswordResetToken { get; set; }
        public DateTime? ResetTokenExpires { get; set; }
        public int? phatTuId { get; set; }
        public PhanTu? PhatTu { get; set; }
    }
}
