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

        public IList<SoldCar> SoldCar { get;set; }

        public async Task OnGetAsync()
        {
            SoldCar = await _context.SoldCar.ToListAsync();
        }
    }
}
