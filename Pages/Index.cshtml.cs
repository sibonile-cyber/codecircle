using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CodeCircle.Data;
 using CodeCircle.Data;
 using CodeCircle.Models;

namespace CodeCircle.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

       
        public List<Project> LiveFeedProjects { get; set; }

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task OnGetAsync()
        {
            
            LiveFeedProjects = await _context.Projects
                                     .OrderByDescending(p => p.CreatedAt)
                                     .ToListAsync();
        }
    }
}
