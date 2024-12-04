using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Models.Users;

namespace Infrastructure.Mapping;

public class UserMapping : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("User").HasKey(p => p.Id);
        builder.Property(p => p.Username).HasMaxLength(150).IsRequired();
        builder.Property(p => p.Mobile).HasMaxLength(11).IsRequired();
    }
}