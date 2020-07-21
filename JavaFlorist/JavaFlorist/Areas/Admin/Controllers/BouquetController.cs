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
        private readonly IWebHostEnvironment iwebHostEnvironment;
        private IBouquetRepository bouquetRepository;

        public BouquetController(IWebHostEnvironment _iwebHostEnvironment, IBouquetRepository _bouquetRepository)
        {          
            iwebHostEnvironment = _iwebHostEnvironment;
            bouquetRepository = _bouquetRepository;
        }


        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            ViewBag.bouquets = bouquetRepository.GetAll().ToList();
            return View();
        }

        [HttpPost]
        [Route("searchByKeyword")]
        public IActionResult Search(string keyword)
        {
            ViewBag.bouquets = bouquetRepository.Search(keyword).ToList();
            ViewBag.keyword = keyword;
            return View("Index");
        }

        [HttpPost]
        [Route("upload")]
        public async Task<IActionResult> Upload(IFormFile[] images)
        {
           
            if (images == null || images.Length==0)
            {
                ViewBag.noimageerror = "Please select at least 1 image";
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
                ViewBag.uploaded = "Upload images successfully!";                
            }
            return View("Index");
        }
    }
}