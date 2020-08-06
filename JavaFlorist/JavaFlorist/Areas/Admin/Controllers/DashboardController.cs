using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JavaFlorist.Models;
using JavaFlorist.Models.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JavaFlorist.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin/dashboard")]
    public class DashboardController : Controller
    {
        private DatabaseContext db;
        private IAccountRepository accountRepository;
        private IBouquetRepository bouquetRepository;
        private IOrderRepository orderRepository;
        private IOccasionRepository occasionRepository;

        public DashboardController(DatabaseContext _db,
            IAccountRepository _accountRepository,
            IBouquetRepository _bouquetRepository,
            IOrderRepository _orderRepository,
            IOccasionRepository _occasionRepository)
        {
            db = _db;
            accountRepository = _accountRepository;
            bouquetRepository = _bouquetRepository;
            orderRepository = _orderRepository;
            occasionRepository = _occasionRepository;
        }

        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            try
            {
                // Dashboard index
                ViewBag.numoforder = orderRepository.GetAll().Count();
                ViewBag.numofbouquet = bouquetRepository.GetAll().Count();
                ViewBag.numofuser = accountRepository.GetAll().Count();
                ViewBag.numofoccasion = occasionRepository.GetAll().Count();

                // Admin Photo
                var username = HttpContext.Session.GetString("username");
                var account = accountRepository.GetByUsername(username);
                ViewBag.account = account;
                return View();
            }
            catch (Exception)
            {
                return RedirectToAction("error500", "error", new { area = "admin" });
            }            
        }

        [Route("user")]
        public IActionResult CustomerUser()
        {
            try
            {
                ViewBag.users = accountRepository.GetAll().Where(a => a.Role == "user").ToList();
                return View("User");
            }
            catch (Exception)
            {
                return RedirectToAction("error500", "error", new { area = "admin" });
            }

        }


    }
}