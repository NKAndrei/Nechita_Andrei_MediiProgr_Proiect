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
    public class CreateModel : SoldCarDetails
    {
        private readonly Nechita_Andrei_MediiProgr_Proiect.Data.Nechita_Andrei_MediiProgr_ProiectContext _context;

        public CreateModel(Nechita_Andrei_MediiProgr_Proiect.Data.Nechita_Andrei_MediiProgr_ProiectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            GetDetails(_context);
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
