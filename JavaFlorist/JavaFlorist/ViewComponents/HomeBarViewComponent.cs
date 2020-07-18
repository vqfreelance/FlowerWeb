using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace JavaFlorist.ViewComponents
{
    [ViewComponent(Name = "HomeBar")]
    public class HomeBarViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            if (HttpContext.User.FindFirst(ClaimTypes.Name) != null) 
            {
                return View("Index2");
            } 
            else
            {
                return View("Index");
            }
            
        }
    }
}