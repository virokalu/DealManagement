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
            if(DealExists(deal.Slug))
            {
                throw new Exception($"'{deal.Slug}' already exists.");
            }
            await _context.Deals.AddAsync(deal);
        }
        private bool DealExists(string id)
        {
            return _context.Deals.Any(e => e.Slug == id);
        }
    }
}
