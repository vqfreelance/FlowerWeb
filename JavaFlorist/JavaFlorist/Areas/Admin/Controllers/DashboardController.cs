using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JavaFlorist.Models;
using Microsoft.AspNetCore.Mvc;

namespace JavaFlorist.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin/dashboard")]
    public class DashboardController : Controller
    {
        private DatabaseContext db;

        public DashboardController(DatabaseContext _db)
        {
            db = _db;
        }

        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            ViewBag.username = TempData["Username"];
            //ViewBag.countBouquets = db.Bouquet.Count();
            return View();
        }

        [Route("logout")]
        public IActionResult Logout()
        {
            return RedirectToAction("login", "account");
        }
    }
}