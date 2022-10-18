using Microsoft.AspNetCore.Mvc.RazorPages;
using truck_registration.Models;
using truck_registration.Repositories.Interfaces;

namespace truck_registration.Pages
{
    public class IndexModel : PageModel
    {
        readonly ITruckRepository _truckRepository;
        public List<Truck> Trucks { get; set; }
        public Truck Truck { get; set; }

        public IndexModel(ITruckRepository truckRepository)
        {
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