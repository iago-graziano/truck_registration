using Microsoft.EntityFrameworkCore;
using truck_register.Models;

namespace truck_register
{
    public class TruckContext : DbContext
    {
        public DbSet<Truck> Trucks { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "TruckDb");
        }
    }
}