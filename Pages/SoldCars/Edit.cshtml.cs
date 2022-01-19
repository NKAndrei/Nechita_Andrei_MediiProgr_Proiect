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

namespace Nechita_Andrei_MediiProgr_Proiect.Pages.SoldCars
{
    public class EditModel : PageModel
    {
        private readonly Nechita_Andrei_MediiProgr_Proiect.Data.Nechita_Andrei_MediiProgr_ProiectContext _context;

        public EditModel(Nechita_Andrei_MediiProgr_Proiect.Data.Nechita_Andrei_MediiProgr_ProiectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public SoldCar SoldCar { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            SoldCar = await _context.SoldCar.FirstOrDefaultAsync(m => m.ID == id);

            if (SoldCar == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            SoldCar soldCarUpdate = await _context.SoldCar.AsNoTracking().FirstOrDefaultAsync(c => c.ID == id);
            soldCarUpdate.SoldCarDescription = SoldCar.SoldCarDescription;
            soldCarUpdate.SoldCarPrice = SoldCar.SoldCarPrice;
            _context.Attach(soldCarUpdate).State = EntityState.Modified;
            //_context.Attach(SoldCar).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SoldCarExists(SoldCar.ID))
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

        private bool SoldCarExists(int id)
        {
            return _context.SoldCar.Any(e => e.ID == id);
        }
    }
}
