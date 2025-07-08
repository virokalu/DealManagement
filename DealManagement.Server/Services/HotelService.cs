using DealManagement.Server.Domain.Models;
using DealManagement.Server.Domain.Repositories;
using DealManagement.Server.Domain.Services;
using DealManagement.Server.Domain.Services.Communication;

namespace DealManagement.Server.Services
{
    public class HotelService : IHotelService
    {
        private readonly IHotelRepository _hotelRepository;
        private readonly IUnitOfWork _unitOfWork;

        public HotelService(IHotelRepository hotelRepository, IUnitOfWork unitOfWork)
        {
            _hotelRepository = hotelRepository;
            _unitOfWork = unitOfWork;
        }
        public Task<IEnumerable<Hotel>> ListAsync(string slug)
        {
            return _hotelRepository.ListAsync(slug);
        }
        public async Task<HotelResponse> SaveAsync(Hotel hotel)
        {
            try
            {
                await _hotelRepository.AddAsync(hotel);
                await _unitOfWork.CompleteAsync();
                return new HotelResponse(hotel);
            }
            catch (Exception ex)
            {
                return new HotelResponse(ex.Message);
            }
        }
        public Task<HotelResponse> FindByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
        public async Task<HotelResponse> UpdateAsync(int id, Hotel hotel)
        {
            var existingHotel = await _hotelRepository.FindByIdAsync(id);
            if (existingHotel == null)
            {
                return new HotelResponse("Hotel not found.");
            }
            try
            {
                existingHotel.Name = hotel.Name;
                existingHotel.Rate = hotel.Rate;
                existingHotel.Amenities = hotel.Amenities;

                _hotelRepository.Update(existingHotel);
                await _unitOfWork.CompleteAsync();
                return new HotelResponse(existingHotel);
            }
            catch (Exception ex)
            {
                return new HotelResponse(ex.Message);
            }
        }
        public async Task<HotelResponse> DeleteAsync(int id)
        {
            var hotel = await _hotelRepository.FindByIdWithDealAsync(id);
            if (hotel == null)
            {
                return new HotelResponse("Hotel not found.");
            }
            var deal = hotel.Deal;
            if (deal == null || deal.Hotels.Count <= 1) 
            {
                return new HotelResponse("Cannot delete the only hotel in a deal");
            }
            try
            {
                _hotelRepository.Remove(hotel);
                await _unitOfWork.CompleteAsync();

                return new HotelResponse(hotel);
            }
            catch (Exception ex)
            {
                return new HotelResponse(ex.Message);
            }
        }
    }
}
