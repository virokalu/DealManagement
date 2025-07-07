using DealManagement.Server.Domain.Models;

namespace DealManagement.Server.Domain.Repositories
{
    public interface IHotelRepository
    {
        Task<IEnumerable<Hotel>> ListAsync(int id);
        Task AddAsync(Hotel hotel);
        Task<Hotel?> FindByIdAsync(int id);
        void Update(Hotel hotel);
        void Remove(Hotel hotel);
    }
}
