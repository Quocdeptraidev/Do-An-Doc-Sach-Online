using Microsoft.AspNetCore.Identity;

namespace DoAnLapTrinhWeb.Models
{
    public class tbChiTietTheLoai
    {
        public int Id { get; set; }

        public int sachId { get; set; }

        public tbSach? tbSach { get; set; }

        public int maTheLoai { get; set; }

        public tbTheLoai? tbTheLoai { get; set; }
    }
}
