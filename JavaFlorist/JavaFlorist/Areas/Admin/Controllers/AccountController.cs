using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using JavaFlorist.Models;
using JavaFlorist.Models.Repositories;
using JavaFlorist.Security;
using Microsoft.AspNetCore.Http;
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
            return View("login", account);
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login(string admin_username, string admin_password)
        {
            if (Check(admin_username, admin_password) != null)
            {
                var a = db.Account.SingleOrDefault(a => a.Username.Equals(admin_username));
                securityManager.SignIn(HttpContext, a);
                HttpContext.Session.SetString("username", admin_username);               
                return RedirectToAction("index", "dashboard");
            }
            else
            {
                ViewBag.loginerror = "Invalid! Username or Password is incorrect!";
                return View("login");
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
        // Edit profile
        [HttpGet]
        [Route("profile")]
        public IActionResult EditProfile()
        {
            var username = HttpContext.Session.GetString("username");
            var account = accountRepository.GetByUsername(username);
            ViewBag.account = account;
            return View("profile", account);
        }

        [HttpPost]
        [Route("profile")]
        public async Task<IActionResult> EditProfile(string newname, 
            string newemail, string newphone, string newaddress)
        {
            var username = HttpContext.Session.GetString("username");
            var account = accountRepository.GetByUsername(username);
            account.Name = newname;
            account.Email = newemail;
            account.Phone = newphone;
            account.Address = newaddress;
            await accountRepository.Update(account.Id, account);
            return RedirectToAction("profile", "account");
        }

        // Change Password
        [HttpPost]
        [Route("changepassword")]
        public async Task<IActionResult> ChangePassword(string oldpassword, 
            string newpassword, string retypepassword)
        {
            var username = HttpContext.Session.GetString("username");
            var account = accountRepository.GetByUsername(username); 

            if (newpassword == oldpassword && 
                BCrypt.Net.BCrypt.Verify(oldpassword, account.Password))
            {
                account.Password = BCrypt.Net.BCrypt.HashPassword(newpassword);
                await accountRepository.Update(account.Id, account);
            }
            return RedirectToAction("profile", "account");
        }

        //logout
        [Route("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("username");
            return RedirectToAction("login", "account");
        }

        //Register
        [HttpGet]
        [Route("register")]
        public IActionResult Register()
        {
            var account = new Account();
            return View("register", account);
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(Account account)
        {
            account.Role = "admin";
            account.Password = BCrypt.Net.BCrypt.HashPassword(account.Password);
            try
            {
                await accountRepository.Create(account);
            }
            catch (Exception e)
            {
                return RedirectToAction("error500", "error", new { area = "admin" });
            }
            Debug.WriteLine("Account Info");
            Debug.WriteLine("Username: " + account.Username);
            Debug.WriteLine("Password: " + account.Password);
            Debug.WriteLine("Email: " + account.Email);
            Debug.WriteLine("Phone: " + account.Phone);
            Debug.WriteLine("Role: " + account.Role);

            return RedirectToAction("login");
        }

        // Forgot Password
        [HttpGet]
        [Route("forgotpassword")]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [Route("forgotpassword")]
        public IActionResult ForgotPassword(string email)
        {
            var user = db.Account.SingleOrDefault(a => a.Email.Equals(email));           
            return View();
        }

        // Recovery Password
        [HttpGet]
        [Route("recoverypassword")]
        public IActionResult RecoveryPassword()
        {
            return View();
        }

        
    }
}