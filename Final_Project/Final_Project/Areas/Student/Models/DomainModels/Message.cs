﻿using System.ComponentModel.DataAnnotations;

namespace Final_Project.Areas.Student.Models.DomainModels
{
    public class Message
    {
        [Required(ErrorMessage = "Please enter a title")]
        [StringLength(100)]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a body")]
        [StringLength(3000)]
        public string Body { get; set; } = string.Empty;
        [Key]
        public string id { get; set; }= string.Empty;
        public string UserName { get; set; }=string.Empty;
    }
}
