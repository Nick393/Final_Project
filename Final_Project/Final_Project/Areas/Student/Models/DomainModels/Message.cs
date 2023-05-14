using Final_Project.Models.DomainModels;
using System.ComponentModel.DataAnnotations;

namespace Final_Project.Areas.Student.Models.DomainModels
{
    public class Message
    {
        [Required(ErrorMessage = "Please enter a title")]
        [StringLength(100)]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a body")]
        [StringLength(10000)]
        public string Body { get; set; } = string.Empty;
        [Key]
        public int id { get; set; }
        public string UserName { get; set; }=string.Empty;
       public bool isReply { get; set; }
        public bool isPM { get;set; }
        public string Recip { get; set; }=string.Empty;
        public IEnumerable<Account> Users { get; set; } = null!;
        public int ParentID { get; set; }
        public bool obscure=false;
        public List<Message> Replies { get; set; } = new List<Message>();
    }
}
