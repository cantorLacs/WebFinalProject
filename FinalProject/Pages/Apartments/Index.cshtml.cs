using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FinalProject.Data;
using FinalProject.Models;

namespace FinalProject.Pages.Apartments
{
    public class IndexModel : PageModel
    {
        private readonly FinalProject.Data.FinalProjectContext _context;


        public IndexModel(FinalProject.Data.FinalProjectContext context)
        {
            _context = context;
        }

        public IList<Apartment> Apartment { get;set; } = default!;
        public IList<Building> Buildings { get; set; } = new List<Building>();

        public async Task OnGetAsync()
        {
            Buildings = await _context.Building.ToListAsync();
            Apartment = await _context.Apartment.ToListAsync();

        }
    }
}
