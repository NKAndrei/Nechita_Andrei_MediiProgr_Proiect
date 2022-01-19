using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Nechita_Andrei_MediiProgr_Proiect.Data;
using Nechita_Andrei_Proiect.Models;

namespace Nechita_Andrei_MediiProgr_Proiect.Pages.Cars
{
    public class CreateModel : CarDetails
    {
        private readonly Nechita_Andrei_MediiProgr_Proiect.Data.Nechita_Andrei_MediiProgr_ProiectContext _context;

        public CreateModel(Nechita_Andrei_MediiProgr_Proiect.Data.Nechita_Andrei_MediiProgr_ProiectContext context)
        {
            _context = context;
        }
        public string TheResult = "not set";
        public string MyModelState = "not set";
        
        public IActionResult OnGet()
        {
            GetDetails(_context);
            return Page();
        }

        [BindProperty]
        public Car Car { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(string CarMakeType, string CarModelType)
        {
            var newCar = new Car();
            var newCarMake = _context.Make.Find(Int32.Parse(CarMakeType));
            var newCarModel = _context.CarModel.Find(Int32.Parse(CarModelType));
            TheResult = CarMakeType + " " + CarModelType;
            if (newCarMake == null || newCarModel == null)
            {
                MyModelState = "It Is NULL";
                return Page();
            }
            
            Car.Model = newCarModel;
            Car.Make = newCarMake;
            
            _context.Car.Add(Car);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
