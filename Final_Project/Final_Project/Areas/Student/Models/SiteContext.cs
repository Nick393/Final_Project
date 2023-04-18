
using Microsoft.EntityFrameworkCore;
using Final_Project.Models;

namespace Final_Project.Areas.Student.Models
{
    public class SiteContext : DbContext
    {
        public SiteContext(DbContextOptions<SiteContext> options) : base(options) { }
        public DbSet<Account> Accounts { get; set; } = null!;
        public DbSet<Announcement> Announcements { get; set; } = null!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Account>().HasData(
                new Account { Id = "0", UserName = "Admin",LastName="Bob",FirstName="Will",Email="Test@gmail.com" }
                );
            modelBuilder.Entity<Announcement>().HasData(new Announcement { Id = "0", Name = "Welcome to the announcements page" });
        }
    }




}
