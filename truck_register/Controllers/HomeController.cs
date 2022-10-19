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

        [HttpGet]
        public IActionResult Index()
        {
            var viewModel = new TruckViewModel();
            PopulateModel(viewModel);
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Edit(long Id)
        {
            var viewModel = new TruckViewModel();

            if(Id == 0)
            {
                viewModel.Truck = new Truck();
            }
            else
            {
                viewModel.Truck = _truckRepository.GetById(Id);
            }

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(TruckViewModel viewModel)
        {
            if (viewModel.Truck!.Id == 0)
            {
                viewModel.Truck!.Id = _truckRepository.FetchAll().Last().Id + 1;

                _truckRepository.Insert(viewModel.Truck);
            }
            else
            {
                _truckRepository.Update(viewModel.Truck);
            }

            PopulateModel(viewModel);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(long Id)
        {
            var viewModel = new TruckViewModel();

            var truck = _truckRepository.GetById(Id);
            _truckRepository.Delete(truck);

            PopulateModel(viewModel);
            return View("Index", viewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}