using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CodeCircle.Data;
using CodeCircle.Models;

namespace CodeCircle.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        // Injecting the database translator
        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        // The list that will hold all our retrieved projects
        public IList<Project> Projects { get; set; } = new List<Project>();

        public async Task OnGetAsync()
        {
            // Fetch everything from SQL, newest on top!
            Projects = await _db.Projects.OrderByDescending(p => p.CreatedAt).ToListAsync();
        }
    }
}
