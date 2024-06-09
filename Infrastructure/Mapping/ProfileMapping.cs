using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Models.Users;

namespace Infrastructure.Mapping;

public class ProfileMapping : IEntityTypeConfiguration<Profile>
{
    public void Configure(EntityTypeBuilder<Profile> builder)
    {
        builder.ToTable("Profile").HasKey(p => p.Id);
        builder.Property(p => p.Bio).HasMaxLength(500).IsRequired();
        builder.Property(p => p.Address).HasMaxLength(500).IsRequired();
    }
}