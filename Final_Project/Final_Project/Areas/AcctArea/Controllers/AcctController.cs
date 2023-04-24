using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Final_Project.Areas.AcctArea.Controllers
{
    [Area("AcctArea")]
    [Authorize]
    public class AcctController : Controller
    {
        public IActionResult Acct()
        {
            return View();
        }
    }
}
