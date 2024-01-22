using Microsoft.EntityFrameworkCore;
using ResTIConnect.Domain;

namespace ResTIConnect.Infra;

public class ResTIConnectContext : DbContext
{
    public DbSet<Log>? Logs { get; set; }
    public DbSet<Endereco>? Enderecos { get; set; }
    public DbSet<Perfil>? Perfis { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        var connectionString = "server=localhost;user=root;password=tic2023;database=resticonnectdb";
        var serverVersion = ServerVersion.AutoDetect(connectionString);

        optionsBuilder.UseMySql(connectionString, serverVersion);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

    }
}
