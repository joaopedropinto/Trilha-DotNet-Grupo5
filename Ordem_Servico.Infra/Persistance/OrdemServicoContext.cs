using Microsoft.EntityFrameworkCore;
using Ordem_Servico.Domain.Entities;

public class OrdemServicoContext : DbContext
{
    public DbSet<OrdemServico> OrdemServico { get; set; }
    public DbSet<Finalizacao> Finalizacao { get; set; }
    public DbSet<Cliente> Cliente { get; set; }
    public DbSet<Tecnico> Tecnico { get; set; }
    public DbSet<Equipamento> Equipamento { get; set; }
    public DbSet<Servico> Servico { get; set; }
    public DbSet<Ocorrencia> Ocorrencia { get; set; }
    public DbSet<Peca> Peca { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        var connectionString = "server=localhost;user=root;password=tic2023;database=ordemservicodb";
        var serverVersion = ServerVersion.AutoDetect(connectionString);

        optionsBuilder.UseMySql(connectionString, serverVersion);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Finalizacao>().ToTable("Finalizacao").HasKey(f => f.FinalizacaoID);
        modelBuilder.Entity<OrdemServico>().ToTable("OrdemServico").HasKey(o => o.OrdemServicoID);
        modelBuilder.Entity<Cliente>().ToTable("Cliente").HasKey(c => c.ClienteID);
        modelBuilder.Entity<Tecnico>().ToTable("Tecnico").HasKey(t => t.TecnicoID);
        modelBuilder.Entity<Equipamento>().ToTable("Equipamento").HasKey(e => e.EquipamentoID);
        modelBuilder.Entity<Servico>().ToTable("Servico").HasKey(s => s.ServicoID);
        modelBuilder.Entity<Ocorrencia>().ToTable("Ocorrencia").HasKey(o => o.OcorrenciaID);
        modelBuilder.Entity<Peca>().ToTable("Peca").HasKey(p => p.PecaID);

        modelBuilder.Entity<OrdemServico>()
            .HasOne(os => os.Finalizacao)
            .WithOne(f => f.OrdemServico)
            .HasForeignKey<Finalizacao>(os => os.FinalizacaoID);
        
        modelBuilder.Entity<OrdemServico>()
            .HasOne(o => o.Cliente)
            .WithMany(c => c.OrdemServicos)
            .HasForeignKey(o => o.ClienteID);
        
        modelBuilder.Entity<OrdemServico>()
            .HasOne(o => o.Tecnico)
            .WithMany(t => t.OrdemServicos)
            .HasForeignKey(o => o.TecnicoID);

        modelBuilder.Entity<OrdemServico>()
            .HasMany(o => o.Equipamentos)
            .WithMany(e => e.OrdemServicos);

        modelBuilder.Entity<OrdemServico>()
            .HasMany(o => o.Servicos)
            .WithMany(s => s.OrdemServicos);
        
        modelBuilder.Entity<OrdemServico>()
            .HasMany(o => o.Ocorrencias)
            .WithMany(o => o.OrdemServicos);

        modelBuilder.Entity<OrdemServico>()
            .HasMany(o => o.Pecas)
            .WithMany(p => p.OrdemServicos);
        
    }
}