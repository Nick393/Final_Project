using Final_Project.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Final_Project.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Final_Project.Areas.EmailSubsystem.Models.DomainModels;
using Microsoft.AspNetCore.Identity;
using Final_Project.Models.DomainModels;
using Microsoft.Identity.Client;
using System.Net.Mail;
using System.Net;

namespace Final_Project.Controllers
{
    public class HomeController : Controller
    {
        private SiteContext _SiteContext;
        private UserManager<Account> userManager;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, UserManager<Account> userMngr, SiteContext siteContext)
        {
            _logger = logger;
            _SiteContext = siteContext;
            userManager = userMngr;
        }

        public IActionResult Index()
        {
            List<SelectListItem> Types = new() {
                new SelectListItem{Value="0",Text="Member Resources"},
                new SelectListItem { Value = "1", Text = "FRC Member Resources" },
                new SelectListItem { Value = "2", Text = "FTC Member Resources" },
                new SelectListItem { Value = "3", Text = "FLL Member Resources" },
            };
            ViewBag.Types = Types;

            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Teams()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}