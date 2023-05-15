using Final_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Final_Project.Areas.Team.Models.DomainModels;
using Final_Project.Areas.Student.Models.ViewModels;
using Final_Project.Areas.Team.Models;
using Final_Project.Areas.Team.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace Final_Project.Areas.Team.Controllers
{
    [Area("Team")]

    public class TeamController : Controller
    {
        private SiteContext _siteContext;
        private List<Models.DomainModels.Team> teems = new List<Models.DomainModels.Team>();
        
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
        [HttpPost]
        public RedirectToActionResult Delete(int id)
        {
            foreach (Models.DomainModels.Team team in _siteContext.Teams)
            {
                if (team.id == id)
                {
                    _siteContext.Teams.Remove(team);
                }
            }


            //_siteContext.Messages.Remove(message); 

            _siteContext.SaveChanges();

            return RedirectToAction("Index");
        }
        [Authorize(Roles ="Admin")]
        [HttpGet]
        public IActionResult AddTeam()
        {
            AddTeamModel model = new AddTeamModel();
            return View(model);
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult AddTeam(AddTeamModel model)
        {
           

            if (ModelState.IsValid)
            {
                Models.DomainModels.Team team = new Models.DomainModels.Team();
                team.number = model.Number;
                team.name = model.Name;
                team.about = model.about;
                team.Prgm= model.Prgm;
                //team.id = model.;
                team.description = model.Description;
                
                _siteContext.Teams.Add(team);
                _siteContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }


        }
        public IActionResult Team(int id)
        {
            foreach (Final_Project.Areas.Team.Models.DomainModels.Team team in _siteContext.Teams)
            {

                if (team.id == id)
                {
                    return View(team);
                }
            }
            return View();
        }
        public IActionResult Resources(int id)
        {
            foreach (Final_Project.Areas.Team.Models.DomainModels.Team team in _siteContext.Teams)
            {
                if (team.id == id)
                {
                    return View(team);
                }
            }
            return RedirectToAction("Index");
        }
       
    }
}
