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
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;

namespace JavaFlorist.Controllers
{
    [Route("account")]
    public class AccountController : Controller
    {
        private DatabaseContext db;
        private IAccountRepository accountRepository;
        private IOrderRepository orderRepository;
        private IOrderDetailRepository orderdetailRepository;
        private ICustomerRepository customerRepository;
        private IBouquetRepository bouquetRepository;

        public AccountController(DatabaseContext _db, 
            IAccountRepository _accountRepository,
            IOrderRepository _orderRepository,
            IOrderDetailRepository _orderdetailRepository,
            ICustomerRepository _customerRepository,
            IBouquetRepository _bouquetRepository )
        {
            db = _db;
            accountRepository = _accountRepository;
            orderRepository = _orderRepository;
            orderdetailRepository = _orderdetailRepository;
            customerRepository = _customerRepository;
            bouquetRepository = _bouquetRepository;
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
                if (HttpContext.Session.GetString("cart") != null)
                {
                    List<Item> cart = JsonConvert.DeserializeObject<List<Item>>(HttpContext.Session.GetString("cart"));
                    if (cart.Count > 0)
                    {
                        ViewBag.total = cart.Sum(i => i.Quantity * i.Bouquet.Price);
                        ViewBag.cart = cart;
                        return RedirectToAction("index", "cart");
                    }
                }
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
                ViewBag.address = acc.Address;
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

        [Authorize(Roles = "user")]
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

        [Authorize(Roles = "user")]
        [HttpGet]
        [Route("info/{username}")]
        public IActionResult Info(string username)
        {
            ViewBag.acc = accountRepository.GetByUsername(username);
            return View("Info");
        }

        [Authorize(Roles = "user")]
        [HttpGet]
        [Route("editaccount/{id}")]
        public IActionResult EditAccout(int id)
        {
            var acc = accountRepository.GetAccById(id);
            return View("Edit", acc);
        }

        [Authorize(Roles = "user")]
        [HttpPost]
        [Route("editaccount/{id}")]
        public async Task<IActionResult> EditAccout(int id,Account acc)
        {
            //acc.Password = BCrypt.Net.BCrypt.HashPassword(acc.Password);
            var oldInfo = accountRepository.GetAccById(id);
            oldInfo.Name = acc.Name;
            oldInfo.Phone = acc.Phone;
            oldInfo.Email = acc.Email;
            oldInfo.Address = acc.Address;
            try
            {
                await accountRepository.Update(id,oldInfo);
            }
            catch (Exception e)
            {

            }
            return RedirectToAction("index", "home");
        }

        [Authorize(Roles = "user")]
        [HttpGet]
        [Route("changepass/{id}")]
        public IActionResult ChangePassword(int id)
        {
            var acc = accountRepository.GetAccById(id);
            return View("ChangePass", acc);
        }

        [Authorize(Roles = "user")]
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

        [Authorize(Roles = "user")]
        [HttpGet]
        [Route("vieworderdetail/{id}")]
        public async Task<IActionResult> ViewOrderDetail(int id)
        {
            var username = User.FindFirst(ClaimTypes.NameIdentifier);
            var acc = accountRepository.GetByUsername(username.Value);
            var order = await orderRepository.GetById(id);
            var sender = new Customer();
            if (order !=null && order.SenderId > 0)
            {
                sender = await customerRepository.GetById(order.SenderId);
            }
            var receiver = new Customer();
            if (order != null && order.ReceiverId > 0)
            {
                receiver = await customerRepository.GetById(order.ReceiverId);
            }
            var a =  await orderRepository.GetByIdNoTracking(id);
            var cart = new List<Item>();
            //foreach (var b in db.OrderDetail.Where(a=>a.OrderId==id).ToList())
            if (a != null)
            {
                foreach (var b in a.OrderDetail.ToList())
                {
                    var item = new Item
                    {
                        Bouquet = await bouquetRepository.GetById(b.BouquetId),
                        Quantity = b.Quantity
                    };
                    cart.Add(item);
                }
            }


            ViewBag.acc = acc;
            ViewBag.sender = sender;
            ViewBag.receiver = receiver;
            ViewBag.cart = cart;
            ViewBag.order = order;

            return View("OrderHistory");
        }

        [Authorize(Roles = "user")]
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