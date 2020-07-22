using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using JavaFlorist.Models;
using JavaFlorist.Models.Repositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JavaFlorist.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin/bouquet")]
    public class BouquetController : Controller
    {
        private DatabaseContext db;
        private readonly IWebHostEnvironment iwebHostEnvironment;
        private IBouquetRepository bouquetRepository;

        public BouquetController(DatabaseContext _db, 
            IWebHostEnvironment _iwebHostEnvironment, IBouquetRepository _bouquetRepository)
        {
            db = _db;
            iwebHostEnvironment = _iwebHostEnvironment;
            bouquetRepository = _bouquetRepository;
        }


        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            ViewBag.bouquets = bouquetRepository.GetAll().ToList();
            ViewBag.noimageerror = TempData["NoImage"];
            ViewBag.uploaded = TempData["Uploaded"];
            return View();
        }

        //Search bouquest by keyword
        [HttpPost]
        [Route("searchByKeyword")]
        public IActionResult Search(string keyword)
        {
            ViewBag.bouquets = bouquetRepository.Search(keyword).ToList();
            ViewBag.keyword = keyword;           
            return RedirectToAction("Index");
        }

        //Upload bouquets
        [HttpPost]
        [Route("upload")]
        public async Task<IActionResult> Upload(IFormFile[] images)
        {
           
            if (images.Count() == 0 || images.Length==0)
            {
                TempData["NoImage"] = "Please select at least 1 image";
            }
            else
            {
                foreach (var i in images)
                {
                    var bouquet = new Bouquet();
                    string imgname = Path.GetFileNameWithoutExtension(i.FileName);
                   
                    Debug.WriteLine("File Name: " + i.FileName);
                    Debug.WriteLine("File Size (byte): " + i.Length);
                    Debug.WriteLine("File SizeType: " + i.ContentType);
                    string path = Path.Combine(this.iwebHostEnvironment.WebRootPath, "images/bouquets", i.FileName);
                    i.CopyTo(new FileStream(path, FileMode.Create));
                    Debug.WriteLine("================");
                    bouquet.Name = imgname;
                    bouquet.Photo = i.FileName;
                    bouquet.Status = false;
                    try
                    {
                        await bouquetRepository.Create(bouquet);
                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                }
                TempData["Uploaded"] = "Upload images successfully!";                
            }
            return RedirectToAction("Index");
        }

        //Edit Bouquets
        [HttpGet]
        [Route("edit/{id}")]
        public IActionResult Edit(int id)
        {
            var bouquet = db.Bouquet.Find(id);
            return View("Edit", bouquet);
        }

        [HttpPost]
        [Route("edit/{id}")]
        public IActionResult Edit(Bouquet bouquet)
        {           
            db.Entry(bouquet).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("index", "bouquet");
        }

        //Delete Bouquet
        [Route("delete/{id}")]
        public IActionResult Delete(int id)
        {
            db.Bouquet.Remove(db.Bouquet.Find(id));
            db.SaveChanges();
            return RedirectToAction("index", "bouquet");
        }
    }
}