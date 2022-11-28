using System.Text;
using exchange_rates_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace exchange_rates_backend.Persistence;

public class AppDbContext : DbContext
{
    public DbSet<UserEntity> UserEntities { get; set; } = null!;

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<UserEntity>(entity => { entity.HasIndex(e => e.Email).IsUnique(); });
        modelBuilder.Entity<UserEntity>(entity => { entity.HasIndex(e => e.Id).IsUnique(); });
        modelBuilder.Entity<UserEntity>().Property(entity => entity.Id).ValueGeneratedOnAdd();
    }
}