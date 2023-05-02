﻿using Final_Project.Areas.VolunteerRequest.Models.DomainModels;
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
        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage = "Please enter a mobile phone number")]
        [StringLength(3000)]
        public string Phone { get; set; } = string.Empty;


        public int id { get; set; }



    }
}



