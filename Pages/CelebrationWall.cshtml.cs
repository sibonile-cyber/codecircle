using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CodeCircle.Data;
using CodeCircle.Models;

namespace CodeCircle.Pages
{
    public class CelebrationWallModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public CelebrationWallModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IList<Project> CompletedProjects { get; set; } = new List<Project>();

        public async Task OnGetAsync()
        {
            // Only fetch projects that have reached the finish line!
            CompletedProjects = await _db.Projects
                                         .Where(p => p.Stage == "Completed")
                                         .OrderByDescending(p => p.CreatedAt)
                                         .ToListAsync();
        }
    }
}

