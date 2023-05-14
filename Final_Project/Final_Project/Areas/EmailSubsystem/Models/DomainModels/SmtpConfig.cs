using System.ComponentModel.DataAnnotations;

namespace Final_Project.Areas.EmailSubsystem.Models.DomainModels
{
    public class SmtpConfig
    {
        public string emailAddress { get; set; }=string.Empty;
        public string smtpKey { get; set; }= string.Empty;
        public string provider { get; set; } = string.Empty;
        public int port { get; set; }
        [Key]
        public int id { get; set; } 
    }
}
