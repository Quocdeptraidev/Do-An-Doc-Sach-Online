using System.ComponentModel.DataAnnotations;

namespace DoAnLapTrinhWeb.Models
{
    public class tbTheLoai
    {
        [Key]
        public int TheLoaiId { get; set; }

        public string tenTheLoai { get; set;  }

        public List<tbChiTietTheLoai> chiTietTheLoais { get; set; }
}
}
