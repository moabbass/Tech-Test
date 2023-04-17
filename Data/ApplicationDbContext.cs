using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Verto.Models;

namespace Verto.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Verto.Models.Product> Product { get; set; } = default!;

        public DbSet<Verto.Models.Detail>? Detail { get; set; }

        public DbSet<Verto.Models.SpecialOffer>? SpecialOffer { get; set; }
    }
}
