using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleInventory.Models
{
    /// <summary>
    /// The details of the vehicle
    /// </summary>
    public class VehicleDetailViewModel
    {
        /// <summary>
        /// The system id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The make
        /// </summary>
        public string Make { get; set; }

        /// <summary>
        /// The model
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// The year
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// The price
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// The vehicle image
        /// </summary>
        public string Image { get; set; }
    }
}
