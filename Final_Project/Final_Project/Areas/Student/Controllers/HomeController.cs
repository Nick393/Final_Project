using Microsoft.AspNetCore.Mvc;

namespace Final_Project.Areas.Student.Controllers
{
    [Area("Student")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
