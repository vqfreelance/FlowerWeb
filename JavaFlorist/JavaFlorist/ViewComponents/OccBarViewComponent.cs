using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using JavaFlorist.Models;
using JavaFlorist.Models.Repositories;

namespace JavaFlorist.ViewComponents
{
    [ViewComponent(Name = "OccBar")]
    public class OccBarViewComponent : ViewComponent
    {
        private IBouquetRepository bouquetRepository;
        private IOccasionRepository occasionRepository;
        private DatabaseContext db;
        public OccBarViewComponent(IBouquetRepository _bouquetRepository, IOccasionRepository _iOccasionRepository, DatabaseContext _db)
        {
            bouquetRepository = _bouquetRepository;
            occasionRepository = _iOccasionRepository;
            db = _db;
        }
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            ViewBag.Bouquets = occasionRepository.GetBouquetsByOcc(id);

            ViewBag.NumberOccasions = occasionRepository.GetNumberOcc(5);
            ViewBag.Occasions = occasionRepository.GetAll().ToList();
            return View("Index");

        }
    }
}