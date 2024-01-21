using Microsoft.EntityFrameworkCore;
using Ordem_Servico.Domain;

public class OrdemServicoContext : DbContext
{
    public DbSet<OrdemServico> OrdemServico { get; set; }
    public DbSet<Finalizacao> Finalizacao { get; set; }

    public OrdemServicoContext(DbContextOptions<OrdemServicoContext> options) : base(options)
    {
    }

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

        modelBuilder.Entity<OrdemServico>()
            .HasOne(os => os.Finalizacao)
            .WithOne(f => f.OrdemServico)
            .HasForeignKey<Finalizacao>(os => os.FinalizacaoID);
    }
}