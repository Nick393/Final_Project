using Final_Project.Areas.Student.Models.DomainModels;
using Final_Project.Areas.Student.Models.ViewModels;
using Final_Project.Migrations;
using Final_Project.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Final_Project.Areas.Student.Controllers
{
    [Area("Student")]

    [Authorize(Roles = "Student, Admin")]
    public class MessageController : Controller
    {
        private SiteContext _siteContext;
        private List<Message> messages = new List<Message>();
        //private Repository<Message> data { get; set; }
        public MessageController(SiteContext ctx)
        {
            _siteContext = ctx;
            messages = _siteContext.Messages
                    .OrderBy(c => c.id)
                    .ToList();
        }
        [HttpGet]
        public IActionResult Index()
        {
            return RedirectToAction("MessageBoard");
        }
        [HttpPost]
        public IActionResult PostMessage(PostMessageModel model)
        {
            List<Message> messages;
            messages = _siteContext.Messages
                   .OrderBy(p => p.id).ToList();

            
            return View(messages);
        }
        [HttpGet]
        public IActionResult MessageBoard()
        {
            List<Message> messages;
            messages = _siteContext.Messages
                   .OrderBy(p => p.id).ToList();


            return View(messages);
            //return View(model);
        }

    }
}
