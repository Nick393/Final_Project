using Final_Project.Areas.EmailSubsystem.Models.DomainModels;
using Final_Project.Areas.Team.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Final_Project.Areas.EmailSubsystem.Models.DataLayer
{
    internal class ConfigureSmtpConfig:IEntityTypeConfiguration<SmtpConfig>
    {
        public void Configure(EntityTypeBuilder<DomainModels.SmtpConfig> Entity)
        {
            Entity.HasData(
                new { emailAddress = "keymailservice@gmail.com", port = 587, provider="smtp.gmail.com", smtpKey= "vmgadsqskmtwnvjp",id=-1 }


                );
        }
    }
}
