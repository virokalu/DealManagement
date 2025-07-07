using DealManagement.Server.Domain.Models;
using DealManagement.Server.Domain.Services.Communication;

namespace DealManagement.Server.Domain.Services
{
    public interface IDealService
    {
        Task<IEnumerable<Deal>> ListAsync();
        Task<DealResponse> SaveAsync(Deal deal);
        Task<DealResponse> FindBySlugAsync(string slug);
        Task<DealResponse> UpdateAsync(string slug, Deal deal);
    }
}
