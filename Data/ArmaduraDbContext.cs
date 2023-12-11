using Microsoft.EntityFrameworkCore;
using ReinosAcoWebApp.Models;

namespace ReinosAcoWebApp.Data;

public class ArmaduraDbContext : DbContext
{
    public DbSet<Armadura> Armadura { get; set; }
    public DbSet<Autenticidade> Autenticidade { get; set; }
    public DbSet<Material> Material { get; set; } 

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var stringConn = config.GetConnectionString("StringConn");

        optionsBuilder.UseSqlServer(stringConn);
    }
}
