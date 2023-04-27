using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Diagnostics;
using Final_Project.Models.ViewModels;
using Final_Project.Models.DomainModels;
using Microsoft.AspNetCore.Identity;
using Final_Project.Areas.Student.Models.ViewModels;
using Final_Project.Areas.Student.Models.DomainModels;
using Final_Project.Areas.Mentor.Models;
using Final_Project.Models;
//using migrations
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Final_Project.Areas.Student.Controllers
{

    [Area("Student")]
    
    [Authorize(Roles="Student, Admin")]
    
    public class HomeController : Controller
    {
        private SiteContext _siteContext;
        private List <Message> Messages= new List<Message>();
        private Repository<Message> data { get; set; }
        //public HomeController(SiteContext ctx) => data = new Repository<Message>(ctx);
        public HomeController(SiteContext ctx)
        {
            _siteContext = ctx;
            Messages = _siteContext.Messages
                    .OrderBy(c => c.id)
                    .ToList();
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Post()
        {
            return RedirectToAction("PostMessage");
        }

        public IActionResult PostMessage(PostMessageModel model)
        {
            List<Message> messages;
            messages = _siteContext.Messages
                   .OrderBy(p => p.id).ToList();


            return View(messages);
        }
       /* public async Task<IActionResult> MessageBoard()
        {
            List<Message> messages = new List<Message>();
            Message m= new Message();
            m.Title = "test";
            m.Body = "This is a test";
            messages.Add(m);//This is wrong, and needs to get the data from the database

            MessageViewModel model = new MessageViewModel
            {
                Messages= messages

            };
            return View(model);
        }*/
    }
}
