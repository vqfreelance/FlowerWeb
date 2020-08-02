using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JavaFlorist.Models;
using JavaFlorist.Models.Repositories;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult Index()
        {
            try
            {
                ViewBag.messages = messageRepository.GetAllIncludeRelationship().ToList();
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
                if(keyword != null)
                {
                    ViewBag.messages = messageRepository.Search(keyword).ToList();
                    ViewBag.keyword = keyword;
                }
                else
                {
                    ViewBag.messages = messageRepository.GetAllIncludeRelationship().ToList();
                }
                return View("Index");
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
