using System;
using Api.Domain.Interfaces;
using Api.Domain.Repository;
using Api.Infra.Data.Context;
using Api.Infra.Data.Implementations;
using Api.Infra.Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Infra.CrossCutting.DependencyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(
            IServiceCollection serviceCollection
        )
        {
            serviceCollection
                .AddScoped(typeof (IRepository<>), typeof (BaseRepository<>));
            serviceCollection.AddScoped<IUserRepository, UserImplementation>();
            serviceCollection.AddScoped<IUfRepository, UfImplementation>();
            serviceCollection.AddScoped<ICountyRepository, CountyImplementation>();
            serviceCollection.AddScoped<ICepRepository, CepImplementation>();

            if (
                Environment.GetEnvironmentVariable("DATABASE").ToLower() ==
                "SQLSERVER".ToLower()
            )
            {
                serviceCollection
                    .AddDbContext<MyContext>(options =>
                        options
                            .UseSqlServer(Environment
                                .GetEnvironmentVariable("DATABASE")));
            }
            else
            {
                string mySqlConnectionStr = Environment.GetEnvironmentVariable("DB_CONNECTION");
                serviceCollection.AddDbContext<MyContext>(
                    options =>
                      options.UseMySql(mySqlConnectionStr,
                                          ServerVersion.AutoDetect(mySqlConnectionStr))
                    );
            }
        }
    }
}
