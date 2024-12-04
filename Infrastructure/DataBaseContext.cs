using Microsoft.EntityFrameworkCore;
using Domain.Models.Users;
using Infrastructure.Mapping;

namespace Infrastructure;

public class DataBaseContext : DbContext
{
    public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(user =>
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserMapping).Assembly);
        });
    }
}