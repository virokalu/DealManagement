using DealManagement.Server.Persistence.Contexts;

namespace DealManagement.Server.Persistence.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly DealContext _context;
        protected BaseRepository(DealContext context)
        {
            _context = context;
        }
       
    }
}
