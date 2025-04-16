using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FinalProject.Data;
using FinalProject.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace FinalProject.Pages.Messages
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly FinalProject.Data.FinalProjectContext _context;

        public IndexModel(FinalProject.Data.FinalProjectContext context)
        {
            _context = context;
        }

        public IList<Message> Message { get; set; } = default!;
        public IList<Message> ReceivedMessages { get; set; } = default!;
        public IList<Message> SentMessages { get; set; } = default!;

        public async Task OnGetAsync(DateTime? startDate, DateTime? endDate)
        {
            var queryReceived = _context.Message.AsQueryable();
            var querySent = _context.Message.AsQueryable();


            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim != null)
            {
                var userId = int.Parse(userIdClaim.Value);

                ReceivedMessages = await queryReceived.Where(m => m.ReceiverId == userId).ToListAsync();
                SentMessages = await querySent.Where(m => m.SenderId == userId).ToListAsync();
            }
            else
            {
                ReceivedMessages = new List<Message>();
                SentMessages = new List<Message>();
            }
        }
    }
}
