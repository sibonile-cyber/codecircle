using System;
using System.ComponentModel.DataAnnotations;

namespace CodeCircle.Models
{
    public class Celebration
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string DeveloperName { get; set; } = string.Empty;

        [Required]
        public string DeveloperInitials { get; set; } = string.Empty;

        [Required]
        public string ActionText { get; set; } = string.Empty; 

        [Required]
        public string ProjectTitle { get; set; } = string.Empty; 

        
        public string? ImagePath { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
