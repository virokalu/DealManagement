using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DealManagement.Server.Models
{
    public class Hotel
    {
        public int Id { get; set; }
        [Required]
        public required string Name { get; set; }
        [Range(1.0, 5.0)]
        [Column(TypeName = "decimal(2,1)")]
        public decimal Rate { get; set; }

        public string Amenities { get; set; } = string.Empty;
        [ForeignKey("Deal")]
        public required string DealSlug { get; set; }
        public Deal Deal { get; set; } = null!;
    }
}
