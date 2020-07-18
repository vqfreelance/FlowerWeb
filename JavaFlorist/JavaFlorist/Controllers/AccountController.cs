using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using JavaFlorist.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JavaFlorist.Controllers
{
    [Route("account")]
    public class AccountController : Controller
    {
        private DatabaseContext db;
        public AccountController(DatabaseContext _db) => db = _db;

        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login(string customer_username, string customer_password)
        {
            try
            {
                if (customer_username == "abc" && customer_password == "123")
                {
                    //HttpContext.Session.SetString("user", a.Username);
                    return RedirectToAction("index", "home");
                }
                else
                {
                    ViewBag.error = "check your username and password again!";
                    return RedirectToAction("index", "home");
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return View("index", "home");
            }
        }

        [HttpGet]
        [Route("login")]
        public IActionResult Login()
        {
            return View("Login");
        }

        [HttpGet]
        [Route("signup")]
        public IActionResult Signup()
        {
            return View("Signup");
        }
    }
}