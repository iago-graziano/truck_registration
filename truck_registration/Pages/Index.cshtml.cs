using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using truck_registration.Models;

namespace truck_registration.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public List<Truck> Trucks { get; set; }
        public Truck Truck { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;

            Trucks = new List<Truck>();
            Trucks.Add(new Truck
            {
                Id = 1,
                Modelo = "tESTE"
            });

            Trucks.Add(new Truck
            {
                Id = 2,
                Modelo = "Teste 2"
            });
        }

        public void OnGet()
        {

        }
    }
}