using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.Cep;
using Api.Domain.Interfaces.Services.Cep;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.Cep.WhenToRequestGet
{
    public class ReturnBadRequest
    {
        private CepsController _controller;

        [Fact(DisplayName = "É possivel realizar o Get")]
        public async Task It_is_possible_Get
        ()
        {
            var serviceMock = new Mock<ICepService>();
            var id = Guid.NewGuid();
            var cep = Faker.Address.ZipCode();
            var logradouro = Faker.Address.StreetAddress();
            var numero = Faker.RandomNumber.Next(1, 99999).ToString();
            var countyId = Guid.NewGuid();

            serviceMock
            .Setup(m => m.Get(id)).ReturnsAsync(
                new CepDto 
                { 
                    Id = id,
                    Cep = cep,
                    Logradouro = logradouro,
                    Numero = numero,
                    CountyId = countyId,
                    CreateAt = DateTime.UtcNow,
                    UpdateAt = DateTime.UtcNow
                }
            );

            _controller = new CepsController(serviceMock.Object);
            _controller
                .ModelState
                .AddModelError("Id", "Registro inexistente");


            var result = await _controller.Get(id);
            Assert.True(result is BadRequestObjectResult);
            Assert.False(_controller.ModelState.IsValid);
        }   
        
    }
}