using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FinalProject.Models;

namespace FinalProject.Data
{
    public class FinalProjectContext : DbContext
    {
        public FinalProjectContext (DbContextOptions<FinalProjectContext> options)
            : base(options)
        {
        }

        public DbSet<FinalProject.Models.Apartment> Apartment { get; set; } = default!;
        public DbSet<FinalProject.Models.User> User { get; set; } = default!;
        public DbSet<FinalProject.Models.Appointment> Appointment { get; set; } = default!;
        public DbSet<FinalProject.Models.Building> Building { get; set; } = default!;
        public DbSet<FinalProject.Models.Message> Message { get; set; } = default!;
    }
}
