using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.Cep;
using Api.Domain.Interfaces.Services.Cep;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.Cep.WhenToRequestUpdate
{
    public class ReturnUpdated
    {
        private CepsController _controller;

        [Fact(DisplayName = "É possivel realizar o Updated")]
        public async Task It_is_possible_to_create_Updated()
        {
            var serviceMock = new Mock<ICepService>();
            var id = Guid.NewGuid();
            var cep = Faker.Address.ZipCode();
            var logradouro = Faker.Address.StreetAddress();
            var numero = Faker.RandomNumber.Next(1, 99999).ToString();
            var countyId = Guid.NewGuid();

            serviceMock.Setup(m => m.Put(It.IsAny<CepDtoUpdate>())).ReturnsAsync(
                new CepDtoUpdateResult 
                { 
                    Id = id,
                    Cep = cep,
                    Logradouro = logradouro,
                    Numero = numero,
                    CountyId = countyId,
                    UpdateAt = DateTime.UtcNow
                }
            );

            _controller = new CepsController(serviceMock.Object);


            var cepDtoUpdate = new CepDtoUpdate
            {
                Id = id,
                Cep = cep,
                Logradouro = logradouro,
                Numero = numero,
                CountyId = countyId,
            };

            var result = await _controller.Put(cepDtoUpdate);
            Assert.True(result is OkObjectResult);

            var resultValue = ((OkObjectResult) result).Value as CepDtoUpdateResult; 
            Assert.NotNull(resultValue);
            Assert.Equal(cepDtoUpdate.Id, resultValue.Id);
            Assert.Equal(cepDtoUpdate.Cep, resultValue.Cep);
            Assert.Equal(cepDtoUpdate.Logradouro, resultValue.Logradouro);
            Assert.Equal(cepDtoUpdate.Numero, resultValue.Numero);
            Assert.Equal(cepDtoUpdate.CountyId, resultValue.CountyId);
        }
    }
}