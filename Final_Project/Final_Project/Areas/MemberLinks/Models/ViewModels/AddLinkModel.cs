using Final_Project.Areas.MemberLinks.Models.DomainModels;
using System.ComponentModel.DataAnnotations;

namespace Final_Project.Areas.MemberLinks.Models.ViewModels
{
    public class AddLinkModel
    {


        [Required(ErrorMessage = "Please enter a resource name")]
        [StringLength(100)]
        public string name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter the link to the resource")]
        [StringLength(3000)]
        public string LinkData { get; set; } = string.Empty;

        [Key]
        public int id { get; set; }
        [Required(ErrorMessage = "Please enter a team type")]
        [StringLength(3,ErrorMessage ="Select a team type")]
        public string teamtype { get; set; }= string.Empty;
        
    }


}
