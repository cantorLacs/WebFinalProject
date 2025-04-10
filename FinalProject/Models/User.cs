using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public enum UserRole
    {
        Owner,
        Manager,
        Tenant
    }
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [StringLength(100)]
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First Name is required.")]
        public required string FirstName { get; set; }

        [StringLength(100)]
        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last Name is required.")]
        public required string LastName { get; set; }

        [StringLength(100)]
        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password is required.")]
        public required string Password { get; set; }

        [StringLength(100)]
        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "Email is required.")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Email format is not valid.")]
        public required string Email { get; set; }

        [Display(Name = "Role")]
        [Required(ErrorMessage = "Role is required.")]
        public required UserRole Role { get; set; } // 'owner', 'manager', 'tenant'

        [StringLength(20)]
        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Phone Number is required.")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Phone Number format is not valid.")]
        public required string Phone { get; set; }

        public DateTime RegistrationDate { get; set; }
    }

}
