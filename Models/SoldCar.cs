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
        public int SoldCarSerial { get; set; }

        [Required]
        public String SoldCarDescription { get; set; }

        public decimal SoldCarPrice { get; set; }

        [Required]
        public Customer Customer { get; set; }

    }
}
