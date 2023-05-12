using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Final_Project.Areas.Student.Models.DomainModels;

namespace Final_Project.Models.DataLayer.Configuration
{
    internal class ConfigureMessage : IEntityTypeConfiguration<Message>
    {






        public void Configure(EntityTypeBuilder<Message> entity)
        {
            // seed initial data
            entity.HasData(
                new { Title = "Title", Body = "Body", isReply = false },
                new { Title = "Title", Body = "Body", isReply = false },
                new { Title = "Title", Body = "Body", isReply = false },
                new { Title = "Title", Body = "Body", isReply = false },
                new { Title = "Title", Body = "Body", isReply = false }
            );
        }


    }
}


