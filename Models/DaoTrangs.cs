using System.ComponentModel.DataAnnotations;

namespace QuanLyPhanTuWeb.Models
{
    public class DaoTrangs
    {
        [Key]
        public int daoTrangId { get; set; }
        public Boolean daKetThuc { get; set; } = true;
        [Required(ErrorMessage = "vui lòng nhập nội dung")]
        public string? noiDung { get; set; }
        [Required(ErrorMessage = "vui lòng nhập nơi tổ chức")]
        public string? noiToChuc { get; set; }
        public int? soThanhVienThamGia { get; set; } = 0;
        [Required(ErrorMessage = "vui lòng nhập thời gian tổ chức")]
        public DateTime? thoiGianToChuc { get; set; }
        public int? phatTuId { get; set; }
        public PhanTu? PhatTu { get; set; }
    }
}
