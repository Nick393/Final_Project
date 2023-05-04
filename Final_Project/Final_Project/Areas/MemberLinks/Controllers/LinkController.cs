using Final_Project.Areas.MemberLinks.Models.ViewModels;
using Final_Project.Areas.MemberLinks.Models;
using Final_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace Final_Project.Areas.MemberLinks.Controllers
{
    [Authorize(Roles = "Student, Admin")]
    [Area("MemberLinks")]
    public class LinkController : Controller
    {
        private SiteContext _siteContext;
        private List<Models.DomainModels.Link> links = new List<Models.DomainModels.Link>();
        
        public LinkController(SiteContext ctx)
        {
            _siteContext = ctx;
            links = _siteContext.Links
                    .OrderBy(c => c.id)
                    .ToList();
        }

        [HttpGet]
        public IActionResult Links(string teamType)
        {
            List<Models.DomainModels.Link> links = new List<Models.DomainModels.Link>() ;
            // links = _siteContext.Links
            //.OrderBy(p => p.id).ToList();
            LinksModel viewModel = new LinksModel();
            foreach (Final_Project.Areas.MemberLinks.Models.DomainModels.Link link in _siteContext.Links)
            {
                if(link.teamtype==teamType)
                {
                    links.Add(link);
                    viewModel.type = teamType;
                }
            }
            if(links.Count==0)
            {
                foreach(Final_Project.Areas.MemberLinks.Models.DomainModels.Link link in _siteContext.Links)
                {
                    links.Add(link);
                }
                viewModel.type = "All";
            }
            
            viewModel.links = links;
            return View(viewModel);
            //return View(model);
        }
        [HttpPost]
        public RedirectToActionResult Delete(int id)
        {
            foreach (Models.DomainModels.Link link in _siteContext.Links)
            {
                if (link.id == id)
                {
                    _siteContext.Links.Remove(link);
                }
            }


            //_siteContext.Messages.Remove(message); 

            _siteContext.SaveChanges();

            return RedirectToAction("Links");
        }
        [HttpGet]
        public IActionResult AddLink()
        {
            AddLinkModel model = new AddLinkModel();
            return View(model);
        }
        [HttpPost]
        public IActionResult AddLink(AddLinkModel model)
        {


            if (ModelState.IsValid)
            {
                Models.DomainModels.Link link = new Models.DomainModels.Link();
                link.name = model.name;
                link.LinkData = model.LinkData;
                link.teamtype = model.teamtype;

                _siteContext.Links.Add(link);
                _siteContext.SaveChanges();
                return View("redirect");
            }
            else
            {
                return View(model);
            }


        }
        public IActionResult Link(int id)
        {
            foreach (Final_Project.Areas.MemberLinks.Models.DomainModels.Link link in _siteContext.Links)
            {

                if (link.id == id)
                {
                    return View(link);
                }
            }
            return View();
        }
    }
}
