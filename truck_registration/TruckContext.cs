using Microsoft.EntityFrameworkCore;
using truck_registration.Models;

namespace truck_registration
{
    public class TruckContext : DbContext
    {
        public DbSet<Truck> Truck { get; set; }
        public TruckContext(DbContextOptions<TruckContext> options) : base(options)
        {
        }
    }
}