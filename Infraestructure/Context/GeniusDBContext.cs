using Infraestructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Context;

public class GeniusDBContext : DbContext
{
    public GeniusDBContext(){}
    
    public GeniusDBContext(DbContextOptions<GeniusDBContext> options) : base(options){}
    
    public DbSet<Owner> Owners { get; set; }
    public DbSet<Parking> Parkings { get; set; }
    public DbSet<Rent> Rents { get; set; }
    public DbSet<OwnerType.OwnerType> OwnerTypes { get; set; }

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
        
        builder.Entity<Parking>().ToTable("Parkings");
        builder.Entity<Parking>().HasKey(p => p.id_parking);
        builder.Entity<Parking>().Property(p => p.id_parking).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Parking>().Property(c => c.costPerHour);
        builder.Entity<Parking>().Property(a => a.address).HasMaxLength(50);
        builder.Entity<Parking>().Property(s => s.spaces);
        
        builder.Entity<Rent>().ToTable("Rents");
        builder.Entity<Rent>().HasKey(p => p.Id_rent);
        builder.Entity<Rent>().Property(p => p.Id_rent).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Rent>().Property(pt => pt.payment_type).HasMaxLength(25);
        builder.Entity<Rent>().Property(a => a.amount);
        
        //OwnerType
        builder.Entity<OwnerType.OwnerType>().ToTable("OwnerTypes");
        builder.Entity<OwnerType.OwnerType>().HasKey(i => i.idOwnerType);
        builder.Entity<OwnerType.OwnerType>().Property(i => i.idOwnerType).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<OwnerType.OwnerType>().Property(n => n.nameType).IsRequired().HasMaxLength(30);
        builder.Entity<OwnerType.OwnerType>().Property(d => d.description).IsRequired().HasMaxLength(50);

    }
}