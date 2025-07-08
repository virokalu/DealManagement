using System.ComponentModel.DataAnnotations.Schema;

namespace DealManagement.Server.Domain.Models
{
    public class Hotel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Rate { get; set; }
        public string Amenities { get; set; } = string.Empty;
        [ForeignKey("Deal")]
        public string DealSlug { get; set; } = string.Empty;
        public Deal Deal { get; set; } = null!;
    }
}