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
using JavaFlorist.PayPal;

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
            if(order != null) {
                if(acc.Id == order.AccountId)
                {
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
                    var a =  await orderRepository.GetByIdIncludeRelationship(id);
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
                    ViewBag.sum = (cart.Sum(i => i.Quantity * i.Bouquet.Price));
                    ViewBag.ship = receiver.Name == null ? 0 : 5;
                    ViewBag.total = receiver.Name == null ? (cart.Sum(i => i.Quantity * i.Bouquet.Price)) : (cart.Sum(i => i.Quantity * i.Bouquet.Price)) + 5;

                    if (order.Payment == "paypal" && order.PaymentConfirm == null)
                    {
                        ViewBag.paypalConfig = PayPalService.getPayPalConfig();
                        return View("PaypalConfirm");
                    } 
                    else
                    {
                        return View("OrderHistory");
                    }
                }
                else
                {
                    return RedirectToAction("carterror", "cart");
                }
            }
             else
            {
                return RedirectToAction("carterror", "cart");
            }
        }

        [HttpGet]
        [Route("paypalreturn/{id}")]
        public async Task<IActionResult> Success(int id,[FromQuery(Name = "tx")] string tx)
        {
            var time = DateTime.Now;
            var startday = time.Date + new TimeSpan(09, 00, 00);
            var endday = time.Date + new TimeSpan(21, 00, 00);

            if (time.AddHours(5) < startday)
            {
                time = time.Date + new TimeSpan(14, 00, 00);
            }
            else if (time.AddHours(5) > endday)
            {
                time = time.AddDays(1).Date + new TimeSpan(14, 00, 00);
            }
            else
            {
                time = time.AddHours(5);
            }

            //hung lai ket qua tu class PDTHolder
            var order = await orderRepository.GetById(id);
            try
            {
                order.PaymentConfirm = tx;
                order.ReceivingTime = time.ToString();
                order.Status = "paid";
                await orderRepository.Update(id,order);

            }
            catch (Exception e)
            {
                Debug.WriteLine(e);

            }
            //var result = PDTHolder.Success(tx);
            //ViewBag.result = result;

            //Debug.WriteLine("Transaction Details");
            //Debug.WriteLine("cart: " + result.PaymentStatus);
            //Debug.WriteLine("create_time: " + result.PayerFirstName);

            return RedirectToAction("vieworderdetail","account",new { id = id });

        }

        [Authorize(Roles = "user")]
        [HttpGet]
        [Route("vieworderlist")]
        public async Task<IActionResult> ViewOrderList()
        {
            var username = User.FindFirst(ClaimTypes.NameIdentifier);

            var acc = accountRepository.GetByUsername(username.Value);

            var a = await accountRepository.GetById2(acc.Id);

            var list = a.Order.ToList();
            var listorder = new List<ListOrder>();
            foreach (var o in list)
            {
                var aa = new ListOrder
                {
                    Order = o,
                    Total = o.SenderId == 0? o.OrderDetail.Sum(i=>i.Quantity * i.Bouquet.Price) : o.OrderDetail.Sum(i => i.Quantity * i.Bouquet.Price)+5
                };
                listorder.Add(aa);
            }

            ViewBag.listorder = listorder;
            return View("OrderList");
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