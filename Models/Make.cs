using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nechita_Andrei_Proiect.Models
{
    public class Make
    {
        //read the docummentation first
        // this can be done in 2 or 3 ways, convention, fluentapi or annotations
        //[ForeignKey("Car")]
        public int ID { get; set; }
        [Required, StringLength(50, MinimumLength = 3)]
        public String Name { get; set; }

        //public int CarId { get; set; }

        // public Car Car { get; set; }

        public ICollection<Car> Car { get; set; }
    }
}
