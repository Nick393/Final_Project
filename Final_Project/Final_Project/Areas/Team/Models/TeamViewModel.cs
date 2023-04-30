//using Microsoft.Build.Framework;
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
    }
}
