using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using JavaFlorist.Models.Repositories;
using JavaFlorist.Models;

namespace JavaFlorist.Controllers
{
    [Route("home")]
    public class HomeController : Controller
    {
        private DatabaseContext db;
        private IBouquetRepository bouquetRepository;
        public HomeController(DatabaseContext _db, IBouquetRepository _bouquetRepository)
        {
            db = _db;
            bouquetRepository = _bouquetRepository;
        }

        [AllowAnonymous]
        [Route("index")]
        [Route("")]
        [Route("~/")]
        public async Task<IActionResult> Index()
        {
            var bouquets = bouquetRepository.GetAll().ToList();
            ViewBag.bouquets = bouquets;
            return View();
        }
    }
}