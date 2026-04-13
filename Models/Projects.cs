using System.ComponentModel.DataAnnotations;

namespace CodeCircle.Models
{

    public class Project
    {
        [Key]
        public int Id { get; set; }
        [StringLength(64)]
        public string DeveloperId { get; set; } = string.Empty;
        [Required]
        [StringLength(80)]
        public string Title { get; set; } = string.Empty;
        [StringLength(2000)]
        public string Description { get; set; } = string.Empty;

        [StringLength(24)]
        public string Stage { get; set; } = string.Empty;
        [StringLength(120)]
        public string SupportRequired { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
