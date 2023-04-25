using Final_Project.Areas.Student.Models.DomainModels;

namespace Final_Project.Areas.Student.Models.ViewModels
{
    public class MessageViewModel
    {
        public IEnumerable<Message> Messages { get; set; } = null!;

    }
}
