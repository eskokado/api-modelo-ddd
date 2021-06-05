using System;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Infra.Data.Context;
using Api.Infra.Data.Implementations;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Api.Infra.Data.Test
{
    public class CrudUfComplet : BaseTest, IClassFixture<DbTest>
    {
        private ServiceProvider _serviceProvider;

        public CrudUfComplet(DbTest dbTest)
        {
            _serviceProvider = dbTest.ServiceProvider;
        }

        [Fact(DisplayName = "Uf CRUD")]
        [Trait("CRUD", "UfEntity")]
        public async Task It_is_possible_to_perform_Uf_CRUD()
        {
            using (var context = _serviceProvider.GetService<MyContext>())
            {
                UfImplementation _repositorio = new UfImplementation(context);
                UfEntity _entity = new UfEntity 
                {
                     Id = Guid.NewGuid(),
                     Initials = "XR",
                     Name = "Xara",
                     CreateAt = DateTime.UtcNow
                };
                var _record_created = await _repositorio.InsertAsync(_entity);
                Assert.NotNull(_record_created);
                Assert.Equal(_entity.Initials, _record_created.Initials);
                Assert.Equal(_entity.Name, _record_created.Name);
                Assert.True(_record_created.Id == _entity.Id);

                _entity = _record_created;
                _entity.Name = Faker.Name.First();
                _entity.Initials = "XX";

                var _record_update = await _repositorio.UpdateAsync(_entity);
                Assert.Equal(_entity, _record_update);
                Assert.True(_record_update.Id == _entity.Id);

                var _record_exists = await _repositorio.ExistAsync(_entity.Id);
                Assert.True(_record_exists);

                var _find_by_name = await _repositorio.FindByName(_entity.Name);
                Assert.True(_find_by_name.Count() > 0);

                var _selected = await _repositorio.SelectAsync(_entity.Id);
                Assert.Equal(_entity, _selected);

                var _removed = await _repositorio.DeleteAsync(_entity.Id);
                Assert.True(_removed);
            }
        }
    }
}