using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{

    public enum AppointmentStatus
    {
        Pending,
        Confirmed,
        Canceled
    }
    public class Appointment
    {
        [Key]
        public int AppointmentId { get; set; }

        [Required(ErrorMessage = "Tenant ID is required.")]
        public int TenantId { get; set; } // Foreign key to User

        [Required(ErrorMessage = "Manager ID is required.")]
        public int ManagerId { get; set; } // Foreign key to User

        public int? ApartmentId { get; set; } // Optional foreign key to Apartment

        [Required(ErrorMessage = "Date is required.")]
        public DateTime Date { get; set; }

        [Display(Name = "Status")]
        [Required(ErrorMessage = "Status is required.")]
        public required AppointmentStatus Status { get; set; }

        [Display(Name = "Notes")]
        public string? Notes { get; set; }
    }
}
