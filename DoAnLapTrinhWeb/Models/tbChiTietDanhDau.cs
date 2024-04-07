using Microsoft.AspNetCore.Identity;

namespace DoAnLapTrinhWeb.Models
{
    public class tbChiTietDanhDau
    {
        public int Id { get; set; }

        public int sachId { get; set; }
        public tbSach tbSach { get; set; }

        public int maLoaiDanhDau { get; set; }
        public tbLoaiDanhDau tbLoaiDanhDau { get; set; }

        public string userId { get; set; }

        public ApplicationUser User { get; set; }
    }
}
