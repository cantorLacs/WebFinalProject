using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FinalProject.Data;
using FinalProject.Models;

namespace FinalProject.Pages.Appointments
{
    public class EditModel : PageModel
    {
        private readonly FinalProject.Data.FinalProjectContext _context;

        public EditModel(FinalProject.Data.FinalProjectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Appointment Appointment { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _context.Appointment.FirstOrDefaultAsync(m => m.AppointmentId == id);
            if (appointment == null)
            {
                return NotFound();
            }
            Appointment = appointment;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var appointmentToUpdate = await _context.Appointment.FindAsync(Appointment.AppointmentId);
            if (appointmentToUpdate == null)
            {
                return NotFound();
            }

            if (User.IsInRole("Manager"))
            {
                appointmentToUpdate.Status = Appointment.Status;
            }

            if (User.IsInRole("Tenant"))
            {
                appointmentToUpdate.Date = Appointment.Date;
                appointmentToUpdate.Notes = Appointment.Notes;
            }

            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
