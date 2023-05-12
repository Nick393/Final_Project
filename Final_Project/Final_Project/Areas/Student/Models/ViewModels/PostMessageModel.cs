using System.ComponentModel.DataAnnotations;
using Final_Project.Areas.Student.Models.DomainModels;
using Final_Project.Models.DomainModels;

namespace Final_Project.Areas.Student.Models.ViewModels
{
    public class PostMessageModel
    {
        [Required(ErrorMessage = "Please enter a title.")]
        [StringLength(100)]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a message Body.")]
        [StringLength(3000)]
        public string Body { get; set; } = string.Empty;
        public string UserName { get; set; }= string.Empty;
        public List<Message>Replies=null!;
        public int parentId { get; set; }
        public IEnumerable<Account> Users { get; set; } = null!;
        bool isReply { get; set; }
        public bool isPM { get; set; }
        public string Recip { get; set; } = string.Empty;
        public int id { get; set; }


    }
}
