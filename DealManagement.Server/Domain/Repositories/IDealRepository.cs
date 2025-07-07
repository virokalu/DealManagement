using DealManagement.Server.Domain.Models;

namespace DealManagement.Server.Domain.Repositories
{
    public interface IDealRepository
    {
        Task<IEnumerable<Deal>> ListAsync();
    }
}
