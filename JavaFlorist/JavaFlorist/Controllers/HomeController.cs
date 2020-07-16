using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace JavaFlorist.Controllers
{
    [Route("index")]
    public class HomeController : Controller
    {
        [Route("")]
        [Route("home")]
        [Route("~/")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
