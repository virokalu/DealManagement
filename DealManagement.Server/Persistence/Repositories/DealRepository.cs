using DealManagement.Server.Domain.Models;
using DealManagement.Server.Domain.Repositories;
using DealManagement.Server.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace DealManagement.Server.Persistence.Repositories
{
    public class DealRepository : BaseRepository, IDealRepository
    {
        public DealRepository(DealContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Deal>> ListAsync()
        {
            return await _context.Deals.ToListAsync();
        }

        public async Task AddAsync(Deal deal)
        {
            await _context.Deals.AddAsync(deal);
        }

        public async Task<Deal?> FindBySlugAsync(string slug)
        {
            return await _context.Deals.FindAsync(slug);
        }

        public void Update(Deal deal)
        {
            _context.Deals.Update(deal);
        }
    }
}
