using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechAdvocacia.Core.Entities;

namespace TechAdvocacia.Infrastructure.Persistence.Configurations;
public class LawyerConfigurations : IEntityTypeConfiguration<Lawyer>
{
   public void Configure(EntityTypeBuilder<Lawyer> builder)
   {
      builder
         .ToTable("Lawyers")
         .HasKey(l => l.LawyerId);
   }
}
