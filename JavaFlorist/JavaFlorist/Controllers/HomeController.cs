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
        private IOccasionRepository occasionRepository;
        public HomeController(DatabaseContext _db, IBouquetRepository _bouquetRepository, IOccasionRepository _occasionRepository)
        {
            db = _db;
            bouquetRepository = _bouquetRepository;
            occasionRepository = _occasionRepository;
        }

        [AllowAnonymous]
        [Route("index")]
        [Route("")]
        [Route("~/")]
        public IActionResult Index()
        {
            ViewBag.bouquets = bouquetRepository.GetBouquetByStatus();
            ViewBag.numberOccasions = occasionRepository.GetNumberOcc(5);
            ViewBag.occasions = occasionRepository.GetAll().ToList();
            return View();
        }

        [Route("occbouquet/{id}")]
        public IActionResult OccBouquet(int id)
        {

            ViewBag.bouquets = occasionRepository.GetBouquetsByOcc(id);
            ViewBag.numberOccasions = occasionRepository.GetNumberOcc(5);
            ViewBag.occasions = occasionRepository.GetAll().ToList();
            return View("Index2");
        }
    }
}