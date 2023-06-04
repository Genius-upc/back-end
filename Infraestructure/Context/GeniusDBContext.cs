using Infraestructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Context;

public class GeniusDBContext : DbContext
{
    public GeniusDBContext(){}
    
    public GeniusDBContext(DbContextOptions<GeniusDBContext> options) : base(options){}
    
    public DbSet<Owner> Owners { get; set; }
    
    //Configuracion
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));
            optionsBuilder.UseMySql("Server=localhost,3306;Uid=root;Pwd=admin;Database=geniusdb", serverVersion);
        }
    }
    
    //Tablas
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        //Entity
        builder.Entity<Owner>().ToTable("Owners");
        builder.Entity<Owner>().HasKey(p => p.Id);
        builder.Entity<Owner>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Owner>().Property(n => n.firstName).HasMaxLength(30);
        builder.Entity<Owner>().Property(l => l.lastName).HasMaxLength(30);
        builder.Entity<Owner>().Property(a => a.age);
        builder.Entity<Owner>().Property(c => c.phone).HasPrecision(9);
    }
}