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

        public async Task<DealResponse> FindBySlugAsync(string slug)
        {
            var deal = await _dealRepository.FindBySlugAsync(slug);
            if (deal == null)
            {
                return new DealResponse("Deal not found.");
            }

            return new DealResponse(deal);
        }

        public Task<IEnumerable<Deal>> ListAsync()
        {
            return _dealRepository.ListAsync();
        }

        public async Task<DealResponse> SaveAsync(Deal deal)
        {
            var slugDeal = await _dealRepository.FindBySlugAsync(deal.Slug);

            // Check if the slug already exists for a different deal
            if (slugDeal != null)
            {
                return new DealResponse("Slug already exists.");
            }

            try
            {
                await _dealRepository.AddAsync(deal);
                await _unitOfWork.CompleteAsync();
                return new DealResponse(deal);
            }
            catch (Exception ex)
            {
                return new DealResponse($"{ex.Message}");
            }
        }

        public async Task<DealResponse> UpdateAsync(string slug, Deal deal)
        {
            var existingDeal = await _dealRepository.FindBySlugAsync(slug); 
            if (existingDeal == null)
            {
                return new DealResponse("Deal not found.");
            }

            var slugDeal = await _dealRepository.FindBySlugAsync(deal.Slug);

            // Check if the slug already exists for a different deal
            if (slugDeal != null && slugDeal.Slug != existingDeal.Slug)
            {
                return new DealResponse("Slug already exists.");
            }

            try
            {
                existingDeal.Name = deal.Name;
                existingDeal.Slug = deal.Slug;
                existingDeal.Video = deal.Video;

                // TODO: Update other properties as needed

                _dealRepository.Update(existingDeal);
                await _unitOfWork.CompleteAsync();
                return new DealResponse(existingDeal);
            }
            catch (Exception ex)
            {
                return new DealResponse(ex.Message);
            }
        }
    }
}
