using System;
using Api.Domain.Entities;
using Api.Infra.Data.Mapping;
using Api.Infra.Data.Seeds;
using Microsoft.EntityFrameworkCore;

namespace Api.Infra.Data.Context
{
    public class MyContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }

        public MyContext(DbContextOptions<MyContext> options) :
            base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserEntity>(new UserMap().Configure);

            modelBuilder.Entity<UfEntity>(new UfMap().Configure);
            modelBuilder.Entity<CountyEntity>(new CountyMap().Configure);
            modelBuilder.Entity<CepEntity>(new CepMap().Configure);

            UfSeeds.Ufs(modelBuilder);
        }
    }
}
