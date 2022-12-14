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
                if (context.Trucks.Any())
                    return;

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
                    },
                    new Truck
                    {
                        Id = 3,
                        Modelo ="FH",
                        AnoFabricacao = "2022",
                        AnoModelo = "2022"
                    }
                };

                context.Trucks.AddRange(trucks);
                context.SaveChanges();
            }
        }

        public void Delete(Truck Truck)
        {
            using (var context = new TruckContext())
            {
                context.Trucks.Remove(Truck);
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

        public Truck Insert(Truck Truck)
        {
            using (var context = new TruckContext())
            {
                IsTruckModelValid(Truck);
                Truck = context.Trucks.Add(Truck).Entity;
                context.SaveChanges();
                return Truck;
            }
        }

        public Truck Update(Truck Truck)
        {
            using (var context = new TruckContext())
            {
                IsTruckModelValid(Truck);
                Truck = context.Trucks.Update(Truck).Entity;
                context.SaveChanges();
                return Truck;
            }
        }

        private void IsTruckModelValid(Truck truck)
        {
            var currentYear = DateTime.Now.Year;
            if (Convert.ToInt32(truck.AnoFabricacao) != currentYear)
            {
                throw new Exception("O ano de fabricação deve ser o atual.");
            }

            var anoModelo = Convert.ToInt32(truck.AnoModelo);
            if (anoModelo != currentYear && anoModelo != currentYear + 1)
            {
                throw new Exception("O ano modelo deve ser o atual ou o ano subsequente.");
            }

            if (truck.Modelo != "FM" && truck.Modelo != "FH")
            {
                throw new Exception("Modelo Inválido.");
            }
        }
    }
}