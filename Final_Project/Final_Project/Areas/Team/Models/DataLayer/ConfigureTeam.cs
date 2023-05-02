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
                new { number= "6419", name = "Test1",id=1,description="Description ICE",about="This is a team assocxiated with the ICE organization",Program=(TeamType)0,Prgm="FRC" },
                new { number = "Testc", name = "Test2",id=2,description= "Description Test1", about = "This is a team assocxiated with the ICE organization", Program=(TeamType)1, Prgm = "FRC" },
                new { number = "Testb", name = "Test3" ,id=3, description = "Description Test2", about = "This is a team assocxiated with the ICE organization", Program = (TeamType)1, Prgm = "FRC" },
                new { number = "Testa", name = "Test4" ,id=4, description = "Description Test3", about = "This is a team assocxiated with the ICE organization", Program = (TeamType)1, Prgm = "FRC" },
                new { number = "Test", name = "Test5" ,id=5, description = "Description Test4", about = "This is a team assocxiated with the ICE organization", Program = (TeamType)1, Prgm = "FRC" }
            );
        }


    }
}
