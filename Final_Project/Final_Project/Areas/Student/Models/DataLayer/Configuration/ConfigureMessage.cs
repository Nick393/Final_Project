using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Final_Project.Areas.Student.Models.DomainModels;

namespace Final_Project.Areas.Student.Models.DataLayer.Configuration
{
    public class ConfigureMessage : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> entity)
        {
            // seed initial data
            entity.HasData(
                new { Title = "novel", Body = "Novel", id = "1",UserName="Null" },
                new { Title = "memoir", Body = "Memoir",id = "2", UserName = "Null" },
                new { Title = "mystery", Body = "Mystery",id = "3", UserName = "Null" },
                new { Title = "scifi", Body = "Science Fiction", id = "4", UserName = "Null" },
                new { Title = "history", Body = "History",id="5", UserName = "Null" }
            );
        }

    }
}
