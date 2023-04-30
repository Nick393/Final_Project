using Final_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Final_Project.Areas.Team.Models.DomainModels;
using Final_Project.Areas.Student.Models.ViewModels;
using Final_Project.Areas.Team.Models;

namespace Final_Project.Areas.Team.Controllers
{
    [Area("Team")]

    public class TeamController : Controller
    {
        private SiteContext _siteContext;
        private List<Models.DomainModels.Team> teems = new List<Models.DomainModels.Team>();
        //private Repository<Final_Project.Areas.Team.Models.DomainModels.Team> data { get; set; }
        public TeamController(SiteContext ctx)
        {
            _siteContext = ctx;
            teems = _siteContext.Teams
                    .OrderBy(c => c.id)
                    .ToList();
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Models.DomainModels.Team> teams;
            teams = _siteContext.Teams
                   .OrderBy(p => p.id).ToList();
            TeamsModel viewModel = new TeamsModel();
            viewModel.teams =teams ;
            return View(viewModel);
            //return View(model);
        }
    }
}
