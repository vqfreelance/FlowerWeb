using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace JavaFlorist.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin/error")]
    public class ErrorController : Controller
    {
        [Route("")]
        [Route("error400")]
        public IActionResult Error400()
        {
            return View("Error400");
        }

        [Route("error500")]
        public IActionResult Error500()
        {
            return View("Error500");
        }
    }
}
