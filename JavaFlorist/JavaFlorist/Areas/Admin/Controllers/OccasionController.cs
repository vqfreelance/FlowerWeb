using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using JavaFlorist.Models;
using JavaFlorist.Models.Repositories;
using JavaFlorist.Models.Temp;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using PagedList;

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
        public IActionResult Index(int? page, int? pageSize)
        {
            try
            {
                int pageIndex = 1;
                pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
                ViewBag.pageIndex = pageIndex;
                //Default size is 5 otherwise take pageSize value
                int defaultSize = (pageSize ?? 5);
                ViewBag.psize = defaultSize;
                var selected5 = false;
                var selected10 = false;
                var selected20 = false;
                var selected50 = false;
                if (defaultSize == 5) selected5 = true;
                if (defaultSize == 10) selected10 = true;
                if (defaultSize == 20) selected20 = true;
                if (defaultSize == 50) selected50 = true;

                //Dropdownlist code for PageSize selection
                //In View Attach this
                ViewBag.PageSize = new List<SelectListItem>()
                {
                    new SelectListItem() { Value = "5", Text = "5 records", Selected = selected5},
                    new SelectListItem() { Value = "10", Text = "10 records", Selected = selected10},
                    new SelectListItem() { Value = "20", Text = "20 records", Selected = selected20},
                    new SelectListItem() { Value = "50", Text = "50 records", Selected = selected50}
                };

                //Check if there is search or not, then take appropriate entity
                var occasions = new List<Occasion>();
                if (HttpContext.Session.GetString("searchOccasions") == null)
                {
                    occasions = occasionRepository.GetAllIncludeRelationship().ToList();
                }
                else
                {
                    var a = JsonConvert.DeserializeObject<SearchOccasions>(HttpContext.Session.GetString("searchOccasions"));
                    occasions = a.occasions;
                    ViewBag.keyword = a.keyword;           
                }

                //Show occasion index
                ViewBag.occasions = occasions.ToPagedList(pageIndex, defaultSize);
                ViewBag.occasioncount = occasions.Count();
                var numofpage = occasions.Count / defaultSize + 1;
                var lastpage = occasions.Count % defaultSize;
                ViewBag.numofpage = numofpage;
                ViewBag.fromoccasion = defaultSize * (pageIndex - 1) + 1;
                ViewBag.tooccasion = pageIndex == numofpage ? defaultSize * (pageIndex - 1) + lastpage : defaultSize * pageIndex;

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
            HttpContext.Session.Remove("searchOccasions");
            try
            {
                if (keyword != null)
                {
                    var occasions = occasionRepository.Search(keyword).ToList();
                    var searchOccasions = new SearchOccasions { occasions = occasions, keyword = keyword };
                    HttpContext.Session.SetString("searchOccasions", JsonConvert.SerializeObject(searchOccasions, new JsonSerializerSettings()
                    {
                        PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                        Formatting = Formatting.Indented
                    }));

                }
                return RedirectToAction("index", "occasion");
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
