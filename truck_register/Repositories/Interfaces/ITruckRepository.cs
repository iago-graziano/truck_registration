using truck_register.Models;

namespace truck_register.Repositories.Interfaces
{
    public interface ITruckRepository
    {
        public List<Truck> FetchAll();
        public Truck? GetById(long Id);
        public Truck Insert(Truck Truck);
        public Truck Update(Truck Truck);
        public void Delete(Truck Truck);
    }
}