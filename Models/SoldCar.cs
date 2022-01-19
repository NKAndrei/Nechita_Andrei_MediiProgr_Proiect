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
        [Display(Name = "Serial")]
        public int SoldCarSerial { get; set; }

        [Required]
        [Display(Name = "Description")]
        public String SoldCarDescription { get; set; }
        [Display(Name = "Price")]
        public decimal SoldCarPrice { get; set; }

        [Required]
        [Display(Name = "Customer")]
        public Customer Customer { get; set; }

    }
}
