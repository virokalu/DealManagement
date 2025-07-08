namespace DealManagement.Server.Resources
{
    public class GetDealResource : DealResource
    {
        public ICollection<HotelResource> Hotels { get; set; } = new List<HotelResource>();
    }
}
