﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FinalProject.Data;
using FinalProject.Models;
using Microsoft.AspNetCore.Authorization;

namespace FinalProject.Pages.Buildings
{
    [Authorize(Roles = nameof(UserRole.Manager))]
    public class IndexModel : PageModel
    {
        private readonly FinalProject.Data.FinalProjectContext _context;

        public IndexModel(FinalProject.Data.FinalProjectContext context)
        {
            _context = context;
        }

        public IList<Building> Building { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Building = await _context.Building.ToListAsync();
        }
    }
}
