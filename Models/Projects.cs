using System.ComponentModel.DataAnnotations;

namespace CodeCircle.Models
{

    public class Project
    {
        [Key]
        public int Id { get; set; }
        public string DeveloperId { get; set; } = string.Empty;
        [Required]
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public string Stage { get; set; } = string.Empty;
        public string SupportRequired { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
