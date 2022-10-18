using truck_register.Models;

namespace truck_register.Repositories.Interfaces
{
    public interface ITruckRepository
    {
        public List<Truck> FetchAll();
        public Truck? GetById(long Id);
    }
}