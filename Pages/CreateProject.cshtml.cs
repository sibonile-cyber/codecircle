using CodeCircle.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;
using CodeCircle.Models;
using System.ComponentModel.DataAnnotations;

namespace CodeCircle.Pages
{
    public class CreateProjectModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        // Inject the Database
        public CreateProjectModel(ApplicationDbContext context)
        {
            _context = context;
        }

        // [BindProperty] automatically attaches the HTML form inputs by matching their 'name=' tags!
        [BindProperty, Required, StringLength(80)]
        public string ProjectName { get; set; } = string.Empty;

        [BindProperty, Required, StringLength(2000)]
        public string Description { get; set; } = string.Empty;

        [BindProperty, Required, StringLength(24)]
        public string CurrentStage { get; set; } = "Ideating";

        [BindProperty, StringLength(120)]
        public string SupportNeeded { get; set; } = string.Empty;

        [BindProperty, StringLength(200)]
        public string MilestoneUpdate { get; set; } = string.Empty;

        [BindProperty, Range(0, 100)]
        public int Progress { get; set; }

        public void OnGet() { }

        public async Task<IActionResult> OnPostAsync()
        {
            ProjectName = (ProjectName ?? string.Empty).Trim();
            Description = (Description ?? string.Empty).Trim();
            CurrentStage = string.IsNullOrWhiteSpace(CurrentStage) ? "Ideating" : CurrentStage.Trim();
            SupportNeeded = (SupportNeeded ?? string.Empty).Trim();
            MilestoneUpdate = (MilestoneUpdate ?? string.Empty).Trim();

            if (!ModelState.IsValid)
            {
                return Page();
            }

            var newProject = new Project
            {
                Title = ProjectName,
                Description = Description,
                Stage = CurrentStage,
                SupportRequired = SupportNeeded,
                DeveloperId = User.Identity?.Name ?? "Alex Kim",
                CreatedAt = DateTime.UtcNow
            };

           
            _context.Projects.Add(newProject);
            await _context.SaveChangesAsync();

            
            return RedirectToPage("/Index");
        }

    }
}
