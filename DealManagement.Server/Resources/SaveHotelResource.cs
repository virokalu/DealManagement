namespace DealManagement.Server.Resources
{
    public class SaveHotelResource
    {
        public string Name { get; set; } = string.Empty;
        public decimal Rate { get; set; }
        public string Amenities { get; set; } = string.Empty;
        public string DealSlug { get; set; } = string.Empty;
    }
}
