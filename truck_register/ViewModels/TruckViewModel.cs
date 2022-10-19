using Microsoft.AspNetCore.Mvc.Rendering;
using truck_register.Models;

namespace truck_register.ViewModels
{
    public class TruckViewModel
    {
        public List<Truck> Trucks { get; set; }
        public Truck? Truck { get; set; }
        public List<SelectListItem>? TruckModels { get; set; }
        public string Errors { get; set; }
    }
}