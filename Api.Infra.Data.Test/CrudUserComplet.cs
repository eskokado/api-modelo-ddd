using System;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Infra.Data.Context;
using Api.Infra.Data.Implementations;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Api.Infra.Data.Test
{
    public class CrudUserComplet : BaseTest, IClassFixture<DbTest>
    {
        private ServiceProvider _serviceProvider;

        public CrudUserComplet(DbTest dbTest)
        {
            _serviceProvider = dbTest.ServiceProvider;
        }

        [Fact(DisplayName = "User CRUD")]
        [Trait("CRUD", "UserEntity")]
        public async Task It_is_possible_to_perform_User_CRUD()
        {
            using (var context = _serviceProvider.GetService<MyContext>())
            {
                UserImplementation _repositorio = new UserImplementation(context);
                UserEntity _entity = new UserEntity 
                {
                    Email = Faker.Internet.Email(),
                    Name = Faker.Name.FullName()
                };
                var _record_created = await _repositorio.InsertAsync(_entity);
                Assert.NotNull(_record_created);
                Assert.Equal(_entity.Email, _record_created.Email);
                Assert.Equal(_entity.Name, _record_created.Name);
                Assert.False(_record_created.Id == Guid.NewGuid());
            }
        }
    }
}