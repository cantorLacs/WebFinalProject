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

namespace FinalProject.Pages.Appointments
{
    public class IndexModel : PageModel
    {
        private readonly FinalProject.Data.FinalProjectContext _context;

        public IndexModel(FinalProject.Data.FinalProjectContext context)
        {
            _context = context;
        }

        public IList<Appointment> Appointment { get;set; } = default!;

        public async Task OnGetAsync()
        {
            var query = _context.Appointment.AsQueryable();
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);

            if (userIdClaim != null)
            {
                var userId = int.Parse(userIdClaim.Value);

                Appointment = await query.Where(m => m.TenantId == userId || m.ManagerId == userId).ToListAsync();
               
            }
            else
            {
                Appointment = new List<Appointment>();

            }
        }

    public async Task<IActionResult> OnPostAsync(string action, int id)
    {
        if (action == "Cancel")
        {
                var appointment = await _context.Appointment.FindAsync(id);
                if (appointment == null)
                {
                    return NotFound();
                }
                appointment.Status = AppointmentStatus.Canceled;
                await _context.SaveChangesAsync();

                return RedirectToPage("./Index");
            }
        return Page();
    }
        }
}
