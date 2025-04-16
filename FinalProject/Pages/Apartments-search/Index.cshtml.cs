using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FinalProject.Data;
using FinalProject.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace FinalProject.Pages.Apartments_search
{
    public class IndexModel : PageModel
    {
        private readonly FinalProject.Data.FinalProjectContext _context;

        public IndexModel(FinalProject.Data.FinalProjectContext context)
        {
            _context = context;
        }

        public IList<Apartment> Apartment { get;set; } = default!;

        public async Task OnGetAsync()
        {
            var query = _context.Apartment.AsQueryable();

            Apartment = await query.Where(a => a.Status != ApartmentStatus.Occupied).ToListAsync();
        }
    }
}
