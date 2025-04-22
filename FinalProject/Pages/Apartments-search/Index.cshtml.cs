using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FinalProject.Data;
using FinalProject.Models;

namespace FinalProject.Pages.Apartments_search
{
    public class IndexModel : PageModel
    {
        private readonly FinalProject.Data.FinalProjectContext _context;

        public IndexModel(FinalProject.Data.FinalProjectContext context)
        {
            _context = context;
        }

        public IList<Apartment> Apartments { get; set; } = default!;
        public IList<Building> Buildings { get; set; } = new List<Building>();

        public async Task OnGetAsync(int? buildingId)
        {
            Buildings = await _context.Building.ToListAsync();
            Apartments = await _context.Apartment
                .Where(a => a.Status != ApartmentStatus.Occupied)
                .ToListAsync();
        }
    }
}