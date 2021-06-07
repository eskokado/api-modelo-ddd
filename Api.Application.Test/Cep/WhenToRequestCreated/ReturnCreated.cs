using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.Cep;
using Api.Domain.Interfaces.Services.Cep;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.Cep.WhenToRequestCreated
{
    public class ReturnCreated
    {
        private CepsController _controller;

        [Fact(DisplayName = "É possivel realizar o Created")]
        public async Task It_is_possible_to_create_Created()
        {
            var serviceMock = new Mock<ICepService>();
            var id = Guid.NewGuid();
            var cep = Faker.Address.ZipCode();
            var logradouro = Faker.Address.StreetAddress();
            var numero = Faker.RandomNumber.Next(1, 99999).ToString();
            var countyId = Guid.NewGuid();

            serviceMock.Setup(m => m.Post(It.IsAny<CepDtoCreate>())).ReturnsAsync(
                new CepDtoCreateResult 
                { 
                    Id = id,
                    Cep = cep,
                    Logradouro = logradouro,
                    Numero = numero,
                    CountyId = countyId,
                    CreateAt = DateTime.UtcNow
                }
            );

            _controller = new CepsController(serviceMock.Object);

            Mock<IUrlHelper> url = new Mock<IUrlHelper>();
            url.Setup(x => x.Link(It.IsAny<string>(), It.IsAny<object>())).Returns("http://localhost:5000");
            _controller.Url = url.Object;

            var cepDtoCreate = new CepDtoCreate
            {
                Cep = cep,
                Logradouro = logradouro,
                Numero = numero,
                CountyId = countyId,
            };

            var result = await _controller.Post(cepDtoCreate);
            Assert.True(result is CreatedResult);

            var resultValue = ((CreatedResult) result).Value as CepDtoCreateResult; 
            Assert.NotNull(resultValue);
            Assert.Equal(cepDtoCreate.Cep, resultValue.Cep);
            Assert.Equal(cepDtoCreate.Logradouro, resultValue.Logradouro);
            Assert.Equal(cepDtoCreate.Numero, resultValue.Numero);
            Assert.Equal(cepDtoCreate.CountyId, resultValue.CountyId);
        }
    }
}