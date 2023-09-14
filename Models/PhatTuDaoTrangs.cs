
using System.ComponentModel.DataAnnotations;

namespace QuanLyPhanTuWeb.Models
{
    public class PhatTuDaoTrangs
    {
        [Key]
        public int phatTuDaoTrangId { get; set; }
        public Boolean daThamGia { get; set; }
        public string lyDoKhongThamGia { get; set; }
        public int? daoTrangId { get; set; }
        public DaoTrangs? daoTrang { get; set; }
        public int? phatTuId { get; set; }
        public PhanTu? phatTu { get; set; }
    }
}
