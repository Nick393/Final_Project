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
                new { Title = "Testd", Body = "Test1", isReply = false },
                new { Title = "Testc", Body = "Test2", isReply = false },
                new { Title = "Testb", Body = "Test3", isReply = false },
                new { Title = "Testa", Body = "Test4", isReply = false },
                new { Title = "Test", Body = "Test5", isReply = false }
            );
        }


    }
}


