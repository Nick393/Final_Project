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
                new { Title = "Message5", Body = "Body1", id = 1,UserName="Null" },
                new { Title = "Message4", Body = "Body2",id = 2, UserName = "Null" },
                new { Title = "Message3", Body = "Body3",id = 3, UserName = "Null" },
                new { Title = "Message2", Body = "Body4", id = 4, UserName = "Null" },
                new { Title = "Message1", Body = "Body5",id=5, UserName = "Null" }
            );
        }

    }
}
