using Microsoft.EntityFrameworkCore;
using TechMed.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TechMed.Infrastructure.Persistence.Configurations;
public class ExameConfigurations : IEntityTypeConfiguration<Exame>
{
    public void Configure(EntityTypeBuilder<Exame> builder)
    {
        builder
            .ToTable("Exames")
            .HasKey(e => e.ExameId);

        builder
           .HasOne(a => a.Atendimento)
           .WithMany(e => e.Exames)
           .HasForeignKey(a => a.AtendimentoId);
    }
}
