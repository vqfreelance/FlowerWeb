﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JavaFlorist.Models;
using JavaFlorist.Models.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace JavaFlorist.ViewComponents
{
    [ViewComponent(Name = "Sender")]
    public class SenderViewComponent : ViewComponent
    {
        private DatabaseContext db;
        public SenderViewComponent(DatabaseContext _db)
        {
            db = _db;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("Index");
        }
    }
}
