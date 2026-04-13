using System.ComponentModel.DataAnnotations;

namespace CodeCircle.Models
{
    public class CollabRequest
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string SenderUserName { get; set; } = string.Empty;

        [Required]
        public string ReceiverUserName { get; set; } = string.Empty;

        public int? ProjectId { get; set; }

        public string ProjectName { get; set; } = string.Empty;

        public string ProjectDescription { get; set; } = string.Empty;

        public string RoleRequested { get; set; } = string.Empty;

        public string SkillsRequested { get; set; } = string.Empty;

        public string Message { get; set; } = string.Empty;

        public string Status { get; set; } = "Pending"; // Pending, Accepted, Declined, Withdrawn

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
