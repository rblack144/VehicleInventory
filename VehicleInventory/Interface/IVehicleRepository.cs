using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleInventory.Models;

namespace VehicleInventory.Interface
{
    public interface IVehicleRepository
    {
        void AddVehicle(Vehicle vehicle);

        void DeleteVehicle(int id);

        void AddModel(Model model);

        void AddMake(Make make);

        List<Model> GetModels();

        List<Make> GetMakes();

        List<int> GetYears();

        List<Vehicle> GetVehicles();
    }
}
