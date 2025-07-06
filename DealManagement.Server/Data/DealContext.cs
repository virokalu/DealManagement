using DealManagement.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace DealManagement.Server.Data
{
    public class DealContext : DbContext
    {
        public DealContext(DbContextOptions<DealContext> options) 
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Deal>()
            .HasMany(o => o.Hotels)
            .WithOne(oi => oi.Deal)
            .HasForeignKey(oi => oi.DealSlug)
            .OnDelete(DeleteBehavior.Cascade); // This will delete the child record(s) when parent record is deleted
        }

        public DbSet<Deal> Deals { get; set; }
        public DbSet<Hotel> Hotels { get; set; }

    }
}
