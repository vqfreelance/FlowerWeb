using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using JavaFlorist.Models;
using JavaFlorist.Models.Repositories;
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
        public CartController(DatabaseContext _db, IBouquetRepository _bouquetRepository)
        {
            db = _db;
            bouquetRepository = _bouquetRepository;
        }

        [Route("index")]
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("cart") != null)
            {
                //Debug.WriteLine("Cart: " + HttpContext.Session.GetString("cart"));
                List<Item> cart = JsonConvert.DeserializeObject<List<Item>>(HttpContext.Session.GetString("cart"));
                if(cart.Count >0)
                {
                    ViewBag.total = cart.Sum(i => i.Quantity * i.Bouquet.Price);
                    ViewBag.cart = cart;
                }
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
                    cart[index].Quantity = cart[index].Quantity+quantity;
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
            return null;
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

        [Route("checkout")]
        public IActionResult Checkout()
        {
            return View("Checkout");
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
            var i = JsonConvert.DeserializeObject<List<Item>>(HttpContext.Session.GetString("cart")).Sum(i => i.Quantity);
            return new JsonResult(i.ToString());
        }
    }
}