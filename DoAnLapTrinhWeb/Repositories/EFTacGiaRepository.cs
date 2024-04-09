using Microsoft.EntityFrameworkCore;
using DoAnLapTrinhWeb.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DoAnLapTrinhWeb.Repositories
{
    public class EFTacGiaRepository : ITacGiaRepository // Thay thế ITacGiaRepository bằng interface tương ứng
    {
        private readonly ApplicationDbContext _context;

        public EFTacGiaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<tbTacGia>> GetAllAsync()
        {
            return await _context.tbTacGia.ToListAsync();
        }

        public async Task<tbTacGia> GetByIdAsync(int id)
        {
            return await _context.tbTacGia.FindAsync(id);
        }

        public async Task AddAsync(tbTacGia tacGia)
        {
            _context.tbTacGia.Add(tacGia);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(tbTacGia tacGia)
        {
            _context.tbTacGia.Update(tacGia);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var tacGia = await _context.tbTacGia.FindAsync(id);
            _context.tbTacGia.Remove(tacGia);
            await _context.SaveChangesAsync();
        }
    }
}
