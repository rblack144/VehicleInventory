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
    public class VehicleRepository : IVehicleRepository
    {
        private readonly ApplicationDbContext _context;

        public VehicleRepository(ApplicationDbContext context) => _context = context;

        public void AddMake(Make make)
        {
            _context.Makes.Add(make);
            _context.SaveChanges();
        }

        public void AddModel(Model model)
        {
            _context.Models.Add(model);
            _context.SaveChanges();
        }

        public void AddVehicle(Vehicle vehicle)
        {
            _context.Vehicles.Add(vehicle);
            _context.SaveChanges();
        }

        public void DeleteVehicle(int id)
        {
            var vehicle = _context.Vehicles.Find(id);
            if(vehicle != null)
            {
                _context.Vehicles.Remove(vehicle);
                _context.SaveChanges();
            }
        }

        public List<Make> GetMakes() => _context.Makes.ToList();

        public List<Model> GetModels() => _context.Models.ToList();

        public List<Vehicle> GetVehicles() => _context.Vehicles.Include(vehicle => vehicle.Model)
            .ThenInclude(model => model.Make).ToList();

        public List<int> GetYears() =>
            new List<int>()
            {
                2020,
                2019,
                2018,
                2017,
                2016
            };

    }
}
