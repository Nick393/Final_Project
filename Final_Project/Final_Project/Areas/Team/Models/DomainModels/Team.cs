using System.ComponentModel.DataAnnotations;

namespace Final_Project.Areas.Team.Models.DomainModels
{
    public class Team
    {
        [Required(ErrorMessage = "Please enter a team number")]
        [StringLength(100)]
        public string number { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a team name")]
        [StringLength(3000)]
        public string name { get; set; } = string.Empty;
        [Key]
        public int id { get; set; }
        
    }
}
