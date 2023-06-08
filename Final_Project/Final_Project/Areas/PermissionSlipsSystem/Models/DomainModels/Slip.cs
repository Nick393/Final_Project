using System.Diagnostics.Eventing.Reader;

namespace Final_Project.Areas.PermissionSlipsSystem.Models.DomainModels
{
    public class Slip
    {
        public string EventName { get; set; } = string.Empty;
        public int id { get; set; }
        public List<Slip> replies { get; set; } = null!;
        public int EventId { get; set; }
        public string EventType { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime eventStartDate { get; set; }
        public DateTime eventEndDate { get; set; }
        public bool isMain { get; set; }
       
        public string username { get; set; } = string.Empty;
        public bool signed { get; set; }

    }
}
