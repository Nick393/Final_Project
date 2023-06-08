using Final_Project.Areas.PermissionSlipsSystem.Models.DomainModels;
using Final_Project.Models.DomainModels;

namespace Final_Project.Areas.PermissionSlipsSystem.Models
{
    public class SlipsModel
    {
        public IEnumerable<Account> Accounts { get; set; } = null!;
        public IEnumerable<Slip> Slips { get; set; } = null!;

    }
}
