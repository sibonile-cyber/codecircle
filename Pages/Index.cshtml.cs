using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CodeCircle.Data;
using CodeCircle.Models;

namespace CodeCircle.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;


        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }


        public IList<Project> Projects { get; set; } = new List<Project>();

        public IList<Celebration> Celebrations { get; set; } = default!;

        public async Task OnGetAsync()
        {
            // Fetch your existing Projects
            Projects = await _db.Projects.OrderByDescending(p => p.CreatedAt).ToListAsync();

            // Fetch the 5 most recent Celebrations using _db instead of _context
            if (_db.Celebrations != null)
            {
                Celebrations = await _db.Celebrations
                     .OrderByDescending(c => c.CreatedAt)
                     .Take(5)
                     .ToListAsync();
            }
        }

    }

}