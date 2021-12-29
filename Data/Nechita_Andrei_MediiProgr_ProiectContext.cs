using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nechita_Andrei_Proiect.Models;

namespace Nechita_Andrei_MediiProgr_Proiect.Data
{
    public class Nechita_Andrei_MediiProgr_ProiectContext : DbContext
    {
        public Nechita_Andrei_MediiProgr_ProiectContext (DbContextOptions<Nechita_Andrei_MediiProgr_ProiectContext> options)
            : base(options)
        {
        }

        public DbSet<Nechita_Andrei_Proiect.Models.CarModel> CarModel { get; set; }

        public DbSet<Nechita_Andrei_Proiect.Models.Car> Car { get; set; }

        public DbSet<Nechita_Andrei_Proiect.Models.Customer> Customer { get; set; }

        public DbSet<Nechita_Andrei_Proiect.Models.Make> Make { get; set; }

        public DbSet<Nechita_Andrei_Proiect.Models.SoldCar> SoldCar { get; set; }
    }
}
