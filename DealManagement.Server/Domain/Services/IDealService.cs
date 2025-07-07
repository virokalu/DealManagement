using DealManagement.Server.Domain.Models;
using DealManagement.Server.Domain.Services.Communication;

namespace DealManagement.Server.Domain.Services
{
    public interface IDealService
    {
        Task<IEnumerable<Deal>> ListAsync();
        Task<SaveDealResponse> SaveAsync(Deal deal);
    }
}
