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
                 new { Title = "Title", Body = "Body", id = -6, UserName = "Null", isReply = false, ParentID = 0, Recip = string.Empty, isPM = false },
                new { Title = "Title", Body = "Body", id = -1, UserName = "Null", isReply = false, ParentID = 0, Recip = string.Empty, isPM = false },
                new { Title = "Title", Body = "Body", id = -2, UserName = "Null", isReply = false, ParentID = 0, Recip = string.Empty, isPM = false },
                new { Title = "Title", Body = "Body", id = -3, UserName = "Null", isReply = false, ParentID = 0, Recip = string.Empty, isPM = false },
                new { Title = "Title", Body = "Body", id = -4, UserName = "Null", isReply = false, ParentID = 0, Recip = string.Empty, isPM = false },
                new { Title = "Title", Body = "Body", id = -5, UserName = "Null", isReply = false, ParentID = 0, Recip = string.Empty, isPM = false }
            )  ;
        }

    }
}
