using System.ComponentModel.DataAnnotations;

namespace DoAnLapTrinhWeb.Models
{
    public class tbSach
    {
        [Key]
        public int sachId { get; set; }

        [Required, StringLength(100)]
        public string? tenSach { get; set; }

        public string? fileUrl { get; set; }

        public string? imageUrl { get; set; }
        public int TheLoaiId { get; set; }
        public tbTheLoai TheLoai { get; set; }
        public int TacGiaId { get; set; }
        public tbTacGia TacGia { get; set; }

        public List<tbChiTietTheLoai> chiTietTheLoais { get; set; }

        public List<tbChiTietDanhDau> chiTietDanhDaus { get; set; }

        public List<tbLichSu> lichSus { get; set; }

        public List<tbPhieuDanhGia> phieuDanhGias { get; set; }
    }
}
