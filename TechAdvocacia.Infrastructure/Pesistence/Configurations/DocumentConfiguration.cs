using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechAdvocacia.Core.Entities;

namespace TechAdvocacia.Infrastructure.Persistence.Configurations;
public class DocumentConfigurations : IEntityTypeConfiguration<Document>
{
   public void Configure(EntityTypeBuilder<Document> builder)
   {
      builder
         .ToTable("Documents")
         .HasKey(d => d.DocumentId);
      
      builder
         .HasOne(d => d.LegalCase)
         .WithMany(lc => lc.Documents)
         .HasForeignKey(d => d.LegalCaseId);
   }
}
