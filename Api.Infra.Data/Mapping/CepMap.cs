using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Infra.Data.Mapping
{
  public class CepMap : IEntityTypeConfiguration<CepEntity>
  {
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<CepEntity> builder)
    {
      builder.ToTable("Ceps");

      builder.HasKey(c => c.Id);
			builder.HasIndex(c => c.Cep)
							.IsUnique();
			builder.Property(c => c.Cep)
							.IsRequired()
							.HasMaxLength(10);
			builder.Property(c => c.Logradouro)
							.IsRequired()
							.HasMaxLength(150);
			builder.Property(c => c.Numero)
							.IsRequired()
							.HasMaxLength(15);
			builder.HasOne(c => c.County)
              .WithMany(m => m.Ceps);

    }
  }
}