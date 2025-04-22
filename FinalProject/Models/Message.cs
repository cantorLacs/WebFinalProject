using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public class Message
    {
        [Key]
        public int MessageId { get; set; }

        [Required(ErrorMessage = "Sender ID is required.")]
        public int SenderId { get; set; } // Foreign key to User

        [Required(ErrorMessage = "Receiver ID is required.")]
        public int ReceiverId { get; set; } // Foreign key to User

        [StringLength(150)]
        [Display(Name = "Subject")]
        [Required(ErrorMessage = "Subject is required.")]
        public required string Subject { get; set; }

        [Display(Name = "Content")]
        public string? Content { get; set; }

        public int? ApartmentId { get; set; }

        public DateTime SendDate { get; set; }

        public bool IsRead { get; set; }
    }

}
