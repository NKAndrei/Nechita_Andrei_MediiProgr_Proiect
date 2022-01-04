using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Nechita_Andrei_MediiProgr_Proiect.Data;
using Nechita_Andrei_Proiect.Models;

namespace Nechita_Andrei_Proiect.Models
{
    public class CarDetails : PageModel
    {
        public List<Make> CarMakeList;
        public List<CarModel> CarModelList;
        public void GetDetails(Nechita_Andrei_MediiProgr_Proiect.Data.Nechita_Andrei_MediiProgr_ProiectContext context)
        {

            var allMakes = context.Make.AsNoTracking();
            CarMakeList = new List<Make>();

            foreach (var make in allMakes)
            {
                Make carMake = new Make
                {
                    ID = make.ID,
                    Name = make.Name
                };
                CarMakeList.Add(carMake);
            }

            var allCarModels = context.CarModel.AsNoTracking(); // it returns a list or a collection
            CarModelList = new List<CarModel>();
            foreach (var carModel in allCarModels)
            {
                CarModel carCarModel = new CarModel
                {
                    ID = carModel.ID,
                    Name = carModel.Name
                };
                CarModelList.Add(carCarModel);
            }

        }
    
    }
}
