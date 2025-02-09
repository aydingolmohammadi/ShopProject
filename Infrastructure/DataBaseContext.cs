using Domain.Models.Categories;
using Domain.Models.OrderItems;
using Domain.Models.Orders;
using Domain.Models.Products;
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
    public DbSet<SubCategory> SubCategories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    
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
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CategoryMapping).Assembly);
        });
        modelBuilder.Entity<SubCategory>(user =>
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SubCategoryMapping).Assembly);
        });
        modelBuilder.Entity<Product>(user =>
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductMapping).Assembly);
        });
        modelBuilder.Entity<Order>(user =>
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(OrderMapping).Assembly);
        });
        modelBuilder.Entity<OrderItem>(user =>
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(OrderItemMapping).Assembly);
        });
    }
}