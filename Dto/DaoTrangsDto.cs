using System.ComponentModel.DataAnnotations;

namespace QuanLyPhanTuWeb.Dto
{
    public class DaoTrangsDto
    {
        public Boolean? daKetThuc { get; set; }
        [Required(ErrorMessage ="vui lòng nhập nội dung")]
        public string? noiDung { get; set; }
        [Required(ErrorMessage = "vui lòng nhập nơi tổ chức")]
        public string? noiToChuc { get; set; }
        [Required(ErrorMessage ="vui lòng nhập thời gian tổ chức")]
        public DateTime? thoiGianToChuc { get; set; }
    }
}
