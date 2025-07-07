using DealManagement.Server.Domain.Models;

namespace DealManagement.Server.Domain.Services
{
    public interface IDealService
    {
        Task<IEnumerable<Deal>> ListAsync();
    }
}
