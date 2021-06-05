using System.Text;
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
    public class CrudCepComplet : BaseTest, IClassFixture<DbTest>
    {
        private ServiceProvider _serviceProvider;

        public CrudCepComplet(DbTest dbTest)
        {
            _serviceProvider = dbTest.ServiceProvider;
        }

        [Fact(DisplayName = "Cep CRUD")]
        [Trait("CRUD", "CepEntity")]
        public async Task It_is_possible_to_perform_Cep_CRUD()
        {
            using (var context = _serviceProvider.GetService<MyContext>())
            {
                CountyImplementation _countyRepository = new CountyImplementation(context);
                CountyEntity _countyEntity = new CountyEntity 
                {
                     Id = Guid.NewGuid(),
                     Name = "São Paulo",
                     CodeIBGE = 12345,
                     UfId = new Guid("e7e416de-477c-4fa3-a541-b5af5f35ccf6"),
                     CreateAt = DateTime.UtcNow
                };
                var _county_record_created = await _countyRepository.InsertAsync(_countyEntity);

                CepImplementation _repositorio = new CepImplementation(context);
                CepEntity _entity = new CepEntity 
                {
                    Id = Guid.NewGuid(),
                    Logradouro = Faker.Address.StreetName(),
                    CountyId = _countyEntity.Id,
                    Cep = Faker.Address.ZipCode(),
                    Numero = "1234",                    
                    CreateAt = DateTime.UtcNow
                };
                var _record_created = await _repositorio.InsertAsync(_entity);
                Assert.NotNull(_record_created);
                Assert.Equal(_entity.Logradouro, _record_created.Logradouro);
                Assert.Equal(_entity.CountyId, _record_created.CountyId);
                Assert.Equal(_entity.Cep, _record_created.Cep);
                Assert.Equal(_entity.Numero, _record_created.Numero);
                Assert.True(_record_created.Id == _entity.Id);


                _entity = _record_created;
                _entity.Logradouro = Faker.Address.SecondaryAddress();
                _entity.Numero = "4321";
                _entity.Cep = Faker.Address.ZipCode();

                var _record_update = await _repositorio.UpdateAsync(_entity);
                Assert.Equal(_entity, _record_update);
                Assert.True(_record_update.Id == _entity.Id);

                var _record_exists = await _repositorio.ExistAsync(_entity.Id);
                Assert.True(_record_exists);

                var _find_by_cep = await _repositorio.FindCompleteByCep(_entity.Cep);
                Assert.NotNull(_find_by_cep);
                Assert.Equal(_entity.Logradouro, _find_by_cep.Logradouro);
                Assert.Equal(_entity.CountyId, _find_by_cep.CountyId);
                Assert.Equal(_entity.Cep, _find_by_cep.Cep);
                Assert.Equal(_entity.Numero, _find_by_cep.Numero);
                Assert.True(_find_by_cep.Id == _entity.Id);

                var _selected = await _repositorio.SelectAsync(_entity.Id);
                Assert.Equal(_entity, _selected);

                var _removed = await _repositorio.DeleteAsync(_entity.Id);
                Assert.True(_removed);
            }
        }
    }
}