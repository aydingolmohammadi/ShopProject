using Domain.Models.SubCategories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mapping;

public class SubCategoryMapping : IEntityTypeConfiguration<SubCategory>
{
    public void Configure(EntityTypeBuilder<SubCategory> builder)
    {
        // نام جدول و کلید اصلی
        builder.ToTable("SubCategory").HasKey(sc => sc.Id);

        // تنظیمات فیلدها
        builder.Property(sc => sc.Name)
            .HasMaxLength(100)
            .IsRequired();

        // تنظیم روابط
        builder.HasOne(sc => sc.Category)
            .WithMany(c => c.SubCategories)
            .HasForeignKey(sc => sc.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(sc => sc.Product)
            .WithOne(p => p.SubCategory)
            .HasForeignKey(p => p.SubCategoryId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}