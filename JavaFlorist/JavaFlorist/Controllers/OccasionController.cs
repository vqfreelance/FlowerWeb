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
        public async Task<IActionResult> Index(int id, int? page = 0)
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
            ViewBag.occ = occ;

            //load pagination
            int limit = 8;
            int start;
            if (page > 0)
            {
                page = page;
            }
            else
            {
                page = 1;
            }
            start = (int)(page - 1) * limit;

            ViewBag.pageCurrent = page;

            int totalProduct = bouquetRepository.totalProduct(listb);

            ViewBag.totalProduct = totalProduct;

            ViewBag.numberPage = bouquetRepository.numberPage(totalProduct, limit);

            var data = bouquetRepository.paginationProduct(start, limit, listb);

            ViewBag.data = data;
            }

            return View();
        }
    }
}
