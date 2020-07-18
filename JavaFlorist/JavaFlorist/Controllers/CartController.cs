using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace JavaFlorist.Controllers
{
    [Route("cart")]
    public class CartController : Controller
    {
        [Route("index")]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("checkout")]
        public IActionResult Checkout()
        {
            return View("Checkout");
        }
    }
}