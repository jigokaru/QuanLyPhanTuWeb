using System.ComponentModel.DataAnnotations;

namespace QuanLyPhanTuWeb.Models
{
    public class PhanTu
    {
        [Key]
        public int? phatTuId { get; set; }
        public string? anhChup { get; set; }
        public Boolean? daHoanTuc { get; set; }
        public string? email { get; set; } = string.Empty;
        public string? gioiTinh { get; set; }
        public string? ho { get; set; }
        public string? ten { get; set; }
        public string? tenDem { get; set; }
        public DateTime? ngayCapNhap { get; set; }
        public DateTime? ngayHoanTuc { get; set; }
        public DateTime? ngayXuatGia { get; set; }
        public DateTime? ngaySinh { get; set; } 
        public string? phapDanh { get; set; }
        public string? password { get; set; } = string.Empty;
        public int? soDienThoai { get; set; }
        public int? chuaId { get; set; }
        public Chuas? chua { get; set; }
        public IEnumerable<DaoTrangs>? DaoTrang { get; set; }
        public int? kieuThanhVienId { get; set; }
        public KieuThanhViens? kieuThanhVien { get; set; }
        public string? Role { get; set; } = "ADMIN";
        public bool isActive { get; set; } = true;
    }
}
