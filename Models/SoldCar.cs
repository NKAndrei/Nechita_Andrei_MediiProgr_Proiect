using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema


namespace Nechita_Andrei_Proiect.Models
{
    public class SoldCar
    {
        public int ID { get; set; }

        [Index]
        [Required]
        public Car Car { get; set; }

        [Required]
        public Customer Customer { get; set; }

    }
}
