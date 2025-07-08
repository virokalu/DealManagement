using DealManagement.Server.Domain.Models;

namespace DealManagement.Server.Domain.Repositories
{
    public interface IDealRepository
    {
        Task<IEnumerable<Deal>> ListAsync();
        Task AddAsync(Deal deal);
        Task<Deal?> FindBySlugAsync(string slug);
        Task<Deal?> FindByIdWithHotelsAsync(string slug);
        void Update(Deal deal);
        void Remove(Deal deal);
    }
}
