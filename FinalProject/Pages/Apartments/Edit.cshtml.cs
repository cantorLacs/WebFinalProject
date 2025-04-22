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
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace FinalProject.Pages.Apartments
{
    [Authorize(Roles = nameof(UserRole.Manager))]
    public class EditModel : PageModel
    {
        private readonly FinalProject.Data.FinalProjectContext _context;

        public EditModel(FinalProject.Data.FinalProjectContext context)
        {
            _context = context;
        }

        public List<SelectListItem> Tenants { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> StatusOptions { get; set; } = new List<SelectListItem>();


        [BindProperty]
        public Apartment Apartment { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apartment =  await _context.Apartment.FirstOrDefaultAsync(m => m.ApartmentId == id);

            if (apartment == null)
            {
                return NotFound();
            }
            Apartment = apartment;



            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            var userId = int.Parse(userIdClaim.Value); ;
            Tenants = _context.User
                .Where(u => u.UserId != userId)
                .Select(u => new SelectListItem
                {
                    Value = u.UserId.ToString(),
                    Text = u.FirstName + " " + u.LastName
                }).ToList();
            
            Tenants.Add(new SelectListItem { Value = "0", Text = "None" });

            StatusOptions = Enum.GetValues(typeof(ApartmentStatus))
                .Cast<ApartmentStatus>()
                .Select(e => new SelectListItem
                {
                    Value = e.ToString(),
                    Text = e.ToString()
                }).ToList();
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

            // Recuperar el valor actual de ImagePath desde la base de datos si no se proporciona uno nuevo
            var existingApartment = await _context.Apartment.AsNoTracking()
                .FirstOrDefaultAsync(a => a.ApartmentId == Apartment.ApartmentId);

            if (existingApartment == null)
            {
                return NotFound();
            }

            // Si no se proporciona un nuevo valor para ImagePath, mantener el valor existente
            if (string.IsNullOrEmpty(Apartment.ImagePath))
            {
                Apartment.ImagePath = existingApartment.ImagePath;
            }

            Apartment.ManagerId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            _context.Attach(Apartment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApartmentExists(Apartment.ApartmentId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ApartmentExists(int id)
        {
            return _context.Apartment.Any(e => e.ApartmentId == id);
        }
    }
}
