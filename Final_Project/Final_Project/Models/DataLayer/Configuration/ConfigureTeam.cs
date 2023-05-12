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
                new { Title = "Title", Body = "Body" },
                new { Title = "Title", Body = "Body" },
                new { Title = "Title", Body = "Body" },
                new { Title = "Title", Body = "Body" },
                new { Title = "Title", Body = "Body" }
            );
        }


    }
}
