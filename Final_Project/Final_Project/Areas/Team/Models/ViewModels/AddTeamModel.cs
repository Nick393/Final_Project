using Final_Project.Areas.Team.Models.DomainModels;
using System.ComponentModel.DataAnnotations;

namespace Final_Project.Areas.Team.Models.ViewModels
{
    public class AddTeamModel
    {


        [Required(ErrorMessage = "Please enter a team number.")]
        [StringLength(100)]
        public string Number { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a Team Name.")]
        [StringLength(3000)]
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = "Please enter a short team description or slogan")]
        [StringLength(3000)]
        public string Description { get; set; } = string.Empty;
        [Required(ErrorMessage = "Please enter a long team descrption")]
        [StringLength(3000)]
        public string about { get; set; } = string.Empty;
        [Required(ErrorMessage = "Please select a program type")]
       // [StringLength(3000)]
        public TeamType Program { get; set; }
        [Required(ErrorMessage = "Please select a program type")]
        [MinLength(3, ErrorMessage = "Select a team type")]
        [MaxLength(3, ErrorMessage = "Select a team type")]
        public string Prgm { get; set; }=string.Empty;
        public int id { get; set; }



    }
    public enum TeamType
    {
        FRC,
        FTC,
        FLL
    }
}



