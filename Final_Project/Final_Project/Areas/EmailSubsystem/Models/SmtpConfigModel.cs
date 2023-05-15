using System.ComponentModel.DataAnnotations;

namespace Final_Project.Areas.EmailSubsystem.Models
{
    public class SmtpConfigModel
    {
        public string emailAddress { get; set; } = string.Empty;
        public string smtpKey { get; set; } = string.Empty;
        public string provider { get; set; } = string.Empty;
        public int port { get; set; }
        public string reminder { get; set; }= "This is a friendly reminder about this message I sent a while ago: ";
        [Key]
        public int id { get; set; }
    }
}
