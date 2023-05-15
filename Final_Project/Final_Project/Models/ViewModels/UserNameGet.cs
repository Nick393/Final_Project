using System.ComponentModel.DataAnnotations;

namespace Final_Project.Models.ViewModels
{
    public class UserNameGet
    {
        [Required(ErrorMessage="Enter your username")]
        public string UserName { get; set; } =string.Empty;
    }
}
