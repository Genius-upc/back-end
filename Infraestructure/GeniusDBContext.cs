using Genius.Infraestructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Genius.Infraestructure.Context;

public class GeniusDBContext:DbContext
{
    public GeniusDBContext()
    {
        
    }
    public GeniusDBContext(DbContextOptions<GeniusDBContext> options) : base(options)
    {
    }
    public DbSet<Driver> Drivers { get; set; }
    public DbSet<Car> Cars { get; set; }
    public object Rents { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));
            optionsBuilder.UseMySql("Server=sql10.freemysqlhosting.net,3306;Uid=sql10623959;Pwd=E9CcQSHYEv;Database=sql10623959", serverVersion);
        }
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        //Drives Table
        builder.Entity<Driver>().ToTable("Drivers");
        builder.Entity<Driver>().HasKey(p => p.Id);
        builder.Entity<Driver>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Driver>().Property(c => c.Phone).IsRequired().HasMaxLength(9);
        
        //Cars Table
        builder.Entity<Car>().ToTable("Cars");
        builder.Entity<Car>().HasKey(p => p.Id);
        builder.Entity<Car>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Car>().Property(c => c.Placa).IsRequired().HasMaxLength(10);
        builder.Entity<Driver>().Property(p=>p.Id).IsRequired().ValueGeneratedOnAdd();

        
        
    }
    
}
