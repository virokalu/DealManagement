using System.ComponentModel.DataAnnotations;

namespace DealManagement.Server.Models
{
    public class Deal
    {
        [Key]
        public required string Slug { get; set; }
        [Required]
        public required string Name { get; set; }
        public string Video { get; set; } = string.Empty;
        public ICollection<Hotel> Hotels { get; } = new List<Hotel>();
    }
}
