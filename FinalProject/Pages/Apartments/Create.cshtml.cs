﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FinalProject.Data;
using FinalProject.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace FinalProject.Pages.Apartments
{

    public class CreateModel : PageModel
    {
        private readonly FinalProject.Data.FinalProjectContext _context;

        public CreateModel(FinalProject.Data.FinalProjectContext context)
        {
            _context = context;
        }

        public List<SelectListItem> Buildings { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> StatusOptions { get; set; } = new List<SelectListItem>();

        [BindProperty]
        public int SelectedBuildingId { get; set; }

        [BindProperty]
        public IFormFile ImageFile { get; set; }
        public IActionResult OnGet()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            var userId = int.Parse(userIdClaim.Value); ;
            Buildings = _context.Building
                .Where(b => b.ManagerId == userId)
                .Select(b => new SelectListItem
                {
                    Value = b.BuildingId.ToString(),
                    Text = b.Name
                }).ToList();

            StatusOptions = Enum.GetValues(typeof(ApartmentStatus))
                .Cast<ApartmentStatus>()
                .Select(e => new SelectListItem
                {
                    Value = e.ToString(),
                    Text = e.ToString()
                }).ToList();

            return Page();
        }

        [BindProperty]
        public Apartment Apartment { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Apartment.Buildingid = SelectedBuildingId;

            if (ImageFile != null && ImageFile.Length > 0)
            {
                var uploads = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");
                var filePath = Path.Combine(uploads, ImageFile.FileName);

                try
                {
                    if (!Directory.Exists(uploads))
                    {
                        Directory.CreateDirectory(uploads);
                    }

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await ImageFile.CopyToAsync(fileStream);
                    }

                    Apartment.ImagePath = $"/images/{ImageFile.FileName}";
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, "Error uploading image: " + ex.Message);
                    return Page();
                }
            }
            else
            {
                Apartment.ImagePath = null; 
            }
            
            Apartment.ManagerId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

            _context.Apartment.Add(Apartment);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
