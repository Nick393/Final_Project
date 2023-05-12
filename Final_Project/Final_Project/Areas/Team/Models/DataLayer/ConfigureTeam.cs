using Final_Project.Areas.Student.Models.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Final_Project.Areas.Team.Models.DomainModels;
using Final_Project.Areas.Team.Models.ViewModels;

namespace Final_Project.Areas.Team.Models.DataLayer
{
    internal class ConfigureTeam : IEntityTypeConfiguration<DomainModels.Team>
    {






        public void Configure(EntityTypeBuilder<DomainModels.Team> entity)
        {
            // seed initial data
            entity.HasData(
                new { number= "Number", name = "Name",id=1,description="Description",about="About",Program=(TeamType)0,Prgm="FRC" },
                new { number = "Number", name = "Name",id=2,description= "Description", about = "About", Program=(TeamType)1, Prgm = "FRC" },
                new { number = "Number", name = "Name" ,id=3, description = "Description", about = "About", Program = (TeamType)1, Prgm = "FRC" },
                new { number = "Number", name = "Name" ,id=4, description = "Description", about = "About", Program = (TeamType)1, Prgm = "FRC" },
                new { number = "Number", name = "Name" ,id=5, description = "Description", about = "About", Program = (TeamType)1, Prgm = "FRC" }
            );
        }


    }
}
