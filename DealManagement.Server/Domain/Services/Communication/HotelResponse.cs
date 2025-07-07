using DealManagement.Server.Domain.Models;

namespace DealManagement.Server.Domain.Services.Communication
{
    public class HotelResponse : BaseResponse
    {
        public Hotel Hotel { get; private set; }
        private HotelResponse(bool success, string message, Hotel hotel) : base(success, message)
        {
            Hotel = hotel;
        }
        public HotelResponse(string message) : this(false, message, null!)
        {
        }
        public HotelResponse(Hotel hotel) : this(true, string.Empty, hotel)
        {
        }
    }
}
