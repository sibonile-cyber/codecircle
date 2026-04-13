using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CodeCircle.Data;
using CodeCircle.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeCircle.Pages
{
    public class ProfileModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public ProfileModel(ApplicationDbContext db)
        {
            _db = db;
        }

      
        public string CurrentDeveloper { get; set; } = string.Empty;

        
        public IList<Celebration> DeveloperWins { get; set; } = new List<Celebration>();

       
        public async Task<IActionResult> OnGetAsync(string? username)
        {
            if (string.IsNullOrEmpty(username))
            {
               
                return RedirectToPage("/Index");
            }

            
            CurrentDeveloper = username;

            
            if (_db.Celebrations != null)
            {
                DeveloperWins = await _db.Celebrations
                    .Where(c => c.DeveloperName == CurrentDeveloper)
                    .OrderByDescending(c => c.CreatedAt)
                    .ToListAsync();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostRequestCollabAsync(string receiverUserName)
        {
            var senderUser = (User.Identity?.IsAuthenticated == true ? User.Identity?.Name : null) ?? "Alex Kim";

            var req = new CollabRequest
            {
                SenderUserName = senderUser,
                ReceiverUserName = string.IsNullOrEmpty(receiverUserName) ? "TargetUser" : receiverUserName,
                ProjectName = "DevFlow",
                ProjectDescription = "AI code review tool",
                RoleRequested = "Backend dev",
                SkillsRequested = "Python, C#",
                Message = $"Hi {receiverUserName}, I'd love to collaborate with you!",
                Status = "Pending"
            };

            _db.CollabRequests.Add(req);
            await _db.SaveChangesAsync();

            // Redirect back or pass a flag to show UI success state
            TempData["CollabRequested"] = true;
            return RedirectToPage(new { username = receiverUserName });
        }
    }
}
