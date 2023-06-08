using Final_Project.Models.DomainModels;
using Final_Project.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Final_Project.Areas.Student.Models.ViewModels;
using Final_Project.Areas.Student.Models.DomainModels;
using Final_Project.Areas.PermissionSlipsSystem.Models;
using Final_Project.Areas.PermissionSlipsSystem.Models.DomainModels;
using Microsoft.AspNetCore.Authorization;

//using migrations
//using AspNetCore;

//using migrations
namespace Final_Project.Areas.PermissionSlipsSystem.Controllers
{
    [Authorize(Roles = "Admin, Student")]
    [Area("PermissionSlipsSystem")]
    public class HomeController : Controller
    {
        private SiteContext _siteContext;
        private UserManager<Account> userManager;
        private RoleManager<IdentityRole> roleManager;
        private List<Final_Project.Areas.Student.Models.DomainModels.Message> messages = new List<Final_Project.Areas.Student.Models.DomainModels.Message>();
        //private Repository<Message> data { get; set; }
        public HomeController(SiteContext ctx, UserManager<Account> userMngr,
            RoleManager<IdentityRole> roleMngr)
        {
            _siteContext = ctx;
            userManager = userMngr;
            roleManager = roleMngr;
        }
       
        
        [HttpGet]
        [Authorize(Roles ="Admin")]
        public IActionResult PostEvent()
        {
            SlipModel model = new SlipModel();
            
            return View(model);
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult PostEvent(SlipModel model)
        {
            


            if (ModelState.IsValid)
            {
                Models.DomainModels.Slip slip = new Models.DomainModels.Slip();//This works
                slip.EventName = model.EventName;
                slip.isMain = false;
                slip.EventId = model.EventId;
                
                slip.username = User.Identity?.Name ?? "";
                slip.Description = model.Description;

                
                
                
                return RedirectToAction("MessageBoard");
            }
            else
            {
                return View(model);
            }


        }
        [HttpGet]
        public IActionResult Index()
        {
            List<Models.DomainModels.Slip> slips;
            slips = _siteContext.slips
                   .OrderBy(p => p.id).ToList();
            SlipsModel viewModel = new SlipsModel();
            viewModel.Slips=slips;
            
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
            foreach (Models.DomainModels.Slip slip in _siteContext.slips)
            {
                if (slip.id == id)
                {
                    _siteContext.slips.Remove(slip);
                }
            }


            //_siteContext.Messages.Remove(message); 
            try
            {


                _siteContext.SaveChanges();
            }
            catch
            {
                foreach (Slip slip in _siteContext.slips)
                {
                    slip.isMain = false;
                    
                }
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
        public IActionResult Slip(int id)
        {
            foreach (Slip slip in _siteContext.slips)
            {

                if (slip.id == id)
                {
                    return View(slip);
                }
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult ReplySlip(int EventId)
        {
            ReplyModel model = new ReplyModel();
            // model.ParentId= parentId;
            return View(model);
        }
        [HttpPost]
        public IActionResult ReplySlip(ReplyModel model)
        {
            

            if (ModelState.IsValid)
            {
               Slip slip = new Slip();
                slip.EventName = slip.EventName;
                //message.id = model.id;
                slip.username = User.Identity?.Name ?? "";
                
                
                slip.isMain = false;
                foreach (Slip slp in _siteContext.slips)
                {
                    if (slip.id == model.id)
                    {
                        slip.EventId = slp.id;
                        slip.replies.Add(slp);

                    }
                }

                _siteContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }


        }
        public IActionResult returnToLast(int id)
        {
            foreach (Message msg in _siteContext.Messages)
            {
                if (msg.id == id)
                {
                    return View("Message", msg);
                }
            }
            return RedirectToAction("MessageBoard");
        }
        [HttpGet]
        public IActionResult Reset()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ResetBoard()
        {
            foreach (Message msg in _siteContext.Messages)
            {

                //msg.Replies =new List<Message>();
                //msg.Users = new List<Account>();
                //msg.isReply = false;
                //msg.isPM = false;
                //msg.Recip = string.Empty;
                //msg.UserName = string.Empty;
                //msg.Body = string.Empty;
                //msg.ParentID = 0;
                //msg.Title = string.Empty;


            }


            _siteContext.SaveChanges();
            foreach (Message msg in _siteContext.Messages)
            {
                //msg.Users=new List<Account>();
                _siteContext.Messages.Remove(msg);
            }
            try
            {
                _siteContext.SaveChanges();
            }
            catch (Exception ex)
            {
                foreach (Message msg in _siteContext.Messages)
                {
                    msg.isReply = true;
                    msg.obscure = true;

                }
            }

            return RedirectToAction("MessageBoard");
        }
    }
}
