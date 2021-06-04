using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Infra.Data.Mapping
{
  public class CountyMap : IEntityTypeConfiguration<CountyEntity>
  {
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<CountyEntity> builder)
    {
      builder.ToTable("Counties");

      builder.HasKey(u => u.Id);
			builder.HasIndex(u => u.CodeIBGE)
							.IsUnique();
			builder.Property(u => u.Name)
							.IsRequired()
							.HasMaxLength(150);
			builder.Property(u => u.CodeIBGE)
              .IsRequired();
      builder.HasOne(u => u.Uf)
              .WithMany(m => m.Counties);
    }
  }
}