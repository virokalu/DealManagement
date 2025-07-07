using System.ComponentModel;
using DealManagement.Server.Domain.Models;
using DealManagement.Server.Domain.Services.Communication;

namespace DealManagement.Server.Domain.Repositories
{
    public interface IDealRepository
    {
        Task<IEnumerable<Deal>> ListAsync();
        Task AddAsync(Deal deal);
    }
}
