using Microsoft.EntityFrameworkCore;
using truck_registration.Models;

namespace truck_registration
{
    public class TruckContext : DbContext
    {
        public DbSet<Truck> Trucks { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "AuthorDb");
        }
    }
}