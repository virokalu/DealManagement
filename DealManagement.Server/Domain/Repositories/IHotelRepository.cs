using DealManagement.Server.Domain.Models;

namespace DealManagement.Server.Domain.Repositories
{
    public interface IHotelRepository
    {
        Task<IEnumerable<Hotel>> ListAsync(string slug);
        Task AddAsync(Hotel hotel);
        Task<Hotel?> FindByIdAsync(int id);
        Task<Hotel?> FindByIdWithDealAsync(int id);
        void Update(Hotel hotel);
        void Remove(Hotel hotel);
    }
}
