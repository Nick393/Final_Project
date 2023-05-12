using Final_Project.Areas.Student.Models.DomainModels;
using System.ComponentModel.DataAnnotations;

namespace Final_Project.Areas.Student.Models.ViewModels
{
    public class ReplyMessageModel
    {
        [Required(ErrorMessage = "Please enter a Message.")]
        [StringLength(283)]
        public string Title { get; set; } = string.Empty;

        public string UserName { get; set; }= string.Empty;
        public int ParentId { get; set; }
        public List<Message> Replies = null!;
        bool isReply { get; set; }
        public bool isPM { get; set; }
        public string Recip { get; set; } = string.Empty;
        public int id { get; set; }


    }
}
