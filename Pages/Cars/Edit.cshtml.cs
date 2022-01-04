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
        //public Make Make { get; set; }
        //public CarModel Model { get; set; }

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
            //Car = await _context.Car.Include(c => c.Make).Include(c => c.Model).AsNoTracking().FirstOrDefaultAsync(c => c.ID == id);
            //ViewData["MakeID"] = new SelectList(_context.Set<Make>(), "ID", "Name");
            //ViewData["ModelID"] = new SelectList(_context.Set<CarModel>(), "ID", "Name");
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
            //var newCarMake = _context.Make.Find(Int32.Parse(CarMake));
            //var newCarModel = _context.CarModel.Find(Int32.Parse(CarModel));
            //int makeID = Int32.Parse(CarMake);
            //int modelID = Int32.Parse(CarModel);
            //var newCarMake = await _context.Make.AsNoTracking().FirstOrDefaultAsync(c => c.ID == makeID);
            //var newCarModel = await _context.CarModel.AsNoTracking().FirstOrDefaultAsync(c => c.ID == modelID);

            validationErrors = ModelState.Values.Where(E => E.Errors.Count > 0)
.SelectMany(E => E.Errors)
.Select(E => E.ErrorMessage)
.ToList();
            /*
            if (!ModelState.IsValid)
            {
                //return NotFound();
                return Page();
            }
            */
            //Make newCarMake = new Make();//= CarMakeList.Select(i => i).Where(i => i.ID == id);
            //CarModel newCarModel = new CarModel();// = CarModelList.Select(i => i).Where(i => i.ID == id);
            
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

            //Car CarToUpdate = await _context.Car.Include(c => c.Make).AsNoTracking().Include(c => c.Model).AsNoTracking().FirstOrDefaultAsync(c => c.ID == id);
            Car CarToUpdate = await _context.Car.AsNoTracking().FirstOrDefaultAsync(c => c.ID == id);
            //_context.Attach(Car).State = EntityState.Modified;
            _context.Attach(CarToUpdate).State = EntityState.Modified;

            try
            {
                //if (await TryUpdateModelAsync<Car>(CarToUpdate, "Car", i => i.Price, i=> i.Make, i => i.Model))
                //if (await TryUpdateModelAsync<Car>(Car, "Car", i => i.Make, i => i.Model))
                if (await TryUpdateModelAsync<Car>(CarToUpdate, "Car"))
                {
                    CarToUpdate.Model = newCarModel;
                    CarToUpdate.Make = newCarMake;
                    //await TryUpdateModelAsync<Car>(CarToUpdate, "Car", );
                    await _context.SaveChangesAsync();
                    //return RedirectToPage("./Index");
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
            return Page();
            return RedirectToPage("./Index");
        }
        
        private bool CarExists(int id)
        {
            return _context.Car.Any(e => e.ID == id);
        }
    }
}
