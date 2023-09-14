using System.ComponentModel.DataAnnotations;

namespace QuanLyPhanTuWeb.Models
{
    public class Chuas
    {
        [Key]
        public int? chuaId { get; set; }
        public DateTime? capNhap { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập địa chỉ.")]
        public string? diaChi { get; set; }
        public DateTime? ngayThanhLap { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập tên chùa")]
        public string? tenChua { get; set; }
    }
}
