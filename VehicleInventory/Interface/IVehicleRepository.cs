using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleInventory.Models;

namespace VehicleInventory.Interface
{
    /// <summary>
    /// Vehicle repository
    /// </summary>
    public interface IVehicleRepository
    {
        /// <summary>
        /// Add the vehicle
        /// </summary>
        /// <param name="vehicle">The vehicle to add</param>
        void AddVehicle(Vehicle vehicle);

        /// <summary>
        /// Delete the vehicle
        /// </summary>
        /// <param name="id">The vehicle id</param>
        void DeleteVehicle(int id);

        /// <summary>
        /// Update the vehicle
        /// </summary>
        /// <param name="vehicle">The updated vehicle information</param>
        void UpdateVehicle(Vehicle vehicle);

        /// <summary>
        /// Add the model
        /// </summary>
        /// <param name="model">the vehicle model</param>
        void AddModel(Model model);

        /// <summary>
        /// Add the make
        /// </summary>
        /// <param name="make">The vehicle make</param>
        void AddMake(Make make);

        /// <summary>
        /// Get the list of vehicle models
        /// </summary>
        /// <returns>The vehicle models</returns>
        List<Model> GetModels();

        /// <summary>
        /// Get the list of vehicle makes
        /// </summary>
        /// <returns>The vehicle make</returns>
        List<Make> GetMakes();

        /// <summary>
        /// The list of vehicle years
        /// </summary>
        /// <returns>The list of years</returns>
        List<int> GetYears();

        /// <summary>
        /// The list of vehicles
        /// </summary>
        /// <returns>The vehicle list</returns>
        List<Vehicle> GetVehicles();

        /// <summary>
        /// Get the vehicle with the specified id
        /// </summary>
        /// <param name="id">The vehicle id</param>
        /// <returns>The vehicle</returns>
        Vehicle GetVehicle(int id);
    }
}
