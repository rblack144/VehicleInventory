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
    /// <summary>
    /// Home Controller
    /// </summary>
    [Authorize]
    public class HomeController : Controller
    {
        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger<HomeController> _logger;

        /// <summary>
        /// The vehicle repository
        /// </summary>
        private readonly IVehicleRepository _repository;

        /// <summary>
        /// Initialize the member variables
        /// </summary>
        /// <param name="logger">The logger</param>
        /// <param name="repository">The vehicle repository</param>
        public HomeController(ILogger<HomeController> logger, IVehicleRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        /// <summary>
        /// The index page
        /// </summary>
        /// <returns>The index view</returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Deletes the specified vehicle
        /// </summary>
        /// <param name="id">The vehicle id</param>
        /// <returns>The index view</returns>
        public IActionResult DeleteVehicle(int id)
        {
            _repository.DeleteVehicle(id);
            return View("Index");
        }

        /// <summary>
        /// Adds a vehicle
        /// </summary>
        /// <returns>The add view</returns>
        public IActionResult Add()
        {
            var model = new VehicleViewModel();
            model.Makes = _repository.GetMakes();
            model.Models = _repository.GetModels();
            model.Years = _repository.GetYears();
            return View(model);
        }

        /// <summary>
        /// Add the vehicle
        /// </summary>
        /// <param name="model">The vehicle to add the the database</param>
        /// <returns>The add view</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(VehicleViewModel model)
        {
            if (ModelState.IsValid)
            {
                var vehicle = new Vehicle
                {
                    ImageName = model.ImagePath,
                    Image = model.Image,
                    ModelId = model.ModelId,
                    Price = model.Price
                };
                _repository.AddVehicle(vehicle);
            }

            return RedirectToAction("Index");
        }

        /// <summary>
        /// Edit the vehicle
        /// </summary>
        /// <param name="id">The system id of the vehicle to edit</param>
        /// <returns>The edit view</returns>
        public IActionResult Edit(int id)
        {
            // Get the vehicle
            var vehicle = _repository.GetVehicle(id);
            if(vehicle == null)
            {
                // No such vehicle
                return View(new VehicleViewModel());
            }
            else
            {
                return View(new VehicleViewModel
                {
                    Image = vehicle.Image,
                    ImagePath = vehicle.ImageName,
                    ModelId = vehicle.ModelId,
                    Models = _repository.GetModels(),
                    MakeId = vehicle.Model.MakeId,
                    Makes = _repository.GetMakes(),
                    Price = vehicle.Price,
                    Year = vehicle.Model.Year,
                    Years = _repository.GetYears()
                });
            }
        }

        /// <summary>
        /// Edit the vehicle
        /// </summary>
        /// <param name="model">The edited vehicle information</param>
        /// <returns>The Index view</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(VehicleViewModel model)
        {
            if (ModelState.IsValid)
            {
                var vehicle = _repository.GetVehicle(model.Id);
                if (vehicle != null)
                {
                    vehicle.ImageName = model.ImagePath;
                    vehicle.Image = model.Image;
                    vehicle.ModelId = model.ModelId;
                    vehicle.Price = model.Price;
                    vehicle.Model.Year = model.Year;
                    _repository.UpdateVehicle(vehicle);
                }
            }

            return RedirectToAction("Index");
        }

        #region Ajax Methods
        /// <summary>
        /// Load the vehicle data
        /// </summary>
        /// <returns>The list of vehicles to display</returns>
        [HttpGet]
        public IActionResult LoadData()
        {
            // Get the vehicles
            var vehicles = _repository.GetVehicles();
            var detailsModels = new List<VehicleDetailViewModel>();

            // Conver to view models
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

            // Send the data a json
            return Json(detailsModels);
        }

        /// <summary>
        /// Get the vehicle models
        /// </summary>
        /// <param name="id">The vehicle make system id</param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetModels(int id)
        {
            // Get the list of vehicle models
            var vehicleModels = _repository.GetModels().Where(model => model.MakeId == id).ToList();
            return Json(vehicleModels);
        }
        #endregion

        /// <summary>
        /// The privacy message
        /// </summary>
        /// <returns>Privacy view</returns>
        public IActionResult Privacy()
        {
            return View();
        }

        /// <summary>
        /// Error message
        /// </summary>
        /// <returns>The error view</returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
