using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Diagnostics;
using Final_Project.Models.ViewModels;
namespace Final_Project.Areas.Student.Controllers
{
    [Area("Student")]
    
    [Authorize(Roles="Student")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
