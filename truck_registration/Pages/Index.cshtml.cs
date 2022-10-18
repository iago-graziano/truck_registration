using Microsoft.AspNetCore.Mvc.RazorPages;
using truck_registration.Daos;
using truck_registration.Models;

namespace truck_registration.Pages
{
    public class IndexModel : PageModel
    {
        private readonly TruckContext _context;
        private readonly ILogger<IndexModel> _logger;
        public List<Truck> Trucks { get; set; }
        public Truck Truck { get; set; }

        public IndexModel(ILogger<IndexModel> logger, TruckContext context)
        {
            _logger = logger;
            _context = context;
            PopulateModel();
        }

        private void PopulateModel()
        {
            var truckDao = new TruckDao(_context);
            Trucks = truckDao.FetchAll();
        }

        public void OnGet()
        {

        }
    }
}