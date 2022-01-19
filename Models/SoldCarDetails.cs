using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Nechita_Andrei_MediiProgr_Proiect.Data;
using Nechita_Andrei_Proiect.Models;

namespace Nechita_Andrei_Proiect.Models
//namespace Nechita_Andrei_MediiProgr_Proiect.Models
{
    public class SoldCarDetails : PageModel
    {
        public List<Car> CarList;
        public List<Customer> CustomerList;
        public void GetDetails(Nechita_Andrei_MediiProgr_Proiect.Data.Nechita_Andrei_MediiProgr_ProiectContext context)
        {
            var allCars = context.Car;
            CarList = new List<Car>();

            foreach (var car in allCars)
            {
                Car newCar = new Car
                {
                    ID = car.ID,
                    Price = car.Price,
                    Description = car.Description,
                    Make = car.Make,
                    Model = car.Model
                };
                CarList.Add(newCar);
            }

            var allCustomers = context.Customer;
            CustomerList = new List<Customer>();

            foreach (var customer in allCustomers)
            {
                Customer newCustomer = new Customer
                {
                    ID = customer.ID,
                    Name = customer.Name
                };
                CustomerList.Add(newCustomer);
            }

        }
    }
}
