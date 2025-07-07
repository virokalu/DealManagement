using DealManagement.Server.Domain.Models;
using DealManagement.Server.Domain.Services.Communication;

namespace DealManagement.Server.Domain.Services
{
    public interface IHotelService
    {
        Task<IEnumerable<Hotel>> ListAsync(string slug);
        Task<HotelResponse> SaveAsync(Hotel hotel);
        Task<HotelResponse> FindByIdAsync(int id);
        Task<HotelResponse> UpdateAsync(int id, Hotel hotel);
        Task<HotelResponse> DeleteAsync(int id);
    }
}
