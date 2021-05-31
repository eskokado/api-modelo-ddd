using System;
using Api.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Api.Infra.Data.Test
{
    public abstract class BaseTest
    {
        public BaseTest()
        {
            
        }
    }

    public class DbTest : IDisposable
    {
        private string dataBaseName = $"dbApiTest_{Guid.NewGuid().ToString().Replace("-", string.Empty)}";

        public DbTest()
        {
            var connectionString =
                $"Persist Security Info=True;Server=localhost;Database={dataBaseName};User=root;Password=root";

            var serviceCollection = new ServiceCollection();
            serviceCollection.AddDbContext<MyContext>(o => 
                o.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)),
                ServiceLifetime.Transient
            );

            ServiceProvider = serviceCollection.BuildServiceProvider();
            using (var context = ServiceProvider.GetService<MyContext>())
            {
                context.Database.EnsureCreated();
            }
        }

        public ServiceProvider ServiceProvider { get; private set; }
        
        public void Dispose()
        {
            using (var context = ServiceProvider.GetService<MyContext>())
            {
                context.Database.EnsureDeleted();
            }
        }
    }
}
