using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleInventory.Models
{
    #region Vehicle
    /// <summary>
    /// Vehicle
    /// </summary>
    public class Vehicle
    {
        /// <summary>
        /// The system id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The model id
        /// </summary>
        public int ModelId { get; set; }

        /// <summary>
        /// The price of the vehicle
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Vehicle picture
        /// </summary>
        public string Image { get; set; }

        /// <summary>
        /// The vehicle image name
        /// </summary>
        public string ImageName { get; set; }

        /// <summary>
        /// The vehicle model
        /// </summary>
        public virtual Model Model { get; set; }
    }
    #endregion

    #region Vehicle Make
    /// <summary>
    /// Make
    /// </summary>
    public class Make
    {
        /// <summary>
        /// The system id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The vehicle name
        /// </summary>
        public string Name { get; set; }
    }
    #endregion

    #region Vehicle Model
    /// <summary>
    /// Model
    /// </summary>
    public class Model
    {
        /// <summary>
        /// The system id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The make
        /// </summary>
        public int MakeId { get; set; }

        /// <summary>
        /// The name of the vehicle model
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The year
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// The vehicle make
        /// </summary>
        public virtual Make Make { get; set; }
    }
    #endregion
}
