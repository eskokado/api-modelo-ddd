using Microsoft.Extensions.DependencyInjection;
using Api.Service.Services;
using Api.Domain.Interfaces.Services.User;

namespace Api.Infra.CrossCutting.DependencyInjection
{
    public class ConfigureService
    {
        public static void ConfigureDependenciesService(IServiceCollection serviceCollection) {
            serviceCollection.AddTransient<IUserService, UserService>();
        }
    }
}