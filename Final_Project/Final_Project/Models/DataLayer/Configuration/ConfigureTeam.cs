using Final_Project.Areas.Student.Models.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Final_Project.Areas.Team.Models.DomainModels;

namespace Final_Project.Models.DataLayer.Configuration
{
    internal class ConfigureTeam : IEntityTypeConfiguration<Team>
    {






        public void Configure(EntityTypeBuilder<Team> entity)
        {
            // seed initial data
            entity.HasData(
                new { Title = "Testd", Body = "Test1" },
                new { Title = "Testc", Body = "Test2" },
                new { Title = "Testb", Body = "Test3" },
                new { Title = "Testa", Body = "Test4" },
                new { Title = "Test", Body = "Test5" }
            );
        }


    }
}
