using DealManagement.Server.Domain.Models;
using DealManagement.Server.Domain.Repositories;
using DealManagement.Server.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace DealManagement.Server.Persistence.Repositories
{
    public class HotelRepository : BaseRepository, IHotelRepository
    {
        public HotelRepository(DealContext context) : base(context)
        {
        }
        public async Task<IEnumerable<Hotel>> ListAsync(string slug)
        {
            return await _context.Hotels.Where(h => h.DealSlug == slug).ToListAsync();
        }
        public async Task AddAsync(Hotel hotel)
        {
            await _context.Hotels.AddAsync(hotel);
        }
        public async Task<Hotel?> FindByIdAsync(int id)
        {
            return await _context.Hotels.FindAsync(id);
        }
        public void Update(Hotel hotel)
        {
            _context.Hotels.Update(hotel);
        }
        public void Remove(Hotel hotel)
        {
            _context.Hotels.Remove(hotel);
        }

        public async Task<Hotel?> FindByIdWithDealAsync(int id)
        {
            return await _context.Hotels
                .Include(h => h.Deal)
                .ThenInclude(d => d.Hotels)
                .FirstOrDefaultAsync(h => h.Id == id);
        }
    }
}
