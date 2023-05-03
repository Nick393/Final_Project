using Final_Project.Areas.Team.Models.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace Final_Project.Areas.MemberLinks.Models.DomainModels
{
    public class Link
    {
        [Required(ErrorMessage = "Please enter a resource name")]
        [StringLength(100)]
        public string name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter the link to the resource")]
        [StringLength(3000)]
        public string LinkData { get; set; } = string.Empty;
        
        [Key]
        public int id { get; set; }
        
    }
    
}
