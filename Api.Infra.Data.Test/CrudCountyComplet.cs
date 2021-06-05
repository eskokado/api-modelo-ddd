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
    public class CrudCountyComplet : BaseTest, IClassFixture<DbTest>
    {
        private ServiceProvider _serviceProvider;

        public CrudCountyComplet(DbTest dbTest)
        {
            _serviceProvider = dbTest.ServiceProvider;
        }

        [Fact(DisplayName = "County CRUD")]
        [Trait("CRUD", "CountyEntity")]
        public async Task It_is_possible_to_perform_County_CRUD()
        {
            using (var context = _serviceProvider.GetService<MyContext>())
            {
                CountyImplementation _repositorio = new CountyImplementation(context);
                CountyEntity _entity = new CountyEntity 
                {
                     Id = Guid.NewGuid(),
                     Name = "São Paulo",
                     CodeIBGE = 12345,
                     UfId = new Guid("e7e416de-477c-4fa3-a541-b5af5f35ccf6"),
                     CreateAt = DateTime.UtcNow
                };
                var _record_created = await _repositorio.InsertAsync(_entity);
                Assert.NotNull(_record_created);
                Assert.Equal(_entity.CodeIBGE, _record_created.CodeIBGE);
                Assert.Equal(_entity.Name, _record_created.Name);
                Assert.Equal(_entity.UfId, _record_created.UfId);
                Assert.True(_record_created.Id == _entity.Id);

                _entity = _record_created;
                _entity.Name = Faker.Name.First();
                _entity.CodeIBGE = 4321;

                var _record_update = await _repositorio.UpdateAsync(_entity);
                Assert.Equal(_entity, _record_update);
                Assert.True(_record_update.Id == _entity.Id);

                var _record_exists = await _repositorio.ExistAsync(_entity.Id);
                Assert.True(_record_exists);

                var _find_by_name = await _repositorio.FindCompleteByName(_entity.Name);
                Assert.True(_find_by_name.Count() > 0);

                var _find_by_ibge = await _repositorio.FindCompleteByIBGE(_entity.CodeIBGE);
                Assert.Equal(_find_by_ibge.Name, _entity.Name);
                Assert.Equal(_find_by_ibge.Id, _entity.Id);
                Assert.Equal(_find_by_ibge.Uf, _entity.Uf);
                Assert.Equal(_find_by_ibge.UfId, _entity.UfId);
                Assert.Equal(_find_by_ibge.CodeIBGE, _entity.CodeIBGE);

                var _selected = await _repositorio.SelectAsync(_entity.Id);
                Assert.Equal(_entity, _selected);

                var _removed = await _repositorio.DeleteAsync(_entity.Id);
                Assert.True(_removed);
            }
        }
    }
}