﻿using Microsoft.AspNetCore.Mvc;
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}