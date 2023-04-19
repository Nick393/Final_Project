using System.ComponentModel.DataAnnotations.Schema;

namespace Final_Project.Models
{
    public class Account
    {
        public string Id { get; set; } = string.Empty;
        public string LastName { get; set; }=string.Empty;
        public string FirstName { get; set; }=string.Empty; 
        public string Email { get; set; }=string.Empty; 
        public string UserName { get; set; }= string.Empty;
        [NotMapped]
        public IList<string> RoleNames { get; set; }=null!;
    }
}
