using Domain.Models.Categories;
using Domain.Models.SubCategories;
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
    public DbSet<Category> Categories { get; set; }
    
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
        modelBuilder.Entity<Category>(user =>
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserMapping).Assembly);
        });
        modelBuilder.Entity<SubCategory>(user =>
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserMapping).Assembly);
        });
    }
}