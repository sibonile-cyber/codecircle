using CodeCircle.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;
using CodeCircle.Models;

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
        [BindProperty] public string ProjectName { get; set; } = string.Empty;
        [BindProperty] public string Description { get; set; } = string.Empty;
        [BindProperty] public string CurrentStage { get; set; } = string.Empty;
        [BindProperty] public string SupportNeeded { get; set; } = string.Empty;
        [BindProperty] public string MilestoneUpdate { get; set; } = string.Empty;
        [BindProperty] public int Progress { get; set; }

        public void OnGet() { }

        public async Task<IActionResult> OnPostAsync()
        {
            
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
