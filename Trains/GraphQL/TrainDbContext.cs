using GraphQL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
namespace GraphQL
{
    public class TrainDbContext:DbContext
    {
        public TrainDbContext(DbContextOptions options) : base(options)
        { }

 
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<Train> Trains { get; set; }
        public DbSet<Carriage> Carriages { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.Train)
                .WithMany(t => t.Tickets)
                .HasForeignKey(t => t.TrainId)
                .OnDelete(DeleteBehavior.Cascade); // Каскадное удаление, если поезд удален

            // Указываем точность и масштаб для столбца Price
            modelBuilder.Entity<Seat>()
                .Property(s => s.Price)
                .HasPrecision(18, 2);  // Точность 18 и масштаб 2
        }
    }
}
