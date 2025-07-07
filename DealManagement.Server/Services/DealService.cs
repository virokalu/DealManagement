using DealManagement.Server.Domain.Models;
using DealManagement.Server.Domain.Repositories;
using DealManagement.Server.Domain.Services;
using DealManagement.Server.Domain.Services.Communication;

namespace DealManagement.Server.Services
{
    public class DealService : IDealService
    {
        private readonly IDealRepository _dealRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DealService(IDealRepository dealRepository, IUnitOfWork unitOfWork)
        {
            _dealRepository = dealRepository;
            _unitOfWork = unitOfWork;
        }
        public Task<IEnumerable<Deal>> ListAsync()
        {
            return _dealRepository.ListAsync();
        }

        public async Task<SaveDealResponse> SaveAsync(Deal deal)
        {
            try
            {
                await _dealRepository.AddAsync(deal);
                await _unitOfWork.CompleteAsync();
                return new SaveDealResponse(deal);
            }
            catch (Exception ex)
            {
                return new SaveDealResponse(ex.Message);
            }
        }
    }
}
