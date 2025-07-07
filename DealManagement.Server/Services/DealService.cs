using DealManagement.Server.Domain.Models;
using DealManagement.Server.Domain.Repositories;
using DealManagement.Server.Domain.Services;

namespace DealManagement.Server.Services
{
    public class DealService : IDealService
    {
        private readonly IDealRepository _dealRepository; 
        public DealService(IDealRepository dealRepository)
        {
            _dealRepository = dealRepository;
        }
        public Task<IEnumerable<Deal>> ListAsync()
        {
            return _dealRepository.ListAsync();
        }
    }
}
