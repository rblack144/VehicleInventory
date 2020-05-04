using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleInventory.Data;
using VehicleInventory.Interface;
using VehicleInventory.Models;

namespace VehicleInventory.Repositories
{
    /// <summary>
    /// Vehicle repository
    /// </summary>
    public class VehicleRepository : IVehicleRepository
    {
        /// <summary>
        /// The database context
        /// </summary>
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Initialize the member variables
        /// </summary>
        /// <param name="context">The database context</param>
        public VehicleRepository(ApplicationDbContext context) => _context = context;

        /// <summary>
        /// Add the vehicle make
        /// </summary>
        /// <param name="make">The make</param>
        public void AddMake(Make make)
        {
            _context.Makes.Add(make);
            _context.SaveChanges();
        }

        /// <summary>
        /// Add the vehicle model
        /// </summary>
        /// <param name="model">The model</param>
        public void AddModel(Model model)
        {
            _context.Models.Add(model);
            _context.SaveChanges();
        }

        /// <summary>
        /// Add the vehicle
        /// </summary>
        /// <param name="vehicle">The vehicle to add</param>
        public void AddVehicle(Vehicle vehicle)
        {
            _context.Vehicles.Add(vehicle);
            _context.SaveChanges();
        }

        /// <summary>
        /// Delete the vehicle
        /// </summary>
        /// <param name="id">The id of the vehicle to delete</param>
        public void DeleteVehicle(int id)
        {
            var vehicle = _context.Vehicles.Find(id);
            if(vehicle != null)
            {
                _context.Vehicles.Remove(vehicle);
                _context.SaveChanges();
            }
        }

        /// <summary>
        /// Gets the list of vehicle makes
        /// </summary>
        /// <returns>The list of vehicle makes</returns>
        public List<Make> GetMakes() => _context.Makes.ToList();

        /// <summary>
        /// Gets the list of vehicle models
        /// </summary>
        /// <returns>The list of vehicle models</returns>
        public List<Model> GetModels() => _context.Models.ToList();

        /// <summary>
        /// Get the vehicle with the specified id
        /// </summary>
        /// <param name="id">The vehicle id</param>
        /// <returns>The vehicle if found</returns>
        public Vehicle GetVehicle(int id) => _context.Vehicles.Where(v => v.Id == id).Include(vehicle => vehicle.Model)
            .ThenInclude(model => model.Make).SingleOrDefault();

        /// <summary>
        /// Gets the list of vehicles
        /// </summary>
        /// <returns>The list of vehicles</returns>
        public List<Vehicle> GetVehicles() => _context.Vehicles.Include(vehicle => vehicle.Model)
            .ThenInclude(model => model.Make).ToList();

        /// <summary>
        /// The list of years
        /// </summary>
        /// <returns>The list of years</returns>
        public List<int> GetYears() =>
            new List<int>()
            {
                2020,
                2019,
                2018,
                2017,
                2016
            };

        /// <summary>
        /// Update the vehicle
        /// </summary>
        /// <param name="vehicle">The updated vehicle information</param>
        public void UpdateVehicle(Vehicle vehicle)
        {
            _context.Vehicles.Update(vehicle);
            _context.SaveChanges();
        }
    }
}
