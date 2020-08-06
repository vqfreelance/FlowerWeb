using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JavaFlorist.Models;
using JavaFlorist.Models.Repositories;
using JavaFlorist.Models.Temp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using PagedList;

namespace JavaFlorist.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin/message")]
    public class MessageController : Controller
    {
        private IMessageRepository messageRepository;
        private IOccasionRepository occasionRepository;
        public MessageController(IMessageRepository _messageRepository, 
            IOccasionRepository _occasionRepository)
        {
            messageRepository = _messageRepository;
            occasionRepository = _occasionRepository;
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
                var messages = new List<Message>();
                if (HttpContext.Session.GetString("searchMessages") == null)
                {
                    messages = messageRepository.GetAllIncludeRelationship().ToList();
                }
                else
                {
                    var a = JsonConvert.DeserializeObject<SearchMessages>(HttpContext.Session.GetString("searchMessages"));
                    messages = a.messages;
                    ViewBag.keyword = a.keyword;
                }

                //Show message index
                ViewBag.messages = messages.ToPagedList(pageIndex, defaultSize);
                ViewBag.messagecount = messages.Count();
                var numofpage = messages.Count / defaultSize + 1;
                var lastpage = messages.Count % defaultSize;
                ViewBag.numofpage = numofpage;
                ViewBag.frommessage = defaultSize * (pageIndex - 1) + 1;
                ViewBag.toomessage = pageIndex == numofpage ? defaultSize * (pageIndex - 1) + lastpage : defaultSize * pageIndex;

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
            HttpContext.Session.Remove("searchMessages");
            try
            {
                if(keyword != null)
                {
                    var messages = messageRepository.Search(keyword).ToList();
                    var searchMessages = new SearchMessages { messages = messages, keyword = keyword };
                    HttpContext.Session.SetString("searchMessages", JsonConvert.SerializeObject(searchMessages, new JsonSerializerSettings()
                    {
                        PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                        Formatting = Formatting.Indented
                    }));
                }
                return RedirectToAction("index", "message");
            }
            catch (Exception)
            {
                return RedirectToAction("error500", "error", new { area = "admin" });
            }
        }

        //Create Message
        [HttpGet]
        [Route("create")]
        public IActionResult Create()
        {
            ViewBag.occasions = occasionRepository.GetAllIncludeRelationship().ToList();
            return View();
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create(Message message)
        {
            try
            {
                await messageRepository.Create(message);
                return RedirectToAction("index", "message");
            }
            catch (Exception)
            {
                return RedirectToAction("error500", "error", new { area = "admin" });
            }
        }

        // Edit message
        [HttpGet]
        [Route("edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var message = await messageRepository.GetByIdIncludeRelationship(id);
                ViewBag.message = message;
                ViewBag.occasions = occasionRepository.GetAllIncludeRelationship().Where(o => o.Id != message.OccasionId).ToList();
                return View("edit", message);
            }
            catch (Exception)
            {
                return RedirectToAction("error500", "error", new { area = "admin" });
            }
        }

        [HttpPost]
        [Route("edit/{id}")]
        public async Task<IActionResult> Edit(Message message, int occasionId)
        {
            try
            {
                message.OccasionId = occasionId;
                await messageRepository.Update(message.Id, message);
                return RedirectToAction("index", "message");
            }
            catch (Exception)
            {
                return RedirectToAction("error500", "error", new { area = "admin" });
            }

        }
    }
}
