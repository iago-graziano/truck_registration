using Microsoft.AspNetCore.Mvc;

namespace truck_registration.Controllers
{
    public class TruckController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}