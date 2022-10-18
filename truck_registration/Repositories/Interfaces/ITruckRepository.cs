using truck_registration.Models;

namespace truck_registration.Repositories.Interfaces
{
    public interface ITruckRepository
    {
        public List<Truck> FetchAll();
        public Truck? GetById(long Id);
    }
}