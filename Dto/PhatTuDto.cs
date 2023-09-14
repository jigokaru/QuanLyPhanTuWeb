using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace QuanLyPhanTuWeb.Dto
{
    public class PhatTuDto
    {
        public string? gioiTinh { get; set; }
        public string? ho { get; set; }
        public string? ten { get; set; }
        public string? tenDem { get; set; }
        public Boolean? daHoanTuc { get; set; }
        public DateTime? ngayHoanTuc { get; set; }
        public DateTime? ngayXuatGia { get; set; }
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? ngaySinh { get; set; }
        public string? phapDanh { get; set; }
        public int? soDienThoai { get; set; }
        public int? chuaId { get; set; }
        public int? kieuThanhVienId { get; set; }

       
    }
}
