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

namespace FinalProject.Pages.Appointments
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly FinalProject.Data.FinalProjectContext _context;

        public CreateModel(FinalProject.Data.FinalProjectContext context)
        {
            _context = context;
        }

        public List<SelectListItem> Tenants { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> Apartments { get; set; } = new List<SelectListItem>();

        [BindProperty]
        public int SelectedTenant { get; set; }

        [BindProperty]
        public int SelectedApartment { get; set; }

        [BindProperty]
        public int CurrentApartmentId { get; set; }

        public IActionResult OnGet(int apartmentId)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            var userId = int.Parse(userIdClaim.Value); ;
            Tenants = _context.User
                .Where(u => u.UserId != userId && u.Role  == UserRole.Tenant)
                .Select(u => new SelectListItem
                {
                    Value = u.UserId.ToString(),
                    Text = u.FirstName + " " + u.LastName
                }).ToList();

            Apartments = _context.Apartment
                .Where(a => a.ManagerId == userId)
                .Select(a => new SelectListItem
                {
                    Value = a.ApartmentId.ToString(),
                    Text = "Building: " + a.Buildingid + "Apartment Number: " + a.ApartmentNumber
                }).ToList();

            CurrentApartmentId = apartmentId;
            return Page();
        }

        [BindProperty]
        public Appointment Appointment { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var now = DateTime.Now;
            var minDate = DateTime.Today;
            var maxDate = minDate.AddDays(6);


            Appointment.Status = AppointmentStatus.Pending;

            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            if (User.IsInRole("Tenant"))
            {
                Appointment.TenantId = userId;
                Appointment.ApartmentId = CurrentApartmentId;
            }
            else if (User.IsInRole("Manager"))
            {
                Appointment.TenantId = SelectedTenant;
                Appointment.ApartmentId = SelectedApartment;
            }

            _context.Appointment.Add(Appointment);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

    }
}