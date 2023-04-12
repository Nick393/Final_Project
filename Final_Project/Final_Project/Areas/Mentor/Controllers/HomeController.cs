using Final_Project.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Final_Project.Areas.Mentor.Controllers
{
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
