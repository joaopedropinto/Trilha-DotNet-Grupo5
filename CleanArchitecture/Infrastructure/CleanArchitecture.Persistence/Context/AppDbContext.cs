using Microsoft.EntityFrameworkCore;
using CleanArchitecture.Domain.Entities; // Verifique se o namespace está correto

namespace CleanArchitecture.Persistence.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
