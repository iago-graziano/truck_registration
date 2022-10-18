using Microsoft.EntityFrameworkCore;
using truck_register.Models;
using truck_register.Repositories.Interfaces;

namespace truck_register.Repositories.Concrete
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
                        Modelo = "FH",
                        AnoFabricacao = "2022",
                        AnoModelo = "2023"
                    },
                    new Truck
                    {
                        Id = 2,
                        Modelo ="FM",
                        AnoFabricacao = "2022",
                        AnoModelo = "2022"
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