﻿using Final_Project.Areas.Student.Models.DataLayer.Configuration;
using Final_Project.Areas.Student.Models.DomainModels;
using Final_Project.Models.DomainModels;
using Final_Project.Areas.Team.Models.DataLayer;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Final_Project.Models
{
    public class SiteContext:IdentityDbContext<Account>
    {
        public SiteContext(DbContextOptions<SiteContext> options)
           : base(options)
        { }

        public DbSet<Message> Messages { get; set; } = null!;
        public DbSet<Final_Project.Areas.Team.Models.DomainModels.Team> Teams { get; set; } = null!;
        public DbSet<Final_Project.Areas.VolunteerRequest.Models.DomainModels.Request> VolReqs { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ConfigureMessage());
            modelBuilder.ApplyConfiguration(new ConfigureTeam());
            // configure entities

        }
    }
}
