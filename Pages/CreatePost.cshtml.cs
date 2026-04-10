using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using CodeCircle.Data;
using CodeCircle.Models;

namespace CodeCircle.Pages
{
    public class CreatePostModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _env;

        public CreatePostModel(ApplicationDbContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }

        [BindProperty]
        public Celebration NewCelebration { get; set; } = new Celebration();

        [BindProperty]
        public IFormFile? UploadedImage { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            if (UploadedImage != null)
            {
               
                var uploadsFolder = Path.Combine(_env.WebRootPath, "images");
                Directory.CreateDirectory(uploadsFolder);

                
                var uniqueFileName = Guid.NewGuid().ToString() + "_" + UploadedImage.FileName;
                var filePath = Path.Combine(uploadsFolder, uniqueFileName);

             
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await UploadedImage.CopyToAsync(fileStream);
                }

                
                NewCelebration.ImagePath = "/images/" + uniqueFileName;
            }

            NewCelebration.CreatedAt = DateTime.UtcNow;

            
            _db.Celebrations.Add(NewCelebration);
            await _db.SaveChangesAsync();

            return RedirectToPage("/Index");
        }
    }
}
