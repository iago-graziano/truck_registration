using Microsoft.AspNetCore.Mvc.RazorPages;
using truck_registration.Models;
using truck_registration.Repositories.Interfaces;

namespace truck_registration.Pages
{
    public class IndexModel : PageModel
    {
        readonly ITruckRepository _truckRepository;
        private readonly ILogger<IndexModel> _logger;
        public List<Truck> Trucks { get; set; }
        public Truck Truck { get; set; }

        public IndexModel(ILogger<IndexModel> logger, ITruckRepository truckRepository)
        {
            _logger = logger;
            _truckRepository = truckRepository;
            PopulateModel();
        }

        private void PopulateModel()
        {
            Trucks = _truckRepository.FetchAll();
        }

        public void OnGet()
        {

        }
    }
}