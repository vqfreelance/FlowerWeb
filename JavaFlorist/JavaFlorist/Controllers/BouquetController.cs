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
        public BouquetController(DatabaseContext _db, IBouquetRepository _bouquetRepository)
        {
            db = _db;
            bouquetRepository = _bouquetRepository;
        }

        [HttpGet]
        [Route("detail/{id}")]
        public async Task<IActionResult> Detail(int id)
        {
            ViewBag.bouquet = await bouquetRepository.GetById(id);
            return View("Detail");
        }
    }
}