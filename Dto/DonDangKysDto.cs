using System.ComponentModel.DataAnnotations;

namespace QuanLyPhanTuWeb.Dto
{
    public class DonDangKysDto
    {
        [Required(ErrorMessage ="bắt buộc nhập.")]
        public int? daoTrangId { get; set; }
    }
}
