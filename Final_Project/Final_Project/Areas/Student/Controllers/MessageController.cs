using Final_Project.Areas.Student.Models.DomainModels;
using Final_Project.Areas.Student.Models.ViewModels;
using Final_Project.Migrations;
using Final_Project.Models;
using Microsoft.AspNetCore.Mvc;

namespace Final_Project.Areas.Student.Controllers
{
    public class MessageController : Controller
    {
        private SiteContext _siteContext;
        private Repository<Message> data { get; set; }
        public MessageController(SiteContext ctx) => data = new Repository<Message>(ctx);
        public IActionResult Index()
        {
            return RedirectToAction("MessageBoard");
        }
        public IActionResult PostMessage(PostMessageModel model)
        {
            List<Message> messages;
            messages = _siteContext.Messages
                   .OrderBy(p => p.id).ToList();

            
            return View(messages);
        }
        public async Task<IActionResult> MessageBoard()
        {
            List<Message> messages;
            messages = _siteContext.Messages
                   .OrderBy(p => p.id).ToList();


            return View(messages);
            //return View(model);
        }

    }
}
