using Final_Project.Areas.Student.Models.DomainModels;
using Final_Project.Areas.Student.Models.ViewModels;

//using migrations
using Final_Project.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.Data;

namespace Final_Project.Areas.Student.Controllers
{
    [Area("Student")]

    [Authorize(Roles = "Student, Admin")]
    public class MessageController : Controller
    {
        private SiteContext _siteContext;
        private List<Models.DomainModels.Message> messages = new List<Models.DomainModels.Message>();
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
        [HttpGet]
        public IActionResult PostMessage()
        {
            PostMessageModel model = new PostMessageModel();
            return View(model);
        }
        [HttpPost]
        public IActionResult PostMessage(PostMessageModel model)
        {
            /*List<Message> messages;

            messages = _siteContext.Messages
                   .OrderBy(p => p.id).ToList();
            MessageViewModel viewModel = new MessageViewModel();
            viewModel.Messages = messages;*/

            if (ModelState.IsValid)
            {
                Models.DomainModels.Message message = new Models.DomainModels.Message();
                message.Title = model.Title;
                message.id = model.id;
                message.UserName = User.Identity?.Name ?? "";
                message.Body = model.Body;
                _siteContext.Messages.Add(message);
                _siteContext.SaveChanges();
                return RedirectToAction("MessageBoard");
            }
            else
            {
                return View("error");
            }

            
        }
         [HttpGet]
        public IActionResult MessageBoard()
        {
            List<Models.DomainModels.Message> messages;
            messages = _siteContext.Messages
                   .OrderBy(p => p.id).ToList();
            MessageViewModel viewModel = new MessageViewModel();
            viewModel.Messages = messages;
            return View(viewModel);
            //return View(model);
        }
        /*[HttpPost]
        public ViewResult Delete(int id)
        {
            foreach (Message message in _siteContext.Messages)
            {
                if(message.id==id)
                {
                    _siteContext.Remove(message);
                    _siteContext.SaveChanges();
                }
            }
            
            return View("MessageBoard");
        }*/

        [HttpPost]
        public RedirectToActionResult Delete(int id)
        {
            foreach (Models.DomainModels.Message message in _siteContext.Messages)
            {
                if(message.id == id)
                {
                    _siteContext.Messages.Remove(message);
                }
            }
            
            
            //_siteContext.Messages.Remove(message); 
            
            _siteContext.SaveChanges();
            
            return RedirectToAction("MessageBoard");  
        }

    }
}
