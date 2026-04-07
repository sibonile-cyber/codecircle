using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CodeCircle.Data;
using CodeCircle.Models;

namespace CodeCircle.Pages
{
    public class CreateProjectModel : PageModel
    {
        private readonly ApplicationDbContext _db;

       
        public CreateProjectModel(ApplicationDbContext db)
        {
            _db = db;
        }


        [BindProperty]
        public Project NewProject { get; set; } = new Project();

        public void OnGet()
        {
            
        }

        public IActionResult OnPost()
        {
            
            _db.Projects.Add(NewProject);
            _db.SaveChanges();

           
            return RedirectToPage("/Index");
        }
    }
}
