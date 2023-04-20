using Final_Project.Models.DomainModels;
using Microsoft.AspNetCore.Identity;

namespace Final_Project.Models
{
    public class UserViewModel
    {
        public IEnumerable<Account> Users { get; set; } = null!;
        public IEnumerable<IdentityRole> Roles { get; set; } = null!;
    }
}
