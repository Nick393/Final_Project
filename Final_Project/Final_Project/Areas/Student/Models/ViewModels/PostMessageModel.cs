using System.ComponentModel.DataAnnotations;

namespace Final_Project.Areas.Student.Models.ViewModels
{
    public class PostMessageModel
    {
        [Required(ErrorMessage = "Please enter a title.")]
        [StringLength(100)]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a message Body.")]
        [StringLength(3000)]
        public string Body { get; set; } = string.Empty;
        public string UserName { get; set; }= string.Empty;
        public string id { get; set; }=string.Empty;


    }
}
