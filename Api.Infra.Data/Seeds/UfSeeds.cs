using System;
using System.Reflection.Emit;
using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Infra.Data.Seeds
{
    public class UfSeeds
    {
        public static void Ufs(ModelBuilder builder)
        {
            builder.Entity<UfEntity>().HasData(
                new UfEntity()
                {
                    Id = Guid.NewGuid(),
                    Initials = "AC",
                    Name = "Acre",
                    CreateAt = DateTime.UtcNow,
                    UpdateAt = DateTime.UtcNow
                },
                new UfEntity()
                {
                    Id = Guid.NewGuid(),
                    Initials = "SP",
                    Name = "São Paulo",
                    CreateAt = DateTime.UtcNow,
                    UpdateAt = DateTime.UtcNow
                },
                new UfEntity()
                {
                    Id = Guid.NewGuid(),
                    Initials = "RJ",
                    Name = "Rio de Janeiro",
                    CreateAt = DateTime.UtcNow,
                    UpdateAt = DateTime.UtcNow
                },
                new UfEntity()
                {
                    Id = Guid.NewGuid(),
                    Initials = "MG",
                    Name = "Minas Gerais",
                    CreateAt = DateTime.UtcNow,
                    UpdateAt = DateTime.UtcNow
                }
            );
        }
    }
}