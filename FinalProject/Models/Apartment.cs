using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{


    public enum ApartmentStatus
    {
        Available,
        Occupied,
        Appointment,
    }

    public class Apartment
    {
        [Key]
        public int ApartmentId { get; set; }

        public int ManagerId { get; set; }

        public int? TenantId { get; set; }

        [Required(ErrorMessage = "Building ID is required.")]
        public int Buildingid { get; set; } 

        [StringLength(20)]
        [Display(Name = "Apartment Number")]
        [Required(ErrorMessage = "Apartment Number is required.")]
        public required string ApartmentNumber { get; set; }

        [Required(ErrorMessage = "Floor number is required.")]
        public int Floor { get; set; }

        [Required(ErrorMessage = "Number of Bedrooms is required.")]
        public int Bedrooms { get; set; }

        [Required(ErrorMessage = "Area is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Area must be a positive value.")]
        public decimal Area { get; set; }

        [Required(ErrorMessage = "Rental Price is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Rental Price must be a positive value.")]
        public int RentalPrice { get; set; }

        [Display(Name = "Status")]
        [Required(ErrorMessage = "Status is required.")]
        public required ApartmentStatus Status { get; set; } 

        [Display(Name = "Description")]
        public string? Description { get; set; }

        public string? ImagePath { get; set; }
    }
}
