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

namespace FinalProject.Pages.MyContracts
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

            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim != null)
            {
                var userId = int.Parse(userIdClaim.Value);

                Apartment = await query.Where(a => a.TenantId == userId).ToListAsync();

            }
            else
            {
                Apartment = new List<Apartment>();
            }

        }
    }
}
