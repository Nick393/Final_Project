using Final_Project.Areas.Team.Models.DomainModels;
using Final_Project.Areas.VolunteerRequest.Models.ViewModels;
using Final_Project.Models;
using Microsoft.AspNetCore.Mvc;

namespace Final_Project.Areas.VolunteerRequest.Controllers
{
    [Area("VolunteerRequest")]
    public class RequestController : Controller
    {
        private SiteContext _siteContext;
        private List<Models.DomainModels.Request> requests = new List<Models.DomainModels.Request>();
        public RequestController(SiteContext ctx)
        {
            _siteContext = ctx;
            requests = _siteContext.VolReqs
                    .OrderBy(c => c.id)
                    .ToList();
        }
        [HttpGet]
        public IActionResult Request()
        {
            VolunteerRequestModel model = new VolunteerRequestModel();
            return View(model);
        }
        [HttpPost]
        public IActionResult Request(VolunteerRequestModel Model)
        {


            if (ModelState.IsValid)
            {
                Models.DomainModels.Request model = new Models.DomainModels.Request();
                model.Phone = Model.Phone;
                model.FirstName = Model.FirstName;
                model.LastName = Model.LastName;
                model.Email = Model.Email;
                model.Reason = Model.Reason;
                
                

                _siteContext.VolReqs.Add(model);
                _siteContext.SaveChanges();
                return RedirectToAction("Success");
            }
            else
            {
                return View(Model);
            }


        }
        public IActionResult Success()
        {
            return View();
        }
    }
}
