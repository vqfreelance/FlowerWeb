using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using JavaFlorist.Models;
using JavaFlorist.Models.Repositories;
using JavaFlorist.PayPal;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


namespace JavaFlorist.Controllers
{
    [Route("cart")]
    public class CartController : Controller
    {
        private DatabaseContext db;
        private IBouquetRepository bouquetRepository;
        private IAccountRepository accountRepository;
        private IOccasionRepository occasionRepository;
        private IMessageRepository messageRepository;
        private IOrderRepository orderRepository;
        private IOrderDetailRepository orderdetailRepository;
        private ICustomerRepository customerRepository;

        public CartController(DatabaseContext _db,
            IBouquetRepository _bouquetRepository,
            IAccountRepository _accountRepository,
            IOccasionRepository _occasionRepository,
            IMessageRepository _messageRepository,
            IOrderRepository _orderRepository,
            IOrderDetailRepository _orderdetailRepository,
            ICustomerRepository _customerRepository
            )
        {
            db = _db;
            bouquetRepository = _bouquetRepository;
            accountRepository = _accountRepository;
            occasionRepository = _occasionRepository;
            messageRepository = _messageRepository;
            orderRepository = _orderRepository;
            orderdetailRepository = _orderdetailRepository;
            customerRepository = _customerRepository;

        }

