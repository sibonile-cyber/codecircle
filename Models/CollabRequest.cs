using System.ComponentModel.DataAnnotations;

namespace CodeCircle.Models
{
    public class CollabRequest
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(64)]
        public string SenderUserName { get; set; } = string.Empty;

        [Required]
        [StringLength(64)]
        public string ReceiverUserName { get; set; } = string.Empty;

        public int? ProjectId { get; set; }

        [StringLength(120)]
        public string ProjectName { get; set; } = string.Empty;

        [StringLength(2000)]
        public string ProjectDescription { get; set; } = string.Empty;

        [StringLength(60)]
        public string RoleRequested { get; set; } = string.Empty;

        [StringLength(120)]
        public string SkillsRequested { get; set; } = string.Empty;

        [StringLength(800)]
        public string Message { get; set; } = string.Empty;

        [StringLength(16)]
        public string Status { get; set; } = "Pending"; // Pending, Accepted, Declined, Withdrawn

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
