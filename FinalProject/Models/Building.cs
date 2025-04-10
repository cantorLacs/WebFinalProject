using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public class Building
    {
        [Key]
        public int BuildingId { get; set; }

        [Required(ErrorMessage = "Manager ID is required.")]
        public int ManagerId { get; set; } // Foreign key to User

        [StringLength(100)]
        [Display(Name = "Building Name")]
        [Required(ErrorMessage = "Building Name is required.")]
        public required string Name { get; set; }

        [StringLength(255)]
        [Display(Name = "Address")]
        [Required(ErrorMessage = "Address is required.")]
        public required string Address { get; set; }

        [Display(Name = "Description")]
        public string? Description { get; set; }

        public DateTime RegistrationDate { get; set; }
    }
}
