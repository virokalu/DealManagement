using DealManagement.Server.Domain.Repositories;
using DealManagement.Server.Persistence.Contexts;

namespace DealManagement.Server.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DealContext _context;
        public UnitOfWork(DealContext context)
        {
            _context = context;
        }
        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
