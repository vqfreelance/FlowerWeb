using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using JavaFlorist.Models;
using JavaFlorist.Models.Repositories;

namespace JavaFlorist.ViewComponents
{
    [ViewComponent(Name = "HomeBar")]
    public class HomeBarViewComponent : ViewComponent
    {
        private DatabaseContext db;
        private IAccountRepository accountRepository;
        private IOccasionRepository occasionRepository;
        public HomeBarViewComponent(DatabaseContext _db, IAccountRepository _accountRepository, IOccasionRepository _occasionRepository)
        {
            db = _db;
            accountRepository = _accountRepository;
            occasionRepository = _occasionRepository;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            if (HttpContext.User.FindFirst(ClaimTypes.Name) != null) 
            {
                var username = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
                ViewBag.occasions = occasionRepository.GetAll().ToList();
                ViewBag.acc = accountRepository.GetByUsername(username.Value);
                return View("Index2");
            } 
            else
            {
                ViewBag.occasions = occasionRepository.GetAll().ToList();
                return View("Index");
            }
            
        }
    }
}