using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Infra.Data.Mapping
{
  public class UfMap : IEntityTypeConfiguration<UfEntity>
  {
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<UfEntity> builder)
    {
      builder.ToTable("Ufs");

      builder.HasKey(u => u.Id);
			builder.HasIndex(u => u.Initials)
							.IsUnique();
			builder.Property(u => u.Name)
							.IsRequired()
							.HasMaxLength(150);
			builder.Property(u => u.Initials)
              .IsRequired()
							.HasMaxLength(2);
    }
  }
}