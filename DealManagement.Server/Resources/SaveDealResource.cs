namespace DealManagement.Server.Resources
{
    public class SaveDealResource : DealResource
    {
        public ICollection<SaveHotelResource> Hotels { get; set; } = new List<SaveHotelResource>();
    }
}
