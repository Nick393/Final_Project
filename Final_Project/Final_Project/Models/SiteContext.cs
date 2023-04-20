using Final_Project.Models.DomainModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Final_Project.Models
{
    public class SiteContext:IdentityDbContext<Account>
    {
        public SiteContext(DbContextOptions<SiteContext> options)
           : base(options)
        { }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // configure entities
           
        }
    }
}
