using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Nechita_Andrei_MediiProgr_Proiect.Data;
using Nechita_Andrei_Proiect.Models;

namespace Nechita_Andrei_MediiProgr_Proiect.Pages.SoldCars
{
    public class IndexModel : PageModel
    {
        private readonly Nechita_Andrei_MediiProgr_Proiect.Data.Nechita_Andrei_MediiProgr_ProiectContext _context;

        public IndexModel(Nechita_Andrei_MediiProgr_Proiect.Data.Nechita_Andrei_MediiProgr_ProiectContext context)
        {
            _context = context;
        }

        public IList<SoldCar> SoldCars { get;set; }
        public IList<Car> Cars { get; set; }
        public IList<Customer> Customers { get; set; }

        public async Task OnGetAsync()
        {
            SoldCars = await _context.SoldCar.Include(i => i.Car).Include(i => i.Customer).ToListAsync();
            /*
            foreach (var element in SoldCars)
            {
                var car = _context.Car.Find(element.Car.ID);
                var customer = _context.Customer.Find(element.Customer.ID);
                Car newCar = new Car
                {
                    ID = car.ID,
                    Price = car.Price,
                    Description = car.Description,
                    Make = car.Make,
                    Model = car.Model
                };

                Customer newCustomer = new Customer
                {
                    ID = customer.ID,
                    Name = customer.Name
                };
                Customers.Add(newCustomer);
                Cars.Add(newCar);
            }
            */
            
        }
    }
}
