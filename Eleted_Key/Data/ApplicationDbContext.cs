using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Eleted_Key.Controllers.Models;
using Eleted_Key.Models;

namespace Eleted_Key.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Aici poți adăuga orice alte seturi de date specifice aplicației tale
        public DbSet<User> User { get; set; } = null!;
    }
}
