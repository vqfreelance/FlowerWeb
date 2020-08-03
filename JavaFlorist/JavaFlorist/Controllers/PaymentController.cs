using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JavaFlorist.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace JavaFlorist.Controllers
{
    [Route("payment")]
    public class PaymentController : Controller
    {
        [Route("index")]
        [Route("")]
        
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
            }
            return View();
        }
    }
}
