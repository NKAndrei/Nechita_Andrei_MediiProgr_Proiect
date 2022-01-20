using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Nechita_Andrei_MediiProgr_Proiect.Data;
using Nechita_Andrei_Proiect.Models;

namespace Nechita_Andrei_MediiProgr_Proiect.Pages.Cars
{
    public class EditModel : CarDetails
    {
        private readonly Nechita_Andrei_MediiProgr_Proiect.Data.Nechita_Andrei_MediiProgr_ProiectContext _context;

        public EditModel(Nechita_Andrei_MediiProgr_Proiect.Data.Nechita_Andrei_MediiProgr_ProiectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Car Car { get; set; }
        public List<String> validationErrors;

        public Make newCarMake;
        public CarModel newCarModel;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            GetDetails(_context);
            if (id == null)
            {
                return NotFound();
            }

            Car = await _context.Car.FirstOrDefaultAsync(m => m.ID == id);
            if (Car == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string? CarMake, string? CarModel)
        {

            validationErrors = ModelState.Values.Where(E => E.Errors.Count > 0)
.SelectMany(E => E.Errors)
.Select(E => E.ErrorMessage)
.ToList();
            
            GetDetails(_context);
            foreach (var carModel in CarModelList)
            {
                if (carModel.ID == Int32.Parse(CarModel))
                {
                    newCarModel = carModel;
                }
            }
            foreach (var carMake in CarMakeList)
            {
                if (carMake.ID == Int32.Parse(CarMake))
                {
                    newCarMake = carMake;
                }
            }

            Car CarToUpdate = await _context.Car.AsNoTracking().FirstOrDefaultAsync(c => c.ID == id);
            _context.Attach(CarToUpdate).State = EntityState.Modified;

            try
            {
                if (await TryUpdateModelAsync<Car>(CarToUpdate, "Car"))
                {
                    CarToUpdate.Model = newCarModel;
                    CarToUpdate.Make = newCarMake;
                    await _context.SaveChangesAsync();
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarExists(Car.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToPage("./Index");
        }
        
        private bool CarExists(int id)
        {
            return _context.Car.Any(e => e.ID == id);
        }
    }
}
