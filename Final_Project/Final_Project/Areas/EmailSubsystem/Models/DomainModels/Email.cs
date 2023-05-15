using Final_Project.Models.DomainModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Final_Project.Areas.EmailSubsystem.Models.DomainModels
{
    public class Email
    {
        [Required(ErrorMessage = "Please enter a title.")]
        [StringLength(100)]
        public string Subject { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a email Body.")]
        [StringLength(10000)]
        public string Body { get; set; } = string.Empty;
        public string emailsCSV { get; set; }= string.Empty;
        public string usernames { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        [NotMapped]
        public List<string> EmailAddresses { get; set; } = null!;
        //public IEnumerable<Account> Users { get; set; } = null!;
        public string error=string.Empty;
        public bool success;
        public string succeed{get; set;}=string.Empty;
        [Key]
        public int id { get; set; }
    }
}
