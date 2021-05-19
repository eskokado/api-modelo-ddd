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
        public static void ConfigureDependenciesRepository(IServiceCollection serviceCollection) 
        {
            serviceCollection.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            serviceCollection.AddScoped<IUserRepository, UserImplementation>();

            serviceCollection.AddDbContext<MyContext> (
                options => options.UseMySql("Server=localhost;Port=3306;Database=dbApiCourseCsharp;Uid=root;Pwd=root")
            );
        }
    }
}