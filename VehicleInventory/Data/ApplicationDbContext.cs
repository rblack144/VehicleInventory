using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VehicleInventory.Models;

namespace VehicleInventory.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)  {    }

        /// <summary>
        /// The vehicle make
        /// </summary>
        public DbSet<Make> Makes { get; set; }

        /// <summary>
        /// The vehicle models
        /// </summary>
        public DbSet<Model> Models { get; set; }

        /// <summary>
        /// The vehicles
        /// </summary>
        public DbSet<Vehicle> Vehicles { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Make>().HasData(
                new Make { Id = 1, Name="Honda" },
                new Make { Id = 2, Name="Toyota" });

            builder.Entity<Model>().HasData(
                new Model { Id = 1, MakeId = 1, Name = "Civic LX", Year = 2018 },
                new Model { Id = 2, MakeId = 1, Name = "Civic EX", Year = 2017 },
                new Model { Id = 3, MakeId = 2, Name = "Camry", Year = 2018 },
                new Model { Id = 4, MakeId = 2, Name = "Corolla", Year = 2017 });

            base.OnModelCreating(builder);
        }
    }
}
