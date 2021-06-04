using System;
using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Infra.Data.Seeds
{
    public class UserSeeds
    {
        public static void Users(ModelBuilder modelBuilder) 
        {
            
            modelBuilder.Entity<UserEntity>().HasData(
                new UserEntity {
                    Id = Guid.NewGuid(),
                    Name = "Edson Shideki Kokado",
                    Email = "eskokado@email.com",
                    CreateAt = DateTime.UtcNow,
                    UpdateAt = DateTime.UtcNow
                },
                new UserEntity {
                    Id = Guid.NewGuid(),
                    Name = "Maria da Silva",
                    Email = "mariasilva@email.com",
                    CreateAt = DateTime.UtcNow,
                    UpdateAt = DateTime.UtcNow
                },
                new UserEntity {
                    Id = Guid.NewGuid(),
                    Name = "José Souza",
                    Email = "josesouza@email.com",
                    CreateAt = DateTime.UtcNow,
                    UpdateAt = DateTime.UtcNow
                }
            );

        }
    }
}