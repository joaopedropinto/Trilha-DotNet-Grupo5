using Microsoft.EntityFrameworkCore;
using TechMed.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TechMed.Infrastructure.Persistence.Configurations;
public class AtendimentoConfigurations : IEntityTypeConfiguration<Atendimento>
{
    public void Configure(EntityTypeBuilder<Atendimento> builder)
    {
        builder
           .ToTable("Atendimentos")
           .HasKey(a => a.AtendimentoId);

        builder
           .HasOne(m => m.Medico)
           .WithMany(a => a.Atendimentos)
           .HasForeignKey(m => m.MedicoId);

        builder
           .HasOne(p => p.Paciente)
           .WithMany(a => a.Atendimentos)
           .HasForeignKey(p => p.PacienteId);
    }
}
