using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechAdvocacia.Core.Entities;

namespace TechAdvocacia.Infrastructure.Persistence.Configurations;
public class LegalCaseConfigurations : IEntityTypeConfiguration<LegalCase>
{
    public void Configure(EntityTypeBuilder<LegalCase> builder)
    {
        builder
           .ToTable("LegalCases")
           .HasKey(lc => lc.LegalCaseId);

        // relacionamentos
        builder
            .HasOne(lc => lc.Client)
            .WithMany(c => c.LegalCases)
            .HasForeignKey(lc => lc.ClientId);
        
        builder
            .HasOne(lc => lc.Lawyer)
            .WithMany(l => l.LegalCases)
            .HasForeignKey(lc => lc.LawyerId);

    }
}
