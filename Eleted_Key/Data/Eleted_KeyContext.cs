using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Eleted_Key.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Eleted_Key.Data
{
    public class Eleted_KeyContext : IdentityDbContext<ApplicationUser>
    {
        public Eleted_KeyContext (DbContextOptions<Eleted_KeyContext> options)
            : base(options)
        {
        }

        public DbSet<Eleted_Key.Models.Game> Game { get; set; } = default!;



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>()
                .Property(g => g.Price)
                .HasColumnType("decimal(18,2)");

            base.OnModelCreating(modelBuilder);
        }
    }
}
