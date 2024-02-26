using Microsoft.EntityFrameworkCore;
using ResTIConnect.Domain.Entities;

namespace ResTIConnect.Infra.Context;

public class ResTIConnectContext : DbContext
{
    public DbSet<Log> Logs { get; set; }
    public DbSet<Endereco> Enderecos { get; set; }
    public DbSet<Perfil> Perfis { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Evento> Eventos { get; set; }
    public DbSet<Sistema> Sistemas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        var connectionString = "server=localhost;user=root;password=tic2023;database=resticonnectdb";
        var serverVersion = ServerVersion.AutoDetect(connectionString);

        optionsBuilder.UseMySql(connectionString, serverVersion);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Log>().ToTable("Logs").HasKey(l => l.LogId);
        modelBuilder.Entity<Endereco>().ToTable("Enderecos").HasKey(e => e.EnderecoId);
        modelBuilder.Entity<Perfil>().ToTable("Perfis").HasKey(p => p.PerfilId);
        modelBuilder.Entity<Usuario>().ToTable("Usuarios").HasKey(u => u.UsuarioId);
        modelBuilder.Entity<Evento>().ToTable("Eventos").HasKey(e => e.EventoId);
        modelBuilder.Entity<Sistema>().ToTable("Sistemas").HasKey(s => s.Sistemald);

        modelBuilder.Entity<Usuario>()
            .HasOne(u => u.Endereco)
            .WithOne(e => e.Usuario)
            .HasForeignKey<Endereco>(e => e.UsuarioId);

        modelBuilder.Entity<Usuario>()
            .HasMany(u => u.Perfis)
            .WithOne(p => p.Usuario)
            .HasForeignKey(p => p.UsuarioId);

        modelBuilder.Entity<Sistema>()
            .HasMany(s => s.Usuarios)
            .WithMany(u => u.Sistemas)
            .UsingEntity<Dictionary<string, object>>(
                "SistemaUsuario",
                j => j
                    .HasOne<Usuario>()
                    .WithMany()
                    .HasForeignKey("UsuarioId"),
                j => j
                    .HasOne<Sistema>()
                    .WithMany()
                    .HasForeignKey("SistemaId")
            );

        modelBuilder.Entity<Sistema>()
            .HasMany(s => s.Eventos)
            .WithMany(e => e.Sistemas)
            .UsingEntity<Dictionary<string, object>>(
                "SistemaEvento",
                j => j
                    .HasOne<Evento>()
                    .WithMany()
                    .HasForeignKey("EventoId"),
                j => j
                    .HasOne<Sistema>()
                    .WithMany()
                    .HasForeignKey("SistemaId")
            );
    }
}
