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

namespace Nechita_Andrei_MediiProgr_Proiect.Pages.Makes
{
    public class EditModel : PageModel
    {
        private readonly Nechita_Andrei_MediiProgr_Proiect.Data.Nechita_Andrei_MediiProgr_ProiectContext _context;

        public EditModel(Nechita_Andrei_MediiProgr_Proiect.Data.Nechita_Andrei_MediiProgr_ProiectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Make Make { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Make = await _context.Make.FirstOrDefaultAsync(m => m.ID == id);

            if (Make == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Make).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MakeExists(Make.ID))
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

        private bool MakeExists(int id)
        {
            return _context.Make.Any(e => e.ID == id);
        }
    }
}
