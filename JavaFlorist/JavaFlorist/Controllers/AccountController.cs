using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using JavaFlorist.Security;
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

        private SecurityManager securityManager = new SecurityManager();

        [HttpPost]
        [Route("login")]
        public IActionResult Login(string customer_username, string customer_password)
        {
            var countAccount = db.Account.Count(a => a.Username.Equals(customer_username) && a.Password.Equals(customer_password));
            if (countAccount == 1)
            {
                var a = db.Account.SingleOrDefault(a => a.Username.Equals(customer_username));
                securityManager.SignIn(HttpContext, a);
                return RedirectToAction("index", "home");
            }
            else
            {
                ViewBag.customer_username = customer_username;
                ViewBag.customer_password = customer_password;
                ViewBag.error = "check your username and password again!";
                return View("Login");
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

        [Route("logout")]
        public IActionResult Logout()
        {
            securityManager.SignOut(HttpContext);
            return RedirectToAction("login", "account");
        }

        private Account Check(string username, string password)
        {
            var acc = db.Account.SingleOrDefault(a => a.Username.Equals(username));
            if (acc != null)
            {
                if (BCrypt.Net.BCrypt.Verify(password, acc.Password))
                {
                    return acc;
                }
            }
            return null;
        }
    }
}