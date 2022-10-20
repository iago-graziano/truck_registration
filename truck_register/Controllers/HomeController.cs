using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using truck_register.Models;
using truck_register.Repositories.Interfaces;
using truck_register.ViewModels;

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
            viewModel.TruckModels = new List<SelectListItem>()
            {
                new SelectListItem() {Text="FH", Value="FH"},
                new SelectListItem() {Text="FM", Value="FM"},
            };
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

            if (Id == 0)
            {
                viewModel.Truck = new Truck();
            }
            else
            {
                viewModel.Truck = _truckRepository.GetById(Id);
            }

            PopulateModel(viewModel);
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(TruckViewModel viewModel)
        {
            var isModelValid = IsTruckModelValid(viewModel.Truck);
            if (isModelValid.Item1)
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
            else
            {
                PopulateModel(viewModel);
                viewModel.Errors = isModelValid.Item2;
                return View("Edit", viewModel);
            }
        }

        private Tuple<bool, string> IsTruckModelValid(Truck truck)
        {
            var currentYear = DateTime.Now.Year;
            bool hasError = false;
            var errorMessages = "";

            if (Convert.ToInt32(truck.AnoFabricacao) != currentYear)
            {
                hasError = true;
                errorMessages += "O ano de fabricação deve ser o atual;\n";
            }

            var anoModelo = Convert.ToInt32(truck.AnoModelo);
            if (anoModelo != currentYear && anoModelo != currentYear + 1)
            {
                hasError = true;
                errorMessages += "O ano modelo deve ser o atual ou o ano subsequente;\n";
            }

            return new Tuple<bool, string>(!hasError, errorMessages);
        }

        public IActionResult Delete(long Id)
        {
            var viewModel = new TruckViewModel();

            var truck = _truckRepository.GetById(Id);
            _truckRepository.Delete(truck);

            PopulateModel(viewModel);
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}