//using Microsoft.Build.Framework;
using Final_Project.Areas.Team.Models.DomainModels;
using Final_Project.Areas.Team.Models.ViewModels;
using System.ComponentModel.DataAnnotations;
namespace Final_Project.Areas.Team.Models
{
    public class TeamViewModel
    {
        [Required(ErrorMessage="Please enter a team name")]
        public string Name { get; set; }=string.Empty;
        [Required(ErrorMessage ="Please enter a team number")]
        public string Number { get; set; }=string.Empty;
        [Required(ErrorMessage = "Please enter a team about page body")]
        public string Description { get; set; } = string.Empty;
        [Required(ErrorMessage = "Please select a program type")]
        //[StringLength(3000)]
        public TeamType Program { get; set; }
        [Required(ErrorMessage = "Please select a program type")]
        public string Prgm { get; set; }=string.Empty;

    }
}
