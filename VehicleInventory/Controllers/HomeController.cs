using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VehicleInventory.Interface;
using VehicleInventory.Models;

namespace VehicleInventory.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IVehicleRepository _repository;

        public HomeController(ILogger<HomeController> logger, IVehicleRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult LoadData()
        {
            var vehicles = _repository.GetVehicles();
            var detailsModels = new List<VehicleDetailViewModel>();

            vehicles.ForEach(vehicle =>
            {
                var detailModel = new VehicleDetailViewModel
                {
                    Id = vehicle.Id,
                    Make = vehicle.Model.Make.Name,
                    Model = vehicle.Model.Name,
                    Image = vehicle.Image,
                    Price = vehicle.Price,
                    Year = vehicle.Model.Year
                };
                detailsModels.Add(detailModel);
            });
            return Json(detailsModels);
        }

        public IActionResult DeleteVehicle(int id)
        {
            _repository.DeleteVehicle(id);
            return View("Index");
        }

        [HttpGet]
        public IActionResult GetModels(int id)
        {
            var makeList = _repository.GetModels().Where(model => model.MakeId == id).ToList();
            return Json(makeList);
        }

        public IActionResult Add()
        {
            var model = new VehicleViewModel();
            model.Makes = _repository.GetMakes();
            model.Models = _repository.GetModels();
            model.Years = _repository.GetYears();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(VehicleViewModel model)
        {
            if (ModelState.IsValid)
            {
                var vehicle = new Vehicle
                {
                    Image = model.Image,
                    ModelId = model.ModelId,
                    Price = model.Price
                };
                _repository.AddVehicle(vehicle);
            }

            return RedirectToAction("Add");
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
