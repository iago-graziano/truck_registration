using truck_registration.Models;

namespace truck_registration.Daos
{
    public class TruckDao
    {
        private readonly TruckContext _context;
        public TruckDao(TruckContext context)
        {
            _context = context;
        }

        public Truck? GetById(long Id)
        {
            return _context.Truck.FirstOrDefault(t => t.Id == Id);
        }

        public List<Truck> FetchAll()
        {
            return _context.Truck.ToList();
        }
    }
}