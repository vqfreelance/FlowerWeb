using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JavaFlorist.Models;
using JavaFlorist.Models.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace JavaFlorist.Controllers
{
    [Route("bouquet")]
    public class BouquetController : Controller
    {
        private DatabaseContext db;
        private IBouquetRepository bouquetRepository;
        private IOccasionRepository occasionRepository;

        public BouquetController(DatabaseContext _db, IBouquetRepository _bouquetRepository, IOccasionRepository _occasionRepository)
        {
            db = _db;
            bouquetRepository = _bouquetRepository;
            occasionRepository = _occasionRepository;
        }

        [HttpGet]
        [Route("detail/{id}")]
        public async Task<IActionResult> Detail(int id)
        {
            ViewBag.bouquet = await bouquetRepository.GetById(id);
            ViewBag.randombouquets = bouquetRepository.GetRandomBouquets(5);
            return View("Detail");
        }

        [Route("getbouquetbyid/{id}")]
        public IActionResult GetBouquetById(int id)
        {
            ViewBag.bouquet = bouquetRepository.GetBouquetById(id);
            ViewBag.randombouquets = bouquetRepository.GetRandomBouquets(5);
            return View("Index");
        }

        [Route("index")]
        public IActionResult Index(int? page = 0)
        {
            var today = DateTime.Now;
            var allocc = occasionRepository.GetAll().ToList();
            var occs = new List<Occasion>();
            foreach (var o in allocc)
            {
                if (o.StartMonth - 1 < today.Month && o.EndMonth >= today.Month)
                {
                    occs.Add(o);
                }
            }
            ViewBag.occs = occs;

            //load pagination
            int limit = 2;
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

            int totalProduct = bouquetRepository.totalProduct();

            ViewBag.totalProduct = totalProduct;

            ViewBag.numberPage = bouquetRepository.numberPage(totalProduct, limit);

            var data = bouquetRepository.paginationProduct(start, limit);

            ViewBag.data = data;
            ViewBag.bouquets = bouquetRepository.GetAll().ToList();
            return View("AllBouquet");
        }

        [Route("search")]
        public IActionResult Search(string keyword)
        {
            var today = DateTime.Now;
            var allocc = occasionRepository.GetAll().ToList();
            var occs = new List<Occasion>();
            foreach (var o in allocc)
            {
                if (o.StartMonth - 1 < today.Month && o.EndMonth >= today.Month)
                {
                    occs.Add(o);
                }
            }
            ViewBag.occs = occs;

            ViewBag.bouquets = bouquetRepository.SearchByKeyword(keyword);
            return View("AllBouquet");
        }
    }
}