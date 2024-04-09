using DoAnLapTrinhWeb.Models;
using System.Collections;

namespace DoAnLapTrinhWeb.Repositories
{
    public interface ITheLoaiRepository
    {
        Task<IEnumerable<tbTheLoai>> GetAllAsync();
        Task<tbTheLoai> GetByIdAsync(int id);
        Task AddAsync(tbTheLoai theLoai);
        Task UpdateAsync(tbTheLoai theLoai);
        Task DeleteAsync(int id);
    }
}
