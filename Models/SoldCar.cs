using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Nechita_Andrei_Proiect.Models
{
    public class SoldCar
    {
        public int ID { get; set; }

        [Required]
        public Car Car { get; set; }

        [Required]
        public Customer Customer { get; set; }

    }
}