        [Route("index")]
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("cart") != null)
            {
                //Debug.WriteLine("Cart: " + HttpContext.Session.GetString("cart"));
                List<Item> cart = JsonConvert.DeserializeObject<List<Item>>(HttpContext.Session.GetString("cart"));
                if (cart.Count > 0)
                {
                    ViewBag.totalqty = cart.Sum(i => i.Quantity);
                    ViewBag.total = cart.Sum(i => i.Quantity * i.Bouquet.Price);
                    ViewBag.cart = cart;
                }
                ViewBag.paypalConfig = PayPalService.getPayPalConfig();
            }
            return View();
        }

        [Route("buy/{id}")]
        public IActionResult Buy(int id)
        {
            var bouquet = db.Bouquet.Find(id);
            if (HttpContext.Session.GetString("cart") == null)
            {
                List<Item> cart = new List<Item>();
                cart.Add(new Item { Bouquet = bouquet, Quantity = 1 });
                HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(cart));
            }
            else
            {
                List<Item> cart = JsonConvert.DeserializeObject<List<Item>>(HttpContext.Session.GetString("cart"));
                int index = exists(id, cart);
                if (index == -1)
                {
                    cart.Add(new Item { Bouquet = bouquet, Quantity = 1 });
                }
                else
                {
                    cart[index].Quantity++;
                }
                HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(cart));

            }
            return RedirectToAction("index", "cart");
        }

        [Route("buynow")]
        public IActionResult BuyNow(int bouquetid, int quantity)
        {
            var bouquet = db.Bouquet.Find(bouquetid);
            if (HttpContext.Session.GetString("cart") == null)
            {
                List<Item> cart = new List<Item>();
                cart.Add(new Item { Bouquet = bouquet, Quantity = quantity });
                HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(cart, new JsonSerializerSettings()
                {
                    PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                    Formatting = Formatting.Indented
                }));
            }
            else
            {
                List<Item> cart = JsonConvert.DeserializeObject<List<Item>>(HttpContext.Session.GetString("cart"));
                int index = exists(bouquet.Id, cart);
                if (index == -1)
                {
                    cart.Add(new Item { Bouquet = bouquet, Quantity = quantity });
                }
                else
                {
                    cart[index].Quantity = cart[index].Quantity + quantity;
                }
                HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(cart, new JsonSerializerSettings()
                {
                    PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                    Formatting = Formatting.Indented
                }));

            }
            return Json(Url.Action("index", "cart"));
        }

        [Route("addcart")]
        public IActionResult AddCart(int bouquetid, int quantity)
        {
            var bouquet = db.Bouquet.Find(bouquetid);
            List<Item> cart = new List<Item>();
            if (HttpContext.Session.GetString("cart") == null)
            {
                cart.Add(new Item { Bouquet = bouquet, Quantity = quantity });
                HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(cart, new JsonSerializerSettings()
                {
                    PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                    Formatting = Formatting.Indented
                }));
            }
            else
            {
                cart = JsonConvert.DeserializeObject<List<Item>>(HttpContext.Session.GetString("cart"));
                int index = exists(bouquet.Id, cart);
                if (index == -1)
                {
                    cart.Add(new Item { Bouquet = bouquet, Quantity = quantity });
                }
                else
                {
                    cart[index].Quantity = cart[index].Quantity + quantity;
                }
                HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(cart, new JsonSerializerSettings()
                {
                    PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                    Formatting = Formatting.Indented
                }));
            }

            var result = new
            {
                cart_num = cart.Sum(i => i.Quantity),
            };
            return new JsonResult(result);
        }

        [Route("touchspincart")]
        public IActionResult TouchSpinCart(int bouquetid, int quantity)
        {
            if (bouquetid > 0)
            {
                var bouquet = db.Bouquet.Find(bouquetid);

                var cart = JsonConvert.DeserializeObject<List<Item>>(HttpContext.Session.GetString("cart"));
                int index = exists(bouquet.Id, cart);
                if (cart[index].Quantity + quantity < 1)
                {
                    cart[index].Quantity = 1;
                }
                else
                {
                    cart[index].Quantity = cart[index].Quantity + quantity;
                }

                HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(cart, new JsonSerializerSettings()
                {
                    PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                    Formatting = Formatting.Indented
                }));

                var result = new
                {
                    cart_num = cart.Sum(i => i.Quantity),
                    cart_total = cart.Sum(i => i.Quantity * i.Bouquet.Price).ToString("C", CultureInfo.CurrentCulture),
                    bouquet_total = (cart[index].Quantity * cart[index].Bouquet.Price).ToString("C", CultureInfo.CurrentCulture)

                };
                return new JsonResult(result);
            }
            else
            {
                return null;
            }

        }

        [Route("remove/{id}")]
        public IActionResult Remove(int id)
        {
            List<Item> cart = JsonConvert.DeserializeObject<List<Item>>(HttpContext.Session.GetString("cart"));
            int index = exists(id, cart);
            cart.RemoveAt(index);
            HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(cart, new JsonSerializerSettings()
            {
                PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                Formatting = Formatting.Indented
            }));
            return RedirectToAction("index", "cart");
        }

        [HttpPost]
        [Route("update")]
        public IActionResult Update(int[] quantity)
        {
            List<Item> cart = JsonConvert.DeserializeObject<List<Item>>(HttpContext.Session.GetString("cart"));
            for (int i = 0; i < cart.Count; i++)
            {
                cart[i].Quantity = quantity[i];
            }
            HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(cart, new JsonSerializerSettings()
            {
                PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                Formatting = Formatting.Indented
            }));
            return RedirectToAction("index", "cart");
        }

        [Authorize(Roles = "user")]
        [HttpGet]
        [Route("checkout")]
        public IActionResult Checkout()
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

            List<Item> cart = JsonConvert.DeserializeObject<List<Item>>(HttpContext.Session.GetString("cart"));
            var username = User.FindFirst(ClaimTypes.NameIdentifier);
            ViewBag.acc = accountRepository.GetByUsername(username.Value);
            ViewBag.occ = occasionRepository.GetAll().ToList();
            ViewBag.total = cart.Sum(i => i.Quantity * i.Bouquet.Price);
            ViewBag.cart = cart;
            ViewBag.time = time.ToString("MM/dd/yyyy, HH:mm");
            return View("Checkout");
        }

        [Authorize(Roles = "user")]
        [Route("pay")]
        public async Task<IActionResult> Pay(
            string sender_name,
            string sender_email,
            string sender_phone,
            string sender_address,
            string receiver_name,
            string receiver_email,
            string receiver_phone,
            string receiver_address,
            string message,
            string time_type,
            string receivingtime,
            string receiving5hours,
            string payment)
        {
            var sender = new Customer { Name = sender_name, Phone = sender_phone, Email = sender_email, Address = sender_address };
            var receiver = new Customer { Name = receiver_name, Phone = receiver_phone, Email = receiver_email, Address = receiver_address };
            List<Item> cart = JsonConvert.DeserializeObject<List<Item>>(HttpContext.Session.GetString("cart"));
            var username = User.FindFirst(ClaimTypes.NameIdentifier);
            var acc = accountRepository.GetByUsername(username.Value);
            var order = new Order();
            try
            {
                if (sender.Name != null) { await customerRepository.Create(sender); };
                if (receiver.Name != null) { await customerRepository.Create(receiver); };
                order = new Order
                {
                    AccountId = acc.Id,
                    SenderId = sender != null ? sender.Id : 0,
                    ReceiverId = receiver != null ? receiver.Id : 0,
                    Status = "pending",
                    Message = message,
                    CreateDate = DateTime.Now,
                    ReceivingTime = time_type == "ctime" ? receivingtime : receiving5hours,
                    Payment = payment
                };
                await orderRepository.Create(order);
                foreach (var c in cart)
                {
                    var od = new OrderDetail
                    {
                        OrderId = order.Id,
                        BouquetId = c.Bouquet.Id,
                        Quantity = c.Quantity
                    };
                    await orderdetailRepository.Create(od);
                };

                HttpContext.Session.Remove("cart");
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }

            return Json(Url.Action("vieworderdetail", "account", new { id = order.Id }));
        }

        [Route("getallmess")]
        public IActionResult GetAllMess(int id)
        {
            //Occasion occ = await occasionRepository.GetById(id);
            //var mess = db.Message.Where(m => m.OccasionId == id).ToList();
            return new JsonResult(db.Message.Where(m => m.OccasionId == id).ToList());
        }

        private int exists(int id, List<Item> cart)
        {
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].Bouquet.Id == id)
                {
                    return i;
                }
            }
            return -1;
        }

        [Route("countcart")]
        public IActionResult countCart()
        {
            var cart = HttpContext.Session.GetString("cart");
            if (cart != null)
            {
                return new JsonResult(JsonConvert.DeserializeObject<List<Item>>(cart).Sum(i => i.Quantity));
            }
            else
            {
                return null;
            }
        }

        [Route("carterror")]
        public IActionResult CartError()
        {
            return View("OrderError");
        }

        [Route("success1")]
        public IActionResult Success1()
        {
            return View("Success");
        }
    }
}