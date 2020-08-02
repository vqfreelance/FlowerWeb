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
    [Route("admin/occasion")]
    public class OccasionController : Controller
    {
        private IOccasionRepository occasionRepository;
        private readonly IWebHostEnvironment iwebHostEnvironment;
        public OccasionController(
            IOccasionRepository _occasionRepository,
            IWebHostEnvironment _iwebHostEnvironment)
        {
            occasionRepository = _occasionRepository;
            iwebHostEnvironment = _iwebHostEnvironment;
        }
        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            try
            {
                ViewBag.occasions = occasionRepository.GetAllIncludeRelationship().ToList();
                return View();
            }
            catch (Exception)
            {
                return RedirectToAction("error500", "error", new { area = "admin" });
            }          
        }

        //Search message by keyword
        [HttpPost]
        [Route("searchByKeyword")]
        public IActionResult Search(string keyword)
        {
            try
            {
                if (keyword != null)
                {
                    ViewBag.occasions = occasionRepository.Search(keyword).ToList();
                    ViewBag.keyword = keyword;
                }
                else
                {
                    ViewBag.occasions = occasionRepository.GetAllIncludeRelationship().ToList();
                }
                return View("Index");
            }
            catch (Exception)
            {
                return RedirectToAction("error500", "error", new { area = "admin" });
            }
        }

        //Create Occassion
        [HttpGet]
        [Route("create")]
        public IActionResult Create()
        {            
            return View();
        }
        
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create(Occasion occasion, IFormFile photo)
        {
            try
            {
                if (photo != null)
                {
                    Debug.WriteLine("File Name: " + photo.FileName);
                    Debug.WriteLine("File Size (byte): " + photo.Length);
                    Debug.WriteLine("File SizeType: " + photo.ContentType);
                    string path = Path.Combine(this.iwebHostEnvironment.WebRootPath, "images/occasions", photo.FileName);
                    photo.CopyTo(new FileStream(path, FileMode.Create));
                    occasion.Photo = photo.FileName;
                }
                await occasionRepository.Create(occasion);
                return RedirectToAction("index", "occasion");
            }
            catch (Exception)
            {
                return RedirectToAction("error500", "error", new { area = "admin" });
            }
            
        }

        //Edit Occasion
        [HttpGet]
        [Route("edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var occasion = await occasionRepository.GetByIdIncludeRelationship(id);
                ViewBag.occPhoto = occasion.Photo;
                return View("edit", occasion);
            }
            catch (Exception)
            {
                return RedirectToAction("error500", "error", new { area = "admin" });
            }
            
        }

        [HttpPost]
        [Route("edit/{id}")]
        public async Task<IActionResult> Edit(Occasion occasion, IFormFile image)
        {
            try
            {
                if (image != null)
                {
                    Debug.WriteLine("File Name: " + image.FileName);
                    Debug.WriteLine("File Size (byte): " + image.Length);
                    Debug.WriteLine("File SizeType: " + image.ContentType);
                    string path = Path.Combine(this.iwebHostEnvironment.WebRootPath, "images/occasions", image.FileName);
                    image.CopyTo(new FileStream(path, FileMode.Create));
                    occasion.Photo = image.FileName;
                }

                await occasionRepository.Update(occasion.Id, occasion);

                return RedirectToAction("index", "occasion");
            }
            catch (Exception)
            {
                return RedirectToAction("error500", "error", new { area = "admin" });
            }
            
        }

    }
}
