using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using JavaFlorist.Security;
using JavaFlorist.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using JavaFlorist.Models.Repositories;
using System.Security.Claims;

namespace JavaFlorist.Controllers
{
    [Route("account")]
    public class AccountController : Controller
    {
        private DatabaseContext db;
        private IAccountRepository accountRepository;
        public AccountController(DatabaseContext _db, IAccountRepository _accountRepository)
        {
            db = _db;
            accountRepository = _accountRepository;
        }

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
            var acc = new Account();
            return View("Signup",acc);
        }

        [HttpPost]
        [Route("signup")]
        public async Task<IActionResult> Signup(Account acc)
        {
            //acc.Password = BCrypt.Net.BCrypt.HashPassword(acc.Password);
            acc.Role = "user";
            try
            {
                await accountRepository.Create(acc);
            }
            catch (Exception e)
            {
                ViewBag.name = acc.Name;
                ViewBag.username = acc.Username;
                ViewBag.phone = acc.Phone;
                ViewBag.email = acc.Email;
                ViewBag.error = "check your infomation again!";
                return View("Signup");
            }
            return RedirectToAction("index", "home");
        }

        //check username exist
        [HttpPost]
        [Route("checkusername")]
        public bool CheckUserName(string username)
        {
            if (accountRepository.CheckByUsername(username))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        [HttpPost]
        [Route("checkuserpass")]
        public bool CheckUserPass(string id, string oldpass)
        {
            var acc = accountRepository.GetAccById(int.Parse(id));
            if (acc.Password != oldpass)
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        [HttpGet]
        [Route("info/{username}")]
        public IActionResult Info(string username)
        {
            ViewBag.acc = accountRepository.GetByUsername(username);
            return View("Info");
        }

        [HttpGet]
        [Route("editaccount/{id}")]
        public IActionResult EditAccout(int id)
        {
            var acc = accountRepository.GetAccById(id);
            return View("Edit", acc);
        }

        [HttpPost]
        [Route("editaccount/{id}")]
        public async Task<IActionResult> EditAccout(int id,Account acc)
        {
            //acc.Password = BCrypt.Net.BCrypt.HashPassword(acc.Password);
            var oldInfo = accountRepository.GetAccById(id);
            oldInfo.Name = acc.Name;
            oldInfo.Phone = acc.Phone;
            oldInfo.Email = acc.Email;
            try
            {
                await accountRepository.Update(id,oldInfo);
            }
            catch (Exception e)
            {

            }
            return RedirectToAction("index", "home");
        }

        [HttpGet]
        [Route("changepass/{id}")]
        public IActionResult ChangePassword(int id)
        {
            var acc = accountRepository.GetAccById(id);
            return View("ChangePass", acc);
        }

        [HttpPost]
        [Route("changepass/{id}")]
        public async Task<IActionResult> ChangePassword(int id, Account acc)
        {
            //acc.Password = BCrypt.Net.BCrypt.HashPassword(acc.Password);
            var oldInfo = accountRepository.GetAccById(id);
            oldInfo.Password = acc.Password;
            try
            {
                await accountRepository.Update(id, oldInfo);
            }
            catch (Exception e)
            {

            }
            return RedirectToAction("index", "home");
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