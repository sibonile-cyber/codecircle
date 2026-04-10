using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CodeCircle.Data;
using CodeCircle.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeCircle.Pages
{
    public class CelebrationWallModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public CelebrationWallModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IList<Celebration> Celebrations { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_db.Celebrations != null)
            {
                Celebrations = await _db.Celebrations
                    .OrderByDescending(c => c.CreatedAt)
                    .ToListAsync();
            }
        }
    }
}

