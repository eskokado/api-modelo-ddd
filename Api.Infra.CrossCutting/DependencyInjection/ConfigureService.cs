using Microsoft.Extensions.DependencyInjection;
using Api.Service.Services;
using Api.Domain.Interfaces.Services.User;
using Api.Domain.Interfaces.Services.Uf;
using Api.Domain.Interfaces.Services.County;
using Api.Domain.Interfaces.Services.Cep;

namespace Api.Infra.CrossCutting.DependencyInjection
{
    public class ConfigureService
    {
        public static void ConfigureDependenciesService(IServiceCollection serviceCollection) {
            serviceCollection.AddTransient<ILoginService, LoginService>();
            serviceCollection.AddTransient<IUserService, UserService>();
            serviceCollection.AddTransient<IUfService, UfService>();
            serviceCollection.AddTransient<ICountyService, CountyService>();
            serviceCollection.AddTransient<ICepService, CepService>();
        }
    }
}