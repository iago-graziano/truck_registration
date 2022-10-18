using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using truck_register.Models;
using truck_register.Repositories.Interfaces;

namespace truck_register.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITruckRepository _truckRepository;

        public HomeController(ITruckRepository truckRepository)
        {
            _truckRepository = truckRepository;
        }

        private void PopulateModel(TruckViewModel viewModel)
        {
            viewModel.Trucks = _truckRepository.FetchAll();
        }

        public IActionResult Index()
        {
            var viewModel = new TruckViewModel();
            PopulateModel(viewModel);
            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}