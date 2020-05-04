using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleInventory.Models
{
    /// <summary>
    /// The vehicle view model
    /// </summary>
    public class VehicleViewModel
    {
        /// <summary>
        /// The id of the vehicle
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The make id
        /// </summary>
        [Required]
        [Range(1, double.MaxValue, ErrorMessage = "Please select a Make")]
        public int MakeId { get; set; }

        /// <summary>
        /// The list of makes
        /// </summary>
        public List<Make> Makes { get; set; }

        /// <summary>
        /// The model id
        /// </summary>
        [Required]
        [Range(1, double.MaxValue, ErrorMessage = "Please select a Model")]
        public int ModelId { get; set; }

        /// <summary>
        /// The list of models
        /// </summary>
        public List<Model> Models { get; set; }

        /// <summary>
        /// The year
        /// </summary>
        [Required]
        [Range(1, double.MaxValue, ErrorMessage = "Please select the year")]
        public int Year { get; set; }

        /// <summary>
        /// The list of years
        /// </summary>
        public List<int> Years { get; set; }

        /// <summary>
        /// The vehicle image
        /// </summary>
        [Required]
        public string Image { get; set; }

        /// <summary>
        /// The image path
        /// </summary>
        [Required(ErrorMessage ="Please upload an image of the vehicle")]
        [DisplayName("Image Path")]
        public string ImagePath { get; set; }

        /// <summary>
        /// The vehicle price
        /// </summary>
        [Required]
        [Range(500, 1000000, ErrorMessage ="Please enter the vehicle price")]
        public decimal Price { get; set; }
    }
}
