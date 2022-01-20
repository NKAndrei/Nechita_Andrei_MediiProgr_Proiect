using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nechita_Andrei_Proiect.Models
{
    public class Car
    {
        public int ID { get; set; }

        [Range(100, 3000)]
        public decimal Price { get; set; }
        [Required, StringLength(150, MinimumLength = 5)]
        public String Description { get; set; }
        [Required]
        public Make Make { get; set; }
        [Required]
        public CarModel Model { get; set; }
    }
}
