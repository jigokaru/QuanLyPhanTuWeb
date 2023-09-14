using System.ComponentModel.DataAnnotations;

namespace QuanLyPhanTuWeb.Models
{
    public class DonDangKys
    {
        [Key]
        public int donDangkyId { get; set; }
        public DateTime ngayGuiDon { get; set; }
        public DateTime ngayXuLy { get; set; }
        public int nguoiXuLy { get; set; }
        public Boolean? trangThaiDon { get; set; } = null;
        public int? phatTuId { get; set; }
        public PhanTu? phatTu { get; set; }
        public int? daoTrangId { get; set; }
        public DaoTrangs? daoTrang { get; set; }
    }
}
