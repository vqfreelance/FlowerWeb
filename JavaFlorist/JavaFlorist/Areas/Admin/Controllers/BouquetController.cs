using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JavaFlorist.Models;
using Microsoft.AspNetCore.Mvc;

namespace JavaFlorist.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin/bouquet")]
    public class BouquetController : Controller
    {

        private DatabaseContext db;

        public BouquetController(DatabaseContext _db)
        {
            db = _db;
        }


        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            ViewBag.bouquets = db.Bouquet.ToList();
            return View();
        }
    }
}