using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Nechita_Andrei_Proiect.Models
{
    public class Customer
    {
        public int ID { get; set; }
        [Required, StringLength(150, MinimumLength = 5)]
        public string Name { get; set; }

    }
}
