using Final_Project.Areas.Student.Models.DomainModels;
using Final_Project.Models.DomainModels;

namespace Final_Project.Areas.Student.Models.ViewModels
{
    public class MessageViewModel
    {
        public IEnumerable<Message> Messages { get; set; } = null!;
        public IEnumerable<Account> Users { get; set; } = null!;

    }
}
