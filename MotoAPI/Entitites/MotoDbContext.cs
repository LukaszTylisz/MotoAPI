using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace MotoAPI.Entitites;

public class MotoDbContext : DbContext
{
    public MotoDbContext(DbContextOptions<MotoDbContext> options) : base(options)
    {
        
    }
        
    public DbSet<Moto> Motos { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Car> Cars { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .Property(u => u.Email)
            .IsRequired();
        
        modelBuilder.Entity<Role>()
            .Property(u => u.Name)
            .IsRequired();
        
        modelBuilder.Entity<Moto>()
            .Property(m => m.Name)
            .IsRequired()
            .HasMaxLength(50);

        modelBuilder.Entity<Car>()
            .Property(c => c.Model) 
            .IsRequired();

        modelBuilder.Entity<Address>()
            .Property(a => a.City)
            .IsRequired()
            .HasMaxLength(50);
        
        modelBuilder.Entity<Address>()
            .Property(a => a.Street)
            .IsRequired()
            .HasMaxLength(50);
    }
}