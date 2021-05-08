using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Infra.Data.Mapping
{
  public class UserMap : IEntityTypeConfiguration<UserEntity>
  {
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<UserEntity> builder)
    {
      builder.ToTable("Users");

      builder.HasKey(u => u.Id);
			builder.HasIndex(u => u.Email)
							.IsUnique();
			builder.Property(u => u.Name)
							.IsRequired()
							.HasMaxLength(150);
			builder.Property(u => u.Email)
							.HasMaxLength(150);
    }
  }
}