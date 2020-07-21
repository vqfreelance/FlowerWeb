using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using JavaFlorist.Models;
using JavaFlorist.Models.Repositories;
using JavaFlorist.Security;
using Microsoft.AspNetCore.Mvc;

namespace JavaFlorist.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin/account")]
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

        // Login
        [Route("")]
        [HttpGet]
        [Route("login")]
        public IActionResult Login()
        {
            var account = new Account();
            return View("Login", account);
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login(string admin_username, string admin_password)
        {
            var countAccount = db.Account.Count(a => a.Username.Equals(admin_username) && a.Password.Equals(admin_password));
            if (countAccount == 1)
            {
                var a = db.Account.SingleOrDefault(a => a.Username.Equals(admin_username));
                securityManager.SignIn(HttpContext, a);
                TempData["Username"] = admin_username;
                return RedirectToAction("index", "dashboard");
            }
            else
            {
                ViewBag.loginerror = "Invalid! Username or Password is incorrect!";
                return View("Login");
            }
        }

        private Account Check(string username, string password)
        {
            var account = db.Account.SingleOrDefault(a => a.Username.Equals(username));
            if (account != null)
            {
                if (BCrypt.Net.BCrypt.Verify(password, account.Password))
                {
                    return account;
                }
            }
            return null;
        }

        //Register
        [Route("register")]
        public IActionResult Register()
        {
            var account = new Account()
            { 
                Role = "admin"
            };
            return View("Register", account);
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(Account account)
        {
            account.Role = "admin";
            try
            {
                await accountRepository.Create(account);
            }
            catch (Exception e)
            {
                throw e;
            }
            Debug.WriteLine("Account Info");
            Debug.WriteLine("Username: " + account.Username);
            Debug.WriteLine("Password: " + account.Password);
            string hash = BCrypt.Net.BCrypt.HashPassword(account.Password);
            Debug.WriteLine("Hash: " + hash);
            Debug.WriteLine("Email: " + account.Email);
            Debug.WriteLine("Phone: " + account.Phone);
            Debug.WriteLine("Role: " + account.Role);

            return RedirectToAction("Login");
        }

        // Forgot Password
        [Route("forgotpassword")]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        // Change Password
        [Route("changepassword")]
        public IActionResult ChangePassword()
        {
            return View();
        }
    }
}