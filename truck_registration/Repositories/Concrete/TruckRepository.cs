using Microsoft.EntityFrameworkCore;
using truck_registration.Models;
using truck_registration.Repositories.Interfaces;

namespace truck_registration.Repositories.Concrete
{
    public class TruckRepository : ITruckRepository
    {
        public TruckRepository()
        {
            using (var context = new TruckContext())
            {
                var trucks = new List<Truck>
                {
                    new Truck
                    {
                        Id = 1,
                        Modelo ="FH"
                    },
                    new Truck
                    {
                        Id = 2,
                        Modelo ="FM"
                    }
                };

                context.Trucks.AddRange(trucks);
                context.SaveChanges();
            }
        }

        public List<Truck> FetchAll()
        {
            using (var context = new TruckContext())
            {
                var list = context.Trucks
                    .ToList();
                return list;
            }
        }

        public Truck? GetById(long Id)
        {
            using (var context = new TruckContext())
            {
                return context.Trucks.SingleOrDefault(t => t.Id == Id);
            }
        }
    }
}