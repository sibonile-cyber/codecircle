using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CodeCircle.Data;
using CodeCircle.Models;

namespace CodeCircle.Pages
{
    public class CollabRequestsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CollabRequestsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<CollabRequest> ReceivedRequests { get; set; } = new List<CollabRequest>();
        public List<CollabRequest> SentRequests { get; set; } = new List<CollabRequest>();

        public async Task OnGetAsync()
        {
            var currentUser = User.Identity != null && User.Identity.IsAuthenticated
                              ? User.Identity.Name
                              : "Alex Kim";

            ReceivedRequests = await _context.CollabRequests
                .Where(r => r.ReceiverUserName == currentUser)
                .OrderByDescending(r => r.CreatedAt)
                .ToListAsync();

            SentRequests = await _context.CollabRequests
                .Where(r => r.SenderUserName == currentUser)
                .OrderByDescending(r => r.CreatedAt)
                .ToListAsync();
        }

        public async Task<IActionResult> OnPostAcceptAsync(int requestId)
        {
            var req = await _context.CollabRequests.FindAsync(requestId);
            if (req != null)
            {
                req.Status = "Accepted";
                await _context.SaveChangesAsync();
            }
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostDeclineAsync(int requestId)
        {
            var req = await _context.CollabRequests.FindAsync(requestId);
            if (req != null)
            {
                req.Status = "Declined";
                await _context.SaveChangesAsync();
            }
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostWithdrawAsync(int requestId)
        {
            var req = await _context.CollabRequests.FindAsync(requestId);
            if (req != null)
            {
                _context.CollabRequests.Remove(req);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage();
        }
    }
}
