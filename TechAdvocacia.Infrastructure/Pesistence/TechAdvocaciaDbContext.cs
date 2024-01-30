using Microsoft.EntityFrameworkCore;
using TechAdvocacia.Core.Entities;

namespace TechAdvocacia.Infrastructure.Persistence;
public class TechAdvocaciaDbContext : DbContext
{
   public DbSet<Lawyer> Lawyers { get; set; }
   public DbSet<Client> Clients { get; set; }
   public DbSet<Document> Documents { get; set; }
   public DbSet<LegalCase> LegalCases { get; set; }

   public TechAdvocaciaDbContext(DbContextOptions<TechAdvocaciaDbContext> options) : base(options)
   {
      //Database.EnsureCreated();
   }

   protected override void OnModelCreating(ModelBuilder modelBuilder)
   {
      base.OnModelCreating(modelBuilder);

      modelBuilder.ApplyConfigurationsFromAssembly(typeof(TechAdvocaciaDbContext).Assembly);
   }
}
