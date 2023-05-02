using Final_Project.Areas.VolunteerRequest.Models.DomainModels;
using System.ComponentModel.DataAnnotations;

namespace Final_Project.Areas.VolunteerRequest.Models.ViewModels
{
    public class VolunteerRequestModel
    {


        [Required(ErrorMessage = "Please enter your first name")]
        [StringLength(100)]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter your last name")]
        [StringLength(3000)]
        public string LastName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Please enter an email address")]
        [StringLength(3000)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage = "Please enter a mobile phone number")]
        [StringLength(3000)]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string Phone { get; set; } = string.Empty;
      
        [Required(ErrorMessage = "Please enter your reason for volunteering")]
        [StringLength(3000)]
        public string Reason { get; set; } = string.Empty;

        public int id { get; set; }



    }
}



