using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using JavaFlorist.Models;
using JavaFlorist.Models.Repositories;
using JavaFlorist.Models.Temp;
using JavaFlorist.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using PagedList;

namespace JavaFlorist.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin/bouquet")]
    public class BouquetController : Controller
    {
       
        private readonly IWebHostEnvironment iwebHostEnvironment;
        private IBouquetRepository bouquetRepository;
        private IOccasionRepository occasionRepository;
        private IOccBouquetRepository occBouquetRepository;

        public BouquetController( 
            IWebHostEnvironment _iwebHostEnvironment, 
            IBouquetRepository _bouquetRepository,
            IOccasionRepository _occasionRepository,
            IOccBouquetRepository _occBouquetRepository)
        {
            iwebHostEnvironment = _iwebHostEnvironment;
            bouquetRepository = _bouquetRepository;
            occasionRepository = _occasionRepository;
            occBouquetRepository = _occBouquetRepository;
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
                var bouquets = new List<Bouquet>();
                if (HttpContext.Session.GetString("searchBouquets") == null)
                {
                    bouquets = bouquetRepository.GetAllIncludeRelationship().ToList();
                }
                else
                {
                    var a = JsonConvert.DeserializeObject<SearchBouquets>(HttpContext.Session.GetString("searchBouquets"));
                    bouquets = a.bouquets;
                    ViewBag.keyword = a.keyword;
                    if(a.min != 0) ViewBag.min = a.min;
                    if (a.max != 0) ViewBag.max = a.max;
                }
                
                //Show bouquet index
                ViewBag.bouquets = bouquets.ToPagedList(pageIndex, defaultSize);
                ViewBag.bouquetcount = bouquets.Count();
                var numofpage = bouquets.Count / defaultSize + 1;
                var lastpage = bouquets.Count % defaultSize;
                ViewBag.numofpage = numofpage;
                ViewBag.frombouquet = defaultSize * (pageIndex - 1) + 1;
                ViewBag.toboquet = pageIndex == numofpage ? defaultSize * (pageIndex - 1) + lastpage : defaultSize * pageIndex;
                //Upload annoucement
                ViewBag.noimageerror = TempData["NoImage"];
                ViewBag.uploaded = TempData["Uploaded"];
                return View();
            }
            catch (Exception)
            {                
                return RedirectToAction("error500", "error", new { area = "admin"});               
            }           
        }

        //Search bouquet by keyword
        [HttpPost]
        [Route("searchByKeyword")]
        public IActionResult Search(string keyword)
        {
            HttpContext.Session.Remove("searchBouquets");
            try
            {
                if(keyword != null)
                {
                    var bouquets = bouquetRepository.Search(keyword).ToList();                   
                    var searchBouquets = new SearchBouquets { bouquets = bouquets, keyword = keyword };
                    HttpContext.Session.SetString("searchBouquets", JsonConvert.SerializeObject(searchBouquets, new JsonSerializerSettings()
                    {
                        PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                        Formatting = Formatting.Indented
                    }));
                }
                return RedirectToAction("index", "bouquet");
            }
            catch (Exception)
            {
                return RedirectToAction("error500", "error", new { area = "admin" });
            } 
        }

        

        //Search bouquet by price
        [HttpPost]
        [Route("searchByPrice")]
        public IActionResult Search(decimal min, decimal max)
        {
            HttpContext.Session.Remove("searchBouquets");
            try
            {
               
                var bouquets = new List<Bouquet>();
                
                if (min != 0 && max != 0)
                {
                    bouquets = bouquetRepository.Search(min, max).ToList();                 
                }
                else if (min != 0 && max == 0)
                {
                    bouquets = bouquetRepository.Search1(min).ToList();                  
                }
                else if (min == 0 && max != 0)
                {
                    bouquets = bouquetRepository.Search2(max).ToList();
                }
                else
                {
                    bouquets = bouquetRepository.GetAllIncludeRelationship().ToList();
                }
                var searchBouquets = new SearchBouquets { bouquets = bouquets, min = min, max = max };
                HttpContext.Session.SetString("searchBouquets", JsonConvert.SerializeObject(searchBouquets, new JsonSerializerSettings()
                {
                    PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                    Formatting = Formatting.Indented
                }));
                return RedirectToAction("index", "bouquet");
            }
            catch (Exception)
            {
                return RedirectToAction("error500", "error", new { area = "admin" });
            }
            
        }

        //Upload bouquet photos
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
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var bouquet = await bouquetRepository.GetByIdIncludeRelationship(id);
                ViewBag.bouquet = bouquet;

                var tempOccasions = new List<TempOccasion>();
                var occasions = occasionRepository.GetAllIncludeRelationship().ToList();

                // Transfer all occasions in current database into temporary occasions
                for (var i = 0; i < occasions.Count; i++)
                {
                    tempOccasions.Add(new TempOccasion
                    {
                        Id = occasions[i].Id,
                        Name = occasions[i].Name,
                        IsChecked = false
                    });
                }

                // Check if occasions of bouquet exists in temporary occasions
                for (var i = 0; i < occasions.Count; i++)
                {
                    if (isExist(tempOccasions[i].Id, bouquet.OccBouquet))
                    {
                        tempOccasions[i].IsChecked = true;
                    }
                }
                var tempOccasionViewModel = new TempOccasionViewModel();
                tempOccasionViewModel.TempOccasions = tempOccasions;
                tempOccasionViewModel.Bouquet = bouquet;

                return View("Edit", tempOccasionViewModel);
            }
            catch (Exception)
            {
                return RedirectToAction("error500", "error", new { area = "admin" });
            }
            
        }

        private bool isExist(int id, ICollection<OccBouquet> occBouquets)
        {
            foreach (var occBouquet in occBouquets)
            {
                if(occBouquet.OccasionId == id)
                {
                    return true;
                }
            }
            return false;
        }

        [HttpPost]
        [Route("edit/{id}")]
        public async Task<IActionResult> Edit(TempOccasionViewModel tempOccasionViewModel)
        {
            try
            {
                //Create an editing bouquet to edit
                var edittingBouquet = await bouquetRepository.GetByIdIncludeRelationship(tempOccasionViewModel.Bouquet.Id);
                edittingBouquet.Name = tempOccasionViewModel.Bouquet.Name;
                edittingBouquet.Description = tempOccasionViewModel.Bouquet.Description;
                edittingBouquet.Price = tempOccasionViewModel.Bouquet.Price;
                edittingBouquet.Status = tempOccasionViewModel.Bouquet.Status;
                await bouquetRepository.Update(edittingBouquet.Id, edittingBouquet);

                //Delete transactions in OccBouquet table
                var dbOccasions = edittingBouquet.OccBouquet.ToList();
                foreach (var dbOccasion in dbOccasions)
                {
                    await occBouquetRepository.Delete(dbOccasion.Id);
                }

                //Add transactions in OccBouquet table
                var checkedOccasions = tempOccasionViewModel.TempOccasions.Where(o => o.IsChecked == true).ToList();
                foreach (var checkedOccasion in checkedOccasions)
                {
                    var a = new OccBouquet
                    {
                        OccasionId = checkedOccasion.Id,
                        BouquetId = tempOccasionViewModel.Bouquet.Id
                    };
                    await occBouquetRepository.Create(a);
                }

                return RedirectToAction("index", "bouquet");
            }
            catch (Exception)
            {
                return RedirectToAction("error500", "error", new { area = "admin" });
            }
            
        }

    }
}