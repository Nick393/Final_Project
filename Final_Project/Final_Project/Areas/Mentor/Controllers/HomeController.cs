using Final_Project.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Final_Project.Models.ViewModels;


namespace Final_Project.Areas.Mentor.Controllers
{
    [Authorize(Roles ="Admin")]
    [Area("Mentor")]
    public class HomeController : Controller
    {
        public IActionResult Approval()
        {
            return View();
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
