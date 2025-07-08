using DealManagement.Server.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DealManagement.Server.Persistence.Contexts
{
    public class DealContext : DbContext
    {
        public DealContext(DbContextOptions<DealContext> options) 
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Deal>()
            .HasMany(ob => ob.Hotels)
            .WithOne(ob => ob.Deal)
            .HasForeignKey(ob => ob.DealSlug)
            .OnDelete(DeleteBehavior.Cascade); // This will delete the child record(s) when parent record is deleted

            // Seed Deals
            modelBuilder.Entity<Deal>().HasData(
                new Deal { Name = "Summer Getaway", Slug = "summer-getaway", Video = "https://example.com/video1" },
                new Deal { Name = "Winter Retreat", Slug = "winter-retreat", Video = "https://example.com/video2" }
            );

            // Seed Hotels
            modelBuilder.Entity<Hotel>().HasData(
                new Hotel { Id = 1, Name = "Palm Beach Resort", Rate = 4.5m, Amenities = "Pool,WiFi,Breakfast", DealSlug = "summer-getaway" },
                new Hotel { Id = 2, Name = "Oceanview Inn", Rate = 4.2m, Amenities = "WiFi,Parking,Gym", DealSlug = "summer-getaway" },
                new Hotel { Id = 3, Name = "Snow Lodge", Rate = 4.7m, Amenities = "Sauna,Fireplace,Bar", DealSlug = "winter-retreat" }
            );

        }

        public DbSet<Deal> Deals { get; set; }
        public DbSet<Hotel> Hotels { get; set; }

    }
}
