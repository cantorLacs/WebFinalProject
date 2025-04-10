using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public enum EventType
    {
        Incident,
        Maintenance,
        Notification
    }
    public class EventReport
    {
        [Key]
        public int ReportId { get; set; }

        [Required(ErrorMessage = "Manager ID is required.")]
        public int ManagerId { get; set; } // Foreign key to User

        [Required(ErrorMessage = "Owner ID is required.")]
        public int OwnerId { get; set; } // Foreign key to User

        [Display(Name = "Event Description")]
        [Required(ErrorMessage = "Event Description is required.")]
        public required string EventDescription { get; set; }

        public DateTime ReportDate { get; set; }

        [Display(Name = "Event Type")]
        public EventType? EventType { get; set; } // Optional: classification or type of event
    }
}
