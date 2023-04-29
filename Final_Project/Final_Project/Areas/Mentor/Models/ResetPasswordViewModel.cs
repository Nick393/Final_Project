using Final_Project.Models.DomainModels;
using System.ComponentModel.DataAnnotations;

namespace Final_Project.Areas.Mentor.Models.ViewModels
{
    public class ResetPasswordViewModel
    {
        [Required(ErrorMessage ="errr")]
        public string Username { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter your new password.")]
        [MaxLength(255)]
        [MinLength(6)]
        [DataType(DataType.Password)]
        [Compare("ConfirmPassword")]
        public string NewPassword { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please confirm your new password.")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; } = string.Empty;

        public Account user { get; set; } = null!;

        public string id { get; set; } =string.Empty;
    }
}
