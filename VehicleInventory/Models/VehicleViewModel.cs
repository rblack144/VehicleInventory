using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleInventory.Models
{
    public class VehicleViewModel
    {
        [Required(ErrorMessage = "Please Select a Make")]
        public int MakeId { get; set; }

        public List<Make> Makes { get; set; }

        [Required(ErrorMessage = "Please Select a Model")]
        public int ModelId { get; set; }

        public List<Model> Models { get; set; }

        [Required(ErrorMessage ="Please Select a Year")]
        public int Year { get; set; }

        public List<int> Years { get; set; }

        [Required]
        public string Image { get; set; }

        [Required]
        public string ImagePath { get; set; }

        [Required]
        [Range(500, 1000000)]
        public decimal Price { get; set; }
    }
}
