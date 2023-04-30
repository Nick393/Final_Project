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
        public int id { get; set; }



    }
    }



