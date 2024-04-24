using Microsoft.EntityFrameworkCore;
using WebMarker.Models;

namespace WebMarker.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        public DbSet<AppUser> AppUsers { get; set; }
    }
}
