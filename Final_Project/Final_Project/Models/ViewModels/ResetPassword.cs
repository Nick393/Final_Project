using System.ComponentModel.DataAnnotations;

namespace Final_Project.Models.ViewModels
{
    public class ResetPassword
    {
        public string Username { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter your reset token.")]
        public string ResetToken { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter your new password.")]
        [DataType(DataType.Password)]
        [Compare("ConfirmPassword")]
        public string NewPassword { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please confirm your new password.")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}

