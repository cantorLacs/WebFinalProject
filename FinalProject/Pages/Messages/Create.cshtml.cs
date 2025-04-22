using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FinalProject.Data;
using FinalProject.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace FinalProject.Pages.Messages
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly FinalProject.Data.FinalProjectContext _context;
        public List<SelectListItem> Receivers { get; set; } = new List<SelectListItem>();

        [BindProperty(SupportsGet = true)]
        public int ApartmentId { get; set; }

        [BindProperty]
        public Message Message { get; set; } = default!;

        [BindProperty]
        public int SelectedReceiver { get; set; }

        public CreateModel(FinalProject.Data.FinalProjectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet(int? apartmentId)
        {
            if (apartmentId.HasValue)
            {
                ApartmentId = apartmentId.Value;
            }

            if (!User.IsInRole("Tenant"))
            {
                var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
                var userId = int.Parse(userIdClaim.Value); ;
                Receivers = _context.User
                    .Where(u => u.UserId != userId)
                    .Select(a => new SelectListItem
                    {
                        Value = a.UserId.ToString(),
                        Text = a.FirstName + " " + a.LastName
                    }).ToList();

            }
            return Page();
        }


        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            Message.SenderId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            Message.SendDate = DateTime.Now;
            Message.IsRead = false;

            if (User.IsInRole("Tenant"))
            {
                var managerId = _context.Apartment
                    .Where(a => a.ApartmentId == ApartmentId)
                    .Select(a => a.ManagerId)
                    .FirstOrDefault();

                Message.ReceiverId = managerId;
            }
            else
            {
                Message.ReceiverId = SelectedReceiver;
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Message.Add(Message);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

    }
}
