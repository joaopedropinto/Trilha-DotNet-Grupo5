using Microsoft.EntityFrameworkCore;
using ResTIConnect.Domain;

namespace ResTIConnect.Infra;

public class ResTIConnectContext : DbContext
{
    public DbSet<Log>? Logs { get; set; }
    public DbSet<Endereco>? Enderecos { get; set; }
    public DbSet<Perfil>? Perfis { get; set; }
    public DbSet<Usuario>? Usuarios { get; set; }

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

        modelBuilder.Entity<Usuario>()
            .HasOne(u => u.Endereco)
            .WithOne(e => e.Usuario)
            .HasForeignKey<Endereco>(e => e.EnderecoId);
        
        modelBuilder.Entity<Usuario>()
            .HasMany(u => u.Perfis)
            .WithOne(p => p.Usuario)
            .HasForeignKey(p => p.UsuarioId);
    }
}
