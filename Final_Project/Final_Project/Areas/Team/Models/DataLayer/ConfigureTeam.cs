using Final_Project.Areas.Student.Models.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Final_Project.Areas.Team.Models.DomainModels;

namespace Final_Project.Areas.Team.Models.DataLayer
{
    internal class ConfigureTeam : IEntityTypeConfiguration<DomainModels.Team>
    {






        public void Configure(EntityTypeBuilder<DomainModels.Team> entity)
        {
            // seed initial data
            entity.HasData(
                new { number= "6419", name = "Test1",id=1,description="an FRC team" },
                new { number = "Testc", name = "Test2",id=2,description="an FTC team" },
                new { number = "Testb", name = "Test3" ,id=3, description = "an FTC team" },
                new { number = "Testa", name = "Test4" ,id=4, description = "an FTC team" },
                new { number = "Test", name = "Test5" ,id=5, description = "an FTC team" }
            );
        }


    }
}
