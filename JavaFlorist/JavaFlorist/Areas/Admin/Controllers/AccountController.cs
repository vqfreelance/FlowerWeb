using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace JavaFlorist.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin/account")]
    public class AccountController : Controller
    {
        [Route("")]
        [Route("login")]
        public IActionResult Login()
        {
            return View();
        }

      
        [Route("register")]
        public IActionResult Register()
        {
            return View();
        }

        
        [Route("forgotpassword")]
        public IActionResult ForgotPassword()
        {
            return View();
        }
    }
}