using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using JavaFlorist.Models;
using JavaFlorist.Models.Repositories;
using JavaFlorist.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
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
        private readonly IWebHostEnvironment iwebHostEnvironment;
        private SecurityManager securityManager = new SecurityManager();
        public AccountController(DatabaseContext _db,
            IAccountRepository _accountRepository,
            IWebHostEnvironment _iwebHostEnvironment)
        {
            db = _db;
            accountRepository = _accountRepository;
            iwebHostEnvironment = _iwebHostEnvironment;
        }

        // Login
        [AllowAnonymousAttribute]
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
                var account = db.Account.SingleOrDefault(a => a.Username.Equals(admin_username));
                securityManager.SignIn(HttpContext, account);
                HttpContext.Session.SetString("username", admin_username);
                HttpContext.Session.SetString("photo", account.Photo);
                HttpContext.Session.SetString("name", account.Name);
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
            try
            {
                var username = HttpContext.Session.GetString("username");
                var account = accountRepository.GetByUsername(username);
                ViewBag.account = account;
                return View("profile", account);
            }
            catch (Exception)
            {
                return RedirectToAction("error500", "error", new { area = "admin" });
            }
            
        }

        [HttpPost]
        [Route("profile")]
        public async Task<IActionResult> EditProfile(string newname, 
            string newemail, string newphone, string newaddress, IFormFile photo)
        {
            try
            {
                var username = HttpContext.Session.GetString("username");
                var account = accountRepository.GetByUsername(username);
                account.Name = newname;
                account.Email = newemail;
                account.Phone = newphone;
                account.Address = newaddress;
                if (photo != null)
                {
                    Debug.WriteLine("File Name: " + photo.FileName);
                    Debug.WriteLine("File Size (byte): " + photo.Length);
                    Debug.WriteLine("File SizeType: " + photo.ContentType);
                    string path = Path.Combine(this.iwebHostEnvironment.WebRootPath, "images/user", photo.FileName);
                    photo.CopyTo(new FileStream(path, FileMode.Create));
                    account.Photo = photo.FileName;
                    HttpContext.Session.SetString("photo", account.Photo);
                }
                await accountRepository.Update(account.Id, account);
                return RedirectToAction("profile", "account");
            }
            catch (Exception)
            {
                return RedirectToAction("error500", "error", new { area = "admin" });
            }
            
        }

        // Change Password
        [HttpPost]
        [Route("changepassword")]
        public async Task<IActionResult> ChangePassword(string oldpassword, 
            string newpassword, string retypepassword)
        {
            try
            {
                var username = HttpContext.Session.GetString("username");
                var account = accountRepository.GetByUsername(username);

                if (newpassword == retypepassword &&
                    BCrypt.Net.BCrypt.Verify(oldpassword, account.Password))
                {
                    account.Password = BCrypt.Net.BCrypt.HashPassword(newpassword);
                    await accountRepository.Update(account.Id, account);
                }
                return RedirectToAction("profile", "account");
            }
            catch (Exception)
            {
                return RedirectToAction("error500", "error", new { area = "admin" });
            }
            
        }

        //logout
        [Route("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("username");
            HttpContext.Session.Remove("photo");
            HttpContext.Session.Remove("name");
            HttpContext.Session.Remove("searchBouquets");
            HttpContext.Session.Remove("searchOccasions");
            HttpContext.Session.Remove("searchMessages");
            securityManager.SignOut(HttpContext);
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
            try
            {
                account.Role = "admin";
                account.Password = BCrypt.Net.BCrypt.HashPassword(account.Password);
                await accountRepository.Create(account);

                Debug.WriteLine("Account Info");
                Debug.WriteLine("Username: " + account.Username);
                Debug.WriteLine("Password: " + account.Password);
                Debug.WriteLine("Email: " + account.Email);
                Debug.WriteLine("Phone: " + account.Phone);
                Debug.WriteLine("Role: " + account.Role);

                return RedirectToAction("login");
            }
            catch (Exception)
            {
                return RedirectToAction("error500", "error", new { area = "admin" });
            }
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

    }
}