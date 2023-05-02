using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Final_Project.Areas.Student.Models.DomainModels;

namespace Final_Project.Areas.Student.Models.DataLayer.Configuration
{
    public class ConfigureMessage : IEntityTypeConfiguration<DomainModels.Message>
    {
        public void Configure(EntityTypeBuilder<DomainModels.Message> entity)
        {
            // seed initial data
            entity.HasData(
                 new { Title = "Message5", Body = "Body1", id = -6, UserName = "Null", isReply = false, ParentID = 0 },
                new { Title = "Message5", Body = "Body1", id = -1, UserName = "Null", isReply = false, ParentID = 0 },
                new { Title = "Message4", Body = "Body2", id = -2, UserName = "Null", isReply = false, ParentID = 0 },
                new { Title = "Message3", Body = "Body3", id = -3, UserName = "Null", isReply = false, ParentID = 0 },
                new { Title = "Message2", Body = "Body4", id = -4, UserName = "Null", isReply = false, ParentID = 0 },
                new { Title = "Message1", Body = "Body5", id = -5, UserName = "Null", isReply = false, ParentID = 0 }
            )  ;
        }

    }
}
