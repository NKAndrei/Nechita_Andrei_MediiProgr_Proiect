using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Nechita_Andrei_MediiProgr_Proiect.Data;
using Nechita_Andrei_Proiect.Models;


namespace Nechita_Andrei_MediiProgr_Proiect.Pages.SoldCars
{
    public class CreateModel : PageModel
    {
        private readonly Nechita_Andrei_MediiProgr_Proiect.Data.Nechita_Andrei_MediiProgr_ProiectContext _context;

        public CreateModel(Nechita_Andrei_MediiProgr_Proiect.Data.Nechita_Andrei_MediiProgr_ProiectContext context)
        {
            _context = context;
        }
        public List<Car> CarList;
        public List<Customer> CustomerList;
        public String isCarListNull = "not null";
        public String isCustomerListNull = "not null";
        public void GetSoldCarDetails(Nechita_Andrei_MediiProgr_Proiect.Data.Nechita_Andrei_MediiProgr_ProiectContext scontext)
        {
            var allCars = scontext.Car;
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

            var allCustomers = scontext.Customer;
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

        public IActionResult OnGet()
        {
            GetSoldCarDetails(_context);
            if (CarList == null || CarList.Count == 0)
            {
                isCarListNull = "Car list is null";
            }
            if (CustomerList == null || CustomerList.Count == 0)
            {
                isCustomerListNull = "Customer list is null";
            }
            isCarListNull = "not null " + CarList.Count;
            isCustomerListNull = "not null " + CustomerList.Count;
            return Page();
        }

        [BindProperty]
        public SoldCar SoldCar { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(string CustomerStringID, string CarStringID)
        {
            int customerID = Int32.Parse(CustomerStringID);
            int carID = Int32.Parse(CarStringID);

            Car car = _context.Car.Find(carID);
            Customer customer = _context.Customer.Find(customerID);

            SoldCar.SoldCarSerial = carID;
            SoldCar.SoldCarPrice = car.Price;
            SoldCar.SoldCarDescription = car.Description;
            SoldCar.Customer = customer;

            _context.SoldCar.Add(SoldCar);
            _context.Car.Remove(car);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
