using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JavaFlorist.Models;
using JavaFlorist.Models.Repositories;
using JavaFlorist.PayPal;
using Microsoft.AspNetCore.Mvc;

namespace JavaFlorist.ViewComponents
{
    [ViewComponent(Name = "BouquetList")]
    public class BouquetListViewComponent : ViewComponent
    {
        private DatabaseContext db;
        private IBouquetRepository bouquetRepository;
        public BouquetListViewComponent(DatabaseContext _db, IBouquetRepository _bouquetRepository)
        {
            db = _db;
            bouquetRepository = _bouquetRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewBag.paypalConfig = PayPalService.getPayPalConfig();
            return View("Index");
        }
    }
}
