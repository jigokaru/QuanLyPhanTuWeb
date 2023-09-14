using System.ComponentModel.DataAnnotations;

namespace QuanLyPhanTuWeb.Dto
{
    public class ChuasDto
    {
        [Required(ErrorMessage ="Vui lòng nhập địa chỉ.")]
        public string? diaChi { get; set; }
        public DateTime? ngayThanhLap { get; set; }
        [Required(ErrorMessage ="Vui lòng nhập tên chùa")]
        public string? tenChua { get; set; }
    }
}
