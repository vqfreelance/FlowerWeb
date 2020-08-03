using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JavaFlorist.Models;
using JavaFlorist.Models.Repositories;
using JavaFlorist.ViewComponents;
using Microsoft.AspNetCore.Mvc;

namespace JavaFlorist.Controllers
{
    [Route("occasion")]
    public class OccasionController : Controller
    {
        private DatabaseContext db;
        private IOccasionRepository occasionRepository;
        private IOccBouquetRepository occBouquetRepository;
        private IBouquetRepository bouquetRepository;

        public OccasionController(DatabaseContext _db, IOccasionRepository _occasionRepository, IOccBouquetRepository _occBouquetRepository, IBouquetRepository _bouquetRepository)
        {
            db = _db;
            occasionRepository = _occasionRepository;
            occBouquetRepository = _occBouquetRepository;
            bouquetRepository = _bouquetRepository;
        }

        [Route("detail/{id}")]
        public async Task<IActionResult> Index(int id)
        {
            var occ = await occasionRepository.GetByIdIncludeRelationship(id);
            var listb = new List<Bouquet>();
            if(occ != null)
            {
            foreach (var o in occ.OccBouquet)
            {
                var b = await bouquetRepository.GetByIdIncludeRelationship(o.BouquetId);
                listb.Add(b);
            }            
                ViewBag.listb = listb;
            }

            ViewBag.occ = occ;

            return View();
        }
    }
}
